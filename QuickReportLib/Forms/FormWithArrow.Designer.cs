namespace QuickReportLib.Forms
{
    partial class FormWithArrow
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
            this.pnlArrow = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlArrow
            // 
            this.pnlArrow.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlArrow.Location = new System.Drawing.Point(0, 0);
            this.pnlArrow.Name = "pnlArrow";
            this.pnlArrow.Size = new System.Drawing.Size(523, 48);
            this.pnlArrow.TabIndex = 0;
            this.pnlArrow.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlArrow_Paint);
            // 
            // FormWithArrow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            
            this.ClientSize = new System.Drawing.Size(523, 286);
            this.Controls.Add(this.pnlArrow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormWithArrow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlArrow;
    }
}