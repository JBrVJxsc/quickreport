namespace QuickReportLib.Controls
{
    partial class SheetViewForHeaderSetting
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
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // SheetViewForHeaderSetting
            // 
            this.Reset();
            this.SheetName = "";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.ColumnCount = 0;
            this.RowCount = 0;
            this.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.ColumnHeader.DefaultStyle.Locked = false;
            this.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Black);
            this.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Black);
            this.DataAutoCellTypes = false;
            this.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.RowHeader.DefaultStyle.Locked = false;
            this.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Black);
            this.RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Black);
            this.SheetCornerHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Black);
            this.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.SheetCornerStyle.Locked = false;
            this.SheetCornerStyle.Parent = "HeaderDefault";
            this.SheetCornerVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Black);
            this.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion
    }
}
