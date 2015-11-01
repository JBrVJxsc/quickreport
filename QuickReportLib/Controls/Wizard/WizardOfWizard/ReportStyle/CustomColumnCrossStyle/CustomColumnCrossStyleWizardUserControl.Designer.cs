namespace QuickReportLib.Controls.Wizard.WizardOfWizard.ReportStyle.CustomColumnCrossStyle
{
    partial class CustomColumnCrossStyleWizardUserControl
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustomColumnSQL = new QuickReportLib.Controls.Plus.TextBoxPlus();
            this.btParseSQL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(16, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "列SQL：";
            // 
            // txtCustomColumnSQL
            // 
            this.txtCustomColumnSQL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCustomColumnSQL.FontWhenNull = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Italic);
            this.txtCustomColumnSQL.ForeColorWhenNull = System.Drawing.Color.Gray;
            this.txtCustomColumnSQL.Location = new System.Drawing.Point(76, 181);
            this.txtCustomColumnSQL.Multiline = true;
            this.txtCustomColumnSQL.Name = "txtCustomColumnSQL";
            this.txtCustomColumnSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCustomColumnSQL.Size = new System.Drawing.Size(399, 140);
            this.txtCustomColumnSQL.TabIndex = 15;
            this.txtCustomColumnSQL.TextWhenNull = "";
            this.txtCustomColumnSQL.Enter += new System.EventHandler(this.txtCustomColumnSQL_Enter);
            // 
            // btParseSQL
            // 
            this.btParseSQL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btParseSQL.Location = new System.Drawing.Point(481, 181);
            this.btParseSQL.Name = "btParseSQL";
            this.btParseSQL.Size = new System.Drawing.Size(85, 29);
            this.btParseSQL.TabIndex = 16;
            this.btParseSQL.Text = "解析";
            this.btParseSQL.UseVisualStyleBackColor = true;
            this.btParseSQL.Click += new System.EventHandler(this.btParseSQL_Click);
            // 
            // CustomColumnCrossStyleWizardUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            
            this.Controls.Add(this.btParseSQL);
            this.Controls.Add(this.txtCustomColumnSQL);
            this.Controls.Add(this.label5);
            this.Name = "CustomColumnCrossStyleWizardUserControl";
            this.Size = new System.Drawing.Size(598, 335);
            this.Controls.SetChildIndex(this.imgPreview, 0);
            this.Controls.SetChildIndex(this.cmbRow, 0);
            this.Controls.SetChildIndex(this.cmbColumn, 0);
            this.Controls.SetChildIndex(this.cmbValue, 0);
            this.Controls.SetChildIndex(this.txtRowText, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtCustomColumnSQL, 0);
            this.Controls.SetChildIndex(this.btParseSQL, 0);
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private QuickReportLib.Controls.Plus.TextBoxPlus txtCustomColumnSQL;
        private System.Windows.Forms.Button btParseSQL;
    }
}
