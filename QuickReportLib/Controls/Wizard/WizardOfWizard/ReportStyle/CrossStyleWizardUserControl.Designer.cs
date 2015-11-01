namespace QuickReportLib.Controls.Wizard.WizardOfWizard.ReportStyle
{
    partial class CrossStyleWizardUserControl
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRow = new QuickReportLib.Controls.Plus.ComboBoxPlus();
            this.cmbColumn = new QuickReportLib.Controls.Plus.ComboBoxPlus();
            this.cmbValue = new QuickReportLib.Controls.Plus.ComboBoxPlus();
            this.imgPreview = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRowText = new QuickReportLib.Controls.Plus.TextBoxPlus();
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(38, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "值：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(38, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "列：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(38, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "行：";
            // 
            // cmbRow
            // 
            this.cmbRow.ColumnShowState = QuickReportLib.Enums.ComboBoxPlusColumnShowState.Both;
            this.cmbRow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRow.FilterName = "过滤框";
            this.cmbRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbRow.FormattingEnabled = true;
            this.cmbRow.Location = new System.Drawing.Point(76, 19);
            this.cmbRow.Name = "cmbRow";
            this.cmbRow.Size = new System.Drawing.Size(158, 25);
            this.cmbRow.TabIndex = 0;
            this.cmbRow.SelectedIndexChanged += new System.EventHandler(this.cmbRow_SelectedIndexChanged);
            this.cmbRow.Enter += new System.EventHandler(this.cmbRow_Enter);
            // 
            // cmbColumn
            // 
            this.cmbColumn.ColumnShowState = QuickReportLib.Enums.ComboBoxPlusColumnShowState.Both;
            this.cmbColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumn.FilterName = "过滤框";
            this.cmbColumn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbColumn.FormattingEnabled = true;
            this.cmbColumn.Location = new System.Drawing.Point(76, 59);
            this.cmbColumn.Name = "cmbColumn";
            this.cmbColumn.Size = new System.Drawing.Size(158, 25);
            this.cmbColumn.TabIndex = 1;
            this.cmbColumn.SelectedIndexChanged += new System.EventHandler(this.cmbColumn_SelectedIndexChanged);
            this.cmbColumn.Enter += new System.EventHandler(this.cmbColumn_Enter);
            // 
            // cmbValue
            // 
            this.cmbValue.ColumnShowState = QuickReportLib.Enums.ComboBoxPlusColumnShowState.Both;
            this.cmbValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbValue.FilterName = "过滤框";
            this.cmbValue.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbValue.FormattingEnabled = true;
            this.cmbValue.Location = new System.Drawing.Point(76, 99);
            this.cmbValue.Name = "cmbValue";
            this.cmbValue.Size = new System.Drawing.Size(158, 25);
            this.cmbValue.TabIndex = 2;
            this.cmbValue.SelectedIndexChanged += new System.EventHandler(this.cmbValue_SelectedIndexChanged);
            this.cmbValue.Enter += new System.EventHandler(this.cmbValue_Enter);
            // 
            // imgPreview
            // 
            this.imgPreview.Location = new System.Drawing.Point(267, 16);
            this.imgPreview.Name = "imgPreview";
            this.imgPreview.Size = new System.Drawing.Size(208, 147);
            this.imgPreview.TabIndex = 11;
            this.imgPreview.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(15, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "行名称：";
            // 
            // txtRowText
            // 
            this.txtRowText.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRowText.FontWhenNull = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Italic);
            this.txtRowText.ForeColorWhenNull = System.Drawing.Color.Gray;
            this.txtRowText.Location = new System.Drawing.Point(76, 140);
            this.txtRowText.Name = "txtRowText";
            this.txtRowText.Size = new System.Drawing.Size(158, 23);
            this.txtRowText.TabIndex = 13;
            this.txtRowText.TextWhenNull = "";
            this.txtRowText.TextChanged += new System.EventHandler(this.txtRowText_TextChanged);
            this.txtRowText.Enter += new System.EventHandler(this.txtRowText_Enter);
            // 
            // CrossStyleWizardUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            
            this.Controls.Add(this.txtRowText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.imgPreview);
            this.Controls.Add(this.cmbValue);
            this.Controls.Add(this.cmbColumn);
            this.Controls.Add(this.cmbRow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "CrossStyleWizardUserControl";
            this.Size = new System.Drawing.Size(518, 353);
            this.Load += new System.EventHandler(this.GeneralCrossStyleWizardUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        protected QuickReportLib.Controls.Plus.ComboBoxPlus cmbRow;
        protected QuickReportLib.Controls.Plus.ComboBoxPlus cmbColumn;
        protected QuickReportLib.Controls.Plus.ComboBoxPlus cmbValue;
        protected QuickReportLib.Controls.Plus.TextBoxPlus txtRowText;
        protected System.Windows.Forms.PictureBox imgPreview;
    }
}
