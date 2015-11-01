using System;

namespace QuickReportLib.Enums
{
    /// <summary>
    /// 报表样式向引擎发出翻译请求的种类。
    /// </summary>
    internal enum ReportStyleAskForTranslationType
    {
        /// <summary>
        /// 系统。
        /// </summary>
        System,
        /// <summary>
        /// 条件。
        /// </summary>
        Condition,
        /// <summary>
        /// 树。
        /// </summary>
        Tree
    }
}
