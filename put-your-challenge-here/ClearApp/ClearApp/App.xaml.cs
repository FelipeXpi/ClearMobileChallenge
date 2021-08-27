using ClearApp.Abstractions;
using ClearApp.Extensions;
using ClearApp.Views.Pages;
using Xamarin.Forms;
using DependencyService = ClearApp.Services.DependencyService;

namespace ClearApp
{
    public partial class App : Application
    {
        #region Constructors

        public App()
        {
            InitializeComponent();

            InitializeDependencies();
            GoToMainPage();
        }

        #endregion

        #region Public Methods

        public INavigationService GetNavigator() =>
            DependencyService.Get<INavigationService>();

        #endregion

        #region Private Methods

        private void InitializeDependencies() =>
            DependencyService.Initialize();

        private void GoToMainPage() =>
            GetNavigator()
                .ConfigureAndNavigateTo(nameof(LoginPage))
                .SafeFireAndForget();

        #endregion
    }
}
