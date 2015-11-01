using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting
{
    internal partial class ToolStripButtonFont : ToolStripButtonPlus , IHeaderSettingToolStripItem
    {
        public ToolStripButtonFont()
        {
            InitializeComponent();
        }

        private FontDialog fontDialog = new FontDialog();
        private FpSpreadForHeaderSetting fpSpreadForHeaderSetting;

        /// <summary>
        /// 显示字体设置对话框。
        /// </summary>
        public void ShowFontDialog()
        {
            DialogResult dialogResult = fontDialog.ShowDialog();
            bool fontChanged = false;

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
                        if (fpSpreadForHeaderSetting.SheetMain.Cells[i, j].Font != fontDialog.Font)
                        {
                            fontChanged = true;
                        }
                        fpSpreadForHeaderSetting.SheetMain.Cells[i, j].Font = fontDialog.Font;
                        if (fpSpreadForHeaderSetting.ReportColumnSelected != null)
                        {
                            fpSpreadForHeaderSetting.ReportColumnSelected.SetHeaderFont(fontDialog.Font);
                        }
                    }
                }
            }
            if (fontChanged)
            {
                fpSpreadForHeaderSetting.ManualChange(HeaderSettingFpSpreadChangedType.FontChanged);
            }
        }

        protected override void OnClick(EventArgs e)
        {
            ShowFontDialog();
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
            else if(commandStatus== HeaderSettingCommandStatus.SelectCell)
            {
                Enabled = true;
                int row = fpSpreadForHeaderSetting.CellRange.Row;
                int column = fpSpreadForHeaderSetting.CellRange.Column;
                fontDialog.Font = fpSpreadForHeaderSetting.SheetMain.Cells[row, column].Font;
            }
            else if (commandStatus == HeaderSettingCommandStatus.SelectReportColumn)
            {
                Enabled = true;
                if (fpSpreadForHeaderSetting.ReportColumnSelected != null)
                {
                    fontDialog.Font = fpSpreadForHeaderSetting.ReportColumnSelected.GetHeaderFont();
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
                return 70;
            }
        }

        #endregion
    }
}
