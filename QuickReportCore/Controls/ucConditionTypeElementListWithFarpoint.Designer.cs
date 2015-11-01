namespace QuickReportCore.Controls
{
    partial class ucConditionTypeElementListWithFarpoint
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.fpConditionTypeElement = new FarPoint.Win.Spread.FpSpread();
            this.fpConditionTypeElement_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbAdd = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.fpConditionTypeElement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpConditionTypeElement_Sheet1)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // fpConditionTypeElement
            // 
            this.fpConditionTypeElement.About = "2.5.2007.2005";
            this.fpConditionTypeElement.AccessibleDescription = "fpConditionTypeElement, Sheet1, Row 0, Column 0, ";
            this.fpConditionTypeElement.BackColor = System.Drawing.SystemColors.Control;
            this.fpConditionTypeElement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpConditionTypeElement.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpConditionTypeElement.Location = new System.Drawing.Point(0, 25);
            this.fpConditionTypeElement.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.fpConditionTypeElement.Name = "fpConditionTypeElement";
            this.fpConditionTypeElement.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpConditionTypeElement_Sheet1});
            this.fpConditionTypeElement.Size = new System.Drawing.Size(226, 233);
            this.fpConditionTypeElement.TabIndex = 10;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpConditionTypeElement.TextTipAppearance = tipAppearance1;
            this.fpConditionTypeElement.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpConditionTypeElement_Sheet1
            // 
            this.fpConditionTypeElement_Sheet1.Reset();
            this.fpConditionTypeElement_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpConditionTypeElement_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpConditionTypeElement_Sheet1.ColumnCount = 2;
            this.fpConditionTypeElement_Sheet1.RowCount = 0;
            this.fpConditionTypeElement_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "编码";
            this.fpConditionTypeElement_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "名称";
            this.fpConditionTypeElement_Sheet1.Columns.Get(0).Label = "编码";
            this.fpConditionTypeElement_Sheet1.Columns.Get(0).Width = 64F;
            this.fpConditionTypeElement_Sheet1.Columns.Get(1).Label = "名称";
            this.fpConditionTypeElement_Sheet1.Columns.Get(1).Width = 101F;
            this.fpConditionTypeElement_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpConditionTypeElement_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpConditionTypeElement_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpConditionTypeElement.SetActiveViewport(1, 0);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbAdd,
            this.tbDelete});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.ShowItemToolTips = false;
            this.toolStrip.Size = new System.Drawing.Size(226, 25);
            this.toolStrip.TabIndex = 9;
            // 
            // tbAdd
            // 
            this.tbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(36, 22);
            this.tbAdd.Text = "添加";
            this.tbAdd.Click += new System.EventHandler(this.tbAdd_Click);
            // 
            // tbDelete
            // 
            this.tbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(36, 22);
            this.tbDelete.Text = "删除";
            this.tbDelete.Click += new System.EventHandler(this.tbDelete_Click);
            // 
            // ucConditionTypeElementListWithFarpoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fpConditionTypeElement);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucConditionTypeElementListWithFarpoint";
            this.Size = new System.Drawing.Size(226, 258);
            this.Load += new System.EventHandler(this.ucConditionTypeElementListWithFarpoint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpConditionTypeElement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpConditionTypeElement_Sheet1)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread fpConditionTypeElement;
        private FarPoint.Win.Spread.SheetView fpConditionTypeElement_Sheet1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbAdd;
        private System.Windows.Forms.ToolStripButton tbDelete;
    }
}
