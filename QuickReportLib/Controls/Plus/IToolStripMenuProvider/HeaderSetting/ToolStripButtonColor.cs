using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting
{
    internal partial class ToolStripButtonColor : ToolStripButtonPlus, IHeaderSettingToolStripItem
    {
        public ToolStripButtonColor()
        {
            InitializeComponent();
        }

        private ColorDialog colorDialog = new ColorDialog();
        private FpSpreadForHeaderSetting fpSpreadForHeaderSetting;

        /// <summary>
        /// 显示颜色设置对话框。
        /// </summary>
        public void ShowColorDialog()
        {
            DialogResult dialogResult = colorDialog.ShowDialog();
            bool colorChanged = false;

            if (dialogResult == DialogResult.OK)
            {
                int row = fpSpreadForHeaderSetting.CellRange.Row;
                int column = fpSpreadForHeaderSetting.CellRange.Column;
                int rowCount = fpSpreadForHeaderSetting.CellRange.RowCount;
                int columnCount = fpSpreadForHeaderSetting.CellRange.ColumnCount;
                for (int i = row; i < row + rowCount; i++)
                {
                    for (int j = column; j < column + columnCount; j++)
                    {
                        if (fpSpreadForHeaderSetting.SheetMain.Cells[i, j].ForeColor != colorDialog.Color)
                        {
                            colorChanged = true;
                        }
                        fpSpreadForHeaderSetting.SheetMain.Cells[i, j].ForeColor = colorDialog.Color;
                        if (fpSpreadForHeaderSetting.ReportColumnSelected != null)
                        {
                            fpSpreadForHeaderSetting.ReportColumnSelected.SetHeaderColor(colorDialog.Color);
                        }
                    }
                }
            }
            if (colorChanged)
            {
                fpSpreadForHeaderSetting.ManualChange(HeaderSettingFpSpreadChangedType.ColorChanged);
            }
        }

        protected override void OnClick(EventArgs e)
        {
            ShowColorDialog();
            base.OnClick(e);
        }

        #region IHeaderSettingToolStripItem 成员

        public void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
            if (commandStatus == HeaderSettingCommandStatus.SelectColumn)
            {
                Enabled = false;
            }
            else if (commandStatus == HeaderSettingCommandStatus.SelectRow)
            {
                Enabled = false;
            }
            else if (commandStatus == HeaderSettingCommandStatus.Null)
            {
                Enabled = false;
            }
            else if (commandStatus == HeaderSettingCommandStatus.SelectCell)
            {
                Enabled = true;
                int row = fpSpreadForHeaderSetting.CellRange.Row;
                int column = fpSpreadForHeaderSetting.CellRange.Column;
                colorDialog.Color = fpSpreadForHeaderSetting.SheetMain.Cells[row, column].ForeColor;
            }
            else if (commandStatus == HeaderSettingCommandStatus.SelectReportColumn)
            {
                Enabled = true;
                if (fpSpreadForHeaderSetting.ReportColumnSelected != null)
                {
                    colorDialog.Color = fpSpreadForHeaderSetting.ReportColumnSelected.GetHeaderColor();
                }
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
                return 80;
            }
        }

        #endregion
    }
}
