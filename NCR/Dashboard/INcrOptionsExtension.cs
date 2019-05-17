using Microsoft.Extensions.DependencyInjection;

namespace NCR.Dashboard
{
    public interface INcrOptionsExtension
    {
        void AddServices(IServiceCollection services);
    }
}