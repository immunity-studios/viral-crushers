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
			// Update audio engine that user has reached Game Page
			AudioSystem.AudioEngine.Instance.ProcessAudioEvent(AudioSystem.AudioEventEnum.GamePageReached);
		}

		/// <summary>
		/// Jump to the auto battle
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void AutobattleButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AutoBattlePage());
		}

		
		public async void AboutButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AboutPage());
		}

		/// <summary>
		/// Jump to the Dungeon/Hospital
		/// </summary>
		public async void DungeonButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PickCharactersPage());
		}
	}
}