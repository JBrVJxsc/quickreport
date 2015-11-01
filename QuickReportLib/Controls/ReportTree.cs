using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using QuickReportLib.Controls.Plus;
using QuickReportLib.Objects;
using QuickReportLib.Managers;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Objects.GlobalValue;
using QuickReportLib.Interfaces;

namespace QuickReportLib.Controls
{
    /// <summary>
    /// 用来显示数据库中所有报表的树。
    /// </summary>
    internal partial class ReportTree : TreeViewPlus , IGlobalValueProvider 
    {
        public ReportTree()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 报表被删除后所触发的事件。
        /// </summary>
        public event ReportDeletedHandle ReportDeleted;

        private DataBaseManager dataBaseManager = new DataBaseManager();
        private List<Report> reportList;
        private ReportGlobalValue reportGlobalValue = new ReportGlobalValue();

        /// <summary>
        /// 获取当前选中的报表。
        /// </summary>
        public Report SelectedReport
        {
            get
            {
                if (SelectedNode == null)
                {
                    return null;
                }
                return SelectedNode.Tag as Report;
            }
        }

        /// <summary>
        /// 获得当前所显示的报表。
        /// </summary>
        /// <returns>当前所显示的报表。</returns>
        public List<Report> GetReportList()
        {
            return reportList;
        }

        /// <summary>
        /// 初始化报表树。
        /// </summary>
        public void Init()
        {
            reportList = dataBaseManager.QueryAllQuickReports();
            if (reportList.Count > 0)
            {
                ShowReports(reportList);
            }
        }

        private void ShowReports(List<Report> reportList)
        {
            Nodes.Clear();
            if (reportList.Count == 0)
            {
                goto End;
            }
            string compareString = Constants.Constants.COMPARE_STRING;
            Hashtable rootNodes = new Hashtable();
            foreach (Report report in reportList)
            {
                TreeNode sonNode = new TreeNode();
                sonNode.Text = report.Name;
                sonNode.ImageIndex = 0;
                sonNode.SelectedImageIndex=1;
                sonNode.Tag = report;
                if (report.Type != compareString)
                {
                    TreeNode rootNode = new TreeNode();
                    rootNode.Text = report.Type;
                    rootNode.ImageIndex = 2;
                    rootNode.SelectedImageIndex = 3;
                    rootNode.Nodes.Add(sonNode);
                    rootNodes.Add(rootNode.Text, rootNode);
                    compareString = rootNode.Text;
                }
                else
                {
                    TreeNode rootNode=rootNodes[report.Type] as TreeNode;
                    rootNode.Nodes.Add(sonNode);
                }
            }
            foreach (DictionaryEntry de in rootNodes)
            {
                Nodes.Add(de.Value as TreeNode);
            }

        End:
            reportGlobalValue.Value = new List<BaseObject>();
            foreach (Report report in reportList)
            {
                reportGlobalValue.Value.Add(report);
            }
            if (GlobalValueChanged != null)
            {
                GlobalValueChanged(this, reportGlobalValue);
            }
        }

        /// <summary>
        /// 导出报表。
        /// </summary>
        public void Export()
        {
            
        }
        
        /// <summary>
        /// 删除选中的报表。
        /// </summary>
        public void Delete()
        {
            Report report = SelectedReport;
            if (report != null)
            {
                DialogResult dr = MessageBox.Show("确认要删除 " + report.Name + " 吗？", "删除报表", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes)
                {
                    return;
                }
                dataBaseManager.DeleteQuickReportByID(report.ID);
                if (ReportDeleted != null)
                {
                    ReportDeleted(this, report);
                }
                RefreshReport();
            }
        }

        /// <summary>
        /// 刷新报表。
        /// </summary>
        public void RefreshReport()
        {
            reportList = dataBaseManager.QueryAllQuickReports();
            if (reportList!=null)
            {
                ShowReports(reportList);
            }
        }

        #region IGlobalValueProvider 成员

        public event GlobalValueChangedHandle GlobalValueChanged;

        #endregion
    }

    /// <summary>
    /// 删除报表时所执行的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="report">报表实体。</param>
    internal delegate void ReportDeletedHandle(object sender, Report report);
}
