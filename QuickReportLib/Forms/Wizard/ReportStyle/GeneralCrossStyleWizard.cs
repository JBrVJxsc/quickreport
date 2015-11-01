using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects;
using QuickReportLib.ReportStyles;
using QuickReportLib.Interfaces.Wizard.WizardOfWizard.ReportStyle;

namespace QuickReportLib.Forms.Wizard.ReportStyle
{
    /// <summary>
    /// ��ͨ���汨����ʽ�򵼡�
    /// </summary>
    internal partial class GeneralCrossStyleWizard : BaseWizard
    {
        public GeneralCrossStyleWizard(Report report)
        {
            InitializeComponent();
            this.report = report;
        }

        protected override Type WizardType
        {
            get
            {
                return typeof(IGeneralCrossStyleWizardUserControl);
            }
        }
    }
}