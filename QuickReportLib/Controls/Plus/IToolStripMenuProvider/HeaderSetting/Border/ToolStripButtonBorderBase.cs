using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Enums;

namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting.Border
{
    internal partial class ToolStripButtonBorderBase : ToolStripButtonPlus
    {
        public ToolStripButtonBorderBase()
        {
            InitializeComponent();
        }

        protected FpSpreadForHeaderSetting fpSpreadForHeaderSetting;

        public virtual void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
            if (commandStatus == HeaderSettingCommandStatus.SelectCell)
            {
                Enabled = true;
            }
            else 
            {
                Enabled = false;
                Checked = false;
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

        protected override void OnClick(EventArgs e)
        {
            fpSpreadForHeaderSetting.ManualChange(HeaderSettingFpSpreadChangedType.BorderChanged);
            fpSpreadForHeaderSetting.ManualHeaderSettingCommandStatusChanged();
            base.OnClick(e);
        }

        public virtual int SortID
        {
            get
            {
                return 0;
            }
        }
    }
}
