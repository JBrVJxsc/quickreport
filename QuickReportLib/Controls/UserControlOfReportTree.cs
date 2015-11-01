using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects;
using QuickReportLib.Objects.GlobalValue;
using QuickReportLib.Interfaces;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Controls.Plus.IToolStripMenuProvider.UserControlOfReportTree;

namespace QuickReportLib.Controls
{
    internal partial class UserControlOfReportTree : BaseUserControl , IGlobalValueProvider , IToolStripMenuProvider
    {
        public UserControlOfReportTree()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 报表被双击选中后触发的事件。
        /// </summary>
        public event ReportSelectedHandle ReportSelected;

        /// <summary>
        /// 报表被删除后所触发的事件。
        /// </summary>
        public event ReportDeletedHandle ReportDeleted;


        private ToolStripItem[] toolStripItemList;

        /// <summary>
        /// 获得当前所显示的报表。
        /// </summary>
        public List<Report> ReportList
        {
            get
            {
                return reportTree.GetReportList();
            }
        }

        private void reportTree_GloalValueChanged(object sender, IGlobalValue globalValue)
        {
            if (GlobalValueChanged != null)
            {
                GlobalValueChanged(sender, globalValue);
            }
        }

        private void reportTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Report report = e.Node.Tag as Report;
            if (report == null)
            {
                return;
            }
            if (ReportSelected != null)
            {
                ReportSelected(sender, report);
            }
        }

        private void reportTree_ReportDeleted(object sender, Report report)
        {
            if (ReportDeleted != null)
            {
                ReportDeleted(sender, report);
            }
        }

        void tsButtomRefresh_Click(object sender, EventArgs e)
        {
            reportTree.RefreshReport();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            reportTree.Init();
            base.OnLoad(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            if (toolStripItemList == null)
            {
                toolStripItemList = new ToolStripItem[1];
                ToolStripButtonRefresh tsButtomRefresh = new ToolStripButtonRefresh();
                tsButtomRefresh.Click += new EventHandler(tsButtomRefresh_Click);
                toolStripItemList[0] = tsButtomRefresh;
            }
            if (ProvideToolStripMenu != null)
            {
                ProvideToolStripMenu(this, toolStripItemList);
            }
            base.OnEnter(e);
        }

        /// <summary>
        /// 导出报表。
        /// </summary>
        public void Export()
        {
            reportTree.Export();
        }

        /// <summary>
        /// 删除当前选中的报表。
        /// </summary>
        public void Delete()
        {
            reportTree.Delete();
        }

        /// <summary>
        /// 刷新报表。
        /// </summary>
        public void RefreshReport()
        {
            reportTree.RefreshReport();
        }

        #region IGlobalValueProvider 成员

        public event GlobalValueChangedHandle GlobalValueChanged;

        #endregion

        #region IToolStripMenuProvider 成员

        public event ProvideToolStripMenuHandle ProvideToolStripMenu;

        #endregion
    }

    /// <summary>
    /// 当报表树的报表节点被双击选择后，执行的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="report">被双击选中的报表。</param>
    internal delegate void ReportSelectedHandle(object sender, Report report);
}
