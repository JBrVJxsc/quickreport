namespace QuickReportLib.Controls.ReportSetting
{
    partial class ConditionSetting
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
            this.fpConditions = new QuickReportLib.Controls.Plus.FpSpreadPlus();
            this.fpConditions_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.conditionDetailSetting = new QuickReportLib.Controls.ReportSetting.ConditionDetailSetting();
            ((System.ComponentModel.ISupportInitialize)(this.fpConditions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpConditions_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpConditions
            // 
            this.fpConditions.About = "2.5.2007.2005";
            this.fpConditions.AccessibleDescription = "fpConditions, Sheet1, Row 0, Column 0, ";
            this.fpConditions.BackColor = System.Drawing.SystemColors.Control;
            this.fpConditions.Dock = System.Windows.Forms.DockStyle.Left;
            this.fpConditions.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpConditions.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpConditions.IsEditing = false;
            this.fpConditions.Location = new System.Drawing.Point(0, 0);
            this.fpConditions.Name = "fpConditions";
            this.fpConditions.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpConditions_Sheet1});
            this.fpConditions.Size = new System.Drawing.Size(164, 263);
            this.fpConditions.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpConditions.TextTipAppearance = tipAppearance1;
            this.fpConditions.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpConditions.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpConditions_CellClick);
            this.fpConditions.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.fpConditions_EnterCell);
            // 
            // fpConditions_Sheet1
            // 
            this.fpConditions_Sheet1.Reset();
            this.fpConditions_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpConditions_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpConditions_Sheet1.ColumnCount = 1;
            this.fpConditions_Sheet1.ColumnHeader.RowCount = 0;
            this.fpConditions_Sheet1.RowCount = 0;
            this.fpConditions_Sheet1.RowHeader.ColumnCount = 0;
            this.fpConditions_Sheet1.Columns.Get(0).Locked = true;
            this.fpConditions_Sheet1.Columns.Get(0).Width = 153F;
            this.fpConditions_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpConditions_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpConditions_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpConditions.SetActiveViewport(1, 0);
            // 
            // conditionDetailSetting
            // 
            this.conditionDetailSetting.Condition = null;
            this.conditionDetailSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conditionDetailSetting.Location = new System.Drawing.Point(164, 0);
            this.conditionDetailSetting.Name = "conditionDetailSetting";
            this.conditionDetailSetting.Size = new System.Drawing.Size(562, 263);
            this.conditionDetailSetting.TabIndex = 1;
            // 
            // ConditionSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            
            this.Controls.Add(this.conditionDetailSetting);
            this.Controls.Add(this.fpConditions);
            this.Name = "ConditionSetting";
            this.Size = new System.Drawing.Size(726, 263);
            ((System.ComponentModel.ISupportInitialize)(this.fpConditions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpConditions_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QuickReportLib.Controls.Plus.FpSpreadPlus fpConditions;
        private FarPoint.Win.Spread.SheetView fpConditions_Sheet1;
        private ConditionDetailSetting conditionDetailSetting;
    }
}
