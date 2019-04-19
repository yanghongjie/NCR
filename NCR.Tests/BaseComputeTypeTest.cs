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
            //�������
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
            //��ӹ�������
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //������ʵ
            var fact = new Fact { { "age", "14" } };
            //����
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_MoreThan()
        {
            //�������
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
            //��ӹ�������
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //������ʵ
            var fact = new Fact { { "age", "20" } };
            //����
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_NotEqualsTo()
        {
            //�������
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
            //��ӹ�������
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //������ʵ
            var fact = new Fact { { "sex", "women" } };
            //����
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_Contains()
        {
            //�������
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
            //��ӹ�������
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //������ʵ
            var fact = new Fact { { "say", "World" } };
            //����
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_NotContain()
        {
            //�������
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
            //��ӹ�������
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //������ʵ
            var fact = new Fact { { "say", "Hi" } };
            //����
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_LessThanOrEquals()
        {
            //�������
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
            //��ӹ�������
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //������ʵ
            var fact = new Fact { { "age", "18" } };
            //����
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_MoreThanOrEquals()
        {
            //�������
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
            //��ӹ�������
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //������ʵ
            var fact = new Fact { { "age", "18" } };
            //����
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_All()
        {
            //�������
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
            //��ӹ�������
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //������ʵ
            var fact = new Fact { { "age", "what" } };
            //����
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_EqualsOneOfArray()
        {
            //�������
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
            //��ӹ�������
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //������ʵ
            var fact = new Fact { { "age", "19" } };
            //����
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_NotEqualsOneOfArray()
        {
            //�������
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
            //��ӹ�������
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //������ʵ
            var fact = new Fact { { "age", "what" } };
            //����
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_RegexTrue()
        {
            //�������
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
            //��ӹ�������
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //������ʵ
            var fact = new Fact { { "age", "18" } };
            //����
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_OneItem_RegexFalse()
        {
            //�������
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
            //��ӹ�������
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //������ʵ
            var fact = new Fact { { "age", "what" } };
            //����
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        #endregion

        #region MoreItemTestCase

        [TestMethod]
        public void Rule_MoreItem()
        {
            //�������
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
            //��ӹ�������
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //������ʵ
            var fact = new Fact {{"age", "14"}, {"sex", "man"}};
            //����
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Rule_MoreItem_ComputeResult()
        {
            //�������
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
            //��ӹ�������
            RuleEngine.Clear();
            RuleEngine.AddRule(rule);
            //������ʵ
            var fact = new Fact { { "age", "14" }, { "sex", "man" } };
            //����
            var res = RuleEngine.Compute(fact);

            Assert.IsTrue(res);
        }

        #endregion
    }
}
