using ClearApp.Services;
using ClearApp.ViewModels.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClearApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersPage : ContentPage
    {
        private readonly OrdersPageViewModel _viewModel;

        public OrdersPage()
        {
            InitializeComponent();

            _viewModel = this.GetViewModel() as OrdersPageViewModel;
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearingCommand.Execute(null);
        }
    }
}