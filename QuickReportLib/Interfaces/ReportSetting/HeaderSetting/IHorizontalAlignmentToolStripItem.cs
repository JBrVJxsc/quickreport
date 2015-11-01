using System;
using System.Collections.Generic;
using System.Text;
using FarPoint.Win.Spread;

namespace QuickReportLib.Interfaces.ReportSetting.HeaderSetting
{
    internal interface IHorizontalAlignmentToolStripItem : IHeaderSettingToolStripItem
    {
        /// <summary>
        /// 横向对齐方式。
        /// </summary>
        CellHorizontalAlignment HorizontalAlignment
        {
            get;
            set;
        }
    }
}
