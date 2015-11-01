namespace QuickReportCore.Controls
{
    partial class ucConditionTypeElementList
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
            this.grbConditionTypeElements = new System.Windows.Forms.GroupBox();
            this.pnlConditionTypeElements = new System.Windows.Forms.Panel();
            this.grbConditionTypeElements.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbConditionTypeElements
            // 
            this.grbConditionTypeElements.Controls.Add(this.pnlConditionTypeElements);
            this.grbConditionTypeElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbConditionTypeElements.Location = new System.Drawing.Point(0, 0);
            this.grbConditionTypeElements.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbConditionTypeElements.Name = "grbConditionTypeElements";
            this.grbConditionTypeElements.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbConditionTypeElements.Size = new System.Drawing.Size(454, 380);
            this.grbConditionTypeElements.TabIndex = 0;
            this.grbConditionTypeElements.TabStop = false;
            // 
            // pnlConditionTypeElements
            // 
            this.pnlConditionTypeElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConditionTypeElements.Location = new System.Drawing.Point(3, 20);
            this.pnlConditionTypeElements.Name = "pnlConditionTypeElements";
            this.pnlConditionTypeElements.Size = new System.Drawing.Size(448, 356);
            this.pnlConditionTypeElements.TabIndex = 0;
            // 
            // ucConditionTypeElementList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbConditionTypeElements);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucConditionTypeElementList";
            this.Size = new System.Drawing.Size(454, 380);
            this.grbConditionTypeElements.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbConditionTypeElements;
        private System.Windows.Forms.Panel pnlConditionTypeElements;
    }
}
