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
        /// ������ʽ��ѡ��ʱ���������¼���
        /// </summary>
        internal event ReportStyleSelectedHandle ReportStyleSelected;

        private BaseReportStyle reportStyle;

        /// <summary>
        /// ������ʽ��
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
        /// ����RadioButton��ѡ��״̬��
        /// </summary>
        /// <param name="check">ѡ��״̬��</param>
        public void SetCheckState(bool check)
        {
            rbSelect.Checked = check;
        }

    }

    /// <summary>
    /// ѡ�񱨱���ʽʱ��ִ�еķ�����
    /// </summary>
    /// <param name="sender">�¼�Դ��</param>
    /// <param name="reportStyle">������ʽ��</param>
    internal delegate void ReportStyleSelectedHandle(object sender, BaseReportStyle reportStyle);
}
