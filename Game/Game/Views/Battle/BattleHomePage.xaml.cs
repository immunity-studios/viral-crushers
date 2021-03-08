using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// This page is temporarily holding links to all battle pages for debugging/UI development
	/// TODO delete this page and remove "dungeon" button from game page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BattleHomePage : ContentPage
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public BattleHomePage ()
		{
			InitializeComponent ();
		}

		/// <summary>
		/// Jump to the auto battle
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void BattlePage_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new BattlePage());
		}

		
		public async void AutoBattlePage_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AutoBattlePage());
		}

		/// <summary>
		/// Jump to the Dungeon/Hospital
		/// </summary>
		public async void PickCharactersPage_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PickCharactersPage());
		}

		/// <summary>
		/// Jump to the Show Monsters page
		/// </summary>
		public async void ShowMonstersPage_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ShowMonstersPage());
		}

		/// <summary>
		/// Jump to the Pick Items page 
		/// </summary>
		public async void PickItemsPage_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PickItemsPage());
		}

		/// <summary>
		/// Jump to the Round over page
		/// </summary>
		public async void RoundOverPage_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new RoundOverPage());
		}

		/// <summary>
		/// Jump to the New Round page
		/// </summary>
		public async void NewRoundPage_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewRoundPage());
		}

		/// <summary>
		/// Jump to the game over page
		/// </summary>
		public async void GameOverPage_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new GameOverPage());
		}
	}
}