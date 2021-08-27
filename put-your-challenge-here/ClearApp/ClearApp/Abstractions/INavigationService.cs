using System.Threading.Tasks;

namespace ClearApp.Abstractions
{
    public interface INavigationService
    {
        Task ConfigureAndNavigateTo(string url);
    }
}
