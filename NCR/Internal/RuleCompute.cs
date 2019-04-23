using NCR.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NCR.Enums;
using NCR.Extensions;
using NCR.Models;

namespace NCR.Internal
{
    public abstract class RuleCompute : IRuleCompute
    {
        public ComputeResult Compute(List<Rule> rules, Fact fact)
        {
            var result = new ComputeResult();
            foreach (var rule in rules.OrderByDescending(x => x.Priority))
            {
                result = Compute(rule, fact);
                if (!result.Success) continue;
                result.HitRule = rule;
                break;
            }
            return result;
        }

        private ComputeResult Compute(Rule rule, Fact fact)
        {
            var result = new ComputeResult();
            try
            {
                #region 参数校验
                if (rule.IsNull())
                {
                    throw new ArgumentNullException(nameof(rule));
                }
                if (rule.Name.IsNullOrEmpty())
                {
                    throw new ArgumentNullException(nameof(rule.Name));
                }
                if (fact.IsNull())
                {
                    throw new ArgumentNullException(nameof(fact));
                }
                if (!rule.Enabled)
                {
                    throw new AggregateException($"Rule.Name:{rule.Name} 未启用");
                }
                #endregion

                if (!rule.Items.Any())
                    return result;

                var trueCount = 0;
                foreach (var item in rule.Items.Where(x => x.Enabled))
                {
                    if (Compute(item, fact))
                    {
                        trueCount++;
                    }
                    else
                    {
                        result.Infos.Add(new ComputeResultInfo
                        {
                            MissRuleItemType = item.RuleItemType,
                            ComputeMessage = $"RuleValue:{item.Value} FactValue:{fact.GetValueOrDefault(item.RuleItemType) ?? "Null"}"
                        });
                        break;
                    }
                }

                result.Success = rule.Items.Count == trueCount;
            }
            catch (Exception ex)
            {
                throw new RuleComputeException($"规则运算出错:{ex.Message}", ex);
            }

            return result;
        }

        private bool Compute(RuleItem ruleItem, Fact fact)
        {
            #region 参数校验
            if (ruleItem.IsNull())
            {
                throw new ArgumentNullException(nameof(ruleItem));
            }
            if (fact.IsNull())
            {
                throw new ArgumentNullException(nameof(fact));
            }
            if (ruleItem.ComputeType.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(ruleItem.ComputeType));
            }
            if (ruleItem.Value.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(ruleItem.Value));
            }
            #endregion

            try
            {
                var ruleValue = ruleItem.Value.Trim().ToLower();

                foreach (var factKey in fact.Keys)
                {
                    var factName = factKey.Trim().ToLower();
                    var factValue = fact[factName].Trim().ToLower();

                    if (factKey != ruleItem.RuleItemType) continue;

                    //是否为基础运算类型
                    var isBaseComputeType = Enum.IsDefined(typeof(BaseComputeType), ruleItem.ComputeType);

                    return isBaseComputeType
                        ? BaseCompute(ruleItem.ComputeType, ruleValue, factValue)
                        : CustomCompute(ruleItem.ComputeType, ruleValue, factValue);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new RuleComputeException($"规则运算出错:{ex.Message}", ex);
            }
        }

        private bool BaseCompute(string computeTypeString, string ruleValue, string factValue)
        {
            var computeType = (BaseComputeType)Enum.Parse(typeof(BaseComputeType), computeTypeString);
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
                case BaseComputeType.Any:
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

        protected abstract bool CustomCompute(string computeType, string ruleValue, string factValue);
    }
}
