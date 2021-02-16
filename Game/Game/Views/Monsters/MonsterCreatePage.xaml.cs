using Game.Models;
using Game.ViewModels;

using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// Create Item
    /// </summary>
    [DesignTimeVisible(false)] 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterCreatePage : ContentPage
    {
        // The item to create
        public GenericViewModel<MonsterModel> ViewModel = new GenericViewModel<MonsterModel>();

        // Empty Constructor for UTs
        public MonsterCreatePage(bool UnitTest){}

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public MonsterCreatePage()
        {
            InitializeComponent();

            this.ViewModel.Data = new MonsterModel();

            BindingContext = this.ViewModel;

            this.ViewModel.Title = "Monster Create";

            MonsterTypePicker.SelectedItem = ViewModel.Data.Type.ConvertEnumToMappedString();

            MonsterImage.Source = ViewModel.Data.Type.ToImageFile();
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

            ViewModel.Data.ImageURI = ViewModel.Data.Type.ToImageFile();

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


        private void OnMonsterTypePickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;

            var selectedMonsterType = MonsterTypeEnumHelper.ConvertMappedStringToEnum((string)picker.SelectedItem);

            MonsterImage.Source = selectedMonsterType.ToImageFile();
        }

    }
}