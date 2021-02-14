using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Game.Views
{
    public partial class CurvedLabelControl : ContentView
    {
        public CurvedLabelControl()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CurvedLabelControl));

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public static readonly BindableProperty TextBackgroundColorProperty = BindableProperty.Create(nameof(TextBackgroundColor), typeof(Color), typeof(CurvedLabelControl));

        public Color TextBackgroundColor
        {
            get
            {
                return (Color)GetValue(TextBackgroundColorProperty);
            }
            set
            {
                SetValue(TextBackgroundColorProperty, value);
            }
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(CurvedLabelControl));

        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(CurvedLabelControl));

        public float CornerRadius
        {
            get
            {
                return (float)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(CurvedLabelControl));

        public double FontSize
        {
            get
            {
                return (double)GetValue(FontSizeProperty);
            }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }

        public static readonly BindableProperty FrameHorizontalOptionsProperty = BindableProperty.Create(nameof(FrameHorizontalOptions), typeof(LayoutOptions), typeof(CurvedLabelControl));

        public LayoutOptions FrameHorizontalOptions
        {
            get
            {
                return (LayoutOptions)GetValue(FrameHorizontalOptionsProperty);
            }
            set
            {
                SetValue(FrameHorizontalOptionsProperty, value);
            }
        }
    }
}
