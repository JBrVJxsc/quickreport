namespace QuickReportCore.Controls.Report
{
    partial class ucReportV100
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucReportV100));
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            this.pnlConditions = new System.Windows.Forms.Panel();
            this.ucReportConditionList = new QuickReportCore.Controls.ucReportConditionList();
            this.splitContainerH = new System.Windows.Forms.SplitContainer();
            this.grbTree = new System.Windows.Forms.GroupBox();
            this.tvReport = new QuickReportCore.Controls.TreeViewPlus();
            this.treeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbTreeExp = new System.Windows.Forms.ToolStripMenuItem();
            this.tbTreeCol = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainerV = new System.Windows.Forms.SplitContainer();
            this.grbReport = new System.Windows.Forms.GroupBox();
            this.fpMain = new FarPoint.Win.Spread.FpSpread();
            this.fpMain_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grbDetail = new System.Windows.Forms.GroupBox();
            this.fpDetail = new FarPoint.Win.Spread.FpSpread();
            this.fpDetail_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlConditions.SuspendLayout();
            this.splitContainerH.Panel1.SuspendLayout();
            this.splitContainerH.Panel2.SuspendLayout();
            this.splitContainerH.SuspendLayout();
            this.grbTree.SuspendLayout();
            this.treeContextMenuStrip.SuspendLayout();
            this.splitContainerV.Panel1.SuspendLayout();
            this.splitContainerV.Panel2.SuspendLayout();
            this.splitContainerV.SuspendLayout();
            this.grbReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpMain_Sheet1)).BeginInit();
            this.grbDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpDetail_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlConditions
            // 
            this.pnlConditions.Controls.Add(this.ucReportConditionList);
            this.pnlConditions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConditions.Location = new System.Drawing.Point(0, 0);
            this.pnlConditions.Name = "pnlConditions";
            this.pnlConditions.Size = new System.Drawing.Size(905, 45);
            this.pnlConditions.TabIndex = 0;
            // 
            // ucReportConditionList
            // 
            this.ucReportConditionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReportConditionList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucReportConditionList.Location = new System.Drawing.Point(0, 0);
            this.ucReportConditionList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucReportConditionList.Name = "ucReportConditionList";
            this.ucReportConditionList.Size = new System.Drawing.Size(905, 45);
            this.ucReportConditionList.TabIndex = 1;
            // 
            // splitContainerH
            // 
            this.splitContainerH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerH.Location = new System.Drawing.Point(0, 45);
            this.splitContainerH.Name = "splitContainerH";
            // 
            // splitContainerH.Panel1
            // 
            this.splitContainerH.Panel1.Controls.Add(this.grbTree);
            this.splitContainerH.Panel1MinSize = 0;
            // 
            // splitContainerH.Panel2
            // 
            this.splitContainerH.Panel2.Controls.Add(this.splitContainerV);
            this.splitContainerH.Size = new System.Drawing.Size(905, 466);
            this.splitContainerH.SplitterDistance = 180;
            this.splitContainerH.TabIndex = 1;
            this.splitContainerH.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
            this.splitContainerH.SizeChanged += new System.EventHandler(this.splitContainer_SizeChanged);
            // 
            // grbTree
            // 
            this.grbTree.Controls.Add(this.tvReport);
            this.grbTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbTree.Location = new System.Drawing.Point(0, 0);
            this.grbTree.Name = "grbTree";
            this.grbTree.Size = new System.Drawing.Size(180, 466);
            this.grbTree.TabIndex = 2;
            this.grbTree.TabStop = false;
            // 
            // tvReport
            // 
            this.tvReport.ContextMenuStrip = this.treeContextMenuStrip;
            this.tvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvReport.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvReport.FullRowSelect = true;
            this.tvReport.HideSelection = false;
            this.tvReport.ImageIndex = 0;
            this.tvReport.ImageList = this.imageList;
            this.tvReport.Location = new System.Drawing.Point(3, 17);
            this.tvReport.Name = "tvReport";
            this.tvReport.SelectedImageIndex = 0;
            this.tvReport.ShowRootLines = false;
            this.tvReport.Size = new System.Drawing.Size(174, 446);
            this.tvReport.TabIndex = 0;
            this.tvReport.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvReport_NodeMouseDoubleClick);
            this.tvReport.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvReport_AfterSelect);
            // 
            // treeContextMenuStrip
            // 
            this.treeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbTreeExp,
            this.tbTreeCol});
            this.treeContextMenuStrip.Name = "treeContextMenuStrip";
            this.treeContextMenuStrip.Size = new System.Drawing.Size(125, 48);
            // 
            // tbTreeExp
            // 
            this.tbTreeExp.Name = "tbTreeExp";
            this.tbTreeExp.Size = new System.Drawing.Size(124, 22);
            this.tbTreeExp.Text = "展开全部";
            this.tbTreeExp.Click += new System.EventHandler(this.tbTreeExp_Click);
            // 
            // tbTreeCol
            // 
            this.tbTreeCol.Name = "tbTreeCol";
            this.tbTreeCol.Size = new System.Drawing.Size(124, 22);
            this.tbTreeCol.Text = "折叠全部";
            this.tbTreeCol.Click += new System.EventHandler(this.tbTreeCol_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "1.png");
            this.imageList.Images.SetKeyName(1, "2.png");
            this.imageList.Images.SetKeyName(2, "3.png");
            this.imageList.Images.SetKeyName(3, "4.png");
            this.imageList.Images.SetKeyName(4, "5.png");
            this.imageList.Images.SetKeyName(5, "6.png");
            this.imageList.Images.SetKeyName(6, "7.png");
            this.imageList.Images.SetKeyName(7, "8.png");
            this.imageList.Images.SetKeyName(8, "9.png");
            this.imageList.Images.SetKeyName(9, "10.png");
            this.imageList.Images.SetKeyName(10, "11.png");
            this.imageList.Images.SetKeyName(11, "12.png");
            this.imageList.Images.SetKeyName(12, "13.png");
            this.imageList.Images.SetKeyName(13, "14.png");
            this.imageList.Images.SetKeyName(14, "15.png");
            this.imageList.Images.SetKeyName(15, "16.png");
            this.imageList.Images.SetKeyName(16, "17.png");
            this.imageList.Images.SetKeyName(17, "18.png");
            this.imageList.Images.SetKeyName(18, "19.png");
            this.imageList.Images.SetKeyName(19, "20.png");
            this.imageList.Images.SetKeyName(20, "21.png");
            this.imageList.Images.SetKeyName(21, "22.png");
            this.imageList.Images.SetKeyName(22, "23.png");
            this.imageList.Images.SetKeyName(23, "24.png");
            this.imageList.Images.SetKeyName(24, "25.png");
            this.imageList.Images.SetKeyName(25, "26.png");
            this.imageList.Images.SetKeyName(26, "27.png");
            this.imageList.Images.SetKeyName(27, "28.png");
            this.imageList.Images.SetKeyName(28, "29.png");
            this.imageList.Images.SetKeyName(29, "30.png");
            this.imageList.Images.SetKeyName(30, "31.png");
            this.imageList.Images.SetKeyName(31, "32.png");
            this.imageList.Images.SetKeyName(32, "33.png");
            this.imageList.Images.SetKeyName(33, "34.png");
            this.imageList.Images.SetKeyName(34, "35.png");
            this.imageList.Images.SetKeyName(35, "36.png");
            // 
            // splitContainerV
            // 
            this.splitContainerV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerV.Location = new System.Drawing.Point(0, 0);
            this.splitContainerV.Name = "splitContainerV";
            this.splitContainerV.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerV.Panel1
            // 
            this.splitContainerV.Panel1.Controls.Add(this.grbReport);
            // 
            // splitContainerV.Panel2
            // 
            this.splitContainerV.Panel2.Controls.Add(this.grbDetail);
            this.splitContainerV.Panel2MinSize = 0;
            this.splitContainerV.Size = new System.Drawing.Size(721, 466);
            this.splitContainerV.SplitterDistance = 255;
            this.splitContainerV.TabIndex = 0;
            this.splitContainerV.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
            this.splitContainerV.SizeChanged += new System.EventHandler(this.splitContainer_SizeChanged);
            // 
            // grbReport
            // 
            this.grbReport.Controls.Add(this.fpMain);
            this.grbReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbReport.Location = new System.Drawing.Point(0, 0);
            this.grbReport.Name = "grbReport";
            this.grbReport.Size = new System.Drawing.Size(721, 255);
            this.grbReport.TabIndex = 2;
            this.grbReport.TabStop = false;
            // 
            // fpMain
            // 
            this.fpMain.About = "2.5.2007.2005";
            this.fpMain.AccessibleDescription = "fpMain, Sheet1, Row 0, Column 0, ";
            this.fpMain.BackColor = System.Drawing.Color.White;
            this.fpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpMain.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpMain.Location = new System.Drawing.Point(3, 17);
            this.fpMain.Name = "fpMain";
            this.fpMain.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpMain_Sheet1});
            this.fpMain.Size = new System.Drawing.Size(715, 235);
            this.fpMain.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpMain.TextTipAppearance = tipAppearance1;
            this.fpMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpMain.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpMain.AutoSortingColumn += new FarPoint.Win.Spread.AutoSortingColumnEventHandler(this.fpMain_AutoSortingColumn);
            this.fpMain.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpMain_CellDoubleClick);
            this.fpMain.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpMain_CellClick);
            this.fpMain.ColumnWidthChanged += new FarPoint.Win.Spread.ColumnWidthChangedEventHandler(this.fpMain_ColumnWidthChanged);
            // 
            // fpMain_Sheet1
            // 
            this.fpMain_Sheet1.Reset();
            this.fpMain_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpMain_Sheet1.ColumnCount = 0;
            this.fpMain_Sheet1.ColumnHeader.RowCount = 0;
            this.fpMain_Sheet1.RowCount = 0;
            this.fpMain_Sheet1.RowHeader.ColumnCount = 0;
            this.fpMain_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.fpMain_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpMain_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpMain_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpMain_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpMain_Sheet1.ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.fpMain_Sheet1.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.fpMain_Sheet1.DataAutoCellTypes = false;
            this.fpMain_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.fpMain_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.fpMain_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.fpMain_Sheet1.PrintInfo.ShowBorder = false;
            this.fpMain_Sheet1.Protect = false;
            this.fpMain_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpMain_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpMain_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpMain_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpMain_Sheet1.RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.fpMain_Sheet1.RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.fpMain_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpMain_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpMain_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.fpMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpMain.SetActiveViewport(1, 1);
            // 
            // grbDetail
            // 
            this.grbDetail.Controls.Add(this.fpDetail);
            this.grbDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbDetail.Location = new System.Drawing.Point(0, 0);
            this.grbDetail.Name = "grbDetail";
            this.grbDetail.Size = new System.Drawing.Size(721, 207);
            this.grbDetail.TabIndex = 2;
            this.grbDetail.TabStop = false;
            // 
            // fpDetail
            // 
            this.fpDetail.About = "2.5.2007.2005";
            this.fpDetail.AccessibleDescription = "fpDetail";
            this.fpDetail.BackColor = System.Drawing.Color.White;
            this.fpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpDetail.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpDetail.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpDetail.Location = new System.Drawing.Point(3, 17);
            this.fpDetail.Name = "fpDetail";
            this.fpDetail.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpDetail_Sheet1});
            this.fpDetail.Size = new System.Drawing.Size(715, 187);
            this.fpDetail.TabIndex = 1;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpDetail.TextTipAppearance = tipAppearance2;
            this.fpDetail.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpDetail.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpDetail.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpDetail_CellDoubleClick);
            this.fpDetail.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpDetail_CellClick);
            // 
            // fpDetail_Sheet1
            // 
            this.fpDetail_Sheet1.Reset();
            this.fpDetail_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpDetail_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpDetail_Sheet1.ColumnCount = 0;
            this.fpDetail_Sheet1.ColumnHeader.RowCount = 0;
            this.fpDetail_Sheet1.RowCount = 0;
            this.fpDetail_Sheet1.RowHeader.ColumnCount = 0;
            this.fpDetail_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkinReport", System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Color.Black, System.Drawing.Color.Black, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Black, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.White, System.Drawing.Color.Empty, true, true, true, true, true);
            this.fpDetail_Sheet1.ColumnHeader.Columns.Default.CanFocus = false;
            this.fpDetail_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpDetail_Sheet1.ColumnHeader.DefaultStyle.CanFocus = false;
            this.fpDetail_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.fpDetail_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.fpDetail_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpDetail_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpDetail_Sheet1.ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Color.White);
            this.fpDetail_Sheet1.ColumnHeader.Rows.Default.CanFocus = false;
            this.fpDetail_Sheet1.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Color.White);
            this.fpDetail_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpDetail_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.fpDetail_Sheet1.DefaultStyle.Locked = false;
            this.fpDetail_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.fpDetail_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.fpDetail_Sheet1.PrintInfo.ShowBorder = false;
            this.fpDetail_Sheet1.RowHeader.Columns.Default.CanFocus = false;
            this.fpDetail_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpDetail_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpDetail_Sheet1.RowHeader.DefaultStyle.CanFocus = false;
            this.fpDetail_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.fpDetail_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.fpDetail_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpDetail_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpDetail_Sheet1.RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Color.White);
            this.fpDetail_Sheet1.RowHeader.Rows.Default.CanFocus = false;
            this.fpDetail_Sheet1.RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Color.White);
            this.fpDetail_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpDetail_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpDetail_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.Black;
            this.fpDetail_Sheet1.SheetCornerStyle.Locked = false;
            this.fpDetail_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpDetail_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpDetail.SetActiveViewport(1, 1);
            // 
            // ucReportV100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerH);
            this.Controls.Add(this.pnlConditions);
            this.DoubleBuffered = true;
            this.Name = "ucReportV100";
            this.Size = new System.Drawing.Size(905, 511);
            this.pnlConditions.ResumeLayout(false);
            this.splitContainerH.Panel1.ResumeLayout(false);
            this.splitContainerH.Panel2.ResumeLayout(false);
            this.splitContainerH.ResumeLayout(false);
            this.grbTree.ResumeLayout(false);
            this.treeContextMenuStrip.ResumeLayout(false);
            this.splitContainerV.Panel1.ResumeLayout(false);
            this.splitContainerV.Panel2.ResumeLayout(false);
            this.splitContainerV.ResumeLayout(false);
            this.grbReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpMain_Sheet1)).EndInit();
            this.grbDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpDetail_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlConditions;
        private System.Windows.Forms.SplitContainer splitContainerH;
        private System.Windows.Forms.GroupBox grbTree;
        private QuickReportCore.Controls.TreeViewPlus tvReport;
        private System.Windows.Forms.SplitContainer splitContainerV;
        private System.Windows.Forms.GroupBox grbReport;
        private FarPoint.Win.Spread.FpSpread fpMain;
        private FarPoint.Win.Spread.SheetView fpMain_Sheet1;
        private System.Windows.Forms.GroupBox grbDetail;
        private ucReportConditionList ucReportConditionList;
        private System.Windows.Forms.ContextMenuStrip treeContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tbTreeExp;
        private System.Windows.Forms.ToolStripMenuItem tbTreeCol;
        private FarPoint.Win.Spread.FpSpread fpDetail;
        private FarPoint.Win.Spread.SheetView fpDetail_Sheet1;
        private System.Windows.Forms.ImageList imageList;
    }
}
