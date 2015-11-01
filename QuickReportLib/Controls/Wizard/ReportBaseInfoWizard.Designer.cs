namespace QuickReportLib.Controls.Wizard
{
    partial class ReportBaseInfoWizard
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
            this.txtReportName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbReportTypes = new QuickReportLib.Controls.Plus.ComboBoxPlus();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSQL = new QuickReportLib.Controls.Plus.TextBoxPlus();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtReportName
            // 
            this.txtReportName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtReportName.Location = new System.Drawing.Point(300, 10);
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.Size = new System.Drawing.Size(260, 23);
            this.txtReportName.TabIndex = 4;
            this.txtReportName.Text = "test报表名称";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtReportName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbReportTypes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 72);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(4, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "SQL：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(226, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "报表名称：";
            // 
            // cmbReportTypes
            // 
            this.cmbReportTypes.ColumnShowState = QuickReportLib.Enums.ComboBoxPlusColumnShowState.Both;
            this.cmbReportTypes.FilterName = "报表分类";
            this.cmbReportTypes.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbReportTypes.FormattingEnabled = true;
            this.cmbReportTypes.Location = new System.Drawing.Point(78, 9);
            this.cmbReportTypes.Name = "cmbReportTypes";
            this.cmbReportTypes.Size = new System.Drawing.Size(121, 25);
            this.cmbReportTypes.TabIndex = 2;
            this.cmbReportTypes.Text = "test报表分类";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "报表分类：";
            // 
            // txtSQL
            // 
            this.txtSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSQL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSQL.FontWhenNull = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Italic);
            this.txtSQL.ForeColorWhenNull = System.Drawing.Color.Gray;
            this.txtSQL.Location = new System.Drawing.Point(0, 72);
            this.txtSQL.MaxLength = 999999999;
            this.txtSQL.Multiline = true;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSQL.Size = new System.Drawing.Size(582, 265);
            this.txtSQL.TabIndex = 9;
            this.txtSQL.Text = "select * from quickreport_reports  ";
            this.txtSQL.TextWhenNull = "";
            // 
            // ReportBaseInfoWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            
            this.Controls.Add(this.txtSQL);
            this.Controls.Add(this.panel1);
            this.Name = "ReportBaseInfoWizard";
            this.Size = new System.Drawing.Size(582, 337);
            this.Load += new System.EventHandler(this.ReportBaseInfoWizard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReportName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private QuickReportLib.Controls.Plus.ComboBoxPlus cmbReportTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private QuickReportLib.Controls.Plus.TextBoxPlus txtSQL;
    }
}
