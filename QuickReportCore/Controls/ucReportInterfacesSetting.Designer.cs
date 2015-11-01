namespace QuickReportCore.Controls
{
    partial class ucReportInterfacesSetting
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
            this.tabControlInterfaces = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // tabControlInterfaces
            // 
            this.tabControlInterfaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlInterfaces.Location = new System.Drawing.Point(0, 0);
            this.tabControlInterfaces.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControlInterfaces.Name = "tabControlInterfaces";
            this.tabControlInterfaces.SelectedIndex = 0;
            this.tabControlInterfaces.Size = new System.Drawing.Size(650, 468);
            this.tabControlInterfaces.TabIndex = 0;
            // 
            // ucReportInterfacesSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlInterfaces);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucReportInterfacesSetting";
            this.Size = new System.Drawing.Size(650, 468);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlInterfaces;
    }
}
