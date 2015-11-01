namespace QuickReportCore.Controls
{
    partial class ucConditionList
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
            this.grpConditions = new System.Windows.Forms.GroupBox();
            this.pnlConditions = new System.Windows.Forms.Panel();
            this.grpConditions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConditions
            // 
            this.grpConditions.Controls.Add(this.pnlConditions);
            this.grpConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConditions.Location = new System.Drawing.Point(0, 0);
            this.grpConditions.Name = "grpConditions";
            this.grpConditions.Size = new System.Drawing.Size(435, 333);
            this.grpConditions.TabIndex = 0;
            this.grpConditions.TabStop = false;
            // 
            // pnlConditions
            // 
            this.pnlConditions.AutoScroll = true;
            this.pnlConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConditions.Location = new System.Drawing.Point(3, 17);
            this.pnlConditions.Name = "pnlConditions";
            this.pnlConditions.Size = new System.Drawing.Size(429, 313);
            this.pnlConditions.TabIndex = 0;
            // 
            // ucConditionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpConditions);
            this.Name = "ucConditionList";
            this.Size = new System.Drawing.Size(435, 333);
            this.grpConditions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConditions;
        private System.Windows.Forms.Panel pnlConditions;
    }
}
