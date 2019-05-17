using System.Threading.Tasks;
using NCR.Models;

namespace NCR
{
    /// <summary>
    /// 规则引擎
    /// </summary>
    public interface IRuleEngine
    {
        /// <summary>
        /// 运算
        /// </summary>
        /// <param name="fact">事实</param>
        /// <returns>运算结果</returns>
        Task<ComputeResult> Compute(Fact fact);
        /// <summary>
        /// 添加规则
        /// </summary>
        /// <param name="rule">规则</param>
        Task AddRule(Rule rule);
        /// <summary>
        /// 重置所有规则
        /// </summary>
        Task Clear();
    }
}