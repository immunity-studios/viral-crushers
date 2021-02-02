using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootMenuTabbedPage : TabbedPage
    {
        public RootMenuTabbedPage()
        {
            InitializeComponent();
            this.Children.Add(new GamePage());
            this.Children.Add(new CharacterIndexPage());
            this.Children.Add(new ItemIndexPage());
            this.Children.Add(new ItemIndexPage());
        }
    }
}
