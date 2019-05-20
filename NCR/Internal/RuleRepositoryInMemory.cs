using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NCR.Dashboard.Model;
using NCR.Extensions;
using NCR.Models;

namespace NCR.Internal
{
    public class RuleRepositoryInMemory : IRuleRepository
    {
        private static readonly List<Rule> Rules = new List<Rule>();
        private static readonly List<RuleItem> RuleItems = new List<RuleItem>();
        public async Task<List<Rule>> GetRules()
        {
            return await Task.FromResult(Rules);
        }
        public async Task<GetRuleListResponse> GetRules(GetRuleListRequest request)
        {
            var response = new GetRuleListResponse();
            var query = Rules.AsQueryable();
            if (request.RuleName.IsNotNullOrEmpty())
            {
                query = query.Where(x => x.Name.Contains(request.RuleName));
            }
            if (request.RuleType.IsNotNullOrEmpty())
            {
                query = query.Where(x => x.Type.Contains(request.RuleType));
            }
            if (request.RuleStatus != -1)
            {
                var enabled = request.RuleStatus == 1;
                query = query.Where(x => x.Enabled == enabled);
            }
            var totalCount = query.Count();
            var data = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize).ToList();
            response.TotalCount = totalCount;
            response.Data = await Task.FromResult(data);

            return response;
        }
        public async Task SaveRule(Rule rule)
        {
            if (rule.Name.IsNullOrEmpty())
                throw new ArgumentException($"规则名称 {rule.Name} 不能为空。");
            if (rule.Type.IsNullOrEmpty())
                throw new ArgumentException($"规则类型 {rule.Type} 不能为空。");

            if (rule.Id > 0)
            {
                var findRule = Rules.FirstOrDefault(x => x.Id == rule.Id);
                if (findRule == null)
                    throw new ArgumentException($"规则编号 {rule.Id} 无效。");
                findRule.Name = rule.Name;
                findRule.Type = rule.Type;
                findRule.Enabled = rule.Enabled;
                findRule.Priority = rule.Priority;
                findRule.Desciption = rule.Desciption;
                findRule.UpdateTime = DateTime.Now;
            }
            else
            {
                if (Rules.Any(x => x.Name.Equals(rule.Name)))
                    throw new ArgumentException($"规则名称 {rule.Name} 已经存在。");

                //模拟自增
                rule.Id = Rules.Any() ? Rules.Max(x => x.Id) + 1 : 1;
                rule.CreateTime = DateTime.Now;
                if (rule.Items.Any())
                {
                    foreach (var ruleItem in rule.Items)
                    {
                        ruleItem.RuleId = rule.Id;
                        RuleItems.Add(ruleItem);
                    }
                }
                Rules.Add(rule);
            }
        }
        public async Task SaveRuleItem(RuleItem ruleItem)
        {
            if (ruleItem.RuleId<=0)
                throw new ArgumentException($"规则编号 {ruleItem.RuleId} 不能为空。");
            if (ruleItem.RuleItemType.IsNullOrEmpty())
                throw new ArgumentException($"规则项类型 {ruleItem.RuleItemType} 不能为空。");
            if (ruleItem.ComputeType.IsNullOrEmpty())
                throw new ArgumentException($"运算类型 {ruleItem.ComputeType} 不能为空。");
            if (ruleItem.Value.IsNullOrEmpty())
                throw new ArgumentException($"规则值 {ruleItem.Value} 不能为空。");

            if (ruleItem.Id > 0)
            {
                var findRuleItem = RuleItems.FirstOrDefault(x => x.Id == ruleItem.Id);
                if (findRuleItem == null)
                    throw new ArgumentException($"规则项编号 {ruleItem.Id} 无效。");
                findRuleItem.RuleItemType = ruleItem.RuleItemType;
                findRuleItem.ComputeType = ruleItem.ComputeType;
                findRuleItem.Value = ruleItem.Value;
                findRuleItem.Enabled = ruleItem.Enabled;
                findRuleItem.Desciption = ruleItem.Desciption;
                findRuleItem.UpdateTime = DateTime.Now;
            }
            else
            {
                var rule = Rules.FirstOrDefault(x => x.Id == ruleItem.RuleId);
                if (rule == null)
                {
                    throw new ArgumentException($"规则编号 {ruleItem.RuleId} 无效。");
                }

                ruleItem.Id = RuleItems.Any() ? RuleItems.Max(x => x.Id) + 1 : 1;
                RuleItems.Add(ruleItem);
                rule.Items.Add(ruleItem);
            }
        }
        public async Task Clear()
        {
            Rules.Clear();
        }
    }
}