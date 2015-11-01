namespace QuickReportCore.Controls
{
    partial class ucReportConditionList
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
            this.pnlRight = new System.Windows.Forms.Panel();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.pnlOfPnl = new System.Windows.Forms.Panel();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.vScrollBar);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(896, 0);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(17, 67);
            this.pnlRight.TabIndex = 0;
            // 
            // vScrollBar
            // 
            this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vScrollBar.Location = new System.Drawing.Point(0, 0);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 67);
            this.vScrollBar.SmallChange = 10;
            this.vScrollBar.TabIndex = 0;
            this.vScrollBar.ValueChanged += new System.EventHandler(this.vScrollBar_ValueChanged);
            // 
            // pnlOfPnl
            // 
            this.pnlOfPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOfPnl.Location = new System.Drawing.Point(0, 0);
            this.pnlOfPnl.Name = "pnlOfPnl";
            this.pnlOfPnl.Size = new System.Drawing.Size(896, 67);
            this.pnlOfPnl.TabIndex = 1;
            // 
            // ucReportConditionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlOfPnl);
            this.Controls.Add(this.pnlRight);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucReportConditionList";
            this.Size = new System.Drawing.Size(913, 67);
            this.Load += new System.EventHandler(this.ucReportConditionList_Load);
            this.SizeChanged += new System.EventHandler(this.ucReportConditionListNew_SizeChanged);
            this.pnlRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlOfPnl;
        private System.Windows.Forms.VScrollBar vScrollBar;
    }
}
