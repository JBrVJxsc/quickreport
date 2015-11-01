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
    internal partial class ToolStripTextBoxRowHeight : ToolStripTextBoxPlus, IHeaderSettingToolStripItem
    {
        public ToolStripTextBoxRowHeight()
        {
            InitializeComponent();
        }

        private FpSpreadForHeaderSetting fpSpreadForHeaderSetting;

        protected override int NullValue
        {
            get
            {
                return (int)Constants.Constants.HEADER_SETTING_ROW_HEIGHT;
            }
        }

        private void ToolStripTextBoxRowHeight_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                float height = Convert.ToInt64(Text);
                bool heightChanged = false;
                for (int i = fpSpreadForHeaderSetting.CellRange.Row; i < fpSpreadForHeaderSetting.CellRange.Row + fpSpreadForHeaderSetting.CellRange.RowCount; i++)
                {
                    if (fpSpreadForHeaderSetting.SheetMain.Rows[i].Height != height)
                    {
                        fpSpreadForHeaderSetting.SheetMain.Rows[i].Height = height;
                        heightChanged = true;
                    }
                }
                if (heightChanged)
                {
                    fpSpreadForHeaderSetting.ManualChange(HeaderSettingFpSpreadChangedType.RowHeightChanged);
                }
            }
        }

        private void Calculate()
        {
            if (fpSpreadForHeaderSetting.CellRange.RowCount == 1)
            {
                Text = ((int)fpSpreadForHeaderSetting.SheetMain.Rows[fpSpreadForHeaderSetting.CellRange.Row].Height).ToString();
            }
            else
            {
                float height = fpSpreadForHeaderSetting.SheetMain.Rows[fpSpreadForHeaderSetting.CellRange.Row].Height;
                string heightText = ((int)height).ToString();
                for (int i = fpSpreadForHeaderSetting.CellRange.Row + 1; i < fpSpreadForHeaderSetting.CellRange.Row + fpSpreadForHeaderSetting.CellRange.RowCount; i++)
                {
                    float tempHeight = fpSpreadForHeaderSetting.SheetMain.Rows[i].Height;
                    if (tempHeight != height)
                    {
                        heightText = string.Empty;
                        break;
                    }
                }
                Text = heightText;
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
            if (changedType == HeaderSettingFpSpreadChangedType.RowHeightChanged)
            {
                Calculate();
            }
        }

        public int SortID
        {
            get
            {
                return 310;
            }
        }

        #endregion
    }
}
