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
    public partial class CharacterReadPage : ContentPage
    {
        // View Model for Item
        public readonly GenericViewModel<CharacterModel> ViewModel;

        // Empty Constructor for UTs
        public CharacterReadPage(bool UnitTest) { }

        /// <summary>
        /// Constructor called with a view model
        /// This is the primary way to open the page
        /// The viewModel is the data that should be displayed
        /// </summary>
        /// <param name="viewModel"></param>
        public CharacterReadPage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            CharacterImage.Source = ViewModel.Data.Job.ToImageFile();

            String SpecialAbility = "";

            switch (data.Data.Job)
            {
                case CharacterJobEnum.Doctor:
                    SpecialAbility = 
                    SpecialAbilityEnumHelper.GetListDoctor[0];
                    break;

                case CharacterJobEnum.Teacher:
                    SpecialAbility =
                    SpecialAbilityEnumHelper.GetListTeacher[0];
                    break;

                case CharacterJobEnum.Athlete:
                    SpecialAbility =
                    SpecialAbilityEnumHelper.GetListAthlete[0];
                    break;

                case CharacterJobEnum.PoliceOfficer:
                    SpecialAbility =
                    SpecialAbilityEnumHelper.GetListPoliceOfficer[0];
                    break;

                case CharacterJobEnum.CollegeStudent:
                    SpecialAbility =
                    SpecialAbilityEnumHelper.GetListCollegeStudent[0];
                    break;

                case CharacterJobEnum.Firefighter:
                    SpecialAbility =
                    SpecialAbilityEnumHelper.GetListFireFighter[0];
                    break;

                case CharacterJobEnum.Unknown:
                default:
                    break;
            }

            if (SpecialAbility.Length != 0)
            {
                SpecialAbilityLabel.Text = SpcialAbilityEnumExtensions.ToMessage(SpecialAbilityEnumHelper.ConvertStringToEnum(SpecialAbility));
            }
            

        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Update_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CharacterUpdatePage(ViewModel)));
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Calls for Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CharacterDeletePage(ViewModel)));
            await Navigation.PopAsync();
        }
    }
}