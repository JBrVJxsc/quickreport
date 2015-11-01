namespace QuickReportLib.Controls.ConditionInputTypeSetting
{
    partial class BaseCheckControlSettingUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseCheckControlSettingUserControl));
            this.toolStripSelector = new System.Windows.Forms.ToolStrip();
            this.tbAdd = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.grbControls = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripSelector.SuspendLayout();
            this.grbControls.SuspendLayout();
            this.panel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSelector
            // 
            this.toolStripSelector.BackColor = System.Drawing.Color.Transparent;
            this.toolStripSelector.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripSelector.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbAdd,
            this.tbDelete});
            this.toolStripSelector.Location = new System.Drawing.Point(0, 0);
            this.toolStripSelector.Name = "toolStripSelector";
            this.toolStripSelector.ShowItemToolTips = false;
            this.toolStripSelector.Size = new System.Drawing.Size(692, 25);
            this.toolStripSelector.TabIndex = 6;
            // 
            // tbAdd
            // 
            this.tbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(36, 22);
            this.tbAdd.Text = "增加";
            this.tbAdd.ToolTipText = "调整列顺序：上移。";
            this.tbAdd.Click += new System.EventHandler(this.tbAdd_Click);
            // 
            // tbDelete
            // 
            this.tbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tbDelete.Image")));
            this.tbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(36, 22);
            this.tbDelete.Text = "删除";
            this.tbDelete.Click += new System.EventHandler(this.tbDelete_Click);
            // 
            // grbControls
            // 
            this.grbControls.Controls.Add(this.flowLayoutPanel);
            this.grbControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbControls.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grbControls.Location = new System.Drawing.Point(0, 25);
            this.grbControls.Name = "grbControls";
            this.grbControls.Size = new System.Drawing.Size(692, 89);
            this.grbControls.TabIndex = 7;
            this.grbControls.TabStop = false;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(686, 67);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.groupBox1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 114);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(692, 164);
            this.panel.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 164);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtID.Location = new System.Drawing.Point(63, 22);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(153, 23);
            this.txtID.TabIndex = 1;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(63, 59);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(153, 23);
            this.txtName.TabIndex = 3;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "编码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "名称：";
            // 
            // BaseCheckControlSettingUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.grbControls);
            this.Controls.Add(this.toolStripSelector);
            this.Name = "BaseCheckControlSettingUserControl";
            this.Size = new System.Drawing.Size(692, 278);
            this.toolStripSelector.ResumeLayout(false);
            this.toolStripSelector.PerformLayout();
            this.grbControls.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripSelector;
        private System.Windows.Forms.ToolStripButton tbAdd;
        private System.Windows.Forms.ToolStripButton tbDelete;
        private System.Windows.Forms.GroupBox grbControls;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
