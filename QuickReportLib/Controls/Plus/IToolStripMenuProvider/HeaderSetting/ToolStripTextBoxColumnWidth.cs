using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;
using QuickReportLib.Enums;

namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting
{
    internal partial class ToolStripTextBoxColumnWidth : ToolStripTextBoxPlus, IHeaderSettingToolStripItem
    {
        public ToolStripTextBoxColumnWidth()
        {
            InitializeComponent();
        }

        private FpSpreadForHeaderSetting fpSpreadForHeaderSetting;

        protected override int NullValue
        {
            get
            {
                return (int)Constants.Constants.HEADER_SETTING_COLUMN_WIDTH;
            }
        }

        private void ToolStripTextBoxColumnWidth_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                float width = Convert.ToInt64(Text);
                bool widthChanged = false;
                for (int i = fpSpreadForHeaderSetting.CellRange.Column ; i < fpSpreadForHeaderSetting.CellRange.Column + fpSpreadForHeaderSetting.CellRange.ColumnCount; i++)
                {
                    if (fpSpreadForHeaderSetting.SheetMain.Columns[i].Width != width)
                    {
                        fpSpreadForHeaderSetting.SheetMain.Columns[i].Width = width;
                        widthChanged = true;
                    }
                }
                if (widthChanged)
                {
                    fpSpreadForHeaderSetting.ManualChange(HeaderSettingFpSpreadChangedType.ColumnWidthChanged);
                }
            }
        }

        private void Calculate()
        {
            if (fpSpreadForHeaderSetting.CellRange.ColumnCount == 1)
            {
                Text = ((int)fpSpreadForHeaderSetting.SheetMain.Columns[fpSpreadForHeaderSetting.CellRange.Column].Width).ToString();
            }
            else
            {
                float width = fpSpreadForHeaderSetting.SheetMain.Columns[fpSpreadForHeaderSetting.CellRange.Column].Width;
                string widthText = ((int)width).ToString();
                for (int i = fpSpreadForHeaderSetting.CellRange.Column + 1; i < fpSpreadForHeaderSetting.CellRange.Column + fpSpreadForHeaderSetting.CellRange.ColumnCount; i++)
                {
                    float tempWidth = fpSpreadForHeaderSetting.SheetMain.Columns[i].Width;
                    if (tempWidth != width)
                    {
                        widthText = string.Empty;
                        break;
                    }
                }
                Text = widthText;
            }
        }

        #region IHeaderSettingToolStripItem ³ÉÔ±

        public void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
            Calculate();
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
                fpSpreadForHeaderSetting.HeaderSettingFpSpreadChanged += new HeaderSettingFpSpreadChangedHandle(fpSpreadForHeaderSetting_HeaderSettingFpSpreadChanged);
            }
        }

        void fpSpreadForHeaderSetting_HeaderSettingFpSpreadChanged(object sender, HeaderSettingFpSpreadChangedType changedType)
        {
            if (changedType == HeaderSettingFpSpreadChangedType.ColumnWidthChanged)
            {
                Calculate();
            }
        }

        public int SortID
        {
            get
            {
                return 290;
            }
        }

        #endregion
    }
}
