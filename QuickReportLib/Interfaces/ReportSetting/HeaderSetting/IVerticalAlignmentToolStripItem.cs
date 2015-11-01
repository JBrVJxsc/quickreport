using System;
using System.Collections.Generic;
using System.Text;
using FarPoint.Win.Spread;

namespace QuickReportLib.Interfaces.ReportSetting.HeaderSetting
{
    internal interface IVerticalAlignmentToolStripItem : IHeaderSettingToolStripItem
    {
        /// <summary>
        /// ������뷽ʽ��
        /// </summary>
        CellVerticalAlignment VerticalAlignment
        {
            get;
            set;
        }
    }
}
