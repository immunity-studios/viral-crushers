using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GamePage : ContentPage
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public GamePage ()
		{
			InitializeComponent ();
		}

		/// <summary>
		/// Jump to the Dungeon
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public async void DungeonButton_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new PickCharactersPage());
		}

		/// <summary>
		/// Jump to the Dungeon
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void AutobattleButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AutoBattlePage());
		}

		#region Toolbar Click Handlers
		/// <summary>
		/// Jump to the characters index page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void CharacterButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CharacterIndexPage());
		}

		/// <summary>
		/// Jump to the monsters index page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void MonsterButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MonsterIndexPage());
		}

		/// <summary>
		/// Jump to the items index page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void ItemButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ItemIndexPage());
		}

		/// <summary>
		/// Jump to the scores index page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void ScoreButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ScoreIndexPage());
		}
		#endregion
	}
}