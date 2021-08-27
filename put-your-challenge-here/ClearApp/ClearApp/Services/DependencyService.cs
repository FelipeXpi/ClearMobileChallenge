using ClearApp.Abstractions;
using ClearApp.Apis;
using ClearApp.Managers;
using Refit;
using System;
using System.Net.Http;
using TinyIoC;

namespace ClearApp.Services
{
    public static class DependencyService
    {
        #region Fields

        private static TinyIoCContainer container;
        private static HttpClient httpClient;

        #endregion

        #region Public Methods

        public static void Initialize()
        {
            container = TinyIoCContainer.Current;

            var restApi = BuildRestApi();
            var viewModelManager = new ViewModelManager(container);

            container.Register(restApi);
            container.Register<IViewModelManager>(viewModelManager);
            container.Register<INavigationService, NavigationService>();
            container.Register<IApiService, ApiService>();
        }

        public static T Get<T>() where T : class =>
            container.Resolve<T>();

        public static object Get(Type pageType) =>
            container.Resolve(pageType);

        #endregion

        #region Private Methods

        private static IRestApi BuildRestApi()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri(Constants.Api.URL)
            };

            return RestService.For<IRestApi>(httpClient);
        }

        #endregion
    }
}
