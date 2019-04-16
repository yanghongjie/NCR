using NCR.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NCR.Internal
{
    public abstract class RuleCompute : IRuleCompute
    {
        protected bool Compute(Rule rule, Fact fact)
        {
            try
            {
                #region 参数校验
                if (null == rule)
                {
                    throw new ArgumentNullException(nameof(rule));
                }
                if (string.IsNullOrEmpty(rule.Name))
                {
                    throw new ArgumentNullException(nameof(rule.Name));
                }
                if (null == fact)
                {
                    throw new ArgumentNullException(nameof(fact));
                }
                if (!rule.Enabled)
                {
                    throw new AggregateException($"Rule.Name:{rule.Name} 未启用");
                } 
                #endregion

                if (!rule.Items.Any())
                    return true;

                var trueCount = 0;
                foreach (var item in rule.Items.Where(x => x.Enabled))
                {
                    if (ComputeInternal(item, fact))
                    {
                        trueCount++;
                    }
                    else
                    {
                        break;
                    }
                }

                return rule.Items.Count == trueCount;
            }
            catch (Exception ex)
            {
                throw new RuleComputeException($"规则运算出错:{ex.Message}", ex);
            }
        }

        public bool Compute(List<Rule> rules, Fact fact)
        {
            return rules.OrderByDescending(x => x.Priority).Any(rule => Compute(rule, fact));
        }

        protected abstract bool ComputeInternal(RuleItem ruleItem, Fact fact);
    }
}
