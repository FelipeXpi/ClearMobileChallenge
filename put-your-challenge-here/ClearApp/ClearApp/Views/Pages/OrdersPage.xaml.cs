using ClearApp.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DependencyService = ClearApp.Services.DependencyService;

namespace ClearApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersPage : ContentPage, IViewModelPage
    {
        public OrdersPage()
        {
            InitializeComponent();
            BindViewModel();
        }

        #region IViewModelPage

        public void BindViewModel() =>
            DependencyService.BindViewModel(this);

        #endregion
    }
}