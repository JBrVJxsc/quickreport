using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore
{
    public partial class QuickReportShow : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public QuickReportShow()
        {
            InitializeComponent();
        }

        private QuickReportCore.Managers.QuickReportManager qrManager = new QuickReportCore.Managers.QuickReportManager();
        private QuickReportCore.Interfaces.IAmReport[] reports;

        private string reportIDs = string.Empty;
        [Category("QuickReport设置"), Description("快捷报表的ID。若有多个报表，则以逗号分隔。")]
        public virtual string ReportIDs
        {
            get
            {
                return reportIDs;
            }
            set
            {
                reportIDs = value;
                if (reportIDs.Trim() == string.Empty)
                    return;
                reportIDs = reportIDs.Trim();
                reportIDs = reportIDs.Replace("\n", "").Replace("\r", "").Replace("，", ",");
            }
        }

        [Category("QuickReport设置"), Description("设置为true后，弹出当前快捷报表的编辑界面。")]
        public bool EditReport
        {
            get
            {
                return false;
            }
            set
            {
                if (!value)
                    return;
                if (tabControlReports.SelectedTab != null && tabControlReports.SelectedTab.Tag != null)
                    Edit(tabControlReports.SelectedTab.Tag as QuickReportCore.Objects.QuickReportObject);
            }
        }

        public static void ShowReports(string[] reportIDs)
        {
            QuickReportCore.QuickReportShow show = new QuickReportShow();
            Forms.frmTestReport frm = new QuickReportCore.Forms.frmTestReport(show);
            show.LoadReports(reportIDs);
            frm.ShowDialog();
            frm.Dispose();
        }

        private string Err
        {
            get
            {
                if (tabControlReports.SelectedIndex < 0)
                    return string.Empty;
                else
                    return reports[tabControlReports.SelectedIndex].Err;
            }
        }
 
        private void LoadReports(string[] reportIDs)
        {
            List<QuickReportCore.Objects.QuickReportObject> quickReportList = new List<QuickReportCore.Objects.QuickReportObject>();
            for (int i = 0; i < reportIDs.Length; i++)
            {
                if (reportIDs[i].Trim() == string.Empty)
                    continue;
                QuickReportCore.Objects.QuickReportObject qr = qrManager.QueryReportByID(reportIDs[i]);
                if (qr != null &&qr.ID.Trim()!=string.Empty&& qr.ID == reportIDs[i])
                    quickReportList.Add(qr);
            }
            if (quickReportList.Count == 0)
                return;
            tabControlReports.TabPages.Clear();
            reports = new QuickReportCore.Controls.Report.ucReportV100[quickReportList.Count];
            for (int i = 0; i < quickReportList.Count; i++)
            {
                System.Windows.Forms.TabPage tabPage = new TabPage();
                tabPage.Text = quickReportList[i].Name;
                tabPage.Tag = quickReportList[i];
                Interfaces.IAmReport report = Managers.Functions.GetPerfectReportControl(quickReportList[i].Version);
                if (report == null)
                    continue;
                tabPage.Controls.Add(report as Control);
                (report as Control).Dock = DockStyle.Fill;
                tabControlReports.TabPages.Add(tabPage);
                report.LoadReport(quickReportList[i]);
                reports[i] = report;
            }
        }

        private void Edit(QuickReportCore.Objects.QuickReportObject report)
        {
            QuickReportCore.Forms.frmQuickReportEditor frm = new QuickReportCore.Forms.frmQuickReportEditor();
            frm.LoadQuickReport(report);
            frm.Text = report.Name + " - 编辑报表";
            frm.ShowDialog();
            frm.Dispose();
        }

        private void QuickReportShow_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            try
            {
                LoadReports(ReportIDs.Split(','));
            }
            catch(Exception excp)
            {
                MessageBox.Show("报表加载失败。\n原因：" + excp.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);    
            }
        }

        public int SettingForTest()
        {
            if (tabControlReports.SelectedIndex < 0)
                return -1;
            reports[tabControlReports.SelectedIndex].ShowSetting();
            return 1;
        }

        public override int SetPrint(object sender, object neuObject)
        {
            if (tabControlReports.SelectedIndex < 0)
                return -1;
            reports[tabControlReports.SelectedIndex].ShowSetting();
            return 1;
        }

        public int QueryForTest()
        {
            return Query();
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            int i= Query();
            if (i < 0)
                MessageBox.Show(Err);
            return i;
        }

        public int PrintForTest()
        {
            if (tabControlReports.SelectedIndex < 0)
                return -1;
            return reports[tabControlReports.SelectedIndex].Print();
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            if (tabControlReports.SelectedIndex < 0)
                return -1;
            return reports[tabControlReports.SelectedIndex].Print();
        }

        private int Query()
        {
            if (tabControlReports.SelectedIndex < 0)
                return 0;
            return reports[tabControlReports.SelectedIndex].Query();
        }

        public int ExportForTest()
        {
            return Export();
        }

        private int Export()
        {
            if (tabControlReports.SelectedIndex < 0)
                return 0;
            return reports[tabControlReports.SelectedIndex].Export();
        }

        public override int Export(object sender, object neuObject)
        {
            return Export();
        }
    }
}
