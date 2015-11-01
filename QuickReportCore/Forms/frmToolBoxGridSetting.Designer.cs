namespace QuickReportCore.Forms
{
    partial class frmToolBoxGridSetting
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
            this.cmbRowGroupSum = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.cbUseHeader = new System.Windows.Forms.CheckBox();
            this.cbUseGroupSumRow = new System.Windows.Forms.CheckBox();
            this.txtRowGroupSumName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grbCrossSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbCrossSetting
            // 
            this.grbCrossSetting.Controls.Add(this.cbUnion);
            this.grbCrossSetting.Controls.Add(this.cmbRowGroupSum);
            this.grbCrossSetting.Controls.Add(this.cbUseHeader);
            this.grbCrossSetting.Controls.Add(this.cbUseGroupSumRow);
            this.grbCrossSetting.Controls.Add(this.txtRowGroupSumName);
            this.grbCrossSetting.Controls.Add(this.label7);
            this.grbCrossSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbCrossSetting.Location = new System.Drawing.Point(0, 0);
            this.grbCrossSetting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbCrossSetting.Name = "grbCrossSetting";
            this.grbCrossSetting.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbCrossSetting.Size = new System.Drawing.Size(253, 156);
            this.grbCrossSetting.TabIndex = 1;
            this.grbCrossSetting.TabStop = false;
            // 
            // cbUnion
            // 
            this.cbUnion.AutoSize = true;
            this.cbUnion.Location = new System.Drawing.Point(190, 110);
            this.cbUnion.Name = "cbUnion";
            this.cbUnion.Size = new System.Drawing.Size(51, 21);
            this.cbUnion.TabIndex = 38;
            this.cbUnion.Text = "合并";
            this.cbUnion.UseVisualStyleBackColor = true;
            this.cbUnion.Visible = false;
            this.cbUnion.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cmbRowGroupSum
            // 
            this.cmbRowGroupSum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRowGroupSum.FilterName = "过滤框";
            this.cmbRowGroupSum.FormattingEnabled = true;
            this.cmbRowGroupSum.Location = new System.Drawing.Point(72, 18);
            this.cmbRowGroupSum.Name = "cmbRowGroupSum";
            this.cmbRowGroupSum.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbRowGroupSum.Size = new System.Drawing.Size(155, 25);
            this.cmbRowGroupSum.TabIndex = 0;
            this.cmbRowGroupSum.SelectedIndexChanged += new System.EventHandler(this.cmbRowGroupSum_SelectedIndexChanged);
            this.cmbRowGroupSum.DropDownClosed += new System.EventHandler(this.cmb_DropDownClosed);
            this.cmbRowGroupSum.DropDown += new System.EventHandler(this.cmb_DropDown);
            // 
            // cbUseHeader
            // 
            this.cbUseHeader.AutoSize = true;
            this.cbUseHeader.Location = new System.Drawing.Point(119, 54);
            this.cbUseHeader.Name = "cbUseHeader";
            this.cbUseHeader.Size = new System.Drawing.Size(75, 21);
            this.cbUseHeader.TabIndex = 37;
            this.cbUseHeader.Text = "独立样式";
            this.cbUseHeader.UseVisualStyleBackColor = true;
            this.cbUseHeader.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbUseGroupSumRow
            // 
            this.cbUseGroupSumRow.AutoSize = true;
            this.cbUseGroupSumRow.Location = new System.Drawing.Point(15, 54);
            this.cbUseGroupSumRow.Name = "cbUseGroupSumRow";
            this.cbUseGroupSumRow.Size = new System.Drawing.Size(51, 21);
            this.cbUseGroupSumRow.TabIndex = 36;
            this.cbUseGroupSumRow.Text = "小计";
            this.cbUseGroupSumRow.UseVisualStyleBackColor = true;
            this.cbUseGroupSumRow.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // txtRowGroupSumName
            // 
            this.txtRowGroupSumName.Location = new System.Drawing.Point(67, 52);
            this.txtRowGroupSumName.Name = "txtRowGroupSumName";
            this.txtRowGroupSumName.Size = new System.Drawing.Size(41, 23);
            this.txtRowGroupSumName.TabIndex = 31;
            this.txtRowGroupSumName.Text = "小计";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 29;
            this.label7.Text = "行分组：";
            // 
            // frmToolBoxGridSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CannotClose = true;
            this.ClientSize = new System.Drawing.Size(253, 156);
            this.ControlBox = false;
            this.Controls.Add(this.grbCrossSetting);
            this.ForceActiveForm = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmToolBoxGridSetting";
            this.Opacity = 0.85;
            this.Text = "网格报表设置";
            this.grbCrossSetting.ResumeLayout(false);
            this.grbCrossSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbCrossSetting;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRowGroupSumName;
        private System.Windows.Forms.CheckBox cbUseHeader;
        private System.Windows.Forms.CheckBox cbUseGroupSumRow;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbRowGroupSum;
        private System.Windows.Forms.CheckBox cbUnion;
    }
}