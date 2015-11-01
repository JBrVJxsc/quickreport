using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FarPoint.Win;
using FarPoint.Win.Spread.Model;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.DrawingSpace;
using QuickReportLib.Class.Fp;
using QuickReportLib.Forms.ReportSetting;
using QuickReportLib.Controls.Plus;
using QuickReportLib.Enums;
using QuickReportLib.Objects;
using QuickReportLib.ReportStyles;
using QuickReportLib.Managers;
using QuickReportLib.Interfaces.ReportSetting;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Objects.ReportSetting;

namespace QuickReportLib.Controls
{
    internal partial class FpSpreadForHeaderSetting : FpSpreadPlus, IGlobalValueAsker, IGlobalValueToolStripItemAsker , IChangedUserControl
    {
        public FpSpreadForHeaderSetting()
        {
            InitializeComponent();
            InitAskForGlobalValueTypes();
            InitCellType();
        }

        /// <summary>
        /// 表头设置时的命令状态改变时触发的事件。
        /// </summary>
        public event HeaderSettingCommandStatusChangedHandle HeaderSettingCommandStatusChanged;
        /// <summary>
        /// FpSpread发生改变时触发的事件。
        /// </summary>
        public event HeaderSettingFpSpreadChangedHandle HeaderSettingFpSpreadChanged;

        private Report report;
        private List<BevelLine> bevelLineList = new List<BevelLine>();
        private List<GlobalValueType> globalValueTypeListOfHeader;
        private List<GlobalValueType> globalValueTypeList;
        private List<GlobalValueType> nullGlobalValueTypeList = new List<GlobalValueType>();
        private SheetViewForHeaderSetting sheetMain = new SheetViewForHeaderSetting();
        private int topRowCount = 0;
        private int bottomRowCount = 0;
        private bool canEditColumn = false;
        private List<Column> columnList;
        private CellRange cellRange;
        private Column reportColumnSelected;
        private TextCellType textCellType;
        private TextCellType normalTextCellType;
        private HeaderSettingCommandStatus commandStatus;
        private ReportColumnPropertyEditor reportColumnPropertyEditor;

        /// <summary>
        /// 主Sheet。
        /// </summary>
        public SheetViewForHeaderSetting SheetMain
        {
            get
            {
                return sheetMain;
            }
        }

        /// <summary>
        /// 表首行数。
        /// </summary>
        public int TopRowCount
        {
            get
            {
                return topRowCount;
            }
            set
            {
                topRowCount = value;
                if (sheetMain.Rows.Count == 0)
                {
                    return;
                }
                //获取当前报表列所在行号。
                int reportColumnRowIndex = ReportColumnRowIndex;
                //如果不存在报表列，则返回。
                if (reportColumnRowIndex == -1)
                {
                    return;
                }
                //如果需要设置的表首行数与报表列行号相同，说明不需要增减行数。
                if (topRowCount == reportColumnRowIndex)
                {
                    return;
                }
                //如果需要设置的表首行数大于报表列行号，则从第一行开始新增行数。
                else if (topRowCount > reportColumnRowIndex)
                {
                    sheetMain.AddRows(0, topRowCount - reportColumnRowIndex);
                }
                //如果需要设置的表首行数小于报表列行号，则从第一行开始减少行数。
                else
                {
                    //当表首行数减少时，则判断斜线是否应该显示。
                    CheckTopBevelLineWhenTopRowCountReduced(0, topRowCount-1);
                    sheetMain.RemoveRows(0, reportColumnRowIndex - topRowCount);
                }
                //显示行号。
                for (int i = 0; i < topRowCount; i++)
                {
                    sheetMain.Rows[i].Label = (i + 1).ToString();    
                }
                //清空当前选择。
                ClearSelection();
                //广播Fp界面产生的修改。
                FpChanged(HeaderSettingFpSpreadChangedType.TopRowCountChanged);
            }
        }

        /// <summary>
        /// 表尾行数。
        /// </summary>
        public int BottomRowCount
        {
            get
            {
                return bottomRowCount;
            }
            set
            {
                bottomRowCount = value;
                if (sheetMain.Rows.Count == 0)
                {
                    return;
                }
                int reportColumnRowIndex = ReportColumnRowIndex;
                if (reportColumnRowIndex == -1)
                {
                    return;
                }
                int lastRowIndex = sheetMain.Rows.Count - 1;
                int nowBottomRowCount = lastRowIndex - reportColumnRowIndex;
                if (bottomRowCount == nowBottomRowCount)
                {
                    return;
                }
                else if (bottomRowCount > nowBottomRowCount)
                {
                    sheetMain.AddRows(lastRowIndex + 1, bottomRowCount - nowBottomRowCount);
                }
                else
                {
                    CheckBottomBevelLineWhenBottomRowCountReduced(reportColumnRowIndex + 1, reportColumnRowIndex + bottomRowCount);
                    sheetMain.RemoveRows(reportColumnRowIndex + 1, nowBottomRowCount - bottomRowCount);
                }
                reportColumnRowIndex = ReportColumnRowIndex;
                int index = 1;
                for (int i = reportColumnRowIndex + 1; i < sheetMain.Rows.Count; i++)
                {
                    sheetMain.Rows[i].Label = index.ToString();
                    index++;
                }
                ClearSelection();
                FpChanged(HeaderSettingFpSpreadChangedType.BottomRowCountChanged);
            }
        }

