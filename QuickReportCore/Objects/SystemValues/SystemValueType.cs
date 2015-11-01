using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.SystemValues
{
    /// <summary>
    /// 系统变量类型。每种类型对应变量工具箱下的一个图标。
    /// </summary>
    public enum SystemValueType
    {
        /// <summary>
        /// 日期。
        /// </summary>
        Date,
        /// <summary>
        /// 日期时间。
        /// </summary>
        DateTime,
        /// <summary>
        /// 操作员。
        /// </summary>
        Oper,
        /// <summary>
        /// 科室。
        /// </summary>
        Dept
    }
}
