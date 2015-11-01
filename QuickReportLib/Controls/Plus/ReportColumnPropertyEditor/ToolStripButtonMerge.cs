using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.Objects;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.ReportColumnPropertyEditor
{
    internal partial class ToolStripButtonMerge : ToolStripButtonPlus, IReportColumnSettingToolStripItem
    {
        public ToolStripButtonMerge()
        {
            InitializeComponent();
        }

        private Column column;
        private bool isVisible = true;

        protected override void OnClick(EventArgs e)
        {
            if (Checked)
            {
                Column.Merge = false;
                Checked = false;
            }
            else
            {
                Column.Merge = true;
                Checked = true;
            }
            if (HeaderSettingFpSpreadChanged != null)
            {
                HeaderSettingFpSpreadChanged(this, HeaderSettingFpSpreadChangedType.ReportColumnMergeChanged);
            }
            base.OnClick(e);
        }

        #region IReportColumnSettingToolStripItem ≥…‘±

        public event HeaderSettingFpSpreadChangedHandle HeaderSettingFpSpreadChanged;

        public Column Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
                if (column.Merge)
                {
                    Checked = true;
                }
                else
                {
                    Checked = false;
                }
            }
        }

        public int SortID
        {
            get
            {
                return 20;
            }
        }

        public bool IsVisible
        {
            get
            {
                return isVisible;
            }
            set
            {
                isVisible = value;
            }
        }

        #endregion
    }
}
