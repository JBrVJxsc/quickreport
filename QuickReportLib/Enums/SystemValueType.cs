using System;

namespace QuickReportLib.Enums
{
    /// <summary>
    /// 系统变量类型。每种类型对应工具栏中日期、日期时间、人员、科室中的一个图标。
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
        /// 人员。
        /// </summary>
        Person,
        /// <summary>
        /// 科室。
        /// </summary>
        Department
    }
}
