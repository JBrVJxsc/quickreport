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
    internal partial class ToolStripButtonSort : ToolStripButtonPlus, IReportColumnSettingToolStripItem
    {
        public ToolStripButtonSort()
        {
            InitializeComponent();
        }

        private Column column;
        private bool isVisible = true;

        protected override void OnClick(EventArgs e)
        {
            if (Checked)
            {
                Column.Sort = false;
                Checked = false;
            }
            else
            {
                Column.Sort = true;
                Checked = true;
            }
            if (HeaderSettingFpSpreadChanged != null)
            {
                HeaderSettingFpSpreadChanged(this, HeaderSettingFpSpreadChangedType.ReportColumnSortChanged);
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
                if (column.Sort)
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
                return 0;
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
