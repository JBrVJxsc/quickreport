namespace QuickReportCore
{
    partial class QuickReportEdit
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickReportEdit));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("子节点1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("根节点1", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("子节点2");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("根节点2", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbAdd = new System.Windows.Forms.ToolStripButton();
            this.tbDel = new System.Windows.Forms.ToolStripButton();
            this.tbExport = new System.Windows.Forms.ToolStripButton();
            this.tbImport = new System.Windows.Forms.ToolStripButton();
            this.tvReports = new System.Windows.Forms.TreeView();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.cmbReports = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbAdd,
            this.tbDel,
            this.tbExport,
            this.tbImport});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.ShowItemToolTips = false;
            this.toolStrip.Size = new System.Drawing.Size(296, 39);
            this.toolStrip.TabIndex = 7;
            // 
            // tbAdd
            // 
            this.tbAdd.Image = global::QuickReportCore.Properties.Resources.add_item;
            this.tbAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(68, 36);
            this.tbAdd.Text = "新建";
            this.tbAdd.Click += new System.EventHandler(this.tbAdd_Click);
            // 
            // tbDel
            // 
            this.tbDel.Image = global::QuickReportCore.Properties.Resources.delete_item;
            this.tbDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDel.Name = "tbDel";
            this.tbDel.Size = new System.Drawing.Size(68, 36);
            this.tbDel.Text = "删除";
            this.tbDel.Click += new System.EventHandler(this.tbDel_Click);
            // 
            // tbExport
            // 
            this.tbExport.Image = ((System.Drawing.Image)(resources.GetObject("tbExport.Image")));
            this.tbExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbExport.Name = "tbExport";
            this.tbExport.Size = new System.Drawing.Size(68, 36);
            this.tbExport.Text = "导出";
            this.tbExport.ToolTipText = "将快捷报表以XML文件形式导出。";
            this.tbExport.Click += new System.EventHandler(this.tbExport_Click);
            // 
            // tbImport
            // 
            this.tbImport.Image = ((System.Drawing.Image)(resources.GetObject("tbImport.Image")));
            this.tbImport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbImport.Name = "tbImport";
            this.tbImport.Size = new System.Drawing.Size(68, 36);
            this.tbImport.Text = "导入";
            this.tbImport.ToolTipText = "导入XML文件形式的快捷报表。";
            this.tbImport.Click += new System.EventHandler(this.tbImport_Click);
            // 
            // tvReports
            // 
            this.tvReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvReports.HideSelection = false;
            this.tvReports.Location = new System.Drawing.Point(0, 64);
            this.tvReports.Name = "tvReports";
            treeNode1.Name = "sun1";
            treeNode1.Text = "子节点1";
            treeNode2.Name = "root1";
            treeNode2.Text = "根节点1";
            treeNode3.Name = "sun2";
            treeNode3.Text = "子节点2";
            treeNode4.Name = "root2";
            treeNode4.Text = "根节点2";
            this.tvReports.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4});
            this.tvReports.Size = new System.Drawing.Size(296, 312);
            this.tvReports.TabIndex = 12;
            this.tvReports.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvReports_NodeMouseDoubleClick);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = " QuickReport (.qr)|*.qr";
            // 
            // cmbReports
            // 
            this.cmbReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReports.FilterName = "选择报表";
            this.cmbReports.FormattingEnabled = true;
            this.cmbReports.Location = new System.Drawing.Point(0, 39);
            this.cmbReports.Name = "cmbReports";
            this.cmbReports.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Both;
            this.cmbReports.Size = new System.Drawing.Size(296, 25);
            this.cmbReports.TabIndex = 11;
            this.cmbReports.SelectedIndexChanged += new System.EventHandler(this.cmbReports_SelectedIndexChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = " QuickReport (.qr)|*.qr";
            // 
            // QuickReportEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 376);
            this.Controls.Add(this.tvReports);
            this.Controls.Add(this.cmbReports);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuickReportEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "快捷报表";
            this.Load += new System.EventHandler(this.QuickReportEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QuickReportEdit_KeyDown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbAdd;
        private System.Windows.Forms.ToolStripButton tbDel;
        private System.Windows.Forms.ToolStripButton tbExport;
        private System.Windows.Forms.ToolStripButton tbImport;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbReports;
        private System.Windows.Forms.TreeView tvReports;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}