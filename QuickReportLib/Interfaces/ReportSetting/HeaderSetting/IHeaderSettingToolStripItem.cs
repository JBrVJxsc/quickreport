using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Controls;
using QuickReportLib.Enums;

namespace QuickReportLib.Interfaces.ReportSetting.HeaderSetting
{
    /// <summary>
    /// 报表表头设计器的工具成员需实现此接口。
    /// </summary>
    internal interface IHeaderSettingToolStripItem
    {
        /// <summary>
        /// 设置命令状态。
        /// </summary>
        /// <param name="commandStatus">命令状态。</param>
        void SetCommandStatus(HeaderSettingCommandStatus commandStatus);

        /// <summary>
        /// 获取和设置FpSpread。
        /// </summary>
        FpSpreadForHeaderSetting FpSpread
        {
            get;
            set;
        }

        /// <summary>
        /// 序号。
        /// </summary>
        int SortID
        {
            get;
        }
    }
}
