using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeta.Bot;
using Zeta.Bot.Coroutines;
using Zeta.Bot.Profile;
using Zeta.Common;
using Zeta.Game;
using Zeta.Game.Internals;
using Zeta.Game.Internals.Actors;
using Zeta.Game.Internals.Actors.Gizmos;
using Zeta.Game.Internals.SNO;
using Zeta.TreeSharp;
using Zeta.XmlEngine;
using System.Diagnostics;

namespace ItemCount
{
    public class StashEvents
    {
        private bool _stashOpen = false;
        private bool _countDone = false;
        
        
        public StashEvents()
        {
            _stashOpen = false;
            _countDone = false;
        }

        public void StashCheck()
        {
            if (!_stashOpen && UIElements.StashWindow.IsVisible)
            {
				_stashOpen = true;
				//Logger.Log("Stash Open check works");
				if (!_countDone)
				{
					//run itemcount function
                    Logger.Log("Stash is open, Start ItemCount");
                    ItemCountTabUI.ShowItemCount();
					_countDone = true;
				}
			}
            if (!UIElements.StashWindow.IsVisible)
            {
                _stashOpen = false;
                _countDone = false;
            }
		}

        public void PauseBot(double seconds)
        {
            BotMain.PauseFor(TimeSpan.FromSeconds(seconds));
        }
    }
	
}
