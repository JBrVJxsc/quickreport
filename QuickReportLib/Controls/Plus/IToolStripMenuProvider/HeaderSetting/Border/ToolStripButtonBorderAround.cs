using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using FarPoint.Win;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.Model;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting.Border
{
    internal partial class ToolStripButtonBorderAround : ToolStripButtonBorderBase, IHeaderSettingToolStripItem
    {
        public ToolStripButtonBorderAround()
        {
            InitializeComponent();
        }

        private LineBorder lineBorderLeft = new LineBorder(Color.Black, 1, true, false, false, false);
        private LineBorder lineBorderTop = new LineBorder(Color.Black, 1, false, true, false, false);
        private LineBorder lineBorderRight = new LineBorder(Color.Black, 1, false, false, true, false);
        private LineBorder lineBorderBottom = new LineBorder(Color.Black, 1, false, false, false, true);

        public override void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
            base.SetCommandStatus(commandStatus);
            if (commandStatus == HeaderSettingCommandStatus.SelectCell)
            {
                CellRange cellRange = fpSpreadForHeaderSetting.CellRange;

                int startCellRow = cellRange.Row;
                int startCellColumn = cellRange.Column;
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow + i, startCellColumn];
                    LineBorder lineBorder = cell.Border as LineBorder;
                    if (lineBorder == null)
                    {
                        goto End;
                    }
                    else if (!lineBorder.Left)
                    {
                        goto End;
                    }
                }

                startCellRow = cellRange.Row;
                startCellColumn = cellRange.Column;
                for (int i = 0; i < cellRange.ColumnCount; i++)
                {
                    Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow, startCellColumn + i];
                    LineBorder lineBorder = cell.Border as LineBorder;
                    if (lineBorder == null)
                    {
                        goto End;
                    }
                    else if (!lineBorder.Top)
                    {
                        goto End;
                    }
                }

                startCellRow = cellRange.Row;
                startCellColumn = cellRange.Column + cellRange.ColumnCount - 1;
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow + i, startCellColumn];
                    LineBorder lineBorder = cell.Border as LineBorder;
                    if (lineBorder == null)
                    {
                        goto End;
                    }
                    else if (!lineBorder.Right)
                    {
                        goto End;
                    }
                }

                startCellRow = cellRange.Row + cellRange.RowCount - 1;
                startCellColumn = cellRange.Column;
                for (int i = 0; i < cellRange.ColumnCount; i++)
                {
                    Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow, startCellColumn + i];
                    LineBorder lineBorder = cell.Border as LineBorder;
                    if (lineBorder == null)
                    {
                        goto End;
                    }
                    else if (!lineBorder.Bottom)
                    {
                        goto End;
                    }
                }
                Checked = true;
                return;
            End:
                Checked = false;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            CellRange cellRange = fpSpreadForHeaderSetting.CellRange;
            int startCellRow = -1;
            int startCellColumn = -1;
            if (Checked)
            {
                startCellRow = cellRange.Row;
                startCellColumn = cellRange.Column;
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow + i, startCellColumn];
                    LineBorder lineBorder = cell.Border as LineBorder;
                    if (lineBorder.Left)
                    {
                        cell.Border = new LineBorder(Color.Black, 1, false, lineBorder.Top, lineBorder.Right, lineBorder.Bottom);
                    }
                }

                startCellRow = cellRange.Row;
                startCellColumn = cellRange.Column;
                for (int i = 0; i < cellRange.ColumnCount; i++)
                {
                    Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow, startCellColumn + i];
                    LineBorder lineBorder = cell.Border as LineBorder;
                    if (lineBorder.Top)
                    {
                        cell.Border = new LineBorder(Color.Black, 1, lineBorder.Left, false, lineBorder.Right, lineBorder.Bottom);
                    }
                }

                startCellRow = cellRange.Row;
                startCellColumn = cellRange.Column + cellRange.ColumnCount - 1;
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow + i, startCellColumn];
                    LineBorder lineBorder = cell.Border as LineBorder;
                    if (lineBorder.Right)
                    {
                        cell.Border = new LineBorder(Color.Black, 1, lineBorder.Left, lineBorder.Top, false, lineBorder.Bottom);
                    }
                }

                startCellRow = cellRange.Row + cellRange.RowCount - 1;
                startCellColumn = cellRange.Column;
                for (int i = 0; i < cellRange.ColumnCount; i++)
                {
                    Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow, startCellColumn + i];
                    LineBorder lineBorder = cell.Border as LineBorder;
                    if (lineBorder.Bottom)
                    {
                        cell.Border = new LineBorder(Color.Black, 1, lineBorder.Left, lineBorder.Top, lineBorder.Right, false);
                    }
                }
                Checked = false;
            }
            else
            {
                startCellRow = cellRange.Row;
                startCellColumn = cellRange.Column;
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow + i, startCellColumn];
                    LineBorder lineBorder = cell.Border as LineBorder;
                    if (lineBorder == null)
                    {
                        cell.Border = lineBorderLeft;
                    }
                    else if (!lineBorder.Left)
                    {
                        cell.Border = new LineBorder(Color.Black, 1, true, lineBorder.Top, lineBorder.Right, lineBorder.Bottom);
                    }
                }

                startCellRow = cellRange.Row;
                startCellColumn = cellRange.Column;
                for (int i = 0; i < cellRange.ColumnCount; i++)
                {
                    Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow, startCellColumn + i];
                    LineBorder lineBorder = cell.Border as LineBorder;
                    if (lineBorder == null)
                    {
                        cell.Border = lineBorderTop;
                    }
                    else if (!lineBorder.Top)
                    {
                        cell.Border = new LineBorder(Color.Black, 1, lineBorder.Left, true, lineBorder.Right, lineBorder.Bottom);
                    }
                }

                startCellRow = cellRange.Row;
                startCellColumn = cellRange.Column + cellRange.ColumnCount - 1;
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow + i, startCellColumn];
                    LineBorder lineBorder = cell.Border as LineBorder;
                    if (lineBorder == null)
                    {
                        cell.Border = lineBorderRight;
                    }
                    else if (!lineBorder.Right)
                    {
                        cell.Border = new LineBorder(Color.Black, 1, lineBorder.Left, lineBorder.Top, true, lineBorder.Bottom);
                    }
                }

                startCellRow = cellRange.Row + cellRange.RowCount - 1;
                startCellColumn = cellRange.Column;
                for (int i = 0; i < cellRange.ColumnCount; i++)
                {
                    Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow, startCellColumn + i];
                    LineBorder lineBorder = cell.Border as LineBorder;
                    if (lineBorder == null)
                    {
                        cell.Border = lineBorderBottom;
                    }
                    else if (!lineBorder.Bottom)
                    {
                        cell.Border = new LineBorder(Color.Black, 1, lineBorder.Left, lineBorder.Top, lineBorder.Right, true);
                    }
                }

                Checked = true;
            }
            base.OnClick(e);
        }

        #region IHeaderSettingToolStripItem ³ÉÔ±

        public override int SortID
        {
            get
            {
                return 260;
            }
        }

        #endregion
    }
}
