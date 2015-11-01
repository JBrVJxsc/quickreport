namespace QuickReportLib.Controls.ReportSetting
{
    partial class TreeSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeSetting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbGroupNodeName = new QuickReportLib.Controls.Plus.ComboBoxPlus();
            this.cmbGroupNodeCode = new QuickReportLib.Controls.Plus.ComboBoxPlus();
            this.cmbNodeName = new QuickReportLib.Controls.Plus.ComboBoxPlus();
            this.cmbNodeCode = new QuickReportLib.Controls.Plus.ComboBoxPlus();
            this.cbMultiSelect = new System.Windows.Forms.CheckBox();
            this.txtRootCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRootName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSQL = new QuickReportLib.Controls.GlobalValue.TextBoxForNormalGlobalValueAsker();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbParseSQL = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.cmbGroupNodeName);
            this.groupBox1.Controls.Add(this.cmbGroupNodeCode);
            this.groupBox1.Controls.Add(this.cmbNodeName);
            this.groupBox1.Controls.Add(this.cmbNodeCode);
            this.groupBox1.Controls.Add(this.cbMultiSelect);
            this.groupBox1.Controls.Add(this.txtRootCode);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtRootName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 278);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbGroupNodeName
            // 
            this.cmbGroupNodeName.ColumnShowState = QuickReportLib.Enums.ComboBoxPlusColumnShowState.Both;
            this.cmbGroupNodeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupNodeName.FilterName = "过滤框";
            this.cmbGroupNodeName.FormattingEnabled = true;
            this.cmbGroupNodeName.Location = new System.Drawing.Point(80, 196);
            this.cmbGroupNodeName.Name = "cmbGroupNodeName";
            this.cmbGroupNodeName.Size = new System.Drawing.Size(166, 25);
            this.cmbGroupNodeName.TabIndex = 41;
            // 
            // cmbGroupNodeCode
            // 
            this.cmbGroupNodeCode.ColumnShowState = QuickReportLib.Enums.ComboBoxPlusColumnShowState.Both;
            this.cmbGroupNodeCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupNodeCode.FilterName = "过滤框";
            this.cmbGroupNodeCode.FormattingEnabled = true;
            this.cmbGroupNodeCode.Location = new System.Drawing.Point(80, 160);
            this.cmbGroupNodeCode.Name = "cmbGroupNodeCode";
            this.cmbGroupNodeCode.Size = new System.Drawing.Size(166, 25);
            this.cmbGroupNodeCode.TabIndex = 40;
            // 
            // cmbNodeName
            // 
            this.cmbNodeName.ColumnShowState = QuickReportLib.Enums.ComboBoxPlusColumnShowState.Both;
            this.cmbNodeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeName.FilterName = "过滤框";
            this.cmbNodeName.FormattingEnabled = true;
            this.cmbNodeName.Location = new System.Drawing.Point(80, 124);
            this.cmbNodeName.Name = "cmbNodeName";
            this.cmbNodeName.Size = new System.Drawing.Size(166, 25);
            this.cmbNodeName.TabIndex = 39;
            // 
            // cmbNodeCode
            // 
            this.cmbNodeCode.ColumnShowState = QuickReportLib.Enums.ComboBoxPlusColumnShowState.Both;
            this.cmbNodeCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeCode.FilterName = "过滤框";
            this.cmbNodeCode.FormattingEnabled = true;
            this.cmbNodeCode.Location = new System.Drawing.Point(80, 88);
            this.cmbNodeCode.Name = "cmbNodeCode";
            this.cmbNodeCode.Size = new System.Drawing.Size(166, 25);
            this.cmbNodeCode.TabIndex = 38;
            // 
            // cbMultiSelect
            // 
            this.cbMultiSelect.AutoSize = true;
            this.cbMultiSelect.Location = new System.Drawing.Point(9, 234);
            this.cbMultiSelect.Name = "cbMultiSelect";
            this.cbMultiSelect.Size = new System.Drawing.Size(87, 21);
            this.cbMultiSelect.TabIndex = 37;
            this.cbMultiSelect.Text = "节点可多选";
            this.cbMultiSelect.UseVisualStyleBackColor = true;
            // 
            // txtRootCode
            // 
            this.txtRootCode.Location = new System.Drawing.Point(68, 17);
            this.txtRootCode.Name = "txtRootCode";
            this.txtRootCode.Size = new System.Drawing.Size(178, 23);
            this.txtRootCode.TabIndex = 36;
            this.txtRootCode.Text = "ALL";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 17);
            this.label11.TabIndex = 35;
            this.label11.Text = "根编码：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 17);
            this.label10.TabIndex = 34;
            this.label10.Text = "分组编码：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "根名称：";
            // 
            // txtRootName
            // 
            this.txtRootName.Location = new System.Drawing.Point(68, 53);
            this.txtRootName.Name = "txtRootName";
            this.txtRootName.Size = new System.Drawing.Size(178, 23);
            this.txtRootName.TabIndex = 33;
            this.txtRootName.Text = "默认";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 31;
            this.label5.Text = "分组名称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "节点名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "节点编码：";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtSQL);
            this.groupBox2.Controls.Add(this.toolStrip);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(332, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 278);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SQL";
            // 
            // txtSQL
            // 
            this.txtSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSQL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSQL.FontWhenNull = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSQL.ForeColorWhenNull = System.Drawing.Color.Gray;
            this.txtSQL.Location = new System.Drawing.Point(3, 44);
            this.txtSQL.MaxLength = 999999999;
            this.txtSQL.Multiline = true;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSQL.Size = new System.Drawing.Size(354, 231);
            this.txtSQL.TabIndex = 7;
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
            // 
            // TreeSetting
            // 
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TreeSetting";
            this.Size = new System.Drawing.Size(692, 278);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbParseSQL;
        private QuickReportLib.Controls.GlobalValue.TextBoxForNormalGlobalValueAsker txtSQL;
        private System.Windows.Forms.TextBox txtRootCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRootName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbMultiSelect;
        private QuickReportLib.Controls.Plus.ComboBoxPlus cmbNodeCode;
        private QuickReportLib.Controls.Plus.ComboBoxPlus cmbNodeName;
        private QuickReportLib.Controls.Plus.ComboBoxPlus cmbGroupNodeName;
        private QuickReportLib.Controls.Plus.ComboBoxPlus cmbGroupNodeCode;
    }
}
