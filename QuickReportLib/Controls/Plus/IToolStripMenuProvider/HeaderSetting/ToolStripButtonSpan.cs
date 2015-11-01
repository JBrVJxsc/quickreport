using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using FarPoint.Win.Spread;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting
{
    internal partial class ToolStripButtonSpan : ToolStripButtonPlus ,IHeaderSettingToolStripItem
    {
        public ToolStripButtonSpan()
        {
            InitializeComponent();
        }

        private FpSpreadForHeaderSetting fpSpreadForHeaderSetting;

        protected override void OnClick(EventArgs e)
        {
            if (Checked == true)
            {
                int row = fpSpreadForHeaderSetting.CellRange.Row;
                int column = fpSpreadForHeaderSetting.CellRange.Column;
                Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[row, column];
                cell.RowSpan = 1;
                cell.ColumnSpan = 1;
                Checked = false;
                fpSpreadForHeaderSetting.ManualChange(HeaderSettingFpSpreadChangedType.SpanChanged);
            }
            else
            {
                int row = fpSpreadForHeaderSetting.CellRange.Row;
                int column = fpSpreadForHeaderSetting.CellRange.Column;
                int rowCount = fpSpreadForHeaderSetting.CellRange.RowCount;
                int columnCount = fpSpreadForHeaderSetting.CellRange.ColumnCount;
                fpSpreadForHeaderSetting.SheetMain.AddSpanCell(row, column, rowCount, columnCount);
                Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[row, column];
                if (cell.RowSpan > 1 || cell.ColumnSpan > 1)
                {
                    Checked = true;
                    fpSpreadForHeaderSetting.ManualChange(HeaderSettingFpSpreadChangedType.SpanChanged);
                }
                else
                {
                    Checked = false;
                }
            }
            base.OnClick(e);
        }

        #region IHeaderSettingToolStripItem ³ÉÔ±

        public void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
            if (commandStatus == HeaderSettingCommandStatus.SelectCell)
            {
                Visible = true;
                Enabled = true;
                int row = fpSpreadForHeaderSetting.CellRange.Row;
                int column = fpSpreadForHeaderSetting.CellRange.Column;
                Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[row, column];
                if (cell.RowSpan > 1 || cell.ColumnSpan > 1)
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
                Visible = true;
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

        public int SortID
        {
            get
            {
                return 180;
            }
        }

        #endregion
    }
}
