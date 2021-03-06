﻿using Game.Models;
using Game.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoundOverPage: ContentPage
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public RoundOverPage()
        {
            InitializeComponent();

            // Update the Round Count
            TotalRound.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.RoundCount.ToString();

            // Update the Found Number
            TotalFound.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Count().ToString();

            // Update the Selected Number, this gets updated later when selected refresh happens
            //TotalSelected.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Count().ToString();

            DrawCharacterList();

            DrawItemLists();
        }

        /// <summary>
        /// Clear and Add the Characters that survived
        /// </summary>
        public void DrawCharacterList()
        {
            // Clear and Populate the Characters Remaining
            var FlexList = CharacterListFrame.Children.ToList();
            foreach (var data in FlexList)
            {
                CharacterListFrame.Children.Remove(data);
            }

            // Draw the Characters
            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList)
            {
                CharacterListFrame.Children.Add(CreatePlayerDisplayBox(data));
            }
        }

        /// <summary>
        /// Draw the List of Items
        /// 
        /// The Ones Dropped
        /// 
        /// The Ones Selected
        /// 
        /// </summary>
        public void DrawItemLists()
        {
            DrawDroppedItems();
            //DrawSelectedItems();

            // Only need to update the selected, the Dropped is set in the constructor
            //TotalSelected.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Count().ToString();
        }

        /// <summary>
        /// Add the Dropped Items to the Display
        /// </summary>
        public void DrawDroppedItems()
        {
            // Clear and Populate the Dropped Items
            var FlexList = ItemListFoundFrame.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemListFoundFrame.Children.Remove(data);
            }

            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Distinct())
            {
                ItemListFoundFrame.Children.Add(GetItemToDisplay(data));
            }
        }

        ///// <summary>
        ///// Add the Dropped Items to the Display
        ///// </summary>
        //public void DrawSelectedItems()
        //{
        //    // Clear and Populate the Dropped Items
        //    var FlexList = ItemListSelectedFrame.Children.ToList();
        //    foreach (var data in FlexList)
        //    {
        //        ItemListSelectedFrame.Children.Remove(data);
        //    }

        //    foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList)
        //    {
        //        ItemListSelectedFrame.Children.Add(GetItemToDisplay(data));
        //    }
        //}

        /// <summary>
        /// Look up the Item to Display
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout GetItemToDisplay(ItemModel item)
        {
            if (item == null)
            {
                return new StackLayout();
            }

            if (string.IsNullOrEmpty(item.Id))
            {
                return new StackLayout();
            }

            // Defualt Image is the Plus
            var ClickableButton = true;

            var data = ItemIndexViewModel.Instance.GetItem(item.Id);
            if (data == null)
            {
                // Show the Default Icon for the Location
                data = new ItemModel { Name="Unknown", ImageURI = "icon_cancel.png" };

                // Turn off click action
                ClickableButton = false;
            }

            // Hookup the Image Button to show the Item picture
            var ItemButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ImageBattleMediumStyle"],
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Source = data.ImageURI
            };

            // Hookup the background image
            var BackgroundImage = new Image
            {
                Style = (Style)Application.Current.Resources["ImageBattleLargeStyle"],
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Source = "item_background.png"
            };

            // Player Image Grid
            var ImageGrid = new Grid()
            {
                RowDefinitions =
            {
                new RowDefinition()
            }
            };

            // Row 0
            ImageGrid.Children.Add(BackgroundImage);
            ImageGrid.Children.Add(ItemButton);

            if (ClickableButton)
            {
                // Add a event to the user can click the item and see more
                ItemButton.Clicked += (sender, args) => ShowPopup(data);
            }

            var ItemNameLabel = new Label()
            {
                Text = data.Name,
                TextColor = Color.DarkOrange,
                Style = (Style)Application.Current.Resources["ValueStyle"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            // Put the Image Button and Text inside a layout
            var ItemStack = new StackLayout
            {
                Padding = 3,
                Style = (Style)Application.Current.Resources["ItemImageBox"],
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    ImageGrid,
                },
            };

            return ItemStack;
        }

        /// <summary>
        /// Return a stack layout with the Player information inside
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StackLayout CreatePlayerDisplayBox(PlayerInfoModel data)
        {
            if (data == null)
            {
                data = new PlayerInfoModel();
            }

            // Hookup the image
            var PlayerImage = new Image
            {
                Style = (Style)Application.Current.Resources["ImageBattleLargeStyle"],
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Source = data.ImageURI,
                IsAnimationPlaying = true
            };

            // Add the Level
            var PlayerLevelLabel = new Label
            {
                Text = "Level: " + data.Level,
                TextColor = Color.DarkOrange,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            // Add the HP
            var PlayerHPLabel = new Label
            {
                Text = "Hp:" + data.GetCurrentHealthTotal,
                TextColor = Color.DarkOrange,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                Padding = 1,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            // Add the Speed
            var PlayerSpeedLabel = new Label
            {
                Text = "Spd:" + data.Speed,
                TextColor = Color.DarkOrange,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                Padding = 1,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            // Add the Attack
            var PlayerAttackLabel = new Label
            {
                Text = "Atk:" + data.Attack,
                TextColor = Color.DarkOrange,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                Padding = 1,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            // Add the Defense
            var PlayerDefenseLabel = new Label
            {
                Text = "Def:" + data.Defense,
                TextColor = Color.DarkOrange,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                Padding = 1,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            var PlayerNameLabel = new Label()
            {
                Text = data.Name,
                TextColor = Color.DarkOrange,
                Style = (Style)Application.Current.Resources["ValueStyle"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            // Put player information into Grid
            var AttributeGrid = new Grid()
            {
                RowDefinitions =
            {
                new RowDefinition(),
                new RowDefinition()
            },
                ColumnDefinitions =
            {
                new ColumnDefinition(),
                new ColumnDefinition()
            }
            };

            // Row 0
            AttributeGrid.Children.Add(PlayerAttackLabel);
            AttributeGrid.Children.Add(PlayerDefenseLabel, 0, 1);

            // Row 1
            AttributeGrid.Children.Add(PlayerHPLabel, 1, 0);
            AttributeGrid.Children.Add(PlayerSpeedLabel, 1, 1);

            // Put the Image Button and Text inside a layout
            var PlayerStack = new StackLayout
            {
                Style = (Style)Application.Current.Resources["PlayerInfoBox"],
                HorizontalOptions = LayoutOptions.Center,
                Padding = 2,
                Spacing = 0,
                Children = {
                    PlayerNameLabel,
                    PlayerImage,
                    AttributeGrid,
                },
            };

            return PlayerStack;
        }

        /// <summary>
        /// Show the Popup for the Item
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ShowPopup(ItemModel data)
        {
            PopupLoadingView.IsVisible = true;
            PopupItemImage.Source = data.ImageURI;

            PopupItemName.Text = data.Name;
            PopupItemDescription.Text = data.Description;
            PopupItemLocation.Text = data.Location.ToMessage();
            PopupItemAttribute.Text = data.Attribute.ToMessage();
            PopupItemValue.Text = " + " + data.Value.ToString();
            return true;
        }

        /// <summary>
        /// Close the popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClosePopup_Clicked(object sender, EventArgs e)
		{
			PopupLoadingView.IsVisible = false;
		}
		
		/// <summary>
		/// Closes the Round Over Popup
        /// 
        /// Launches the Next Round Popup
        /// 
        /// Resets the Game Round
        /// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void CloseButton_Clicked(object sender, EventArgs e)
		{
            // Reset to a new Round
            BattleEngineViewModel.Instance.Engine.Round.NewRound();

            // Show the New Round Screen
            ShowModalNewRoundPage();
		}

		/// <summary>
		/// Start next Round, returning to the battle screen
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void AutoAssignButton_Clicked(object sender, EventArgs e)
		{
            // Distribute the Items
            //BattleEngineViewModel.Instance.Engine.Round.PickupItemsForAllCharacters();

            // Show what was picked up
            //DrawItemLists();

            await Navigation.PushModalAsync(new PickItemsPage());
        }

        /// <summary>
        /// Show the Page for New Round
        /// 
        /// Upcomming Monsters
        /// 
        /// </summary>
        public async void ShowModalNewRoundPage()
        {
            await Navigation.PopModalAsync();
        }

    }
}