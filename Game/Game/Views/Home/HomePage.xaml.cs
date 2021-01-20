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
			// Start menu music loop
			AudioEngine.AudioResources.MENU_MUSIC1_LOOP_LAYER1.Play();
			AudioEngine.AudioResources.MENU_MUSIC1_LOOP_LAYER2.Play();
			AudioEngine.AudioResources.MENU_MUSIC1_LOOP_LAYER3.Play();
		}

		/// <summary>
		/// Example of a Button Click (this one is Sync, if calling Async then needs to be Async)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void GameButton_Clicked(object sender, EventArgs e)
        {
			AudioEngine.AudioResources.MENU_CLICK_SOUND.Play(); // Play test sound
			await Navigation.PushAsync(new GamePage());
		}
    }
}