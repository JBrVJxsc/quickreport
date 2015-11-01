using System;
using System.Collections.Generic;
using System.Text;
using FarPoint.Win.Spread;

namespace QuickReportLib.Interfaces.ReportSetting.HeaderSetting
{
    internal interface IVerticalAlignmentToolStripItem : IHeaderSettingToolStripItem
    {
        /// <summary>
        /// 纵向对齐方式。
        /// </summary>
        CellVerticalAlignment VerticalAlignment
        {
            get;
            set;
        }
    }
}
