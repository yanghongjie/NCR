using System.ComponentModel;

namespace NCR
{
    /// <summary>
    /// 运算类型
    /// </summary>
    public enum BaseComputeType
    {
        /// <summary>
        /// 小于
        /// </summary>
        [Description("小于")]
        LessThan = 1,
        /// <summary>
        /// 大于
        /// </summary>
        [Description("大于")]
        MoreThan = 2,
        /// <summary>
        /// 等于
        /// </summary>
        [Description("等于")]
        EqualsTo = 3,
        /// <summary>
        /// 不等于操作
        /// </summary>
        [Description("不等于操作")]
        NotEqualsTo = 4,
        /// <summary>
        /// 包含
        /// </summary>
        [Description("包含")]
        Contains = 5,
        /// <summary>
        /// 不包含
        /// </summary>
        [Description("不包含")]
        NotContain = 6,
        /// <summary>
        /// 小于或等于
        /// </summary>
        [Description("小于或等于")]
        LessThanOrEquals = 7,
        /// <summary>
        /// 大于或等于
        /// </summary>
        [Description("大于或等于")]
        MoreThanOrEquals = 8,
        /// <summary>
        /// 任何值
        /// </summary>
        [Description("任何值")]
        All = 9,
        /// <summary>
        /// 等于数组中任意一值
        /// </summary>
        [Description("等于数组中任意一值")]
        EqualsOneOfArray = 10,
        /// <summary>
        /// 不等于数组中任意一值
        /// </summary>
        [Description("不等于数组中任意一值")]
        NotEqualsOneOfArray = 11,
        /// <summary>
        /// 正则达式成立
        /// </summary>
        [Description("正则达式成立")]
        RegexTrue = 12,
        /// <summary>
        /// 正则达式不成立
        /// </summary>
        [Description("正则达式不成立")]
        RegexFalse = 13
    }
}