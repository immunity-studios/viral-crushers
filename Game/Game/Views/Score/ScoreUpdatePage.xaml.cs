using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

namespace Game.Views
{
    /// <summary>
    /// Score Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScoreUpdatePage : ContentPage
    {
        // Original score model before changes
        // used to restore if the user clicks cancel
        private ScoreModel originalScoreModel;

        // View Model for Score
        public readonly GenericViewModel<ScoreModel> ViewModel;

        // Constructor for Unit Testing
        public ScoreUpdatePage(bool UnitTest) { }

        /// <summary>
        /// Constructor that takes and existing data Score
        /// </summary>
        public ScoreUpdatePage(GenericViewModel<ScoreModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Update " + data.Title;

            // Save a copy of the original score model
            // so we can restore it if the user cancels
            originalScoreModel = new ScoreModel(data.Data);
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // check if the user has entered a valid name before saving
            if (string.IsNullOrEmpty(ViewModel.Data.Name))
            {
                // create popup to tell user they need to add a valid name
                await DisplayAlert("Error", "You must enter a valid name.", "OK");
                return;
            }

            MessagingCenter.Send(this, "Update", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            // Since the user clicked cancel, restore the original data
            ViewModel.Data.Update(originalScoreModel);
            await Navigation.PopModalAsync();
        }
    }
}