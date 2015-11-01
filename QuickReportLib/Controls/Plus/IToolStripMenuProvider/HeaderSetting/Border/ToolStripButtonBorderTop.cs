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
    internal partial class ToolStripButtonBorderTop : ToolStripButtonBorderBase, IHeaderSettingToolStripItem
    {
        public ToolStripButtonBorderTop()
        {
            InitializeComponent();
        }

        private LineBorder lineBorderTop = new LineBorder(Color.Black, 1, false, true, false, false);

        public override void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
            base.SetCommandStatus(commandStatus);
            if (commandStatus == HeaderSettingCommandStatus.SelectCell)
            {
                CellRange cellRange = fpSpreadForHeaderSetting.CellRange;
                int startCellRow = cellRange.Row;
                int startCellColumn = cellRange.Column;
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
                for (int i = 0; i < cellRange.ColumnCount; i++)
                {
                    Cell cell = fpSpreadForHeaderSetting.SheetMain.Cells[startCellRow, startCellColumn + i];
                    LineBorder lineBorder = cell.Border as LineBorder;
                    if (lineBorder.Top)
                    {
                        cell.Border = new LineBorder(Color.Black, 1, lineBorder.Left, false, lineBorder.Right, lineBorder.Bottom);
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
                        cell.Border = lineBorderTop;
                    }
                    else if (!lineBorder.Top)
                    {
                        cell.Border = new LineBorder(Color.Black, 1, lineBorder.Left, true, lineBorder.Right, lineBorder.Bottom);
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
                return 230;
            }
        }

        #endregion
    }
}
