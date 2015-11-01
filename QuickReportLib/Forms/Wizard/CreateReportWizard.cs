using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects;
using QuickReportLib.Interfaces.Wizard;

namespace QuickReportLib.Forms.Wizard
{
    /// <summary>
    /// ���������򵼡�
    /// </summary>
    internal partial class CreateReportWizard : BaseWizard
    {
        public CreateReportWizard(Report report)
        {
            InitializeComponent();
            base.report = report;
        }

        protected override Type WizardType
        {
            get
            {
                return typeof(ICreateReportWizardUserControl);
            }
        }
    }
}