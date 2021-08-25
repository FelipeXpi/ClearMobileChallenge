using ClearApp.Abstractions;
using Moq;

namespace ClearAppTests.ViewModels
{
    public abstract class BaseTestableViewModel
    {
        protected readonly Mock<IApiService> _apiService;

        protected BaseTestableViewModel()
        {
            _apiService = new Mock<IApiService>();
        }
    }
}
