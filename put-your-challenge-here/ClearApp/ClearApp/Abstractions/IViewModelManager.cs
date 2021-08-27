using ClearApp.ViewModels.Pages;
using Xamarin.Forms;

namespace ClearApp.Abstractions
{
    public interface IViewModelManager
    {
        void BindViewModel(BindableObject bindable);
    }
}
