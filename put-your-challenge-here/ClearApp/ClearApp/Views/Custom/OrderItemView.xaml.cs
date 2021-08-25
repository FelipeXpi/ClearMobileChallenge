using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClearApp.Views.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderItemView : Grid
    {
        public OrderItemView()
        {
            InitializeComponent();
        }
    }
}