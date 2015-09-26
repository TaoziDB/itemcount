using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Diagnostics;
using System.Configuration;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Documents;
using Zeta.Common;
using Zeta.Common.Plugins;
using Zeta.Common.Xml;
using Zeta.Bot;
using Zeta.Bot.Profile;
using Zeta.Bot.Profile.Composites;
using Zeta.Game;
using Zeta.Game.Internals.Actors;
using Zeta.Bot.Navigation;
using Zeta.TreeSharp;
using Zeta.XmlEngine;

namespace ItemCount
{

											
	public static class Logger
    {
        private static readonly log4net.ILog Logging = Zeta.Common.Logger.GetLoggerInstanceForType();

        public static void Log(string message, params object[] args)
        {
            StackFrame frame = new StackFrame(1);
            var method = frame.GetMethod();
            var type = method.DeclaringType;

            Logging.InfoFormat("[ItemCount] " + string.Format(message, args), type.Name);
        }

        public static void Log(string message)
        {
            Log(message, string.Empty);			
        }
    }

    public class ItemCount : IPlugin
    {

        static readonly string NAME = "ItemCount";
        static readonly string AUTHOR = "Taozi";
        static readonly Version VERSION = new Version(2, 3, 1);
        static readonly string DESCRIPTION = "Count Items in Stash and Inventory";
		
		private static StashEvents eventHandler;

		
        // Plugin Auth Info
        public string Author
        {
            get
            {
                return AUTHOR;
            }
        }
        public string Description
        {
            get
            {
                return DESCRIPTION;
            }
        }
        public string Name
        {
            get
            {
                return NAME;
            }
        }
        public Version Version
        {
            get
            {
                return VERSION;
            }
        }
        public Window DisplayWindow { get { return null; } }

		


        ///////////////
        // DB EVENTS //
        public void OnDisabled()
        {
			Log("Plugin ItemCount - Disabled");
            ItemCountTabUI.RemoveTab();
			eventHandler = null;
            GameEvents.OnGameJoined -= GameEvents_OnGameJoined;
				
        }

        public void OnEnabled()
        {
		    eventHandler = new StashEvents();
            Log("Plugin ItemCount - Enabled " + Version + " now in action!");
            ItemCountTabUI.InstallTab();
			GameEvents.OnGameJoined += GameEvents_OnGameJoined;
        }
		
        void GameEvents_OnGameJoined(object sender, EventArgs e)
        {
            eventHandler = new StashEvents();
			//run itemcount function
            //Logger.Log("Game is joined, Start ItemCount");
            //ItemCountTabUI.ShowItemCount();		
		}		

        public void OnInitialize()
        {
        }

        public void OnPulse()
        {
            if (ZetaDia.Me == null)
                return;

            if (!ZetaDia.IsInGame || !ZetaDia.Me.IsValid || ZetaDia.IsLoadingWorld || ZetaDia.IsPlayingCutscene)
                return;
            
            eventHandler.StashCheck();		
        }

        public void OnShutdown()
        {
            eventHandler = null;
            GameEvents.OnGameJoined -= GameEvents_OnGameJoined;		
        }


        ////////////////////
        // CORE FUNCTIONS //

        // Log / Ancillary
        private void Log(string message, LogLevel logLevel = LogLevel.Info)
        {
            Logger.Log(message);
        }

        public static bool isPlayerDoingAnything()
        {
            if (Zeta.Bot.Logic.BrainBehavior.IsVendoring)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Equals(IPlugin other)
        {
            return Name.Equals(other.Name) && Author.Equals(other.Author) && Version.Equals(other.Version);
        }
    }

    //////////////
    // XML TAGS //
 
     public static class ItemCounter
    {

		public static long[] myitemCount = 	{
                                            0,
                                            0,
                                            0,
                                            0,
                                            0,
                                            0,
                                            0,
                                            0,
                                            0,
                                            0,
                                            0,
                                            0,
                                            0,
                                            0,
                                            0,
                                            0,
                                            0,
                                            0,
                                            0,
                                            0
											};	
        private static readonly int[] myitemSNO = 	{
                                                    365020,
                                                    408416,
                                                    361989,
                                                    361988,
                                                    361986,
                                                    361985,
                                                    361984,
                                                    364281,
                                                    364290,
                                                    364305,
                                                    364975,
                                                    366946,
                                                    366947,
                                                    366948,
                                                    366949,
                                                    403611,
                                                    364722,
                                                    364723,
                                                    364724,
                                                    364725
													};
        private static readonly string[] myitemName = 	{
														"Khanduran Rune",
														"Greater Rift Keystone",
														"Death's Breath",
														"Forgotten Soul",
														"Veiled Crystal",
														"Arcane Dust",
														"Reusable Parts",
														"Caldeum Nightshade",
														"Arreat War Tapestry",
														"Corrupted Angel Flesh",
														"Westmarch Holy Water",
														"Infernal Machine of Bones",
														"Infernal Machine of Gluttony",
														"Infernal Machine of War",
														"Infernal Machine of Evil",
														"Ramaladni's Gift",
                                                        "Leoric's Regret",
                                                        "Vial of Putridness",
                                                        "Idol of Terror",
                                                        "Heart of Evil"
														};


