using ClearApp.Services;

namespace ClearApp
{
    public sealed class Startup
    {
        public Startup() : base()
        {
            DependencyService.InitializeContainer();
        }
    }
}
