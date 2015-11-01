namespace QuickReportCore.Forms
{
    partial class frmSelector
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.fpSelector = new FarPoint.Win.Spread.FpSpread();
            this.fpSelector_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.fpSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSelector_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpSelector
            // 
            this.fpSelector.About = "2.5.2007.2005";
            this.fpSelector.AccessibleDescription = "fpFilter, Sheet1, Row 0, Column 0, ";
            this.fpSelector.BackColor = System.Drawing.Color.Transparent;
            this.fpSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSelector.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpSelector.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSelector.Location = new System.Drawing.Point(0, 0);
            this.fpSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fpSelector.Name = "fpSelector";
            this.fpSelector.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSelector_Sheet1});
            this.fpSelector.Size = new System.Drawing.Size(439, 231);
            this.fpSelector.TabIndex = 4;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSelector.TextTipAppearance = tipAppearance1;
            this.fpSelector.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSelector.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSelector_CellDoubleClick);
            this.fpSelector.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSelector_CellClick);
            this.fpSelector.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpSelector_KeyDown);
            this.fpSelector.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fpSelector_LeaveCell);
            this.fpSelector.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.fpSelector_EnterCell);
            // 
            // fpSelector_Sheet1
            // 
            this.fpSelector_Sheet1.Reset();
            this.fpSelector_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSelector_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSelector_Sheet1.ColumnCount = 0;
            this.fpSelector_Sheet1.RowCount = 0;
            this.fpSelector_Sheet1.RowHeader.ColumnCount = 0;
            this.fpSelector_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSelector_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSelector_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSelector.SetActiveViewport(1, 1);
            // 
            // frmSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 231);
            this.ControlBox = false;
            this.Controls.Add(this.fpSelector);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSelector";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Deactivate += new System.EventHandler(this.frmListSelector_Deactivate);
            this.Activated += new System.EventHandler(this.frmListSelector_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.fpSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSelector_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread fpSelector;
        private FarPoint.Win.Spread.SheetView fpSelector_Sheet1;
    }
}