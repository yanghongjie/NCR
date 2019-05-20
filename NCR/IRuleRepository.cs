using System.Collections.Generic;
using System.Threading.Tasks;
using NCR.Dashboard.Model;
using NCR.Models;

namespace NCR
{
    /// <summary>
    /// 规则仓储
    /// </summary>
    public interface IRuleRepository
    {
        /// <summary>
        /// 获取所有规则
        /// </summary>
        /// <returns>规则集合</returns>
        Task<List<Rule>> GetRules();
        /// <summary>
        /// 获取所有规则
        /// </summary>
        /// <returns>规则集合</returns>
        Task<GetRuleListResponse> GetRules(GetRuleListRequest request);
        /// <summary>
        /// 保存规则
        /// </summary>
        /// <param name="rule">规则对象</param>
        Task SaveRule(Rule rule);
        /// <summary>
        /// 保存规则项目
        /// </summary>
        /// <param name="ruleItem">规则项对象</param>
        Task SaveRuleItem(RuleItem ruleItem);
        /// <summary>
        /// 重置所有规则
        /// </summary>
        Task Clear();
    }
}