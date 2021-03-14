using System;
using System.Linq;

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
	public partial class NewRoundPage: ContentPage
	{
		// This uses the Instance so it can be shared with other Battle Pages as needed
		public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

		/// <summary>
		/// Constructor
		/// </summary>
		public NewRoundPage ()
		{
			InitializeComponent ();

			// Draw the Characters
			foreach (var data in EngineViewModel.Engine.EngineSettings.CharacterList)
			{
                PartyListFrame.Children.Add(CreatePlayerDisplayBox(data));
			}

			// Draw the Monsters
			foreach (var data in EngineViewModel.Engine.EngineSettings.MonsterList)
			{
				MonsterListFrame.Children.Add(CreatePlayerDisplayBox(data));
			}

		}

		/// <summary>
		/// Start next Round, returning to the battle screen
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void BeginButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
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
                Style = (Style)Application.Current.Resources["ImageBattleMediumStyle"],
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Source = data.ImageURI
            };

            // Hookup the background image
            var CharacterBackgroundImage = new Image
            {
                Style = (Style)Application.Current.Resources["ImageBattleLargeStyle"],
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Source = "character background.png"
            };

            // Hookup the background image
            var MonsterBackgroundImage = new Image
            {
                Style = (Style)Application.Current.Resources["ImageBattleLargeStyle"],
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Source = "monster background.png"
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
            if (data.PlayerType == PlayerTypeEnum.Character)
            {
                ImageGrid.Children.Add(CharacterBackgroundImage);
            } else
            {
                ImageGrid.Children.Add(MonsterBackgroundImage);
            }
            
            ImageGrid.Children.Add(PlayerImage);

            // Add the Level
            var PlayerLevelLabel = new Label
            {
                Text = "Level: "+data.Level,
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
                Text = "Hp:"+ data.GetCurrentHealthTotal,
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
                CharacterSpacing=1,
                LineHeight=1,
                MaxLines =1,
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
                    ImageGrid,
                    AttributeGrid,
                },
            };

            return PlayerStack;
		}
	}
}