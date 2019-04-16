using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace NCR.Internal
{
    public  class RuleComputeBase : RuleCompute
    {
        protected override bool ComputeInternal(RuleItem ruleItem, Fact fact)
        {
            #region 参数校验
            if (null == ruleItem)
            {
                throw new ArgumentNullException(nameof(ruleItem));
            }
            if (null == fact)
            {
                throw new ArgumentNullException(nameof(fact));
            }
            if (string.IsNullOrEmpty(ruleItem.ComputeType))
            {
                throw new ArgumentNullException(nameof(ruleItem.ComputeType));
            }
            if (string.IsNullOrEmpty(ruleItem.Value))
            {
                throw new ArgumentNullException(nameof(ruleItem.Value));
            }
            if (string.IsNullOrEmpty(fact.Value))
            {
                throw new ArgumentNullException(nameof(fact.Value));
            } 
            #endregion

            var ruleValue = ruleItem.Value.Trim().ToLower();
            var ruleComputeType = ruleItem.ComputeType;

            foreach (var factKey in fact.Keys)
            {
                var factName = factKey.Trim().ToLower();
                var factValue = fact[factName];

                if(factKey == ruleItem.RuleItemType)

                if (Enum.IsDefined(typeof(BaseComputeType), ruleComputeType))
                {
                    #region BaseCompute

                    var computeTypeEnum = (BaseComputeType)Enum.Parse(typeof(BaseComputeType), ruleComputeType);
                    switch (computeTypeEnum)
                    {
                        case BaseComputeType.LessThan:
                            return Convert.ToDecimal(factValue) < Convert.ToDecimal(ruleValue);
                        case BaseComputeType.MoreThan:
                            return Convert.ToDecimal(factValue) > Convert.ToDecimal(ruleValue);
                        case BaseComputeType.EqualsTo:
                            return factValue.Equals(ruleValue);
                        case BaseComputeType.NotEqualsTo:
                            return !factValue.Equals(ruleValue);
                        case BaseComputeType.Contains:
                            var valArr = ruleValue.Split(',');
                            return valArr.Any(factValue.Contains);
                        case BaseComputeType.NotContain:
                            valArr = ruleValue.Split(',');
                            return !valArr.Any(factValue.Contains);
                        case BaseComputeType.LessThanOrEquals:
                            return Convert.ToDecimal(factValue) <= Convert.ToDecimal(ruleValue);
                        case BaseComputeType.MoreThanOrEquals:
                            return Convert.ToDecimal(factValue) >= Convert.ToDecimal(ruleValue);
                        case BaseComputeType.All:
                            return true;
                        case BaseComputeType.EqualsOneOfArray:
                            valArr = ruleValue.Split(',');
                            return valArr.Any(factValue.Equals);
                        case BaseComputeType.NotEqualsOneOfArray:
                            valArr = ruleValue.Split(',');
                            return !valArr.Any(factValue.Equals);
                        case BaseComputeType.RegexTrue:
                            return Regex.IsMatch(factValue, ruleValue);
                        case BaseComputeType.RegexFalse:
                            return !Regex.IsMatch(factValue, ruleValue);
                    }

                    #endregion
                }
            }

            throw new ArgumentException($"{ruleComputeType} 找不到对应的运算方法。");
        }
    }
}
