﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClearApp.Styles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefaultTheme : ResourceDictionary
    {
        public DefaultTheme() => InitializeComponent();
    }
}