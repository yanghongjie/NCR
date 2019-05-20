namespace NCR.Dashboard.Model
{
    public class SaveRuleItemRequest
    {
        /// <summary>
        /// 规则项编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 规则编号
        /// </summary>
        public int RuleId { get; set; }
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
    }
}