using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting.Border
{
    internal partial class ToolStripButtonBorderEraser : ToolStripButtonBorderBase, IHeaderSettingToolStripItem
    {
        public ToolStripButtonBorderEraser()
        {
            InitializeComponent();
        }

        protected override void OnClick(EventArgs e)
        {
            int row = fpSpreadForHeaderSetting.CellRange.Row;
            int column = fpSpreadForHeaderSetting.CellRange.Column;
            int rowCount = fpSpreadForHeaderSetting.CellRange.RowCount;
            int columnCount = fpSpreadForHeaderSetting.CellRange.ColumnCount;
            for (int i = row; i < row + rowCount; i++)
            {
                for (int j = column; j < column + columnCount; j++)
                {
                    fpSpreadForHeaderSetting.SheetMain.Cells[i, j].Border = null;
                }
            }
            base.OnClick(e);
        }

        #region IHeaderSettingToolStripItem ³ÉÔ±

        public override int SortID
        {
            get
            {
                return 280;
            }
        }

        #endregion
    }
}
