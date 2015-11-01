namespace QuickReportCore.Forms
{
    partial class frmToolBoxSystemValue
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.Date = new System.Windows.Forms.ToolStripSplitButton();
            this.DateTime = new System.Windows.Forms.ToolStripSplitButton();
            this.Oper = new System.Windows.Forms.ToolStripSplitButton();
            this.Dept = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripReportCondition = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tbReportColumn = new System.Windows.Forms.ToolStripSplitButton();
            this.tbReportCondition = new System.Windows.Forms.ToolStripSplitButton();
            this.tbTreeCondition = new System.Windows.Forms.ToolStripSplitButton();
            this.tbReportDynamic = new System.Windows.Forms.ToolStripSplitButton();
            this.lbCurrentSelection = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            this.toolStripReportCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.Date,
            this.DateTime,
            this.Oper,
            this.Dept});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(253, 39);
            this.toolStrip.TabIndex = 1;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripLabel1.Text = "系统：";
            // 
            // Date
            // 
            this.Date.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Date.Image = global::QuickReportCore.Properties.Resources.date;
            this.Date.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Date.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(48, 36);
            this.Date.ToolTipText = "日期";
            this.Date.DropDownOpened += new System.EventHandler(this.tb_DropDownOpened);
            this.Date.Click += new System.EventHandler(this.tb_Click);
            this.Date.DropDownClosed += new System.EventHandler(this.tb_DropDownClosed);
            this.Date.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tb_DropDownItemClicked);
            // 
            // DateTime
            // 
            this.DateTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DateTime.Image = global::QuickReportCore.Properties.Resources.time;
            this.DateTime.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DateTime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DateTime.Name = "DateTime";
            this.DateTime.Size = new System.Drawing.Size(48, 36);
            this.DateTime.ToolTipText = "日期时间";
            this.DateTime.DropDownOpened += new System.EventHandler(this.tb_DropDownOpened);
            this.DateTime.Click += new System.EventHandler(this.tb_Click);
            this.DateTime.DropDownClosed += new System.EventHandler(this.tb_DropDownClosed);
            this.DateTime.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tb_DropDownItemClicked);
            // 
            // Oper
            // 
            this.Oper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Oper.Image = global::QuickReportCore.Properties.Resources._operator;
            this.Oper.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Oper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Oper.Name = "Oper";
            this.Oper.Size = new System.Drawing.Size(48, 36);
            this.Oper.ToolTipText = "操作员";
            this.Oper.DropDownOpened += new System.EventHandler(this.tb_DropDownOpened);
            this.Oper.Click += new System.EventHandler(this.tb_Click);
            this.Oper.DropDownClosed += new System.EventHandler(this.tb_DropDownClosed);
            this.Oper.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tb_DropDownItemClicked);
            // 
            // Dept
            // 
            this.Dept.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Dept.Image = global::QuickReportCore.Properties.Resources.department;
            this.Dept.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Dept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Dept.Name = "Dept";
            this.Dept.Size = new System.Drawing.Size(48, 36);
            this.Dept.ToolTipText = "科室";
            this.Dept.DropDownOpened += new System.EventHandler(this.tb_DropDownOpened);
            this.Dept.Click += new System.EventHandler(this.tb_Click);
            this.Dept.DropDownClosed += new System.EventHandler(this.tb_DropDownClosed);
            this.Dept.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tb_DropDownItemClicked);
            // 
            // toolStripReportCondition
            // 
            this.toolStripReportCondition.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripReportCondition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.tbReportColumn,
            this.tbReportCondition,
            this.tbTreeCondition,
            this.tbReportDynamic});
            this.toolStripReportCondition.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripReportCondition.Location = new System.Drawing.Point(0, 39);
            this.toolStripReportCondition.Name = "toolStripReportCondition";
            this.toolStripReportCondition.Size = new System.Drawing.Size(253, 58);
            this.toolStripReportCondition.TabIndex = 4;
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(44, 17);
            this.toolStripLabel4.Text = "报表：";
            // 
            // tbReportColumn
            // 
            this.tbReportColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbReportColumn.Image = global::QuickReportCore.Properties.Resources.bar_chart;
            this.tbReportColumn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbReportColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbReportColumn.Name = "tbReportColumn";
            this.tbReportColumn.Size = new System.Drawing.Size(48, 36);
            this.tbReportColumn.ToolTipText = "列";
            this.tbReportColumn.DropDownOpened += new System.EventHandler(this.tb_DropDownOpened);
            this.tbReportColumn.ButtonClick += new System.EventHandler(this.tb_Click);
            this.tbReportColumn.DropDownClosed += new System.EventHandler(this.tb_DropDownClosed);
            this.tbReportColumn.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tbReportColumn_DropDownItemClicked);
            // 
            // tbReportCondition
            // 
            this.tbReportCondition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbReportCondition.Image = global::QuickReportCore.Properties.Resources.processing_02;
            this.tbReportCondition.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbReportCondition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbReportCondition.Name = "tbReportCondition";
            this.tbReportCondition.Size = new System.Drawing.Size(48, 36);
            this.tbReportCondition.ToolTipText = "条件";
            this.tbReportCondition.DropDownOpened += new System.EventHandler(this.tb_DropDownOpened);
            this.tbReportCondition.Click += new System.EventHandler(this.tb_Click);
            this.tbReportCondition.DropDownClosed += new System.EventHandler(this.tb_DropDownClosed);
            this.tbReportCondition.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tbReportCondition_DropDownItemClicked);
            // 
            // tbTreeCondition
            // 
            this.tbTreeCondition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbTreeCondition.Image = global::QuickReportCore.Properties.Resources.tree;
            this.tbTreeCondition.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbTreeCondition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbTreeCondition.Name = "tbTreeCondition";
            this.tbTreeCondition.Size = new System.Drawing.Size(48, 36);
            this.tbTreeCondition.ToolTipText = "树";
            this.tbTreeCondition.DropDownOpened += new System.EventHandler(this.tb_DropDownOpened);
            this.tbTreeCondition.Click += new System.EventHandler(this.tb_Click);
            this.tbTreeCondition.DropDownClosed += new System.EventHandler(this.tb_DropDownClosed);
            this.tbTreeCondition.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tbTreeCondition_DropDownItemClicked);
            // 
            // tbReportDynamic
            // 
            this.tbReportDynamic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbReportDynamic.Image = global::QuickReportCore.Properties.Resources.report;
            this.tbReportDynamic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbReportDynamic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbReportDynamic.Name = "tbReportDynamic";
            this.tbReportDynamic.Size = new System.Drawing.Size(48, 36);
            this.tbReportDynamic.ToolTipText = "动态";
            this.tbReportDynamic.DropDownOpened += new System.EventHandler(this.tb_DropDownOpened);
            this.tbReportDynamic.Click += new System.EventHandler(this.tb_Click);
            this.tbReportDynamic.DropDownClosed += new System.EventHandler(this.tb_DropDownClosed);
            this.tbReportDynamic.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tbReportDynamic_DropDownItemClicked);
            // 
            // lbCurrentSelection
            // 
            this.lbCurrentSelection.AutoSize = true;
            this.lbCurrentSelection.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCurrentSelection.Location = new System.Drawing.Point(77, 93);
            this.lbCurrentSelection.Name = "lbCurrentSelection";
            this.lbCurrentSelection.Size = new System.Drawing.Size(0, 19);
            this.lbCurrentSelection.TabIndex = 3;
            this.lbCurrentSelection.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "当前选择：";
            this.label1.Visible = false;
            // 
            // frmToolBoxSystemValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CannotClose = true;
            this.ClientSize = new System.Drawing.Size(253, 85);
            this.ControlBox = false;
            this.Controls.Add(this.toolStripReportCondition);
            this.Controls.Add(this.lbCurrentSelection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip);
            this.ForceActiveForm = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmToolBoxSystemValue";
            this.Opacity = 0.85;
            this.Text = "变量工具箱";
            this.Activated += new System.EventHandler(this.frmToolBoxSystemValue_Activated);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.toolStripReportCondition.ResumeLayout(false);
            this.toolStripReportCondition.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSplitButton Date;
        private System.Windows.Forms.ToolStripSplitButton DateTime;
        private System.Windows.Forms.ToolStripSplitButton Oper;
        private System.Windows.Forms.ToolStripSplitButton Dept;
        private System.Windows.Forms.ToolStrip toolStripReportCondition;
        private System.Windows.Forms.ToolStripSplitButton tbReportCondition;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSplitButton tbTreeCondition;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripSplitButton tbReportColumn;
        private System.Windows.Forms.ToolStripSplitButton tbReportDynamic;
        private System.Windows.Forms.Label lbCurrentSelection;
        private System.Windows.Forms.Label label1;
    }
}