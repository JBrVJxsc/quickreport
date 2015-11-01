namespace QuickReportLib.Controls
{
    partial class UserControlOfReportTree
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlOfReportTree));
            this.tabReportTree = new System.Windows.Forms.TabControl();
            this.tabPageReportTree = new System.Windows.Forms.TabPage();
            this.reportTree = new QuickReportLib.Controls.ReportTree();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabReportTree.SuspendLayout();
            this.tabPageReportTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabReportTree
            // 
            this.tabReportTree.Controls.Add(this.tabPageReportTree);
            this.tabReportTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabReportTree.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabReportTree.ImageList = this.imageList;
            this.tabReportTree.Location = new System.Drawing.Point(0, 0);
            this.tabReportTree.Name = "tabReportTree";
            this.tabReportTree.SelectedIndex = 0;
            this.tabReportTree.Size = new System.Drawing.Size(255, 403);
            this.tabReportTree.TabIndex = 1;
            // 
            // tabPageReportTree
            // 
            this.tabPageReportTree.Controls.Add(this.reportTree);
            this.tabPageReportTree.ImageIndex = 0;
            this.tabPageReportTree.Location = new System.Drawing.Point(4, 26);
            this.tabPageReportTree.Name = "tabPageReportTree";
            this.tabPageReportTree.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReportTree.Size = new System.Drawing.Size(247, 373);
            this.tabPageReportTree.TabIndex = 0;
            this.tabPageReportTree.Text = "报表目录";
            this.tabPageReportTree.UseVisualStyleBackColor = true;
            // 
            // reportTree
            // 
            this.reportTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportTree.HideSelection = false;
            this.reportTree.ImageIndex = 0;
            this.reportTree.Location = new System.Drawing.Point(3, 3);
            this.reportTree.Name = "reportTree";
            this.reportTree.SelectedImageIndex = 0;
            this.reportTree.Size = new System.Drawing.Size(241, 367);
            this.reportTree.TabIndex = 2;
            this.reportTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.reportTree_NodeMouseDoubleClick);
            this.reportTree.ReportDeleted += new QuickReportLib.Controls.ReportDeletedHandle(this.reportTree_ReportDeleted);
            this.reportTree.GlobalValueChanged += new QuickReportLib.Interfaces.GlobalValue.GlobalValueChangedHandle(this.reportTree_GloalValueChanged);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "ReportCatalog.png");
            // 
            // UserControlOfReportTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            
            this.Controls.Add(this.tabReportTree);
            this.Name = "UserControlOfReportTree";
            this.Size = new System.Drawing.Size(255, 403);
            this.tabReportTree.ResumeLayout(false);
            this.tabPageReportTree.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabReportTree;
        private System.Windows.Forms.TabPage tabPageReportTree;
        private ReportTree reportTree;
        private System.Windows.Forms.ImageList imageList;
    }
}
