using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.Model;
using QuickReportLib.Enums;
using QuickReportLib.Objects.ReportSetting;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting
{
    internal partial class ToolStripButtonBevelLineDown : ToolStripButtonPlus , IHeaderSettingToolStripItem
    {
        public ToolStripButtonBevelLineDown()
        {
            InitializeComponent();
        }

        private FpSpreadForHeaderSetting fpSpreadForHeaderSetting;

        protected override void OnClick(EventArgs e)
        {
            fpSpreadForHeaderSetting.StopCellEditing();
            CellRange cellRange = fpSpreadForHeaderSetting.CellRange;
            int startCellRow = cellRange.Row;
            int startCellColumn = cellRange.Column;

            //对于一个单独选中的Span过的Cell，RowCount与ColumnCount都为1。这会导致斜线计算错误，所以需要添加偏移量进行校正。
            int offset = 0;
            if (cellRange.RowCount == 1)
            {
                Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow, startCellColumn];
                if (cell.RowSpan > 1)
                {
                    offset = cell.RowSpan - 1;
                }
            }
            int endCellRow = cellRange.Row + cellRange.RowCount-1+offset;

            offset = 0;
            if (cellRange.ColumnCount == 1)
            {
                Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow, startCellColumn];
                if (cell.ColumnSpan > 1)
                {
                    offset = cell.ColumnSpan - 1;
                }
            }
            int endCellColumn = cellRange.Column + cellRange.ColumnCount - 1+offset;

            Cell startCell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow, startCellColumn];
            if (Checked)
            {
                BevelLine bevelLineNeedDelete=null;
                List<BevelLine> bevelLineList = fpSpreadForHeaderSetting.GetBevelLines();
                foreach (BevelLine bevelLine in bevelLineList)
                {
                    if (bevelLine.StartCellRow == startCellRow && bevelLine.StartCellColumn == startCellColumn)
                    {
                        if (bevelLine.EndCellRow == endCellRow && bevelLine.EndCellColumn == endCellColumn || cellRange.RowCount == 1 && cellRange.ColumnCount == 1 && bevelLine.EndCellRow == startCellRow + startCell.RowSpan - 1 && bevelLine.EndCellColumn == startCellColumn + startCell.ColumnSpan - 1)
                        {
                            if (bevelLine.BevelLineType == BevelLineType.Down)
                            {
                                bevelLineNeedDelete = bevelLine;
                                break;
                            }
                        }
                    }
                }
                if (bevelLineNeedDelete != null)
                {
                    fpSpreadForHeaderSetting.RemoveBevelLine(bevelLineNeedDelete);
                    fpSpreadForHeaderSetting.ManualChange(HeaderSettingFpSpreadChangedType.BevelLineChanged);
                    Checked = false;
                }
            }
            else
            {
                BevelLine bevelLine = new BevelLine();
                bevelLine.StartCellRow = startCellRow;
                bevelLine.StartCellColumn = startCellColumn;
                bevelLine.EndCellRow = endCellRow;
                bevelLine.EndCellColumn = endCellColumn;
                bevelLine.BevelLineType = BevelLineType.Down;
                fpSpreadForHeaderSetting.AddBevelLine(bevelLine);
                fpSpreadForHeaderSetting.ManualChange(HeaderSettingFpSpreadChangedType.BevelLineChanged);
                Checked = true;
            }
            base.OnClick(e);
        }

        #region IHeaderSettingToolStripItem 成员

        public void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
            if (commandStatus == HeaderSettingCommandStatus.SelectCell)
            {
                Visible = true;
                Enabled = true;
                CellRange cellRange = fpSpreadForHeaderSetting.CellRange;
                int startCellRow = cellRange.Row;
                int startCellColumn = cellRange.Column;

                //对于一个单独选中的Span过的Cell，RowCount与ColumnCount都为1。这会导致斜线计算错误，所以需要添加偏移量进行校正。
                int offset = 0;
                if (cellRange.RowCount == 1)
                {
                    Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow, startCellColumn];
                    if (cell.RowSpan > 1)
                    {
                        offset = cell.RowSpan - 1;
                    }
                }
                int endCellRow = cellRange.Row + cellRange.RowCount - 1+offset;

                offset = 0;
                if (cellRange.ColumnCount == 1)
                {
                    Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow, startCellColumn];
                    if (cell.ColumnSpan > 1)
                    {
                        offset = cell.ColumnSpan - 1;
                    }
                }
                int endCellColumn = cellRange.Column + cellRange.ColumnCount - 1+offset;

                Cell startCell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow, startCellColumn];
                List<BevelLine> bevelLineList = fpSpreadForHeaderSetting.GetBevelLines();
                foreach (BevelLine bevelLine in bevelLineList)
                {
                    if (bevelLine.StartCellRow == startCellRow && bevelLine.StartCellColumn == startCellColumn)
                    {
                        if (bevelLine.EndCellRow == endCellRow && bevelLine.EndCellColumn == endCellColumn||cellRange.RowCount==1&&cellRange.ColumnCount==1&&bevelLine.EndCellRow==startCellRow+startCell.RowSpan-1&&bevelLine.EndCellColumn==startCellColumn+startCell.ColumnSpan-1)
                        {
                            if (bevelLine.BevelLineType == BevelLineType.Down)
                            {
                                Checked = true;
                                break;
                            }
                        }
                    }
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
                return 190;
            }
        }

        #endregion
    }
}
