using System;

namespace QuickReportLib.Enums
{
    /// <summary>
    /// NumberCellType的值自动转换方式。
    /// </summary>
    public enum ValueTranslateType
    {
        /// <summary>
        /// 值为空时转换为零。
        /// </summary>
        BeZeroWhenNull,
        /// <summary>
        /// 值为零时转换为空。
        /// </summary>
        BeNullWhenZero,
        /// <summary>
        /// 不转换。
        /// </summary>
        DoNothing
    }
}
