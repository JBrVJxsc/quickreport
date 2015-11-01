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
        /// ��������ʽ��ѡ��ʱ���������¼���
        /// </summary>
        internal event ReportLayoutStyleSelectedHandle ReportLayoutStyleSelected;

        private BaseReportLayoutStyle reportLayoutStyle;

        /// <summary>
        /// ��������ʽ��
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
        /// ����RadioButton��ѡ��״̬��
        /// </summary>
        /// <param name="check">ѡ��״̬��</param>
        public void SetCheckState(bool check)
        {
            rbSelect.Checked = check;
        }
    }

    /// <summary>
    /// ѡ�񱨱�����ʽʱ��ִ�еķ�����
    /// </summary>
    /// <param name="sender">�¼�Դ��</param>
    /// <param name="reportStyle">��������ʽ��</param>
    internal delegate void ReportLayoutStyleSelectedHandle(object sender, BaseReportLayoutStyle reportLayoutStyle);
}
