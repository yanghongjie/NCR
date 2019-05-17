using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCR.Enums;
using NCR.Models;
using NCR.Tests.Base;


namespace NCR.Tests
{
    [TestClass]
    public class BaseComputeTypeTest: RuleTestBase
    {
        #region OneItemTestCase

        [TestMethod]
        public async Task BaseComputeType_OneItem_LessThen()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "BaseComputeType_OneItem_LessThen",
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "age",
                        ComputeType = BaseComputeType.LessThan.ToString(),
                        Value = "18",
                    }
                },
            };
            //添加规则到引擎
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "14" } };
            //运算
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);
        }

        [TestMethod]
        public async Task BaseComputeType_OneItem_MoreThan()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "BaseComputeType_OneItem_MoreThan",
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "age",
                        ComputeType = BaseComputeType.MoreThan.ToString(),
                        Value = "18",
                    }
                },
            };
            //添加规则到引擎
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "20" } };
            //运算
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);
        }

        [TestMethod]
        public async Task BaseComputeType_OneItem_NotEqualsTo()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "BaseComputeType_OneItem_NotEqualsTo",
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "sex",
                        ComputeType = BaseComputeType.NotEqualsTo.ToString(),
                        Value = "man",
                    }
                },
            };
            //添加规则到引擎
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "sex", "women" } };
            //运算
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);
        }

        [TestMethod]
        public async Task BaseComputeType_OneItem_Contains()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "BaseComputeType_OneItem_Contains",
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "say",
                        ComputeType = BaseComputeType.Contains.ToString(),
                        Value = "Hello World!",
                    }
                },
            };
            //添加规则到引擎
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "say", "World" } };
            //运算
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);
        }

        [TestMethod]
        public async Task BaseComputeType_OneItem_NotContain()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "BaseComputeType_OneItem_NotContain",
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "say",
                        ComputeType = BaseComputeType.NotContain.ToString(),
                        Value = "Hello World!",
                    }
                },
            };
            //添加规则到引擎
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "say", "Hi" } };
            //运算
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);
        }

        [TestMethod]
        public async Task BaseComputeType_OneItem_LessThanOrEquals()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "BaseComputeType_OneItem_LessThanOrEquals",
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "age",
                        ComputeType = BaseComputeType.LessThanOrEquals.ToString(),
                        Value = "18",
                    }
                },
            };
            //添加规则到引擎
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "18" } };
            //运算
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);
        }

        [TestMethod]
        public async Task BaseComputeType_OneItem_MoreThanOrEquals()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "BaseComputeType_OneItem_MoreThanOrEquals",
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "age",
                        ComputeType = BaseComputeType.MoreThanOrEquals.ToString(),
                        Value = "18",
                    }
                },
            };
            //添加规则到引擎
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "18" } };
            //运算
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);
        }

        [TestMethod]
        public async Task BaseComputeType_OneItem_Any()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "BaseComputeType_OneItem_Any",
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "age",
                        ComputeType = BaseComputeType.Any.ToString(),
                        Value = "18",
                    }
                },
            };
            //添加规则到引擎
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "what" } };
            //运算
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);
        }

        [TestMethod]
        public async Task BaseComputeType_OneItem_EqualsOneOfArray()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "BaseComputeType_OneItem_EqualsOneOfArray",
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "age",
                        ComputeType = BaseComputeType.EqualsOneOfArray.ToString(),
                        Value = "18,19,20",
                    }
                },
            };
            //添加规则到引擎
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "19" } };
            //运算
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);
        }

        [TestMethod]
        public async Task BaseComputeType_OneItem_NotEqualsOneOfArray()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "BaseComputeType_OneItem_NotEqualsOneOfArray",
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "age",
                        ComputeType = BaseComputeType.NotEqualsOneOfArray.ToString(),
                        Value = "18,19,20",
                    }
                },
            };
            //添加规则到引擎
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "what" } };
            //运算
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);
        }

        [TestMethod]
        public async Task BaseComputeType_OneItem_RegexTrue()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "BaseComputeType_OneItem_RegexTrue",
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "age",
                        ComputeType = BaseComputeType.RegexTrue.ToString(),
                        Value = @"^\d+$",
                    }
                },
            };
            //添加规则到引擎
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "18" } };
            //运算
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);
        }

        [TestMethod]
        public async Task BaseComputeType_OneItem_RegexFalse()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "BaseComputeType_OneItem_RegexFalse",
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "age",
                        ComputeType = BaseComputeType.RegexFalse.ToString(),
                        Value = @"^\d+$",
                    }
                },
            };
            //添加规则到引擎
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "what" } };
            //运算
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);
        }

        #endregion

        #region MoreItemTestCase

        [TestMethod]
        public async Task BaseComputeType_MoreItem_HitRule()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "BaseComputeType_MoreItem_HitRule",
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "age",
                        ComputeType = BaseComputeType.LessThan.ToString(),
                        Value = "18",
                    },
                    new RuleItem
                    {
                        RuleItemType = "sex",
                        ComputeType = BaseComputeType.EqualsTo.ToString(),
                        Value = "man",
                    }
                },
            };
            //添加规则到引擎
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact {{"age", "14"}, {"sex", "man"}};
            //运算
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);
        }

        [TestMethod]
        public async Task BaseComputeType_MoreItem_MissRule()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "BaseComputeType_MoreItem_MissRule",
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "age",
                        ComputeType = BaseComputeType.LessThan.ToString(),
                        Value = "18",
                    },
                    new RuleItem
                    {
                        RuleItemType = "sex",
                        ComputeType = BaseComputeType.EqualsTo.ToString(),
                        Value = "man",
                    },
                    new RuleItem
                    {
                        RuleItemType = "weight",
                        ComputeType = BaseComputeType.MoreThan.ToString(),
                        Value = "60",
                    }
                },
            };
            //添加规则到引擎
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "14" }, { "sex", "man" }, { "weight", "50" } };
            //运算
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsNull(res.HitRule);
            Assert.IsFalse(res.Success);
            Assert.IsTrue(res.Infos.Any(x => x.MissRuleItemType == "weight"));
        }

        #endregion

        #region MoreRuleTestCase

        [TestMethod]
        public async Task BaseComputeType_MoreBaseComputeType_HitRule()
        {
            //定义规则
            var rule1 = new Rule
            {
                Name = "BaseComputeType_MoreBaseComputeType_HitRule1",
                Priority = 1,
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "age",
                        ComputeType = BaseComputeType.LessThan.ToString(),
                        Value = "15",
                    }
                },
            };
            var rule2 = new Rule
            {
                Name = "BaseComputeType_MoreBaseComputeType_HitRule2",
                Priority = 0,
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "age",
                        ComputeType = BaseComputeType.LessThan.ToString(),
                        Value = "18",
                    }
                },
            };
            //添加规则到引擎
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule1);
            await RuleEngine.AddRule(rule2);
            //定义事实
            var fact = new Fact { { "age", "14" } };
            //运算
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);
            Assert.AreEqual(res.HitRule.Name, "BaseComputeType_MoreBaseComputeType_HitRule1");
        }

        [TestMethod]
        public async Task BaseComputeType_MoreBaseComputeType_MissRule()
        {
            //定义规则
            var rule1 = new Rule
            {
                Name = "BaseComputeType_MoreBaseComputeType_MissRule",
                Priority = 1,
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "age",
                        ComputeType = BaseComputeType.LessThan.ToString(),
                        Value = "15",
                    }
                },
            };
            var rule2 = new Rule
            {
                Name = "BaseComputeType_MoreBaseComputeType_HitRule2",
                Priority = 0,
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "age",
                        ComputeType = BaseComputeType.LessThan.ToString(),
                        Value = "18",
                    }
                },
            };
            //添加规则到引擎
            await RuleEngine.Clear();
            await RuleEngine.AddRule(rule1);
            await RuleEngine.AddRule(rule2);
            //定义事实
            var fact = new Fact { { "age", "24" } };
            //运算
            var res = await RuleEngine.Compute(fact);

            Assert.IsNotNull(res);
            Assert.IsNull(res.HitRule);
            Assert.IsFalse(res.Success);
            Assert.IsTrue(res.Infos.Any(x => x.MissRuleItemType == "age"));
        }

        #endregion
    }
}
