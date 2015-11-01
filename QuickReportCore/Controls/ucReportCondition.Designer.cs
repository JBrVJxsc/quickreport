namespace QuickReportCore.Controls
{
    partial class ucReportCondition
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
            this.grbReportCondition = new System.Windows.Forms.GroupBox();
            this.pnlReportCondition = new System.Windows.Forms.Panel();
            this.cmbAndOr = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.cmbOperator = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.lbConditionName = new System.Windows.Forms.Label();
            this.grbReportCondition.SuspendLayout();
            this.pnlReportCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbReportCondition
            // 
            this.grbReportCondition.Controls.Add(this.pnlReportCondition);
            this.grbReportCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbReportCondition.Location = new System.Drawing.Point(0, 0);
            this.grbReportCondition.Name = "grbReportCondition";
            this.grbReportCondition.Size = new System.Drawing.Size(248, 64);
            this.grbReportCondition.TabIndex = 0;
            this.grbReportCondition.TabStop = false;
            // 
            // pnlReportCondition
            // 
            this.pnlReportCondition.Controls.Add(this.cmbAndOr);
            this.pnlReportCondition.Controls.Add(this.cmbOperator);
            this.pnlReportCondition.Controls.Add(this.lbConditionName);
            this.pnlReportCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReportCondition.Location = new System.Drawing.Point(3, 19);
            this.pnlReportCondition.Name = "pnlReportCondition";
            this.pnlReportCondition.Size = new System.Drawing.Size(242, 42);
            this.pnlReportCondition.TabIndex = 0;
            // 
            // cmbAndOr
            // 
            this.cmbAndOr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAndOr.FilterName = "过滤框";
            this.cmbAndOr.FormattingEnabled = true;
            this.cmbAndOr.Location = new System.Drawing.Point(192, 2);
            this.cmbAndOr.Name = "cmbAndOr";
            this.cmbAndOr.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbAndOr.Size = new System.Drawing.Size(38, 25);
            this.cmbAndOr.TabIndex = 14;
            // 
            // cmbOperator
            // 
            this.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperator.FilterName = "过滤框";
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Location = new System.Drawing.Point(53, 3);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Name;
            this.cmbOperator.Size = new System.Drawing.Size(73, 25);
            this.cmbOperator.TabIndex = 13;
            // 
            // lbConditionName
            // 
            this.lbConditionName.AutoSize = true;
            this.lbConditionName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbConditionName.Location = new System.Drawing.Point(5, 7);
            this.lbConditionName.Name = "lbConditionName";
            this.lbConditionName.Size = new System.Drawing.Size(51, 19);
            this.lbConditionName.TabIndex = 12;
            this.lbConditionName.Text = "条件名";
            // 
            // ucReportCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbReportCondition);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucReportCondition";
            this.Size = new System.Drawing.Size(248, 64);
            this.Enter += new System.EventHandler(this.ucReportCondition_Enter);
            this.grbReportCondition.ResumeLayout(false);
            this.pnlReportCondition.ResumeLayout(false);
            this.pnlReportCondition.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbReportCondition;
        private System.Windows.Forms.Panel pnlReportCondition;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbAndOr;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbOperator;
        private System.Windows.Forms.Label lbConditionName;



    }
}
