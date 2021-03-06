﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.Models;
using Game.ViewModels;

namespace Game.Views
{
    /// <summary>
    /// The Main Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
    public partial class BattlePage : ContentPage
    {
        // HTML Formatting for message output box
        public HtmlWebViewSource htmlSource = new HtmlWebViewSource();

        // Wait time before proceeding
        public int WaitTime = 1500;

        // Hold the Map Objects, for easy access to update them
        public Dictionary<string, object> MapLocationObject = new Dictionary<string, object>();

        public static string lastGameMessage = string.Empty;


        // Empty Constructor for UTs
        bool UnitTestSetting;
        public BattlePage(bool UnitTest) { UnitTestSetting = UnitTest; }

        /// <summary>
        /// Constructor
        /// </summary>
        public BattlePage()
        {
            InitializeComponent();

            // Update audio engine that user has reached the start of the battle
            //AudioSystem.AudioEngine.Instance.ProcessAudioEvent(AudioSystem.AudioEventEnum.BattleStart);

            // Set initial State to Starting
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Starting;

            // Set up the UI to Defaults
            BindingContext = BattleEngineViewModel.Instance;

            // Create and Draw the Map
            InitializeMapGrid();

            // Start the Battle Engine
            BattleEngineViewModel.Instance.Engine.StartBattle(false);

            // Populate the UI Map
            DrawMapGridInitialState();

            // Ask the Game engine to select who goes first
            BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(null);

            // Add Players to Display
            DrawGameAttackerDefenderBoard();

            // Set the Battle Mode
            ShowBattleMode();
        }

        /// <summary>
        /// Dray the Player Boxes
        /// </summary>
        public void DrawPlayerBoxes()
        {
            var CharacterBoxList = CharacterBox.Children.ToList();
            foreach (var data in CharacterBoxList)
            {
                CharacterBox.Children.Remove(data);
            }

            // Draw the Characters
            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Where(m => m.PlayerType == PlayerTypeEnum.Character).ToList())
            {
                CharacterBox.Children.Add(PlayerInfoDisplayBox(data));
            }

            var MonsterBoxList = MonsterBox.Children.ToList();
            foreach (var data in MonsterBoxList)
            {
                MonsterBox.Children.Remove(data);
            }

            // Draw the Monsters
            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Where(m => m.PlayerType == PlayerTypeEnum.Monster).ToList())
            {
                MonsterBox.Children.Add(PlayerInfoDisplayBox(data));
            }

            // Add one black PlayerInfoDisplayBox to hold space in case the list is empty
            CharacterBox.Children.Add(PlayerInfoDisplayBox(null));

