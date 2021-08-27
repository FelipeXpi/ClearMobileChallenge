using ClearApp.Abstractions;
using ClearApp.ViewModels.Pages;
using System;
using System.Globalization;
using System.Reflection;
using TinyIoC;
using Xamarin.Forms;

namespace ClearApp.Managers
{
    public class ViewModelManager : IViewModelManager
    {
        #region Fields

        private readonly TinyIoCContainer _container;

        #endregion

        #region Constructors

        public ViewModelManager(TinyIoCContainer container) =>
            _container = container;

        #endregion

        #region IViewModelManager

        public void BindViewModel(BindableObject bindable)
        {
            var view = bindable as Element;

            if (view == null) return;
            if (view.BindingContext != null) return;

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(
                CultureInfo.InvariantCulture, "{0}ViewModel, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName, false, true);
            if (viewModelType == null) return;

            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }

        #endregion
    }
}
