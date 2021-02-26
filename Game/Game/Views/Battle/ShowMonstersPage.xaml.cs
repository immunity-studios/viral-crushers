using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.Models;
using Game.ViewModels;

namespace Game.Views
{
    /// <summary>
    /// Index Page
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0019:Use pattern matching", Justification = "<Pending>")]
    [DesignTimeVisible(false)] 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowMonstersPage : ContentPage
    {
        // The view model, used for data binding
        readonly MonsterIndexViewModel ViewModel = MonsterIndexViewModel.Instance;

        // Empty Constructor for UTs
        public ShowMonstersPage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Index Page
        /// 
        /// Get the ItemIndexView Model
        /// </summary>
        public ShowMonstersPage()
        {
            InitializeComponent();

            BindingContext = ViewModel;
        }

        #region CollectionViewHandlers
        /// <summary>
        /// Select the item from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            MonsterModel data = MonstersCollectionView.SelectedItem as MonsterModel;
            if (data == null)
            {
                return;
            }

            // Open the Read Page
            await Navigation.PushAsync(new MonsterReadPage(new GenericViewModel<MonsterModel>(data)));

            // Manually deselect item.
            MonstersCollectionView.SelectedItem = null;
        }
        #endregion


        #region ListViewHandlers
        /// <summary>
        /// The row selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            MonsterModel data = args.SelectedItem as MonsterModel;
            if (data == null)
            {
                return;
            }

            // Open the Read Page
            await Navigation.PushAsync(new MonsterReadPage(new GenericViewModel<MonsterModel>(data)));

            // Manually deselect item.
            //ItemsListView.SelectedItem = null;
        }

        /// <summary>
        /// Call to Add a new record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MonsterCreatePage()));
        }
        #endregion

        /// <summary>
        /// Jump to the Battle
        /// 
        /// Its Modal because don't want user to come back...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void BattleButton_Clicked(object sender, EventArgs e)
        {
            // CreateEngineCharacterList();

            await Navigation.PushModalAsync(new NavigationPage(new BattlePage()));
            await Navigation.PopAsync();
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