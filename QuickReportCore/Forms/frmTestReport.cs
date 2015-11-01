using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore.Forms
{
    internal partial class frmTestReport : Form
    {
        private QuickReportCore.QuickReportShow quickReportShow = null;

        public frmTestReport(QuickReportCore.QuickReportShow show)
        {
            InitializeComponent();
            if (show == null)
                return;
            quickReportShow = show;
            panelShowReport.Controls.Add(quickReportShow);
            show.Dock = DockStyle.Fill;
        }

        private void tbQuery_Click(object sender, EventArgs e)
        {
            if (quickReportShow!=null)
                quickReportShow.QueryForTest();
        }

        private void tbPrint_Click(object sender, EventArgs e)
        {
            if (quickReportShow != null)
                quickReportShow.PrintForTest();
        }

        private void tbExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbSetting_Click(object sender, EventArgs e)
        {
            if (quickReportShow != null)
                quickReportShow.SettingForTest();
        }

        private void tbExp_Click(object sender, EventArgs e)
        {
            if (quickReportShow != null)
                quickReportShow.ExportForTest();
        }

        private void frmTestReport_Activated(object sender, EventArgs e)
        {
            Forms.frmQuickReportEditor.StopHooker();
        }

        private void frmTestReport_Deactivate(object sender, EventArgs e)
        {
            Forms.frmQuickReportEditor.StopHooker();
        }
    }
}