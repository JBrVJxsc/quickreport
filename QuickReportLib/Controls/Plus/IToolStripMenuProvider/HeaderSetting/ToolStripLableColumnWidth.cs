using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;
using QuickReportLib.Enums;


namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting
{
    internal partial class ToolStripLableColumnWidth : ToolStripLabel, IHeaderSettingToolStripItem
    {
        public ToolStripLableColumnWidth()
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
                return 300;
            }
        }

        #endregion
    }
}
