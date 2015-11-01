namespace QuickReportLib.Controls.ConditionInputTypeSetting
{
    partial class TextBoxSettingUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextBoxSettingUserControl));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numLeftZero = new System.Windows.Forms.NumericUpDown();
            this.cbLeftZero = new System.Windows.Forms.CheckBox();
            this.grbSelector = new System.Windows.Forms.GroupBox();
            this.tabControlSelector = new System.Windows.Forms.TabControl();
            this.tabPageSql = new System.Windows.Forms.TabPage();
            this.txtSelectorSQL = new QuickReportLib.Controls.GlobalValue.TextBoxForNormalGlobalValueAsker();
            this.tabPageOutColumn = new System.Windows.Forms.TabPage();
            this.cmbOutPutColumn = new QuickReportLib.Controls.Plus.ComboBoxPlus();
            this.cbHideSelectorOutPutColumn = new System.Windows.Forms.CheckBox();
            this.txtSelectorNullMessage = new System.Windows.Forms.TextBox();
            this.txtSelectorTitle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStripSelector = new System.Windows.Forms.ToolStrip();
            this.tbUseSelector = new System.Windows.Forms.ToolStripButton();
            this.tbParseSQL = new System.Windows.Forms.ToolStripButton();
            this.cbOnlyNumber = new System.Windows.Forms.CheckBox();
            this.txtDefaultValue = new QuickReportLib.Controls.GlobalValue.TextBoxForNormalGlobalValueAsker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbActionAfterEnterKeyDown = new QuickReportLib.Controls.Plus.ComboBoxActionAfterEnterKeyDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numLeftZero)).BeginInit();
            this.grbSelector.SuspendLayout();
            this.tabControlSelector.SuspendLayout();
            this.tabPageSql.SuspendLayout();
            this.tabPageOutColumn.SuspendLayout();
            this.toolStripSelector.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "默认值：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(206, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "位";
            // 
            // numLeftZero
            // 
            this.numLeftZero.Enabled = false;
            this.numLeftZero.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numLeftZero.Location = new System.Drawing.Point(165, 52);
            this.numLeftZero.Name = "numLeftZero";
            this.numLeftZero.Size = new System.Drawing.Size(38, 23);
            this.numLeftZero.TabIndex = 23;
            this.numLeftZero.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cbLeftZero
            // 
            this.cbLeftZero.AutoSize = true;
            this.cbLeftZero.Enabled = false;
            this.cbLeftZero.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbLeftZero.Location = new System.Drawing.Point(100, 53);
            this.cbLeftZero.Name = "cbLeftZero";
            this.cbLeftZero.Size = new System.Drawing.Size(63, 21);
            this.cbLeftZero.TabIndex = 22;
            this.cbLeftZero.Text = "左补零";
            this.cbLeftZero.UseVisualStyleBackColor = true;
            this.cbLeftZero.CheckedChanged += new System.EventHandler(this.cbLeftZero_CheckedChanged);
            // 
            // grbSelector
            // 
            this.grbSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbSelector.Controls.Add(this.tabControlSelector);
            this.grbSelector.Controls.Add(this.toolStripSelector);
            this.grbSelector.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grbSelector.Location = new System.Drawing.Point(332, 0);
            this.grbSelector.Name = "grbSelector";
            this.grbSelector.Size = new System.Drawing.Size(360, 278);
            this.grbSelector.TabIndex = 26;
            this.grbSelector.TabStop = false;
            this.grbSelector.Text = "选择框";
            // 
            // tabControlSelector
            // 
            this.tabControlSelector.Controls.Add(this.tabPageSql);
            this.tabControlSelector.Controls.Add(this.tabPageOutColumn);
            this.tabControlSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSelector.Location = new System.Drawing.Point(3, 44);
            this.tabControlSelector.Name = "tabControlSelector";
            this.tabControlSelector.SelectedIndex = 0;
            this.tabControlSelector.Size = new System.Drawing.Size(354, 231);
            this.tabControlSelector.TabIndex = 6;
            // 
            // tabPageSql
            // 
            this.tabPageSql.Controls.Add(this.txtSelectorSQL);
            this.tabPageSql.Location = new System.Drawing.Point(4, 26);
            this.tabPageSql.Name = "tabPageSql";
            this.tabPageSql.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSql.Size = new System.Drawing.Size(346, 201);
            this.tabPageSql.TabIndex = 0;
            this.tabPageSql.Text = "SQL";
            this.tabPageSql.UseVisualStyleBackColor = true;
            // 
            // txtSelectorSQL
            // 
            this.txtSelectorSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSelectorSQL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSelectorSQL.FontWhenNull = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSelectorSQL.ForeColorWhenNull = System.Drawing.Color.Gray;
            this.txtSelectorSQL.Location = new System.Drawing.Point(3, 3);
            this.txtSelectorSQL.MaxLength = 999999999;
            this.txtSelectorSQL.Multiline = true;
            this.txtSelectorSQL.Name = "txtSelectorSQL";
            this.txtSelectorSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSelectorSQL.Size = new System.Drawing.Size(340, 195);
            this.txtSelectorSQL.TabIndex = 0;
            this.txtSelectorSQL.TextWhenNull = "";
            // 
            // tabPageOutColumn
            // 
            this.tabPageOutColumn.AutoScroll = true;
            this.tabPageOutColumn.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageOutColumn.Controls.Add(this.cmbOutPutColumn);
            this.tabPageOutColumn.Controls.Add(this.cbHideSelectorOutPutColumn);
            this.tabPageOutColumn.Controls.Add(this.txtSelectorNullMessage);
            this.tabPageOutColumn.Controls.Add(this.txtSelectorTitle);
            this.tabPageOutColumn.Controls.Add(this.label7);
            this.tabPageOutColumn.Controls.Add(this.label5);
            this.tabPageOutColumn.Controls.Add(this.label4);
            this.tabPageOutColumn.Location = new System.Drawing.Point(4, 26);
            this.tabPageOutColumn.Name = "tabPageOutColumn";
            this.tabPageOutColumn.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOutColumn.Size = new System.Drawing.Size(346, 201);
            this.tabPageOutColumn.TabIndex = 1;
            this.tabPageOutColumn.Text = "设置";
            // 
            // cmbOutPutColumn
            // 
            this.cmbOutPutColumn.ColumnShowState = QuickReportLib.Enums.ComboBoxPlusColumnShowState.Both;
            this.cmbOutPutColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutPutColumn.FilterName = "过滤框";
            this.cmbOutPutColumn.FormattingEnabled = true;
            this.cmbOutPutColumn.Location = new System.Drawing.Point(65, 14);
            this.cmbOutPutColumn.Name = "cmbOutPutColumn";
            this.cmbOutPutColumn.Size = new System.Drawing.Size(130, 25);
            this.cmbOutPutColumn.TabIndex = 26;
            // 
            // cbHideSelectorOutPutColumn
            // 
            this.cbHideSelectorOutPutColumn.AutoSize = true;
            this.cbHideSelectorOutPutColumn.Checked = true;
            this.cbHideSelectorOutPutColumn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHideSelectorOutPutColumn.Location = new System.Drawing.Point(204, 17);
            this.cbHideSelectorOutPutColumn.Name = "cbHideSelectorOutPutColumn";
            this.cbHideSelectorOutPutColumn.Size = new System.Drawing.Size(87, 21);
            this.cbHideSelectorOutPutColumn.TabIndex = 25;
            this.cbHideSelectorOutPutColumn.Text = "隐藏输出列";
            this.cbHideSelectorOutPutColumn.UseVisualStyleBackColor = true;
            // 
            // txtSelectorNullMessage
            // 
            this.txtSelectorNullMessage.Location = new System.Drawing.Point(94, 91);
            this.txtSelectorNullMessage.Name = "txtSelectorNullMessage";
            this.txtSelectorNullMessage.Size = new System.Drawing.Size(194, 23);
            this.txtSelectorNullMessage.TabIndex = 24;
            // 
            // txtSelectorTitle
            // 
            this.txtSelectorTitle.Location = new System.Drawing.Point(65, 54);
            this.txtSelectorTitle.Name = "txtSelectorTitle";
            this.txtSelectorTitle.Size = new System.Drawing.Size(223, 23);
            this.txtSelectorTitle.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "无值时提示：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "标题：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "输出列：";
            // 
            // toolStripSelector
            // 
            this.toolStripSelector.BackColor = System.Drawing.Color.Transparent;
            this.toolStripSelector.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripSelector.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbUseSelector,
            this.tbParseSQL});
            this.toolStripSelector.Location = new System.Drawing.Point(3, 19);
            this.toolStripSelector.Name = "toolStripSelector";
            this.toolStripSelector.ShowItemToolTips = false;
            this.toolStripSelector.Size = new System.Drawing.Size(354, 25);
            this.toolStripSelector.TabIndex = 5;
            // 
            // tbUseSelector
            // 
            this.tbUseSelector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbUseSelector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUseSelector.Name = "tbUseSelector";
            this.tbUseSelector.Size = new System.Drawing.Size(36, 22);
            this.tbUseSelector.Text = "启用";
            this.tbUseSelector.ToolTipText = "调整列顺序：上移。";
            this.tbUseSelector.Click += new System.EventHandler(this.tbUseSelector_Click);
            // 
            // tbParseSQL
            // 
            this.tbParseSQL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbParseSQL.Image = ((System.Drawing.Image)(resources.GetObject("tbParseSQL.Image")));
            this.tbParseSQL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbParseSQL.Name = "tbParseSQL";
            this.tbParseSQL.Size = new System.Drawing.Size(36, 22);
            this.tbParseSQL.Text = "解析";
            this.tbParseSQL.Click += new System.EventHandler(this.tbParseSQL_Click);
            // 
            // cbOnlyNumber
            // 
            this.cbOnlyNumber.AutoSize = true;
            this.cbOnlyNumber.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbOnlyNumber.Location = new System.Drawing.Point(9, 53);
            this.cbOnlyNumber.Name = "cbOnlyNumber";
            this.cbOnlyNumber.Size = new System.Drawing.Size(87, 21);
            this.cbOnlyNumber.TabIndex = 27;
            this.cbOnlyNumber.Text = "仅允许数字";
            this.cbOnlyNumber.UseVisualStyleBackColor = true;
            this.cbOnlyNumber.CheckedChanged += new System.EventHandler(this.cbOnlyNumber_CheckedChanged);
            // 
            // txtDefaultValue
            // 
            this.txtDefaultValue.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDefaultValue.FontWhenNull = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDefaultValue.ForeColorWhenNull = System.Drawing.Color.Gray;
            this.txtDefaultValue.Location = new System.Drawing.Point(68, 17);
            this.txtDefaultValue.MaxLength = 999999999;
            this.txtDefaultValue.Multiline = true;
            this.txtDefaultValue.Name = "txtDefaultValue";
            this.txtDefaultValue.Size = new System.Drawing.Size(239, 23);
            this.txtDefaultValue.TabIndex = 28;
            this.txtDefaultValue.TextWhenNull = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "回车后：";
            // 
            // cmbActionAfterEnterKeyDown
            // 
            this.cmbActionAfterEnterKeyDown.ActionAfterEnterKeyDown = QuickReportLib.Enums.ActionAfterEnterKeyDown.Query;
            this.cmbActionAfterEnterKeyDown.ColumnShowState = QuickReportLib.Enums.ComboBoxPlusColumnShowState.Both;
            this.cmbActionAfterEnterKeyDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActionAfterEnterKeyDown.FilterName = "过滤框";
            this.cmbActionAfterEnterKeyDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbActionAfterEnterKeyDown.FormattingEnabled = true;
            this.cmbActionAfterEnterKeyDown.Items.AddRange(new object[] {
            "查询",
            "选择下一个控件"});
            this.cmbActionAfterEnterKeyDown.Location = new System.Drawing.Point(68, 88);
            this.cmbActionAfterEnterKeyDown.Name = "cmbActionAfterEnterKeyDown";
            this.cmbActionAfterEnterKeyDown.Size = new System.Drawing.Size(239, 25);
            this.cmbActionAfterEnterKeyDown.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbActionAfterEnterKeyDown);
            this.groupBox1.Controls.Add(this.cbLeftZero);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numLeftZero);
            this.groupBox1.Controls.Add(this.txtDefaultValue);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbOnlyNumber);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 278);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // TextBoxSettingUserControl
            // 
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbSelector);
            this.Name = "TextBoxSettingUserControl";
            this.Size = new System.Drawing.Size(692, 278);
            ((System.ComponentModel.ISupportInitialize)(this.numLeftZero)).EndInit();
            this.grbSelector.ResumeLayout(false);
            this.grbSelector.PerformLayout();
            this.tabControlSelector.ResumeLayout(false);
            this.tabPageSql.ResumeLayout(false);
            this.tabPageSql.PerformLayout();
            this.tabPageOutColumn.ResumeLayout(false);
            this.tabPageOutColumn.PerformLayout();
            this.toolStripSelector.ResumeLayout(false);
            this.toolStripSelector.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numLeftZero;
        private System.Windows.Forms.CheckBox cbLeftZero;
        private System.Windows.Forms.GroupBox grbSelector;
        private System.Windows.Forms.TabControl tabControlSelector;
        private System.Windows.Forms.TabPage tabPageSql;
        private System.Windows.Forms.TabPage tabPageOutColumn;
        private System.Windows.Forms.CheckBox cbHideSelectorOutPutColumn;
        private System.Windows.Forms.TextBox txtSelectorNullMessage;
        private System.Windows.Forms.TextBox txtSelectorTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStripSelector;
        private System.Windows.Forms.ToolStripButton tbUseSelector;
        private QuickReportLib.Controls.GlobalValue.TextBoxForNormalGlobalValueAsker txtSelectorSQL;
        private System.Windows.Forms.ToolStripButton tbParseSQL;
        private System.Windows.Forms.CheckBox cbOnlyNumber;
        private QuickReportLib.Controls.GlobalValue.TextBoxForNormalGlobalValueAsker txtDefaultValue;
        private System.Windows.Forms.Label label2;
        private QuickReportLib.Controls.Plus.ComboBoxActionAfterEnterKeyDown cmbActionAfterEnterKeyDown;
        private QuickReportLib.Controls.Plus.ComboBoxPlus cmbOutPutColumn;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
