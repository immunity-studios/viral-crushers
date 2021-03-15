using Game.Models;
using Game.ViewModels;

using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// Create Character
    /// </summary>
    [DesignTimeVisible(false)] 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterCreatePage : ContentPage
    {
        // The character to create
        public GenericViewModel<CharacterModel> ViewModel = new GenericViewModel<CharacterModel>();

        // Empty Constructor for UTs
        public CharacterCreatePage(bool UnitTest){}

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public CharacterCreatePage()
        {
            InitializeComponent();

            this.ViewModel.Data = new CharacterModel();

            BindingContext = this.ViewModel;

            this.ViewModel.Title = "Character Create";
            JobPicker.SelectedItem = ViewModel.Data.Job.ConvertEnumToMappedString();

            // Match Character Image with Character Type
            CharacterImage.Source = ViewModel.Data.Job.ToGifFile();
        }

        /// <summary>
        /// Save by calling for Create
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
            ViewModel.Data.ImageURI = ViewModel.Data.Job.ToGifFile();

            MessagingCenter.Send(this, "Create", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel the Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void OnJobPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            //var selectedJob = ((string)picker.SelectedItem).ConvertMappedStringToEnum();

            // Convert selected Character Type string to CharacterJobEnum
            var selectedJob = CharacterJobEnumHelper.ConvertMappedStringToEnum((string)picker.SelectedItem);

            // Match Character Image with Character Type
            CharacterImage.Source = selectedJob.ToGifFile();
        }
    }
}