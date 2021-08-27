using ClearApp.Abstractions;
using ClearApp.Extensions;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ClearApp.ViewModels.Pages
{
    public class LoginPageViewModel : BasePageViewModel
    {
        #region Fields

        private readonly INavigationService _navigationService;

        #endregion

        #region Properties

        public ICommand LoginCommand =>
            new Command(LoginCommandExecute);

        public ICommand OpenAccountCommand =>
            new Command(OpenAccountCommandExecute);

        #endregion

        #region Constructors

        public LoginPageViewModel(INavigationService navigationService) =>
            _navigationService = navigationService;

        #endregion

        #region Private Methods

        private async void LoginCommandExecute(object sender) =>
            await _navigationService.ConfigureAndNavigateTo("OrdersPage").ConfigureAwait(false);

        private async void OpenAccountCommandExecute(object sender)
        {
            var uri = new Uri(Constants.OPEN_ACCOUNT_URL);
            await Browser.OpenAsync(uri).ConfigureAwait(false);
        }

        #endregion
    }
}
