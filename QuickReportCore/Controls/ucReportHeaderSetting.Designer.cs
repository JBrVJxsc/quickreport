namespace QuickReportCore.Controls
{
    partial class ucReportHeaderSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucReportHeaderSetting));
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbAdd = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tbFont = new System.Windows.Forms.ToolStripButton();
            this.tbColor = new System.Windows.Forms.ToolStripButton();
            this.tbHAligment = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbHLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.tbHCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.tbHRight = new System.Windows.Forms.ToolStripMenuItem();
            this.tbHGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.tbVAligment = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbVTop = new System.Windows.Forms.ToolStripMenuItem();
            this.tbVCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.tbVBottom = new System.Windows.Forms.ToolStripMenuItem();
            this.tbVGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.tbAutoRowHeight = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.fpMain = new FarPoint.Win.Spread.FpSpread();
            this.fpMain_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpMain_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbAdd,
            this.tbDelete,
            this.toolStripSeparator,
            this.tbFont,
            this.tbColor,
            this.tbHAligment,
            this.tbVAligment,
            this.tbAutoRowHeight});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.ShowItemToolTips = false;
            this.toolStrip.Size = new System.Drawing.Size(569, 25);
            this.toolStrip.TabIndex = 4;
            // 
            // tbAdd
            // 
            this.tbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(48, 22);
            this.tbAdd.Text = "添加行";
            this.tbAdd.Click += new System.EventHandler(this.tbAdd_Click);
            // 
            // tbDelete
            // 
            this.tbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(48, 22);
            this.tbDelete.Text = "删除行";
            this.tbDelete.Click += new System.EventHandler(this.tbDelete_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // tbFont
            // 
            this.tbFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbFont.Image = ((System.Drawing.Image)(resources.GetObject("tbFont.Image")));
            this.tbFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbFont.Name = "tbFont";
            this.tbFont.Size = new System.Drawing.Size(36, 22);
            this.tbFont.Text = "字体";
            this.tbFont.Click += new System.EventHandler(this.tbFont_Click);
            // 
            // tbColor
            // 
            this.tbColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbColor.Image = ((System.Drawing.Image)(resources.GetObject("tbColor.Image")));
            this.tbColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbColor.Name = "tbColor";
            this.tbColor.Size = new System.Drawing.Size(36, 22);
            this.tbColor.Text = "颜色";
            this.tbColor.Click += new System.EventHandler(this.tbColor_Click);
            // 
            // tbHAligment
            // 
            this.tbHAligment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbHAligment.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbHLeft,
            this.tbHCenter,
            this.tbHRight,
            this.tbHGeneral});
            this.tbHAligment.Image = ((System.Drawing.Image)(resources.GetObject("tbHAligment.Image")));
            this.tbHAligment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbHAligment.Name = "tbHAligment";
            this.tbHAligment.Size = new System.Drawing.Size(69, 22);
            this.tbHAligment.Text = "横向格式";
            this.tbHAligment.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tbHAligment_DropDownItemClicked);
            // 
            // tbHLeft
            // 
            this.tbHLeft.Name = "tbHLeft";
            this.tbHLeft.Size = new System.Drawing.Size(152, 22);
            this.tbHLeft.Text = "左对齐";
            // 
            // tbHCenter
            // 
            this.tbHCenter.Name = "tbHCenter";
            this.tbHCenter.Size = new System.Drawing.Size(152, 22);
            this.tbHCenter.Text = "居中";
            // 
            // tbHRight
            // 
            this.tbHRight.Name = "tbHRight";
            this.tbHRight.Size = new System.Drawing.Size(152, 22);
            this.tbHRight.Text = "右对齐";
            // 
            // tbHGeneral
            // 
            this.tbHGeneral.Name = "tbHGeneral";
            this.tbHGeneral.Size = new System.Drawing.Size(152, 22);
            this.tbHGeneral.Text = "普通";
            // 
            // tbVAligment
            // 
            this.tbVAligment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbVAligment.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbVTop,
            this.tbVCenter,
            this.tbVBottom,
            this.tbVGeneral});
            this.tbVAligment.Image = ((System.Drawing.Image)(resources.GetObject("tbVAligment.Image")));
            this.tbVAligment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbVAligment.Name = "tbVAligment";
            this.tbVAligment.Size = new System.Drawing.Size(69, 22);
            this.tbVAligment.Text = "纵向格式";
            this.tbVAligment.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tbVAligment_DropDownItemClicked);
            // 
            // tbVTop
            // 
            this.tbVTop.Name = "tbVTop";
            this.tbVTop.Size = new System.Drawing.Size(152, 22);
            this.tbVTop.Text = "上对齐";
            // 
            // tbVCenter
            // 
            this.tbVCenter.Name = "tbVCenter";
            this.tbVCenter.Size = new System.Drawing.Size(152, 22);
            this.tbVCenter.Text = "居中";
            // 
            // tbVBottom
            // 
            this.tbVBottom.Name = "tbVBottom";
            this.tbVBottom.Size = new System.Drawing.Size(152, 22);
            this.tbVBottom.Text = "下对齐";
            // 
            // tbVGeneral
            // 
            this.tbVGeneral.Name = "tbVGeneral";
            this.tbVGeneral.Size = new System.Drawing.Size(152, 22);
            this.tbVGeneral.Text = "普通";
            // 
            // tbAutoRowHeight
            // 
            this.tbAutoRowHeight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbAutoRowHeight.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbAll,
            this.tbSelect});
            this.tbAutoRowHeight.Image = ((System.Drawing.Image)(resources.GetObject("tbAutoRowHeight.Image")));
            this.tbAutoRowHeight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAutoRowHeight.Name = "tbAutoRowHeight";
            this.tbAutoRowHeight.Size = new System.Drawing.Size(81, 22);
            this.tbAutoRowHeight.Text = "自适应行高";
            // 
            // tbAll
            // 
            this.tbAll.Name = "tbAll";
            this.tbAll.Size = new System.Drawing.Size(152, 22);
            this.tbAll.Text = "全部行";
            this.tbAll.Click += new System.EventHandler(this.tbAll_Click);
            // 
            // tbSelect
            // 
            this.tbSelect.Name = "tbSelect";
            this.tbSelect.Size = new System.Drawing.Size(152, 22);
            this.tbSelect.Text = "选中行";
            this.tbSelect.Click += new System.EventHandler(this.tbSelect_Click);
            // 
            // fpMain
            // 
            this.fpMain.About = "2.5.2007.2005";
            this.fpMain.AccessibleDescription = "fpMain, Sheet1, Row 0, Column 0, ";
            this.fpMain.BackColor = System.Drawing.SystemColors.Control;
            this.fpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpMain.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpMain.Location = new System.Drawing.Point(0, 25);
            this.fpMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fpMain.Name = "fpMain";
            this.fpMain.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpMain_Sheet1});
            this.fpMain.Size = new System.Drawing.Size(569, 203);
            this.fpMain.TabIndex = 5;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpMain.TextTipAppearance = tipAppearance2;
            this.fpMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpMain.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpMain_CellDoubleClick);
            this.fpMain.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpMain_CellClick);
            // 
            // fpMain_Sheet1
            // 
            this.fpMain_Sheet1.Reset();
            this.fpMain_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpMain_Sheet1.ColumnCount = 1;
            this.fpMain_Sheet1.RowCount = 0;
            this.fpMain_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = " ";
            this.fpMain_Sheet1.Columns.Get(0).CellType = textCellType2;
            this.fpMain_Sheet1.Columns.Get(0).Label = " ";
            this.fpMain_Sheet1.Columns.Get(0).Width = 534F;
            this.fpMain_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpMain.SetActiveViewport(1, 0);
            // 
            // ucReportHeaderSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fpMain);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucReportHeaderSetting";
            this.Size = new System.Drawing.Size(569, 228);
            this.Load += new System.EventHandler(this.ucReportHeaderSetting_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpMain_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbAdd;
        private System.Windows.Forms.ToolStripButton tbDelete;
        private System.Windows.Forms.ToolStripButton tbFont;
        private System.Windows.Forms.ToolStripDropDownButton tbHAligment;
        private System.Windows.Forms.ToolStripMenuItem tbHLeft;
        private System.Windows.Forms.ToolStripMenuItem tbHCenter;
        private System.Windows.Forms.ToolStripMenuItem tbHRight;
        private System.Windows.Forms.ToolStripDropDownButton tbVAligment;
        private System.Windows.Forms.ToolStripMenuItem tbVTop;
        private System.Windows.Forms.ToolStripMenuItem tbVCenter;
        private System.Windows.Forms.ToolStripMenuItem tbVBottom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private FarPoint.Win.Spread.FpSpread fpMain;
        private FarPoint.Win.Spread.SheetView fpMain_Sheet1;
        private System.Windows.Forms.ToolStripMenuItem tbHGeneral;
        private System.Windows.Forms.ToolStripMenuItem tbVGeneral;
        private System.Windows.Forms.ToolStripDropDownButton tbAutoRowHeight;
        private System.Windows.Forms.ToolStripMenuItem tbAll;
        private System.Windows.Forms.ToolStripMenuItem tbSelect;
        private System.Windows.Forms.ToolStripButton tbColor;

    }
}
