using System;
using Microsoft.Extensions.DependencyInjection;
using NCR.Internal;
using NCR.Models;

namespace NCR.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddNetCoreRule(this IServiceCollection services,Action<NcrOptions> setupAction)
        {
            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            services.AddSingleton<IRuleRespository, RuleRespositoryInMemory>();
            services.AddSingleton<IRuleCompute, RuleComputeBase>();
            services.AddSingleton<IRuleEngine, RuleEngine>();
        }
    }

    public class NcrOptions
    {

    }
}