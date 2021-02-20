using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.Models;
using Game.ViewModels;
using System.Linq;

namespace Game.Views
{
    /// <summary>
    /// Index Page
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0019:Use pattern matching", Justification = "<Pending>")]
    [DesignTimeVisible(false)] 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterIndexPage : ContentPage
    {
        // The view model, used for data binding
        readonly CharacterIndexViewModel ViewModel = CharacterIndexViewModel.Instance;

        // Empty Constructor for UTs
        public CharacterIndexPage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Index Page

        /// Get the ItemIndexView Model
        /// </summary>
        public CharacterIndexPage()
        {
            InitializeComponent();

            BindingContext = ViewModel;
        }

        #region CollectionView Handlers

        /// <summary>
        /// Select the item from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            CharacterModel data = CharactersCollectionView.SelectedItem as CharacterModel;
            if (data == null)
            {
                return;
            }

            // Open the Read Page
            await Navigation.PushAsync(new CharacterReadPage(new GenericViewModel<CharacterModel>(data)));

            // Manually deselect item.
            CharactersCollectionView.SelectedItem = null;
        }

        #endregion

        /// <summary>
        /// Call to Add a new record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void AddCharacter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CharacterCreatePage()));
        }

        /// <summary>
        /// Refresh the list on page appearing
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = null;

            // If no data, then set it for needing refresh
            if (ViewModel.Dataset.Count == 0)
            {
                ViewModel.SetNeedsRefresh(true);
            }

            // If the needs Refresh flag is set update it
            if (ViewModel.NeedsRefresh())
            {
                ViewModel.LoadDatasetCommand.Execute(null);
            }

            BindingContext = ViewModel;
        }
    }
}