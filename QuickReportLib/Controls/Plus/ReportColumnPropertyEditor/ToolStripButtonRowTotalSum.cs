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
    internal partial class ToolStripButtonRowTotalSum : ToolStripButtonPlus, IReportColumnSettingToolStripItem
    {
        public ToolStripButtonRowTotalSum()
        {
            InitializeComponent();
        }

        private Column column;
        private bool isVisible = true;

        protected override void OnClick(EventArgs e)
        {
            if (Checked)
            {
                Column.RowTotalSum = false;
                Checked = false;
            }
            else
            {
                Column.RowTotalSum = true;
                Checked = true;
            }
            if (HeaderSettingFpSpreadChanged != null)
            {
                HeaderSettingFpSpreadChanged(this, HeaderSettingFpSpreadChangedType.ReportColumnRowTotalSumChanged);
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
                if (column.IsNumber)
                {
                    Visible = true;
                    isVisible = true;
                    if (column.RowTotalSum)
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
                    Visible = false;
                    isVisible = false;
                }
            }
        }

        public int SortID
        {
            get
            {
                return 170;
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
