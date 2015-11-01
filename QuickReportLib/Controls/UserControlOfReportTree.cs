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
        /// ����˫��ѡ�к󴥷����¼���
        /// </summary>
        public event ReportSelectedHandle ReportSelected;

        /// <summary>
        /// ����ɾ�������������¼���
        /// </summary>
        public event ReportDeletedHandle ReportDeleted;


        private ToolStripItem[] toolStripItemList;

        /// <summary>
        /// ��õ�ǰ����ʾ�ı���
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
        /// ��������
        /// </summary>
        public void Export()
        {
            reportTree.Export();
        }

        /// <summary>
        /// ɾ����ǰѡ�еı���
        /// </summary>
        public void Delete()
        {
            reportTree.Delete();
        }

        /// <summary>
        /// ˢ�±���
        /// </summary>
        public void RefreshReport()
        {
            reportTree.RefreshReport();
        }

        #region IGlobalValueProvider ��Ա

        public event GlobalValueChangedHandle GlobalValueChanged;

        #endregion

        #region IToolStripMenuProvider ��Ա

        public event ProvideToolStripMenuHandle ProvideToolStripMenu;

        #endregion
    }

    /// <summary>
    /// ���������ı���ڵ㱻˫��ѡ���ִ�еķ�����
    /// </summary>
    /// <param name="sender">�¼�Դ��</param>
    /// <param name="report">��˫��ѡ�еı���</param>
    internal delegate void ReportSelectedHandle(object sender, Report report);
}
