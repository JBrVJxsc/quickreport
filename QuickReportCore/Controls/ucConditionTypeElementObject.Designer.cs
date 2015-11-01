namespace QuickReportCore.Controls
{
    partial class ucConditionTypeElementObject
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
            this.grbConditionTypeObject = new System.Windows.Forms.GroupBox();
            this.pnlConditionTypeElement = new System.Windows.Forms.Panel();
            this.cbHide = new System.Windows.Forms.CheckBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbConditionTypeObject.SuspendLayout();
            this.pnlConditionTypeElement.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbConditionTypeObject
            // 
            this.grbConditionTypeObject.Controls.Add(this.pnlConditionTypeElement);
            this.grbConditionTypeObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbConditionTypeObject.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grbConditionTypeObject.Location = new System.Drawing.Point(0, 0);
            this.grbConditionTypeObject.Name = "grbConditionTypeObject";
            this.grbConditionTypeObject.Size = new System.Drawing.Size(324, 55);
            this.grbConditionTypeObject.TabIndex = 0;
            this.grbConditionTypeObject.TabStop = false;
            // 
            // pnlConditionTypeElement
            // 
            this.pnlConditionTypeElement.Controls.Add(this.cbHide);
            this.pnlConditionTypeElement.Controls.Add(this.txtID);
            this.pnlConditionTypeElement.Controls.Add(this.label2);
            this.pnlConditionTypeElement.Controls.Add(this.txtName);
            this.pnlConditionTypeElement.Controls.Add(this.label1);
            this.pnlConditionTypeElement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConditionTypeElement.Location = new System.Drawing.Point(3, 19);
            this.pnlConditionTypeElement.Name = "pnlConditionTypeElement";
            this.pnlConditionTypeElement.Size = new System.Drawing.Size(318, 33);
            this.pnlConditionTypeElement.TabIndex = 0;
            // 
            // cbHide
            // 
            this.cbHide.AutoSize = true;
            this.cbHide.Location = new System.Drawing.Point(262, 6);
            this.cbHide.Name = "cbHide";
            this.cbHide.Size = new System.Drawing.Size(51, 21);
            this.cbHide.TabIndex = 21;
            this.cbHide.Text = "隐藏";
            this.cbHide.UseVisualStyleBackColor = true;
            this.cbHide.CheckedChanged += new System.EventHandler(this.cbHide_CheckedChanged);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(174, 4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(75, 23);
            this.txtID.TabIndex = 20;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "代码：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(48, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(75, 23);
            this.txtName.TabIndex = 18;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "名称：";
            // 
            // ucConditionTypeElementObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbConditionTypeObject);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ucConditionTypeElementObject";
            this.Size = new System.Drawing.Size(324, 55);
            this.grbConditionTypeObject.ResumeLayout(false);
            this.pnlConditionTypeElement.ResumeLayout(false);
            this.pnlConditionTypeElement.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbConditionTypeObject;
        private System.Windows.Forms.Panel pnlConditionTypeElement;
        private System.Windows.Forms.CheckBox cbHide;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
    }
}
