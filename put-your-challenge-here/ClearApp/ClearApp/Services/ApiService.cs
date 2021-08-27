using ClearApp.Abstractions;
using ClearApp.Apis;
using ClearApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClearApp.Services
{
    public sealed class ApiService : IApiService
    {
        #region Fields

        private readonly IRestApi _restApi;

        #endregion

        #region Constructors

        public ApiService(IRestApi restApi) =>
            _restApi = restApi;

        #endregion

        #region IApiService

        public async Task<IEnumerable<Order>> GetOrdersAsync() =>
             await _restApi.GetOrders().ConfigureAwait(false);

        #endregion
    }
}
