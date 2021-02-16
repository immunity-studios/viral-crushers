using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

namespace Game.Views
{
    /// <summary>
    /// Item Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterUpdatePage : ContentPage
    {
        // Original character model before changes
        // used to restore if the user clicks cancel
        private CharacterModel originalCharacterModel;

        // View Model for Item
        public readonly GenericViewModel<CharacterModel> ViewModel;

        // Empty Constructor for Tests
        public CharacterUpdatePage(bool UnitTest){ }

        /// <summary>
        /// Constructor that takes and existing data item
        /// </summary>
        public CharacterUpdatePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Character Update " + data.Title;

            // Save a copy of the original character model
            // so we can restore it if the user cancels
            originalCharacterModel = new CharacterModel(data.Data);

            // Match Character Image with Character Type
            JobPicker.SelectedItem = data.Data.Job.ToString();
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

            // Match Character Image with Character Type
            ViewModel.Data.ImageURI = ViewModel.Data.Job.ToImageFile();

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
            ViewModel.Data.Update(originalCharacterModel);
            await Navigation.PopModalAsync();
        }


        private void OnJobPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;

            // Convert selected Character Type string to CharacterJobEnum
            var selectedJob = CharacterJobEnumHelper.ConvertMappedStringToEnum((string)picker.SelectedItem);

            // Match Character Image with Character Type
            CharacterImage.Source = selectedJob.ToImageFile();
        }

    }
}