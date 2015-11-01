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
    internal partial class ToolStripTextBoxBottomRowCount : ToolStripTextBoxPlus, IHeaderSettingToolStripItem
    {
        public ToolStripTextBoxBottomRowCount()
        {
            InitializeComponent();
        }

        private FpSpreadForHeaderSetting fpSpreadForHeaderSetting;

        private void ToolStripTextBoxBottomRowCount_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fpSpreadForHeaderSetting.BottomRowCount = Convert.ToInt32(Text);
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
                Text = fpSpreadForHeaderSetting.BottomRowCount.ToString();
            }
        }

        public int SortID
        {
            get
            {
                return 30;
            }
        }

        #endregion
    }
}
