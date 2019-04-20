using NCR.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using NCR.Extensions;
using NCR.Models;

namespace NCR.Internal
{
    public abstract class RuleCompute : IRuleCompute
    {
        protected ComputeResult Compute(Rule rule, Fact fact)
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
                    if (ComputeInternal(item, fact))
                    {
                        trueCount++;
                    }
                    else
                    {
                        result.Infos.Add(new ComputeResultInfo
                        {
                            MissRuleItemType = item.RuleItemType,
                            ComputeMessage = $"RuleValue:{item.Value} FactValue:{fact.GetValueOrDefault(item.RuleItemType)??"Null"}"
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

        protected abstract bool ComputeInternal(RuleItem ruleItem, Fact fact);
    }
}
