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
    public partial class MonsterUpdatePage : ContentPage
    {
        // Original monster model before changes
        // used to restore if the user clicks cancel
        private MonsterModel originalMonsterModel;

        // View Model for Item
        public readonly GenericViewModel<MonsterModel> ViewModel;

        // Empty Constructor for Tests
        public MonsterUpdatePage(bool UnitTest){ }

        /// <summary>
        /// Constructor that takes and existing data item
        /// </summary>
        public MonsterUpdatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Update " + data.Title;

            // Save a copy of the original monster model
            // so we can restore it if the user cancels
            originalMonsterModel = new MonsterModel(data.Data);

            MonsterTypePicker.SelectedItem = data.Data.Type.ToString();
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

            // Match Monster Image with Monster Type
            ViewModel.Data.ImageURI = ViewModel.Data.Type.ToImageFile();

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
            ViewModel.Data.Update(originalMonsterModel);
            await Navigation.PopModalAsync();
        }


        private void OnMonsterTypePickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;

            // Convert selected Monster Type string to MonsterTypeEnum
            var selectedMonsterType = MonsterTypeEnumHelper.ConvertMappedStringToEnum((string)picker.SelectedItem);

            // Match Monster Image with Monster Type
            MonsterImage.Source = selectedMonsterType.ToImageFile();
        }
    }
}