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
        /// ��ͷ����ʱ������״̬�ı�ʱ�������¼���
        /// </summary>
        public event HeaderSettingCommandStatusChangedHandle HeaderSettingCommandStatusChanged;
        /// <summary>
        /// FpSpread�����ı�ʱ�������¼���
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
        /// ��Sheet��
        /// </summary>
        public SheetViewForHeaderSetting SheetMain
        {
            get
            {
                return sheetMain;
            }
        }

        /// <summary>
        /// ����������
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
                //��ȡ��ǰ�����������кš�
                int reportColumnRowIndex = ReportColumnRowIndex;
                //��������ڱ����У��򷵻ء�
                if (reportColumnRowIndex == -1)
                {
                    return;
                }
                //�����Ҫ���õı��������뱨�����к���ͬ��˵������Ҫ����������
                if (topRowCount == reportColumnRowIndex)
                {
                    return;
                }
                //�����Ҫ���õı����������ڱ������кţ���ӵ�һ�п�ʼ����������
                else if (topRowCount > reportColumnRowIndex)
                {
                    sheetMain.AddRows(0, topRowCount - reportColumnRowIndex);
                }
                //�����Ҫ���õı�������С�ڱ������кţ���ӵ�һ�п�ʼ����������
                else
                {
                    //��������������ʱ�����ж�б���Ƿ�Ӧ����ʾ��
                    CheckTopBevelLineWhenTopRowCountReduced(0, topRowCount-1);
                    sheetMain.RemoveRows(0, reportColumnRowIndex - topRowCount);
                }
                //��ʾ�кš�
                for (int i = 0; i < topRowCount; i++)
                {
                    sheetMain.Rows[i].Label = (i + 1).ToString();    
                }
                //��յ�ǰѡ��
                ClearSelection();
                //�㲥Fp����������޸ġ�
                FpChanged(HeaderSettingFpSpreadChangedType.TopRowCountChanged);
            }
        }

        /// <summary>
        /// ��β������
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
        /// ������
        /// </summary>
        public int ColumnCount
        {
            get
            {
                return sheetMain.Columns.Count;
            }
            set
            {
                //���С��������Сֵ���򷵻ء�
                if (value < MinColumnCount)
                {
                    return;
                }
                //�����ͬ�����޸ġ�
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
        /// �Ƿ���Ա༭�С�
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
        /// �������������������
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
        /// �����е�����š�
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
        /// Cell����
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
        /// ��ǰѡ�е�ReportColumn��
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
        /// ����״̬��
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
        /// б���б�
        /// </summary>
        public List<BevelLine> GetBevelLines()
        {
            return bevelLineList;
        }

        /// <summary>
        /// ��յ�ǰѡ��
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
        /// ��ʼ��Fp��
        /// </summary>
        private void InitFP()
        {
            //ֹͣ���֡�
            SuspendLayout();

            #region ��ʼ�������С�
            sheetMain.Rows.Count = 1;
            sheetMain.Columns.Count = report.MainReportSetting.HeaderSetting.ColumnCount;
            sheetMain.Rows[0].Tag = report.Columns;
            sheetMain.Rows[0].Label = string.Empty;
            DrawReportColumnList();
            #endregion
            //��ʼ�����ס���β������
            TopRowCount = report.MainReportSetting.HeaderSetting.TopSetting.RowCount;
            BottomRowCount = report.MainReportSetting.HeaderSetting.BottomSetting.RowCount;
            //����Cells��
            DrawCells();
            //�����и����п�
            DrawRowHeightAndColumnWidth();
            //����б�ߡ�
            DrawBevelLine();

            //�ָ����֡�
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
        /// ���Ʊ����С�
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
            #region ����ձ����������С�
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
                //��Ҫ��ӱ�������š�
                sheetMain.Rows[rowHeight.Row + reportColumnRowIndex + 1].Height = rowHeight.Height;
            }
            foreach (ColumnWidth columnWidth in columnWidthList)
            {
                sheetMain.Columns[columnWidth.Column].Width = columnWidth.Width;
            }
            //�����е��иߡ�
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
        /// ����CellInfo������Cell��
        /// </summary>
        /// <param name="cellInfoList">CellInfo�б�</param>
        /// <param name="rowOffSet">��ʼ�С�</param>
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
            #region �������е����������С�
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
        /// ����б���б����б�ߡ�
        /// </summary>
        /// <param name="bevelLineList">б���б�</param>
        private void DrawBevelLine(List<BevelLine> bevelLineList)
        {
            foreach (BevelLine bevelLine in bevelLineList)
            {
                bevelLine.DrawLine(this, 0);
                //�����bevelLineList����ͳһ��������Top����Bottom��
                this.bevelLineList.Add(bevelLine);
            }
        }

        /// <summary>
        /// ��Fp���޸�ʱ����Ҫ�ֶ�ִ�еķ�����
        /// </summary>
        /// <param name="changedType">Fp���ĵ����͡�</param>
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
        /// �ֶ�ִ�У���ʾFp�ѱ��޸ġ�
        /// </summary>
        /// <param name="changedType">�ı����͡�</param>
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
        /// ���һ��б�ߡ�
        /// </summary>
        /// <param name="bevelLine">б�ߡ�</param>
        public void AddBevelLine(BevelLine bevelLine)
        {
            bevelLine.DrawLine(this, 0);
            bevelLineList.Add(bevelLine);
        }

        /// <summary>
        /// ɾ��һ��б�ߡ�
        /// </summary>
        public void RemoveBevelLine(BevelLine bevelLine)
        {
            bevelLine.Remove();
            bevelLineList.Remove(bevelLine);
            bevelLine = null;
        }

        /// <summary>
        /// ��ʼ��Fp��
        /// </summary>
        /// <param name="report">����ʵ�塣</param>
        public void Init(Report report)
        {
            this.report = report;
            //��ȡ��������ʽ���ж��Ƿ���Ա༭�����С��������񱨱���������ʽ���ǿ��Ա༭�еġ����ڽ��汨���ǲ��ܱ༭�еġ�
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
        /// �㲥Fp�����ĸı䡣����÷�������ʹ��Ψһ���ڡ��İ�ť�������֪ͨ����ͬ�ఴť������H��VAlignment��ť��
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
            #region ����������������Ϣ��
            report.MainReportSetting.HeaderSetting.TopSetting.RowCount = TopRowCount;
            report.MainReportSetting.HeaderSetting.BottomSetting.RowCount = BottomRowCount;
            report.MainReportSetting.HeaderSetting.ColumnCount = sheetMain.Columns.Count;
            #endregion
            #region �����и���Ϣ��
            #region ���汨���е��иߡ�
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
                //��Ҫ���ٱ�������š�
                rowHeight.Row = i - reportColumnRowIndex -1;
                rowHeight.Height = sheetMain.Rows[i].Height;
                report.MainReportSetting.HeaderSetting.BottomSetting.RowHeightList.Add(rowHeight); 
            }
            #endregion
            #region �����п���Ϣ��
            report.MainReportSetting.HeaderSetting.ColumnWidthList = new List<ColumnWidth>();
            for (int i = 0; i < sheetMain.Columns.Count; i++)
            {
                ColumnWidth columnWidth = new ColumnWidth();
                columnWidth.Column = i;
                columnWidth.Width = sheetMain.Columns[i].Width;
                report.MainReportSetting.HeaderSetting.ColumnWidthList.Add(columnWidth);
            }
            #endregion
            #region ����б���б�
            report.MainReportSetting.HeaderSetting.TopSetting.BevelLineList = new List<BevelLine>();
            report.MainReportSetting.HeaderSetting.BottomSetting.BevelLineList = new List<BevelLine>();
            //�����ڱ������·���б�ߣ�ͳһ��Row���ٱ����е���š�
            foreach (BevelLine bevelLine in bevelLineList)
            {
                //����б���б�
                if (bevelLine.StartCellRow < reportColumnRowIndex)
                {
                    report.MainReportSetting.HeaderSetting.TopSetting.BevelLineList.Add(bevelLine);
                }
                //��βб���б�
                else
                {
                    #region ��б�ߵ�����ż��ٱ�������š�
                    BevelLine bevelLineTemp = bevelLine.Clone();
                    bevelLineTemp.StartCellRow -= reportColumnRowIndex+1;
                    bevelLineTemp.EndCellRow -= reportColumnRowIndex+1;
                    #endregion
                    report.MainReportSetting.HeaderSetting.BottomSetting.BevelLineList.Add(bevelLineTemp);
                }
            }
            #endregion
            #region ����Cell��Ϣ��
            report.MainReportSetting.HeaderSetting.TopSetting.CellInfoList = GetVisibleCellInfo(0, reportColumnRowIndex - 1);
            report.MainReportSetting.HeaderSetting.BottomSetting.CellInfoList = GetVisibleCellInfo(reportColumnRowIndex + 1, sheetMain.Rows.Count - 1);
            //������ż��ٱ�������š�
            foreach (CellInfo cellInfo in report.MainReportSetting.HeaderSetting.BottomSetting.CellInfoList)
            {
                cellInfo.Row -= reportColumnRowIndex+1;
            }
            #endregion
            return 1;
        }

        /// <summary>
        /// ��õ�ǰ��ʾ�����ġ�������Border��Ϣ��Text��Ϣ��Cell��������SpanCell��ס��Cell������á�
        /// </summary>
        /// <param name="startRow">��ʼ�С�</param>
        /// <param name="endRow">�����С�</param>
        /// <returns>��ǰ��ʾ�����ġ�������Border��Ϣ��Text��Ϣ��Cell��</returns>
        private List<CellInfo> GetVisibleCellInfo(int startRow,int endRow)
        {
            //���е�ǰ��ʾ������Cell��
            List<FarPoint.Win.Spread.Cell> visibleCellList = new List<FarPoint.Win.Spread.Cell>();
            List<CellInfo> cellInfoList = new List<CellInfo>();
            //ѭ����
            int columnCount = sheetMain.ColumnCount;
            for (int rowIndex = startRow; rowIndex <= endRow; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    FarPoint.Win.Spread.Cell cell = sheetMain.Cells[rowIndex, columnIndex];
                    FilterCell(visibleCellList, cell);
                }
            }
            //����ʾ������Cell���ж��ι��ˣ������豣����Ϣ��Cell�ų���
            foreach (FarPoint.Win.Spread.Cell cell in visibleCellList)
            {
                if (cell.RowSpan == 1 && cell.ColumnSpan == 1)
                {
                    //���Cellû���ַ���û��Border���򲻼�¼��
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
        /// ����Cell�����cellû�б�visibleCellList�е��κ�һ��Cell��ס����cell��ӽ�visibleCellList��
        /// </summary>
        /// <param name="visibleCellList">��ǰ��ʾ������Cell��</param>
        /// <param name="cell">�����˵�Cell��</param>
        private void FilterCell(List<FarPoint.Win.Spread.Cell> visibleCellList, FarPoint.Win.Spread.Cell cell)
        {
            //��Cell��λ��ת��ΪPoint��
            Point p = new Point(cell.Column.Index, cell.Row.Index);
            foreach (FarPoint.Win.Spread.Cell c in visibleCellList)
            {
                //��Ŀǰ�Ѿ���ʾ������Cell��λ������ռ�õ����ת��ΪRectangle��
                Rectangle r = new Rectangle(c.Column.Index, c.Row.Index, c.ColumnSpan, c.RowSpan);
                //���Rectangle����Point����˵��cell�Ѿ�����ס�ˣ���return��
                if (r.Contains(p))
                {
                    return;
                }
            }
            //�������ִ�е����˵��cellû�б�visibleCellList�е��κ�һ��Cell��ס����cell��ӽ�visibleCellList��
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
            //��յ�ǰѡ��ı����С�
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
                    #region ���Fp����Ļ�ϵ���ʾ����
                    Rectangle screenRectangle = GetScreenRectangle();
                    //����Ļ�����󽻼���
                    screenRectangle = Rectangle.Intersect(screenRectangle,Screen.PrimaryScreen.Bounds);
                    #endregion
                    #region ���Cell����Ļ�ϵ���ʾ����
                    Rectangle cellScreenRectangle = GetCellScreenRectangle(cellRange.Row, cellRange.Column);
                    //��Fp�����󽻼���
                    cellScreenRectangle = Rectangle.Intersect(cellScreenRectangle,screenRectangle);
                    #endregion
                    #region ȥ��RowHeader�Ŀ�
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
            Font = new Font("����", 9, FontStyle.Regular);
            base.OnCreateControl();
        }

        #region IGlobalValueAsker ��Ա

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

        #region IGlobalValueToolStripItemAsker ��Ա

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

        #region IChangedUserControl ��Ա

        public event EventHandler Changed;

        #endregion

    }

    /// <summary>
    ///  ��ͷ����ʱ������״̬�ı�ʱִ�еķ�����
    /// </summary>
    /// <param name="sender">�¼�Դ��</param>
    /// <param name="commandStatus">��ͷ����ʱ������״̬��</param>
    internal delegate void HeaderSettingCommandStatusChangedHandle(object sender, HeaderSettingCommandStatus commandStatus);

    /// <summary>
    /// Fp�����仯ʱ����ִ�еķ�����
    /// </summary>
    /// <param name="sender">�¼�Դ��</param>
    /// <param name="changedType">�仯���ࡣ</param>
    internal delegate void HeaderSettingFpSpreadChangedHandle(object sender, HeaderSettingFpSpreadChangedType changedType);
}
