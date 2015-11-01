using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting
{
    internal partial class ToolStripSeparatorOfSpan : ToolStripSeparator , IHeaderSettingToolStripItem
    {
        public ToolStripSeparatorOfSpan()
        {
            InitializeComponent();
        }

        #region IHeaderSettingToolStripItem ≥…‘±

        public void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
            if (commandStatus == HeaderSettingCommandStatus.SelectCell)
            {
                Visible = true;
                Enabled = true;
            }
            else
            {
                Visible = true;
                Enabled = false;
            }
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
                return 170;
            }
        }

        #endregion
    }
}
