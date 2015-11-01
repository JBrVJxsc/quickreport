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
    internal partial class ToolStripTextBoxTopRowCount : ToolStripTextBoxPlus, IHeaderSettingToolStripItem
    {
        public ToolStripTextBoxTopRowCount()
        {
            InitializeComponent();
        }

        FpSpreadForHeaderSetting fpSpreadForHeaderSetting;

        private void ToolStripTextBoxTopRowCount_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                fpSpreadForHeaderSetting.TopRowCount = Convert.ToInt32(Text);
            }
        }

        #region IHeaderSettingToolStripItem ≥…‘±

        public void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
             
        }

        public FpSpreadForHeaderSetting FpSpread
        {
            get
            {
                return fpSpreadForHeaderSetting;
            }
            set
            {
                fpSpreadForHeaderSetting = value;
                Text = fpSpreadForHeaderSetting.TopRowCount.ToString();
            }
        }

        public int SortID
        {
            get
            {
                return 50;
            }
        }

        #endregion
    }
}
