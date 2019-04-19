using System;
using System.Collections.Generic;
using System.Text;

namespace NCR
{
    /// <summary>
    /// 规则项
    /// </summary>
    public class RuleItem
    {
        public RuleItem()
        {
            Enabled = true;
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }
        /// <summary>
        /// 规则项编号
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 规则项类型
        /// </summary>
        public string RuleItemType { get; set; }
        /// <summary>
        /// 运算类型
        /// </summary>
        public string ComputeType { get; set; }
        /// <summary>
        /// 规则值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Desciption { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
