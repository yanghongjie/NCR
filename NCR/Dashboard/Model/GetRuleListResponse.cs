using System.Collections.Generic;
using NCR.Models;

namespace NCR.Dashboard.Model
{
    public class GetRuleListResponse : BaseResponse
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalCount { get; set; }
    }
}