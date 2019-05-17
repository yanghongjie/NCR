using System;
using Microsoft.Extensions.DependencyInjection;
using NCR.Internal;
using NCR.Models;

namespace NCR.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddNcr(this IServiceCollection services)
        {
            services.AddSingleton<IRuleRepository, RuleRepositoryInMemory>();
            services.AddSingleton<IRuleCompute, RuleComputeBase>();
            services.AddSingleton<IRuleEngine, RuleEngine>();
        }
    }

}