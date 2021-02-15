using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Game.Views
{
    public partial class BackButtonControl : ImageButton
    {
        public BackButtonControl()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty PopModalProperty = BindableProperty.Create(nameof(PopModal), typeof(bool), typeof(CurvedLabelControl));

        public bool PopModal
        {
            get
            {
                return (bool)GetValue(PopModalProperty);
            }
            set
            {
                SetValue(PopModalProperty, value);
            }
        }

        async void BackButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if (PopModal)
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                await Navigation.PopAsync();
            }
        }
    }
}
