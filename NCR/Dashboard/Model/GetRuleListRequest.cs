namespace NCR.Dashboard.Model
{
    /// <summary>
    /// 获取规则请求
    /// </summary>
    public class GetRuleListRequest
    {
        public string RuleName { get; set; }
        public string RuleType { get; set; }
        public int RuleStatus { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}