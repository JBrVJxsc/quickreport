using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects;
using QuickReportLib.Managers;
using QuickReportLib.ReportLayoutStyles;
using QuickReportLib.Interfaces.Wizard;

namespace QuickReportLib.Controls.Wizard
{
    /// <summary>
    /// 报表外观向导设置。
    /// </summary>
    internal partial class ReportLayoutStyleWizard : BaseWizardUserControl, ICreateReportWizardUserControl
    {
        public ReportLayoutStyleWizard()
        {
            InitializeComponent();
        }

        private ReportLayoutStyleWizardElement[] reportLayoutStyleWizardElements;

        public override Report Report
        {
            get
            {
                return base.Report;
            }
            set
            {
                base.Report = value;
                if (report.ReportLayoutStyle == null)
                {
                    if (reportLayoutStyleWizardElements != null)
                    {
                        reportLayoutStyleWizardElements[0].SetCheckState(true);
                    }
                }
            }
        }

        public override int SortID
        {
            get
            {
                return 2;
            }
        }

        private void InitReportLayoutStyles()
        {
            List<object> objectList = ReflectionManager.CreateInstancesByBaseClass(typeof(BaseReportLayoutStyle));
            reportLayoutStyleWizardElements = new ReportLayoutStyleWizardElement[objectList.Count];
            foreach (object obj in objectList)
            {
                BaseReportLayoutStyle style = obj as BaseReportLayoutStyle;
                int sortID = style.GetStyleSortID();
                ReportLayoutStyleWizardElement reportLayoutStyleWizardElement = new ReportLayoutStyleWizardElement();
                reportLayoutStyleWizardElement.ReportLayoutStyle = style;
                reportLayoutStyleWizardElement.ReportLayoutStyleSelected += new ReportLayoutStyleSelectedHandle(reportLayoutStyleWizardElement_ReportLayoutStyleSelected);
                reportLayoutStyleWizardElements[sortID] = reportLayoutStyleWizardElement;
            }
            pnlReportLayoutStyles.SuspendLayout();
            for (int i = 0; i < reportLayoutStyleWizardElements.Length; i++)
            {
                pnlReportLayoutStyles.Controls.Add(reportLayoutStyleWizardElements[i] as Control);
            }
            pnlReportLayoutStyles.ResumeLayout();
        }

        void reportLayoutStyleWizardElement_ReportLayoutStyleSelected(object sender, BaseReportLayoutStyle reportLayoutStyle)
        {
            foreach (Control control in pnlReportLayoutStyles.Controls)
            {
                if (control == sender as Control)
                {
                    lbSummary.Text = reportLayoutStyle.GetLayoutStyleSummary();
                    if (report != null)
                    {
                        report.ReportLayoutStyle = reportLayoutStyle;
                    }
                    continue;
                }
                (control as ReportLayoutStyleWizardElement).SetCheckState(false);
            }
        }

        private void ReportLayoutStyleWizard_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            InitReportLayoutStyles();
        }

        #region IWizardUserControl 成员


        public string Title
        {
            get
            {
                return "报表布局";
            }
        }

        public string Summary
        {
            get
            {
                return "选择报表布局样式";
            }
        }

        public Image Image
        {
            get
            {
                return null;
            }
        }

        public bool CanNext()
        {
            return true;
        }

        #endregion
    }
}
