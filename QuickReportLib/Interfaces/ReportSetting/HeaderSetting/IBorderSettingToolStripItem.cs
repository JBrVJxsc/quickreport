using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;

namespace QuickReportLib.Interfaces.ReportSetting.HeaderSetting
{
    internal interface IBorderSettingToolStripItem : IHeaderSettingToolStripItem
    {
        /// <summary>
        /// Border÷÷¿‡°£
        /// </summary>
        HeaderSettingBorderType HeaderSettingBorderType
        {
            get;
            set;
        }
    }
}
