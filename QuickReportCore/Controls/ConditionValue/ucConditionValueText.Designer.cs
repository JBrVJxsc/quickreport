namespace QuickReportCore.Controls.ConditionValue
{
    partial class ucConditionValueText
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDefaultValue = new System.Windows.Forms.TextBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbHideOperator = new System.Windows.Forms.CheckBox();
            this.cbLeftZero = new System.Windows.Forms.CheckBox();
            this.numLeftZero = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.grbSelector = new System.Windows.Forms.GroupBox();
            this.tabControlSelector = new System.Windows.Forms.TabControl();
            this.tabPageSql = new System.Windows.Forms.TabPage();
            this.txtSelectorSql = new System.Windows.Forms.TextBox();
            this.tabPageOutColumn = new System.Windows.Forms.TabPage();
            this.cbHideSelectorOutColumn = new System.Windows.Forms.CheckBox();
            this.txtSelectorNullMessage = new System.Windows.Forms.TextBox();
            this.txtSelectorTitle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSelectorActionType = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbOutColumn = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStripSelector = new System.Windows.Forms.ToolStrip();
            this.tbUseSelector = new System.Windows.Forms.ToolStripButton();
            this.cmbOperators = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.cbQueryAfterEnter = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numLeftZero)).BeginInit();
            this.grbSelector.SuspendLayout();
            this.tabControlSelector.SuspendLayout();
            this.tabPageSql.SuspendLayout();
            this.tabPageOutColumn.SuspendLayout();
            this.toolStripSelector.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "默认值：";
            // 
            // txtDefaultValue
            // 
            this.txtDefaultValue.Location = new System.Drawing.Point(74, 25);
            this.txtDefaultValue.Name = "txtDefaultValue";
            this.txtDefaultValue.Size = new System.Drawing.Size(166, 23);
            this.txtDefaultValue.TabIndex = 1;
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(66, 387);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(87, 29);
            this.btAdd.TabIndex = 2;
            this.btAdd.Text = "确认";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(162, 387);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 29);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "默认操作符：";
            // 
            // cbHideOperator
            // 
            this.cbHideOperator.AutoSize = true;
            this.cbHideOperator.Checked = true;
            this.cbHideOperator.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHideOperator.Location = new System.Drawing.Point(189, 69);
            this.cbHideOperator.Name = "cbHideOperator";
            this.cbHideOperator.Size = new System.Drawing.Size(51, 21);
            this.cbHideOperator.TabIndex = 16;
            this.cbHideOperator.Text = "隐藏";
            this.cbHideOperator.UseVisualStyleBackColor = true;
            // 
            // cbLeftZero
            // 
            this.cbLeftZero.AutoSize = true;
            this.cbLeftZero.Location = new System.Drawing.Point(115, 104);
            this.cbLeftZero.Name = "cbLeftZero";
            this.cbLeftZero.Size = new System.Drawing.Size(63, 21);
            this.cbLeftZero.TabIndex = 17;
            this.cbLeftZero.Text = "左补零";
            this.cbLeftZero.UseVisualStyleBackColor = true;
            this.cbLeftZero.CheckedChanged += new System.EventHandler(this.cbLeftZero_CheckedChanged);
            // 
            // numLeftZero
            // 
            this.numLeftZero.Enabled = false;
            this.numLeftZero.Location = new System.Drawing.Point(177, 102);
            this.numLeftZero.Name = "numLeftZero";
            this.numLeftZero.Size = new System.Drawing.Size(38, 23);
            this.numLeftZero.TabIndex = 18;
            this.numLeftZero.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "位";
            // 
            // grbSelector
            // 
            this.grbSelector.Controls.Add(this.tabControlSelector);
            this.grbSelector.Controls.Add(this.toolStripSelector);
            this.grbSelector.Location = new System.Drawing.Point(3, 134);
            this.grbSelector.Name = "grbSelector";
            this.grbSelector.Size = new System.Drawing.Size(254, 247);
            this.grbSelector.TabIndex = 20;
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
            this.tabControlSelector.Size = new System.Drawing.Size(248, 200);
            this.tabControlSelector.TabIndex = 6;
            // 
            // tabPageSql
            // 
            this.tabPageSql.Controls.Add(this.txtSelectorSql);
            this.tabPageSql.Location = new System.Drawing.Point(4, 26);
            this.tabPageSql.Name = "tabPageSql";
            this.tabPageSql.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSql.Size = new System.Drawing.Size(240, 170);
            this.tabPageSql.TabIndex = 0;
            this.tabPageSql.Text = "SQL";
            this.tabPageSql.UseVisualStyleBackColor = true;
            // 
            // txtSelectorSql
            // 
            this.txtSelectorSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSelectorSql.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSelectorSql.Location = new System.Drawing.Point(3, 3);
            this.txtSelectorSql.Multiline = true;
            this.txtSelectorSql.Name = "txtSelectorSql";
            this.txtSelectorSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSelectorSql.Size = new System.Drawing.Size(234, 164);
            this.txtSelectorSql.TabIndex = 23;
            this.txtSelectorSql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtSelectorSql.Leave += new System.EventHandler(this.txtSelectorSql_Leave);
            // 
            // tabPageOutColumn
            // 
            this.tabPageOutColumn.Controls.Add(this.cbHideSelectorOutColumn);
            this.tabPageOutColumn.Controls.Add(this.txtSelectorNullMessage);
            this.tabPageOutColumn.Controls.Add(this.txtSelectorTitle);
            this.tabPageOutColumn.Controls.Add(this.label7);
            this.tabPageOutColumn.Controls.Add(this.label5);
            this.tabPageOutColumn.Controls.Add(this.cmbSelectorActionType);
            this.tabPageOutColumn.Controls.Add(this.label6);
            this.tabPageOutColumn.Controls.Add(this.cmbOutColumn);
            this.tabPageOutColumn.Controls.Add(this.label4);
            this.tabPageOutColumn.Location = new System.Drawing.Point(4, 26);
            this.tabPageOutColumn.Name = "tabPageOutColumn";
            this.tabPageOutColumn.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOutColumn.Size = new System.Drawing.Size(240, 172);
            this.tabPageOutColumn.TabIndex = 1;
            this.tabPageOutColumn.Text = "设置";
            this.tabPageOutColumn.UseVisualStyleBackColor = true;
            // 
            // cbHideSelectorOutColumn
            // 
            this.cbHideSelectorOutColumn.AutoSize = true;
            this.cbHideSelectorOutColumn.Checked = true;
            this.cbHideSelectorOutColumn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHideSelectorOutColumn.Location = new System.Drawing.Point(181, 16);
            this.cbHideSelectorOutColumn.Name = "cbHideSelectorOutColumn";
            this.cbHideSelectorOutColumn.Size = new System.Drawing.Size(51, 21);
            this.cbHideSelectorOutColumn.TabIndex = 25;
            this.cbHideSelectorOutColumn.Text = "隐藏";
            this.cbHideSelectorOutColumn.UseVisualStyleBackColor = true;
            // 
            // txtSelectorNullMessage
            // 
            this.txtSelectorNullMessage.Location = new System.Drawing.Point(94, 129);
            this.txtSelectorNullMessage.Name = "txtSelectorNullMessage";
            this.txtSelectorNullMessage.Size = new System.Drawing.Size(135, 23);
            this.txtSelectorNullMessage.TabIndex = 24;
            this.txtSelectorNullMessage.Text = "未查找到有效记录。";
            // 
            // txtSelectorTitle
            // 
            this.txtSelectorTitle.Location = new System.Drawing.Point(65, 92);
            this.txtSelectorTitle.Name = "txtSelectorTitle";
            this.txtSelectorTitle.Size = new System.Drawing.Size(164, 23);
            this.txtSelectorTitle.TabIndex = 23;
            this.txtSelectorTitle.Text = "请选择一条记录";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "无值时提示：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "标题：";
            // 
            // cmbSelectorActionType
            // 
            this.cmbSelectorActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectorActionType.FilterName = "选择动作";
            this.cmbSelectorActionType.FormattingEnabled = true;
            this.cmbSelectorActionType.Location = new System.Drawing.Point(65, 53);
            this.cmbSelectorActionType.Name = "cmbSelectorActionType";
            this.cmbSelectorActionType.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbSelectorActionType.Size = new System.Drawing.Size(165, 25);
            this.cmbSelectorActionType.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "动作：";
            // 
            // cmbOutColumn
            // 
            this.cmbOutColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutColumn.FilterName = "选择编码";
            this.cmbOutColumn.FormattingEnabled = true;
            this.cmbOutColumn.Location = new System.Drawing.Point(65, 14);
            this.cmbOutColumn.Name = "cmbOutColumn";
            this.cmbOutColumn.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbOutColumn.Size = new System.Drawing.Size(107, 25);
            this.cmbOutColumn.TabIndex = 14;
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
            this.tbUseSelector});
            this.toolStripSelector.Location = new System.Drawing.Point(3, 19);
            this.toolStripSelector.Name = "toolStripSelector";
            this.toolStripSelector.ShowItemToolTips = false;
            this.toolStripSelector.Size = new System.Drawing.Size(248, 25);
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
            // cmbOperators
            // 
            this.cmbOperators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperators.FilterName = "过滤框";
            this.cmbOperators.FormattingEnabled = true;
            this.cmbOperators.Location = new System.Drawing.Point(98, 67);
            this.cmbOperators.Name = "cmbOperators";
            this.cmbOperators.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Both;
            this.cmbOperators.Size = new System.Drawing.Size(86, 25);
            this.cmbOperators.TabIndex = 10;
            // 
            // cbQueryAfterEnter
            // 
            this.cbQueryAfterEnter.AutoSize = true;
            this.cbQueryAfterEnter.Checked = true;
            this.cbQueryAfterEnter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbQueryAfterEnter.Location = new System.Drawing.Point(15, 104);
            this.cbQueryAfterEnter.Name = "cbQueryAfterEnter";
            this.cbQueryAfterEnter.Size = new System.Drawing.Size(87, 21);
            this.cbQueryAfterEnter.TabIndex = 21;
            this.cbQueryAfterEnter.Text = "回车后查询";
            this.cbQueryAfterEnter.UseVisualStyleBackColor = true;
            // 
            // ucConditionValueText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbQueryAfterEnter);
            this.Controls.Add(this.grbSelector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numLeftZero);
            this.Controls.Add(this.cbLeftZero);
            this.Controls.Add(this.cbHideOperator);
            this.Controls.Add(this.cmbOperators);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.txtDefaultValue);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucConditionValueText";
            this.Size = new System.Drawing.Size(260, 432);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDefaultValue;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btCancel;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbOperators;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbHideOperator;
        private System.Windows.Forms.CheckBox cbLeftZero;
        private System.Windows.Forms.NumericUpDown numLeftZero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grbSelector;
        private System.Windows.Forms.ToolStrip toolStripSelector;
        private System.Windows.Forms.ToolStripButton tbUseSelector;
        private System.Windows.Forms.TabControl tabControlSelector;
        private System.Windows.Forms.TabPage tabPageSql;
        private System.Windows.Forms.TabPage tabPageOutColumn;
        private System.Windows.Forms.TextBox txtSelectorSql;
        private ComboBoxWithFilter cmbOutColumn;
        private System.Windows.Forms.Label label4;
        private ComboBoxWithFilter cmbSelectorActionType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSelectorTitle;
        private System.Windows.Forms.TextBox txtSelectorNullMessage;
        private System.Windows.Forms.CheckBox cbHideSelectorOutColumn;
        private System.Windows.Forms.CheckBox cbQueryAfterEnter;
    }
}
