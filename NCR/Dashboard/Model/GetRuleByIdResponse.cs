using System.Collections.Generic;
using NCR.Models;

namespace NCR.Dashboard.Model
{
    public class GetRuleByIdResponse : BaseResponse
    {
       
    }

    public class RuleInfo
    {
        /// <summary>
        /// 规则编号
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
        /// 是否启用,默认开启
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// 规则项
        /// </summary>
        public List<RuleItem> RuleItems { get; set; }
    }
}