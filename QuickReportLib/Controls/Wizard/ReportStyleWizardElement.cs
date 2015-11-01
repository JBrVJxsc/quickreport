using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.ReportStyles;

namespace QuickReportLib.Controls.Wizard
{
    internal partial class ReportStyleWizardElement : BaseUserControl
    {
        public ReportStyleWizardElement()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 报表样式被选中时所触发的事件。
        /// </summary>
        internal event ReportStyleSelectedHandle ReportStyleSelected;

        private BaseReportStyle reportStyle;

        /// <summary>
        /// 报表样式。
        /// </summary>
        public BaseReportStyle ReportStyle
        {
            get
            {
                return reportStyle;
            }
            set
            {
                reportStyle = value;
                InitReportStyle();
            }
        }

        private void InitReportStyle()
        {
            if (DesignMode)
            {
                return;
            }
            imgStyle.Image = reportStyle.GetStylePreview();
            rbSelect.Text = reportStyle.GetStyleName();
        }

        private void rbSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSelect.Checked)
            {
                if (ReportStyleSelected != null)
                {
                    ReportStyleSelected(this, reportStyle);
                }
                if (!rbSelect.Focused)
                {
                    rbSelect.Focus();
                }
            }
        }

        private void imgStyle_Click(object sender, EventArgs e)
        {
            if (!rbSelect.Checked)
            {
                rbSelect.Checked = true;
            }
        }

        /// <summary>
        /// 设置RadioButton的选中状态。
        /// </summary>
        /// <param name="check">选中状态。</param>
        public void SetCheckState(bool check)
        {
            rbSelect.Checked = check;
        }

    }

    /// <summary>
    /// 选择报表样式时所执行的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="reportStyle">报表样式。</param>
    internal delegate void ReportStyleSelectedHandle(object sender, BaseReportStyle reportStyle);
}
