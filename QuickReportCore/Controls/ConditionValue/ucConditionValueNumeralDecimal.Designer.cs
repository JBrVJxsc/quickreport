namespace QuickReportCore.Controls.ConditionValue
{
    partial class ucConditionValueNumeralDecimal
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
            this.btAdd = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.cmbOperators = new QuickReportCore.Controls.ComboBoxWithFilter();
            this.label2 = new System.Windows.Forms.Label();
            this.cbHideOperator = new System.Windows.Forms.CheckBox();
            this.ucNumeralText = new QuickReportCore.Controls.NumeralText();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "默认值：";
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(66, 135);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(87, 29);
            this.btAdd.TabIndex = 2;
            this.btAdd.Text = "确认";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(162, 135);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 29);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // cmbOperators
            // 
            this.cmbOperators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperators.FilterName = "过滤框";
            this.cmbOperators.FormattingEnabled = true;
            this.cmbOperators.Location = new System.Drawing.Point(98, 67);
            this.cmbOperators.Name = "cmbOperators";
            this.cmbOperators.ShowState = QuickReportCore.Controls.ComboBoxWithFilter.ColumnShowState.Both;
            this.cmbOperators.Size = new System.Drawing.Size(86, 25);
            this.cmbOperators.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "默认操作符：";
            // 
            // cbHideOperator
            // 
            this.cbHideOperator.AutoSize = true;
            this.cbHideOperator.Checked = true;
            this.cbHideOperator.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHideOperator.Location = new System.Drawing.Point(189, 69);
            this.cbHideOperator.Name = "cbHideOperator";
            this.cbHideOperator.Size = new System.Drawing.Size(51, 21);
            this.cbHideOperator.TabIndex = 14;
            this.cbHideOperator.Text = "隐藏";
            this.cbHideOperator.UseVisualStyleBackColor = true;
            // 
            // ucNumeralText
            // 
            this.ucNumeralText.DecimalLength = 2;
            this.ucNumeralText.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ucNumeralText.Location = new System.Drawing.Point(74, 25);
            this.ucNumeralText.Name = "ucNumeralText";
            this.ucNumeralText.Size = new System.Drawing.Size(166, 23);
            this.ucNumeralText.TabIndex = 4;
            this.ucNumeralText.Text = "0.00";
            // 
            // ucConditionValueNumeralDecimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbHideOperator);
            this.Controls.Add(this.cmbOperators);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ucNumeralText);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucConditionValueNumeralDecimal";
            this.Size = new System.Drawing.Size(260, 179);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btCancel;
        private NumeralText ucNumeralText;
        private QuickReportCore.Controls.ComboBoxWithFilter cmbOperators;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbHideOperator;
    }
}
