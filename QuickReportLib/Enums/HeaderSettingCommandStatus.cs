using System;

namespace QuickReportLib.Enums
{
    /// <summary>
    /// 表头设置时的命令状态。
    /// </summary>
    internal enum HeaderSettingCommandStatus
    {
        /// <summary>
        /// 选中列。
        /// </summary>
        SelectColumn,
        /// <summary>
        /// 选中行。
        /// </summary>
        SelectRow,
        /// <summary>
        /// 选中Cell。
        /// </summary>
        SelectCell,
        /// <summary>
        /// 选中报表列。
        /// </summary>
        SelectReportColumn,
        /// <summary>
        /// 无状态。
        /// </summary>
        Null
    }
}
