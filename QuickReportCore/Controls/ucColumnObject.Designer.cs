namespace QuickReportCore.Controls
{
    partial class ucColumnObject
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
            this.components = new System.ComponentModel.Container();
            this.grbColumnObject = new System.Windows.Forms.GroupBox();
            this.pnlColumnObject = new System.Windows.Forms.Panel();
            this.linkLableOther = new System.Windows.Forms.LinkLabel();
            this.cbTotalCountRow = new System.Windows.Forms.CheckBox();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lbNumberPlace = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.CheckBox();
            this.cbSort = new System.Windows.Forms.CheckBox();
            this.cbTotalCountColumn = new System.Windows.Forms.CheckBox();
            this.cbUse = new System.Windows.Forms.CheckBox();
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.FontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HAligmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HAligmentLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HAligmentCenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HAligmentRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HAligmentGeneralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VAligmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VAligmentTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VAligmentCenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VAligmentBottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VAligmentGeneralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ValueTransTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ValueTransBeZeroWhenNullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ValueTransBeNullWhenZeroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ValueTransDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grbColumnObject.SuspendLayout();
            this.pnlColumnObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbColumnObject
            // 
            this.grbColumnObject.BackColor = System.Drawing.SystemColors.Control;
            this.grbColumnObject.Controls.Add(this.pnlColumnObject);
            this.grbColumnObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbColumnObject.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grbColumnObject.Location = new System.Drawing.Point(0, 0);
            this.grbColumnObject.Name = "grbColumnObject";
            this.grbColumnObject.Size = new System.Drawing.Size(555, 55);
            this.grbColumnObject.TabIndex = 4;
            this.grbColumnObject.TabStop = false;
            // 
            // pnlColumnObject
            // 
            this.pnlColumnObject.Controls.Add(this.linkLableOther);
            this.pnlColumnObject.Controls.Add(this.cbTotalCountRow);
            this.pnlColumnObject.Controls.Add(this.numericUpDown);
            this.pnlColumnObject.Controls.Add(this.lbNumberPlace);
            this.pnlColumnObject.Controls.Add(this.cbFilter);
            this.pnlColumnObject.Controls.Add(this.cbSort);
            this.pnlColumnObject.Controls.Add(this.cbTotalCountColumn);
            this.pnlColumnObject.Controls.Add(this.cbUse);
            this.pnlColumnObject.Controls.Add(this.txtColumnName);
            this.pnlColumnObject.Controls.Add(this.label1);
            this.pnlColumnObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColumnObject.Location = new System.Drawing.Point(3, 19);
            this.pnlColumnObject.Name = "pnlColumnObject";
            this.pnlColumnObject.Size = new System.Drawing.Size(549, 33);
            this.pnlColumnObject.TabIndex = 0;
            // 
            // linkLableOther
            // 
            this.linkLableOther.AutoSize = true;
            this.linkLableOther.Location = new System.Drawing.Point(507, 6);
            this.linkLableOther.Name = "linkLableOther";
            this.linkLableOther.Size = new System.Drawing.Size(32, 17);
            this.linkLableOther.TabIndex = 22;
            this.linkLableOther.TabStop = true;
            this.linkLableOther.Text = "其他";
            this.linkLableOther.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLableOther_LinkClicked);
            // 
            // cbTotalCountRow
            // 
            this.cbTotalCountRow.AutoSize = true;
            this.cbTotalCountRow.Location = new System.Drawing.Point(248, 5);
            this.cbTotalCountRow.Name = "cbTotalCountRow";
            this.cbTotalCountRow.Size = new System.Drawing.Size(63, 21);
            this.cbTotalCountRow.TabIndex = 21;
            this.cbTotalCountRow.Text = "行合计";
            this.cbTotalCountRow.UseVisualStyleBackColor = true;
            this.cbTotalCountRow.CheckedChanged += new System.EventHandler(this.cbTotalCountRow_CheckedChanged);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(464, 3);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(35, 23);
            this.numericUpDown.TabIndex = 20;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // lbNumberPlace
            // 
            this.lbNumberPlace.AutoSize = true;
            this.lbNumberPlace.Location = new System.Drawing.Point(419, 6);
            this.lbNumberPlace.Name = "lbNumberPlace";
            this.lbNumberPlace.Size = new System.Drawing.Size(44, 17);
            this.lbNumberPlace.TabIndex = 19;
            this.lbNumberPlace.Text = "位数：";
            // 
            // cbFilter
            // 
            this.cbFilter.AutoSize = true;
            this.cbFilter.Location = new System.Drawing.Point(367, 5);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(51, 21);
            this.cbFilter.TabIndex = 18;
            this.cbFilter.Text = "过滤";
            this.cbFilter.UseVisualStyleBackColor = true;
            this.cbFilter.CheckedChanged += new System.EventHandler(this.cbFilter_CheckedChanged);
            // 
            // cbSort
            // 
            this.cbSort.AutoSize = true;
            this.cbSort.Location = new System.Drawing.Point(314, 5);
            this.cbSort.Name = "cbSort";
            this.cbSort.Size = new System.Drawing.Size(51, 21);
            this.cbSort.TabIndex = 17;
            this.cbSort.Text = "排序";
            this.cbSort.UseVisualStyleBackColor = true;
            this.cbSort.CheckedChanged += new System.EventHandler(this.cbSort_CheckedChanged);
            // 
            // cbTotalCountColumn
            // 
            this.cbTotalCountColumn.AutoSize = true;
            this.cbTotalCountColumn.Location = new System.Drawing.Point(183, 5);
            this.cbTotalCountColumn.Name = "cbTotalCountColumn";
            this.cbTotalCountColumn.Size = new System.Drawing.Size(63, 21);
            this.cbTotalCountColumn.TabIndex = 16;
            this.cbTotalCountColumn.Text = "列合计";
            this.cbTotalCountColumn.UseVisualStyleBackColor = true;
            this.cbTotalCountColumn.CheckedChanged += new System.EventHandler(this.cbTotalCount_CheckedChanged);
            // 
            // cbUse
            // 
            this.cbUse.AutoSize = true;
            this.cbUse.Checked = true;
            this.cbUse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUse.Location = new System.Drawing.Point(132, 5);
            this.cbUse.Name = "cbUse";
            this.cbUse.Size = new System.Drawing.Size(51, 21);
            this.cbUse.TabIndex = 15;
            this.cbUse.Text = "显示";
            this.cbUse.UseVisualStyleBackColor = true;
            this.cbUse.CheckedChanged += new System.EventHandler(this.cbHide_CheckedChanged);
            // 
            // txtColumnName
            // 
            this.txtColumnName.Location = new System.Drawing.Point(48, 4);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.ReadOnly = true;
            this.txtColumnName.Size = new System.Drawing.Size(75, 23);
            this.txtColumnName.TabIndex = 14;
            this.txtColumnName.TextChanged += new System.EventHandler(this.txtColumnName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "名称：";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FontToolStripMenuItem,
            this.ColorToolStripMenuItem,
            this.HAligmentToolStripMenuItem,
            this.VAligmentToolStripMenuItem,
            this.UnionToolStripMenuItem,
            this.ValueTransTypeToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 158);
            // 
            // FontToolStripMenuItem
            // 
            this.FontToolStripMenuItem.Name = "FontToolStripMenuItem";
            this.FontToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.FontToolStripMenuItem.Text = "字体";
            this.FontToolStripMenuItem.Click += new System.EventHandler(this.FontToolStripMenuItem_Click);
            // 
            // ColorToolStripMenuItem
            // 
            this.ColorToolStripMenuItem.Name = "ColorToolStripMenuItem";
            this.ColorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ColorToolStripMenuItem.Text = "颜色";
            this.ColorToolStripMenuItem.Click += new System.EventHandler(this.ColorToolStripMenuItem_Click);
            // 
            // HAligmentToolStripMenuItem
            // 
            this.HAligmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HAligmentLeftToolStripMenuItem,
            this.HAligmentCenterToolStripMenuItem,
            this.HAligmentRightToolStripMenuItem,
            this.HAligmentGeneralToolStripMenuItem});
            this.HAligmentToolStripMenuItem.Name = "HAligmentToolStripMenuItem";
            this.HAligmentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.HAligmentToolStripMenuItem.Text = "横向格式";
            // 
            // HAligmentLeftToolStripMenuItem
            // 
            this.HAligmentLeftToolStripMenuItem.Name = "HAligmentLeftToolStripMenuItem";
            this.HAligmentLeftToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.HAligmentLeftToolStripMenuItem.Text = "左对齐";
            this.HAligmentLeftToolStripMenuItem.Click += new System.EventHandler(this.HAligmentLeftToolStripMenuItem_Click);
            // 
            // HAligmentCenterToolStripMenuItem
            // 
            this.HAligmentCenterToolStripMenuItem.Name = "HAligmentCenterToolStripMenuItem";
            this.HAligmentCenterToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.HAligmentCenterToolStripMenuItem.Text = "居中";
            this.HAligmentCenterToolStripMenuItem.Click += new System.EventHandler(this.HAligmentCenterToolStripMenuItem_Click);
            // 
            // HAligmentRightToolStripMenuItem
            // 
            this.HAligmentRightToolStripMenuItem.Name = "HAligmentRightToolStripMenuItem";
            this.HAligmentRightToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.HAligmentRightToolStripMenuItem.Text = "右对齐";
            this.HAligmentRightToolStripMenuItem.Click += new System.EventHandler(this.HAligmentRightToolStripMenuItem_Click);
            // 
            // HAligmentGeneralToolStripMenuItem
            // 
            this.HAligmentGeneralToolStripMenuItem.Name = "HAligmentGeneralToolStripMenuItem";
            this.HAligmentGeneralToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.HAligmentGeneralToolStripMenuItem.Text = "普通";
            this.HAligmentGeneralToolStripMenuItem.Click += new System.EventHandler(this.HAligmentGeneralToolStripMenuItem_Click);
            // 
            // VAligmentToolStripMenuItem
            // 
            this.VAligmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VAligmentTopToolStripMenuItem,
            this.VAligmentCenterToolStripMenuItem,
            this.VAligmentBottomToolStripMenuItem,
            this.VAligmentGeneralToolStripMenuItem});
            this.VAligmentToolStripMenuItem.Name = "VAligmentToolStripMenuItem";
            this.VAligmentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.VAligmentToolStripMenuItem.Text = "纵向格式";
            // 
            // VAligmentTopToolStripMenuItem
            // 
            this.VAligmentTopToolStripMenuItem.Name = "VAligmentTopToolStripMenuItem";
            this.VAligmentTopToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.VAligmentTopToolStripMenuItem.Text = "上对齐";
            this.VAligmentTopToolStripMenuItem.Click += new System.EventHandler(this.VAligmentTopToolStripMenuItem_Click);
            // 
            // VAligmentCenterToolStripMenuItem
            // 
            this.VAligmentCenterToolStripMenuItem.Name = "VAligmentCenterToolStripMenuItem";
            this.VAligmentCenterToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.VAligmentCenterToolStripMenuItem.Text = "居中";
            this.VAligmentCenterToolStripMenuItem.Click += new System.EventHandler(this.VAligmentCenterToolStripMenuItem1_Click);
            // 
            // VAligmentBottomToolStripMenuItem
            // 
            this.VAligmentBottomToolStripMenuItem.Name = "VAligmentBottomToolStripMenuItem";
            this.VAligmentBottomToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.VAligmentBottomToolStripMenuItem.Text = "下对齐";
            this.VAligmentBottomToolStripMenuItem.Click += new System.EventHandler(this.VAligmentBottomToolStripMenuItem_Click);
            // 
            // VAligmentGeneralToolStripMenuItem
            // 
            this.VAligmentGeneralToolStripMenuItem.Name = "VAligmentGeneralToolStripMenuItem";
            this.VAligmentGeneralToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.VAligmentGeneralToolStripMenuItem.Text = "普通";
            this.VAligmentGeneralToolStripMenuItem.Click += new System.EventHandler(this.VAligmentGeneralToolStripMenuItem1_Click);
            // 
            // UnionToolStripMenuItem
            // 
            this.UnionToolStripMenuItem.Name = "UnionToolStripMenuItem";
            this.UnionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.UnionToolStripMenuItem.Text = "合并相同";
            this.UnionToolStripMenuItem.Click += new System.EventHandler(this.UnionToolStripMenuItem_Click);
            // 
            // ValueTransTypeToolStripMenuItem
            // 
            this.ValueTransTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ValueTransBeZeroWhenNullToolStripMenuItem,
            this.ValueTransBeNullWhenZeroToolStripMenuItem,
            this.ValueTransDefaultToolStripMenuItem});
            this.ValueTransTypeToolStripMenuItem.Name = "ValueTransTypeToolStripMenuItem";
            this.ValueTransTypeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ValueTransTypeToolStripMenuItem.Text = "转换方式";
            // 
            // ValueTransBeZeroWhenNullToolStripMenuItem
            // 
            this.ValueTransBeZeroWhenNullToolStripMenuItem.Name = "ValueTransBeZeroWhenNullToolStripMenuItem";
            this.ValueTransBeZeroWhenNullToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ValueTransBeZeroWhenNullToolStripMenuItem.Text = "值为空时转换为零";
            this.ValueTransBeZeroWhenNullToolStripMenuItem.Click += new System.EventHandler(this.ValueTransBeZeroWhenNullToolStripMenuItem_Click);
            // 
            // ValueTransBeNullWhenZeroToolStripMenuItem
            // 
            this.ValueTransBeNullWhenZeroToolStripMenuItem.Name = "ValueTransBeNullWhenZeroToolStripMenuItem";
            this.ValueTransBeNullWhenZeroToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ValueTransBeNullWhenZeroToolStripMenuItem.Text = "值为零时转换为空";
            this.ValueTransBeNullWhenZeroToolStripMenuItem.Click += new System.EventHandler(this.ValueTransBeNullWhenZeroToolStripMenuItem_Click);
            // 
            // ValueTransDefaultToolStripMenuItem
            // 
            this.ValueTransDefaultToolStripMenuItem.Name = "ValueTransDefaultToolStripMenuItem";
            this.ValueTransDefaultToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ValueTransDefaultToolStripMenuItem.Text = "不转换";
            this.ValueTransDefaultToolStripMenuItem.Click += new System.EventHandler(this.ValueTransDefaultToolStripMenuItem_Click);
            // 
            // ucColumnObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.grbColumnObject);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ucColumnObject";
            this.Size = new System.Drawing.Size(555, 55);
            this.Load += new System.EventHandler(this.ucColumnObject_Load);
            this.grbColumnObject.ResumeLayout(false);
            this.pnlColumnObject.ResumeLayout(false);
            this.pnlColumnObject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbColumnObject;
        private System.Windows.Forms.Panel pnlColumnObject;
        private System.Windows.Forms.CheckBox cbFilter;
        private System.Windows.Forms.CheckBox cbSort;
        private System.Windows.Forms.CheckBox cbTotalCountColumn;
        private System.Windows.Forms.CheckBox cbUse;
        private System.Windows.Forms.TextBox txtColumnName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label lbNumberPlace;
        private System.Windows.Forms.CheckBox cbTotalCountRow;
        private System.Windows.Forms.LinkLabel linkLableOther;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HAligmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VAligmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HAligmentLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HAligmentCenterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HAligmentRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HAligmentGeneralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VAligmentTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VAligmentCenterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VAligmentBottomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VAligmentGeneralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UnionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ValueTransTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ValueTransBeZeroWhenNullToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ValueTransBeNullWhenZeroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ValueTransDefaultToolStripMenuItem;

    }
}
