using System.Collections.Generic;
using System.Linq;
using NCR.Internal;

namespace NCR
{
    public interface IRuleEngine
    {
        bool Compute(Fact fact);
        void AddRule(Rule rule);
    }

    public class RuleEngine : IRuleEngine
    {
        /// <summary>
        /// 规则运算
        /// </summary>
        private readonly IRuleCompute _ruleCompute;
        /// <summary>
        /// 规则集合
        /// </summary>
        private readonly IRuleRespository _ruleRespository;

        public RuleEngine(IRuleCompute ruleCompute, IRuleRespository ruleRespository)
        {
            _ruleCompute = ruleCompute;
            _ruleRespository = ruleRespository;
        }
        public bool Compute(Fact fact)
        {
            return _ruleCompute.Compute(_ruleRespository.GetRules(), fact);
        }

        public void AddRule(Rule rule)
        {
            _ruleRespository.Add(rule);
        }

    }
}
