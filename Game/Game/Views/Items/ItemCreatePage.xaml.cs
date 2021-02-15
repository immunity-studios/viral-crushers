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
    public partial class ItemCreatePage : ContentPage
    {
        // The item to create
        public GenericViewModel<ItemModel> ViewModel = new GenericViewModel<ItemModel>();

        // Empty Constructor for UTs
        public ItemCreatePage(bool UnitTest){}

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public ItemCreatePage()
        {
            InitializeComponent();

            this.ViewModel.Data = new ItemModel();

            BindingContext = this.ViewModel;

            this.ViewModel.Title = "Item Create";

            //Need to make the SelectedItem a string, so it can select the correct item.
            ItemTypePicker.SelectedItem = ViewModel.Data.ItemType.ToString();
            LocationPicker.SelectedItem = ItemLocationEnumHelper.ConvertEnumToMappedString(ViewModel.Data.Location);
            AttributePicker.SelectedItem = ViewModel.Data.Attribute.ToString();

            switch (ViewModel.Data.ItemType)
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

            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = Services.ItemService.DefaultImageURI;
            }

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