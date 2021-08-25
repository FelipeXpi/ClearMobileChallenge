using ClearApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClearApp.Abstractions
{
    public interface IApiService
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
    }
}
