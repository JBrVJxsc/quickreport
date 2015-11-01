using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting.ReportColumn
{
    internal partial class ToolStripButtonMerge : ToolStripButtonPlus, IHeaderSettingToolStripItem
    {
        public ToolStripButtonMerge()
        {
            InitializeComponent();
            Visible = false;
        }

        private FpSpreadForHeaderSetting fpSpreadForHeaderSetting;

        protected override void OnClick(EventArgs e)
        {
            if (Checked)
            {
                fpSpreadForHeaderSetting.ReportColumnSelected.Merge = false;
                Checked = false;
            }
            else
            {
                fpSpreadForHeaderSetting.ReportColumnSelected.Merge = true;
                Checked = true;
            }
            fpSpreadForHeaderSetting.ManualChange(HeaderSettingFpSpreadChangedType.MergeChanged);
            base.OnClick(e);
        }

        #region IHeaderSettingToolStripItem ≥…‘±

        public void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
            if (commandStatus == HeaderSettingCommandStatus.SelectReportColumn)
            {
                Visible = true;
                if (fpSpreadForHeaderSetting.ReportColumnSelected != null)
                {
                    Enabled = true;

                    if (fpSpreadForHeaderSetting.ReportColumnSelected.Merge)
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
                return 360;
            }
        }

        #endregion
    }
}
