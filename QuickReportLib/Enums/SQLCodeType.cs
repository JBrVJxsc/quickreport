using System;

namespace QuickReportLib.Enums
{
    /// <summary>
    /// SQL编码的类型。
    /// </summary>
    internal enum SQLCodeType
    {
        /// <summary>
        /// 树。
        /// </summary>
        Tree,
        /// <summary>
        /// 列。
        /// </summary>
        Column,
        /// <summary>
        /// 条件。
        /// </summary>
        Condition,
        /// <summary>
        /// 系统。
        /// </summary>
        System,
        /// <summary>
        /// 动态。例如行数、列数等在查询之后才有的值。
        /// </summary>
        Dynamic,
        /// <summary>
        /// 无类型。
        /// </summary>
        Null
    }
}
