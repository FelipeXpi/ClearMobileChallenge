using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClearApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnOpenAccountClicked(object sender, EventArgs e)
        {
            var uri = new Uri(Constants.OPEN_ACCOUNT_URL);
            await Browser.OpenAsync(uri).ConfigureAwait(false);
        }

        private async void OnLoginClicked(object sender, EventArgs e) =>
            await Navigation.PushAsync(new OrdersPage()).ConfigureAwait(false);
    }
}