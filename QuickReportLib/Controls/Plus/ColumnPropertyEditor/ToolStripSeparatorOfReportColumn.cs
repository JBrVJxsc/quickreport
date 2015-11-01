using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting.ReportColumn
{
    internal partial class ToolStripSeparatorOfReportColumn : ToolStripSeparator, IHeaderSettingToolStripItem
    {
        public ToolStripSeparatorOfReportColumn()
        {
            InitializeComponent();
            Visible = false;
        }

        #region IHeaderSettingToolStripItem ≥…‘±

        public void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
            if (commandStatus != HeaderSettingCommandStatus.SelectReportColumn)
            {
                Visible = false;
            }
            else
            {
                Visible = true;
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
                return 330;
            }
        }

        #endregion
    }
}
