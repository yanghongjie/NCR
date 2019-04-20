using System;
using System.Collections.Generic;
using System.Linq;
using NCR.Extensions;

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
            if (rule.Name.IsNullOrEmpty())
                throw new ArgumentException($"规则名称 {rule.Name} 不能为空。");
            //if (rule.Type.IsNullOrEmpty())
            //    throw new ArgumentException($"规则类型 {rule.Type} 不能为空。");
            if (Rules.Any(x => x.Name.Equals(rule.Name)))
                throw new ArgumentException($"规则名称 {rule.Name} 已经存在。");
            //模拟自增
            rule.Id = Rules.Any() ? Rules.Max(x => x.Id) + 1 : 1;
            Rules.Add(rule);
        }

        public void Clear()
        {
            Rules.Clear();
        }
    }
}