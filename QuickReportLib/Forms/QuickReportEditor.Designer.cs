namespace QuickReportLib.Forms
{
    partial class QuickReportEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickReportEditor));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.msMainFile = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainFileDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.msMainFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainFileSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.msMainFileImport = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainFileExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.msMainFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainTools = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainToolsSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainToolsPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainHelpDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsMainNew = new System.Windows.Forms.ToolStripButton();
            this.tsMainDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMainSave = new System.Windows.Forms.ToolStripButton();
            this.tsMainSaveAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMainImport = new System.Windows.Forms.ToolStripButton();
            this.tsMainExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsMainSearch = new QuickReportLib.Controls.Plus.ToolStripComboBoxPlus();
            this.tsMainPreview = new System.Windows.Forms.ToolStripButton();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.ssMainHelp = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsForUserControl = new System.Windows.Forms.ToolStrip();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.userControlOfReportTree = new QuickReportLib.Controls.UserControlOfReportTree();
            this.reportTabControl = new QuickReportLib.Controls.ReportTabControl();
            this.msMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMainFile,
            this.msMainTools,
            this.msMainHelp});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(906, 25);
            this.msMain.TabIndex = 0;
            // 
            // msMainFile
            // 
            this.msMainFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMainFileNew,
            this.msMainFileDelete,
            this.toolStripSeparator1,
            this.msMainFileSave,
            this.msMainFileSaveAll,
            this.toolStripSeparator2,
            this.msMainFileImport,
            this.msMainFileExport,
            this.toolStripSeparator3,
            this.msMainFileExit});
            this.msMainFile.Name = "msMainFile";
            this.msMainFile.ShortcutKeyDisplayString = "";
            this.msMainFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.msMainFile.Size = new System.Drawing.Size(58, 21);
            this.msMainFile.Text = "文件(&F)";
            // 
            // msMainFileNew
            // 
            this.msMainFileNew.Image = global::QuickReportLib.Properties.Resources.New;
            this.msMainFileNew.Name = "msMainFileNew";
            this.msMainFileNew.ShortcutKeyDisplayString = "";
            this.msMainFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.msMainFileNew.Size = new System.Drawing.Size(202, 22);
            this.msMainFileNew.Text = "新建";
            this.msMainFileNew.Click += new System.EventHandler(this.msMainFileNew_Click);
            // 
            // msMainFileDelete
            // 
            this.msMainFileDelete.Image = global::QuickReportLib.Properties.Resources.Delete;
            this.msMainFileDelete.Name = "msMainFileDelete";
            this.msMainFileDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.msMainFileDelete.Size = new System.Drawing.Size(202, 22);
            this.msMainFileDelete.Text = "删除";
            this.msMainFileDelete.Click += new System.EventHandler(this.msMainFileDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // msMainFileSave
            // 
            this.msMainFileSave.Image = global::QuickReportLib.Properties.Resources.Save;
            this.msMainFileSave.Name = "msMainFileSave";
            this.msMainFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.msMainFileSave.Size = new System.Drawing.Size(202, 22);
            this.msMainFileSave.Text = "保存";
            this.msMainFileSave.Click += new System.EventHandler(this.msMainFileSave_Click);
            // 
            // msMainFileSaveAll
            // 
            this.msMainFileSaveAll.Image = global::QuickReportLib.Properties.Resources.SaveAll;
            this.msMainFileSaveAll.Name = "msMainFileSaveAll";
            this.msMainFileSaveAll.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.msMainFileSaveAll.Size = new System.Drawing.Size(202, 22);
            this.msMainFileSaveAll.Text = "全部保存";
            this.msMainFileSaveAll.Click += new System.EventHandler(this.msMainFileSaveAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
            // 
            // msMainFileImport
            // 
            this.msMainFileImport.Image = global::QuickReportLib.Properties.Resources.Import;
            this.msMainFileImport.Name = "msMainFileImport";
            this.msMainFileImport.ShortcutKeyDisplayString = "";
            this.msMainFileImport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.msMainFileImport.Size = new System.Drawing.Size(202, 22);
            this.msMainFileImport.Text = "导入";
            this.msMainFileImport.Click += new System.EventHandler(this.msMainFileImport_Click);
            // 
            // msMainFileExport
            // 
            this.msMainFileExport.Image = global::QuickReportLib.Properties.Resources.Export;
            this.msMainFileExport.Name = "msMainFileExport";
            this.msMainFileExport.ShortcutKeyDisplayString = "";
            this.msMainFileExport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.msMainFileExport.Size = new System.Drawing.Size(202, 22);
            this.msMainFileExport.Text = "导出";
            this.msMainFileExport.Click += new System.EventHandler(this.msMainFileExport_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(199, 6);
            // 
            // msMainFileExit
            // 
            this.msMainFileExit.Image = global::QuickReportLib.Properties.Resources.Exit;
            this.msMainFileExit.Name = "msMainFileExit";
            this.msMainFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.msMainFileExit.Size = new System.Drawing.Size(202, 22);
            this.msMainFileExit.Text = "退出";
            this.msMainFileExit.Click += new System.EventHandler(this.msMainFileExit_Click);
            // 
            // msMainTools
            // 
            this.msMainTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMainToolsSearch,
            this.msMainToolsPreview});
            this.msMainTools.Name = "msMainTools";
            this.msMainTools.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.msMainTools.Size = new System.Drawing.Size(59, 21);
            this.msMainTools.Text = "工具(&T)";
            // 
            // msMainToolsSearch
            // 
            this.msMainToolsSearch.Image = global::QuickReportLib.Properties.Resources.Query;
            this.msMainToolsSearch.Name = "msMainToolsSearch";
            this.msMainToolsSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.msMainToolsSearch.Size = new System.Drawing.Size(163, 22);
            this.msMainToolsSearch.Text = "查找报表";
            this.msMainToolsSearch.Click += new System.EventHandler(this.msMainToolsSearch_Click);
            // 
            // msMainToolsPreview
            // 
            this.msMainToolsPreview.Image = global::QuickReportLib.Properties.Resources.Preview;
            this.msMainToolsPreview.Name = "msMainToolsPreview";
            this.msMainToolsPreview.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.msMainToolsPreview.Size = new System.Drawing.Size(163, 22);
            this.msMainToolsPreview.Text = "预览";
            this.msMainToolsPreview.Click += new System.EventHandler(this.msMainToolsPreview_Click);
            // 
            // msMainHelp
            // 
            this.msMainHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMainHelpDocument,
            this.msMainHelpAbout});
            this.msMainHelp.Name = "msMainHelp";
            this.msMainHelp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.msMainHelp.Size = new System.Drawing.Size(61, 21);
            this.msMainHelp.Text = "帮助(&H)";
            // 
            // msMainHelpDocument
            // 
            this.msMainHelpDocument.Image = global::QuickReportLib.Properties.Resources.Document;
            this.msMainHelpDocument.Name = "msMainHelpDocument";
            this.msMainHelpDocument.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.msMainHelpDocument.Size = new System.Drawing.Size(140, 22);
            this.msMainHelpDocument.Text = "文档";
            this.msMainHelpDocument.Click += new System.EventHandler(this.msMainHelpDocument_Click);
            // 
            // msMainHelpAbout
            // 
            this.msMainHelpAbout.Image = ((System.Drawing.Image)(resources.GetObject("msMainHelpAbout.Image")));
            this.msMainHelpAbout.Name = "msMainHelpAbout";
            this.msMainHelpAbout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.msMainHelpAbout.Size = new System.Drawing.Size(140, 22);
            this.msMainHelpAbout.Text = "关于";
            this.msMainHelpAbout.Click += new System.EventHandler(this.msMainHelpAbout_Click);
            // 
            // tsMain
            // 
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMainNew,
            this.tsMainDelete,
            this.toolStripSeparator4,
            this.tsMainSave,
            this.tsMainSaveAll,
            this.toolStripSeparator5,
            this.tsMainImport,
            this.tsMainExport,
            this.toolStripSeparator6,
            this.toolStripLabel1,
            this.tsMainSearch,
            this.tsMainPreview});
            this.tsMain.Location = new System.Drawing.Point(0, 25);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(906, 39);
            this.tsMain.TabIndex = 1;
            // 
            // tsMainNew
            // 
            this.tsMainNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsMainNew.Image = global::QuickReportLib.Properties.Resources.New;
            this.tsMainNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMainNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMainNew.Name = "tsMainNew";
            this.tsMainNew.Size = new System.Drawing.Size(36, 36);
            this.tsMainNew.Text = "新建";
            this.tsMainNew.Click += new System.EventHandler(this.tsMainNew_Click);
            // 
            // tsMainDelete
            // 
            this.tsMainDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsMainDelete.Image = global::QuickReportLib.Properties.Resources.Delete;
            this.tsMainDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMainDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMainDelete.Name = "tsMainDelete";
            this.tsMainDelete.Size = new System.Drawing.Size(36, 36);
            this.tsMainDelete.Text = "删除";
            this.tsMainDelete.Click += new System.EventHandler(this.tsMainDelete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // tsMainSave
            // 
            this.tsMainSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsMainSave.Image = global::QuickReportLib.Properties.Resources.Save;
            this.tsMainSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMainSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMainSave.Name = "tsMainSave";
            this.tsMainSave.Size = new System.Drawing.Size(36, 36);
            this.tsMainSave.Text = "保存";
            this.tsMainSave.Click += new System.EventHandler(this.tsMainSave_Click);
            // 
            // tsMainSaveAll
            // 
            this.tsMainSaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsMainSaveAll.Image = global::QuickReportLib.Properties.Resources.SaveAll;
            this.tsMainSaveAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMainSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMainSaveAll.Name = "tsMainSaveAll";
            this.tsMainSaveAll.Size = new System.Drawing.Size(36, 36);
            this.tsMainSaveAll.Text = "全部保存";
            this.tsMainSaveAll.Click += new System.EventHandler(this.tsMainSaveAll_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // tsMainImport
            // 
            this.tsMainImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsMainImport.Image = global::QuickReportLib.Properties.Resources.Import;
            this.tsMainImport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMainImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMainImport.Name = "tsMainImport";
            this.tsMainImport.Size = new System.Drawing.Size(36, 36);
            this.tsMainImport.Text = "导入";
            this.tsMainImport.Click += new System.EventHandler(this.tsMainImport_Click);
            // 
            // tsMainExport
            // 
            this.tsMainExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsMainExport.Image = global::QuickReportLib.Properties.Resources.Export;
            this.tsMainExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMainExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMainExport.Name = "tsMainExport";
            this.tsMainExport.Size = new System.Drawing.Size(36, 36);
            this.tsMainExport.Text = "导出";
            this.tsMainExport.Click += new System.EventHandler(this.tsMainExport_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 36);
            this.toolStripLabel1.Text = "查找报表";
            this.toolStripLabel1.Visible = false;
            // 
            // tsMainSearch
            // 
            this.tsMainSearch.ColumnShowState = QuickReportLib.Enums.ComboBoxPlusColumnShowState.Both;
            this.tsMainSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsMainSearch.FilterName = "查找报表";
            this.tsMainSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tsMainSearch.Name = "tsMainSearch";
            this.tsMainSearch.Size = new System.Drawing.Size(121, 39);
            this.tsMainSearch.Visible = false;
            // 
            // tsMainPreview
            // 
            this.tsMainPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsMainPreview.Image = global::QuickReportLib.Properties.Resources.Preview;
            this.tsMainPreview.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMainPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMainPreview.Name = "tsMainPreview";
            this.tsMainPreview.Size = new System.Drawing.Size(36, 36);
            this.tsMainPreview.Text = "预览";
            this.tsMainPreview.Click += new System.EventHandler(this.tsMainPreview_Click);
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssMainHelp});
            this.ssMain.Location = new System.Drawing.Point(0, 456);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(906, 22);
            this.ssMain.TabIndex = 2;
            this.ssMain.Text = "statusStrip1";
            // 
            // ssMainHelp
            // 
            this.ssMainHelp.Name = "ssMainHelp";
            this.ssMainHelp.Size = new System.Drawing.Size(0, 17);
            // 
            // tsForUserControl
            // 
            this.tsForUserControl.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsForUserControl.Location = new System.Drawing.Point(0, 64);
            this.tsForUserControl.Name = "tsForUserControl";
            this.tsForUserControl.Size = new System.Drawing.Size(906, 25);
            this.tsForUserControl.TabIndex = 7;
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 89);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.userControlOfReportTree);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.reportTabControl);
            this.scMain.Size = new System.Drawing.Size(906, 367);
            this.scMain.SplitterDistance = 212;
            this.scMain.TabIndex = 8;
            // 
            // userControlOfReportTree
            // 
            this.userControlOfReportTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlOfReportTree.Location = new System.Drawing.Point(0, 0);
            this.userControlOfReportTree.Name = "userControlOfReportTree";
            this.userControlOfReportTree.Size = new System.Drawing.Size(212, 367);
            this.userControlOfReportTree.TabIndex = 0;
            this.userControlOfReportTree.ReportSelected += new QuickReportLib.Controls.ReportSelectedHandle(this.userControlOfReportTree_ReportSelected);
            this.userControlOfReportTree.ReportDeleted += new QuickReportLib.Controls.ReportDeletedHandle(this.userControlOfReportTree_ReportDeleted);
            // 
            // reportTabControl
            // 
            this.reportTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportTabControl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reportTabControl.Location = new System.Drawing.Point(0, 0);
            this.reportTabControl.Name = "reportTabControl";
            this.reportTabControl.SelectedIndex = 0;
            this.reportTabControl.Size = new System.Drawing.Size(690, 367);
            this.reportTabControl.TabIndex = 0;
            this.reportTabControl.SelectedIndexChanged += new System.EventHandler(this.reportTabControl_SelectedIndexChanged);
            this.reportTabControl.ReportTablePageClosed += new QuickReportLib.Controls.ReportTablePageClosedHandle(this.reportTabControl_ReportTablePageClosed);
            // 
            // QuickReportEditor
            // 
            this.ClientSize = new System.Drawing.Size(906, 478);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.tsForUserControl);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.msMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "QuickReportEditor";
            this.ShowInTaskbar = false;
            this.SmokyOpacity = 1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuickReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem msMainFile;
        private System.Windows.Forms.ToolStripMenuItem msMainFileNew;
        private System.Windows.Forms.ToolStripMenuItem msMainFileImport;
        private System.Windows.Forms.ToolStripMenuItem msMainFileExport;
        private System.Windows.Forms.ToolStripMenuItem msMainFileDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem msMainFileSave;
        private System.Windows.Forms.ToolStripMenuItem msMainFileSaveAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem msMainFileExit;
        private System.Windows.Forms.ToolStripMenuItem msMainHelp;
        private System.Windows.Forms.ToolStripMenuItem msMainHelpDocument;
        private System.Windows.Forms.ToolStripMenuItem msMainHelpAbout;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsMainDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsMainSave;
        private System.Windows.Forms.ToolStripButton tsMainSaveAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsMainImport;
        private System.Windows.Forms.ToolStripButton tsMainExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private QuickReportLib.Controls.Plus.ToolStripComboBoxPlus tsMainSearch;
        private System.Windows.Forms.ToolStripMenuItem msMainTools;
        private System.Windows.Forms.ToolStripMenuItem msMainToolsPreview;
        private System.Windows.Forms.ToolStripMenuItem msMainToolsSearch;
        private System.Windows.Forms.ToolStripButton tsMainPreview;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel ssMainHelp;
        private System.Windows.Forms.ToolStripButton tsMainNew;
        private System.Windows.Forms.ToolStrip tsForUserControl;
        private System.Windows.Forms.SplitContainer scMain;
        private QuickReportLib.Controls.UserControlOfReportTree userControlOfReportTree;
        private QuickReportLib.Controls.ReportTabControl reportTabControl;

    }
}