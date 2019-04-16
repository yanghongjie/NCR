using System;
using System.Collections.Generic;
using System.Linq;

namespace NCR.Internal
{
    public class RuleRespositoryInMemory : IRuleRespository
    {
        private static readonly List<Rule> Rules = new List<Rule>();
        public List<Rule> GetRules()
        {
            return Rules;
        }

        public void Add(Rule rule)
        {
            if (Rules.Any(x => x.Name.Equals(rule.Name)))
                throw new ArgumentException($"规则名称 {rule.Name} 已经存在。");
            Rules.Add(rule);
        }
    }
}