using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
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

		public async void ShowMonstersPage_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ShowMonstersPage());
		}

		public async void PickItemsPage_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PickItemsPage());
		}

		public async void RoundOverPage_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new RoundOverPage());
		}

		public async void NewRoundPage_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewRoundPage());
		}

		public async void ScorePage_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new GameOverPage());
		}
	}
}