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
    internal partial class ToolStripButtonColumnTotalSum : ToolStripButtonPlus, IReportColumnSettingToolStripItem
    {
        public ToolStripButtonColumnTotalSum()
        {
            InitializeComponent();
        }

        private Column column;
        private bool isVisible = true;

        protected override void OnClick(EventArgs e)
        {
            if (Checked)
            {
                Column.ColumnTotalSum = false;
                Checked = false;
            }
            else
            {
                Column.ColumnTotalSum = true;
                Checked = true;
            }
            if (HeaderSettingFpSpreadChanged != null)
            {
                HeaderSettingFpSpreadChanged(this, HeaderSettingFpSpreadChangedType.ReportColumnColumnTotalSumChanged);
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
                    if (column.ColumnTotalSum)
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
                return 160;
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
