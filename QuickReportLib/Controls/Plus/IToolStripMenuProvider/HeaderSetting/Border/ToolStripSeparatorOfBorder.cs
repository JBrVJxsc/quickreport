using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting.Border
{
    internal partial class ToolStripSeparatorOfBorder : ToolStripSeparator , IHeaderSettingToolStripItem
    {
        public ToolStripSeparatorOfBorder()
        {
            InitializeComponent();
        }

        #region IHeaderSettingToolStripItem ≥…‘±

        public void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
            if (commandStatus == HeaderSettingCommandStatus.SelectCell)
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
                return 210;
            }
        }

        #endregion
    }
}
