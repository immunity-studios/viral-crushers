using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Game.Views
{
    public partial class ToolbarMenuControl : ContentView
    {
        public ToolbarMenuControl()
        {
            InitializeComponent();
        }

		#region Toolbar Click Handlers

		/// <summary>
		/// Jump to the Dungeon/Hospital
		/// </summary>
		public async void DungeonButton_Clicked(object sender, EventArgs e)
		{
			var previousPage = Navigation.NavigationStack.LastOrDefault();
			await Navigation.PushAsync(new GamePage());
			if (!(previousPage is GamePage))
			{
				Navigation.RemovePage(previousPage);
			}
		}

		/// <summary>
		/// Jump to the characters index page
		/// </summary>
		public async void CharacterButton_Clicked(object sender, EventArgs e)
		{
			var previousPage = Navigation.NavigationStack.LastOrDefault();
			await Navigation.PushAsync(new CharacterIndexPage());
			if (!(previousPage is GamePage))
			{
				Navigation.RemovePage(previousPage);
			}
		}

		/// <summary>
		/// Jump to the monsters index page
		/// </summary>
		public async void MonsterButton_Clicked(object sender, EventArgs e)
		{
			var previousPage = Navigation.NavigationStack.LastOrDefault();
			await Navigation.PushAsync(new MonsterIndexPage());
			if (!(previousPage is GamePage))
			{
				Navigation.RemovePage(previousPage);
			}
		}

		/// <summary>
		/// Jump to the items index page
		/// </summary>
		public async void ItemButton_Clicked(object sender, EventArgs e)
		{
			var previousPage = Navigation.NavigationStack.LastOrDefault();
			await Navigation.PushAsync(new ItemIndexPage());
			if (!(previousPage is GamePage))
			{
				Navigation.RemovePage(previousPage);
			}
		}

		/// <summary>
		/// Jump to the scores index page
		/// </summary>
		public async void ScoreButton_Clicked(object sender, EventArgs e)
		{
			var previousPage = Navigation.NavigationStack.LastOrDefault();
			await Navigation.PushAsync(new ScoreIndexPage());
			if (!(previousPage is GamePage))
			{
				Navigation.RemovePage(previousPage);
			}
		}
		#endregion
	}
}
