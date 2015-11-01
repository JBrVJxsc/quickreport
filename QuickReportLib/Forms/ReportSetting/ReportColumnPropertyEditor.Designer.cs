namespace QuickReportLib.Forms.ReportSetting
{
    partial class ReportColumnPropertyEditor
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.Location = new System.Drawing.Point(0, 18);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(464, 25);
            this.tsMain.TabIndex = 2;
            // 
            // ReportColumnPropertyEditor
            // 
            this.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(202)))), ((int)(((byte)(219)))));
            this.ArrowOffset = new System.Drawing.Point(0, 5);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            
            this.ClientSize = new System.Drawing.Size(464, 153);
            this.Controls.Add(this.tsMain);
            this.Name = "ReportColumnPropertyEditor";
            this.PanelHeight = 18;
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;







    }
}