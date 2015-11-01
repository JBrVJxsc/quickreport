namespace QuickReportCore.Controls
{
    partial class ucReportInterfaceOtherSetting
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
            this.label7 = new System.Windows.Forms.Label();
            this.cmbActionType = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "INeedDatas动作：";
            // 
            // cmbActionType
            // 
            this.cmbActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActionType.FilterName = "选择动作";
            this.cmbActionType.FormattingEnabled = true;
            this.cmbActionType.Location = new System.Drawing.Point(128, 15);
            this.cmbActionType.Name = "cmbActionType";
            this.cmbActionType.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbActionType.Size = new System.Drawing.Size(141, 25);
            this.cmbActionType.TabIndex = 24;
            // 
            // ucReportInterfaceOtherSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbActionType);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucReportInterfaceOtherSetting";
            this.Size = new System.Drawing.Size(430, 372);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBoxWithFilter cmbActionType;
        private System.Windows.Forms.Label label7;

    }
}
