using Microsoft.Extensions.DependencyInjection;
using NCR.Internal;

namespace NCR.Tests
{
    public class RuleTestBase
    {
        private readonly ServiceCollection _services = new ServiceCollection();
        public IRuleEngine RuleEngine => GetRuleEngine();

        public RuleTestBase()
        {
            Setup();
        }
        public void Setup()
        {
            _services.AddSingleton<IRuleRespository, RuleRespositoryInMemory>();
            _services.AddSingleton<IRuleCompute, RuleComputeBase>();
            _services.AddSingleton<IRuleEngine, RuleEngine>();
        }

        public IRuleEngine GetRuleEngine()
        {
            var provider = _services.BuildServiceProvider();
            var engine = provider.GetService<IRuleEngine>();
            return engine;
        }


    }
}