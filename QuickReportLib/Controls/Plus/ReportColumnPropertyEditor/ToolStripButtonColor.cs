using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using QuickReportLib.Objects;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.ReportColumnPropertyEditor
{
    internal partial class ToolStripButtonColor : ToolStripButtonPlus, IReportColumnSettingToolStripItem
    {
        public ToolStripButtonColor()
        {
            InitializeComponent();
        }

        private ColorDialog colorDialog = new ColorDialog();
        private Column column;
        private bool isVisible = true;

        /// <summary>
        /// 显示颜色设置对话框。
        /// </summary>
        public void ShowColorDialog()
        {
            DialogResult dialogResult = colorDialog.ShowDialog();
            bool colorChanged = false;

            if (dialogResult == DialogResult.OK)
            {
                if (column.GetColor() != colorDialog.Color)
                {
                    column.SetColor(colorDialog.Color);
                    colorChanged = true;
                }
            }
            if (colorChanged)
            {
                if (HeaderSettingFpSpreadChanged != null)
                {
                    HeaderSettingFpSpreadChanged(this, HeaderSettingFpSpreadChangedType.ReportColumnColorChanged);
                }
            }
        }

        protected override void OnClick(EventArgs e)
        {
            ShowColorDialog();
            base.OnClick(e);
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
                colorDialog.Color = column.GetColor();
            }
        }

        public int SortID
        {
            get
            {
                return -10;
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
