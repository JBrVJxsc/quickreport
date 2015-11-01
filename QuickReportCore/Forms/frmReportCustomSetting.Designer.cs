namespace QuickReportCore.Forms
{
    partial class frmReportCustomSetting
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportCustomSetting));
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.TipAppearance tipAppearance3 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.TipAppearance tipAppearance4 = new FarPoint.Win.Spread.TipAppearance();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.tbSave = new System.Windows.Forms.ToolStripButton();
            this.tbShareSetting = new System.Windows.Forms.ToolStripButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageColumnSetting = new System.Windows.Forms.TabPage();
            this.splitContainerColumn = new System.Windows.Forms.SplitContainer();
            this.fpColumnShows = new FarPoint.Win.Spread.FpSpread();
            this.fpColumnShows_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.toolStripColumn = new System.Windows.Forms.ToolStrip();
            this.tbColumnUp = new System.Windows.Forms.ToolStripButton();
            this.tbColumnDown = new System.Windows.Forms.ToolStripButton();
            this.tbRefreshColumn = new System.Windows.Forms.ToolStripButton();
            this.fpColumnUnShows = new FarPoint.Win.Spread.FpSpread();
            this.fpColumnUnShows_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tabPageConditionSetting = new System.Windows.Forms.TabPage();
            this.splitContainerCondition = new System.Windows.Forms.SplitContainer();
            this.fpConditionShows = new FarPoint.Win.Spread.FpSpread();
            this.fpConditionShows_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.toolStripCondition = new System.Windows.Forms.ToolStrip();
            this.tbConditionUp = new System.Windows.Forms.ToolStripButton();
            this.tbConditionDown = new System.Windows.Forms.ToolStripButton();
            this.tbRefreshCondition = new System.Windows.Forms.ToolStripButton();
            this.fpConditionUnShows = new FarPoint.Win.Spread.FpSpread();
            this.fpConditionUnShows_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tabPagePrint = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStripMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageColumnSetting.SuspendLayout();
            this.splitContainerColumn.Panel1.SuspendLayout();
            this.splitContainerColumn.Panel2.SuspendLayout();
            this.splitContainerColumn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpColumnShows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpColumnShows_Sheet1)).BeginInit();
            this.toolStripColumn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpColumnUnShows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpColumnUnShows_Sheet1)).BeginInit();
            this.tabPageConditionSetting.SuspendLayout();
            this.splitContainerCondition.Panel1.SuspendLayout();
            this.splitContainerCondition.Panel2.SuspendLayout();
            this.splitContainerCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpConditionShows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpConditionShows_Sheet1)).BeginInit();
            this.toolStripCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpConditionUnShows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpConditionUnShows_Sheet1)).BeginInit();
            this.tabPagePrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSave,
            this.tbShareSetting});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.ShowItemToolTips = false;
            this.toolStripMain.Size = new System.Drawing.Size(612, 39);
            this.toolStripMain.TabIndex = 29;
            // 
            // tbSave
            // 
            this.tbSave.Image = global::QuickReportCore.Properties.Resources.save;
            this.tbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(68, 36);
            this.tbSave.Text = "保存";
            this.tbSave.Click += new System.EventHandler(this.tbSave_Click);
            // 
            // tbShareSetting
            // 
            this.tbShareSetting.Image = global::QuickReportCore.Properties.Resources.share_setting;
            this.tbShareSetting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbShareSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbShareSetting.Name = "tbShareSetting";
            this.tbShareSetting.Size = new System.Drawing.Size(92, 36);
            this.tbShareSetting.Text = "共享设置";
            this.tbShareSetting.Click += new System.EventHandler(this.tbShareSetting_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageColumnSetting);
            this.tabControl.Controls.Add(this.tabPageConditionSetting);
            this.tabControl.Controls.Add(this.tabPagePrint);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 39);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(612, 360);
            this.tabControl.TabIndex = 30;
            // 
            // tabPageColumnSetting
            // 
            this.tabPageColumnSetting.Controls.Add(this.splitContainerColumn);
            this.tabPageColumnSetting.Location = new System.Drawing.Point(4, 26);
            this.tabPageColumnSetting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageColumnSetting.Name = "tabPageColumnSetting";
            this.tabPageColumnSetting.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageColumnSetting.Size = new System.Drawing.Size(604, 330);
            this.tabPageColumnSetting.TabIndex = 0;
            this.tabPageColumnSetting.Text = "列";
            this.tabPageColumnSetting.UseVisualStyleBackColor = true;
            // 
            // splitContainerColumn
            // 
            this.splitContainerColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerColumn.Location = new System.Drawing.Point(3, 4);
            this.splitContainerColumn.Name = "splitContainerColumn";
            // 
            // splitContainerColumn.Panel1
            // 
            this.splitContainerColumn.Panel1.Controls.Add(this.fpColumnShows);
            this.splitContainerColumn.Panel1.Controls.Add(this.toolStripColumn);
            // 
            // splitContainerColumn.Panel2
            // 
            this.splitContainerColumn.Panel2.Controls.Add(this.fpColumnUnShows);
            this.splitContainerColumn.Size = new System.Drawing.Size(598, 322);
            this.splitContainerColumn.SplitterDistance = 296;
            this.splitContainerColumn.SplitterWidth = 3;
            this.splitContainerColumn.TabIndex = 0;
            // 
            // fpColumnShows
            // 
            this.fpColumnShows.About = "2.5.2007.2005";
            this.fpColumnShows.AccessibleDescription = "fpColumnShows";
            this.fpColumnShows.BackColor = System.Drawing.Color.Transparent;
            this.fpColumnShows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpColumnShows.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpColumnShows.Location = new System.Drawing.Point(0, 25);
            this.fpColumnShows.Name = "fpColumnShows";
            this.fpColumnShows.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpColumnShows_Sheet1});
            this.fpColumnShows.Size = new System.Drawing.Size(296, 297);
            this.fpColumnShows.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpColumnShows.TextTipAppearance = tipAppearance1;
            this.fpColumnShows.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpColumnShows.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpColumnShows_CellDoubleClick);
            this.fpColumnShows.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fp_CellClick);
            // 
            // fpColumnShows_Sheet1
            // 
            this.fpColumnShows_Sheet1.Reset();
            this.fpColumnShows_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpColumnShows_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpColumnShows_Sheet1.ColumnCount = 1;
            this.fpColumnShows_Sheet1.RowCount = 0;
            this.fpColumnShows_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "显示的列";
            this.fpColumnShows_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpColumnShows_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpColumnShows_Sheet1.Columns.Get(0).Label = "显示的列";
            this.fpColumnShows_Sheet1.Columns.Get(0).Locked = true;
            this.fpColumnShows_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpColumnShows_Sheet1.Columns.Get(0).Width = 202F;
            this.fpColumnShows_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpColumnShows_Sheet1.RowHeader.Columns.Get(0).Width = 43F;
            this.fpColumnShows_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpColumnShows_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpColumnShows.SetActiveViewport(1, 0);
            // 
            // toolStripColumn
            // 
            this.toolStripColumn.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripColumn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbColumnUp,
            this.tbColumnDown,
            this.tbRefreshColumn});
            this.toolStripColumn.Location = new System.Drawing.Point(0, 0);
            this.toolStripColumn.Name = "toolStripColumn";
            this.toolStripColumn.ShowItemToolTips = false;
            this.toolStripColumn.Size = new System.Drawing.Size(296, 25);
            this.toolStripColumn.TabIndex = 1;
            this.toolStripColumn.Text = "toolStrip1";
            // 
            // tbColumnUp
            // 
            this.tbColumnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbColumnUp.Image = ((System.Drawing.Image)(resources.GetObject("tbColumnUp.Image")));
            this.tbColumnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbColumnUp.Name = "tbColumnUp";
            this.tbColumnUp.Size = new System.Drawing.Size(46, 22);
            this.tbColumnUp.Text = "↑ 上移";
            this.tbColumnUp.Click += new System.EventHandler(this.tbColumnUp_Click);
            // 
            // tbColumnDown
            // 
            this.tbColumnDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbColumnDown.Image = ((System.Drawing.Image)(resources.GetObject("tbColumnDown.Image")));
            this.tbColumnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbColumnDown.Name = "tbColumnDown";
            this.tbColumnDown.Size = new System.Drawing.Size(46, 22);
            this.tbColumnDown.Text = "↓ 下移";
            this.tbColumnDown.Click += new System.EventHandler(this.tbColumnDown_Click);
            // 
            // tbRefreshColumn
            // 
            this.tbRefreshColumn.Image = global::QuickReportCore.Properties.Resources.reload;
            this.tbRefreshColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRefreshColumn.Name = "tbRefreshColumn";
            this.tbRefreshColumn.Size = new System.Drawing.Size(64, 22);
            this.tbRefreshColumn.Text = "重置列";
            this.tbRefreshColumn.Click += new System.EventHandler(this.tbRefreshColumn_Click);
            // 
            // fpColumnUnShows
            // 
            this.fpColumnUnShows.About = "2.5.2007.2005";
            this.fpColumnUnShows.AccessibleDescription = "fpColumnUnShows";
            this.fpColumnUnShows.BackColor = System.Drawing.Color.Transparent;
            this.fpColumnUnShows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpColumnUnShows.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpColumnUnShows.Location = new System.Drawing.Point(0, 0);
            this.fpColumnUnShows.Name = "fpColumnUnShows";
            this.fpColumnUnShows.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpColumnUnShows_Sheet1});
            this.fpColumnUnShows.Size = new System.Drawing.Size(299, 322);
            this.fpColumnUnShows.TabIndex = 1;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpColumnUnShows.TextTipAppearance = tipAppearance2;
            this.fpColumnUnShows.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpColumnUnShows.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpColumnUnShows_CellDoubleClick);
            this.fpColumnUnShows.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fp_CellClick);
            // 
            // fpColumnUnShows_Sheet1
            // 
            this.fpColumnUnShows_Sheet1.Reset();
            this.fpColumnUnShows_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpColumnUnShows_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpColumnUnShows_Sheet1.ColumnCount = 1;
            this.fpColumnUnShows_Sheet1.RowCount = 0;
            this.fpColumnUnShows_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "未显示的列";
            this.fpColumnUnShows_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpColumnUnShows_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpColumnUnShows_Sheet1.Columns.Get(0).Label = "未显示的列";
            this.fpColumnUnShows_Sheet1.Columns.Get(0).Locked = true;
            this.fpColumnUnShows_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpColumnUnShows_Sheet1.Columns.Get(0).Width = 202F;
            this.fpColumnUnShows_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpColumnUnShows_Sheet1.RowHeader.Columns.Get(0).Width = 43F;
            this.fpColumnUnShows_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpColumnUnShows_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpColumnUnShows.SetActiveViewport(1, 0);
            // 
            // tabPageConditionSetting
            // 
            this.tabPageConditionSetting.Controls.Add(this.splitContainerCondition);
            this.tabPageConditionSetting.Location = new System.Drawing.Point(4, 26);
            this.tabPageConditionSetting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageConditionSetting.Name = "tabPageConditionSetting";
            this.tabPageConditionSetting.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageConditionSetting.Size = new System.Drawing.Size(604, 330);
            this.tabPageConditionSetting.TabIndex = 1;
            this.tabPageConditionSetting.Text = "条件";
            this.tabPageConditionSetting.UseVisualStyleBackColor = true;
            // 
            // splitContainerCondition
            // 
            this.splitContainerCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCondition.Location = new System.Drawing.Point(3, 4);
            this.splitContainerCondition.Name = "splitContainerCondition";
            // 
            // splitContainerCondition.Panel1
            // 
            this.splitContainerCondition.Panel1.Controls.Add(this.fpConditionShows);
            this.splitContainerCondition.Panel1.Controls.Add(this.toolStripCondition);
            // 
            // splitContainerCondition.Panel2
            // 
            this.splitContainerCondition.Panel2.Controls.Add(this.fpConditionUnShows);
            this.splitContainerCondition.Size = new System.Drawing.Size(598, 322);
            this.splitContainerCondition.SplitterDistance = 296;
            this.splitContainerCondition.SplitterWidth = 3;
            this.splitContainerCondition.TabIndex = 1;
            // 
            // fpConditionShows
            // 
            this.fpConditionShows.About = "2.5.2007.2005";
            this.fpConditionShows.AccessibleDescription = "fpConditionShows";
            this.fpConditionShows.BackColor = System.Drawing.Color.Transparent;
            this.fpConditionShows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpConditionShows.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpConditionShows.Location = new System.Drawing.Point(0, 25);
            this.fpConditionShows.Name = "fpConditionShows";
            this.fpConditionShows.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpConditionShows_Sheet1});
            this.fpConditionShows.Size = new System.Drawing.Size(296, 297);
            this.fpConditionShows.TabIndex = 2;
            tipAppearance3.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpConditionShows.TextTipAppearance = tipAppearance3;
            this.fpConditionShows.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpConditionShows.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpConditionShows_CellDoubleClick);
            this.fpConditionShows.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fp_CellClick);
            // 
            // fpConditionShows_Sheet1
            // 
            this.fpConditionShows_Sheet1.Reset();
            this.fpConditionShows_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpConditionShows_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpConditionShows_Sheet1.ColumnCount = 1;
            this.fpConditionShows_Sheet1.RowCount = 0;
            this.fpConditionShows_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "使用的条件";
            this.fpConditionShows_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpConditionShows_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpConditionShows_Sheet1.Columns.Get(0).Label = "使用的条件";
            this.fpConditionShows_Sheet1.Columns.Get(0).Locked = true;
            this.fpConditionShows_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpConditionShows_Sheet1.Columns.Get(0).Width = 202F;
            this.fpConditionShows_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpConditionShows_Sheet1.RowHeader.Columns.Get(0).Width = 43F;
            this.fpConditionShows_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpConditionShows_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpConditionShows.SetActiveViewport(1, 0);
            // 
            // toolStripCondition
            // 
            this.toolStripCondition.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripCondition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbConditionUp,
            this.tbConditionDown,
            this.tbRefreshCondition});
            this.toolStripCondition.Location = new System.Drawing.Point(0, 0);
            this.toolStripCondition.Name = "toolStripCondition";
            this.toolStripCondition.ShowItemToolTips = false;
            this.toolStripCondition.Size = new System.Drawing.Size(296, 25);
            this.toolStripCondition.TabIndex = 1;
            this.toolStripCondition.Text = "toolStrip1";
            // 
            // tbConditionUp
            // 
            this.tbConditionUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbConditionUp.Image = ((System.Drawing.Image)(resources.GetObject("tbConditionUp.Image")));
            this.tbConditionUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbConditionUp.Name = "tbConditionUp";
            this.tbConditionUp.Size = new System.Drawing.Size(46, 22);
            this.tbConditionUp.Text = "↑ 上移";
            this.tbConditionUp.Click += new System.EventHandler(this.tbConditionUp_Click);
            // 
            // tbConditionDown
            // 
            this.tbConditionDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbConditionDown.Image = ((System.Drawing.Image)(resources.GetObject("tbConditionDown.Image")));
            this.tbConditionDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbConditionDown.Name = "tbConditionDown";
            this.tbConditionDown.Size = new System.Drawing.Size(46, 22);
            this.tbConditionDown.Text = "↓ 下移";
            this.tbConditionDown.Click += new System.EventHandler(this.tbConditionDown_Click);
            // 
            // tbRefreshCondition
            // 
            this.tbRefreshCondition.Image = global::QuickReportCore.Properties.Resources.reload;
            this.tbRefreshCondition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRefreshCondition.Name = "tbRefreshCondition";
            this.tbRefreshCondition.Size = new System.Drawing.Size(76, 22);
            this.tbRefreshCondition.Text = "重置条件";
            this.tbRefreshCondition.Click += new System.EventHandler(this.tbRefreshCondition_Click);
            // 
            // fpConditionUnShows
            // 
            this.fpConditionUnShows.About = "2.5.2007.2005";
            this.fpConditionUnShows.AccessibleDescription = "fpConditionUnShows";
            this.fpConditionUnShows.BackColor = System.Drawing.Color.Transparent;
            this.fpConditionUnShows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpConditionUnShows.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpConditionUnShows.Location = new System.Drawing.Point(0, 0);
            this.fpConditionUnShows.Name = "fpConditionUnShows";
            this.fpConditionUnShows.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpConditionUnShows_Sheet1});
            this.fpConditionUnShows.Size = new System.Drawing.Size(299, 322);
            this.fpConditionUnShows.TabIndex = 1;
            tipAppearance4.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpConditionUnShows.TextTipAppearance = tipAppearance4;
            this.fpConditionUnShows.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpConditionUnShows.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpConditionUnShows_CellDoubleClick);
            this.fpConditionUnShows.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fp_CellClick);
            // 
            // fpConditionUnShows_Sheet1
            // 
            this.fpConditionUnShows_Sheet1.Reset();
            this.fpConditionUnShows_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpConditionUnShows_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpConditionUnShows_Sheet1.ColumnCount = 1;
            this.fpConditionUnShows_Sheet1.RowCount = 0;
            this.fpConditionUnShows_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "未使用的条件";
            this.fpConditionUnShows_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpConditionUnShows_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpConditionUnShows_Sheet1.Columns.Get(0).Label = "未使用的条件";
            this.fpConditionUnShows_Sheet1.Columns.Get(0).Locked = true;
            this.fpConditionUnShows_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpConditionUnShows_Sheet1.Columns.Get(0).Width = 202F;
            this.fpConditionUnShows_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpConditionUnShows_Sheet1.RowHeader.Columns.Get(0).Width = 43F;
            this.fpConditionUnShows_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpConditionUnShows_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpConditionUnShows.SetActiveViewport(1, 0);
            // 
            // tabPagePrint
            // 
            this.tabPagePrint.Controls.Add(this.button1);
            this.tabPagePrint.Location = new System.Drawing.Point(4, 26);
            this.tabPagePrint.Name = "tabPagePrint";
            this.tabPagePrint.Size = new System.Drawing.Size(604, 330);
            this.tabPagePrint.TabIndex = 2;
            this.tabPagePrint.Text = "打印";
            this.tabPagePrint.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(330, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmReportCustomSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 399);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStripMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportCustomSetting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageColumnSetting.ResumeLayout(false);
            this.splitContainerColumn.Panel1.ResumeLayout(false);
            this.splitContainerColumn.Panel1.PerformLayout();
            this.splitContainerColumn.Panel2.ResumeLayout(false);
            this.splitContainerColumn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpColumnShows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpColumnShows_Sheet1)).EndInit();
            this.toolStripColumn.ResumeLayout(false);
            this.toolStripColumn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpColumnUnShows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpColumnUnShows_Sheet1)).EndInit();
            this.tabPageConditionSetting.ResumeLayout(false);
            this.splitContainerCondition.Panel1.ResumeLayout(false);
            this.splitContainerCondition.Panel1.PerformLayout();
            this.splitContainerCondition.Panel2.ResumeLayout(false);
            this.splitContainerCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpConditionShows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpConditionShows_Sheet1)).EndInit();
            this.toolStripCondition.ResumeLayout(false);
            this.toolStripCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpConditionUnShows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpConditionUnShows_Sheet1)).EndInit();
            this.tabPagePrint.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton tbSave;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageColumnSetting;
        private System.Windows.Forms.SplitContainer splitContainerColumn;
        private FarPoint.Win.Spread.FpSpread fpColumnShows;
        private FarPoint.Win.Spread.SheetView fpColumnShows_Sheet1;
        private System.Windows.Forms.ToolStrip toolStripColumn;
        private System.Windows.Forms.ToolStripButton tbColumnUp;
        private System.Windows.Forms.ToolStripButton tbColumnDown;
        private FarPoint.Win.Spread.FpSpread fpColumnUnShows;
        private FarPoint.Win.Spread.SheetView fpColumnUnShows_Sheet1;
        private System.Windows.Forms.TabPage tabPageConditionSetting;
        private System.Windows.Forms.SplitContainer splitContainerCondition;
        private System.Windows.Forms.ToolStrip toolStripCondition;
        private System.Windows.Forms.ToolStripButton tbConditionUp;
        private System.Windows.Forms.ToolStripButton tbConditionDown;
        private FarPoint.Win.Spread.FpSpread fpConditionUnShows;
        private FarPoint.Win.Spread.SheetView fpConditionUnShows_Sheet1;
        private FarPoint.Win.Spread.FpSpread fpConditionShows;
        private FarPoint.Win.Spread.SheetView fpConditionShows_Sheet1;
        private System.Windows.Forms.TabPage tabPagePrint;
        private System.Windows.Forms.ToolStripButton tbRefreshColumn;
        private System.Windows.Forms.ToolStripButton tbRefreshCondition;
        private System.Windows.Forms.ToolStripButton tbShareSetting;
        private System.Windows.Forms.Button button1;


    }
}