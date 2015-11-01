namespace QuickReportCore.Controls.InterfaceList
{
    partial class ucISystemValueList
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbAdd = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.fpInterfaces = new FarPoint.Win.Spread.FpSpread();
            this.fpInterfaces_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpInterfaces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpInterfaces_Sheet1)).BeginInit();
            this.SuspendLayout();
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
            this.toolStrip.Size = new System.Drawing.Size(436, 25);
            this.toolStrip.TabIndex = 12;
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
            // fpInterfaces
            // 
            this.fpInterfaces.About = "2.5.2007.2005";
            this.fpInterfaces.AccessibleDescription = "fpInterfaces, Sheet1";
            this.fpInterfaces.BackColor = System.Drawing.SystemColors.Control;
            this.fpInterfaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpInterfaces.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpInterfaces.Location = new System.Drawing.Point(0, 25);
            this.fpInterfaces.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.fpInterfaces.Name = "fpInterfaces";
            this.fpInterfaces.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpInterfaces_Sheet1});
            this.fpInterfaces.Size = new System.Drawing.Size(436, 345);
            this.fpInterfaces.TabIndex = 14;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpInterfaces.TextTipAppearance = tipAppearance1;
            this.fpInterfaces.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpInterfaces.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpInterfaces_ButtonClicked);
            this.fpInterfaces.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpInterfaces_EditChange);
            this.fpInterfaces.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpInterfaces_CellDoubleClick);
            this.fpInterfaces.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpInterfaces_CellClick);
            // 
            // fpInterfaces_Sheet1
            // 
            this.fpInterfaces_Sheet1.Reset();
            this.fpInterfaces_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpInterfaces_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpInterfaces_Sheet1.ColumnCount = 2;
            this.fpInterfaces_Sheet1.RowCount = 0;
            this.fpInterfaces_Sheet1.RowHeader.ColumnCount = 0;
            this.fpInterfaces_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Dll名称";
            this.fpInterfaces_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "实现类名称";
            this.fpInterfaces_Sheet1.Columns.Get(0).Label = "Dll名称";
            this.fpInterfaces_Sheet1.Columns.Get(0).Width = 175F;
            this.fpInterfaces_Sheet1.Columns.Get(1).Label = "实现类名称";
            this.fpInterfaces_Sheet1.Columns.Get(1).Locked = true;
            this.fpInterfaces_Sheet1.Columns.Get(1).Width = 395F;
            this.fpInterfaces_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpInterfaces_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpInterfaces_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpInterfaces.SetActiveViewport(1, 0);
            // 
            // ucISystemValueList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fpInterfaces);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucISystemValueList";
            this.Size = new System.Drawing.Size(436, 370);
            this.Load += new System.EventHandler(this.ucISystemValueList_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpInterfaces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpInterfaces_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbAdd;
        private System.Windows.Forms.ToolStripButton tbDelete;
        private FarPoint.Win.Spread.FpSpread fpInterfaces;
        private FarPoint.Win.Spread.SheetView fpInterfaces_Sheet1;

    }
}
