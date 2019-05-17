using System.Threading.Tasks;

namespace NCR.Models
{
    /// <summary>
    /// 规则引擎
    /// </summary>
    public class RuleEngine : IRuleEngine
    {
        /// <summary>
        /// 规则运算
        /// </summary>
        private readonly IRuleCompute _ruleCompute;
        /// <summary>
        /// 规则集合
        /// </summary>
        private readonly IRuleRepository _ruleRepository;

        public RuleEngine(IRuleCompute ruleCompute, IRuleRepository ruleRepository)
        {
            _ruleCompute = ruleCompute;
            _ruleRepository = ruleRepository;
        }

        public async Task<ComputeResult> Compute(Fact fact)
        {
            var rules = await _ruleRepository.GetRules();
            return _ruleCompute.Compute(rules, fact);
        }

        public async Task AddRule(Rule rule)
        {
            await _ruleRepository.AddRule(rule);
        }
        public async Task Clear()
        {
            await _ruleRepository.Clear();
        }
    }
}
