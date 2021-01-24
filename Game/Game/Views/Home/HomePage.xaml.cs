using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public HomePage()
		{
			InitializeComponent();
			AudioEngine.AudioResources.MX_MENU_SONG1_FULL_LOOP.Play(); // Start menu music loop
		}

		/// <summary>
		/// Example of a Button Click (this one is Sync, if calling Async then needs to be Async)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void GameButton_Clicked(object sender, EventArgs e)
        {
			//AudioEngine.AudioResources.MENU_CLICK_SOUND.Play(); // Play test click sound
			await Navigation.PushAsync(new GamePage());
		}
    }
}