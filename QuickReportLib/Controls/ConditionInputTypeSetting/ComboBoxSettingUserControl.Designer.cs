namespace QuickReportLib.Controls.ConditionInputTypeSetting
{
    partial class ComboBoxSettingUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComboBoxSettingUserControl));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDefaultValue = new QuickReportLib.Controls.GlobalValue.ComboBoxForNormalGlobalValueAsker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageSql = new System.Windows.Forms.TabPage();
            this.txtSQL = new QuickReportLib.Controls.GlobalValue.TextBoxForNormalGlobalValueAsker();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbParseSQL = new System.Windows.Forms.ToolStripButton();
            this.cbCanEdit = new System.Windows.Forms.CheckBox();
            this.cmbActionAfterEnterKeyDown = new QuickReportLib.Controls.Plus.ComboBoxActionAfterEnterKeyDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageSql.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "默认值：";
            // 
            // cmbDefaultValue
            // 
            this.cmbDefaultValue.ColumnShowState = QuickReportLib.Enums.ComboBoxPlusColumnShowState.Name;
            this.cmbDefaultValue.FilterName = "过滤框";
            this.cmbDefaultValue.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDefaultValue.FormattingEnabled = true;
            this.cmbDefaultValue.Location = new System.Drawing.Point(68, 16);
            this.cmbDefaultValue.Name = "cmbDefaultValue";
            this.cmbDefaultValue.Size = new System.Drawing.Size(239, 25);
            this.cmbDefaultValue.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tabControl);
            this.groupBox1.Controls.Add(this.toolStrip);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(332, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 278);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自定义内容";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageSql);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 44);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(354, 231);
            this.tabControl.TabIndex = 7;
            // 
            // tabPageSql
            // 
            this.tabPageSql.Controls.Add(this.txtSQL);
            this.tabPageSql.Location = new System.Drawing.Point(4, 26);
            this.tabPageSql.Name = "tabPageSql";
            this.tabPageSql.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSql.Size = new System.Drawing.Size(346, 201);
            this.tabPageSql.TabIndex = 0;
            this.tabPageSql.Text = "SQL";
            this.tabPageSql.UseVisualStyleBackColor = true;
            // 
            // txtSQL
            // 
            this.txtSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSQL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSQL.FontWhenNull = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSQL.ForeColorWhenNull = System.Drawing.Color.Gray;
            this.txtSQL.Location = new System.Drawing.Point(3, 3);
            this.txtSQL.MaxLength = 999999999;
            this.txtSQL.Multiline = true;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSQL.Size = new System.Drawing.Size(340, 195);
            this.txtSQL.TabIndex = 0;
            this.txtSQL.TextWhenNull = "";
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbParseSQL});
            this.toolStrip.Location = new System.Drawing.Point(3, 19);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.ShowItemToolTips = false;
            this.toolStrip.Size = new System.Drawing.Size(354, 25);
            this.toolStrip.TabIndex = 6;
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
            // cbCanEdit
            // 
            this.cbCanEdit.AutoSize = true;
            this.cbCanEdit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCanEdit.Location = new System.Drawing.Point(9, 53);
            this.cbCanEdit.Name = "cbCanEdit";
            this.cbCanEdit.Size = new System.Drawing.Size(99, 21);
            this.cbCanEdit.TabIndex = 7;
            this.cbCanEdit.Text = "下拉框可录入";
            this.cbCanEdit.UseVisualStyleBackColor = true;
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
            this.cmbActionAfterEnterKeyDown.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "回车后：";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.cmbActionAfterEnterKeyDown);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbDefaultValue);
            this.groupBox2.Controls.Add(this.cbCanEdit);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(3, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 278);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            // 
            // ComboBoxSettingUserControl
            // 
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ComboBoxSettingUserControl";
            this.Size = new System.Drawing.Size(692, 278);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageSql.ResumeLayout(false);
            this.tabPageSql.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private QuickReportLib.Controls.GlobalValue.ComboBoxForNormalGlobalValueAsker cmbDefaultValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbParseSQL;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageSql;
        private QuickReportLib.Controls.GlobalValue.TextBoxForNormalGlobalValueAsker txtSQL;
        private System.Windows.Forms.CheckBox cbCanEdit;
        private QuickReportLib.Controls.Plus.ComboBoxActionAfterEnterKeyDown cmbActionAfterEnterKeyDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}
