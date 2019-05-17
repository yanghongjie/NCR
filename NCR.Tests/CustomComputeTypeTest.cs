using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCR.Models;
using NCR.Tests.Base;


namespace NCR.Tests
{
    [TestClass]
    public class CustomComputeTypeTest : RuleTestBase
    {
        #region OneItemTestCase

        [TestMethod]
        public async Task CustomComputeType_OneItem_ExistsBySql()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "CustomComputeType_OneItem_ExistsBySql",
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "name",
                        ComputeType = "ExistsBySql",
                        Value = "select 1 from user where userName = @CheckValue;",
                    }
                },
            };
            //添加规则到引擎
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "name", "admin" } };
            //运算
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);
        }

        [TestMethod]
        public async Task CustomComputeType_OneItem_NotExistsBySql()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "CustomComputeType_OneItem_NotExistsBySql",
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "name",
                        ComputeType = "NotExistsBySql",
                        Value = "select 1 from user where userName = @CheckValue;",
                    }
                },
            };
            //添加规则到引擎
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "name", "haha" } };
            //运算
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);
        }

        #endregion
    }
}
