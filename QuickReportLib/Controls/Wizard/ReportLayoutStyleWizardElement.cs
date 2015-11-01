using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.ReportLayoutStyles;

namespace QuickReportLib.Controls.Wizard
{
    internal partial class ReportLayoutStyleWizardElement : BaseUserControl
    {
        public ReportLayoutStyleWizardElement()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 报表布局样式被选中时所触发的事件。
        /// </summary>
        internal event ReportLayoutStyleSelectedHandle ReportLayoutStyleSelected;

        private BaseReportLayoutStyle reportLayoutStyle;

        /// <summary>
        /// 报表布局样式。
        /// </summary>
        public BaseReportLayoutStyle ReportLayoutStyle
        {
            get
            {
                return reportLayoutStyle;
            }
            set
            {
                reportLayoutStyle = value;
                InitReportLayoutStyle();
            }
        }

        private void InitReportLayoutStyle()
        {
            if (DesignMode)
            {
                return;
            }
            imgStyle.Image = reportLayoutStyle.GetLayoutStylePreview();
            rbSelect.Text = reportLayoutStyle.GetLayoutStyleName();
        }

        private void rbSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSelect.Checked)
            {
                if (ReportLayoutStyleSelected != null)
                {
                    ReportLayoutStyleSelected(this, reportLayoutStyle);
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
    /// 选择报表布局样式时所执行的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="reportStyle">报表布局样式。</param>
    internal delegate void ReportLayoutStyleSelectedHandle(object sender, BaseReportLayoutStyle reportLayoutStyle);
}
