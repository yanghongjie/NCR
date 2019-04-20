using System;
using System.Collections.Generic;
using System.Text;
using NCR.Models;

namespace NCR
{
    /// <summary>
    /// 规则
    /// </summary>
    public class Rule
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Rule()
        {
            Enabled = true;
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
            Items = new List<RuleItem>();
        }
        /// <summary>
        /// 规则项编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 规则名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 规则类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 优先级(越大越高),默认值为0
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// 规则描述
        /// </summary>
        public string Desciption { get; set; }
        /// <summary>
        /// 规则项
        /// </summary>
        public List<RuleItem> Items { get; set; }
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
