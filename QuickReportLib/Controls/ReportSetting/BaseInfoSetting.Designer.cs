namespace QuickReportLib.Controls.ReportSetting
{
    partial class BaseInfoSetting
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.GroupBox();
            this.btCopy = new System.Windows.Forms.Button();
            this.txtReportID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReportName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbReportTypes = new QuickReportLib.Controls.Plus.ComboBoxPlus();
            this.tabControlSQL = new System.Windows.Forms.TabControl();
            this.tabPage = new System.Windows.Forms.TabPage();
            this.txtSQL = new QuickReportLib.Controls.GlobalValue.TextBoxForMainReportSQL();
            this.panel1.SuspendLayout();
            this.tabControlSQL.SuspendLayout();
            this.tabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "报表分类：";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.btCopy);
            this.panel1.Controls.Add(this.txtReportID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtReportName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbReportTypes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 278);
            this.panel1.TabIndex = 2;
            this.panel1.TabStop = false;
            // 
            // btCopy
            // 
            this.btCopy.Location = new System.Drawing.Point(222, 113);
            this.btCopy.Name = "btCopy";
            this.btCopy.Size = new System.Drawing.Size(85, 29);
            this.btCopy.TabIndex = 7;
            this.btCopy.Text = "复制编号";
            this.btCopy.UseVisualStyleBackColor = true;
            this.btCopy.Click += new System.EventHandler(this.btCopy_Click);
            // 
            // txtReportID
            // 
            this.txtReportID.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtReportID.Location = new System.Drawing.Point(80, 85);
            this.txtReportID.Name = "txtReportID";
            this.txtReportID.ReadOnly = true;
            this.txtReportID.Size = new System.Drawing.Size(227, 21);
            this.txtReportID.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "报表编号：";
            // 
            // txtReportName
            // 
            this.txtReportName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtReportName.Location = new System.Drawing.Point(80, 51);
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.Size = new System.Drawing.Size(227, 23);
            this.txtReportName.TabIndex = 4;
            this.txtReportName.TextChanged += new System.EventHandler(this.txtReportName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 53);
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
            this.cmbReportTypes.Location = new System.Drawing.Point(80, 16);
            this.cmbReportTypes.Name = "cmbReportTypes";
            this.cmbReportTypes.Size = new System.Drawing.Size(227, 25);
            this.cmbReportTypes.TabIndex = 2;
            this.cmbReportTypes.TextChanged += new System.EventHandler(this.cmbReportTypes_TextChanged);
            // 
            // tabControlSQL
            // 
            this.tabControlSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSQL.Controls.Add(this.tabPage);
            this.tabControlSQL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlSQL.Location = new System.Drawing.Point(332, 0);
            this.tabControlSQL.Name = "tabControlSQL";
            this.tabControlSQL.SelectedIndex = 0;
            this.tabControlSQL.Size = new System.Drawing.Size(360, 278);
            this.tabControlSQL.TabIndex = 3;
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.txtSQL);
            this.tabPage.Location = new System.Drawing.Point(4, 26);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(352, 248);
            this.tabPage.TabIndex = 0;
            this.tabPage.Text = "SQL";
            this.tabPage.UseVisualStyleBackColor = true;
            // 
            // txtSQL
            // 
            this.txtSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSQL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSQL.FontWhenNull = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSQL.ForeColorWhenNull = System.Drawing.Color.Gray;
            this.txtSQL.Location = new System.Drawing.Point(3, 3);
            this.txtSQL.MaxLength = 999999999;
            this.txtSQL.Multiline = true;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.ReadOnly = true;
            this.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSQL.Size = new System.Drawing.Size(346, 242);
            this.txtSQL.TabIndex = 4;
            this.txtSQL.TextWhenNull = "";
            // 
            // BaseInfoSetting
            // 
            this.Controls.Add(this.tabControlSQL);
            this.Controls.Add(this.panel1);
            this.Name = "BaseInfoSetting";
            this.Size = new System.Drawing.Size(692, 278);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControlSQL.ResumeLayout(false);
            this.tabPage.ResumeLayout(false);
            this.tabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox panel1;
        private QuickReportLib.Controls.Plus.ComboBoxPlus cmbReportTypes;
        private System.Windows.Forms.TextBox txtReportName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReportID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btCopy;
        private System.Windows.Forms.TabControl tabControlSQL;
        private System.Windows.Forms.TabPage tabPage;
        private QuickReportLib.Controls.GlobalValue.TextBoxForMainReportSQL txtSQL;

    }
}
