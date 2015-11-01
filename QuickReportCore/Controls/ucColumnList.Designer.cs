namespace QuickReportCore.Controls
{
    partial class ucColumnList
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
            this.grpColumns = new System.Windows.Forms.GroupBox();
            this.pnlColumns = new System.Windows.Forms.Panel();
            this.grpColumns.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpColumns
            // 
            this.grpColumns.Controls.Add(this.pnlColumns);
            this.grpColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpColumns.Location = new System.Drawing.Point(0, 0);
            this.grpColumns.Name = "grpColumns";
            this.grpColumns.Size = new System.Drawing.Size(443, 384);
            this.grpColumns.TabIndex = 0;
            this.grpColumns.TabStop = false;
            // 
            // pnlColumns
            // 
            this.pnlColumns.AutoScroll = true;
            this.pnlColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColumns.Location = new System.Drawing.Point(3, 17);
            this.pnlColumns.Name = "pnlColumns";
            this.pnlColumns.Size = new System.Drawing.Size(437, 364);
            this.pnlColumns.TabIndex = 1;
            // 
            // ucColumnList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpColumns);
            this.Name = "ucColumnList";
            this.Size = new System.Drawing.Size(443, 384);
            this.grpColumns.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpColumns;
        private System.Windows.Forms.Panel pnlColumns;

    }
}
