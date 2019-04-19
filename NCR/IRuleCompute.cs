using System;
using System.Collections.Generic;
using System.Text;
using NCR.Internal;
using NCR.Models;

namespace NCR
{
    /// <summary>
    /// 规则运算接口
    /// </summary>
    public interface IRuleCompute
    {
        /// <summary>
        /// 运算
        /// </summary>
        /// <param name="rules">规则集合</param>
        /// <param name="fact">事实</param>
        /// <returns>是否命中</returns>
        ComputeResult Compute(List<Rule> rules, Fact fact);
    }
}
