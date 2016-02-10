using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Documents;
using Zeta.Bot;
using Zeta.Bot.Dungeons;
using Zeta.Bot.Logic;
using Zeta.Common;
using Zeta.Game;
using Zeta.Game.Internals;
using Zeta.Game.Internals.Actors;
using Zeta.Game.Internals.Actors.Gizmos;

using System.Windows.Media.Imaging;
using System.Data;

namespace ItemCount
{

   internal static class FileManager
    {
 
        /// <summary>
        /// Gets the DemonBuddy path.
        /// </summary>
        /// <value>The demon buddy path.</value>
        public static string DemonBuddyPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_DemonBuddyPath))
                    _DemonBuddyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                return _DemonBuddyPath;
            }
        }
        private static string _DemonBuddyPath;

        /// <summary>
        /// Gets the plugin path.
        /// </summary>
        /// <value>The plugin path.</value>
        public static string PluginPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_PluginPath))
                    _PluginPath = Path.Combine(DemonBuddyPath, "Plugins", ItemCountName);
                return _PluginPath;
            }
        }
        private static string _PluginPath;

        /// <summary>
        /// The string name of ItemCountName
        /// </summary>
        public static string ItemCountName
        {
            get
            {
                return "ItemCount";
            }
        }
    }

    class ItemCountTabUI
    {

		private static Button btnCountItem, btnListItem, btnOpenLogFile;
		private static Button btnImage1, btnImage2, btnImage3, btnImage4, btnImage5;
		private static TextBox boxText1, boxText2, boxText3, boxText4, boxText5;
		private static Button btnImage6, btnImage7, btnImage8, btnImage9, btnImage10;
		private static TextBox boxText6, boxText7, boxText8, boxText9, boxText10;
		private static Button btnImage11, btnImage12, btnImage13, btnImage14, btnImage15, btnImage16;
		private static TextBox boxText11, boxText12, boxText13, boxText14, boxText15, boxText16;
        private static Button btnImage17, btnImage18, btnImage19, btnImage20;
        private static TextBox boxText17, boxText18, boxText19, boxText20;
		private static TextBox boxText0;
		private static String imagesPath;

		
        internal static void InstallTab()
        {
            Application.Current.Dispatcher.Invoke(
                new System.Action(
                    () =>
                    {
                        // 1st column x: 432
                        // 2nd column x: 552
                        // 3rd column x: 672

                        // Y rows: 10, 33, 56, 79, 102
						
				
                        btnCountItem = new Button
                        {
                            Width = 120,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Top,
                            Margin = new Thickness(3),
                            Content = "Count Items",
							ToolTip = 	"Count Items from Stash and Inventory"						
                        };
						
					

				
                        btnListItem = new Button
                        {
                            Width = 120,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Top,
                            Margin = new Thickness(3),
                            Content = "List Items",
							ToolTip = "List All Items in Stash and Inventory with Name and ActorSNO"
                        };

                        btnOpenLogFile = new Button
                        {
                            Width = 120,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Top,
                            Margin = new Thickness(3),
                            Content = "Open Log File",
							ToolTip = "Open Current Log File To See The Result of Listing and Counting"
                        };


                        Window mainWindow = Application.Current.MainWindow;

                        btnCountItem.Click += new RoutedEventHandler(btnCountItem_Click);
                        btnListItem.Click += new RoutedEventHandler(btnListItem_Click);
                        btnOpenLogFile.Click += new RoutedEventHandler(btnOpenLogFile_Click);

						Grid myGrid1 = new Grid();
						myGrid1.HorizontalAlignment = HorizontalAlignment.Stretch;
						myGrid1.VerticalAlignment = VerticalAlignment.Top;
						myGrid1.ShowGridLines = false;	
						
						// Define the Columns
						ColumnDefinition colDef11 = new ColumnDefinition();
						ColumnDefinition colDef12 = new ColumnDefinition();
						ColumnDefinition colDef13 = new ColumnDefinition();
						ColumnDefinition colDef14 = new ColumnDefinition();
						ColumnDefinition colDef15 = new ColumnDefinition();
						ColumnDefinition colDef16 = new ColumnDefinition();
						ColumnDefinition colDef17 = new ColumnDefinition();
						ColumnDefinition colDef18 = new ColumnDefinition();
						ColumnDefinition colDef19 = new ColumnDefinition();
						ColumnDefinition colDef20 = new ColumnDefinition();
						myGrid1.ColumnDefinitions.Add(colDef11);
						myGrid1.ColumnDefinitions.Add(colDef12);
						myGrid1.ColumnDefinitions.Add(colDef13);
						myGrid1.ColumnDefinitions.Add(colDef14);
						myGrid1.ColumnDefinitions.Add(colDef15);
						myGrid1.ColumnDefinitions.Add(colDef16);
						myGrid1.ColumnDefinitions.Add(colDef17);
						myGrid1.ColumnDefinitions.Add(colDef18);
						myGrid1.ColumnDefinitions.Add(colDef19);
						myGrid1.ColumnDefinitions.Add(colDef20);						

						// Define the Rows
						RowDefinition rowDef11 = new RowDefinition();
						RowDefinition rowDef12 = new RowDefinition();
						RowDefinition rowDef13 = new RowDefinition();
						RowDefinition rowDef14 = new RowDefinition();
						RowDefinition rowDef15 = new RowDefinition();
						RowDefinition rowDef16 = new RowDefinition();
						myGrid1.RowDefinitions.Add(rowDef11);
						myGrid1.RowDefinitions.Add(rowDef12);
						myGrid1.RowDefinitions.Add(rowDef13);
						myGrid1.RowDefinitions.Add(rowDef14);
						myGrid1.RowDefinitions.Add(rowDef15);
						myGrid1.RowDefinitions.Add(rowDef16);

						DataGrid dataGrid1 = new DataGrid();	

	
						boxText0 = new TextBox
							{
								HorizontalAlignment = HorizontalAlignment.Center,
								VerticalAlignment = VerticalAlignment.Center,
								Text = "",
								IsReadOnly = true
							};	
						Grid.SetColumnSpan(boxText0, 10);
						Grid.SetRowSpan(boxText0,1);
						Grid.SetRow(boxText0, 5);
						Grid.SetColumn(boxText0,0);	

						myGrid1.Children.Add(boxText0);			

						imagesPath = Path.Combine(FileManager.PluginPath, "images");
                        btnImage1 = new Button
							{
								Width = 24,
								HorizontalAlignment = HorizontalAlignment.Center,
								VerticalAlignment = VerticalAlignment.Top,
								Margin = new Thickness(3),
								 
								Content = new Image
									{
										//Source = new BitmapImage(new Uri(@"h:\1.png")),
										Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "1.png"))),
										VerticalAlignment = VerticalAlignment.Center
									},
								ToolTip = 	"Khanduran Rune"						
							};
						Grid.SetColumnSpan(btnImage1, 1);
						Grid.SetRowSpan(btnImage1,1);
						Grid.SetRow(btnImage1, 1);
						Grid.SetColumn(btnImage1,0);	

						myGrid1.Children.Add(btnImage1);
			
						boxText1 = new TextBox
							{
								HorizontalAlignment = HorizontalAlignment.Left,
								VerticalAlignment = VerticalAlignment.Center,
								Text = "0",
								IsReadOnly = true
							};	
						Grid.SetColumnSpan(boxText1, 1);
						Grid.SetRowSpan(boxText1,1);
						Grid.SetRow(boxText1, 1);
						Grid.SetColumn(boxText1,1);	

						myGrid1.Children.Add(boxText1);			

                        btnImage2 = new Button
							{
								Width = 24,
								HorizontalAlignment = HorizontalAlignment.Center,
								VerticalAlignment = VerticalAlignment.Top,
								Margin = new Thickness(3),
								 
								Content = new Image
									{
										Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "8.png"))),
										VerticalAlignment = VerticalAlignment.Center
									},
								ToolTip = 	"Caldeum Nightshade"				
							};
						Grid.SetColumnSpan(btnImage2, 1);
						Grid.SetRowSpan(btnImage2,1);
						Grid.SetRow(btnImage2, 1);
						Grid.SetColumn(btnImage2,2);	

						myGrid1.Children.Add(btnImage2);	
			
						boxText2 = new TextBox
							{
								HorizontalAlignment = HorizontalAlignment.Left,
								VerticalAlignment = VerticalAlignment.Center,
								Text = "0",
								IsReadOnly = true
							};	
						Grid.SetColumnSpan(boxText2, 1);
						Grid.SetRowSpan(boxText2,1);
						Grid.SetRow(boxText2, 1);
						Grid.SetColumn(boxText2,3);	

						myGrid1.Children.Add(boxText2);				

                        btnImage3 = new Button
							{
								Width = 24,
								HorizontalAlignment = HorizontalAlignment.Center,
								VerticalAlignment = VerticalAlignment.Top,
								Margin = new Thickness(3),
								 
								Content = new Image
									{
										Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "9.png"))),
										VerticalAlignment = VerticalAlignment.Center
									},
								ToolTip = 	"Arreat War Tapestry"					
							};
						Grid.SetColumnSpan(btnImage3, 1);
						Grid.SetRowSpan(btnImage3,1);
						Grid.SetRow(btnImage3, 1);
						Grid.SetColumn(btnImage3,4);	

						myGrid1.Children.Add(btnImage3);
			
						boxText3 = new TextBox
							{
								HorizontalAlignment = HorizontalAlignment.Left,
								VerticalAlignment = VerticalAlignment.Center,
								Text = "0",
								IsReadOnly = true
							};	
						Grid.SetColumnSpan(boxText3, 1);
						Grid.SetRowSpan(boxText3,1);
						Grid.SetRow(boxText3, 1);
						Grid.SetColumn(boxText3,5);	

						myGrid1.Children.Add(boxText3);				

                        btnImage4 = new Button
							{
								Width = 24,
								HorizontalAlignment = HorizontalAlignment.Center,
								VerticalAlignment = VerticalAlignment.Top,
								Margin = new Thickness(3),
								 
								Content = new Image
									{
										Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "10.png"))),
										VerticalAlignment = VerticalAlignment.Center
									},
								ToolTip = 	"Corrupted Angel Flesh"						
							};
						Grid.SetColumnSpan(btnImage4, 1);
						Grid.SetRowSpan(btnImage4,1);
						Grid.SetRow(btnImage4, 1);
						Grid.SetColumn(btnImage4,6);	

						myGrid1.Children.Add(btnImage4);
			
						boxText4 = new TextBox
							{
								HorizontalAlignment = HorizontalAlignment.Left,
								VerticalAlignment = VerticalAlignment.Center,
								Text = "0",
								IsReadOnly = true
							};	
						Grid.SetColumnSpan(boxText4, 1);
						Grid.SetRowSpan(boxText4,1);
						Grid.SetRow(boxText4, 1);
						Grid.SetColumn(boxText4,7);	

						myGrid1.Children.Add(boxText4);				

                        btnImage5 = new Button
							{
								Width = 24,
								HorizontalAlignment = HorizontalAlignment.Center,
								VerticalAlignment = VerticalAlignment.Top,
								Margin = new Thickness(3),
								 
								Content = new Image
									{
										Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "11.png"))),
										VerticalAlignment = VerticalAlignment.Center
									},
								ToolTip = 	"Westmarch Holy Water"							
							};
						Grid.SetColumnSpan(btnImage5, 1);
						Grid.SetRowSpan(btnImage5,1);
						Grid.SetRow(btnImage5, 1);
						Grid.SetColumn(btnImage5,8);	

						myGrid1.Children.Add(btnImage5);	

						boxText5 = new TextBox
							{
								HorizontalAlignment = HorizontalAlignment.Left,
								VerticalAlignment = VerticalAlignment.Center,
								Text = "0",
								IsReadOnly = true
							};	
						Grid.SetColumnSpan(boxText5, 1);
						Grid.SetRowSpan(boxText5,1);
						Grid.SetRow(boxText5, 1);
						Grid.SetColumn(boxText5,9);	

						myGrid1.Children.Add(boxText5);		

						btnImage6 = new Button
							{
								Width = 24,
								HorizontalAlignment = HorizontalAlignment.Center,
								VerticalAlignment = VerticalAlignment.Top,
								Margin = new Thickness(3),
								 
								Content = new Image
									{
										Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "3.png"))),
										VerticalAlignment = VerticalAlignment.Center
									},
								ToolTip = 	"Death's Breath"						
							};
						Grid.SetColumnSpan(btnImage6, 1);
						Grid.SetRowSpan(btnImage6,1);
						Grid.SetRow(btnImage6, 2);
						Grid.SetColumn(btnImage6,0);	

						myGrid1.Children.Add(btnImage6);
			
						boxText6 = new TextBox
							{
								HorizontalAlignment = HorizontalAlignment.Left,
								VerticalAlignment = VerticalAlignment.Center,
								Text = "0",
								IsReadOnly = true
							};	
						Grid.SetColumnSpan(boxText6, 1);
						Grid.SetRowSpan(boxText6,1);
						Grid.SetRow(boxText6, 2);
						Grid.SetColumn(boxText6,1);	

						myGrid1.Children.Add(boxText6);			

                        btnImage7 = new Button
							{
								Width = 24,
								HorizontalAlignment = HorizontalAlignment.Center,
								VerticalAlignment = VerticalAlignment.Top,
								Margin = new Thickness(3),
								 
								Content = new Image
									{
										Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "4.png"))),
										VerticalAlignment = VerticalAlignment.Center
									},
								ToolTip = 	"Forgotten Soul"						
							};
						Grid.SetColumnSpan(btnImage7, 1);
						Grid.SetRowSpan(btnImage7,1);
						Grid.SetRow(btnImage7, 2);
						Grid.SetColumn(btnImage7,2);	

						myGrid1.Children.Add(btnImage7);	
			
						boxText7 = new TextBox
							{
								HorizontalAlignment = HorizontalAlignment.Left,
								VerticalAlignment = VerticalAlignment.Center,
								Text = "0",
								IsReadOnly = true
							};	
						Grid.SetColumnSpan(boxText7, 1);
						Grid.SetRowSpan(boxText7,1);
						Grid.SetRow(boxText7, 2);
						Grid.SetColumn(boxText7,3);	

						myGrid1.Children.Add(boxText7);				

                        btnImage8 = new Button
							{
								Width = 24,
								HorizontalAlignment = HorizontalAlignment.Center,
								VerticalAlignment = VerticalAlignment.Top,
								Margin = new Thickness(3),
								 
								Content = new Image
									{
										Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "5.png"))),
										VerticalAlignment = VerticalAlignment.Center
									},
								ToolTip = 	"Veiled Crystal"					
							};
						Grid.SetColumnSpan(btnImage8, 1);
						Grid.SetRowSpan(btnImage8,1);
						Grid.SetRow(btnImage8, 2);
						Grid.SetColumn(btnImage8,4);	

						myGrid1.Children.Add(btnImage8);
			
						boxText8 = new TextBox
							{
								HorizontalAlignment = HorizontalAlignment.Left,
								VerticalAlignment = VerticalAlignment.Center,
								Text = "0",
								IsReadOnly = true
							};	
						Grid.SetColumnSpan(boxText8, 1);
						Grid.SetRowSpan(boxText8,1);
						Grid.SetRow(boxText8, 2);
						Grid.SetColumn(boxText8,5);	

						myGrid1.Children.Add(boxText8);				

                        btnImage9 = new Button
							{
								Width = 24,
								HorizontalAlignment = HorizontalAlignment.Center,
								VerticalAlignment = VerticalAlignment.Top,
								Margin = new Thickness(3),
								 
								Content = new Image
									{
										Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "6.png"))),
										VerticalAlignment = VerticalAlignment.Center
									},
								ToolTip = 	"Arcane Dust"						
							};
						Grid.SetColumnSpan(btnImage9, 1);
						Grid.SetRowSpan(btnImage9,1);
						Grid.SetRow(btnImage9, 2);
						Grid.SetColumn(btnImage9,6);	

						myGrid1.Children.Add(btnImage9);
			
						boxText9 = new TextBox
							{
								HorizontalAlignment = HorizontalAlignment.Left,
								VerticalAlignment = VerticalAlignment.Center,
								Text = "0",
								IsReadOnly = true
							};	
						Grid.SetColumnSpan(boxText9, 1);
						Grid.SetRowSpan(boxText9,1);
						Grid.SetRow(boxText9, 2);
						Grid.SetColumn(boxText9,7);	

						myGrid1.Children.Add(boxText9);				

                        btnImage10 = new Button
							{
								Width = 24,
								HorizontalAlignment = HorizontalAlignment.Center,
								VerticalAlignment = VerticalAlignment.Top,
								Margin = new Thickness(3),
								 
								Content = new Image
									{
										Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "7.png"))),
										VerticalAlignment = VerticalAlignment.Center
									},
								ToolTip = 	"Reusable Parts"					
							};
						Grid.SetColumnSpan(btnImage10, 1);
						Grid.SetRowSpan(btnImage10,1);
						Grid.SetRow(btnImage10, 2);
						Grid.SetColumn(btnImage10,8);	

						myGrid1.Children.Add(btnImage10);	

						boxText10 = new TextBox
							{
								HorizontalAlignment = HorizontalAlignment.Left,
								VerticalAlignment = VerticalAlignment.Center,
								Text = "0",
								IsReadOnly = true
							};	
						Grid.SetColumnSpan(boxText10, 1);
						Grid.SetRowSpan(boxText10,1);
						Grid.SetRow(boxText10, 2);
						Grid.SetColumn(boxText10,9);	

						myGrid1.Children.Add(boxText10);

						btnImage11 = new Button
							{
								Width = 24,
								HorizontalAlignment = HorizontalAlignment.Center,
								VerticalAlignment = VerticalAlignment.Top,
								Margin = new Thickness(3),
								 
								Content = new Image
									{
										Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "2.png"))),
										VerticalAlignment = VerticalAlignment.Center
									},
								ToolTip = 	"Greater Rift Keystone"						
							};
						Grid.SetColumnSpan(btnImage11, 1);
						Grid.SetRowSpan(btnImage11,1);
						Grid.SetRow(btnImage11, 3);
						Grid.SetColumn(btnImage11,0);	

						myGrid1.Children.Add(btnImage11);
			
						boxText11 = new TextBox
							{
								HorizontalAlignment = HorizontalAlignment.Left,
								VerticalAlignment = VerticalAlignment.Center,
								Text = "0",
								IsReadOnly = true
							};	
						Grid.SetColumnSpan(boxText11, 1);
						Grid.SetRowSpan(boxText11,1);
						Grid.SetRow(boxText11, 3);
						Grid.SetColumn(boxText11,1);	

						myGrid1.Children.Add(boxText11);			

                        btnImage12 = new Button
							{
								Width = 24,
								HorizontalAlignment = HorizontalAlignment.Center,
								VerticalAlignment = VerticalAlignment.Top,
								Margin = new Thickness(3),
								 
								Content = new Image
									{
										Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "12.png"))),
										VerticalAlignment = VerticalAlignment.Center
									},
								ToolTip = 	"Infernal Machine of Regret"						
							};
						Grid.SetColumnSpan(btnImage12, 1);
						Grid.SetRowSpan(btnImage12,1);
						Grid.SetRow(btnImage12, 3);
						Grid.SetColumn(btnImage12,2);	

						myGrid1.Children.Add(btnImage12);	
			
						boxText12 = new TextBox
							{
								HorizontalAlignment = HorizontalAlignment.Left,
								VerticalAlignment = VerticalAlignment.Center,
								Text = "0",
								IsReadOnly = true
							};	
						Grid.SetColumnSpan(boxText12, 1);
						Grid.SetRowSpan(boxText12,1);
						Grid.SetRow(boxText12, 3);
						Grid.SetColumn(boxText12,3);	

						myGrid1.Children.Add(boxText12);				

                        btnImage13 = new Button
							{
								Width = 24,
								HorizontalAlignment = HorizontalAlignment.Center,
								VerticalAlignment = VerticalAlignment.Top,
								Margin = new Thickness(3),
								 
								Content = new Image
									{
										Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "13.png"))),
										VerticalAlignment = VerticalAlignment.Center
									},
								ToolTip = 	"Infernal Machine of Putridness"						
							};
						Grid.SetColumnSpan(btnImage13, 1);
						Grid.SetRowSpan(btnImage13,1);
						Grid.SetRow(btnImage13, 3);
						Grid.SetColumn(btnImage13,4);	

						myGrid1.Children.Add(btnImage13);
			
						boxText13 = new TextBox
							{
								HorizontalAlignment = HorizontalAlignment.Left,
								VerticalAlignment = VerticalAlignment.Center,
								Text = "0",
								IsReadOnly = true
							};	
						Grid.SetColumnSpan(boxText13, 1);
						Grid.SetRowSpan(boxText13,1);
						Grid.SetRow(boxText13, 3);
						Grid.SetColumn(boxText13,5);	

						myGrid1.Children.Add(boxText13);				

                        btnImage14 = new Button
							{
								Width = 24,
								HorizontalAlignment = HorizontalAlignment.Center,
								VerticalAlignment = VerticalAlignment.Top,
								Margin = new Thickness(3),
								 
								Content = new Image
									{
										Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "14.png"))),
										VerticalAlignment = VerticalAlignment.Center
									},
								ToolTip = 	"Infernal Machine of Terror"						
							};
						Grid.SetColumnSpan(btnImage14, 1);
						Grid.SetRowSpan(btnImage14,1);
						Grid.SetRow(btnImage14, 3);
						Grid.SetColumn(btnImage14,6);	

						myGrid1.Children.Add(btnImage14);
			
						boxText14 = new TextBox
							{
								HorizontalAlignment = HorizontalAlignment.Left,
								VerticalAlignment = VerticalAlignment.Center,
								Text = "0",
								IsReadOnly = true
							};	
						Grid.SetColumnSpan(boxText14, 1);
						Grid.SetRowSpan(boxText14,1);
						Grid.SetRow(boxText14, 3);
						Grid.SetColumn(boxText14,7);	

						myGrid1.Children.Add(boxText14);				

                        btnImage15 = new Button
							{
								Width = 24,
								HorizontalAlignment = HorizontalAlignment.Center,
								VerticalAlignment = VerticalAlignment.Top,
								Margin = new Thickness(3),
								 
								Content = new Image
									{
										Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "15.png"))),
										VerticalAlignment = VerticalAlignment.Center
									},
								ToolTip = 	"Infernal Machine of Fright"						
							};
						Grid.SetColumnSpan(btnImage15, 1);
						Grid.SetRowSpan(btnImage15,1);
						Grid.SetRow(btnImage15, 3);
						Grid.SetColumn(btnImage15,8);	

						myGrid1.Children.Add(btnImage15);	

						boxText15 = new TextBox
							{
								HorizontalAlignment = HorizontalAlignment.Left,
								VerticalAlignment = VerticalAlignment.Center,
								Text = "0",
								IsReadOnly = true
							};	
						Grid.SetColumnSpan(boxText15, 1);
						Grid.SetRowSpan(boxText15,1);
						Grid.SetRow(boxText15, 3);
						Grid.SetColumn(boxText15,9);	

						myGrid1.Children.Add(boxText15); 

						btnImage16 = new Button
							{
								Width = 24,
								HorizontalAlignment = HorizontalAlignment.Center,
								VerticalAlignment = VerticalAlignment.Top,
								Margin = new Thickness(3),
								 
								Content = new Image
									{
										Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "16.png"))),
										VerticalAlignment = VerticalAlignment.Center
									},
								ToolTip = 	"Ramaladni's Gift"						
							};
						Grid.SetColumnSpan(btnImage16, 1);
						Grid.SetRowSpan(btnImage16,1);
						Grid.SetRow(btnImage16, 4);
						Grid.SetColumn(btnImage16,0);	

						myGrid1.Children.Add(btnImage16);	

						boxText16 = new TextBox
							{
								HorizontalAlignment = HorizontalAlignment.Left,
								VerticalAlignment = VerticalAlignment.Center,
								Text = "0",
								IsReadOnly = true
							};	
						Grid.SetColumnSpan(boxText16, 1);
						Grid.SetRowSpan(boxText16,1);
						Grid.SetRow(boxText16, 4);
						Grid.SetColumn(boxText16,1);	

						myGrid1.Children.Add(boxText16);

                        btnImage17 = new Button
                        {
                            Width = 24,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Top,
                            Margin = new Thickness(3),

                            Content = new Image
                            {
                                Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "17.png"))),
                                VerticalAlignment = VerticalAlignment.Center
                            },
                            ToolTip = "Leoric's Regret"
                        };
                        Grid.SetColumnSpan(btnImage17, 1);
                        Grid.SetRowSpan(btnImage17, 1);
                        Grid.SetRow(btnImage17, 4);
                        Grid.SetColumn(btnImage17, 2);

                        myGrid1.Children.Add(btnImage17);

                        boxText17 = new TextBox
                        {
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Center,
                            Text = "0",
                            IsReadOnly = true
                        };
                        Grid.SetColumnSpan(boxText17, 1);
                        Grid.SetRowSpan(boxText17, 1);
                        Grid.SetRow(boxText17, 4);
                        Grid.SetColumn(boxText17, 3);

                        myGrid1.Children.Add(boxText17);

                        btnImage18 = new Button
                        {
                            Width = 24,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Top,
                            Margin = new Thickness(3),

                            Content = new Image
                            {
                                Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "18.png"))),
                                VerticalAlignment = VerticalAlignment.Center
                            },
                            ToolTip = "Vial of Putridness"
                        };
                        Grid.SetColumnSpan(btnImage18, 1);
                        Grid.SetRowSpan(btnImage18, 1);
                        Grid.SetRow(btnImage18, 4);
                        Grid.SetColumn(btnImage18, 4);

                        myGrid1.Children.Add(btnImage18);

                        boxText18 = new TextBox
                        {
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Center,
                            Text = "0",
                            IsReadOnly = true
                        };
                        Grid.SetColumnSpan(boxText18, 1);
                        Grid.SetRowSpan(boxText18, 1);
                        Grid.SetRow(boxText18, 4);
                        Grid.SetColumn(boxText18, 5);

                        myGrid1.Children.Add(boxText18);

                        btnImage19 = new Button
                        {
                            Width = 24,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Top,
                            Margin = new Thickness(3),

                            Content = new Image
                            {
                                Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "19.png"))),
                                VerticalAlignment = VerticalAlignment.Center
                            },
                            ToolTip = "Idol of Terror"
                        };
                        Grid.SetColumnSpan(btnImage19, 1);
                        Grid.SetRowSpan(btnImage19, 1);
                        Grid.SetRow(btnImage19, 4);
                        Grid.SetColumn(btnImage19, 6);

                        myGrid1.Children.Add(btnImage19);

                        boxText19 = new TextBox
                        {
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Center,
                            Text = "0",
                            IsReadOnly = true
                        };
                        Grid.SetColumnSpan(boxText19, 1);
                        Grid.SetRowSpan(boxText19, 1);
                        Grid.SetRow(boxText19, 4);
                        Grid.SetColumn(boxText19, 7);

                        myGrid1.Children.Add(boxText19);

                        btnImage20 = new Button
                        {
                            Width = 24,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Top,
                            Margin = new Thickness(3),

                            Content = new Image
                            {
                                Source = new BitmapImage(new Uri(@Path.Combine(imagesPath, "20.png"))),
                                VerticalAlignment = VerticalAlignment.Center
                            },
                            ToolTip = "Heart of Fright"
                        };
                        Grid.SetColumnSpan(btnImage20, 1);
                        Grid.SetRowSpan(btnImage20, 1);
                        Grid.SetRow(btnImage20, 4);
                        Grid.SetColumn(btnImage20, 8);

                        myGrid1.Children.Add(btnImage20);

                        boxText20 = new TextBox
                        {
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Center,
                            Text = "0",
                            IsReadOnly = true
                        };
                        Grid.SetColumnSpan(boxText20, 1);
                        Grid.SetRowSpan(boxText20, 1);
                        Grid.SetRow(boxText20, 4);
                        Grid.SetColumn(boxText20, 9);

                        myGrid1.Children.Add(boxText20);
						
						

						// Create the Grid
						Grid myGrid = new Grid();
						myGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
						myGrid.VerticalAlignment = VerticalAlignment.Top;
						myGrid.ShowGridLines = false;
					

						// Define the Columns
						ColumnDefinition colDef1 = new ColumnDefinition();
						ColumnDefinition colDef2 = new ColumnDefinition();
						ColumnDefinition colDef3 = new ColumnDefinition();
						myGrid.ColumnDefinitions.Add(colDef1);
						myGrid.ColumnDefinitions.Add(colDef2);
						myGrid.ColumnDefinitions.Add(colDef3);

						// Define the Rows
						RowDefinition rowDef1 = new RowDefinition();
						RowDefinition rowDef2 = new RowDefinition();
						RowDefinition rowDef3 = new RowDefinition();
						RowDefinition rowDef4 = new RowDefinition();
						RowDefinition rowDef5 = new RowDefinition();
						RowDefinition rowDef6 = new RowDefinition();
						RowDefinition rowDef7 = new RowDefinition();
						RowDefinition rowDef8 = new RowDefinition();
						myGrid.RowDefinitions.Add(rowDef1);
						myGrid.RowDefinitions.Add(rowDef2);
						myGrid.RowDefinitions.Add(rowDef3);
						myGrid.RowDefinitions.Add(rowDef4);
						myGrid.RowDefinitions.Add(rowDef5);
						myGrid.RowDefinitions.Add(rowDef6);
						myGrid.RowDefinitions.Add(rowDef7);
						myGrid.RowDefinitions.Add(rowDef8);			
									
						Grid.SetColumnSpan(myGrid1, 3);
						Grid.SetRowSpan(myGrid1,6);
						Grid.SetRow(myGrid1, 1);

						Grid.SetColumnSpan(btnCountItem, 1);
						Grid.SetRow(btnCountItem, 0);
						Grid.SetColumn(btnCountItem, 0);
						
						Grid.SetColumnSpan(btnListItem, 1);
						Grid.SetRow(btnListItem, 0);
						Grid.SetColumn(btnListItem, 1);
						
						Grid.SetColumnSpan(btnOpenLogFile, 1);
						Grid.SetRow(btnOpenLogFile, 0);
						Grid.SetColumn(btnOpenLogFile, 2);			

						myGrid.Children.Add(myGrid1);
						myGrid.Children.Add(btnCountItem);
						myGrid.Children.Add(btnListItem);
						myGrid.Children.Add(btnOpenLogFile);

                        tabItem = new TabItem()
                        {
                            Header = "ItemCount",
                            ToolTip = "ItemCount Plugin by Taozi",
                        };

                        tabItem.Content = myGrid;

                        var tabs = mainWindow.FindName("tabControlMain") as TabControl;
                        if (tabs == null)
                            return;

                        tabs.Items.Add(tabItem);
                    }
                )
            );
        }

        private static TabItem tabItem;

        internal static void RemoveTab()
        {
            Application.Current.Dispatcher.Invoke(
                new System.Action(
                    () =>
                    {
                        Window mainWindow = Application.Current.MainWindow;
                        var tabs = mainWindow.FindName("tabControlMain") as TabControl;
                        if (tabs == null)
                            return;
                        tabs.Items.Remove(tabItem);
                    }
                )
            );
        }

		internal static void Log(string message)
        {
            Application.Current.Dispatcher.Invoke(
                new System.Action(
                    () =>
                    {

                    }
                )
            );
        }
		
        private static void btnOpenLogFile_Click(object sender, RoutedEventArgs e)
        {
            string exePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            int myPid = Process.GetCurrentProcess().Id;
            DateTime startTime = Process.GetCurrentProcess().StartTime;
            string logFile = Path.Combine(exePath, "Logs", myPid + " " + startTime.ToString("yyyy-MM-dd HH.mm") + ".txt");

            Process.Start(logFile);
        }

        private static void btnListItem_Click(object sender, RoutedEventArgs e)
        {
			if (!ZetaDia.IsInGame)
			{
			    Logger.Log("Error: The Bot needs to be in the game to use ItemCount Plugin");
				boxText0.Text = "Error: The Bot needs to be in the game to use ItemCount Plugin";
				return;
			}
			
			if (Zeta.Bot.BotMain.IsRunning && !BotMain.IsPausedForStateExecution)
            {
			    Logger.Log("Error: The Bot needs to be Paused or Stopped to use ItemCount Plugin");
				boxText0.Text = "Error: The Bot needs to be Paused or Stopped to use ItemCount Plugin";
				return;
			}
			if (!Zeta.Bot.BotMain.IsRunning || BotMain.IsPausedForStateExecution)
            {
			    Thread.Sleep(500);
				Logger.Log("----Item Listing Starts----");
                ZetaDia.Actors.Update();
				ItemCounter.Lister();
				Logger.Log("----Item Listing Is Done----");	
				Thread.Sleep(500);
				return;
			}		
		}

        internal static void ShowItemCount()
        {
            Thread.Sleep(500);
            ZetaDia.Actors.Update();
            Logger.Log("++++Item Counting Starts++++");
            Application.Current.Dispatcher.Invoke(() =>
            {
                boxText0.Text = "Counting... Please wait...";
            });
            ItemCounter.Refresh();
            ItemCounter.PrintStatistics();
            Application.Current.Dispatcher.Invoke(() =>
            {
                boxText1.Text = ItemCounter.myitemCount[0].ToString();
                boxText2.Text = ItemCounter.myitemCount[7].ToString();
                boxText3.Text = ItemCounter.myitemCount[8].ToString();
                boxText4.Text = ItemCounter.myitemCount[9].ToString();
                boxText5.Text = ItemCounter.myitemCount[10].ToString();
                boxText6.Text = ItemCounter.myitemCount[2].ToString();
                boxText7.Text = ItemCounter.myitemCount[3].ToString();
                boxText8.Text = ItemCounter.myitemCount[4].ToString();
                boxText9.Text = ItemCounter.myitemCount[5].ToString();
                boxText10.Text = ItemCounter.myitemCount[6].ToString();
                boxText11.Text = ItemCounter.myitemCount[1].ToString();
                boxText12.Text = ItemCounter.myitemCount[11].ToString();
                boxText13.Text = ItemCounter.myitemCount[12].ToString();
                boxText14.Text = ItemCounter.myitemCount[13].ToString();
                boxText15.Text = ItemCounter.myitemCount[14].ToString();
                boxText16.Text = ItemCounter.myitemCount[15].ToString();
                boxText17.Text = ItemCounter.myitemCount[16].ToString();
                boxText18.Text = ItemCounter.myitemCount[17].ToString();
                boxText19.Text = ItemCounter.myitemCount[18].ToString();
                boxText20.Text = ItemCounter.myitemCount[19].ToString();
            });
            Thread.Sleep(500);
            Logger.Log("++++Item Counting Is Done++++");
            DateTime now = DateTime.Now;
            Logger.Log("Updated on " + now.ToString());
            Application.Current.Dispatcher.Invoke(() =>
            {
                boxText0.Text = ("Updated on " + now.ToString());
            });
        }

        private static void btnCountItem_Click(object sender, RoutedEventArgs e)
        {
			if (!ZetaDia.IsInGame)
			{
			    Logger.Log("Error: The Bot needs to be in the game to use ItemCount Plugin");
				boxText0.Text = "Error: The Bot needs to be in the game to use ItemCount Plugin";
				return;
			}
			
			if (Zeta.Bot.BotMain.IsRunning && !BotMain.IsPausedForStateExecution)
            {
			    Logger.Log("Error: The Bot needs to be Paused or Stopped to use ItemCount Plugin");
				boxText0.Text = "Error: The Bot needs to be Paused or Stopped to use ItemCount Plugin";
				return;
			}
			if (!Zeta.Bot.BotMain.IsRunning || BotMain.IsPausedForStateExecution)
            {
				ShowItemCount();				
				return;
			}		
		}
    }
}
