﻿using System;
using System.Collections.Generic;
using System.Text;

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
            Id = Guid.NewGuid();
            Items = new List<RuleItem>();
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }
        /// <summary>
        /// 规则项编号
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 规则名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 规则类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 优先级
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