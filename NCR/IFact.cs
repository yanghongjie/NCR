using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NCR
{
    /// <summary>
    /// 事实接口定义
    /// </summary>
    public interface IFact
    {
        /// <summary>
        /// 事实名称
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 事实值
        /// </summary>
        string Value { get; set; }
    }
}
