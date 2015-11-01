namespace QuickReportLib.Controls.Wizard
{
    partial class ReportLayoutStyleWizard
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
            this.lbSummary = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlReportLayoutStyles = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSummary
            // 
            this.lbSummary.AutoSize = true;
            this.lbSummary.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSummary.Location = new System.Drawing.Point(62, 4);
            this.lbSummary.Name = "lbSummary";
            this.lbSummary.Size = new System.Drawing.Size(0, 17);
            this.lbSummary.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lbSummary);
            this.pnlBottom.Controls.Add(this.label1);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 291);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(555, 33);
            this.pnlBottom.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "简介：";
            // 
            // pnlReportLayoutStyles
            // 
            this.pnlReportLayoutStyles.AutoScroll = true;
            this.pnlReportLayoutStyles.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReportLayoutStyles.Location = new System.Drawing.Point(0, 0);
            this.pnlReportLayoutStyles.Name = "pnlReportLayoutStyles";
            this.pnlReportLayoutStyles.Size = new System.Drawing.Size(555, 291);
            this.pnlReportLayoutStyles.TabIndex = 2;
            // 
            // ReportLayoutStyleWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlReportLayoutStyles);
            this.Name = "ReportLayoutStyleWizard";
            this.Size = new System.Drawing.Size(555, 324);
            this.Load += new System.EventHandler(this.ReportLayoutStyleWizard_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbSummary;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel pnlReportLayoutStyles;

    }
}
