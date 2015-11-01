namespace QuickReportCore.Controls
{
    partial class ucConditionObject
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
            this.grbConditionObject = new System.Windows.Forms.GroupBox();
            this.pnlConditionObject = new System.Windows.Forms.Panel();
            this.cbNotNull = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkDefaultValue = new System.Windows.Forms.LinkLabel();
            this.txtConditionName = new System.Windows.Forms.TextBox();
            this.cbUse = new System.Windows.Forms.CheckBox();
            this.cbDefaultShow = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbConditionType = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.grbConditionObject.SuspendLayout();
            this.pnlConditionObject.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbConditionObject
            // 
            this.grbConditionObject.Controls.Add(this.pnlConditionObject);
            this.grbConditionObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbConditionObject.Location = new System.Drawing.Point(0, 0);
            this.grbConditionObject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbConditionObject.Name = "grbConditionObject";
            this.grbConditionObject.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbConditionObject.Size = new System.Drawing.Size(555, 55);
            this.grbConditionObject.TabIndex = 5;
            this.grbConditionObject.TabStop = false;
            // 
            // pnlConditionObject
            // 
            this.pnlConditionObject.Controls.Add(this.cbNotNull);
            this.pnlConditionObject.Controls.Add(this.cmbConditionType);
            this.pnlConditionObject.Controls.Add(this.label2);
            this.pnlConditionObject.Controls.Add(this.lnkDefaultValue);
            this.pnlConditionObject.Controls.Add(this.txtConditionName);
            this.pnlConditionObject.Controls.Add(this.cbUse);
            this.pnlConditionObject.Controls.Add(this.cbDefaultShow);
            this.pnlConditionObject.Controls.Add(this.label1);
            this.pnlConditionObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConditionObject.Location = new System.Drawing.Point(3, 20);
            this.pnlConditionObject.Name = "pnlConditionObject";
            this.pnlConditionObject.Size = new System.Drawing.Size(549, 31);
            this.pnlConditionObject.TabIndex = 0;
            // 
            // cbNotNull
            // 
            this.cbNotNull.AutoSize = true;
            this.cbNotNull.Checked = true;
            this.cbNotNull.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNotNull.Location = new System.Drawing.Point(260, 4);
            this.cbNotNull.Name = "cbNotNull";
            this.cbNotNull.Size = new System.Drawing.Size(51, 21);
            this.cbNotNull.TabIndex = 24;
            this.cbNotNull.Text = "非空";
            this.cbNotNull.UseVisualStyleBackColor = true;
            this.cbNotNull.CheckedChanged += new System.EventHandler(this.cbNotNull_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "条件类型：";
            // 
            // lnkDefaultValue
            // 
            this.lnkDefaultValue.AutoSize = true;
            this.lnkDefaultValue.Location = new System.Drawing.Point(495, 5);
            this.lnkDefaultValue.Name = "lnkDefaultValue";
            this.lnkDefaultValue.Size = new System.Drawing.Size(32, 17);
            this.lnkDefaultValue.TabIndex = 22;
            this.lnkDefaultValue.TabStop = true;
            this.lnkDefaultValue.Text = "设置";
            this.lnkDefaultValue.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDefaultValue_LinkClicked);
            // 
            // txtConditionName
            // 
            this.txtConditionName.Location = new System.Drawing.Point(48, 3);
            this.txtConditionName.Name = "txtConditionName";
            this.txtConditionName.ReadOnly = true;
            this.txtConditionName.Size = new System.Drawing.Size(75, 23);
            this.txtConditionName.TabIndex = 21;
            this.txtConditionName.TextChanged += new System.EventHandler(this.txtConditionName_TextChanged);
            // 
            // cbUse
            // 
            this.cbUse.AutoSize = true;
            this.cbUse.Location = new System.Drawing.Point(132, 4);
            this.cbUse.Name = "cbUse";
            this.cbUse.Size = new System.Drawing.Size(51, 21);
            this.cbUse.TabIndex = 20;
            this.cbUse.Text = "显示";
            this.cbUse.UseVisualStyleBackColor = true;
            this.cbUse.CheckedChanged += new System.EventHandler(this.cbHide_CheckedChanged);
            // 
            // cbDefaultShow
            // 
            this.cbDefaultShow.AutoSize = true;
            this.cbDefaultShow.Location = new System.Drawing.Point(184, 4);
            this.cbDefaultShow.Name = "cbDefaultShow";
            this.cbDefaultShow.Size = new System.Drawing.Size(75, 21);
            this.cbDefaultShow.TabIndex = 19;
            this.cbDefaultShow.Text = "默认显示";
            this.cbDefaultShow.UseVisualStyleBackColor = true;
            this.cbDefaultShow.CheckedChanged += new System.EventHandler(this.cbDefaultShow_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "名称：";
            // 
            // cmbConditionType
            // 
            this.cmbConditionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConditionType.FilterName = "选择条件类型";
            this.cmbConditionType.FormattingEnabled = true;
            this.cmbConditionType.Location = new System.Drawing.Point(376, 2);
            this.cmbConditionType.Name = "cmbConditionType";
            this.cmbConditionType.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Both;
            this.cmbConditionType.Size = new System.Drawing.Size(115, 25);
            this.cmbConditionType.TabIndex = 23;
            this.cmbConditionType.SelectedIndexChanged += new System.EventHandler(this.cmbConditionType_SelectedIndexChanged);
            // 
            // ucConditionObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbConditionObject);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucConditionObject";
            this.Size = new System.Drawing.Size(555, 55);
            this.Load += new System.EventHandler(this.ucConditionObject_Load);
            this.grbConditionObject.ResumeLayout(false);
            this.pnlConditionObject.ResumeLayout(false);
            this.pnlConditionObject.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbConditionObject;
        private System.Windows.Forms.Panel pnlConditionObject;
        private System.Windows.Forms.TextBox txtConditionName;
        private System.Windows.Forms.CheckBox cbUse;
        private System.Windows.Forms.CheckBox cbDefaultShow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkDefaultValue;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbConditionType;
        private System.Windows.Forms.CheckBox cbNotNull;


    }
}
