using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Objects;
using QuickReportLib.Controls;

namespace QuickReportLib.Interfaces.ReportSetting.HeaderSetting
{
    /// <summary>
    /// 用于报表列的设置的ToolStripItem需实现此接口。
    /// </summary>
    internal interface IReportColumnSettingToolStripItem
    {
        /// <summary>
        /// FpSpread发生改变时触发的事件。
        /// </summary>
        event HeaderSettingFpSpreadChangedHandle HeaderSettingFpSpreadChanged;

        /// <summary>
        /// 获取和设置Column。
        /// </summary>
        Column Column
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

        /// <summary>
        /// 是否可见。
        /// </summary>
        bool IsVisible
        {
            get;
            set;
        }
    }
}
