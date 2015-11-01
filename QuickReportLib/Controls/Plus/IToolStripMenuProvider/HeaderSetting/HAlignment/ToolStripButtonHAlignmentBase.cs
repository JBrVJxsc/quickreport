using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using QuickReportLib.Enums;

namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting.HAlignment
{
    internal partial class ToolStripButtonHAlignmentBase : ToolStripButtonPlus
    {
        public ToolStripButtonHAlignmentBase()
        {
            InitializeComponent();
        }

        protected FpSpreadForHeaderSetting fpSpreadForHeaderSetting;

        protected virtual CellHorizontalAlignment HorizontalAlignment
        {
            get
            {
                return CellHorizontalAlignment.General;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            int row = fpSpreadForHeaderSetting.CellRange.Row;
            int column = fpSpreadForHeaderSetting.CellRange.Column;
            int rowCount = fpSpreadForHeaderSetting.CellRange.RowCount;
            int columnCount = fpSpreadForHeaderSetting.CellRange.ColumnCount;

            if (Checked)
            {
                for (int i = row; i < row + rowCount; i++)
                {
                    for (int j = column; j < column + columnCount; j++)
                    {
                        fpSpreadForHeaderSetting.SheetMain.Cells[i, j].HorizontalAlignment = CellHorizontalAlignment.General;
                    }
                }
                if (fpSpreadForHeaderSetting.ReportColumnSelected != null)
                {
                    fpSpreadForHeaderSetting.ReportColumnSelected.HeaderHAligment = CellHorizontalAlignment.General;
                }
            }
            else
            {
                for (int i = row; i < row + rowCount; i++)
                {
                    for (int j = column; j < column + columnCount; j++)
                    {
                        fpSpreadForHeaderSetting.SheetMain.Cells[i, j].HorizontalAlignment = HorizontalAlignment;
                    }
                }
                if (fpSpreadForHeaderSetting.ReportColumnSelected != null)
                {
                    fpSpreadForHeaderSetting.ReportColumnSelected.HeaderHAligment = HorizontalAlignment;
                }
            }

            fpSpreadForHeaderSetting.ManualChange(HeaderSettingFpSpreadChangedType.AlignmentChanged);
            fpSpreadForHeaderSetting.ManualHeaderSettingCommandStatusChanged();
            base.OnClick(e);
        }

        public virtual void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
            if (commandStatus == HeaderSettingCommandStatus.SelectRow || commandStatus == HeaderSettingCommandStatus.SelectColumn || commandStatus== HeaderSettingCommandStatus.Null)
            {
                Enabled = false; 
                Checked = false;
            }
            else
            {
                Enabled = true;

                int row = fpSpreadForHeaderSetting.CellRange.Row;
                int column = fpSpreadForHeaderSetting.CellRange.Column;
                int rowCount = fpSpreadForHeaderSetting.CellRange.RowCount;
                int columnCount = fpSpreadForHeaderSetting.CellRange.ColumnCount;
                for (int i = row; i < row + rowCount; i++)
                {
                    for (int j = column; j < column + columnCount; j++)
                    {
                        CellHorizontalAlignment horizontalAlignment = fpSpreadForHeaderSetting.SheetMain.Cells[i, j].HorizontalAlignment;
                        if (HorizontalAlignment != horizontalAlignment)
                        {
                            goto End;
                        }
                    }
                }
                Checked = true;
                return;
            End:
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

        public virtual int SortID
        {
            get
            {
                return 0;
            }
        }
    }
}
