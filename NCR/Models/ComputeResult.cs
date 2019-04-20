using System.Collections.Generic;
using NCR.Internal;

namespace NCR.Models
{
    /// <summary>
    /// 运算结果
    /// </summary>
    public class ComputeResult
    {
        public ComputeResult()
        {
            Infos = new List<ComputeResultInfo>();
        }
        /// <summary>
        /// 是否所有规则都命中
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 命中的规则
        /// </summary>
        public Rule HitRule { get; set; }
        /// <summary>
        /// 命中的事实
        /// </summary>
        public Fact HitFact { get; set; }
        /// <summary>
        /// 运算结果
        /// </summary>
        public List<ComputeResultInfo> Infos { get; set; }
    }

    public class ComputeResultInfo
    {
        /// <summary>
        /// 未命中的规则项
        /// </summary>
        public string MissRuleItemType { get; set; }
        /// <summary>
        /// 运算信息
        /// </summary>
        public string ComputeMessage { get; set; }
    }
}