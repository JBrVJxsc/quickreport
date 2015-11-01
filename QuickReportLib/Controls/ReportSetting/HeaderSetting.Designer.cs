namespace QuickReportLib.Controls.ReportSetting
{
    partial class HeaderSetting
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
            this.fpMain = new QuickReportLib.Controls.FpSpreadForHeaderSetting();
            ((System.ComponentModel.ISupportInitialize)(this.fpMain)).BeginInit();
            this.SuspendLayout();
            // 
            // fpMain
            // 
            this.fpMain.About = "2.5.2007.2005";
            this.fpMain.AccessibleDescription = "fpMain";
            this.fpMain.AllowColumnHeaderClick = true;
            this.fpMain.AllowCornerHeaderClick = false;
            this.fpMain.AllowRowHeaderClick = true;
            this.fpMain.BottomRowCount = 0;
            this.fpMain.CanEditColumn = false;
            this.fpMain.CellRange = null;
            this.fpMain.ColumnCount = 500;
            this.fpMain.CommandStatus = QuickReportLib.Enums.HeaderSettingCommandStatus.SelectColumn;
            this.fpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpMain.Font = new System.Drawing.Font("宋体", 9F);
            this.fpMain.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpMain.IsEditing = false;
            this.fpMain.Location = new System.Drawing.Point(0, 0);
            this.fpMain.Name = "fpMain";
            this.fpMain.ReportColumnSelected = null;
            this.fpMain.Size = new System.Drawing.Size(697, 376);
            this.fpMain.TabIndex = 2;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpMain.TextTipAppearance = tipAppearance1;
            this.fpMain.TopRowCount = 0;
            this.fpMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpMain.HeaderSettingCommandStatusChanged += new QuickReportLib.Controls.HeaderSettingCommandStatusChangedHandle(this.fpMain_HeaderSettingCommandStatusChanged);
            this.fpMain.HeaderSettingFpSpreadChanged += new QuickReportLib.Controls.HeaderSettingFpSpreadChangedHandle(this.fpMain_HeaderSettingFpSpreadChanged);
            this.fpMain.ActiveSheetIndex = -1;
            // 
            // HeaderSetting
            // 
            this.Controls.Add(this.fpMain);
            this.Name = "HeaderSetting";
            this.Size = new System.Drawing.Size(697, 376);
            ((System.ComponentModel.ISupportInitialize)(this.fpMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FpSpreadForHeaderSetting fpMain;

    }
}
