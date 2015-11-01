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
    internal partial class ToolStripButtonBorderLeft : ToolStripButtonBorderBase , IHeaderSettingToolStripItem
    {
        public ToolStripButtonBorderLeft()
        {
            InitializeComponent();
        }

        private LineBorder lineBorderLeft = new LineBorder(Color.Black, 1, true, false, false, false);

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
            int startCellColumn = cellRange.Column;

            if (Checked)
            {
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow + i, startCellColumn];
                    LineBorder lineBorder = cell.Border as LineBorder;
                    if (lineBorder.Left)
                    {
                        cell.Border = new LineBorder(Color.Black, 1, false, lineBorder.Top, lineBorder.Right, lineBorder.Bottom);
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
                        cell.Border = lineBorderLeft;
                    }
                    else if (!lineBorder.Left)
                    {
                        cell.Border = new LineBorder(Color.Black, 1, true, lineBorder.Top, lineBorder.Right, lineBorder.Bottom);
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
                return 220;
            }
        }

        #endregion
    }
}
