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
    internal partial class ToolStripTextBoxColumnCount : ToolStripTextBoxPlus, IHeaderSettingToolStripItem
    {
        public ToolStripTextBoxColumnCount()
        {
            InitializeComponent();
        }

        private FpSpreadForHeaderSetting fpSpreadForHeaderSetting;

        private void ToolStripTextBoxColumnCount_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fpSpreadForHeaderSetting.ColumnCount =Convert.ToInt32(Text);
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
                fpSpreadForHeaderSetting.HeaderSettingFpSpreadChanged += new HeaderSettingFpSpreadChangedHandle(fpSpreadForHeaderSetting_HeaderSettingFpSpreadChanged);
                Text = fpSpreadForHeaderSetting.ColumnCount.ToString();
            }
        }

        void fpSpreadForHeaderSetting_HeaderSettingFpSpreadChanged(object sender, HeaderSettingFpSpreadChangedType changedType)
        {
            if (changedType == HeaderSettingFpSpreadChangedType.ColumnCountChanged)
            {
                Text = fpSpreadForHeaderSetting.ColumnCount.ToString();
            }
        }

        public int SortID
        {
            get
            {
                return 10;
            }
        }

        #endregion
    }
}
