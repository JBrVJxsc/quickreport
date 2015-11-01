using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Enums
{
    /// <summary>
    /// 条件的录入类型。
    /// </summary>
    internal enum ConditionInputType
    {
        /// <summary>
        /// 字符。
        /// </summary>
        Text,
        /// <summary>
        /// 数字（Int）。
        /// </summary>
        NumeralInt,
        /// <summary>
        /// 数字（Decimal）。
        /// </summary>
        NumeralDecimal,
        /// <summary>
        /// 日期。
        /// </summary>
        Date,
        /// <summary>
        /// 日期时间。
        /// </summary>
        DateTime,
        /// <summary>
        /// 下拉框。
        /// </summary>
        ComboBox
    }
}
