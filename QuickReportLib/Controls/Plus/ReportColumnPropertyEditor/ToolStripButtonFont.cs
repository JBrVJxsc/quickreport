using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using QuickReportLib.Objects;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.ReportColumnPropertyEditor
{
    internal partial class ToolStripButtonFont : ToolStripButtonPlus , IReportColumnSettingToolStripItem
    {
        public ToolStripButtonFont()
        {
            InitializeComponent();
        }

        private FontDialog fontDialog = new FontDialog();
        private Column column;
        private bool isVisible = true;

        /// <summary>
        /// 显示字体设置对话框。
        /// </summary>
        public void ShowFontDialog()
        {
            DialogResult dialogResult = fontDialog.ShowDialog();
            bool fontChanged = false;

            if (dialogResult == DialogResult.OK)
            {
                if (column.GetFont() != fontDialog.Font)
                {
                    column.SetFont(fontDialog.Font);
                    fontChanged = true;
                }
            }
            if (fontChanged)
            {
                if (HeaderSettingFpSpreadChanged != null)
                {
                    HeaderSettingFpSpreadChanged(this, HeaderSettingFpSpreadChangedType.ReportColumnFontChanged);
                }
            }
        }

        protected override void OnClick(EventArgs e)
        {
            ShowFontDialog();
        }

        #region IReportColumnSettingToolStripItem 成员

        public event HeaderSettingFpSpreadChangedHandle HeaderSettingFpSpreadChanged;

        public Column Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
                fontDialog.Font = column.GetFont();
            }
        }

        public int SortID
        {
            get
            {
                return -20;
            }
        }

        public bool IsVisible
        {
            get
            {
                return isVisible;
            }
            set
            {
                isVisible = value;
            }
        }

        #endregion
    }
}
