using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting.VAlignment
{
    internal partial class ToolStripSeparatorOfVAlignment : ToolStripSeparator, IHeaderSettingToolStripItem
    {
        public ToolStripSeparatorOfVAlignment()
        {
            InitializeComponent();
        }

        #region IHeaderSettingToolStripItem ≥…‘±

        public void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {

        }

        public FpSpreadForHeaderSetting FpSpread
        {
            get
            {
                return null;
            }
            set
            {

            }
        }

        public int SortID
        {
            get
            {
                return 130;
            }
        }

        #endregion
    }
}
