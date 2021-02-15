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

            //Need to make the SelectedItem a string, so it can select the correct item.
            LocationPicker.SelectedItem = ItemLocationEnumHelper.ConvertEnumToMappedString(data.Data.Location);
            AttributePicker.SelectedItem = data.Data.Attribute.ToString();
            ItemTypePicker.SelectedItem = data.Data.ItemType.ToString();

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

            switch (ViewModel.Data.ItemType)
            {
                case ItemTypeEnum.HandSoap:
                    ViewModel.Data.ImageURI = "icon_hand_soap.png";
                    break;

                case ItemTypeEnum.BoxOfTissues:
                    ViewModel.Data.ImageURI = "icon_tissue_box.png";
                    break;

                case ItemTypeEnum.Mask:
                    ViewModel.Data.ImageURI = "icon_mask.png";
                    break;

                case ItemTypeEnum.Sanitizer:
                    ViewModel.Data.ImageURI = "icon_sanitizer.png";
                    break;

                case ItemTypeEnum.FaceShield:
                    ItemImage.Source = "icon_face_shield.png";
                    break;

                case ItemTypeEnum.Soup:
                    ViewModel.Data.ImageURI = "icon_soup.png";
                    break;

                case ItemTypeEnum.BugSpray:
                    ViewModel.Data.ImageURI = "icon_bug_spray.png";
                    break;

                case ItemTypeEnum.MosquitoNet:
                    ViewModel.Data.ImageURI = "icon_mosquito_net.png";
                    break;

                case ItemTypeEnum.Goggles:
                    ViewModel.Data.ImageURI = "icon_goggles.png";
                    break;

                case ItemTypeEnum.Gloves:
                    ViewModel.Data.ImageURI = "icon_gloves.png";
                    break;

                case ItemTypeEnum.Vaccine:
                    ViewModel.Data.ImageURI = "icon_vaccine.png";
                    break;

                case ItemTypeEnum.Medicine:
                    ViewModel.Data.ImageURI = "icon_medicine.png";
                    break;

                case ItemTypeEnum.HazmatSuit:
                    ViewModel.Data.ImageURI = "icon_hazmat_suit.png";
                    break;

                case ItemTypeEnum.Panacea:
                    ViewModel.Data.ImageURI = "icon_panacea.png";
                    break;

                case ItemTypeEnum.InvisibleCloak:
                    ViewModel.Data.ImageURI = "icon_invisible_cloak.png";
                    break;

                default:
                    break;
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
            await Navigation.PopModalAsync();
        }

        private void OnItemTypePickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var SelectedItem = (ItemTypeEnum)ItemTypeEnumHelper.ConvertMappedStringToEnum((String)picker.SelectedItem);

            switch (SelectedItem)
            {
                case ItemTypeEnum.HandSoap:
                    ItemImage.Source = "icon_hand_soap.png";
                    break;

                case ItemTypeEnum.BoxOfTissues:
                    ItemImage.Source = "icon_tissue_box.png";
                    break;

                case ItemTypeEnum.Mask:
                    ItemImage.Source = "icon_mask.png";
                    break;

                case ItemTypeEnum.Sanitizer:
                    ItemImage.Source = "icon_sanitizer.png";
                    break;

                case ItemTypeEnum.FaceShield:
                    ItemImage.Source = "icon_face_shield.png";
                    break;

                case ItemTypeEnum.Soup:
                    ItemImage.Source = "icon_soup.png";
                    break;

                case ItemTypeEnum.BugSpray:
                    ItemImage.Source = "icon_bug_spray.png";
                    break;

                case ItemTypeEnum.MosquitoNet:
                    ItemImage.Source = "icon_mosquito_net.png";
                    break;

                case ItemTypeEnum.Goggles:
                    ItemImage.Source = "icon_goggles.png";
                    break;

                case ItemTypeEnum.Gloves:
                    ItemImage.Source = "icon_gloves.png";
                    break;

                case ItemTypeEnum.Vaccine:
                    ItemImage.Source = "icon_vaccine.png";
                    break;

                case ItemTypeEnum.Medicine:
                    ItemImage.Source = "icon_medicine.png";
                    break;

                case ItemTypeEnum.HazmatSuit:
                    ItemImage.Source = "icon_hazmat_suit.png";
                    break;

                case ItemTypeEnum.Panacea:
                    ItemImage.Source = "icon_panacea.png";
                    break;

                case ItemTypeEnum.InvisibleCloak:
                    ItemImage.Source = "icon_invisible_cloak.png";
                    break;

                default:
                    break;
            }
        }
    }
}