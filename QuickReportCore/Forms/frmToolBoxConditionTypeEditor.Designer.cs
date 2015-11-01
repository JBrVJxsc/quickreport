namespace QuickReportCore.Forms
{
    partial class frmToolBoxConditionTypeEditor
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
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.tbSave = new System.Windows.Forms.ToolStripButton();
            this.tbUseAll = new System.Windows.Forms.ToolStripButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageCustom = new System.Windows.Forms.TabPage();
            this.ucConditionTypeElementListWithFarpoint = new QuickReportCore.Controls.ucConditionTypeElementListWithFarpoint();
            this.tabPageSql = new System.Windows.Forms.TabPage();
            this.txtSql = new System.Windows.Forms.TextBox();
            this.toolStripMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageCustom.SuspendLayout();
            this.tabPageSql.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSave,
            this.tbUseAll});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(253, 39);
            this.toolStripMain.TabIndex = 28;
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
            // tbUseAll
            // 
            this.tbUseAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbUseAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbUseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUseAll.Name = "tbUseAll";
            this.tbUseAll.Size = new System.Drawing.Size(84, 36);
            this.tbUseAll.Text = "增加“全部”";
            this.tbUseAll.ToolTipText = "在自定义元素列表中增加“全部”选项。";
            this.tbUseAll.Click += new System.EventHandler(this.tbUseAll_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageCustom);
            this.tabControl.Controls.Add(this.tabPageSql);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 39);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(253, 281);
            this.tabControl.TabIndex = 29;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageCustom
            // 
            this.tabPageCustom.Controls.Add(this.ucConditionTypeElementListWithFarpoint);
            this.tabPageCustom.Location = new System.Drawing.Point(4, 26);
            this.tabPageCustom.Name = "tabPageCustom";
            this.tabPageCustom.Size = new System.Drawing.Size(245, 251);
            this.tabPageCustom.TabIndex = 2;
            this.tabPageCustom.Text = "自定义元素";
            this.tabPageCustom.UseVisualStyleBackColor = true;
            // 
            // ucConditionTypeElementListWithFarpoint
            // 
            this.ucConditionTypeElementListWithFarpoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucConditionTypeElementListWithFarpoint.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucConditionTypeElementListWithFarpoint.Location = new System.Drawing.Point(0, 0);
            this.ucConditionTypeElementListWithFarpoint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucConditionTypeElementListWithFarpoint.Name = "ucConditionTypeElementListWithFarpoint";
            this.ucConditionTypeElementListWithFarpoint.Size = new System.Drawing.Size(245, 251);
            this.ucConditionTypeElementListWithFarpoint.TabIndex = 0;
            // 
            // tabPageSql
            // 
            this.tabPageSql.BackColor = System.Drawing.Color.Transparent;
            this.tabPageSql.Controls.Add(this.txtSql);
            this.tabPageSql.Location = new System.Drawing.Point(4, 26);
            this.tabPageSql.Name = "tabPageSql";
            this.tabPageSql.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSql.Size = new System.Drawing.Size(245, 251);
            this.tabPageSql.TabIndex = 1;
            this.tabPageSql.Text = "自定义SQL";
            this.tabPageSql.UseVisualStyleBackColor = true;
            // 
            // txtSql
            // 
            this.txtSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSql.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSql.Location = new System.Drawing.Point(3, 3);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSql.Size = new System.Drawing.Size(239, 245);
            this.txtSql.TabIndex = 1;
            this.txtSql.TextChanged += new System.EventHandler(this.txtSql_TextChanged);
            this.txtSql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSql_KeyDown);
            // 
            // frmToolBoxConditionTypeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CannotClose = true;
            this.ClientSize = new System.Drawing.Size(253, 320);
            this.CloseToHide = true;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStripMain);
            this.ForceActiveForm = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmToolBoxConditionTypeEditor";
            this.Opacity = 0.85;
            this.Text = "自定义条件";
            this.Load += new System.EventHandler(this.frmToolBoxConditionTypeEditor_Load);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageCustom.ResumeLayout(false);
            this.tabPageSql.ResumeLayout(false);
            this.tabPageSql.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton tbSave;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageSql;
        private System.Windows.Forms.TextBox txtSql;
        private System.Windows.Forms.TabPage tabPageCustom;
        private QuickReportCore.Controls.ucConditionTypeElementListWithFarpoint ucConditionTypeElementListWithFarpoint;
        private System.Windows.Forms.ToolStripButton tbUseAll;
    }
}