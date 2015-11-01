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
    internal partial class ToolStripButtonBorderRight : ToolStripButtonBorderBase, IHeaderSettingToolStripItem
    {
        public ToolStripButtonBorderRight()
        {
            InitializeComponent();
        }

        private LineBorder lineBorderRight = new LineBorder(Color.Black, 1, false, false, true, false);

        public override void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
            base.SetCommandStatus(commandStatus);
            if (commandStatus == HeaderSettingCommandStatus.SelectCell)
            {
                CellRange cellRange = fpSpreadForHeaderSetting.CellRange;
                int startCellRow = cellRange.Row;
                int startCellColumn = cellRange.Column + cellRange.ColumnCount - 1;
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
                Checked = true;
                return;
            End:
                Checked = false;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            CellRange cellRange = fpSpreadForHeaderSetting.CellRange;
            int startCellRow = cellRange.Row;
            int startCellColumn = cellRange.Column + cellRange.ColumnCount - 1;

            if (Checked)
            {
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow + i, startCellColumn];
                    LineBorder lineBorder = cell.Border as LineBorder;
                    if (lineBorder.Right)
                    {
                        cell.Border = new LineBorder(Color.Black, 1, lineBorder.Left, lineBorder.Top, false, lineBorder.Bottom);
                    }
                }
                Checked = false;
            }
            else
            {
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
                Checked = true;
            }
            base.OnClick(e);
        }

        #region IHeaderSettingToolStripItem ³ÉÔ±

        public override int SortID
        {
            get
            {
                return 240;
            }
        }

        #endregion
    }
}
