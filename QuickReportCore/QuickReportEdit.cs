using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace QuickReportCore
{
    public partial class QuickReportEdit : Form
    {
        private List<QuickReportCore.Objects.QuickReportObject> quickReportList = new List<QuickReportCore.Objects.QuickReportObject>();
        private QuickReportCore.Managers.QuickReportManager quickReportManager = new QuickReportCore.Managers.QuickReportManager();

        public QuickReportEdit()
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

        private void ShowQuickReportsOnTree(List<QuickReportCore.Objects.QuickReportObject> list)
        {
            tvReports.Nodes.Clear();
            cmbReports.Items.Clear();
            string root = "";
            Hashtable rootNodes = new Hashtable();
            foreach (QuickReportCore.Objects.QuickReportObject quickReport in list)
            {
                cmbReports.Items.Add(quickReport);
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
            if (quickReportManager.QueryTableExistQUICKREPORT_SETTINGS() <= 0)
                if (quickReportManager.CreateTableQUICKREPORT_SETTINGS() < 0)
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
        private void QuickReportEdit_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            LoadQuickReports();
        }

        private void tbAdd_Click(object sender, EventArgs e)
        {
            QuickReportCore.Forms.frmQuickReportEditor frm = new QuickReportCore.Forms.frmQuickReportEditor();
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
            QuickReportCore.Objects.QuickReportObject qr = tvReports.SelectedNode.Tag as QuickReportCore.Objects.QuickReportObject;
            if (qr == null)
                return;
            DialogResult result = MessageBox.Show("确认要删除 " + qr.Name + " 吗？", "删除快捷报表", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (quickReportManager.DeleteQuickReportByID(qr.ID) < 0)
                {
                    QuickReportCore.Managers.Functions.ShowToolTip(toolStrip, "删除失败。\n" + quickReportManager.Err, new Point(toolStrip.Location.X + tbAdd.Width, toolStrip.Location.Y + tbDel.Height));
                    return;
                }
            }
            else
                return;
            LoadQuickReports();
        }
        #endregion

        private void QuickReportEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (tvReports.SelectedNode == null || tvReports.SelectedNode.Tag == null)
                return;
            if (e.KeyCode == Keys.Enter)
                ShowReport(tvReports.SelectedNode.Tag as QuickReportCore.Objects.QuickReportObject);
        }

        private void tvReports_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null)
                return;
            ShowReport(e.Node.Tag as QuickReportCore.Objects.QuickReportObject);
        }

        private void cmbReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReports.SelectedItem == null || cmbReports.SelectedItem as QuickReportCore.Objects.QuickReportObject == null)
                return;
            ShowReport(cmbReports.SelectedItem as QuickReportCore.Objects.QuickReportObject);
        }

        private void ShowReport(QuickReportCore.Objects.QuickReportObject quickReport)
        {
            QuickReportCore.Forms.frmQuickReportEditor frm = new QuickReportCore.Forms.frmQuickReportEditor();
            frm.LoadQuickReport(quickReport);
            frm.Text = quickReport.Name + " - 编辑报表";
            frm.ShowDialog();
            frm.Dispose();
            LoadQuickReports();
        }

        private void ExportReport()
        {
            if (tvReports.SelectedNode == null || tvReports.SelectedNode.Tag == null)
                return;
            saveFileDialog.FileName =(tvReports.SelectedNode.Tag as Objects.QuickReportObject).Type +"-"+ (tvReports.SelectedNode.Tag as Objects.QuickReportObject).Name;
            DialogResult dr = saveFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (saveFileDialog.FileName == string.Empty)
                    return;
                Objects.QuickReportObject quickReport = new QuickReportCore.Objects.QuickReportObject();
                quickReport = quickReportManager.QueryReportByID((tvReports.SelectedNode.Tag as Objects.QuickReportObject).ID);
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                try
                {
                    sw.Write(quickReport.Content);
                    sw.Close();
                }
                catch(Exception e)
                {
                    QuickReportCore.Managers.Functions.ShowToolTip(toolStrip, "导出失败。\n"+e.Message, new Point(toolStrip.Location.X + tbAdd.Width + tbDel.Width, toolStrip.Location.Y + tbDel.Height));
                    sw.Close();
                    return;
                }
                QuickReportCore.Managers.Functions.ShowToolTip(toolStrip, "导出成功。\n" , new Point(toolStrip.Location.X + tbAdd.Width+tbDel.Width, toolStrip.Location.Y + tbDel.Height));
            }
        }

        private void tbExport_Click(object sender, EventArgs e)
        {
            tbExport.Enabled = false;
            ExportReport();
            tbExport.Enabled = true;
        }

        private void ImportReport()
        {
            DialogResult dr = openFileDialog.ShowDialog();
            if (dr== DialogResult.OK)
            {
                if (openFileDialog.FileName == string.Empty)
                    return;
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                string content = string.Empty;
                try
                {
                    content =sr.ReadToEnd();
                    sr.Close();
                }
                catch(Exception e)
                {
                    QuickReportCore.Managers.Functions.ShowToolTip(toolStrip, "导入失败。\n" + e.Message, new Point(toolStrip.Location.X + tbAdd.Width + tbDel.Width + tbExport.Width, toolStrip.Location.Y + tbDel.Height));
                    sr.Close();
                    return;
                }
                QuickReportCore.Forms.frmQuickReportEditor frm = new QuickReportCore.Forms.frmQuickReportEditor();
                Objects.QuickReportObject quickReport = new QuickReportCore.Objects.QuickReportObject();
                quickReport.Content = content;
                frm.LoadQuickReport(quickReport);
                frm.Text = quickReport.Name + " - 编辑报表";
                frm.NeedSave(true);
                frm.ShowDialog();
                frm.Dispose();
                LoadQuickReports();
            }
        }

        private void tbImport_Click(object sender, EventArgs e)
        {
            tbImport.Enabled = false;
            ImportReport();
            tbImport.Enabled = true;
        }
    }
}