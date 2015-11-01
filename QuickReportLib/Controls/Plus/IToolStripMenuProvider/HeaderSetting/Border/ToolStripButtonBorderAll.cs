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
    internal partial class ToolStripButtonBorderAll : ToolStripButtonBorderBase, IHeaderSettingToolStripItem
    {
        public ToolStripButtonBorderAll()
        {
            InitializeComponent();
        }

        private LineBorder lineBorderCenter = new LineBorder(Color.Black, 1, false, true, true, false);
        private LineBorder lineBorderLeft = new LineBorder(Color.Black, 1, true, true, true, false);
        private LineBorder lineBorderBottom = new LineBorder(Color.Black, 1, false, true, true, true);
        private LineBorder lineBorderCorner = new LineBorder(Color.Black, 1, true, true, true, true);

        public override void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
            base.SetCommandStatus(commandStatus);
            if (commandStatus == HeaderSettingCommandStatus.SelectCell) 
            {
                int row = fpSpreadForHeaderSetting.CellRange.Row;
                int column = fpSpreadForHeaderSetting.CellRange.Column;
                int rowCount = fpSpreadForHeaderSetting.CellRange.RowCount;
                int columnCount = fpSpreadForHeaderSetting.CellRange.ColumnCount;
                LineBorder lineBorder;
                #region 测试中间部分与左侧。
                for (int i = row; i < row + rowCount-1; i++)
                {
                    lineBorder = fpSpreadForHeaderSetting.SheetMain.Cells[i, column].Border as LineBorder;
                    if (lineBorder == null)
                    {
                        goto End;
                    }
                    else if (lineBorder.Left != lineBorderLeft.Left || lineBorder.Top != lineBorderLeft.Top || lineBorder.Right != lineBorderLeft.Right || lineBorder.Bottom != lineBorderLeft.Bottom)
                    {
                        goto End;
                    }

                    for (int j = column+1; j <column + columnCount; j++)
                    {
                        lineBorder = fpSpreadForHeaderSetting.SheetMain.Cells[i, j].Border as LineBorder;
                        if (lineBorder == null)
                        {
                            goto End;
                        }
                        else if(lineBorder.Left!=lineBorderCenter.Left || lineBorder.Top!=lineBorderCenter.Top || lineBorder.Right != lineBorderCenter.Right || lineBorder.Bottom != lineBorderCenter.Bottom)
                        {
                            goto End;
                        }
                    }
                }
                #endregion
                #region 测试最下行。
                for (int i = column + 1; i < column + columnCount; i++)
                {
                    lineBorder = fpSpreadForHeaderSetting.SheetMain.Cells[row+rowCount-1, i].Border as LineBorder;
                    if (lineBorder == null)
                    {
                        goto End;
                    }
                    else if (lineBorder.Left != lineBorderBottom.Left || lineBorder.Top != lineBorderBottom.Top || lineBorder.Right != lineBorderBottom.Right || lineBorder.Bottom != lineBorderBottom.Bottom)
                    {
                        goto End;
                    }
                }
                #endregion
                #region 测试最左行与最下行的交界处。
                lineBorder = fpSpreadForHeaderSetting.SheetMain.Cells[row + rowCount - 1, column].Border as LineBorder;
                if (lineBorder == null)
                {
                    goto End;
                }
                else if (lineBorder.Left != lineBorderCorner.Left || lineBorder.Top != lineBorderCorner.Top || lineBorder.Right != lineBorderCorner.Right || lineBorder.Bottom != lineBorderCorner.Bottom)
                {
                    goto End;
                }
                #endregion
                Checked = true;
                return;
            End:
                Checked = false;
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
                for (int i = row; i <row + rowCount; i++)
                {
                    for (int j = column; j <column + columnCount; j++)
                    {
                        fpSpreadForHeaderSetting.SheetMain.Cells[i, j].Border = null;
                    }
                }
                Checked = false;
            }
            else
            {
                for (int i = row; i <row + rowCount - 1; i++)
                {
                    fpSpreadForHeaderSetting.SheetMain.Cells[i, column].Border=lineBorderLeft;
                    for (int j = column + 1; j <column + columnCount; j++)
                    {
                        fpSpreadForHeaderSetting.SheetMain.Cells[i, j].Border = lineBorderCenter;
                    }
                }
                for (int i = column + 1; i <column + columnCount; i++)
                {
                    fpSpreadForHeaderSetting.SheetMain.Cells[row+rowCount - 1, i].Border = lineBorderBottom;
                }
                fpSpreadForHeaderSetting.SheetMain.Cells[row+rowCount-1, column].Border = lineBorderCorner;
                Checked = true;
            }
            base.OnClick(e);
        }

        #region IHeaderSettingToolStripItem 成员

        public override int SortID
        {
            get
            {
                return 270;
            }
        }

        #endregion
    }
}
