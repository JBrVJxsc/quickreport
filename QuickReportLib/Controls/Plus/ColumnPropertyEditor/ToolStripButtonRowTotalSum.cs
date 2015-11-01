using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting.ReportColumn
{
    internal partial class ToolStripButtonRowTotalSum : ToolStripButtonPlus, IHeaderSettingToolStripItem
    {
        public ToolStripButtonRowTotalSum()
        {
            InitializeComponent();
            Visible = false;
        }

        private FpSpreadForHeaderSetting fpSpreadForHeaderSetting;

        protected override void OnClick(EventArgs e)
        {
            if (Checked)
            {
                fpSpreadForHeaderSetting.ReportColumnSelected.RowTotalSum = false;
                Checked = false;
            }
            else
            {
                fpSpreadForHeaderSetting.ReportColumnSelected.RowTotalSum = true;
                Checked = true;
            }
            fpSpreadForHeaderSetting.ManualChange(HeaderSettingFpSpreadChangedType.ColumnTotalSumChanged);
            base.OnClick(e);
        }

        #region IHeaderSettingToolStripItem ≥…‘±

        public void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
            if (commandStatus == HeaderSettingCommandStatus.SelectReportColumn)
            {
                Visible = true;
                if (fpSpreadForHeaderSetting.ReportColumnSelected != null && fpSpreadForHeaderSetting.ReportColumnSelected.IsNumber)
                {
                    Enabled = true;

                    if (fpSpreadForHeaderSetting.ReportColumnSelected.RowTotalSum)
                    {
                        Checked = true;
                    }
                    else
                    {
                        Checked = false;
                    }
                }
                else
                {
                    Enabled = false;
                    Checked = false;
                }
            }
            else
            {
                Visible = false;
            }
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
            }
        }

        public int SortID
        {
            get
            {
                return 380;
            }
        }

        #endregion
    }
}
