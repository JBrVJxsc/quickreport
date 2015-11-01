namespace QuickReportCore.Forms
{
    partial class frmQuickReportEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuickReportEditor));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.tbSave = new System.Windows.Forms.ToolStripButton();
            this.tbTest = new System.Windows.Forms.ToolStripButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageBaseInfo = new System.Windows.Forms.TabPage();
            this.grbEditSql = new System.Windows.Forms.GroupBox();
            this.txtReportSql = new System.Windows.Forms.TextBox();
            this.toolStripBaseInfo = new System.Windows.Forms.ToolStrip();
            this.tbEditSql = new System.Windows.Forms.ToolStripButton();
            this.pnlBaseInfo = new System.Windows.Forms.Panel();
            this.cmbReportType = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReportName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageColumn = new System.Windows.Forms.TabPage();
            this.ucColumnList = new QuickReportCore.Controls.ucColumnList();
            this.toolStripColumn = new System.Windows.Forms.ToolStrip();
            this.tbColumnUp = new System.Windows.Forms.ToolStripButton();
            this.tbColumnDown = new System.Windows.Forms.ToolStripButton();
            this.tabPageCondition = new System.Windows.Forms.TabPage();
            this.ucConditionList = new QuickReportCore.Controls.ucConditionList();
            this.toolStripCondition = new System.Windows.Forms.ToolStrip();
            this.tbConditionUp = new System.Windows.Forms.ToolStripButton();
            this.tbConditionDown = new System.Windows.Forms.ToolStripButton();
            this.tabPageReport = new System.Windows.Forms.TabPage();
            this.tabControlReport = new System.Windows.Forms.TabControl();
            this.tabPageReportTop = new System.Windows.Forms.TabPage();
            this.ucReportHeaderSettingTop = new QuickReportCore.Controls.ucReportHeaderSetting();
            this.tabPageReportBottom = new System.Windows.Forms.TabPage();
            this.ucReportHeaderSettingBottom = new QuickReportCore.Controls.ucReportHeaderSetting();
            this.tabPageReportInterfaces = new System.Windows.Forms.TabPage();
            this.ucReportInterfacesSetting = new QuickReportCore.Controls.ucReportInterfacesSetting();
            this.pnlViewSetting = new System.Windows.Forms.Panel();
            this.grbViewData = new System.Windows.Forms.GroupBox();
            this.cbUseEvenColor = new System.Windows.Forms.CheckBox();
            this.pnlEvenColor = new System.Windows.Forms.Panel();
            this.cbViewOpen = new System.Windows.Forms.CheckBox();
            this.cbAutoColumnWidth = new System.Windows.Forms.CheckBox();
            this.cbLoadAndQuery = new System.Windows.Forms.CheckBox();
            this.grbViewType = new System.Windows.Forms.GroupBox();
            this.rbViewCross = new System.Windows.Forms.RadioButton();
            this.rbViewGrid = new System.Windows.Forms.RadioButton();
            this.tabPageTree = new System.Windows.Forms.TabPage();
            this.tabControlTreeSetting = new System.Windows.Forms.TabControl();
            this.tabPageTreeViewSetting = new System.Windows.Forms.TabPage();
            this.cbTreeMultiSelect = new System.Windows.Forms.CheckBox();
            this.linkLableTreeNameIcon = new System.Windows.Forms.LinkLabel();
            this.linkLableTreeRootIcon = new System.Windows.Forms.LinkLabel();
            this.linkLableTreeGroupIcon = new System.Windows.Forms.LinkLabel();
            this.linkLableTreeNameColor = new System.Windows.Forms.LinkLabel();
            this.linkLableTreeRootColor = new System.Windows.Forms.LinkLabel();
            this.linkLableTreeGroupColor = new System.Windows.Forms.LinkLabel();
            this.txtTreeRootCode = new System.Windows.Forms.TextBox();
            this.cmbTreeGroupCode = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.linkLableTreeNameFont = new System.Windows.Forms.LinkLabel();
            this.txtTreeRootName = new System.Windows.Forms.TextBox();
            this.linkLableTreeRootFont = new System.Windows.Forms.LinkLabel();
            this.linkLableTreeGroupFont = new System.Windows.Forms.LinkLabel();
            this.cmbTreeCode = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.cmbTreeGroupName = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.cmbTreeName = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageTreeOtherSetting = new System.Windows.Forms.TabPage();
            this.cbTreeCollapsed = new System.Windows.Forms.CheckBox();
            this.cmbTreeActionType = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControlTree = new System.Windows.Forms.TabControl();
            this.tabPageTreeSql = new System.Windows.Forms.TabPage();
            this.txtTreeSql = new System.Windows.Forms.TextBox();
            this.toolStripTree = new System.Windows.Forms.ToolStrip();
            this.tbUseTree = new System.Windows.Forms.ToolStripButton();
            this.tabPageDetail = new System.Windows.Forms.TabPage();
            this.tabControlDetailSetting = new System.Windows.Forms.TabControl();
            this.tabPageReportDetailTop = new System.Windows.Forms.TabPage();
            this.ucReportDetailHeaderSettingTop = new QuickReportCore.Controls.ucReportHeaderSetting();
            this.tabPageReportDetailBottom = new System.Windows.Forms.TabPage();
            this.ucReportDetailHeaderSettingBottom = new QuickReportCore.Controls.ucReportHeaderSetting();
            this.tabPageOtherSetting = new System.Windows.Forms.TabPage();
            this.cmbDetailActionType = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControlDetailSql = new System.Windows.Forms.TabControl();
            this.tabPageDetailSql = new System.Windows.Forms.TabPage();
            this.txtDetailSql = new System.Windows.Forms.TextBox();
            this.toolStripDetail = new System.Windows.Forms.ToolStrip();
            this.tbUseDetail = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageBaseInfo.SuspendLayout();
            this.grbEditSql.SuspendLayout();
            this.toolStripBaseInfo.SuspendLayout();
            this.pnlBaseInfo.SuspendLayout();
            this.tabPageColumn.SuspendLayout();
            this.toolStripColumn.SuspendLayout();
            this.tabPageCondition.SuspendLayout();
            this.toolStripCondition.SuspendLayout();
            this.tabPageReport.SuspendLayout();
            this.tabControlReport.SuspendLayout();
            this.tabPageReportTop.SuspendLayout();
            this.tabPageReportBottom.SuspendLayout();
            this.tabPageReportInterfaces.SuspendLayout();
            this.pnlViewSetting.SuspendLayout();
            this.grbViewData.SuspendLayout();
            this.grbViewType.SuspendLayout();
            this.tabPageTree.SuspendLayout();
            this.tabControlTreeSetting.SuspendLayout();
            this.tabPageTreeViewSetting.SuspendLayout();
            this.tabPageTreeOtherSetting.SuspendLayout();
            this.tabControlTree.SuspendLayout();
            this.tabPageTreeSql.SuspendLayout();
            this.toolStripTree.SuspendLayout();
            this.tabPageDetail.SuspendLayout();
            this.tabControlDetailSetting.SuspendLayout();
            this.tabPageReportDetailTop.SuspendLayout();
            this.tabPageReportDetailBottom.SuspendLayout();
            this.tabPageOtherSetting.SuspendLayout();
            this.tabControlDetailSql.SuspendLayout();
            this.tabPageDetailSql.SuspendLayout();
            this.toolStripDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSave,
            this.tbTest});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.ShowItemToolTips = false;
            this.toolStripMain.Size = new System.Drawing.Size(598, 39);
            this.toolStripMain.TabIndex = 27;
            // 
            // tbSave
            // 
            this.tbSave.Image = ((System.Drawing.Image)(resources.GetObject("tbSave.Image")));
            this.tbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(68, 36);
            this.tbSave.Text = "保存";
            this.tbSave.ToolTipText = "保存当前编辑的快捷报表。";
            this.tbSave.Click += new System.EventHandler(this.tbSave_Click);
            // 
            // tbTest
            // 
            this.tbTest.Image = global::QuickReportCore.Properties.Resources.screen;
            this.tbTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbTest.Name = "tbTest";
            this.tbTest.Size = new System.Drawing.Size(68, 36);
            this.tbTest.Text = "预览";
            this.tbTest.Click += new System.EventHandler(this.tbTest_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageBaseInfo);
            this.tabControl.Controls.Add(this.tabPageColumn);
            this.tabControl.Controls.Add(this.tabPageCondition);
            this.tabControl.Controls.Add(this.tabPageReport);
            this.tabControl.Controls.Add(this.tabPageTree);
            this.tabControl.Controls.Add(this.tabPageDetail);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 39);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(598, 620);
            this.tabControl.TabIndex = 28;
            this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Selecting);
            // 
            // tabPageBaseInfo
            // 
            this.tabPageBaseInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageBaseInfo.Controls.Add(this.grbEditSql);
            this.tabPageBaseInfo.Controls.Add(this.pnlBaseInfo);
            this.tabPageBaseInfo.Location = new System.Drawing.Point(4, 26);
            this.tabPageBaseInfo.Name = "tabPageBaseInfo";
            this.tabPageBaseInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBaseInfo.Size = new System.Drawing.Size(590, 590);
            this.tabPageBaseInfo.TabIndex = 0;
            this.tabPageBaseInfo.Text = "基本信息";
            // 
            // grbEditSql
            // 
            this.grbEditSql.Controls.Add(this.txtReportSql);
            this.grbEditSql.Controls.Add(this.toolStripBaseInfo);
            this.grbEditSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbEditSql.Location = new System.Drawing.Point(3, 42);
            this.grbEditSql.Name = "grbEditSql";
            this.grbEditSql.Size = new System.Drawing.Size(584, 545);
            this.grbEditSql.TabIndex = 33;
            this.grbEditSql.TabStop = false;
            this.grbEditSql.Text = "SQL";
            // 
            // txtReportSql
            // 
            this.txtReportSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReportSql.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtReportSql.Location = new System.Drawing.Point(3, 58);
            this.txtReportSql.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtReportSql.Multiline = true;
            this.txtReportSql.Name = "txtReportSql";
            this.txtReportSql.ReadOnly = true;
            this.txtReportSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReportSql.Size = new System.Drawing.Size(578, 484);
            this.txtReportSql.TabIndex = 32;
            this.txtReportSql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyDown);
            // 
            // toolStripBaseInfo
            // 
            this.toolStripBaseInfo.BackColor = System.Drawing.Color.Transparent;
            this.toolStripBaseInfo.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripBaseInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbEditSql});
            this.toolStripBaseInfo.Location = new System.Drawing.Point(3, 19);
            this.toolStripBaseInfo.Name = "toolStripBaseInfo";
            this.toolStripBaseInfo.ShowItemToolTips = false;
            this.toolStripBaseInfo.Size = new System.Drawing.Size(578, 39);
            this.toolStripBaseInfo.TabIndex = 31;
            this.toolStripBaseInfo.Text = "toolStrip1";
            // 
            // tbEditSql
            // 
            this.tbEditSql.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbEditSql.Image = ((System.Drawing.Image)(resources.GetObject("tbEditSql.Image")));
            this.tbEditSql.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbEditSql.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbEditSql.Name = "tbEditSql";
            this.tbEditSql.Size = new System.Drawing.Size(36, 36);
            this.tbEditSql.ToolTipText = "解除SQL锁定。";
            this.tbEditSql.Click += new System.EventHandler(this.tbEditSql_Click);
            // 
            // pnlBaseInfo
            // 
            this.pnlBaseInfo.Controls.Add(this.cmbReportType);
            this.pnlBaseInfo.Controls.Add(this.label2);
            this.pnlBaseInfo.Controls.Add(this.txtReportName);
            this.pnlBaseInfo.Controls.Add(this.label1);
            this.pnlBaseInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBaseInfo.Location = new System.Drawing.Point(3, 3);
            this.pnlBaseInfo.Name = "pnlBaseInfo";
            this.pnlBaseInfo.Size = new System.Drawing.Size(584, 39);
            this.pnlBaseInfo.TabIndex = 32;
            // 
            // cmbReportType
            // 
            this.cmbReportType.FilterName = "选择报表分类";
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(84, 7);
            this.cmbReportType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbReportType.Size = new System.Drawing.Size(125, 25);
            this.cmbReportType.TabIndex = 21;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "报表分类：";
            // 
            // txtReportName
            // 
            this.txtReportName.Location = new System.Drawing.Point(284, 8);
            this.txtReportName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.Size = new System.Drawing.Size(275, 23);
            this.txtReportName.TabIndex = 22;
            this.txtReportName.TextChanged += new System.EventHandler(this.txtReportName_TextChanged);
            this.txtReportName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "报表名称：";
            // 
            // tabPageColumn
            // 
            this.tabPageColumn.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageColumn.Controls.Add(this.ucColumnList);
            this.tabPageColumn.Controls.Add(this.toolStripColumn);
            this.tabPageColumn.Location = new System.Drawing.Point(4, 26);
            this.tabPageColumn.Name = "tabPageColumn";
            this.tabPageColumn.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageColumn.Size = new System.Drawing.Size(590, 590);
            this.tabPageColumn.TabIndex = 1;
            this.tabPageColumn.Text = "列";
            // 
            // ucColumnList
            // 
            this.ucColumnList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucColumnList.Location = new System.Drawing.Point(3, 28);
            this.ucColumnList.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.ucColumnList.Name = "ucColumnList";
            this.ucColumnList.Size = new System.Drawing.Size(584, 559);
            this.ucColumnList.TabIndex = 4;
            // 
            // toolStripColumn
            // 
            this.toolStripColumn.BackColor = System.Drawing.Color.Transparent;
            this.toolStripColumn.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripColumn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbColumnUp,
            this.tbColumnDown});
            this.toolStripColumn.Location = new System.Drawing.Point(3, 3);
            this.toolStripColumn.Name = "toolStripColumn";
            this.toolStripColumn.ShowItemToolTips = false;
            this.toolStripColumn.Size = new System.Drawing.Size(584, 25);
            this.toolStripColumn.TabIndex = 3;
            // 
            // tbColumnUp
            // 
            this.tbColumnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbColumnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbColumnUp.Name = "tbColumnUp";
            this.tbColumnUp.Size = new System.Drawing.Size(46, 22);
            this.tbColumnUp.Text = "↑ 上移";
            this.tbColumnUp.ToolTipText = "调整列顺序：上移。";
            this.tbColumnUp.Click += new System.EventHandler(this.tbColumnUp_Click);
            // 
            // tbColumnDown
            // 
            this.tbColumnDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbColumnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbColumnDown.Name = "tbColumnDown";
            this.tbColumnDown.Size = new System.Drawing.Size(46, 22);
            this.tbColumnDown.Text = "↓ 下移";
            this.tbColumnDown.ToolTipText = "调整列顺序：下移。";
            this.tbColumnDown.Click += new System.EventHandler(this.tbColumnDown_Click);
            // 
            // tabPageCondition
            // 
            this.tabPageCondition.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageCondition.Controls.Add(this.ucConditionList);
            this.tabPageCondition.Controls.Add(this.toolStripCondition);
            this.tabPageCondition.Location = new System.Drawing.Point(4, 26);
            this.tabPageCondition.Name = "tabPageCondition";
            this.tabPageCondition.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCondition.Size = new System.Drawing.Size(590, 590);
            this.tabPageCondition.TabIndex = 2;
            this.tabPageCondition.Text = "条件";
            // 
            // ucConditionList
            // 
            this.ucConditionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucConditionList.Location = new System.Drawing.Point(3, 28);
            this.ucConditionList.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.ucConditionList.Name = "ucConditionList";
            this.ucConditionList.Size = new System.Drawing.Size(584, 559);
            this.ucConditionList.TabIndex = 6;
            this.ucConditionList.ConditionShowChanged += new QuickReportCore.Controls.ucConditionObject.ConditionShowChangedHandle(this.ucConditionList_ConditionShowChanged);
            // 
            // toolStripCondition
            // 
            this.toolStripCondition.BackColor = System.Drawing.Color.Transparent;
            this.toolStripCondition.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripCondition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbConditionUp,
            this.tbConditionDown});
            this.toolStripCondition.Location = new System.Drawing.Point(3, 3);
            this.toolStripCondition.Name = "toolStripCondition";
            this.toolStripCondition.ShowItemToolTips = false;
            this.toolStripCondition.Size = new System.Drawing.Size(584, 25);
            this.toolStripCondition.TabIndex = 5;
            // 
            // tbConditionUp
            // 
            this.tbConditionUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbConditionUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbConditionUp.Name = "tbConditionUp";
            this.tbConditionUp.Size = new System.Drawing.Size(46, 22);
            this.tbConditionUp.Text = "↑ 上移";
            this.tbConditionUp.ToolTipText = "调整条件顺序：上移。";
            this.tbConditionUp.Click += new System.EventHandler(this.tbConditionUp_Click);
            // 
            // tbConditionDown
            // 
            this.tbConditionDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbConditionDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbConditionDown.Name = "tbConditionDown";
            this.tbConditionDown.Size = new System.Drawing.Size(46, 22);
            this.tbConditionDown.Text = "↓ 下移";
            this.tbConditionDown.ToolTipText = "调整条件顺序：下移。";
            this.tbConditionDown.Click += new System.EventHandler(this.tbConditionDown_Click);
            // 
            // tabPageReport
            // 
            this.tabPageReport.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageReport.Controls.Add(this.tabControlReport);
            this.tabPageReport.Controls.Add(this.pnlViewSetting);
            this.tabPageReport.Location = new System.Drawing.Point(4, 26);
            this.tabPageReport.Name = "tabPageReport";
            this.tabPageReport.Size = new System.Drawing.Size(590, 590);
            this.tabPageReport.TabIndex = 3;
            this.tabPageReport.Text = "报表";
            // 
            // tabControlReport
            // 
            this.tabControlReport.Controls.Add(this.tabPageReportTop);
            this.tabControlReport.Controls.Add(this.tabPageReportBottom);
            this.tabControlReport.Controls.Add(this.tabPageReportInterfaces);
            this.tabControlReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlReport.Location = new System.Drawing.Point(0, 69);
            this.tabControlReport.Name = "tabControlReport";
            this.tabControlReport.SelectedIndex = 0;
            this.tabControlReport.Size = new System.Drawing.Size(590, 521);
            this.tabControlReport.TabIndex = 2;
            // 
            // tabPageReportTop
            // 
            this.tabPageReportTop.Controls.Add(this.ucReportHeaderSettingTop);
            this.tabPageReportTop.Location = new System.Drawing.Point(4, 26);
            this.tabPageReportTop.Name = "tabPageReportTop";
            this.tabPageReportTop.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReportTop.Size = new System.Drawing.Size(582, 491);
            this.tabPageReportTop.TabIndex = 0;
            this.tabPageReportTop.Text = "表首";
            this.tabPageReportTop.UseVisualStyleBackColor = true;
            // 
            // ucReportHeaderSettingTop
            // 
            this.ucReportHeaderSettingTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReportHeaderSettingTop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucReportHeaderSettingTop.Location = new System.Drawing.Point(3, 3);
            this.ucReportHeaderSettingTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucReportHeaderSettingTop.Name = "ucReportHeaderSettingTop";
            this.ucReportHeaderSettingTop.Size = new System.Drawing.Size(576, 485);
            this.ucReportHeaderSettingTop.TabIndex = 0;
            // 
            // tabPageReportBottom
            // 
            this.tabPageReportBottom.Controls.Add(this.ucReportHeaderSettingBottom);
            this.tabPageReportBottom.Location = new System.Drawing.Point(4, 26);
            this.tabPageReportBottom.Name = "tabPageReportBottom";
            this.tabPageReportBottom.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReportBottom.Size = new System.Drawing.Size(582, 433);
            this.tabPageReportBottom.TabIndex = 1;
            this.tabPageReportBottom.Text = "表尾";
            this.tabPageReportBottom.UseVisualStyleBackColor = true;
            // 
            // ucReportHeaderSettingBottom
            // 
            this.ucReportHeaderSettingBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReportHeaderSettingBottom.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucReportHeaderSettingBottom.Location = new System.Drawing.Point(3, 3);
            this.ucReportHeaderSettingBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucReportHeaderSettingBottom.Name = "ucReportHeaderSettingBottom";
            this.ucReportHeaderSettingBottom.Size = new System.Drawing.Size(576, 427);
            this.ucReportHeaderSettingBottom.TabIndex = 0;
            // 
            // tabPageReportInterfaces
            // 
            this.tabPageReportInterfaces.Controls.Add(this.ucReportInterfacesSetting);
            this.tabPageReportInterfaces.Location = new System.Drawing.Point(4, 26);
            this.tabPageReportInterfaces.Name = "tabPageReportInterfaces";
            this.tabPageReportInterfaces.Size = new System.Drawing.Size(582, 433);
            this.tabPageReportInterfaces.TabIndex = 2;
            this.tabPageReportInterfaces.Text = "接口实现";
            this.tabPageReportInterfaces.UseVisualStyleBackColor = true;
            // 
            // ucReportInterfacesSetting
            // 
            this.ucReportInterfacesSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReportInterfacesSetting.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucReportInterfacesSetting.Location = new System.Drawing.Point(0, 0);
            this.ucReportInterfacesSetting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucReportInterfacesSetting.Name = "ucReportInterfacesSetting";
            this.ucReportInterfacesSetting.Size = new System.Drawing.Size(582, 433);
            this.ucReportInterfacesSetting.TabIndex = 1;
            // 
            // pnlViewSetting
            // 
            this.pnlViewSetting.Controls.Add(this.grbViewData);
            this.pnlViewSetting.Controls.Add(this.grbViewType);
            this.pnlViewSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlViewSetting.Location = new System.Drawing.Point(0, 0);
            this.pnlViewSetting.Name = "pnlViewSetting";
            this.pnlViewSetting.Size = new System.Drawing.Size(590, 69);
            this.pnlViewSetting.TabIndex = 1;
            // 
            // grbViewData
            // 
            this.grbViewData.Controls.Add(this.cbUseEvenColor);
            this.grbViewData.Controls.Add(this.pnlEvenColor);
            this.grbViewData.Controls.Add(this.cbViewOpen);
            this.grbViewData.Controls.Add(this.cbAutoColumnWidth);
            this.grbViewData.Controls.Add(this.cbLoadAndQuery);
            this.grbViewData.Location = new System.Drawing.Point(145, 3);
            this.grbViewData.Name = "grbViewData";
            this.grbViewData.Size = new System.Drawing.Size(438, 58);
            this.grbViewData.TabIndex = 2;
            this.grbViewData.TabStop = false;
            this.grbViewData.Text = "其他";
            // 
            // cbUseEvenColor
            // 
            this.cbUseEvenColor.AutoSize = true;
            this.cbUseEvenColor.Location = new System.Drawing.Point(259, 24);
            this.cbUseEvenColor.Name = "cbUseEvenColor";
            this.cbUseEvenColor.Size = new System.Drawing.Size(63, 21);
            this.cbUseEvenColor.TabIndex = 34;
            this.cbUseEvenColor.Text = "间隔色";
            this.cbUseEvenColor.UseVisualStyleBackColor = true;
            // 
            // pnlEvenColor
            // 
            this.pnlEvenColor.BackColor = System.Drawing.Color.Silver;
            this.pnlEvenColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlEvenColor.Location = new System.Drawing.Point(323, 23);
            this.pnlEvenColor.Name = "pnlEvenColor";
            this.pnlEvenColor.Size = new System.Drawing.Size(28, 22);
            this.pnlEvenColor.TabIndex = 33;
            this.pnlEvenColor.Click += new System.EventHandler(this.pnlEvenColor_Click);
            // 
            // cbViewOpen
            // 
            this.cbViewOpen.AutoSize = true;
            this.cbViewOpen.Location = new System.Drawing.Point(99, 24);
            this.cbViewOpen.Name = "cbViewOpen";
            this.cbViewOpen.Size = new System.Drawing.Size(63, 21);
            this.cbViewOpen.TabIndex = 31;
            this.cbViewOpen.Text = "开放式";
            this.cbViewOpen.UseVisualStyleBackColor = true;
            // 
            // cbAutoColumnWidth
            // 
            this.cbAutoColumnWidth.AutoSize = true;
            this.cbAutoColumnWidth.Location = new System.Drawing.Point(166, 24);
            this.cbAutoColumnWidth.Name = "cbAutoColumnWidth";
            this.cbAutoColumnWidth.Size = new System.Drawing.Size(87, 21);
            this.cbAutoColumnWidth.TabIndex = 30;
            this.cbAutoColumnWidth.Text = "自适应列宽";
            this.cbAutoColumnWidth.UseVisualStyleBackColor = true;
            // 
            // cbLoadAndQuery
            // 
            this.cbLoadAndQuery.AutoSize = true;
            this.cbLoadAndQuery.Location = new System.Drawing.Point(18, 24);
            this.cbLoadAndQuery.Name = "cbLoadAndQuery";
            this.cbLoadAndQuery.Size = new System.Drawing.Size(75, 21);
            this.cbLoadAndQuery.TabIndex = 29;
            this.cbLoadAndQuery.Text = "登陆查询";
            this.cbLoadAndQuery.UseVisualStyleBackColor = true;
            // 
            // grbViewType
            // 
            this.grbViewType.Controls.Add(this.rbViewCross);
            this.grbViewType.Controls.Add(this.rbViewGrid);
            this.grbViewType.Location = new System.Drawing.Point(8, 3);
            this.grbViewType.Name = "grbViewType";
            this.grbViewType.Size = new System.Drawing.Size(129, 58);
            this.grbViewType.TabIndex = 0;
            this.grbViewType.TabStop = false;
            this.grbViewType.Text = "样式";
            // 
            // rbViewCross
            // 
            this.rbViewCross.AutoSize = true;
            this.rbViewCross.Location = new System.Drawing.Point(71, 22);
            this.rbViewCross.Name = "rbViewCross";
            this.rbViewCross.Size = new System.Drawing.Size(50, 21);
            this.rbViewCross.TabIndex = 2;
            this.rbViewCross.TabStop = true;
            this.rbViewCross.Text = "交叉";
            this.rbViewCross.UseVisualStyleBackColor = true;
            this.rbViewCross.CheckedChanged += new System.EventHandler(this.rbViewCross_CheckedChanged);
            // 
            // rbViewGrid
            // 
            this.rbViewGrid.AutoSize = true;
            this.rbViewGrid.Checked = true;
            this.rbViewGrid.Location = new System.Drawing.Point(15, 22);
            this.rbViewGrid.Name = "rbViewGrid";
            this.rbViewGrid.Size = new System.Drawing.Size(50, 21);
            this.rbViewGrid.TabIndex = 1;
            this.rbViewGrid.TabStop = true;
            this.rbViewGrid.Text = "网格";
            this.rbViewGrid.UseVisualStyleBackColor = true;
            this.rbViewGrid.CheckedChanged += new System.EventHandler(this.rbViewGrid_CheckedChanged);
            // 
            // tabPageTree
            // 
            this.tabPageTree.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageTree.Controls.Add(this.tabControlTreeSetting);
            this.tabPageTree.Controls.Add(this.tabControlTree);
            this.tabPageTree.Controls.Add(this.toolStripTree);
            this.tabPageTree.Location = new System.Drawing.Point(4, 26);
            this.tabPageTree.Name = "tabPageTree";
            this.tabPageTree.Size = new System.Drawing.Size(590, 590);
            this.tabPageTree.TabIndex = 4;
            this.tabPageTree.Text = "树";
            // 
            // tabControlTreeSetting
            // 
            this.tabControlTreeSetting.Controls.Add(this.tabPageTreeViewSetting);
            this.tabControlTreeSetting.Controls.Add(this.tabPageTreeOtherSetting);
            this.tabControlTreeSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTreeSetting.Location = new System.Drawing.Point(0, 291);
            this.tabControlTreeSetting.Name = "tabControlTreeSetting";
            this.tabControlTreeSetting.SelectedIndex = 0;
            this.tabControlTreeSetting.Size = new System.Drawing.Size(590, 299);
            this.tabControlTreeSetting.TabIndex = 8;
            // 
            // tabPageTreeViewSetting
            // 
            this.tabPageTreeViewSetting.Controls.Add(this.cbTreeMultiSelect);
            this.tabPageTreeViewSetting.Controls.Add(this.linkLableTreeNameIcon);
            this.tabPageTreeViewSetting.Controls.Add(this.linkLableTreeRootIcon);
            this.tabPageTreeViewSetting.Controls.Add(this.linkLableTreeGroupIcon);
            this.tabPageTreeViewSetting.Controls.Add(this.linkLableTreeNameColor);
            this.tabPageTreeViewSetting.Controls.Add(this.linkLableTreeRootColor);
            this.tabPageTreeViewSetting.Controls.Add(this.linkLableTreeGroupColor);
            this.tabPageTreeViewSetting.Controls.Add(this.txtTreeRootCode);
            this.tabPageTreeViewSetting.Controls.Add(this.cmbTreeGroupCode);
            this.tabPageTreeViewSetting.Controls.Add(this.label11);
            this.tabPageTreeViewSetting.Controls.Add(this.label10);
            this.tabPageTreeViewSetting.Controls.Add(this.label9);
            this.tabPageTreeViewSetting.Controls.Add(this.linkLableTreeNameFont);
            this.tabPageTreeViewSetting.Controls.Add(this.txtTreeRootName);
            this.tabPageTreeViewSetting.Controls.Add(this.linkLableTreeRootFont);
            this.tabPageTreeViewSetting.Controls.Add(this.linkLableTreeGroupFont);
            this.tabPageTreeViewSetting.Controls.Add(this.cmbTreeCode);
            this.tabPageTreeViewSetting.Controls.Add(this.cmbTreeGroupName);
            this.tabPageTreeViewSetting.Controls.Add(this.cmbTreeName);
            this.tabPageTreeViewSetting.Controls.Add(this.label5);
            this.tabPageTreeViewSetting.Controls.Add(this.label4);
            this.tabPageTreeViewSetting.Controls.Add(this.label3);
            this.tabPageTreeViewSetting.Location = new System.Drawing.Point(4, 26);
            this.tabPageTreeViewSetting.Name = "tabPageTreeViewSetting";
            this.tabPageTreeViewSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTreeViewSetting.Size = new System.Drawing.Size(582, 269);
            this.tabPageTreeViewSetting.TabIndex = 0;
            this.tabPageTreeViewSetting.Text = "显示";
            this.tabPageTreeViewSetting.UseVisualStyleBackColor = true;
            // 
            // cbTreeMultiSelect
            // 
            this.cbTreeMultiSelect.AutoSize = true;
            this.cbTreeMultiSelect.Location = new System.Drawing.Point(10, 229);
            this.cbTreeMultiSelect.Name = "cbTreeMultiSelect";
            this.cbTreeMultiSelect.Size = new System.Drawing.Size(51, 21);
            this.cbTreeMultiSelect.TabIndex = 35;
            this.cbTreeMultiSelect.Text = "多选";
            this.cbTreeMultiSelect.UseVisualStyleBackColor = true;
            // 
            // linkLableTreeNameIcon
            // 
            this.linkLableTreeNameIcon.AutoSize = true;
            this.linkLableTreeNameIcon.Location = new System.Drawing.Point(257, 123);
            this.linkLableTreeNameIcon.Name = "linkLableTreeNameIcon";
            this.linkLableTreeNameIcon.Size = new System.Drawing.Size(32, 17);
            this.linkLableTreeNameIcon.TabIndex = 34;
            this.linkLableTreeNameIcon.TabStop = true;
            this.linkLableTreeNameIcon.Text = "图标";
            this.linkLableTreeNameIcon.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLableTreeNameIcon_LinkClicked);
            // 
            // linkLableTreeRootIcon
            // 
            this.linkLableTreeRootIcon.AutoSize = true;
            this.linkLableTreeRootIcon.Location = new System.Drawing.Point(257, 51);
            this.linkLableTreeRootIcon.Name = "linkLableTreeRootIcon";
            this.linkLableTreeRootIcon.Size = new System.Drawing.Size(32, 17);
            this.linkLableTreeRootIcon.TabIndex = 33;
            this.linkLableTreeRootIcon.TabStop = true;
            this.linkLableTreeRootIcon.Text = "图标";
            this.linkLableTreeRootIcon.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLableTreeRootIcon_LinkClicked);
            // 
            // linkLableTreeGroupIcon
            // 
            this.linkLableTreeGroupIcon.AutoSize = true;
            this.linkLableTreeGroupIcon.Location = new System.Drawing.Point(257, 195);
            this.linkLableTreeGroupIcon.Name = "linkLableTreeGroupIcon";
            this.linkLableTreeGroupIcon.Size = new System.Drawing.Size(32, 17);
            this.linkLableTreeGroupIcon.TabIndex = 32;
            this.linkLableTreeGroupIcon.TabStop = true;
            this.linkLableTreeGroupIcon.Text = "图标";
            this.linkLableTreeGroupIcon.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLableTreeGroupIcon_LinkClicked);
            // 
            // linkLableTreeNameColor
            // 
            this.linkLableTreeNameColor.AutoSize = true;
            this.linkLableTreeNameColor.Location = new System.Drawing.Point(228, 123);
            this.linkLableTreeNameColor.Name = "linkLableTreeNameColor";
            this.linkLableTreeNameColor.Size = new System.Drawing.Size(32, 17);
            this.linkLableTreeNameColor.TabIndex = 31;
            this.linkLableTreeNameColor.TabStop = true;
            this.linkLableTreeNameColor.Text = "颜色";
            this.linkLableTreeNameColor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLableTreeNameColor_LinkClicked);
            // 
            // linkLableTreeRootColor
            // 
            this.linkLableTreeRootColor.AutoSize = true;
            this.linkLableTreeRootColor.Location = new System.Drawing.Point(228, 51);
            this.linkLableTreeRootColor.Name = "linkLableTreeRootColor";
            this.linkLableTreeRootColor.Size = new System.Drawing.Size(32, 17);
            this.linkLableTreeRootColor.TabIndex = 30;
            this.linkLableTreeRootColor.TabStop = true;
            this.linkLableTreeRootColor.Text = "颜色";
            this.linkLableTreeRootColor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLableTreeRootColor_LinkClicked);
            // 
            // linkLableTreeGroupColor
            // 
            this.linkLableTreeGroupColor.AutoSize = true;
            this.linkLableTreeGroupColor.Location = new System.Drawing.Point(228, 195);
            this.linkLableTreeGroupColor.Name = "linkLableTreeGroupColor";
            this.linkLableTreeGroupColor.Size = new System.Drawing.Size(32, 17);
            this.linkLableTreeGroupColor.TabIndex = 29;
            this.linkLableTreeGroupColor.TabStop = true;
            this.linkLableTreeGroupColor.Text = "颜色";
            this.linkLableTreeGroupColor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLableTreeGroupColor_LinkClicked);
            // 
            // txtTreeRootCode
            // 
            this.txtTreeRootCode.Location = new System.Drawing.Point(69, 12);
            this.txtTreeRootCode.Name = "txtTreeRootCode";
            this.txtTreeRootCode.Size = new System.Drawing.Size(127, 23);
            this.txtTreeRootCode.TabIndex = 28;
            this.txtTreeRootCode.Text = "ALL";
            // 
            // cmbTreeGroupCode
            // 
            this.cmbTreeGroupCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTreeGroupCode.FilterName = "选择分组编码";
            this.cmbTreeGroupCode.FormattingEnabled = true;
            this.cmbTreeGroupCode.Location = new System.Drawing.Point(80, 155);
            this.cmbTreeGroupCode.Name = "cmbTreeGroupCode";
            this.cmbTreeGroupCode.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbTreeGroupCode.Size = new System.Drawing.Size(116, 25);
            this.cmbTreeGroupCode.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 17);
            this.label11.TabIndex = 27;
            this.label11.Text = "根编码：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 17);
            this.label10.TabIndex = 25;
            this.label10.Text = "分组编码：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "根名称：";
            // 
            // linkLableTreeNameFont
            // 
            this.linkLableTreeNameFont.AutoSize = true;
            this.linkLableTreeNameFont.Location = new System.Drawing.Point(199, 123);
            this.linkLableTreeNameFont.Name = "linkLableTreeNameFont";
            this.linkLableTreeNameFont.Size = new System.Drawing.Size(32, 17);
            this.linkLableTreeNameFont.TabIndex = 24;
            this.linkLableTreeNameFont.TabStop = true;
            this.linkLableTreeNameFont.Text = "字体";
            this.linkLableTreeNameFont.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLableTreeNameFont_LinkClicked);
            // 
            // txtTreeRootName
            // 
            this.txtTreeRootName.Location = new System.Drawing.Point(69, 48);
            this.txtTreeRootName.Name = "txtTreeRootName";
            this.txtTreeRootName.Size = new System.Drawing.Size(127, 23);
            this.txtTreeRootName.TabIndex = 21;
            this.txtTreeRootName.Text = "默认";
            // 
            // linkLableTreeRootFont
            // 
            this.linkLableTreeRootFont.AutoSize = true;
            this.linkLableTreeRootFont.Location = new System.Drawing.Point(199, 51);
            this.linkLableTreeRootFont.Name = "linkLableTreeRootFont";
            this.linkLableTreeRootFont.Size = new System.Drawing.Size(32, 17);
            this.linkLableTreeRootFont.TabIndex = 23;
            this.linkLableTreeRootFont.TabStop = true;
            this.linkLableTreeRootFont.Text = "字体";
            this.linkLableTreeRootFont.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLableTreeRootFont_LinkClicked);
            // 
            // linkLableTreeGroupFont
            // 
            this.linkLableTreeGroupFont.AutoSize = true;
            this.linkLableTreeGroupFont.Location = new System.Drawing.Point(199, 195);
            this.linkLableTreeGroupFont.Name = "linkLableTreeGroupFont";
            this.linkLableTreeGroupFont.Size = new System.Drawing.Size(32, 17);
            this.linkLableTreeGroupFont.TabIndex = 22;
            this.linkLableTreeGroupFont.TabStop = true;
            this.linkLableTreeGroupFont.Text = "字体";
            this.linkLableTreeGroupFont.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLableTreeGroupFont_LinkClicked);
            // 
            // cmbTreeCode
            // 
            this.cmbTreeCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTreeCode.FilterName = "选择编码";
            this.cmbTreeCode.FormattingEnabled = true;
            this.cmbTreeCode.Location = new System.Drawing.Point(55, 83);
            this.cmbTreeCode.Name = "cmbTreeCode";
            this.cmbTreeCode.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbTreeCode.Size = new System.Drawing.Size(141, 25);
            this.cmbTreeCode.TabIndex = 12;
            // 
            // cmbTreeGroupName
            // 
            this.cmbTreeGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTreeGroupName.FilterName = "选择分组名称";
            this.cmbTreeGroupName.FormattingEnabled = true;
            this.cmbTreeGroupName.Location = new System.Drawing.Point(80, 192);
            this.cmbTreeGroupName.Name = "cmbTreeGroupName";
            this.cmbTreeGroupName.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbTreeGroupName.Size = new System.Drawing.Size(116, 25);
            this.cmbTreeGroupName.TabIndex = 14;
            // 
            // cmbTreeName
            // 
            this.cmbTreeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTreeName.FilterName = "选择名称";
            this.cmbTreeName.FormattingEnabled = true;
            this.cmbTreeName.Location = new System.Drawing.Point(55, 119);
            this.cmbTreeName.Name = "cmbTreeName";
            this.cmbTreeName.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbTreeName.Size = new System.Drawing.Size(141, 25);
            this.cmbTreeName.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "分组名称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "编码：";
            // 
            // tabPageTreeOtherSetting
            // 
            this.tabPageTreeOtherSetting.Controls.Add(this.cbTreeCollapsed);
            this.tabPageTreeOtherSetting.Controls.Add(this.cmbTreeActionType);
            this.tabPageTreeOtherSetting.Controls.Add(this.label6);
            this.tabPageTreeOtherSetting.Location = new System.Drawing.Point(4, 26);
            this.tabPageTreeOtherSetting.Name = "tabPageTreeOtherSetting";
            this.tabPageTreeOtherSetting.Size = new System.Drawing.Size(582, 269);
            this.tabPageTreeOtherSetting.TabIndex = 1;
            this.tabPageTreeOtherSetting.Text = "其他";
            this.tabPageTreeOtherSetting.UseVisualStyleBackColor = true;
            // 
            // cbTreeCollapsed
            // 
            this.cbTreeCollapsed.AutoSize = true;
            this.cbTreeCollapsed.Checked = true;
            this.cbTreeCollapsed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTreeCollapsed.Location = new System.Drawing.Point(9, 51);
            this.cbTreeCollapsed.Name = "cbTreeCollapsed";
            this.cbTreeCollapsed.Size = new System.Drawing.Size(75, 21);
            this.cbTreeCollapsed.TabIndex = 20;
            this.cbTreeCollapsed.Text = "默认展开";
            this.cbTreeCollapsed.UseVisualStyleBackColor = true;
            // 
            // cmbTreeActionType
            // 
            this.cmbTreeActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTreeActionType.FilterName = "选择动作";
            this.cmbTreeActionType.FormattingEnabled = true;
            this.cmbTreeActionType.Location = new System.Drawing.Point(55, 14);
            this.cmbTreeActionType.Name = "cmbTreeActionType";
            this.cmbTreeActionType.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbTreeActionType.Size = new System.Drawing.Size(141, 25);
            this.cmbTreeActionType.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "动作：";
            // 
            // tabControlTree
            // 
            this.tabControlTree.Controls.Add(this.tabPageTreeSql);
            this.tabControlTree.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlTree.Location = new System.Drawing.Point(0, 25);
            this.tabControlTree.Name = "tabControlTree";
            this.tabControlTree.SelectedIndex = 0;
            this.tabControlTree.Size = new System.Drawing.Size(590, 266);
            this.tabControlTree.TabIndex = 7;
            // 
            // tabPageTreeSql
            // 
            this.tabPageTreeSql.Controls.Add(this.txtTreeSql);
            this.tabPageTreeSql.Location = new System.Drawing.Point(4, 26);
            this.tabPageTreeSql.Name = "tabPageTreeSql";
            this.tabPageTreeSql.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTreeSql.Size = new System.Drawing.Size(582, 236);
            this.tabPageTreeSql.TabIndex = 0;
            this.tabPageTreeSql.Text = "SQL";
            this.tabPageTreeSql.UseVisualStyleBackColor = true;
            // 
            // txtTreeSql
            // 
            this.txtTreeSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTreeSql.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTreeSql.Location = new System.Drawing.Point(3, 3);
            this.txtTreeSql.Multiline = true;
            this.txtTreeSql.Name = "txtTreeSql";
            this.txtTreeSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTreeSql.Size = new System.Drawing.Size(576, 230);
            this.txtTreeSql.TabIndex = 0;
            this.txtTreeSql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyDown);
            this.txtTreeSql.Leave += new System.EventHandler(this.txtTreeSql_Leave);
            // 
            // toolStripTree
            // 
            this.toolStripTree.BackColor = System.Drawing.Color.Transparent;
            this.toolStripTree.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbUseTree});
            this.toolStripTree.Location = new System.Drawing.Point(0, 0);
            this.toolStripTree.Name = "toolStripTree";
            this.toolStripTree.ShowItemToolTips = false;
            this.toolStripTree.Size = new System.Drawing.Size(590, 25);
            this.toolStripTree.TabIndex = 6;
            // 
            // tbUseTree
            // 
            this.tbUseTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbUseTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUseTree.Name = "tbUseTree";
            this.tbUseTree.Size = new System.Drawing.Size(36, 22);
            this.tbUseTree.Text = "启用";
            this.tbUseTree.ToolTipText = "调整列顺序：上移。";
            this.tbUseTree.Click += new System.EventHandler(this.tbUseTree_Click);
            // 
            // tabPageDetail
            // 
            this.tabPageDetail.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageDetail.Controls.Add(this.tabControlDetailSetting);
            this.tabPageDetail.Controls.Add(this.tabControlDetailSql);
            this.tabPageDetail.Controls.Add(this.toolStripDetail);
            this.tabPageDetail.Location = new System.Drawing.Point(4, 26);
            this.tabPageDetail.Name = "tabPageDetail";
            this.tabPageDetail.Size = new System.Drawing.Size(590, 590);
            this.tabPageDetail.TabIndex = 5;
            this.tabPageDetail.Text = "明细";
            // 
            // tabControlDetailSetting
            // 
            this.tabControlDetailSetting.Controls.Add(this.tabPageReportDetailTop);
            this.tabControlDetailSetting.Controls.Add(this.tabPageReportDetailBottom);
            this.tabControlDetailSetting.Controls.Add(this.tabPageOtherSetting);
            this.tabControlDetailSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDetailSetting.Location = new System.Drawing.Point(0, 291);
            this.tabControlDetailSetting.Name = "tabControlDetailSetting";
            this.tabControlDetailSetting.SelectedIndex = 0;
            this.tabControlDetailSetting.Size = new System.Drawing.Size(590, 299);
            this.tabControlDetailSetting.TabIndex = 10;
            // 
            // tabPageReportDetailTop
            // 
            this.tabPageReportDetailTop.Controls.Add(this.ucReportDetailHeaderSettingTop);
            this.tabPageReportDetailTop.Location = new System.Drawing.Point(4, 26);
            this.tabPageReportDetailTop.Name = "tabPageReportDetailTop";
            this.tabPageReportDetailTop.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReportDetailTop.Size = new System.Drawing.Size(582, 269);
            this.tabPageReportDetailTop.TabIndex = 3;
            this.tabPageReportDetailTop.Text = "表首";
            this.tabPageReportDetailTop.UseVisualStyleBackColor = true;
            // 
            // ucReportDetailHeaderSettingTop
            // 
            this.ucReportDetailHeaderSettingTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReportDetailHeaderSettingTop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucReportDetailHeaderSettingTop.Location = new System.Drawing.Point(3, 3);
            this.ucReportDetailHeaderSettingTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucReportDetailHeaderSettingTop.Name = "ucReportDetailHeaderSettingTop";
            this.ucReportDetailHeaderSettingTop.Size = new System.Drawing.Size(576, 263);
            this.ucReportDetailHeaderSettingTop.TabIndex = 0;
            // 
            // tabPageReportDetailBottom
            // 
            this.tabPageReportDetailBottom.Controls.Add(this.ucReportDetailHeaderSettingBottom);
            this.tabPageReportDetailBottom.Location = new System.Drawing.Point(4, 26);
            this.tabPageReportDetailBottom.Name = "tabPageReportDetailBottom";
            this.tabPageReportDetailBottom.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReportDetailBottom.Size = new System.Drawing.Size(582, 269);
            this.tabPageReportDetailBottom.TabIndex = 2;
            this.tabPageReportDetailBottom.Text = "表尾";
            this.tabPageReportDetailBottom.UseVisualStyleBackColor = true;
            // 
            // ucReportDetailHeaderSettingBottom
            // 
            this.ucReportDetailHeaderSettingBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReportDetailHeaderSettingBottom.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucReportDetailHeaderSettingBottom.Location = new System.Drawing.Point(3, 3);
            this.ucReportDetailHeaderSettingBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucReportDetailHeaderSettingBottom.Name = "ucReportDetailHeaderSettingBottom";
            this.ucReportDetailHeaderSettingBottom.Size = new System.Drawing.Size(576, 263);
            this.ucReportDetailHeaderSettingBottom.TabIndex = 0;
            // 
            // tabPageOtherSetting
            // 
            this.tabPageOtherSetting.Controls.Add(this.cmbDetailActionType);
            this.tabPageOtherSetting.Controls.Add(this.label7);
            this.tabPageOtherSetting.Location = new System.Drawing.Point(4, 26);
            this.tabPageOtherSetting.Name = "tabPageOtherSetting";
            this.tabPageOtherSetting.Size = new System.Drawing.Size(582, 269);
            this.tabPageOtherSetting.TabIndex = 1;
            this.tabPageOtherSetting.Text = "其他";
            this.tabPageOtherSetting.UseVisualStyleBackColor = true;
            // 
            // cmbDetailActionType
            // 
            this.cmbDetailActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDetailActionType.FilterName = "选择动作";
            this.cmbDetailActionType.FormattingEnabled = true;
            this.cmbDetailActionType.Location = new System.Drawing.Point(54, 14);
            this.cmbDetailActionType.Name = "cmbDetailActionType";
            this.cmbDetailActionType.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbDetailActionType.Size = new System.Drawing.Size(141, 25);
            this.cmbDetailActionType.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "动作：";
            // 
            // tabControlDetailSql
            // 
            this.tabControlDetailSql.Controls.Add(this.tabPageDetailSql);
            this.tabControlDetailSql.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlDetailSql.Location = new System.Drawing.Point(0, 25);
            this.tabControlDetailSql.Name = "tabControlDetailSql";
            this.tabControlDetailSql.SelectedIndex = 0;
            this.tabControlDetailSql.Size = new System.Drawing.Size(590, 266);
            this.tabControlDetailSql.TabIndex = 9;
            // 
            // tabPageDetailSql
            // 
            this.tabPageDetailSql.Controls.Add(this.txtDetailSql);
            this.tabPageDetailSql.Location = new System.Drawing.Point(4, 26);
            this.tabPageDetailSql.Name = "tabPageDetailSql";
            this.tabPageDetailSql.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetailSql.Size = new System.Drawing.Size(582, 236);
            this.tabPageDetailSql.TabIndex = 0;
            this.tabPageDetailSql.Text = "SQL";
            this.tabPageDetailSql.UseVisualStyleBackColor = true;
            // 
            // txtDetailSql
            // 
            this.txtDetailSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetailSql.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDetailSql.Location = new System.Drawing.Point(3, 3);
            this.txtDetailSql.Multiline = true;
            this.txtDetailSql.Name = "txtDetailSql";
            this.txtDetailSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetailSql.Size = new System.Drawing.Size(576, 230);
            this.txtDetailSql.TabIndex = 1;
            this.txtDetailSql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyDown);
            // 
            // toolStripDetail
            // 
            this.toolStripDetail.BackColor = System.Drawing.Color.Transparent;
            this.toolStripDetail.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbUseDetail});
            this.toolStripDetail.Location = new System.Drawing.Point(0, 0);
            this.toolStripDetail.Name = "toolStripDetail";
            this.toolStripDetail.ShowItemToolTips = false;
            this.toolStripDetail.Size = new System.Drawing.Size(590, 25);
            this.toolStripDetail.TabIndex = 6;
            // 
            // tbUseDetail
            // 
            this.tbUseDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbUseDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUseDetail.Name = "tbUseDetail";
            this.tbUseDetail.Size = new System.Drawing.Size(36, 22);
            this.tbUseDetail.Text = "启用";
            this.tbUseDetail.ToolTipText = "调整列顺序：上移。";
            this.tbUseDetail.Click += new System.EventHandler(this.tbUseDetail_Click);
            // 
            // frmQuickReportEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 659);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStripMain);
            this.ForceActiveForm = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuickReportEditor";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.frmQuickReportEditor_Load);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.frmQuickReportEditor_ControlAdded);
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmQuickReportEditor_HelpButtonClicked);
            this.Activated += new System.EventHandler(this.frmQuickReportEditor_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQuickReportEditor_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQuickReportEditor_FormClosing);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageBaseInfo.ResumeLayout(false);
            this.grbEditSql.ResumeLayout(false);
            this.grbEditSql.PerformLayout();
            this.toolStripBaseInfo.ResumeLayout(false);
            this.toolStripBaseInfo.PerformLayout();
            this.pnlBaseInfo.ResumeLayout(false);
            this.pnlBaseInfo.PerformLayout();
            this.tabPageColumn.ResumeLayout(false);
            this.tabPageColumn.PerformLayout();
            this.toolStripColumn.ResumeLayout(false);
            this.toolStripColumn.PerformLayout();
            this.tabPageCondition.ResumeLayout(false);
            this.tabPageCondition.PerformLayout();
            this.toolStripCondition.ResumeLayout(false);
            this.toolStripCondition.PerformLayout();
            this.tabPageReport.ResumeLayout(false);
            this.tabControlReport.ResumeLayout(false);
            this.tabPageReportTop.ResumeLayout(false);
            this.tabPageReportBottom.ResumeLayout(false);
            this.tabPageReportInterfaces.ResumeLayout(false);
            this.pnlViewSetting.ResumeLayout(false);
            this.grbViewData.ResumeLayout(false);
            this.grbViewData.PerformLayout();
            this.grbViewType.ResumeLayout(false);
            this.grbViewType.PerformLayout();
            this.tabPageTree.ResumeLayout(false);
            this.tabPageTree.PerformLayout();
            this.tabControlTreeSetting.ResumeLayout(false);
            this.tabPageTreeViewSetting.ResumeLayout(false);
            this.tabPageTreeViewSetting.PerformLayout();
            this.tabPageTreeOtherSetting.ResumeLayout(false);
            this.tabPageTreeOtherSetting.PerformLayout();
            this.tabControlTree.ResumeLayout(false);
            this.tabPageTreeSql.ResumeLayout(false);
            this.tabPageTreeSql.PerformLayout();
            this.toolStripTree.ResumeLayout(false);
            this.toolStripTree.PerformLayout();
            this.tabPageDetail.ResumeLayout(false);
            this.tabPageDetail.PerformLayout();
            this.tabControlDetailSetting.ResumeLayout(false);
            this.tabPageReportDetailTop.ResumeLayout(false);
            this.tabPageReportDetailBottom.ResumeLayout(false);
            this.tabPageOtherSetting.ResumeLayout(false);
            this.tabPageOtherSetting.PerformLayout();
            this.tabControlDetailSql.ResumeLayout(false);
            this.tabPageDetailSql.ResumeLayout(false);
            this.tabPageDetailSql.PerformLayout();
            this.toolStripDetail.ResumeLayout(false);
            this.toolStripDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton tbSave;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageBaseInfo;
        private System.Windows.Forms.TabPage tabPageColumn;
        private System.Windows.Forms.TabPage tabPageCondition;
        private System.Windows.Forms.TabPage tabPageReport;
        private System.Windows.Forms.ToolStrip toolStripColumn;
        private System.Windows.Forms.ToolStripButton tbColumnUp;
        private System.Windows.Forms.ToolStripButton tbColumnDown;
        private QuickReportCore.Controls.ucColumnList ucColumnList;
        private System.Windows.Forms.ToolStrip toolStripCondition;
        private System.Windows.Forms.ToolStripButton tbConditionUp;
        private System.Windows.Forms.ToolStripButton tbConditionDown;
        private QuickReportCore.Controls.ucConditionList ucConditionList;
        private System.Windows.Forms.GroupBox grbViewType;
        private System.Windows.Forms.RadioButton rbViewCross;
        private System.Windows.Forms.RadioButton rbViewGrid;
        private System.Windows.Forms.Panel pnlViewSetting;
        private System.Windows.Forms.Panel pnlBaseInfo;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbReportType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReportName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbEditSql;
        private System.Windows.Forms.ToolStrip toolStripBaseInfo;
        private System.Windows.Forms.ToolStripButton tbEditSql;
        private System.Windows.Forms.GroupBox grbViewData;
        private System.Windows.Forms.TextBox txtReportSql;
        private System.Windows.Forms.CheckBox cbLoadAndQuery;
        private System.Windows.Forms.CheckBox cbAutoColumnWidth;
        private System.Windows.Forms.CheckBox cbViewOpen;
        private System.Windows.Forms.Panel pnlEvenColor;
        private System.Windows.Forms.ToolStripButton tbTest;
        private System.Windows.Forms.TabPage tabPageTree;
        private System.Windows.Forms.TabPage tabPageDetail;
        private System.Windows.Forms.ToolStrip toolStripTree;
        private System.Windows.Forms.ToolStripButton tbUseTree;
        private System.Windows.Forms.ToolStrip toolStripDetail;
        private System.Windows.Forms.ToolStripButton tbUseDetail;
        private System.Windows.Forms.TabControl tabControlTreeSetting;
        private System.Windows.Forms.TabPage tabPageTreeViewSetting;
        private System.Windows.Forms.TextBox txtTreeRootCode;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbTreeGroupCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel linkLableTreeNameFont;
        private System.Windows.Forms.TextBox txtTreeRootName;
        private System.Windows.Forms.LinkLabel linkLableTreeRootFont;
        private System.Windows.Forms.LinkLabel linkLableTreeGroupFont;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbTreeCode;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbTreeGroupName;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbTreeName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPageTreeOtherSetting;
        private System.Windows.Forms.CheckBox cbTreeCollapsed;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbTreeActionType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControlTree;
        private System.Windows.Forms.TabPage tabPageTreeSql;
        private System.Windows.Forms.TextBox txtTreeSql;
        private System.Windows.Forms.TabControl tabControlReport;
        private System.Windows.Forms.TabPage tabPageReportTop;
        private QuickReportCore.Controls.ucReportHeaderSetting ucReportHeaderSettingTop;
        private System.Windows.Forms.TabPage tabPageReportBottom;
        private QuickReportCore.Controls.ucReportHeaderSetting ucReportHeaderSettingBottom;
        private System.Windows.Forms.TabPage tabPageReportInterfaces;
        private System.Windows.Forms.TabControl tabControlDetailSetting;
        private System.Windows.Forms.TabPage tabPageReportDetailTop;
        private QuickReportCore.Controls.ucReportHeaderSetting ucReportDetailHeaderSettingTop;
        private System.Windows.Forms.TabPage tabPageReportDetailBottom;
        private QuickReportCore.Controls.ucReportHeaderSetting ucReportDetailHeaderSettingBottom;
        private System.Windows.Forms.TabPage tabPageOtherSetting;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbDetailActionType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControlDetailSql;
        private System.Windows.Forms.TabPage tabPageDetailSql;
        private System.Windows.Forms.TextBox txtDetailSql;
        private QuickReportCore.Controls.ucReportInterfacesSetting ucReportInterfacesSetting;
        private System.Windows.Forms.LinkLabel linkLableTreeNameColor;
        private System.Windows.Forms.LinkLabel linkLableTreeRootColor;
        private System.Windows.Forms.LinkLabel linkLableTreeGroupColor;
        private System.Windows.Forms.LinkLabel linkLableTreeNameIcon;
        private System.Windows.Forms.LinkLabel linkLableTreeRootIcon;
        private System.Windows.Forms.LinkLabel linkLableTreeGroupIcon;
        private System.Windows.Forms.CheckBox cbTreeMultiSelect;
        private System.Windows.Forms.CheckBox cbUseEvenColor;
    }
}