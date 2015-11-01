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
    internal partial class ToolStripSeparatorOfColumnWidth : ToolStripSeparator, IHeaderSettingToolStripItem
    {
        public ToolStripSeparatorOfColumnWidth()
        {
            InitializeComponent();
        }

        #region IHeaderSettingToolStripItem ≥…‘±

        public void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
            if (commandStatus == HeaderSettingCommandStatus.SelectColumn)
            {
                Enabled = true;
            }
            else
            {
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
                return 290;
            }
        }

        #endregion
    }
}