        /// <summary>
        /// 列数。
        /// </summary>
        public int ColumnCount
        {
            get
            {
                return sheetMain.Columns.Count;
            }
            set
            {
                //如果小于列数最小值，则返回。
                if (value < MinColumnCount)
                {
                    return;
                }
                //如果相同，则不修改。
                if (sheetMain.Columns.Count == value)
                {
                    return;
                }
                sheetMain.Columns.Count = value;
                for (int i = 0; i < sheetMain.Columns.Count; i++)
                {
                    sheetMain.Columns[i].CellType = textCellType;
                }
                SuspendLayout();
                DrawReportColumnList();
                ResumeLayout();
                CheckBevelLineWhenColumnCountReduced();
                ClearSelection();
                FpChanged(HeaderSettingFpSpreadChangedType.ColumnCountChanged);
            }
        }

        /// <summary>
        /// 是否可以编辑列。
        /// </summary>
        public bool CanEditColumn
        {
            get
            {
                return canEditColumn;
            }
            set
            {
                canEditColumn = value;
            }
        }

        /// <summary>
        /// 可以允许的最少列数。
        /// </summary>
        public int MinColumnCount
        {
            get
            {
                if (canEditColumn)
                {
                    if (report != null)
                    {
                        return report.Columns.Count;
                    }
                    return 1;
                }
                else
                {
                    return 1;
                }
            }
        }

