using ClearApp.Abstractions;
using ClearApp.Apis;
using ClearApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClearApp.Services
{
    public sealed class ApiService : IApiService, IDisposable
    {
        #region Fields

        private readonly HttpClient _client;
        private readonly IRestApi _api;

        #endregion

        #region Constructors

        public ApiService()
        {
            _client = new HttpClient() {
                BaseAddress = new Uri(Constants.Api.URL)
            };

            _api = RestService.For<IRestApi>(_client);
        }

        #endregion

        #region IApiService

        public async Task<IEnumerable<Order>> GetOrdersAsync() =>
             await _api.GetOrders().ConfigureAwait(false);

        #endregion

        #region IDisposable

        public void Dispose() =>
            _client?.Dispose();

        #endregion
    }
}
