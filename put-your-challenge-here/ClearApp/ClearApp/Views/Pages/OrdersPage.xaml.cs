using ClearApp.ViewModels.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClearApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersPage : ContentPage
    {
        private OrdersPageViewModel viewModel;

        public OrdersPage() =>
            InitializeComponent();

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel = BindingContext as OrdersPageViewModel;
            viewModel.OnAppearingCommand.Execute(null);
        }
    }
}