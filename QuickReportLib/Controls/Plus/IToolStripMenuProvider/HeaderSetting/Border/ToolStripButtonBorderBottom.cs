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
    internal partial class ToolStripButtonBorderBottom : ToolStripButtonBorderBase, IHeaderSettingToolStripItem
    {
        public ToolStripButtonBorderBottom()
        {
            InitializeComponent();
        }

        private LineBorder lineBorderBottom = new LineBorder(Color.Black, 1, false, false, false, true);

        public override void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
            base.SetCommandStatus(commandStatus);
            if (commandStatus == HeaderSettingCommandStatus.SelectCell)
            {
                CellRange cellRange = fpSpreadForHeaderSetting.CellRange;
                int startCellRow = cellRange.Row +cellRange.RowCount-1;
                int startCellColumn = cellRange.Column;
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
            int startCellRow = cellRange.Row + cellRange.RowCount - 1;
            int startCellColumn = cellRange.Column ;

            if (Checked)
            {
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
                return 250;
            }
        }

        #endregion
    }
}
