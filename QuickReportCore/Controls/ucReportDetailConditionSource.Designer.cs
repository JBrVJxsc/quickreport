namespace QuickReportCore.Controls
{
    partial class ucReportDetailConditionSource
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
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            this.fpConditionSource = new FarPoint.Win.Spread.FpSpread();
            this.fpConditionSource_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbConditionSourceAdd = new System.Windows.Forms.ToolStripButton();
            this.tbConditionSourceDelete = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.fpConditionSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpConditionSource_Sheet1)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // fpConditionSource
            // 
            this.fpConditionSource.About = "2.5.2007.2005";
            this.fpConditionSource.AccessibleDescription = "fpConditionSource, Sheet1, Row 0, Column 0, ";
            this.fpConditionSource.BackColor = System.Drawing.SystemColors.Control;
            this.fpConditionSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpConditionSource.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpConditionSource.Location = new System.Drawing.Point(0, 25);
            this.fpConditionSource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fpConditionSource.Name = "fpConditionSource";
            this.fpConditionSource.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpConditionSource_Sheet1});
            this.fpConditionSource.Size = new System.Drawing.Size(221, 157);
            this.fpConditionSource.TabIndex = 8;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpConditionSource.TextTipAppearance = tipAppearance1;
            this.fpConditionSource.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpConditionSource.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpConditionSource_EditChange);
            // 
            // fpConditionSource_Sheet1
            // 
            this.fpConditionSource_Sheet1.Reset();
            this.fpConditionSource_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpConditionSource_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpConditionSource_Sheet1.ColumnCount = 2;
            this.fpConditionSource_Sheet1.RowCount = 0;
            this.fpConditionSource_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "条件源";
            this.fpConditionSource_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "条件";
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType1.Items = new string[] {
        "报表",
        "树"};
            this.fpConditionSource_Sheet1.Columns.Get(0).CellType = comboBoxCellType1;
            this.fpConditionSource_Sheet1.Columns.Get(0).Label = "条件源";
            this.fpConditionSource_Sheet1.Columns.Get(0).Width = 64F;
            comboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.fpConditionSource_Sheet1.Columns.Get(1).CellType = comboBoxCellType2;
            this.fpConditionSource_Sheet1.Columns.Get(1).Label = "条件";
            this.fpConditionSource_Sheet1.Columns.Get(1).Width = 101F;
            this.fpConditionSource_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpConditionSource_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpConditionSource.SetActiveViewport(1, 0);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbConditionSourceAdd,
            this.tbConditionSourceDelete});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.ShowItemToolTips = false;
            this.toolStrip.Size = new System.Drawing.Size(221, 25);
            this.toolStrip.TabIndex = 7;
            // 
            // tbConditionSourceAdd
            // 
            this.tbConditionSourceAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbConditionSourceAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbConditionSourceAdd.Name = "tbConditionSourceAdd";
            this.tbConditionSourceAdd.Size = new System.Drawing.Size(36, 22);
            this.tbConditionSourceAdd.Text = "添加";
            this.tbConditionSourceAdd.Click += new System.EventHandler(this.tbConditionSourceAdd_Click);
            // 
            // tbConditionSourceDelete
            // 
            this.tbConditionSourceDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbConditionSourceDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbConditionSourceDelete.Name = "tbConditionSourceDelete";
            this.tbConditionSourceDelete.Size = new System.Drawing.Size(36, 22);
            this.tbConditionSourceDelete.Text = "删除";
            this.tbConditionSourceDelete.Click += new System.EventHandler(this.tbConditionSourceDelete_Click);
            // 
            // ucReportDetailConditionSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fpConditionSource);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucReportDetailConditionSource";
            this.Size = new System.Drawing.Size(221, 182);
            ((System.ComponentModel.ISupportInitialize)(this.fpConditionSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpConditionSource_Sheet1)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread fpConditionSource;
        private FarPoint.Win.Spread.SheetView fpConditionSource_Sheet1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbConditionSourceAdd;
        private System.Windows.Forms.ToolStripButton tbConditionSourceDelete;
    }
}
