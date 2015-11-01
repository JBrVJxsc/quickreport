namespace QuickReportLib.Controls.Wizard
{
    partial class ReportLayoutStyleWizardElement
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
            this.rbSelect = new System.Windows.Forms.RadioButton();
            this.imgStyle = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgStyle)).BeginInit();
            this.SuspendLayout();
            // 
            // rbSelect
            // 
            this.rbSelect.AutoSize = true;
            this.rbSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbSelect.Location = new System.Drawing.Point(3, 114);
            this.rbSelect.Name = "rbSelect";
            this.rbSelect.Size = new System.Drawing.Size(14, 13);
            this.rbSelect.TabIndex = 4;
            this.rbSelect.TabStop = true;
            this.rbSelect.UseVisualStyleBackColor = true;
            this.rbSelect.CheckedChanged += new System.EventHandler(this.rbSelect_CheckedChanged);
            // 
            // imgStyle
            // 
            this.imgStyle.Dock = System.Windows.Forms.DockStyle.Top;
            this.imgStyle.Location = new System.Drawing.Point(0, 0);
            this.imgStyle.Name = "imgStyle";
            this.imgStyle.Size = new System.Drawing.Size(174, 110);
            this.imgStyle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgStyle.TabIndex = 3;
            this.imgStyle.TabStop = false;
            this.imgStyle.Click += new System.EventHandler(this.imgStyle_Click);
            // 
            // ReportLayoutStyleWizardElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            
            this.Controls.Add(this.rbSelect);
            this.Controls.Add(this.imgStyle);
            this.Name = "ReportLayoutStyleWizardElement";
            this.Size = new System.Drawing.Size(174, 137);
            ((System.ComponentModel.ISupportInitialize)(this.imgStyle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbSelect;
        private System.Windows.Forms.PictureBox imgStyle;

    }
}
