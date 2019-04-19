using System.Collections.Generic;

namespace NCR
{
    /// <summary>
    /// 规则仓储
    /// </summary>
    public interface IRuleRespository
    {
        /// <summary>
        /// 获取所有规则
        /// </summary>
        /// <returns>规则集合</returns>
        List<Rule> GetRules();
        /// <summary>
        /// 添加规则
        /// </summary>
        /// <param name="rule">规则对象</param>
        void Add(Rule rule);
        /// <summary>
        /// 重置所有规则
        /// </summary>
        void Clear();
    }
}