        /// <summary>
        /// 报表列的行序号。
        /// </summary>
        public int ReportColumnRowIndex
        {
            get
            {
                for (int i = 0; i < sheetMain.Rows.Count; i++)
                {
                    if (sheetMain.Rows[i].Tag is List<QuickReportLib.Objects.Column>)
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        /// <summary>
        /// Cell区域。
        /// </summary>
        public CellRange CellRange
        {
            get
            {
                return cellRange;
            }
            set
            {
                cellRange = value;
            }
        }

        /// <summary>
        /// 当前选中的ReportColumn。
        /// </summary>
        public Column ReportColumnSelected
        {
            get
            {
                return reportColumnSelected;
            }
            set
            {
                reportColumnSelected = value;
            }
        }

        /// <summary>
        /// 命令状态。
        /// </summary>
        public HeaderSettingCommandStatus CommandStatus
        {
            get
            {
                return commandStatus;
            }
            set
            {
                commandStatus = value;
            }
        }

        /// <summary>
        /// 斜线列表。
        /// </summary>
        public List<BevelLine> GetBevelLines()
        {
            return bevelLineList;
        }

        /// <summary>
        /// 清空当前选择。
        /// </summary>
        private void ClearSelection()
        {
            sheetMain.ClearSelection();
        }

        private void InitCellType()
        {
            normalTextCellType = new TextCellType();
            textCellType = new TextCellType();
            textCellType.Multiline = true;
            textCellType.WordWrap = true;
        }

        /// <summary>
        /// 初始化Fp。
        /// </summary>
        private void InitFP()
        {
            //停止布局。
            SuspendLayout();

            #region 初始化报表列。
            sheetMain.Rows.Count = 1;
            sheetMain.Columns.Count = report.MainReportSetting.HeaderSetting.ColumnCount;
            sheetMain.Rows[0].Tag = report.Columns;
            sheetMain.Rows[0].Label = string.Empty;
            DrawReportColumnList();
            #endregion
            //初始化表首、表尾行数。
            TopRowCount = report.MainReportSetting.HeaderSetting.TopSetting.RowCount;
            BottomRowCount = report.MainReportSetting.HeaderSetting.BottomSetting.RowCount;
            //绘制Cells。
            DrawCells();
            //绘制行高与列宽。
            DrawRowHeightAndColumnWidth();
            //绘制斜线。
            DrawBevelLine();

            //恢复布局。
            ResumeLayout();
        }

        private void InitAskForGlobalValueTypes()
        {
            globalValueTypeListOfHeader = new List<GlobalValueType>();
            globalValueTypeListOfHeader.Add(GlobalValueType.Date);
            globalValueTypeListOfHeader.Add(GlobalValueType.DateTime);
            globalValueTypeListOfHeader.Add(GlobalValueType.Person);
            globalValueTypeListOfHeader.Add(GlobalValueType.Department);
            globalValueTypeListOfHeader.Add(GlobalValueType.Column);
            globalValueTypeListOfHeader.Add(GlobalValueType.Condition);
            globalValueTypeListOfHeader.Add(GlobalValueType.Tree);
            globalValueTypeListOfHeader.Add(GlobalValueType.Donamic);
        }

        /// <summary>
        /// 绘制报表列。
        /// </summary>
        private void DrawReportColumnList()
        {
            int reportColumnRowIndex = ReportColumnRowIndex;
            if (reportColumnRowIndex < 0)
            {
                return;
            }
            LineBorder border1 = new LineBorder(Color.Black, 1, true, true, true, true);
            LineBorder border2 = new LineBorder(Color.Black, 1, false, true, true, true);
            #region 先清空报表列所在行。
            for (int i = 0; i < sheetMain.Columns.Count; i++)
            {
                FarPoint.Win.Spread.Cell cell = sheetMain.Cells[reportColumnRowIndex, i];
                cell.Value = null;
                cell.Tag = null;
                cell.Border = null;
                cell.Locked = true;
            }
            #endregion
            if (canEditColumn)
            {
                List<Column> columnList = sheetMain.Rows[reportColumnRowIndex].Tag as List<Column>;
                if (columnList.Count > sheetMain.Columns.Count)
                {
                    sheetMain.Columns.Count = columnList.Count;
                    FpChanged(HeaderSettingFpSpreadChangedType.ColumnCountChanged);
                }
                foreach (Column column in columnList)
                {
                    int i = column.SortID;
                    FarPoint.Win.Spread.Cell cell = sheetMain.Cells[reportColumnRowIndex, i];
                    if (i == 0)
                    {
                        cell.Border = border1;
                    }
                    else
                    {
                        cell.Border = border2;
                    }
                    cell.Value = column.Name;
                    cell.Tag = column;
                    cell.CellType = normalTextCellType;
                    cell.Font = column.GetHeaderFont();
                    cell.ForeColor = column.GetHeaderColor();
                    cell.HorizontalAlignment = column.HeaderHAligment;
                    cell.VerticalAlignment = column.HeaderVAligment;
                    cell.Locked = false;
                }
            }
            else
            {
                for (int i = 0; i < sheetMain.Columns.Count; i++)
                {
                    if (i == 0)
                    {
                        sheetMain.Cells[reportColumnRowIndex, i].Border = border1;
                    }
                    else
                    {
                        sheetMain.Cells[reportColumnRowIndex, i].Border = border2;
                    }
                    sheetMain.Cells[reportColumnRowIndex, i].CellType = normalTextCellType;
                }
            }
        }

        private void DrawRowHeightAndColumnWidth()
        {
            int reportColumnRowIndex = ReportColumnRowIndex;
            List<RowHeight> topRowHeightList = report.MainReportSetting.HeaderSetting.TopSetting.RowHeightList;
            List<RowHeight> bottomRowHeightList = report.MainReportSetting.HeaderSetting.BottomSetting.RowHeightList;
            List<ColumnWidth> columnWidthList = report.MainReportSetting.HeaderSetting.ColumnWidthList;
            foreach (RowHeight rowHeight in topRowHeightList)
            {
                sheetMain.Rows[rowHeight.Row].Height = rowHeight.Height;
            }
            foreach (RowHeight rowHeight in bottomRowHeightList)
            {
                //需要添加报表列序号。
                sheetMain.Rows[rowHeight.Row + reportColumnRowIndex + 1].Height = rowHeight.Height;
            }
            foreach (ColumnWidth columnWidth in columnWidthList)
            {
                sheetMain.Columns[columnWidth.Column].Width = columnWidth.Width;
            }
            //报表列的行高。
            sheetMain.Rows[reportColumnRowIndex].Height = report.MainReportSetting.HeaderSetting.ReportColumnHeight;
        }

        private void DrawCells()
        {
            List<CellInfo> topCellInfoList = report.MainReportSetting.HeaderSetting.TopSetting.CellInfoList;
            DrawCells(topCellInfoList,0);
            List<CellInfo> bottomCellInfoList = report.MainReportSetting.HeaderSetting.BottomSetting.CellInfoList;
            DrawCells(bottomCellInfoList,ReportColumnRowIndex+1);
        }

        /// <summary>
        /// 根据CellInfo，绘制Cell。
        /// </summary>
        /// <param name="cellInfoList">CellInfo列表。</param>
        /// <param name="rowOffSet">起始行。</param>
        private void DrawCells(List<CellInfo> cellInfoList,int rowOffSet)
        {
            foreach (CellInfo cellInfo in cellInfoList)
            {
                int row = cellInfo.Row + rowOffSet;
                int column = cellInfo.Column;
                int rowSpan = cellInfo.RowSpan;
                int columnSpan = cellInfo.ColumnSpan;
                string text = cellInfo.Text;
                Font font = cellInfo.GetFont();
                Color color = cellInfo.GetColor();
                LineBorder border = cellInfo.CellBorder.GetBorder();
                FarPoint.Win.Spread.CellHorizontalAlignment hAlignment = cellInfo.HAligment;
                FarPoint.Win.Spread.CellVerticalAlignment vAlignment = cellInfo.VAligment;
                FarPoint.Win.Spread.Cell cell = sheetMain.Cells[row, column];
                cell.RowSpan = rowSpan;
                cell.ColumnSpan = columnSpan;
                cell.Value = text;
                cell.Font = font;
                cell.ForeColor = color;
                cell.Border = border;
                cell.HorizontalAlignment = hAlignment;
                cell.VerticalAlignment = vAlignment;
            }
        }

        private void DrawBevelLine()
        {
            List<BevelLine> topBevelLineList = report.MainReportSetting.HeaderSetting.TopSetting.BevelLineList;
            DrawBevelLine(topBevelLineList);
            List<BevelLine> bottomBevelLineList = report.MainReportSetting.HeaderSetting.BottomSetting.BevelLineList;
            #region 将报表列的序号添加至行。
            int reportColumnRowIndex = ReportColumnRowIndex;
            foreach (BevelLine bevelLine in bottomBevelLineList)
            {
                bevelLine.StartCellRow += reportColumnRowIndex+1;
                bevelLine.EndCellRow += reportColumnRowIndex+1;
            }
            #endregion
            DrawBevelLine(bottomBevelLineList);
        }

        /// <summary>
        /// 根据斜线列表绘制斜线。
        /// </summary>
        /// <param name="bevelLineList">斜线列表。</param>
        private void DrawBevelLine(List<BevelLine> bevelLineList)
        {
            foreach (BevelLine bevelLine in bevelLineList)
            {
                bevelLine.DrawLine(this, 0);
                //添加至bevelLineList进行统一管理，不分Top还是Bottom。
                this.bevelLineList.Add(bevelLine);
            }
        }

        /// <summary>
        /// 当Fp被修改时所需要手动执行的方法。
        /// </summary>
        /// <param name="changedType">Fp更改的类型。</param>
        private void FpChanged(HeaderSettingFpSpreadChangedType changedType)
        {
            if (HeaderSettingFpSpreadChanged != null)
            {
                HeaderSettingFpSpreadChanged(this, changedType);
            }
            ManualChange(changedType);
        }

        private void CheckTopBevelLineWhenTopRowCountReduced(int startIndex,int endIndex)
        {
            int reportColumnRowIndex=ReportColumnRowIndex;
            List<BevelLine> bevelLineNeedToBeDeleted = new List<BevelLine>();
            foreach (BevelLine bevelLine in bevelLineList)
            {
                if (bevelLine.EndCellRow < reportColumnRowIndex)
                { 
                    Rectangle rectangle = new Rectangle(0, startIndex, 1, endIndex-startIndex+1);
                    Point start=new Point(0,bevelLine.StartCellRow);
                    Point end =new Point(0,bevelLine.EndCellRow);
                    if (rectangle.Contains(start) && rectangle.Contains(end))
                    {
                        continue;
                    }
                    else
                    {
                        bevelLineNeedToBeDeleted.Add(bevelLine);
                    }
                }
            }
            foreach (BevelLine bevelLine in bevelLineNeedToBeDeleted)
            {
                RemoveBevelLine(bevelLine);
            }
        }

        private void CheckBottomBevelLineWhenBottomRowCountReduced(int startIndex, int endIndex)
        {
            int reportColumnRowIndex = ReportColumnRowIndex;
            List<BevelLine> bevelLineNeedToBeDeleted = new List<BevelLine>();
            foreach (BevelLine bevelLine in bevelLineList)
            {
                if (bevelLine.StartCellRow > reportColumnRowIndex)
                {
                    Rectangle rectangle = new Rectangle(0, startIndex, 1, endIndex-startIndex+1);
                    Point start = new Point(0, bevelLine.StartCellRow);
                    Point end = new Point(0, bevelLine.EndCellRow);
                    if (rectangle.Contains(start) && rectangle.Contains(end))
                    {
                        continue;
                    }
                    else
                    {
                        bevelLineNeedToBeDeleted.Add(bevelLine);
                    }
                }
            }
            foreach (BevelLine bevelLine in bevelLineNeedToBeDeleted)
            {
                RemoveBevelLine(bevelLine);
            }
        }

        private void CheckBevelLineWhenColumnCountReduced()
        {
            List<BevelLine> bevelLineNeedToBeDeleted = new List<BevelLine>();
            foreach (BevelLine bevelLine in bevelLineList)
            {
                Rectangle rectangle = new Rectangle(0, 0, sheetMain.ColumnCount,1);
                Point start = new Point(bevelLine.StartCellColumn,0);
                Point end = new Point(bevelLine.EndCellColumn,0);
                if (rectangle.Contains(start) && rectangle.Contains(end))
                {
                    continue;
                }
                else
                {
                    bevelLineNeedToBeDeleted.Add(bevelLine);
                }
            }
            foreach (BevelLine bevelLine in bevelLineNeedToBeDeleted)
            {
                RemoveBevelLine(bevelLine);
            }
        }

        /// <summary>
        /// 手动执行，表示Fp已被修改。
        /// </summary>
        /// <param name="changedType">改变类型。</param>
        public void ManualChange(HeaderSettingFpSpreadChangedType changedType)
        {
            if (Changed != null)
            {
                Changed(this, null);
            }
            switch (changedType)
            {
                case HeaderSettingFpSpreadChangedType.TopRowCountChanged:
                    {
                        ReDrawBevelLine();
                        break;
                    }
                case HeaderSettingFpSpreadChangedType.BottomRowCountChanged:
                    {
                        ReDrawBevelLine();
                        break;
                    }
                case HeaderSettingFpSpreadChangedType.RowHeightChanged:
                    {
                        ReDrawBevelLine();
                        break;
                    }
                case HeaderSettingFpSpreadChangedType.ColumnWidthChanged:
                    {
                        ReDrawBevelLine();
                        break;
                    }
                case HeaderSettingFpSpreadChangedType.ColumnCountChanged:
                    {
                        ReDrawBevelLine();
                        break;
                    }
            }
        }

        /// <summary>
        /// 添加一条斜线。
        /// </summary>
        /// <param name="bevelLine">斜线。</param>
        public void AddBevelLine(BevelLine bevelLine)
        {
            bevelLine.DrawLine(this, 0);
            bevelLineList.Add(bevelLine);
        }

        /// <summary>
        /// 删除一条斜线。
        /// </summary>
        public void RemoveBevelLine(BevelLine bevelLine)
        {
            bevelLine.Remove();
            bevelLineList.Remove(bevelLine);
            bevelLine = null;
        }

        /// <summary>
        /// 初始化Fp。
        /// </summary>
        /// <param name="report">报表实体。</param>
        public void Init(Report report)
        {
            this.report = report;
            //获取报表样样式，判定是否可以编辑报表列。对于网格报表这样的样式，是可以编辑列的。对于交叉报表，是不能编辑列的。
            BaseReportStyle reportStyle = this.report.ReportStyle;
            canEditColumn = reportStyle.CanEditColumn();
            Sheets.Clear();
            Sheets.Add(sheetMain);
            InitFP();
        }

        private void ReDrawBevelLine()
        {
            SuspendLayout();
            foreach (BevelLine bevelLine in bevelLineList)
            {
                bevelLine.ReDraw();
            }
            ResumeLayout();
        }

        /// <summary>
        /// 广播Fp发生的改变。例如该方法可以使“唯一存在”的按钮被点击后，通知其他同类按钮。例如H、VAlignment按钮。
        /// </summary>
        public void ManualHeaderSettingCommandStatusChanged()
        {
            if (HeaderSettingCommandStatusChanged != null)
            {
                HeaderSettingCommandStatusChanged(this, this.commandStatus);
            }
        }

        public int Save()
        {
            int reportColumnRowIndex = ReportColumnRowIndex;
            #region 保存行数列数等信息。
            report.MainReportSetting.HeaderSetting.TopSetting.RowCount = TopRowCount;
            report.MainReportSetting.HeaderSetting.BottomSetting.RowCount = BottomRowCount;
            report.MainReportSetting.HeaderSetting.ColumnCount = sheetMain.Columns.Count;
            #endregion
            #region 保存行高信息。
            #region 保存报表列的行高。
            report.MainReportSetting.HeaderSetting.ReportColumnHeight = sheetMain.Rows[reportColumnRowIndex].Height;
            #endregion
            report.MainReportSetting.HeaderSetting.TopSetting.RowHeightList = new List<RowHeight>();
            for (int i = 0; i < reportColumnRowIndex; i++)
            {
                RowHeight rowHeight = new RowHeight();
                rowHeight.Row = i;
                rowHeight.Height = sheetMain.Rows[i].Height;
                report.MainReportSetting.HeaderSetting.TopSetting.RowHeightList.Add(rowHeight); 
            }
            report.MainReportSetting.HeaderSetting.BottomSetting.RowHeightList = new List<RowHeight>();
            for (int i = reportColumnRowIndex+1; i < sheetMain.Rows.Count; i++)
            {
                RowHeight rowHeight = new RowHeight();
                //需要减少报表行序号。
                rowHeight.Row = i - reportColumnRowIndex -1;
                rowHeight.Height = sheetMain.Rows[i].Height;
                report.MainReportSetting.HeaderSetting.BottomSetting.RowHeightList.Add(rowHeight); 
            }
            #endregion
            #region 保存列宽信息。
            report.MainReportSetting.HeaderSetting.ColumnWidthList = new List<ColumnWidth>();
            for (int i = 0; i < sheetMain.Columns.Count; i++)
            {
                ColumnWidth columnWidth = new ColumnWidth();
                columnWidth.Column = i;
                columnWidth.Width = sheetMain.Columns[i].Width;
                report.MainReportSetting.HeaderSetting.ColumnWidthList.Add(columnWidth);
            }
            #endregion
            #region 保存斜线列表。
            report.MainReportSetting.HeaderSetting.TopSetting.BevelLineList = new List<BevelLine>();
            report.MainReportSetting.HeaderSetting.BottomSetting.BevelLineList = new List<BevelLine>();
            //对于在报表列下方的斜线，统一将Row减少报表列的序号。
            foreach (BevelLine bevelLine in bevelLineList)
            {
                //表首斜线列表。
                if (bevelLine.StartCellRow < reportColumnRowIndex)
                {
                    report.MainReportSetting.HeaderSetting.TopSetting.BevelLineList.Add(bevelLine);
                }
                //表尾斜线列表。
                else
                {
                    #region 将斜线的行序号减少报表列序号。
                    BevelLine bevelLineTemp = bevelLine.Clone();
                    bevelLineTemp.StartCellRow -= reportColumnRowIndex+1;
                    bevelLineTemp.EndCellRow -= reportColumnRowIndex+1;
                    #endregion
                    report.MainReportSetting.HeaderSetting.BottomSetting.BevelLineList.Add(bevelLineTemp);
                }
            }
            #endregion
            #region 保存Cell信息。
            report.MainReportSetting.HeaderSetting.TopSetting.CellInfoList = GetVisibleCellInfo(0, reportColumnRowIndex - 1);
            report.MainReportSetting.HeaderSetting.BottomSetting.CellInfoList = GetVisibleCellInfo(reportColumnRowIndex + 1, sheetMain.Rows.Count - 1);
            //将行序号减少报表列序号。
            foreach (CellInfo cellInfo in report.MainReportSetting.HeaderSetting.BottomSetting.CellInfoList)
            {
                cellInfo.Row -= reportColumnRowIndex+1;
            }
            #endregion
            return 1;
        }

        /// <summary>
        /// 获得当前显示出来的、并且有Border信息、Text信息的Cell。被其他SpanCell挡住的Cell不被获得。
        /// </summary>
        /// <param name="startRow">起始行。</param>
        /// <param name="endRow">结束行。</param>
        /// <returns>当前显示出来的、并且有Border信息、Text信息的Cell。</returns>
        private List<CellInfo> GetVisibleCellInfo(int startRow,int endRow)
        {
            //所有当前显示出来的Cell。
            List<FarPoint.Win.Spread.Cell> visibleCellList = new List<FarPoint.Win.Spread.Cell>();
            List<CellInfo> cellInfoList = new List<CellInfo>();
            //循环。
            int columnCount = sheetMain.ColumnCount;
            for (int rowIndex = startRow; rowIndex <= endRow; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    FarPoint.Win.Spread.Cell cell = sheetMain.Cells[rowIndex, columnIndex];
                    FilterCell(visibleCellList, cell);
                }
            }
            //对显示出来的Cell进行二次过滤，将无需保存信息的Cell排除。
            foreach (FarPoint.Win.Spread.Cell cell in visibleCellList)
            {
                if (cell.RowSpan == 1 && cell.ColumnSpan == 1)
                {
                    //如果Cell没有字符且没有Border，则不记录。
                    if (cell.Value == null && cell.Border == null)
                    {
                        continue;
                    }
                    if (cell.Value!=null&&cell.Value.ToString() == string.Empty && cell.Border == null)
                    {
                        continue;
                    }
                }
                CellInfo cellInfo = new CellInfo();
                cellInfo.SetCellInfo(cell);
                cellInfoList.Add(cellInfo);
            }
            return cellInfoList;
        }

        /// <summary>
        /// 过滤Cell。如果cell没有被visibleCellList中的任何一个Cell挡住，则将cell添加进visibleCellList。
        /// </summary>
        /// <param name="visibleCellList">当前显示出来的Cell。</param>
        /// <param name="cell">被过滤的Cell。</param>
        private void FilterCell(List<FarPoint.Win.Spread.Cell> visibleCellList, FarPoint.Win.Spread.Cell cell)
        {
            //将Cell的位置转化为Point。
            Point p = new Point(cell.Column.Index, cell.Row.Index);
            foreach (FarPoint.Win.Spread.Cell c in visibleCellList)
            {
                //将目前已经显示出来的Cell的位置与所占用的面积转化为Rectangle。
                Rectangle r = new Rectangle(c.Column.Index, c.Row.Index, c.ColumnSpan, c.RowSpan);
                //如果Rectangle包含Point，则说明cell已经被挡住了，则return。
                if (r.Contains(p))
                {
                    return;
                }
            }
            //如果可以执行到这里，说明cell没有被visibleCellList中的任何一个Cell挡住，则将cell添加进visibleCellList。
            visibleCellList.Add(cell);
        }

        private void HideReportColumnPropertyEditor()
        {
            if (reportColumnPropertyEditor != null)
            {
                reportColumnPropertyEditor.Hide();
            }
        }

        protected override void OnSelectionChanging(FarPoint.Win.Spread.SelectionChangingEventArgs e)
        {
            if (e.Range.Row < 0 || e.Range.Column < 0)
            {
                return;
            }
            if (e.Range.IntersectRow(ReportColumnRowIndex))
            {
                e.Cancel = true;
                return;
            }
            base.OnSelectionChanging(e);
        }

        protected override void OnSelectionChanged(FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            int reportColumnRowIndex = ReportColumnRowIndex;
            CellRange cellRange = e.Range;
            //清空当前选择的报表列。
            reportColumnSelected = null;

            if (cellRange.IntersectRow(reportColumnRowIndex))
            {
                if (e.Range.Row >= 0 && e.Range.Column >= 0)
                {
                    if (sheetMain.ActiveRowIndex < reportColumnRowIndex)
                    {
                        sheetMain.AddSelection(cellRange.Row, cellRange.Column, cellRange.RowCount - 1, cellRange.ColumnCount);
                        cellRange = new CellRange(cellRange.Row, cellRange.Column, cellRange.RowCount - 1, cellRange.ColumnCount);
                    }
                    else if (sheetMain.ActiveRowIndex > reportColumnRowIndex)
                    {
                        sheetMain.AddSelection(cellRange.Row + 1, cellRange.Column, cellRange.RowCount - 1, cellRange.ColumnCount);
                        cellRange = new CellRange(cellRange.Row + 1, cellRange.Column, cellRange.RowCount - 1, cellRange.ColumnCount);
                    }
                }
            }
            HeaderSettingCommandStatus commandStatus;
            this.cellRange = cellRange;
            if (cellRange.Row < 0)
            {
                commandStatus = HeaderSettingCommandStatus.SelectColumn;
            }
            else if (cellRange.Column < 0)
            {
                commandStatus = HeaderSettingCommandStatus.SelectRow;
            }
            else if (cellRange.Row == reportColumnRowIndex)
            {
                reportColumnSelected = sheetMain.Cells[cellRange.Row, cellRange.Column].Tag as Column;
                if (reportColumnSelected != null)
                {
                    commandStatus = HeaderSettingCommandStatus.SelectReportColumn;
                }
                else
                {
                    commandStatus = HeaderSettingCommandStatus.Null;
                }
            }
            else
            {
                commandStatus = HeaderSettingCommandStatus.SelectCell;
            }

            this.commandStatus = commandStatus;
            ManualHeaderSettingCommandStatusChanged();

            if (this.commandStatus == HeaderSettingCommandStatus.SelectReportColumn)
            {
                if (canEditColumn && reportColumnSelected!=null)
                {
                    if (reportColumnPropertyEditor == null)
                    {
                        reportColumnPropertyEditor = new ReportColumnPropertyEditor();
                        reportColumnPropertyEditor.HeaderSettingFpSpreadChanged += new HeaderSettingFpSpreadChangedHandle(reportColumnPropertyEditor_HeaderSettingFpSpreadChanged);
                        reportColumnPropertyEditor.Init();
                        Form parentForm = WindowManager.GetTopParentForm(this);
                        parentForm.AddOwnedForm(reportColumnPropertyEditor);
                        parentForm.SizeChanged += new EventHandler(parentForm_SizeChanged);
                        parentForm.LocationChanged += new EventHandler(parentForm_LocationChanged);
                    }
                    #region 获得Fp在屏幕上的显示区域。
                    Rectangle screenRectangle = GetScreenRectangle();
                    //与屏幕区域求交集。
                    screenRectangle = Rectangle.Intersect(screenRectangle,Screen.PrimaryScreen.Bounds);
                    #endregion
                    #region 获得Cell在屏幕上的显示区域。
                    Rectangle cellScreenRectangle = GetCellScreenRectangle(cellRange.Row, cellRange.Column);
                    //与Fp区域求交集。
                    cellScreenRectangle = Rectangle.Intersect(cellScreenRectangle,screenRectangle);
                    #endregion
                    #region 去除RowHeader的宽。
                    int rowHeaderWidth = (int)sheetMain.RowHeader.Columns[0].Width;
                    screenRectangle = new Rectangle(screenRectangle.X + rowHeaderWidth, screenRectangle.Y, screenRectangle.Width - rowHeaderWidth, screenRectangle.Height);
                    #endregion
                    Point point = cellScreenRectangle.Location;
                    point.Offset(cellScreenRectangle.Size.Width / 2, cellScreenRectangle.Size.Height);
                    reportColumnPropertyEditor.ShowColumnProperty(reportColumnSelected,screenRectangle, point);
                }
            }
            else
            {
                HideReportColumnPropertyEditor();
            }
            base.OnSelectionChanged(e);
        }

        void reportColumnPropertyEditor_HeaderSettingFpSpreadChanged(object sender, HeaderSettingFpSpreadChangedType changedType)
        {
            FpChanged(changedType);
        }

        void parentForm_SizeChanged(object sender, EventArgs e)
        {
            HideReportColumnPropertyEditor();
        }

        void parentForm_LocationChanged(object sender, EventArgs e)
        {
            HideReportColumnPropertyEditor();
        }

        protected override void OnEditChange(FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            Column column = sheetMain.Cells[e.Row, e.Column].Tag as Column;
            if (column != null)
            {
                if (sheetMain.Cells[e.Row, e.Column].Value != null)
                {
                    column.Name = sheetMain.Cells[e.Row, e.Column].Value.ToString();
                }
                else
                {
                    column.Name = string.Empty;
                }
            }
            base.OnEditChange(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            if (AskForGlobalValueToolStripItem != null)
            {
                AskForGlobalValueToolStripItem(this, globalValueTypeListOfHeader);
            }
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            if (AskForGlobalValueToolStripItem != null)
            {
                AskForGlobalValueToolStripItem(this, nullGlobalValueTypeList);
            }
            if (reportColumnPropertyEditor != null)
            {
                reportColumnPropertyEditor.Hide();
            }
            base.OnLeave(e);
        }

        protected override void OnColumnWidthChanged(FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            FpChanged(HeaderSettingFpSpreadChangedType.ColumnWidthChanged);
            HideReportColumnPropertyEditor();
            base.OnColumnWidthChanged(e);
        }

        protected override void OnRowHeightChanged(FarPoint.Win.Spread.RowHeightChangedEventArgs e)
        {
            FpChanged(HeaderSettingFpSpreadChangedType.RowHeightChanged);
            base.OnRowHeightChanged(e);
        }

        protected override void OnCreateControl()
        {
            Font = new Font("宋体", 9, FontStyle.Regular);
            base.OnCreateControl();
        }

        #region IGlobalValueAsker 成员

        public List<GlobalValueType> GlobalValueTypes
        {
            get
            {
                if (globalValueTypeList == null)
                {
                    globalValueTypeList = new List<GlobalValueType>();
                }
                if (canEditColumn)
                {
                    globalValueTypeList.Add(GlobalValueType.Column);
                }
                return globalValueTypeList;
            }
        }

        public void SetGlobalValue(IGlobalValue globalValue)
        {
            if (globalValue.GlobalValueType == GlobalValueType.Column)
            {
                if (canEditColumn)
                {
                    columnList = new List<Column>();
                    foreach (BaseObject baseObject in globalValue.Value)
                    {
                        columnList.Add(baseObject as Column);
                    }
                    int rowIndex = ReportColumnRowIndex;
                    sheetMain.Rows[rowIndex].Tag = columnList;
                    DrawReportColumnList();
                }
            }
        }

        #endregion

        #region IGlobalValueToolStripItemAsker 成员

        public event AskForGlobalValueToolStripItemHandle AskForGlobalValueToolStripItem;

        public void SetGlobalValue(string globalValue)
        {
            FarPoint.Win.Spread.Cell cell = sheetMain.ActiveCell;
            if (cell != null)
            {
                if (cell.Tag as Column == null)
                {
                    if (IsEditing)
                    {
                        GeneralEditor generalEditor = EditingControl as GeneralEditor;
                        int start = generalEditor.SelectionStart;
                        int length = generalEditor.SelectionLength;
                        if (generalEditor.Text == null)
                        {
                            generalEditor.Text = " ";
                            generalEditor.Text = string.Empty;
                        }
                        generalEditor.Text = generalEditor.Text.Remove(start, length);
                        generalEditor.Text = generalEditor.Text.Insert(start, globalValue);
                        generalEditor.Select(start + globalValue.Length, 0);
                    }
                    else
                    {
                        cell.Value = cell.Text + globalValue;
                    }
                    if (Changed != null)
                    {
                        Changed(this, null);
                    }
                }
            }
        }

        #endregion

        #region IChangedUserControl 成员

        public event EventHandler Changed;

        #endregion

    }

    /// <summary>
    ///  表头设置时的命令状态改变时执行的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="commandStatus">表头设置时的命令状态。</param>
    internal delegate void HeaderSettingCommandStatusChangedHandle(object sender, HeaderSettingCommandStatus commandStatus);

    /// <summary>
    /// Fp发生变化时，所执行的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="changedType">变化种类。</param>
    internal delegate void HeaderSettingFpSpreadChangedHandle(object sender, HeaderSettingFpSpreadChangedType changedType);
}
