﻿using ClearApp.Abstractions;
using ClearApp.ViewModels.Pages;
using ClearApp.Views.Pages;
using System;
using System.Globalization;
using System.Reflection;
using TinyIoC;
using Xamarin.Forms;

namespace ClearApp.Services
{
    public static class DependencyService
    {
        private static TinyIoCContainer container;

        public static void InitializeContainer()
        {
            container = TinyIoCContainer.Current;
            RegisterDependencies();
        }

        private static void RegisterDependencies()
        {
            container.Register<IApiService, ApiService>();
            container.Register<OrdersPageViewModel>();
            container.Register<OrdersPage>();
        }

        public static void BindViewModel(BindableObject bindable)
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

            var viewModel = container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}
