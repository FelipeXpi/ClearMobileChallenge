using ClearApp.Abstractions;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClearApp.Services
{
    public sealed class NavigationService : INavigationService
    {
        #region Fields

        private readonly NavigationPage _navigator;
        private readonly IViewModelManager _viewModelManager;

        #endregion

        #region Constructors

        public NavigationService(IViewModelManager viewModelManager)
        {
            _viewModelManager = viewModelManager;

            _navigator = new NavigationPage();
            Application.Current.MainPage = _navigator;
        }

        #endregion

        #region INavigationService

        public async Task ConfigureAndNavigateTo(string url)
        {
            var page = BuildPage(url);

            await NavigateTo(page).ConfigureAwait(false);
        }

        #endregion

        #region Private Methods

        private Page BuildPage(string url)
        {
            var pageType = Type.GetType($"ClearApp.Views.Pages.{url}");
            var page = (Page) DependencyService.Get(pageType);

            _viewModelManager.BindViewModel(page);
            return page;
        }

        private async Task NavigateTo(Page page) =>
            await _navigator.PushAsync(page).ConfigureAwait(false);

        #endregion
    }
}
