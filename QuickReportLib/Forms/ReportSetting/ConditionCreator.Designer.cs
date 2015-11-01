namespace QuickReportLib.Forms.ReportSetting
{
    partial class ConditionCreator
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConditionCreator));
            this.pnlButtom = new QuickReportLib.Controls.Plus.PanelWithLine();
            this.btCancel = new System.Windows.Forms.Button();
            this.btDone = new System.Windows.Forms.Button();
            this.txtConditionName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbConditionInputTypes = new QuickReportLib.Controls.Plus.ComboBoxPlus();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlButtom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtom
            // 
            this.pnlButtom.Controls.Add(this.btCancel);
            this.pnlButtom.Controls.Add(this.btDone);
            this.pnlButtom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtom.Location = new System.Drawing.Point(0, 100);
            this.pnlButtom.Name = "pnlButtom";
            this.pnlButtom.Size = new System.Drawing.Size(309, 50);
            this.pnlButtom.TabIndex = 0;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCancel.Location = new System.Drawing.Point(208, 9);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(85, 29);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btDone
            // 
            this.btDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDone.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btDone.Location = new System.Drawing.Point(111, 9);
            this.btDone.Name = "btDone";
            this.btDone.Size = new System.Drawing.Size(85, 29);
            this.btDone.TabIndex = 2;
            this.btDone.Text = "完成";
            this.btDone.UseVisualStyleBackColor = true;
            this.btDone.Click += new System.EventHandler(this.btDone_Click);
            // 
            // txtConditionName
            // 
            this.txtConditionName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConditionName.Location = new System.Drawing.Point(84, 14);
            this.txtConditionName.Name = "txtConditionName";
            this.txtConditionName.Size = new System.Drawing.Size(204, 23);
            this.txtConditionName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(10, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "条件名称：";
            // 
            // cmbConditionInputTypes
            // 
            this.cmbConditionInputTypes.ColumnShowState = QuickReportLib.Enums.ComboBoxPlusColumnShowState.Both;
            this.cmbConditionInputTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConditionInputTypes.FilterName = "报表分类";
            this.cmbConditionInputTypes.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbConditionInputTypes.FormattingEnabled = true;
            this.cmbConditionInputTypes.Location = new System.Drawing.Point(84, 54);
            this.cmbConditionInputTypes.Name = "cmbConditionInputTypes";
            this.cmbConditionInputTypes.Size = new System.Drawing.Size(204, 25);
            this.cmbConditionInputTypes.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "控件类型：";
            // 
            // ConditionCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            
            this.ClientSize = new System.Drawing.Size(309, 150);
            this.Controls.Add(this.cmbConditionInputTypes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConditionName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlButtom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConditionCreator";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建条件";
            this.pnlButtom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QuickReportLib.Controls.Plus.PanelWithLine pnlButtom;
        private System.Windows.Forms.Button btDone;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.TextBox txtConditionName;
        private System.Windows.Forms.Label label2;
        private QuickReportLib.Controls.Plus.ComboBoxPlus cmbConditionInputTypes;
        private System.Windows.Forms.Label label1;
    }
}