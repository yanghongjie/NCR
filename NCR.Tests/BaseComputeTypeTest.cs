using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCR.Internal;
using NCR.Models;


namespace NCR.Tests
{
    [TestClass]
    public class BaseComputeTypeTest: RuleTestBase
    {
        #region OneItemTestCase

        [TestMethod]
        public void Rule_OneItem_LessThen()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "Rule_OneItem_LessThen",
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
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "14" } };
            //运算
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_MoreThan()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "Rule_OneItem_MoreThan",
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
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "20" } };
            //运算
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_NotEqualsTo()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "Rule_OneItem_NotEqualsTo",
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
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "sex", "women" } };
            //运算
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_Contains()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "Rule_OneItem_Contains",
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
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "say", "World" } };
            //运算
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_NotContain()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "Rule_OneItem_NotContain",
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
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "say", "Hi" } };
            //运算
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_LessThanOrEquals()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "Rule_OneItem_LessThanOrEquals",
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
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "18" } };
            //运算
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_MoreThanOrEquals()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "Rule_OneItem_MoreThanOrEquals",
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
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "18" } };
            //运算
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_All()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "Rule_OneItem_All",
                Items = new List<RuleItem>
                {
                    new RuleItem
                    {
                        RuleItemType = "age",
                        ComputeType = BaseComputeType.All.ToString(),
                        Value = "18",
                    }
                },
            };
            //添加规则到引擎
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "what" } };
            //运算
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_EqualsOneOfArray()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "Rule_OneItem_EqualsOneOfArray",
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
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "19" } };
            //运算
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_NotEqualsOneOfArray()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "Rule_OneItem_NotEqualsOneOfArray",
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
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "what" } };
            //运算
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_RegexTrue()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "Rule_OneItem_RegexTrue",
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
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "18" } };
            //运算
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_RegexFalse()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "Rule_OneItem_RegexFalse",
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
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "what" } };
            //运算
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        #endregion

        #region MoreItemTestCase

        [TestMethod]
        public void Rule_MoreItem()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "Rule_OneItem_MoreItem",
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
                    //new RuleItem
                    //{
                    //    RuleItemType = "weight",
                    //    ComputeType = BaseComputeType.MoreThan.ToString(),
                    //    Value = "60",
                    //}
                },
            };
            //添加规则到引擎
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact {{"age", "14"}, {"sex", "man"}};
            //运算
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_MoreItem_ComputeResult()
        {
            //定义规则
            var rule = new Rule
            {
                Name = "Rule_OneItem_MoreItem",
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
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //定义事实
            var fact = new Fact { { "age", "14" }, { "sex", "man" } };
            //运算
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        #endregion
    }
}
