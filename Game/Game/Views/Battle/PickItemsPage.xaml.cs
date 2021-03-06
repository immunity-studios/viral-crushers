﻿using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.Models;
using Game.ViewModels;

using System.Linq;

namespace Game.Views
{
    /// <summary>
    /// The Main Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickItemsPage : ContentPage
    {
        // The view model, used for data binding
        //readonly ItemIndexViewModel ViewModel = ItemIndexViewModel.Instance;

        /// <summary>
        /// Constructor
        /// </summary>
        public PickItemsPage()
        {

            InitializeComponent();

            // Update the Found Number
            //TotalFound.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Count().ToString();

            // Update the Selected Number, this gets updated later when selected refresh happens
            TotalSelected.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Count().ToString();

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
            foreach (var data in BattleEngineViewModel.Instance.PartyCharacterList)
            {
                CharacterListFrame.Children.Add(CreatePlayerDisplayBox(new PlayerInfoModel(data)));
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
            DrawSelectedItems();

            // Only need to update the selected, the Dropped is set in the constructor
            TotalSelected.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Count().ToString();
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
                ItemListFoundFrame.Children.Add(GetDroppedItemToDisplay(data));
            }
        }

        /// <summary>
        /// Add the Dropped Items to the Display
        /// </summary>
        public void DrawSelectedItems()
        {
            // Clear and Populate the Dropped Items
            var FlexList = ItemListSelectedFrame.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemListSelectedFrame.Children.Remove(data);
            }

            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList)
            {
                ItemListSelectedFrame.Children.Add(GetSelectedItemToDisplay(data));
            }
        }

        /// <summary>
        /// Look up the Item to Display
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout GetDroppedItemToDisplay(ItemModel item)
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

            //var data = ItemIndexViewModel.Instance.GetItem(item.Id);
            if (item == null)
            {
                // Show the Default Icon for the Location
                item = new ItemModel { Name = "Unknown", ImageURI = "icon_cancel.png" };

                // Turn off click action
                ClickableButton = false;
            }

            // Hookup the Image Button to show the Item picture
            var ItemButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ImageBattleMediumStyle"],
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Source = item.ImageURI
            };

            if (ClickableButton)
            {
                // Add a event to the user can click the item and see more
                ItemButton.Clicked += (sender, args) => SetSelectedItem(item);
            }

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
        /// Look up the Selected Item to Display
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout GetSelectedItemToDisplay(ItemModel item)
        {
            if (item == null)
            {
                return new StackLayout();
            }

            if (string.IsNullOrEmpty(item.Id))
            {
                return new StackLayout();
            }

            // Hookup the Image Button to show the Item picture
            var ItemButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ImageBattleMediumStyle"],
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Source = item.ImageURI
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

            // Defualt Image is the Plus
            var ClickableButton = true;

            if (data == null)
            {
                // Turn off click action
                ClickableButton = false;
            }

            // Hookup the image
            var PlayerImage = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ImageBattleLargeStyle"],
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Source = data.ImageURI
            };

            if (ClickableButton)
            {
                // Add a event to the user can click the item and see more
                PlayerImage.Clicked += (sender, args) => SetSelectedCharacter(data);
            }

            // Add the Level
            var PlayerLevelLabel = new Label
            {
                Text = "Level : " + data.Level,
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
                Text = "HP : " + data.GetCurrentHealthTotal,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            var PlayerItemLabel = new Label();

            if (data.Head != null)
            {
                // Add the current Item
                PlayerItemLabel = new Label
                {
                    Text = "Item : " + data.GetItemByLocation(ItemLocationEnum.Head).Name,
                    Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                    HorizontalOptions = LayoutOptions.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Padding = 0,
                    LineBreakMode = LineBreakMode.TailTruncation,
                    CharacterSpacing = 1,
                    LineHeight = 1,
                    MaxLines = 1,
                };
            }

            if (data.Necklass != null)
            {
                // Add the current Item
                PlayerItemLabel = new Label
                {
                    Text = "Item : " + data.GetItemByLocation(ItemLocationEnum.Necklass).Name,
                    Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                    HorizontalOptions = LayoutOptions.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Padding = 0,
                    LineBreakMode = LineBreakMode.TailTruncation,
                    CharacterSpacing = 1,
                    LineHeight = 1,
                    MaxLines = 1,
                };
            }

            if (data.PrimaryHand != null)
            {
                // Add the current Item
                PlayerItemLabel = new Label
                {
                    Text = "Item : " + data.GetItemByLocation(ItemLocationEnum.PrimaryHand).Name,
                    Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                    HorizontalOptions = LayoutOptions.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Padding = 0,
                    LineBreakMode = LineBreakMode.TailTruncation,
                    CharacterSpacing = 1,
                    LineHeight = 1,
                    MaxLines = 1,
                };
            }

            if (data.OffHand != null)
            {
                // Add the current Item
                PlayerItemLabel = new Label
                {
                    Text = "Item : " + data.GetItemByLocation(ItemLocationEnum.OffHand).Name,
                    Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                    HorizontalOptions = LayoutOptions.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Padding = 0,
                    LineBreakMode = LineBreakMode.TailTruncation,
                    CharacterSpacing = 1,
                    LineHeight = 1,
                    MaxLines = 1,
                };
            }

            if (data.RightFinger != null)
            {
                // Add the current Item
                PlayerItemLabel = new Label
                {
                    Text = "Item : " + data.GetItemByLocation(ItemLocationEnum.RightFinger).Name,
                    Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                    HorizontalOptions = LayoutOptions.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Padding = 0,
                    LineBreakMode = LineBreakMode.TailTruncation,
                    CharacterSpacing = 1,
                    LineHeight = 1,
                    MaxLines = 1,
                };
            }

            if (data.LeftFinger != null)
            {
                // Add the current Item
                PlayerItemLabel = new Label
                {
                    Text = "Item : " + data.GetItemByLocation(ItemLocationEnum.LeftFinger).Name,
                    Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                    HorizontalOptions = LayoutOptions.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Padding = 0,
                    LineBreakMode = LineBreakMode.TailTruncation,
                    CharacterSpacing = 1,
                    LineHeight = 1,
                    MaxLines = 1,
                };
            }

            if (data.Feet != null)
            {
                // Add the current Item
                PlayerItemLabel = new Label
                {
                    Text = "Item : " + data.GetItemByLocation(ItemLocationEnum.Feet).Name,
                    Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                    HorizontalOptions = LayoutOptions.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Padding = 0,
                    LineBreakMode = LineBreakMode.TailTruncation,
                    CharacterSpacing = 1,
                    LineHeight = 1,
                    MaxLines = 1,
                };
            }

            var PlayerNameLabel = new Label()
            {
                Text = data.Name,
                Style = (Style)Application.Current.Resources["ValueStyle"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            // Put the Image Button and Text inside a layout
            var PlayerStack = new StackLayout
            {
                Style = (Style)Application.Current.Resources["PlayerInfoBox"],
                HorizontalOptions = LayoutOptions.Center,
                Padding = 0,
                Spacing = 0,
                Children = {
                    PlayerImage,
                    PlayerNameLabel,
                },
            };

            return PlayerStack;
        }

        /// <summary>
        /// Event when a Character is clicked on
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SetSelectedCharacter(PlayerInfoModel player)
        {
            /*
             * This gets called when the characters is clicked on
             * Usefull if you want to select the character and then set state or do something
             */
            BattleEngineViewModel.Instance.Engine.EngineSettings.EquipForCharacter = player;
            var data = BattleEngineViewModel.Instance.Engine.EngineSettings.AssignedItem;

            PopupLoadingView.IsVisible = true;
            

            var CharacterItem = player.GetItemByLocation(data.Location);
            if (CharacterItem != null)
            {
                ShowPopup(CharacterItem);
            }
            else
            {
                PopupItemImage.Source = "icon_tile.png";

                PopupItemName.Text = "No Item";
                PopupItemLocation.Text = "Unknown";
            }

            PopupNewItemImage.Source = data.ImageURI;

            PopupNewItemName.Text = data.Name;
            PopupNewItemDescription.Text = data.Description;
            PopupNewItemLocation.Text = data.Location.ToMessage();
            PopupNewItemAttribute.Text = data.Attribute.ToMessage();
            PopupNewItemValue.Text = " + " + data.Value.ToString();

            return true;
        }

        /// <summary>
        /// Event when a Item is clicked on
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SetSelectedItem(ItemModel data)
        {
            /*
             * This gets called when the item is clicked on
             */
            BattleEngineViewModel.Instance.Engine.EngineSettings.AssignedItem = data;
            AssignedCharacterList.IsVisible = true;

            return true;
        }

        /// <summary>
        /// Show the Popup for the Item
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ShowPopup(ItemModel data)
        {
            
            PopupItemImage.Source = data.ImageURI;

            PopupItemName.Text = data.Name;
            PopupItemDescription.Text = data.Description;
            PopupItemLocation.Text = data.Location.ToMessage();
            PopupItemAttribute.Text = data.Attribute.ToMessage();
            PopupItemValue.Text = " + " + data.Value.ToString();
            return true;
        }

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void CloseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
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
        /// Close the notice popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CloseNoticePopup_Clicked(object sender, EventArgs e)
        {
            PopupLoadingView.IsVisible = false;
            AssignedCharacterList.IsVisible = false;
        }

        /// <summary>
        /// Assign Item and close the notice popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AssignNoticePopup_Clicked(object sender, EventArgs e)
        {

            // Distribute the Items
            BattleEngineViewModel.Instance.Engine.Round.PickupItemsFromPool(BattleEngineViewModel.Instance.Engine.EngineSettings.EquipForCharacter);

            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Remove(BattleEngineViewModel.Instance.Engine.EngineSettings.AssignedItem);

            // Show what was picked up
            DrawItemLists();
            
            
            BattleEngineViewModel.Instance.Engine.EngineSettings.EquipForCharacter = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.AssignedItem = null;

            PopupLoadingView.IsVisible = false;
            AssignedCharacterList.IsVisible = false;
        }

    }
}