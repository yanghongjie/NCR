using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace NCR.Tests
{
    [TestClass]
    public class RuleTest: RuleTestBase
    {
        [TestMethod]
        public void Rule_LessThen()
        {
            //定义规则
            var rule = new Rule {
                Name = "lessThen rule",
                Enabled = true,
                Type = "",
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "age",
                        ComputeType = BaseComputeType.LessThan.ToString(),
                        Value = "18",
                        Enabled = true
                    }
                },
            };
            //添加规则到引擎
            RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact {{"age", "14"}};
            //运算
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }
    }
}
