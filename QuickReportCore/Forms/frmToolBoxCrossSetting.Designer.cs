namespace QuickReportCore.Forms
{
    partial class frmToolBoxCrossSetting
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
            this.grbCrossSetting = new System.Windows.Forms.GroupBox();
            this.cbUnion = new System.Windows.Forms.CheckBox();
            this.cbUseHeader = new System.Windows.Forms.CheckBox();
            this.cbUseGroupSumRow = new System.Windows.Forms.CheckBox();
            this.cbColumnSum = new System.Windows.Forms.CheckBox();
            this.cbRowSum = new System.Windows.Forms.CheckBox();
            this.txtGroupSumColumnName = new System.Windows.Forms.TextBox();
            this.txtGroupSumRowName = new System.Windows.Forms.TextBox();
            this.tabControlCustom = new System.Windows.Forms.TabControl();
            this.tbColumn = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCustomColumnGroupSumName = new System.Windows.Forms.TextBox();
            this.cmbCustomColumnGroupSum = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCustomColumnName = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.label9 = new System.Windows.Forms.Label();
            this.txtColumnSql = new System.Windows.Forms.TextBox();
            this.toolStripColumn = new System.Windows.Forms.ToolStrip();
            this.tbUseCustomColumn = new System.Windows.Forms.ToolStripButton();
            this.tbRow = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbCustomRowGroupSum = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbCustomRowName = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRowSql = new System.Windows.Forms.TextBox();
            this.toolStripRow = new System.Windows.Forms.ToolStrip();
            this.tbUseCustomRow = new System.Windows.Forms.ToolStripButton();
            this.cmbGroupSumColumn = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.cmbGroupSumRow = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbValue = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.cmbColumn = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.cmbRow = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbCrossSetting.SuspendLayout();
            this.tabControlCustom.SuspendLayout();
            this.tbColumn.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStripColumn.SuspendLayout();
            this.tbRow.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStripRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbCrossSetting
            // 
            this.grbCrossSetting.Controls.Add(this.cbUnion);
            this.grbCrossSetting.Controls.Add(this.cbUseHeader);
            this.grbCrossSetting.Controls.Add(this.cbUseGroupSumRow);
            this.grbCrossSetting.Controls.Add(this.cbColumnSum);
            this.grbCrossSetting.Controls.Add(this.cbRowSum);
            this.grbCrossSetting.Controls.Add(this.txtGroupSumColumnName);
            this.grbCrossSetting.Controls.Add(this.txtGroupSumRowName);
            this.grbCrossSetting.Controls.Add(this.tabControlCustom);
            this.grbCrossSetting.Controls.Add(this.cmbGroupSumColumn);
            this.grbCrossSetting.Controls.Add(this.cmbGroupSumRow);
            this.grbCrossSetting.Controls.Add(this.label6);
            this.grbCrossSetting.Controls.Add(this.label7);
            this.grbCrossSetting.Controls.Add(this.cmbValue);
            this.grbCrossSetting.Controls.Add(this.cmbColumn);
            this.grbCrossSetting.Controls.Add(this.cmbRow);
            this.grbCrossSetting.Controls.Add(this.label3);
            this.grbCrossSetting.Controls.Add(this.label2);
            this.grbCrossSetting.Controls.Add(this.label1);
            this.grbCrossSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbCrossSetting.Location = new System.Drawing.Point(0, 0);
            this.grbCrossSetting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbCrossSetting.Name = "grbCrossSetting";
            this.grbCrossSetting.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbCrossSetting.Size = new System.Drawing.Size(253, 530);
            this.grbCrossSetting.TabIndex = 1;
            this.grbCrossSetting.TabStop = false;
            // 
            // cbUnion
            // 
            this.cbUnion.AutoSize = true;
            this.cbUnion.Location = new System.Drawing.Point(176, 217);
            this.cbUnion.Name = "cbUnion";
            this.cbUnion.Size = new System.Drawing.Size(51, 21);
            this.cbUnion.TabIndex = 34;
            this.cbUnion.Text = "合并";
            this.cbUnion.UseVisualStyleBackColor = true;
            this.cbUnion.Visible = false;
            this.cbUnion.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbUseHeader
            // 
            this.cbUseHeader.AutoSize = true;
            this.cbUseHeader.Location = new System.Drawing.Point(119, 147);
            this.cbUseHeader.Name = "cbUseHeader";
            this.cbUseHeader.Size = new System.Drawing.Size(75, 21);
            this.cbUseHeader.TabIndex = 33;
            this.cbUseHeader.Text = "独立样式";
            this.cbUseHeader.UseVisualStyleBackColor = true;
            this.cbUseHeader.CheckedChanged += new System.EventHandler(this.cbGroupSumSomething_CheckedChanged);
            // 
            // cbUseGroupSumRow
            // 
            this.cbUseGroupSumRow.AutoSize = true;
            this.cbUseGroupSumRow.Location = new System.Drawing.Point(15, 147);
            this.cbUseGroupSumRow.Name = "cbUseGroupSumRow";
            this.cbUseGroupSumRow.Size = new System.Drawing.Size(51, 21);
            this.cbUseGroupSumRow.TabIndex = 32;
            this.cbUseGroupSumRow.Text = "小计";
            this.cbUseGroupSumRow.UseVisualStyleBackColor = true;
            this.cbUseGroupSumRow.CheckedChanged += new System.EventHandler(this.cbGroupSumSomething_CheckedChanged);
            // 
            // cbColumnSum
            // 
            this.cbColumnSum.AutoSize = true;
            this.cbColumnSum.Location = new System.Drawing.Point(84, 211);
            this.cbColumnSum.Name = "cbColumnSum";
            this.cbColumnSum.Size = new System.Drawing.Size(63, 21);
            this.cbColumnSum.TabIndex = 31;
            this.cbColumnSum.Text = "列合计";
            this.cbColumnSum.UseVisualStyleBackColor = true;
            this.cbColumnSum.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbRowSum
            // 
            this.cbRowSum.AutoSize = true;
            this.cbRowSum.Location = new System.Drawing.Point(15, 211);
            this.cbRowSum.Name = "cbRowSum";
            this.cbRowSum.Size = new System.Drawing.Size(63, 21);
            this.cbRowSum.TabIndex = 30;
            this.cbRowSum.Text = "行合计";
            this.cbRowSum.UseVisualStyleBackColor = true;
            this.cbRowSum.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // txtGroupSumColumnName
            // 
            this.txtGroupSumColumnName.Location = new System.Drawing.Point(186, 176);
            this.txtGroupSumColumnName.Name = "txtGroupSumColumnName";
            this.txtGroupSumColumnName.Size = new System.Drawing.Size(41, 23);
            this.txtGroupSumColumnName.TabIndex = 29;
            this.txtGroupSumColumnName.Text = "小计";
            // 
            // txtGroupSumRowName
            // 
            this.txtGroupSumRowName.Location = new System.Drawing.Point(67, 145);
            this.txtGroupSumRowName.Name = "txtGroupSumRowName";
            this.txtGroupSumRowName.Size = new System.Drawing.Size(41, 23);
            this.txtGroupSumRowName.TabIndex = 28;
            this.txtGroupSumRowName.Text = "小计";
            // 
            // tabControlCustom
            // 
            this.tabControlCustom.Controls.Add(this.tbColumn);
            this.tabControlCustom.Controls.Add(this.tbRow);
            this.tabControlCustom.Location = new System.Drawing.Point(6, 244);
            this.tabControlCustom.Name = "tabControlCustom";
            this.tabControlCustom.SelectedIndex = 0;
            this.tabControlCustom.Size = new System.Drawing.Size(241, 274);
            this.tabControlCustom.TabIndex = 27;
            // 
            // tbColumn
            // 
            this.tbColumn.Controls.Add(this.groupBox1);
            this.tbColumn.Controls.Add(this.toolStripColumn);
            this.tbColumn.Location = new System.Drawing.Point(4, 26);
            this.tbColumn.Name = "tbColumn";
            this.tbColumn.Padding = new System.Windows.Forms.Padding(3);
            this.tbColumn.Size = new System.Drawing.Size(233, 244);
            this.tbColumn.TabIndex = 0;
            this.tbColumn.Text = "自定义列";
            this.tbColumn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCustomColumnGroupSumName);
            this.groupBox1.Controls.Add(this.cmbCustomColumnGroupSum);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbCustomColumnName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtColumnSql);
            this.groupBox1.Location = new System.Drawing.Point(7, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 205);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // txtCustomColumnGroupSumName
            // 
            this.txtCustomColumnGroupSumName.Location = new System.Drawing.Point(169, 169);
            this.txtCustomColumnGroupSumName.Name = "txtCustomColumnGroupSumName";
            this.txtCustomColumnGroupSumName.Size = new System.Drawing.Size(41, 23);
            this.txtCustomColumnGroupSumName.TabIndex = 30;
            this.txtCustomColumnGroupSumName.Text = "小计";
            // 
            // cmbCustomColumnGroupSum
            // 
            this.cmbCustomColumnGroupSum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomColumnGroupSum.FilterName = "选择列小计";
            this.cmbCustomColumnGroupSum.FormattingEnabled = true;
            this.cmbCustomColumnGroupSum.Location = new System.Drawing.Point(65, 168);
            this.cmbCustomColumnGroupSum.Name = "cmbCustomColumnGroupSum";
            this.cmbCustomColumnGroupSum.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbCustomColumnGroupSum.Size = new System.Drawing.Size(100, 25);
            this.cmbCustomColumnGroupSum.TabIndex = 26;
            this.cmbCustomColumnGroupSum.DropDownClosed += new System.EventHandler(this.cmb_DropDownClosed);
            this.cmbCustomColumnGroupSum.DropDown += new System.EventHandler(this.cmb_DropDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "列小计：";
            // 
            // cmbCustomColumnName
            // 
            this.cmbCustomColumnName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomColumnName.FilterName = "选择列名";
            this.cmbCustomColumnName.FormattingEnabled = true;
            this.cmbCustomColumnName.Location = new System.Drawing.Point(50, 137);
            this.cmbCustomColumnName.Name = "cmbCustomColumnName";
            this.cmbCustomColumnName.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbCustomColumnName.Size = new System.Drawing.Size(160, 25);
            this.cmbCustomColumnName.TabIndex = 24;
            this.cmbCustomColumnName.DropDownClosed += new System.EventHandler(this.cmb_DropDownClosed);
            this.cmbCustomColumnName.DropDown += new System.EventHandler(this.cmb_DropDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "列名：";
            // 
            // txtColumnSql
            // 
            this.txtColumnSql.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtColumnSql.Location = new System.Drawing.Point(8, 18);
            this.txtColumnSql.Multiline = true;
            this.txtColumnSql.Name = "txtColumnSql";
            this.txtColumnSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtColumnSql.Size = new System.Drawing.Size(202, 109);
            this.txtColumnSql.TabIndex = 22;
            this.txtColumnSql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtColumnSql.Leave += new System.EventHandler(this.txtColumnSql_Leave);
            // 
            // toolStripColumn
            // 
            this.toolStripColumn.BackColor = System.Drawing.Color.Transparent;
            this.toolStripColumn.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripColumn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbUseCustomColumn});
            this.toolStripColumn.Location = new System.Drawing.Point(3, 3);
            this.toolStripColumn.Name = "toolStripColumn";
            this.toolStripColumn.ShowItemToolTips = false;
            this.toolStripColumn.Size = new System.Drawing.Size(227, 25);
            this.toolStripColumn.TabIndex = 4;
            // 
            // tbUseCustomColumn
            // 
            this.tbUseCustomColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbUseCustomColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUseCustomColumn.Name = "tbUseCustomColumn";
            this.tbUseCustomColumn.Size = new System.Drawing.Size(36, 22);
            this.tbUseCustomColumn.Text = "启用";
            this.tbUseCustomColumn.ToolTipText = "调整列顺序：上移。";
            this.tbUseCustomColumn.Click += new System.EventHandler(this.tbUseCustomColumn_Click);
            // 
            // tbRow
            // 
            this.tbRow.Controls.Add(this.groupBox2);
            this.tbRow.Controls.Add(this.toolStripRow);
            this.tbRow.Location = new System.Drawing.Point(4, 26);
            this.tbRow.Name = "tbRow";
            this.tbRow.Padding = new System.Windows.Forms.Padding(3);
            this.tbRow.Size = new System.Drawing.Size(233, 244);
            this.tbRow.TabIndex = 1;
            this.tbRow.Text = "自定义行";
            this.tbRow.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbCustomRowGroupSum);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cmbCustomRowName);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtRowSql);
            this.groupBox2.Location = new System.Drawing.Point(7, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(201, 205);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // cmbCustomRowGroupSum
            // 
            this.cmbCustomRowGroupSum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomRowGroupSum.FilterName = "选择行小计";
            this.cmbCustomRowGroupSum.FormattingEnabled = true;
            this.cmbCustomRowGroupSum.Location = new System.Drawing.Point(65, 168);
            this.cmbCustomRowGroupSum.Name = "cmbCustomRowGroupSum";
            this.cmbCustomRowGroupSum.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Both;
            this.cmbCustomRowGroupSum.Size = new System.Drawing.Size(100, 25);
            this.cmbCustomRowGroupSum.TabIndex = 26;
            this.cmbCustomRowGroupSum.DropDownClosed += new System.EventHandler(this.cmb_DropDownClosed);
            this.cmbCustomRowGroupSum.DropDown += new System.EventHandler(this.cmb_DropDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 25;
            this.label10.Text = "行小计：";
            // 
            // cmbCustomRowName
            // 
            this.cmbCustomRowName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomRowName.FilterName = "选择行名";
            this.cmbCustomRowName.FormattingEnabled = true;
            this.cmbCustomRowName.Location = new System.Drawing.Point(52, 137);
            this.cmbCustomRowName.Name = "cmbCustomRowName";
            this.cmbCustomRowName.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Both;
            this.cmbCustomRowName.Size = new System.Drawing.Size(143, 25);
            this.cmbCustomRowName.TabIndex = 24;
            this.cmbCustomRowName.DropDownClosed += new System.EventHandler(this.cmb_DropDownClosed);
            this.cmbCustomRowName.DropDown += new System.EventHandler(this.cmb_DropDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "行名：";
            // 
            // txtRowSql
            // 
            this.txtRowSql.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRowSql.Location = new System.Drawing.Point(8, 18);
            this.txtRowSql.Multiline = true;
            this.txtRowSql.Name = "txtRowSql";
            this.txtRowSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRowSql.Size = new System.Drawing.Size(187, 109);
            this.txtRowSql.TabIndex = 22;
            this.txtRowSql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtRowSql.Leave += new System.EventHandler(this.txtRowSql_Leave);
            // 
            // toolStripRow
            // 
            this.toolStripRow.BackColor = System.Drawing.Color.Transparent;
            this.toolStripRow.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbUseCustomRow});
            this.toolStripRow.Location = new System.Drawing.Point(3, 3);
            this.toolStripRow.Name = "toolStripRow";
            this.toolStripRow.ShowItemToolTips = false;
            this.toolStripRow.Size = new System.Drawing.Size(227, 25);
            this.toolStripRow.TabIndex = 5;
            // 
            // tbUseCustomRow
            // 
            this.tbUseCustomRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbUseCustomRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUseCustomRow.Name = "tbUseCustomRow";
            this.tbUseCustomRow.Size = new System.Drawing.Size(36, 22);
            this.tbUseCustomRow.Text = "启用";
            this.tbUseCustomRow.ToolTipText = "调整列顺序：上移。";
            this.tbUseCustomRow.Click += new System.EventHandler(this.tbUseCustomRow_Click);
            // 
            // cmbGroupSumColumn
            // 
            this.cmbGroupSumColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupSumColumn.FilterName = "选择列小计";
            this.cmbGroupSumColumn.FormattingEnabled = true;
            this.cmbGroupSumColumn.Location = new System.Drawing.Point(73, 175);
            this.cmbGroupSumColumn.Name = "cmbGroupSumColumn";
            this.cmbGroupSumColumn.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbGroupSumColumn.Size = new System.Drawing.Size(109, 25);
            this.cmbGroupSumColumn.TabIndex = 26;
            this.cmbGroupSumColumn.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            this.cmbGroupSumColumn.DropDownClosed += new System.EventHandler(this.cmb_DropDownClosed);
            this.cmbGroupSumColumn.DropDown += new System.EventHandler(this.cmb_DropDown);
            // 
            // cmbGroupSumRow
            // 
            this.cmbGroupSumRow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupSumRow.FilterName = "选择行小计";
            this.cmbGroupSumRow.FormattingEnabled = true;
            this.cmbGroupSumRow.Location = new System.Drawing.Point(73, 112);
            this.cmbGroupSumRow.Name = "cmbGroupSumRow";
            this.cmbGroupSumRow.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbGroupSumRow.Size = new System.Drawing.Size(154, 25);
            this.cmbGroupSumRow.TabIndex = 25;
            this.cmbGroupSumRow.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            this.cmbGroupSumRow.DropDownClosed += new System.EventHandler(this.cmb_DropDownClosed);
            this.cmbGroupSumRow.DropDown += new System.EventHandler(this.cmb_DropDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "列小计：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "行分组：";
            // 
            // cmbValue
            // 
            this.cmbValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbValue.FilterName = "选择值";
            this.cmbValue.FormattingEnabled = true;
            this.cmbValue.Location = new System.Drawing.Point(51, 80);
            this.cmbValue.Name = "cmbValue";
            this.cmbValue.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbValue.Size = new System.Drawing.Size(176, 25);
            this.cmbValue.TabIndex = 17;
            this.cmbValue.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            this.cmbValue.DropDownClosed += new System.EventHandler(this.cmb_DropDownClosed);
            this.cmbValue.DropDown += new System.EventHandler(this.cmb_DropDown);
            // 
            // cmbColumn
            // 
            this.cmbColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumn.FilterName = "选择列";
            this.cmbColumn.FormattingEnabled = true;
            this.cmbColumn.Location = new System.Drawing.Point(51, 48);
            this.cmbColumn.Name = "cmbColumn";
            this.cmbColumn.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbColumn.Size = new System.Drawing.Size(176, 25);
            this.cmbColumn.TabIndex = 16;
            this.cmbColumn.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            this.cmbColumn.DropDownClosed += new System.EventHandler(this.cmb_DropDownClosed);
            this.cmbColumn.DropDown += new System.EventHandler(this.cmb_DropDown);
            // 
            // cmbRow
            // 
            this.cmbRow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRow.FilterName = "选择行";
            this.cmbRow.FormattingEnabled = true;
            this.cmbRow.Location = new System.Drawing.Point(51, 17);
            this.cmbRow.Name = "cmbRow";
            this.cmbRow.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbRow.Size = new System.Drawing.Size(176, 25);
            this.cmbRow.TabIndex = 15;
            this.cmbRow.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            this.cmbRow.DropDownClosed += new System.EventHandler(this.cmb_DropDownClosed);
            this.cmbRow.DropDown += new System.EventHandler(this.cmb_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "值：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "列：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "行：";
            // 
            // frmToolBoxCrossSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CannotClose = true;
            this.ClientSize = new System.Drawing.Size(253, 530);
            this.ControlBox = false;
            this.Controls.Add(this.grbCrossSetting);
            this.ForceActiveForm = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmToolBoxCrossSetting";
            this.Opacity = 0.85;
            this.Text = "交叉报表设置";
            this.grbCrossSetting.ResumeLayout(false);
            this.grbCrossSetting.PerformLayout();
            this.tabControlCustom.ResumeLayout(false);
            this.tbColumn.ResumeLayout(false);
            this.tbColumn.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStripColumn.ResumeLayout(false);
            this.toolStripColumn.PerformLayout();
            this.tbRow.ResumeLayout(false);
            this.tbRow.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStripRow.ResumeLayout(false);
            this.toolStripRow.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbCrossSetting;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbValue;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbColumn;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbRow;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbGroupSumColumn;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbGroupSumRow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControlCustom;
        private System.Windows.Forms.TabPage tbColumn;
        private System.Windows.Forms.TabPage tbRow;
        private System.Windows.Forms.ToolStrip toolStripColumn;
        private System.Windows.Forms.ToolStripButton tbUseCustomColumn;
        private System.Windows.Forms.ToolStrip toolStripRow;
        private System.Windows.Forms.ToolStripButton tbUseCustomRow;
        private System.Windows.Forms.GroupBox groupBox1;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbCustomColumnGroupSum;
        private System.Windows.Forms.Label label8;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbCustomColumnName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtColumnSql;
        private System.Windows.Forms.GroupBox groupBox2;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbCustomRowGroupSum;
        private System.Windows.Forms.Label label10;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbCustomRowName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRowSql;
        private System.Windows.Forms.TextBox txtGroupSumRowName;
        private System.Windows.Forms.TextBox txtGroupSumColumnName;
        private System.Windows.Forms.TextBox txtCustomColumnGroupSumName;
        private System.Windows.Forms.CheckBox cbRowSum;
        private System.Windows.Forms.CheckBox cbColumnSum;
        private System.Windows.Forms.CheckBox cbUseHeader;
        private System.Windows.Forms.CheckBox cbUseGroupSumRow;
        private System.Windows.Forms.CheckBox cbUnion;
    }
}