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
            //�������
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
            //��ӹ�������
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule);
            //������ʵ
            var fact = new Fact { { "name", "admin" } };
            //����
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);
        }

        [TestMethod]
        public async Task CustomComputeType_OneItem_NotExistsBySql()
        {
            //�������
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
            //��ӹ�������
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule);
            //������ʵ
            var fact = new Fact { { "name", "haha" } };
            //����
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);
        }

        #endregion
    }
}