            // Add one black PlayerInfoDisplayBox to hold space incase the list is empty
            MonsterBox.Children.Add(PlayerInfoDisplayBox(null));

        }

        /// <summary>
        /// Put the Player into a Display Box
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StackLayout PlayerInfoDisplayBox(PlayerInfoModel data)
        {
            if (data == null)
            {
                data = new PlayerInfoModel
                {
                    ImageURI = ""
                };
            }

            // Hookup the image
            var PlayerImage = new Image
            {
                Style = (Style)Application.Current.Resources["PlayerBattleMediumStyle"],
                Source = data.ImageURI
            };

            // Put the Image Button and Text inside a layout
            var PlayerStack = new StackLayout
            {
                Style = (Style)Application.Current.Resources["PlayerBattleDisplayBox"],
                Children = {
                    PlayerImage,
                },
            };

            return PlayerStack;
        }

        #region BattleMapMode

        /// <summary>
        /// Create the Initial Map Grid
        /// 
        /// All lcoations are empty
        /// </summary>
        /// <returns></returns>
        public bool InitializeMapGrid()
        {
            BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.ClearMapGrid();

            return true;
        }

        /// <summary>
        /// Draw the Map Grid
        /// Add the Players to the Map
        /// 
        /// Need to have Players in the Engine first, to then put on the Map
        /// 
        /// The Map Objects are all created with the map background image first
        /// 
        /// Then the actual characters are added to the map
        /// </summary>
        public void DrawMapGridInitialState()
        {
            // Create the Map in the Game Engine
            BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.PopulateMapModel(BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList);

            CreateMapGridObjects();

            UpdateMapGrid();
        }

        /// <summary>
        /// Walk the current grid
        /// check each cell to see if it matches the engine map
        /// Update only those that need change
        /// </summary>
        /// <returns></returns>
        public bool UpdateMapGrid()
        {
            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.MapGridLocation)
            {
                // Use the ImageButton from the dictionary because that represents the player object
                object MapObject = GetMapGridObject(GetDictionaryImageButtonName(data));
                if (MapObject == null)
                {
                    return false;
                }

                var imageObject = (ImageButton)MapObject;

                // Check automation ID on the Image, That should match the Player, if not a match, the cell is now different need to update
                if (!imageObject.AutomationId.Equals(data.Player.Guid))
                {
                    // The Image is different, so need to re-create the Image Object and add it to the Stack
                    // That way the correct monster is in the box.

                    MapObject = GetMapGridObject(GetDictionaryStackName(data));
                    if (MapObject == null)
                    {
                        return false;
                    }

                    var stackObject = (StackLayout)MapObject;

                    // Remove the ImageButton
                    stackObject.Children.RemoveAt(0);

                    var PlayerImageButton = DetermineMapImageButton(data);

                    stackObject.Children.Add(PlayerImageButton);

                    // Update the Image in the Datastructure
                    MapGridObjectAddImage(PlayerImageButton, data);

                    stackObject.BackgroundColor = DetermineMapBackgroundColor(data);
                }
            }

            return true;
        }

        /// <summary>
        /// Convert the Stack to a name for the dictionary to lookup
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GetDictionaryFrameName(MapModelLocation data)
        {
            return string.Format("MapR{0}C{1}Frame", data.Row, data.Column);
        }

        /// <summary>
        /// Convert the Stack to a name for the dictionary to lookup
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GetDictionaryStackName(MapModelLocation data)
        {
            return string.Format("MapR{0}C{1}Stack", data.Row, data.Column);
        }

        /// <summary>
        /// Covert the player map location to a name for the dictionary to lookup
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GetDictionaryImageButtonName(MapModelLocation data)
        {
            // Look up the Frame in the Dictionary
            return string.Format("MapR{0}C{1}ImageButton", data.Row, data.Column);
        }

        /// <summary>
        /// Populate the Map
        /// 
        /// For each map position in the Engine
        /// Create a grid object to hold the Stack for that grid cell.
        /// </summary>
        /// <returns></returns>
        public bool CreateMapGridObjects()
        {
            // Make a frame for each location on the map
            // Populate it with a new Frame Object that is unique
            // Then updating will be easier

            foreach (var location in BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.MapGridLocation)
            {
                var data = MakeMapGridBox(location);

                // Add the Box to the UI

                MapGrid.Children.Add(data, location.Column, location.Row);
            }

            // Set the Height for the MapGrid based on the number of rows * the height of the BattleMapFrame

            var height = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.MapXAxiesCount * 60;

            BattleMapDisplay.MinimumHeightRequest = height;
            BattleMapDisplay.HeightRequest = height;

            return true;
        }

        /// <summary>
        /// Get the Frame from the Dictionary
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetMapGridObject(string name)
        {
            MapLocationObject.TryGetValue(name, out object data);
            return data;
        }

        /// <summary>
        /// Make the Game Map Frame 
        /// Place the Character or Monster on the frame
        /// If empty, place Empty
        /// </summary>
        /// <param name="mapLocationModel"></param>
        /// <returns></returns>
        public Frame MakeMapGridBox(MapModelLocation mapLocationModel)
        {
            if (mapLocationModel.Player == null)
            {
                mapLocationModel.Player = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.EmptySquare;
            }

            var PlayerImageButton = DetermineMapImageButton(mapLocationModel);

            var PlayerStack = new StackLayout
            {
                Padding = 0,
                Style = (Style)Application.Current.Resources["BattleMapImageBox"],
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = DetermineMapBackgroundColor(mapLocationModel),
                Children = {
                    PlayerImageButton
                },
            };

            MapGridObjectAddImage(PlayerImageButton, mapLocationModel);
            MapGridObjectAddStack(PlayerStack, mapLocationModel);

            var MapFrame = new Frame
            {
                Style = (Style)Application.Current.Resources["BattleMapFrame"],
                Content = PlayerStack,
                AutomationId = GetDictionaryFrameName(mapLocationModel)
            };

            return MapFrame;
        }

        /// <summary>
        /// This add the ImageButton to the stack to kep track of
        /// </summary>
        /// <param name="data"></param>
        /// <param name="MapModel"></param>
        /// <returns></returns>
        public bool MapGridObjectAddImage(ImageButton data, MapModelLocation MapModel)
        {
            var name = GetDictionaryImageButtonName(MapModel);

            // First check to see if it has data, if so update rather than add
            if (MapLocationObject.ContainsKey(name))
            {
                // Update it
                MapLocationObject[name] = data;
                return true;
            }

            MapLocationObject.Add(name, data);

            return true;
        }

        /// <summary>
        /// This adds the Stack into the Dictionary to keep track of
        /// </summary>
        /// <param name="data"></param>
        /// <param name="MapModel"></param>
        /// <returns></returns>
        public bool MapGridObjectAddStack(StackLayout data, MapModelLocation MapModel)
        {
            var name = GetDictionaryStackName(MapModel);

            // First check to see if it has data, if so update rather than add
            if (MapLocationObject.ContainsKey(name))
            {
                // Update it
                MapLocationObject[name] = data;
                return true;
            }

            MapLocationObject.Add(name, data);
            return true;
        }

        /// <summary>
        /// Set the Image onto the map
        /// The Image represents the player
        /// 
        /// So a charcter is the character Image for that character
        /// 
        /// The Automation ID equals the guid for the player
        /// This makes it easier to identify when checking the map to update thigns
        /// 
        /// The button action is set per the type, so Characters events are differnt than monster events
        /// </summary>
        /// <param name="MapLocationModel"></param>
        /// <returns></returns>
        public ImageButton DetermineMapImageButton(MapModelLocation MapLocationModel)
        {
            var data = new ImageButton
            {
                Style = (Style)Application.Current.Resources["BattleMapPlayerSmallStyle"],
                Source = MapLocationModel.Player.ImageURI,

                // Store the guid to identify this button
                AutomationId = MapLocationModel.Player.Guid
            };

            switch (MapLocationModel.Player.PlayerType)
            {
                case PlayerTypeEnum.Character:

                    data.Clicked += (sender, args) =>
                    {
                        SetSelectedCharacter(MapLocationModel);
                    };
                    break;
                case PlayerTypeEnum.Monster:

                    data.Clicked += (sender, args) =>
                    {
                        SetSelectedMonster(MapLocationModel);
                    };
                    break;
                case PlayerTypeEnum.Unknown:
                default:

                    data.Clicked += (sender, args) =>
                    {
                        SetSelectedEmpty(MapLocationModel);
                        //data.Source = "item_background.png";
                    };

                    // Use the blank cell
                    data.Source = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.EmptySquare.ImageURI;

                    
                    break;
            }

            return data;
        }

        /// <summary>
        /// Set the Background color for the tile.
        /// Monsters and Characters have different colors
        /// Empty cells are transparent
        /// </summary>
        /// <param name="MapModel"></param>
        /// <returns></returns>
        public Color DetermineMapBackgroundColor(MapModelLocation MapModel)
        {
            string BattleMapBackgroundColor;
            switch (MapModel.Player.PlayerType)
            {
                case PlayerTypeEnum.Character:
                    BattleMapBackgroundColor = "BattleMapCharacterColor";
                    break;
                case PlayerTypeEnum.Monster:
                    BattleMapBackgroundColor = "BattleMapMonsterColor";
                    break;
                case PlayerTypeEnum.Unknown:
                default:
                    BattleMapBackgroundColor = "BattleMapTransparentColor";
                    break;
            }

            var result = (Color)Application.Current.Resources[BattleMapBackgroundColor];
            return result;
        }

        #region MapEvents
        /// <summary>
        /// Event when an empty location is clicked on
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SetSelectedEmpty(MapModelLocation data)
        {
            /*
             * This gets called when the characters is clicked on empty position in the map
             */
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker != null)
            {
                // Clear defender in battle information box
                DefenderImage.Source = string.Empty;
                DefenderName.Text = string.Empty;
                DefenderHealth.Text = string.Empty;
                DefenderImage.BackgroundColor = Color.Transparent;


                BattlePlayerBoxVersus.Text = string.Empty;

                MoveButton.IsEnabled = true;
                MoveButton.Source = "icon_battle_move_button.png";

                BattleEngineViewModel.Instance.Engine.EngineSettings.SelectedMapLocation = data;
                //data.Player = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.EmptySquareSelected;
            }
            

            return true;
        }

        /// <summary>
        /// Event when a Monster is clicked on
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SetSelectedMonster(MapModelLocation data)
        {
            /*
             * This gets called when the Monster is clicked on as defender
             */
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker != null)
            {
                // turn off Move button
                MoveButton.IsEnabled = false;
                MoveButton.Source = "icon_battle_move_button_gray.png";

                BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = data.Player;

                // Draw defender in the battle infomation box
                DefenderImage.Source = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.ImageURI;
                DefenderName.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.Name;
                DefenderHealth.Text = "HP: " + BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.GetCurrentHealthTotal.ToString();
                BattlePlayerBoxVersus.Text = "vs";

                if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker != null
                    && BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.IsTargetInRange(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker, data.Player))
                {
                    AttackButton.IsEnabled = true;
                    AttackButton.Source = "icon_battle_attack_button.png";
                }

                data.IsSelectedTarget = true;
            }
                
            return true;
        }

        /// <summary>
        /// Event when a Character is clicked on
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SetSelectedCharacter(MapModelLocation data)
        {
            /*
             * This gets called when the characters is clicked on as Attacker
             */
            return true;
        }
        #endregion MapEvents

        #endregion BattleMapMode

        #region BasicBattleMode

        /// <summary>
        /// Draw the UI for
        ///
        /// Attacker vs Defender Mode
        /// 
        /// </summary>
        public void DrawGameAttackerDefenderBoard()
        {
            // Clear the current UI
            DrawGameBoardClear();

            // Show Characters across the Top
            DrawPlayerBoxes();

            // Draw the Map
            UpdateMapGrid();

            // Show the Attacker and Defender
            DrawGameBoardAttackerDefenderSection();
        }

        /// <summary>
        /// Draws the Game Board Attacker and Defender
        /// </summary>
        public async void DrawGameBoardAttackerDefenderSection()
        {
            BattlePlayerBoxVersus.Text = "";

            if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker == null)
            {
                return;
            }           

            AttackerImage.Source = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.ImageURI;
            AttackerName.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.Name;
            AttackerHealth.Text = "HP: " + BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.GetCurrentHealthTotal.ToString();

            // Show what action the Attacker used
            //AttackerAttack.Source = BattleEngineViewModel.Instance.Engine.EngineSettings.PreviousAction.ToImageURI();
            
            //var item = ItemIndexViewModel.Instance.GetItem(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.PrimaryHand);
            //if (item != null)
            //{
            //    AttackerAttack.Source = item.ImageURI;
            //}

            if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender != null)
            {
                DefenderImage.Source = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.ImageURI;
                DefenderName.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.Name;
                DefenderHealth.Text = "HP: " + BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.GetCurrentHealthTotal.ToString();

                if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.Alive == false)
                {
                    UpdateMapGrid();
                    DefenderImage.BackgroundColor = Color.Red;
                }
            }
            

            // Attack Animation
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.PreviousAction == ActionEnum.Attack)
            {
                AttackerImage.RotateTo(20, 150);
                await AttackerImage.TranslateTo(20, 0, 150);
                AttackerImage.RelRotateTo(-20, 150);
                await AttackerImage.TranslateTo(0, 0, 150);
                await DefenderImage.ScaleTo(0.5, 150);
                await DefenderImage.ScaleTo(2, 150);
                await DefenderImage.ScaleTo(1, 150);
            }

            // Move Animation
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.PreviousAction == ActionEnum.Move)
            {
                await AttackerImage.TranslateTo(20, 0, 150);
                await AttackerImage.TranslateTo(-20, 0, 150);
                await AttackerImage.TranslateTo(20, 0, 150);               
                await AttackerImage.TranslateTo(-20, 0, 150);
                await AttackerImage.TranslateTo(0, 0, 150);
            }

            // Ability Animation
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.PreviousAction == ActionEnum.Ability)
            {

                AttackerImage.ScaleTo(2, 500);
                await AttackerImage.TranslateTo(0,20, 500);
                AttackerImage.ScaleTo(1, 200);
                await AttackerImage.TranslateTo(0, 0, 200);
            }

            // Rest Animation
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.PreviousAction == ActionEnum.Rest)
            {
                await AttackerImage.RotateTo(360, 500);
                await AttackerImage.RotateTo(360, 500);
            }

            

            BattlePlayerBoxVersus.Text = "vs";
        }

        /// <summary>
        /// Draws the Game Board Attacker and Defender areas to be null
        /// </summary>
        public void DrawGameBoardClear()
        {
            AttackerImage.Source = string.Empty;
            AttackerName.Text = string.Empty;
            AttackerHealth.Text = string.Empty;

            DefenderImage.Source = string.Empty;
            DefenderName.Text = string.Empty;
            DefenderHealth.Text = string.Empty;
            DefenderImage.BackgroundColor = Color.Transparent;

            BattlePlayerBoxVersus.Text = string.Empty;
        }

        /// <summary>
        /// Allows Character to take a break and skip a turn while regaining health points.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RestButton_Clicked(object sender, EventArgs e)
        {
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAction = ActionEnum.Rest;
            NextAttackExample();
        }


        /// <summary>
        /// Attack Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AttackButton_Clicked(object sender, EventArgs e)
        {
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAction = ActionEnum.Attack;
            NextAttackExample();
        }

        /// <summary>
        /// Ability Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AbilityButton_Clicked(object sender, EventArgs e)
        {
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAction = ActionEnum.Ability;
            NextAttackExample();
        }

        /// <summary>
        /// Move Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MoveButton_Clicked(object sender, EventArgs e)
        {
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAction = ActionEnum.Move;

            NextAttackExample();
        }

        /// <summary>
        /// Settings Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Settings_Clicked(object sender, EventArgs e)
        {
            await ShowBattleSettingsPage();
        }

        /// <summary>
        /// Next Attack Example
        /// 
        /// This code example follows the rule of
        /// 
        /// To Attack Select one Monster as Targer then click Attack
        /// To Move Select an empty space then click move
        /// To use ability click ability
        /// To Rest click Rest
        /// 
        /// </summary>
        public async void NextAttackExample()
        {
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Battling;

            // Hold the current state
            var RoundCondition = BattleEngineViewModel.Instance.Engine.Round.RoundNextTurn();

            // Output the Message of what happened.
            GameMessage();

            DrawGameAttackerDefenderBoard();    

            if ((RoundCondition == RoundEnum.NewRound) || (BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Count < 1))
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.NewRound;
                BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(null);
                BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(null);
                
                DrawMapGridInitialState();
                ShowBattleMode();

                // Pause
                Task.Delay(WaitTime);

                Debug.WriteLine("New Round");

                // Show the Round Over, after that is cleared, it will show the New Round Dialog
                ShowModalRoundOverPage();
                return;
            }

            // Check for Game Over
            if ((RoundCondition == RoundEnum.GameOver) || (BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Count < 1))
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.GameOver;
                BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(null);
                BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(null);

                DrawMapGridInitialState();
                ShowBattleMode();

                // Wrap up
                BattleEngineViewModel.Instance.Engine.EndBattle();

                // Pause
                Task.Delay(WaitTime);

                Debug.WriteLine("Game Over");

                GameOver();
                return;
            }
            // Pause
            await Task.Delay(1000);

            // Move to next turn
            GetNextPlayer();
        }

        /// <summary>
        /// Close the User's Turn popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CloseUserPopup_Clicked(object sender, EventArgs e)
        {
            PopupUserLoadingView.IsVisible = false;
            BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(null);
            BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(null);
            DrawGameBoardClear();
        }

        /// <summary>
        /// Show the Popup for the Monster's Turn
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ShowMonsterPopup()
        {
            PopupMonsterLoadingView.IsVisible = true;

            AttackButton.IsEnabled = false;
            AbilityButton.IsEnabled = false;
            MoveButton.IsEnabled = false;

            RestButton.IsEnabled = false;

            AttackButton.Source = "icon_battle_attack_button_gray.png";
            MoveButton.Source = "icon_battle_move_button_gray.png";
            AbilityButton.Source = "icon_battle_ability_button_gray.png";
            RestButton.Source = "icon_battle_rest_button_gray.png";


            return true;
        }

        /// <summary>
        /// Close the Monster's Turn popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void CloseMonsterPopup_Clicked(object sender, EventArgs e)
        {
            PopupMonsterLoadingView.IsVisible = false;
            NextMonsterAttack();

            await Task.Delay(1000);

            if (BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Count() > 0)
            {
                PopupUserLoadingView.IsVisible = true;
            }
        }

        public void GetNextPlayer()
        {
            var attacker = BattleEngineViewModel.Instance.Engine.Round.GetNextPlayerTurn();
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = attacker;

            // Turn off Action Buttons
            UnenableActionButtons();

            if (attacker.PlayerType == PlayerTypeEnum.Character)
            {
                // Set up the turn
                BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(null);
                DrawGameBoardClear();

                // Draw Attacker in the battle infomation box
                AttackerImage.Source = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.ImageURI;
                AttackerName.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.Name;
                AttackerHealth.Text = "HP: " + BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.GetCurrentHealthTotal.ToString();

                // Enable Rest Button
                RestButton.IsEnabled = true;
                RestButton.Source = "icon_battle_rest_button.png";


                // If haven't chosen Defender and the Target isn't in the attack range of Attacker 
                // then the Attack Button is not enabled to click
                if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender != null
                    && BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.IsTargetInRange(attacker, BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender))
                {
                    AttackButton.IsEnabled = true;
                    AttackButton.Source = "icon_battle_attack_button.png";
                }

                // If ability of character is still available then the Ability Button is enabled to click
                foreach (var ability in attacker.AbilityTracker)
                {
                    var temp = ability.Key;

                    var result = attacker.AbilityTracker.TryGetValue(temp, out int remaining);
                    if (remaining > 0)
                    {
                        AbilityButton.IsEnabled = true;
                        AbilityButton.Source = "icon_battle_ability_button.png";

                        break;
                    }
                }

                // Show intruction for user
                //BattleMessages.Text = string.Format("{0} \n{1}", "Choose to do 1 of these actions: Attack, Move, Rest or Ability.", BattleMessages.Text);
                //BattleMessages.Text = string.Format("{0} \n{1}", "IT IS YOUR TURN!", BattleMessages.Text);


                BattleMessages.Text = string.Format("{0} \n{1}", "It's " + attacker.Name + "'s turn!", BattleMessages.Text);

                Debug.WriteLine(BattleMessages.Text);
            }
            else
            {
                NextMonsterAttack();

                //// Show Monster turn Message
                //BattleMessages.Text = string.Format("{0}: {1}", attacker.Name + "'s turn", BattleMessages.Text);

                Debug.WriteLine(BattleMessages.Text);
            }
        }

        public async void NextMonsterAttack()
        {
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Battling;

            // Get the turn, set the current player and attacker to match
            SetAttackerAndDefender();


            // Hold the current state
            var RoundCondition = BattleEngineViewModel.Instance.Engine.Round.RoundNextTurn();

            // Output the Message of what happened.
            GameMessage();

            // Show the outcome on the Board
            DrawGameAttackerDefenderBoard();

            if ((RoundCondition == RoundEnum.NewRound) || (BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Count < 1))
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.NewRound;
                BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(null);
                BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(null);
                DrawMapGridInitialState();
                ShowBattleMode();

                // Pause
                Task.Delay(WaitTime);

                Debug.WriteLine("New Round");

                // Show the Round Over, after that is cleared, it will show the New Round Dialog
                ShowModalRoundOverPage();
                return;
            }

            // Check for Game Over
            if ((RoundCondition == RoundEnum.GameOver) || (BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Count < 1))
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.GameOver;
                BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(null);
                BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(null);

                
                DrawMapGridInitialState();
                ShowBattleMode();

                // Wrap up
                BattleEngineViewModel.Instance.Engine.EndBattle();

                // Pause
                Task.Delay(WaitTime);

                Debug.WriteLine("Game Over");

                GameOver();
                return;
            }

            await Task.Delay(1000);
            GetNextPlayer();
        }

        /// <summary>
        /// Decide The Turn and who to Attack
        /// </summary>
        public void SetAttackerAndDefender()
        {
            //BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(BattleEngineViewModel.Instance.Engine.Round.GetNextPlayerTurn());

            switch (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.PlayerType)
            {
                case PlayerTypeEnum.Character:
                    // User would select who to attack

                    // for now just auto selecting
                    BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(BattleEngineViewModel.Instance.Engine.Round.Turn.AttackChoice(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker));
                    break;

                case PlayerTypeEnum.Monster:
                default:

                    // Monsters turn, so auto pick a Character to Attack
                    BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(BattleEngineViewModel.Instance.Engine.Round.Turn.AttackChoice(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker));
                    break;
            }
        }

        /// <summary>
        /// Game is over
        /// 
        /// Show Buttons
        /// 
        /// Clean up the Engine
        /// 
        /// Show the Score
        /// 
        /// Clear the Board
        /// 
        /// </summary>
        public void GameOver()
        {
            // Save the Score to the Score View Model, by sending a message to it.
            var Score = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore;
            MessagingCenter.Send(this, "AddData", Score);

            ShowBattleMode();
        }
        #endregion BasicBattleMode

        #region MessageHandelers

        /// <summary>
        /// Builds up the output message
        /// </summary>
        /// <param name="message"></param>
        public void GameMessage()
        {
            string toBeDisplayed = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.TurnMessage;

            if (!toBeDisplayed.Equals(lastGameMessage))
            {
                // Output The Message that happened.
                BattleMessages.Text = string.Format("{0} \n{1}", toBeDisplayed, BattleMessages.Text);

                Debug.WriteLine(BattleMessages.Text);
            }

            lastGameMessage = toBeDisplayed;

            // Output the Hit Sound Effect Message
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.HitSoundEffectMessage != string.Empty)
            {
                BattleMessages.Text = string.Format("{0} \n{1}", BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.HitSoundEffectMessage, BattleMessages.Text);

                Debug.WriteLine(BattleMessages.Text);
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.HitSoundEffectMessage = string.Empty;
            }

            // Output the Miss Sound Effect Message
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.MissSoundEffectMessage != string.Empty)
            {
                BattleMessages.Text = string.Format("{0} \n{1}", BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.MissSoundEffectMessage, BattleMessages.Text);

                Debug.WriteLine(BattleMessages.Text);
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.MissSoundEffectMessage = string.Empty;
            }

            // Ouput the Death Sound Effect Message
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.DeathSoundEffectMessage != string.Empty)
            {
                BattleMessages.Text = string.Format("{0} \n{1}", BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.DeathSoundEffectMessage, BattleMessages.Text);

                Debug.WriteLine(BattleMessages.Text);
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.DeathSoundEffectMessage = string.Empty;
            }


            if (!string.IsNullOrEmpty(BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.LevelUpMessage))
            {
                BattleMessages.Text = string.Format("{0} \n{1}", BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.LevelUpMessage, BattleMessages.Text);
            }


            //htmlSource.Html = BattleEngineViewModel.Instance.Engine.BattleMessagesModel.GetHTMLFormattedTurnMessage();
            //HtmlBox.Source = HtmlBox.Source = htmlSource;
        }

        /// <summary>
        ///  Clears the messages on the UX
        /// </summary>
        public void ClearMessages()
        {
            BattleMessages.Text = "Click START to begin!\n\n\n\n\n\n";
            htmlSource.Html = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.GetHTMLBlankMessage();
            //HtmlBox.Source = htmlSource;
        }

        #endregion MessageHandelers

        #region PageHandelers


        

        /// <summary>
        /// Battle Over, so Exit Button
        /// Need to show this for the user to click on.
        /// The Quit does a prompt, exit just exits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ExitButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// The Next Round Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void NextRoundButton_Clicked(object sender, EventArgs e)
        {
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Battling;
            await Navigation.PushModalAsync(new NewRoundPage());

            ShowBattleMode();
            DrawGameAttackerDefenderBoard();
            AttackButton.IsEnabled = false;
            AbilityButton.IsEnabled = false;
            MoveButton.IsEnabled = false;
            RestButton.IsEnabled = false;
            StartButton.IsEnabled = true;

            AttackButton.Source = "icon_battle_attack_button_gray.png";
            MoveButton.Source = "icon_battle_move_button_gray.png";
            AbilityButton.Source = "icon_battle_ability_button_gray.png";
            RestButton.Source = "icon_battle_rest_button_gray.png";
            StartButton.Source = "icon_battle_start_button.png";
        }

        /// <summary>
        /// The Start Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void StartButton_Clicked(object sender, EventArgs e)
        {
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Battling;

            ShowBattleMode();
            await Navigation.PushModalAsync(new NewRoundPage());


            StartButton.IsEnabled = true;

            
            Debug.WriteLine(BattleMessages.Text);
        }

        /// <summary>
        /// The Start Game Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Start_Clicked(object sender, EventArgs e)
        {
            var attacker = BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.FirstOrDefault();
            BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(attacker);

            if (attacker.PlayerType == PlayerTypeEnum.Character)
            {
                DrawGameBoardClear();

                // Show intruction for user
                //BattleMessages.Text = string.Format("{0} \n{1}", "Choose to do 1 of these actions: Attack, Move, Rest or Ability.", BattleMessages.Text);
                //BattleMessages.Text = string.Format("{0} \n{1}", "IT IS YOUR TURN!", BattleMessages.Text);

                BattleMessages.Text = string.Format("{0} \n{1}", "Now is " + attacker.Name  + "'s turn!", BattleMessages.Text);

                Debug.WriteLine(BattleMessages.Text);
            } else
            {
                NextMonsterAttack();

                //// Show Monster turn Message
                //BattleMessages.Text = string.Format("{0}: {1}", attacker.Name + "'s turn", BattleMessages.Text);

                Debug.WriteLine(BattleMessages.Text);
            }
            StartButton.IsEnabled = false;
            StartButton.Source = "start_button_gray.png";
        }

        /// <summary>
        /// Show the Game Over Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public async void ShowScoreButton_Clicked(object sender, EventArgs args)
        {
            ShowBattleMode();
            await Navigation.PushModalAsync(new GameOverPage());
        }

        /// <summary>
        /// Show the Round Over page
        /// 
        /// Round Over is where characters get items
        /// 
        /// </summary>
        public async void ShowModalRoundOverPage()
        {
            
            await Navigation.PushModalAsync(new RoundOverPage());
            ShowBattleMode();
        }

        /// <summary>
        /// Show Settings
        /// </summary>
        public async Task ShowBattleSettingsPage()
        {
            ShowBattleMode();
            await Navigation.PushModalAsync(new BattleSettingsPage());
        }
        #endregion PageHandelers

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ShowBattleMode();
        }

        /// <summary>
        /// 
        /// Hide the differnt button states
        /// 
        /// Hide the message display box
        /// 
        /// </summary>
        public void HideUIElements()
        {
            NextRoundButton.IsVisible = false;
            StartBattleButton.IsVisible = false;
            AttackButton.IsVisible = false;
            AbilityButton.IsVisible = false;
            StartButton.IsVisible = false;
            MoveButton.IsVisible = false;
            MessageDisplayBox.IsVisible = false;
            BattlePlayerInfomationBox.IsVisible = false;

            RestButton.IsVisible = false;
        }

        // Turn off Action buttons
        public void UnenableActionButtons()
        {
            AttackButton.IsEnabled = false;
            AbilityButton.IsEnabled = false;
            MoveButton.IsEnabled = false;

            RestButton.IsEnabled = false;

            AttackButton.Source = "icon_battle_attack_button_gray.png";
            MoveButton.Source = "icon_battle_move_button_gray.png";
            AbilityButton.Source = "icon_battle_ability_button_gray.png";
            RestButton.Source = "icon_battle_rest_button_gray.png";
        }

        /// <summary>
        /// Show the proper Battle Mode
        /// </summary>
        public void ShowBattleMode()
        {
            // If running in UT mode, 
            if (UnitTestSetting)
            {
                return;
            }

            HideUIElements();

            ClearMessages();

            DrawPlayerBoxes();

            // Update the Mode
            //BattleModeValue.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum.ToMessage();

            ShowBattleModeDisplay();

            ShowBattleModeUIElements();
        }

        /// <summary>
        /// Control the UI Elements to display
        /// </summary>
        public void ShowBattleModeUIElements()
        {
            switch (BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum)
            {
                case BattleStateEnum.Starting:
                    //GameUIDisplay.IsVisible = false;
                    //AttackerAttack.Source = ActionEnum.Unknown.ToImageURI();
                    StartBattleButton.IsVisible = true;
                    break;

                case BattleStateEnum.NewRound:
                    UpdateMapGrid();
                    //AttackerAttack.Source = ActionEnum.Unknown.ToImageURI();
                    NextRoundButton.IsVisible = true;
                    break;

                case BattleStateEnum.GameOver:
                    // Hide the Game Board
                    GameUIDisplay.IsVisible = false;
                    //AttackerAttack.Source = ActionEnum.Unknown.ToImageURI();

                    // Show the Game Over Display
                    GameOverDisplay.IsVisible = true;
                    break;

                case BattleStateEnum.RoundOver:
                case BattleStateEnum.Battling:
                    GameUIDisplay.IsVisible = true;
                    BattlePlayerInfomationBox.IsVisible = true;
                    MessageDisplayBox.IsVisible = true;
                    AttackButton.IsVisible = true;
                    AbilityButton.IsVisible = true;
                    MoveButton.IsVisible = true;
                    StartButton.IsVisible = true;

                    RestButton.IsVisible = true;

                    break;

                // Based on the State disable buttons
                case BattleStateEnum.Unknown:
                default:
                    break;
            }
        }

        /// <summary>
        /// Control the Map Mode or Simple
        /// </summary>
        public void ShowBattleModeDisplay()
        {
            switch (BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum)
            {
                case BattleModeEnum.MapAbility:
                case BattleModeEnum.MapFull:
                case BattleModeEnum.MapNext:
                    GamePlayersTopDisplay.IsVisible = false;
                    BattleMapDisplay.IsVisible = true;
                    break;

                case BattleModeEnum.SimpleAbility:
                case BattleModeEnum.SimpleNext:
                case BattleModeEnum.Unknown:
                default:
                    GamePlayersTopDisplay.IsVisible = true;
                    BattleMapDisplay.IsVisible = false;
                    break;
            }
        }
    }
}