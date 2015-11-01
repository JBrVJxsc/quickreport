using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace QuickReport
{
    public partial class QuickReportList : Form
    {
        private List<QuickReport.Objects.QuickReportObject> quickReportList = new List<QuickReport.Objects.QuickReportObject>();
        private QuickReport.Managers.QuickReportManager quickReportManager = new QuickReport.Managers.QuickReportManager();

        public QuickReportList()
        {
            InitializeComponent();
        }

        private void LoadQuickReports()
        {
            CheckDataBase();
            quickReportList = quickReportManager.QueryAllQuickReports();
            ShowQuickReportsOnTree(quickReportList);
            tvReports.ExpandAll();
        }

        private void ShowQuickReportsOnTree(List<QuickReport.Objects.QuickReportObject> list)
        {
            tvReports.Nodes.Clear();
            string root = "";
            Hashtable rootNodes = new Hashtable();
            foreach (QuickReport.Objects.QuickReportObject quickReport in list)
            {
                TreeNode sonNode = new TreeNode();
                sonNode.Text = quickReport.Name+"【"+quickReport.ID+"】";
                sonNode.Tag = quickReport;
                if (quickReport.Type != root)
                {
                    TreeNode rootNode = new TreeNode();
                    rootNode.Text = quickReport.Type;
                    rootNode.Nodes.AddRange(new TreeNode[] { sonNode });
                    rootNodes.Add(rootNode.Text, rootNode);
                    root = rootNode.Text;
                }
                else
                {
                    ((TreeNode)rootNodes[quickReport.Type]).Nodes.AddRange(new TreeNode[] { sonNode });
                }
            }
            foreach (DictionaryEntry de in rootNodes)
            {
                tvReports.Nodes.Add((TreeNode)de.Value);
            }
        }

        /// <summary>
        /// 检测数据库中是否存在所需表与序列。
        /// </summary>
        private void CheckDataBase()
        {
            if (quickReportManager.QueryTableExistQUICKREPORT_REPORTS() <= 0)
                if (quickReportManager.CreateTableQUICKREPORT_REPORTS() < 0)
                    goto Err;
            if (quickReportManager.QuerySeqExistSEQ_QR_QUICKREPORTS_ID() <= 0)
                if (quickReportManager.CreateSeqSEQ_QR_QUICKREPORTS_ID() < 0)
                    goto Err;
            return;
        Err:
            {
                MessageBox.Show(quickReportManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        #region 事件
        private void frmQuickReportEditor_Load(object sender, EventArgs e)
        {
            LoadQuickReports();
        }

        private void tbAdd_Click(object sender, EventArgs e)
        {
            Forms.frmQuickReportEditor frm = new QuickReport.Forms.frmQuickReportEditor();
            frm.Init();
            frm.Text = " - 编辑报表";
            frm.ShowDialog();
            frm.Dispose();
            LoadQuickReports();
        }

        private void tbDel_Click(object sender, EventArgs e)
        {
            if (tvReports.SelectedNode == null || tvReports.SelectedNode.Tag == null)
                return;
            QuickReport.Objects.QuickReportObject qr = tvReports.SelectedNode.Tag as QuickReport.Objects.QuickReportObject;
            if (qr == null)
                return;
            DialogResult result = MessageBox.Show("确认要删除 " + qr.Name + " 吗？", "删除快捷报表", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (quickReportManager.DeleteQuickReportByID(qr.ID) < 0)
                {
                    QuickReport.Managers.Functions.ShowToolTip(toolStrip, "删除失败。\n" + quickReportManager.Err, new Point(toolStrip.Location.X + tbAdd.Width, toolStrip.Location.Y + tbDel.Height));
                    return;
                }
            }
            else
                return;
            LoadQuickReports();
        }
        #endregion

        private void QuickReportList_KeyDown(object sender, KeyEventArgs e)
        {
            if (tvReports.SelectedNode == null || tvReports.SelectedNode.Tag == null)
                return;
            if (e.KeyCode == Keys.Enter)
            {
                Forms.frmQuickReportEditor frm = new QuickReport.Forms.frmQuickReportEditor();
                frm.LoadQuickReport((QuickReport.Objects.QuickReportObject)tvReports.SelectedNode.Tag);
                frm.Text = ((QuickReport.Objects.QuickReportObject)tvReports.SelectedNode.Tag).Name + " - 编辑报表";
                frm.ShowDialog();
                frm.Dispose();
                LoadQuickReports();
            }
        }

        private void tvReports_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null)
                return;
            Forms.frmQuickReportEditor frm = new QuickReport.Forms.frmQuickReportEditor();
            frm.LoadQuickReport((QuickReport.Objects.QuickReportObject)e.Node.Tag);
            frm.Text = ((QuickReport.Objects.QuickReportObject)e.Node.Tag).Name + " - 编辑报表";
            frm.ShowDialog();
            frm.Dispose();
            LoadQuickReports();
        }
    }
}