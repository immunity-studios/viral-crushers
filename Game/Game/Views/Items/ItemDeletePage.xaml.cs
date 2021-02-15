using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

namespace Game.Views
{
    /// <summary>
    /// The Read Page
    /// </summary>
    [DesignTimeVisible(false)] 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDeletePage : ContentPage
    {
        // View Model for Item
        readonly GenericViewModel<ItemModel> viewModel;

        // Empty Constructor for UTs
        public ItemDeletePage(bool UnitTest) { }

        // Constructor for Delete takes a view model of what to delete
        public ItemDeletePage(GenericViewModel<ItemModel> data)
        {
            InitializeComponent();

            BindingContext = this.viewModel = data;

            this.viewModel.Title = "Delete " + data.Title;

            switch (viewModel.Data.ItemType)
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
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Delete", viewModel.Data);
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

        /// <summary>
        /// Trap the Back Button on the Phone
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            // Add your code here...
            return true;
        }
    }
}