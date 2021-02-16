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
    public partial class ItemUpdatePage : ContentPage
    {
        // Original item model before changes
        // used to restore if the user clicks cancel
        private ItemModel originalItemModel;

        // View Model for Item
        public readonly GenericViewModel<ItemModel> ViewModel;

        // Empty Constructor for Tests
        public ItemUpdatePage(bool UnitTest){ }

        /// <summary>
        /// Constructor that takes and existing data item
        /// </summary>
        public ItemUpdatePage(GenericViewModel<ItemModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Update " + data.Title;

            // Save a copy of the original item model
            // so we can restore it if the user cancels
            originalItemModel = new ItemModel(data.Data);

            //Need to make the SelectedItem a string, so it can select the correct item.
            LocationPicker.SelectedItem = ItemLocationEnumHelper.ConvertEnumToMappedString(data.Data.Location);
            AttributePicker.SelectedItem = data.Data.Attribute.ToString();
            ItemTypePicker.SelectedItem = ItemTypeEnumHelper.ConvertEnumToMappedString(data.Data.ItemType);

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
            ViewModel.Data.ImageURI = ViewModel.Data.ItemType.ToImageFile();

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
            ViewModel.Data.Update(originalItemModel);
            await Navigation.PopModalAsync();
        }

        private void OnItemTypePickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItemType = ItemTypeEnumHelper.ConvertMappedStringToEnum((string)picker.SelectedItem);
            ItemImage.Source = selectedItemType.ToImageFile();
        }
    }
}