        private static bool IsMyItemSno(int sno)
        {
            return myitemSNO.Any(k => k == sno);
        }

        private static void AddToMyItemCount(int sno, long increment)
        {
            if (IsMyItemSno(sno))
            {
                myitemCount[myitemSNO.IndexOf(sno)] += increment;
            }
        }

        public static void Refresh()
        {
            for (int i = 0; i < myitemCount.Length; i++)
            {
                myitemCount[i] = 0;
            }

            foreach (ACDItem item in ZetaDia.Me.Inventory.StashItems)
            {
                if (IsMyItemSno(item.ActorSNO))
                {
					if (item.ItemStackQuantity == 0) //for non-stackable item, item.ItemStackQuantity is 0
					{
						AddToMyItemCount(item.ActorSNO, 1);
					}
                    if (item.ItemStackQuantity != 0)
					{
						AddToMyItemCount(item.ActorSNO, item.ItemStackQuantity);
					}
                }
            }

            foreach (ACDItem item in ZetaDia.Me.Inventory.Backpack)
            {
                if (IsMyItemSno(item.ActorSNO))
                {
					if (item.ItemStackQuantity == 0) //for non-stackable item, item.ItemStackQuantity is 0
					{
						AddToMyItemCount(item.ActorSNO, 1);
					}
                    if (item.ItemStackQuantity != 0)
					{
						AddToMyItemCount(item.ActorSNO, item.ItemStackQuantity);
					}
                }
            }
        }
		
        public static void Lister()
        {
            foreach (ACDItem item in ZetaDia.Me.Inventory.StashItems)
            {
				Logger.Log(string.Format("{0},{1},{2}", item.Name, item.ActorSNO, item.ItemStackQuantity));
//				ItemCountTabUI.Log(string.Format("{0},{1},{2}", item.Name, item.ActorSNO, item.ItemStackQuantity));
            }

            foreach (ACDItem item in ZetaDia.Me.Inventory.Backpack)
            {
				Logger.Log(string.Format("{0},{1},{2}", item.Name, item.ActorSNO, item.ItemStackQuantity));
//				ItemCountTabUI.Log(string.Format("{0},{1},{2}", item.Name, item.ActorSNO, item.ItemStackQuantity));
            }
        }		

        public static void PrintStatistics()
        {
            for (int i = 0; i < myitemCount.Length; i++)
            {
                Logger.Log(string.Format("{0} => {1}", myitemName[i], myitemCount[i]));
//				ItemCountTabUI.Log(string.Format("{0} => {1}", myitemName[i], myitemCount[i]));
            }
        }

    }

    // ItemCount
    [XmlElement("RunItemCount")]
    public class RunItemCount : ProfileBehavior
    {
        private bool m_IsDone = false;
        public override bool IsDone
        {
            get
            {
                return m_IsDone;
            }
        }
		
        protected override Composite CreateBehavior()
        {
            return new Zeta.TreeSharp.Action(ret =>
            {
                ItemCountTabUI.ShowItemCount();
                m_IsDone = true;				
            });
        }

        public override void ResetCachedDone()
        {
            m_IsDone = false;
            base.ResetCachedDone();
        }

        private void Log(string message, LogLevel logLevel = LogLevel.Info)
        {
            Logger.Log(message);
        }
    }

    
    [XmlElement("RunItemLister")]
    public class RunItemLister : ProfileBehavior
    {
        private bool m_IsDone = false;
        public override bool IsDone
        {
            get
            {
                return m_IsDone;
            }
        }
		
        protected override Composite CreateBehavior()
        {
            return new Zeta.TreeSharp.Action(ret =>
            {
                Thread.Sleep(500);
				ZetaDia.Actors.Update();
                //ItemCounter.Refresh();
                //ItemCounter.PrintStatistics();
				ItemCounter.Lister();
				Thread.Sleep(500);
                m_IsDone = true;				
            });
        }

        public override void ResetCachedDone()
        {
            m_IsDone = false;
            base.ResetCachedDone();
        }

        private void Log(string message, LogLevel logLevel = LogLevel.Info)
        {
            Logger.Log(message);
        }
    }	
 
}
