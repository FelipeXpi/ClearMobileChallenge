using ClearApp.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClearApp.Apis
{
    public interface IRestApi
    {
        [Headers("accept: application/json")]
        [Get("/api/v1/swingtrade/orders")]
        Task<IEnumerable<Order>> GetOrders();
    }
}
