namespace QuickReportCore.Forms
{
    partial class frmTestReport
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbQuery = new System.Windows.Forms.ToolStripButton();
            this.tbSetting = new System.Windows.Forms.ToolStripButton();
            this.tbExp = new System.Windows.Forms.ToolStripButton();
            this.tbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbExit = new System.Windows.Forms.ToolStripButton();
            this.panelShowReport = new System.Windows.Forms.Panel();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbQuery,
            this.tbSetting,
            this.tbExp,
            this.tbPrint,
            this.toolStripSeparator1,
            this.tbExit});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.ShowItemToolTips = false;
            this.toolStrip.Size = new System.Drawing.Size(781, 39);
            this.toolStrip.TabIndex = 8;
            // 
            // tbQuery
            // 
            this.tbQuery.Image = global::QuickReportCore.Properties.Resources.query;
            this.tbQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Size = new System.Drawing.Size(68, 36);
            this.tbQuery.Text = "查询";
            this.tbQuery.Click += new System.EventHandler(this.tbQuery_Click);
            // 
            // tbSetting
            // 
            this.tbSetting.Image = global::QuickReportCore.Properties.Resources.processing;
            this.tbSetting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSetting.Name = "tbSetting";
            this.tbSetting.Size = new System.Drawing.Size(68, 36);
            this.tbSetting.Text = "设置";
            this.tbSetting.Click += new System.EventHandler(this.tbSetting_Click);
            // 
            // tbExp
            // 
            this.tbExp.Image = global::QuickReportCore.Properties.Resources.export;
            this.tbExp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbExp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbExp.Name = "tbExp";
            this.tbExp.Size = new System.Drawing.Size(68, 36);
            this.tbExp.Text = "导出";
            this.tbExp.Click += new System.EventHandler(this.tbExp_Click);
            // 
            // tbPrint
            // 
            this.tbPrint.Image = global::QuickReportCore.Properties.Resources.print;
            this.tbPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPrint.Name = "tbPrint";
            this.tbPrint.Size = new System.Drawing.Size(68, 36);
            this.tbPrint.Text = "打印";
            this.tbPrint.Click += new System.EventHandler(this.tbPrint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tbExit
            // 
            this.tbExit.Image = global::QuickReportCore.Properties.Resources.exit;
            this.tbExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbExit.Name = "tbExit";
            this.tbExit.Size = new System.Drawing.Size(68, 36);
            this.tbExit.Text = "退出";
            this.tbExit.Click += new System.EventHandler(this.tbExit_Click);
            // 
            // panelShowReport
            // 
            this.panelShowReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShowReport.Location = new System.Drawing.Point(0, 39);
            this.panelShowReport.Name = "panelShowReport";
            this.panelShowReport.Size = new System.Drawing.Size(781, 433);
            this.panelShowReport.TabIndex = 9;
            // 
            // frmTestReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 472);
            this.Controls.Add(this.panelShowReport);
            this.Controls.Add(this.toolStrip);
            this.MinimizeBox = false;
            this.Name = "frmTestReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Deactivate += new System.EventHandler(this.frmTestReport_Deactivate);
            this.Activated += new System.EventHandler(this.frmTestReport_Activated);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbQuery;
        private System.Windows.Forms.ToolStripButton tbPrint;
        private System.Windows.Forms.Panel panelShowReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbExit;
        private System.Windows.Forms.ToolStripButton tbSetting;
        private System.Windows.Forms.ToolStripButton tbExp;
    }
}