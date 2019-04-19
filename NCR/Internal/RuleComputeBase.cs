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
            #endregion

            var ruleValue = ruleItem.Value.Trim().ToLower();
            var computeType = (BaseComputeType)Enum.Parse(typeof(BaseComputeType), ruleItem.ComputeType);

            foreach (var factKey in fact.Keys)
            {
                var factName = factKey.Trim().ToLower();
                var factValue = fact[factName].Trim().ToLower();

                if (factKey != ruleItem.RuleItemType) continue;

                return BaseCompute(computeType, ruleValue, factValue);
            }

            return false;
        }

        protected bool BaseCompute(BaseComputeType computeType,string ruleValue,string factValue)
        {
            switch (computeType)
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
                    return ruleValue.Contains(factValue);
                case BaseComputeType.NotContain:
                    return !ruleValue.Contains(factValue);
                case BaseComputeType.LessThanOrEquals:
                    return Convert.ToDecimal(factValue) <= Convert.ToDecimal(ruleValue);
                case BaseComputeType.MoreThanOrEquals:
                    return Convert.ToDecimal(factValue) >= Convert.ToDecimal(ruleValue);
                case BaseComputeType.All:
                    return true;
                case BaseComputeType.EqualsOneOfArray:
                    return ruleValue.Split(',').Any(factValue.Equals);
                case BaseComputeType.NotEqualsOneOfArray:
                    return !ruleValue.Split(',').Any(factValue.Equals);
                case BaseComputeType.RegexTrue:
                    return Regex.IsMatch(factValue, ruleValue);
                case BaseComputeType.RegexFalse:
                    return !Regex.IsMatch(factValue, ruleValue);
                default:
                    throw new ArgumentOutOfRangeException(nameof(computeType), computeType, $"{computeType} 找不到对应的运算方法。");
            }
        }
    }
}
