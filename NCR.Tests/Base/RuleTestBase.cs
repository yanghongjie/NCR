using Microsoft.Extensions.DependencyInjection;
using Moq;
using NCR.Internal;
using NCR.Models;
using NCR.Tests.Base;

namespace NCR.Tests.Base
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
            var dataAccess = new Mock<IDataAccess>();
            dataAccess.Setup(x => x.ExecuteNonQuery(It.IsAny<string>(), new
            {
                CheckValue = "admin"
            })).Returns(1);
            dataAccess.Setup(x => x.ExecuteNonQuery(It.IsAny<string>(), new
            {
                CheckValue = "haha"
            })).Returns(0);
            _services.AddSingleton<IRuleRespository, RuleRespositoryInMemory>();
            _services.AddSingleton<IRuleCompute, RuleComputeCustom>();
            _services.AddSingleton<IRuleEngine, RuleEngine>();
            _services.AddSingleton(dataAccess.Object);
        }

        public IRuleEngine GetRuleEngine()
        {
            var provider = _services.BuildServiceProvider();
            var engine = provider.GetService<IRuleEngine>();
            return engine;
        }
    }
}