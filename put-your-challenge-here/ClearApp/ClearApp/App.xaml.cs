using ClearApp.Views.Pages;
using Xamarin.Forms;

namespace ClearApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var _ = new Startup();

            var rootPage = new LoginPage();
            var navigationPage = new NavigationPage(rootPage);

            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
