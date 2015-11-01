namespace QuickReportLib.Controls.Forms
{
    partial class FilterForm
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
            this.pnlText = new System.Windows.Forms.Panel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.fpFilter = new FarPoint.Win.Spread.FpSpread();
            this.fpFilter_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpFilter_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlText
            // 
            this.pnlText.Controls.Add(this.txtFilter);
            this.pnlText.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlText.Location = new System.Drawing.Point(0, 0);
            this.pnlText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlText.Name = "pnlText";
            this.pnlText.Size = new System.Drawing.Size(448, 27);
            this.pnlText.TabIndex = 1;
            // 
            // txtFilter
            // 
            this.txtFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtFilter.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFilter.Location = new System.Drawing.Point(0, 0);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(448, 29);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            this.txtFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtFilter_MouseDown);
            // 
            // fpFilter
            // 
            this.fpFilter.About = "2.5.2007.2005";
            this.fpFilter.AccessibleDescription = "fpFilter, Sheet1, Row 0, Column 0, ";
            this.fpFilter.BackColor = System.Drawing.Color.Transparent;
            this.fpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpFilter.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpFilter.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpFilter.Location = new System.Drawing.Point(0, 27);
            this.fpFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fpFilter.Name = "fpFilter";
            this.fpFilter.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpFilter_Sheet1});
            this.fpFilter.Size = new System.Drawing.Size(448, 290);
            this.fpFilter.TabIndex = 2;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpFilter.TextTipAppearance = tipAppearance1;
            this.fpFilter.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpFilter.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpFilter_CellDoubleClick_1);
            this.fpFilter.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpFilter_CellClick);
            this.fpFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpFilter_KeyDown);
            this.fpFilter.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fp_LeaveCell);
            this.fpFilter.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.fp_EnterCell);
            // 
            // fpFilter_Sheet1
            // 
            this.fpFilter_Sheet1.Reset();
            this.fpFilter_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpFilter_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpFilter_Sheet1.ColumnCount = 0;
            this.fpFilter_Sheet1.RowCount = 0;
            this.fpFilter_Sheet1.RowHeader.ColumnCount = 0;
            this.fpFilter_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpFilter_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpFilter_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpFilter_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpFilter.SetActiveViewport(1, 1);
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            
            this.ClientSize = new System.Drawing.Size(448, 317);
            this.Controls.Add(this.fpFilter);
            this.Controls.Add(this.pnlText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlText.ResumeLayout(false);
            this.pnlText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpFilter_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlText;
        private System.Windows.Forms.TextBox txtFilter;
        private FarPoint.Win.Spread.FpSpread fpFilter;
        private FarPoint.Win.Spread.SheetView fpFilter_Sheet1;

    }
}