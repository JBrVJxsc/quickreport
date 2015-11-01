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
    /// �Զ����н��汨����ʽ�򵼡�
    /// </summary>
    internal partial class CustomColumnCrossStyleWizard : BaseWizard
    {
        public CustomColumnCrossStyleWizard(Report report)
        {
            InitializeComponent();
            this.report = report;
        }

        protected override Type WizardType
        {
            get
            {
                return typeof(ICustomColumnCrossStyleWizardUserControl);
            }
        }
    }
}