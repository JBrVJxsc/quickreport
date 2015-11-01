using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Interfaces.Wizard;
using QuickReportLib.Enums;
using QuickReportLib.ReportStyles;
using QuickReportLib.Forms.Wizard;
using QuickReportLib.Objects;
using QuickReportLib.Managers;

namespace QuickReportLib.Controls.Wizard
{
    internal partial class ReportStyleWizard : BaseWizardUserControl,ICreateReportWizardUserControl, IWizardContainsWizardUserControl
    {
        public ReportStyleWizard()
        {
            InitializeComponent();
        }

        private ReportStyleWizardElement[] reportStyleWizardElements;

        public override Report Report
        {
            get
            {
                return base.Report;
            }
            set
            {
                base.Report = value;
                if (report.ReportStyle == null)
                {
                    if (reportStyleWizardElements!=null)
                    {
                        reportStyleWizardElements[0].SetCheckState(true);
                    }
                }
            }
        }

        public override int SortID
        {
            get
            {
                return 1;
            }
        }

        private void InitReportStyles()
        {
            List<object> objectList = ReflectionManager.CreateInstancesByBaseClass(typeof(BaseReportStyle));
            reportStyleWizardElements = new ReportStyleWizardElement[objectList.Count];
            foreach (object obj in objectList)
            {
                BaseReportStyle style = obj as BaseReportStyle;
                int sortID = style.GetStyleSortID();
                ReportStyleWizardElement reportStyleWizardElement = new ReportStyleWizardElement();
                reportStyleWizardElement.ReportStyle = style;
                reportStyleWizardElement.ReportStyleSelected += new ReportStyleSelectedHandle(reportStyleWizardElement_ReportStyleSelected);
                reportStyleWizardElements[sortID] = reportStyleWizardElement;
            }
            pnlReportStyles.SuspendLayout();
            for (int i = 0; i < reportStyleWizardElements.Length; i++)
            {
                pnlReportStyles.Controls.Add(reportStyleWizardElements[i] as Control);
            }
            pnlReportStyles.ResumeLayout();
        }

        void reportStyleWizardElement_ReportStyleSelected(object sender, BaseReportStyle reportStyle)
        {
            foreach (Control control in pnlReportStyles.Controls)
            {
                if (control == sender as Control)
                {
                    lbSummary.Text = reportStyle.GetStyleSummary();
                    if (report != null)
                    {
                        report.ReportStyle = reportStyle;
                    }
                    continue;
                }
                (control as ReportStyleWizardElement).SetCheckState(false);
            }
        }

        private void ReportStyleWizard_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            InitReportStyles();
        }

        #region IWizardContainsWizardUserControl 成员

        public string Title
        {
            get
            {
                return "报表样式";
            }
        }

        public string Summary
        {
            get
            {
                return "选择报表样式";
            }
        }

        public Image Image
        {
            get
            {
                return null;
            }
        }

        public event WizardOfWizardDoneHandle WizardOfWizardDone;

        public void ShowWizard()
        {
            BaseWizard wizard = report.ReportStyle.GetStyleSettingWizard(report);
            if (wizard == null)
            {
                if (WizardOfWizardDone != null)
                {
                    WizardOfWizardDone(this, report, WizardOfWizardDoneAction.Continue);
                    return;
                }
            }
            wizard.WizardDone += new WizardDoneHandle(wizard_WizardDone);
            wizard.ShowDialog();
            if (!wizard.IsDone)
            {
                if (WizardOfWizardDone != null)
                {
                    WizardOfWizardDone(this, report, WizardOfWizardDoneAction.Stay);
                }
            }
        }

        void wizard_WizardDone(object sender, Report report)
        {
            if (WizardOfWizardDone != null)
            {
                WizardOfWizardDone(this, report, WizardOfWizardDoneAction.Continue);
            }
        }

        public bool CanNext()
        {
            return true;
        }

        #endregion
    }
}
