using Microsoft.Extensions.DependencyInjection;

namespace KLabs.Core.ServiceInjector.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
