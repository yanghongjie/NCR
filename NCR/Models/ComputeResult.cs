using System.Collections.Generic;

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
        /// 是否命中
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 命中的规则
        /// </summary>
        public Rule HitRule { get; set; }
        /// <summary>
        /// 运算结果
        /// </summary>
        public List<ComputeResultInfo> Infos { get; set; }
    }

    public class ComputeResultInfo
    {
        /// <summary>
        /// 规则项
        /// </summary>
        public string MissRuleItemType { get; set; }
        /// <summary>
        /// 运算信息
        /// </summary>
        public string ComputeMessage { get; set; }
    }
}