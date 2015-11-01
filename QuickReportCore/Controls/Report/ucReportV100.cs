using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections;

namespace QuickReportCore.Controls.Report
{
    internal partial class ucReportV100 : UserControl, Interfaces.IAmReport
    {
        public ucReportV100()
        {
            InitializeComponent();
        }

        private System.Diagnostics.Stopwatch MyWatch = new System.Diagnostics.Stopwatch();
        private QuickReportCore.Objects.QuickReportObject quickReport;
        private XmlDocument xmlDocument = new XmlDocument();
        private XmlDocument xmlDocumentCustomSetting = new XmlDocument();
        private Hashtable htColumnsBase = new Hashtable();
        private Hashtable htConditionsBase = new Hashtable();
        private Hashtable htColumnsCanShows = new Hashtable();
        private Hashtable htConditionsCanShows = new Hashtable();
        private Hashtable htColumnsCustomShows = new Hashtable();
        private Hashtable htConditionsCustomShows = new Hashtable();
        private Hashtable htColumnsCustomUnShows = new Hashtable();
        private Hashtable htConditionsCustomUnShows = new Hashtable();
        private SortedList slColumnsCustomShows = new SortedList();
        private FarPoint.Win.Spread.CellType.TextCellType textCelltype = new FarPoint.Win.Spread.CellType.TextCellType();
        private Class.NumberCellTypePlus numberCellType = new QuickReportCore.Class.NumberCellTypePlus();
        private SortedList slQueryColumns = new SortedList();
        private SortedList groupSums = new SortedList();
        private SortedList groupSumsRowIndexMap = new SortedList();
        private ArrayList columnsNeedColumnSums = new ArrayList();
        private ArrayList columnsNeedRowSums = new ArrayList();
        private List<FarPoint.Win.Spread.Row> groupSumsRowList = new List<FarPoint.Win.Spread.Row>();
        private List<Interfaces.INeedTranslatedValue> iNeedTranslatedValueList = new List<QuickReportCore.Interfaces.INeedTranslatedValue>();
        private List<Interfaces.INeedQuery> iNeedQueryList = new List<QuickReportCore.Interfaces.INeedQuery>();
        private QuickReportCore.Managers.QuickReportManager quickReportManager = new QuickReportCore.Managers.QuickReportManager();
        private QuickReportCore.Objects.Setting.CustomViewSetting customViewSetting = new QuickReportCore.Objects.Setting.CustomViewSetting();
        private QuickReportCore.Objects.Setting.ReportSetting reportSetting = new QuickReportCore.Objects.Setting.ReportSetting();
        private QuickReportCore.Objects.Setting.TreeSetting treeSetting = new QuickReportCore.Objects.Setting.TreeSetting();
        private QuickReportCore.Objects.Setting.DetailSetting detailSetting = new QuickReportCore.Objects.Setting.DetailSetting();
        private QuickReportCore.Objects.Setting.CrossSetting crossSetting = new QuickReportCore.Objects.Setting.CrossSetting();
        private QuickReportCore.Objects.Setting.GridSetting gridSetting = new QuickReportCore.Objects.Setting.GridSetting();
        private QuickReportCore.Objects.Setting.InterfacesSetting interfacesSetting = new QuickReportCore.Objects.Setting.InterfacesSetting();
        private List<QuickReportCore.Objects.Header> headerSettingTop = new List<QuickReportCore.Objects.Header>();
        private List<QuickReportCore.Objects.Header> headerSettingBottom = new List<QuickReportCore.Objects.Header>();
        private List<QuickReportCore.Objects.Header> detailHeaderSettingTop = new List<QuickReportCore.Objects.Header>();
        private List<QuickReportCore.Objects.Header> detailHeaderSettingBottom = new List<QuickReportCore.Objects.Header>();
        private SortedList iNeedDatasList;
        private List<QuickReportCore.PublicInterfaces.ISystemValue> iSystemValueList;
        private FontConverter fc = new FontConverter();
        private FarPoint.Win.LineBorder topHeaderBorder = new FarPoint.Win.LineBorder(System.Drawing.Color.White, 1, true, true, true, false);
        private FarPoint.Win.LineBorder bottomHeaderBorder = new FarPoint.Win.LineBorder(System.Drawing.Color.White, 1, true, false, true, true);
        private FarPoint.Win.LineBorder columnHeaderLeftLineBorderClose = new FarPoint.Win.LineBorder(System.Drawing.Color.Black, 1, true, true, true, true);
        private FarPoint.Win.LineBorder columnHeaderLeftLineBorderOpen = new FarPoint.Win.LineBorder(System.Drawing.Color.Black, 1, false, true, true, true);
        private FarPoint.Win.LineBorder columnHeaderCenterLineBorder = new FarPoint.Win.LineBorder(System.Drawing.Color.Black, 1, false, true, true, true);
        private FarPoint.Win.LineBorder columnHeaderRightLineBorderClose = new FarPoint.Win.LineBorder(System.Drawing.Color.Black, 1, false, true, true, true);
        private FarPoint.Win.LineBorder columnHeaderRightLineBorderOpen = new FarPoint.Win.LineBorder(System.Drawing.Color.Black, 1, false, true, false, true);
        private FarPoint.Win.LineBorder normalColumnLeftLineBorderClose = new FarPoint.Win.LineBorder(System.Drawing.Color.Black, 1, true, false, true, true);
        private FarPoint.Win.LineBorder normalColumnLeftLineBorderOpen = new FarPoint.Win.LineBorder(System.Drawing.Color.Black, 1, false, false, true, true);
        private FarPoint.Win.LineBorder normalColumnCenterBorder = new FarPoint.Win.LineBorder(System.Drawing.Color.Black, 1, false, false, true, true);
        private FarPoint.Win.LineBorder normalColumnRightBorderClose = new FarPoint.Win.LineBorder(System.Drawing.Color.Black, 1, false, false, true, true);
        private FarPoint.Win.LineBorder normalColumnRightBorderOpen = new FarPoint.Win.LineBorder(System.Drawing.Color.Black, 1, false, false, false, true);
        private FarPoint.Win.LineBorder nullBorder = new FarPoint.Win.LineBorder(System.Drawing.Color.Black, 1, false, false, false, false);
        private string compareString = "~!@#$%^&*()_+=-{}|\\][:\"';<>?/.,";
        private string dataSourceSql = string.Empty;
        private Font defaultGroupSumFont = new Font("宋体", 9, FontStyle.Bold);
        private Font defaultColumnHeaderFont = new Font("宋体", 9, FontStyle.Bold);
        private ReportType reportType;
        private DataView dvReport;
        private DataView dvReportDetail;
        private int reportDataRowNumber = 0;
        private int reportDataColumnNumer = 0;
        private long queryTimeUsed = 0;
        private bool isLoaded = false;
        private FarPoint.Win.Spread.CellType.NumberCellType rowSumNumberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();

        private FarPoint.Win.LineBorder NormalColumnRightBorder
        {
            get
            {
                if (reportSetting.UseViewOpen)
                    return normalColumnRightBorderOpen;
                else
                    return normalColumnRightBorderClose;
            }
        }

        private FarPoint.Win.LineBorder NormalColumnLeftLineBorder
        {
            get
            {
                if (reportSetting.UseViewOpen)
                    return normalColumnLeftLineBorderOpen;
                else
                    return normalColumnLeftLineBorderClose;
            }
        }

        private FarPoint.Win.LineBorder ColumnHeaderRightLineBorder
        {
            get
            {
                if (reportSetting.UseViewOpen)
                    return columnHeaderRightLineBorderOpen;
                else
                    return columnHeaderRightLineBorderClose;
            }
        }

        private FarPoint.Win.LineBorder ColumnHeaderLeftLineBorder
        {
            get
            {
                if (reportSetting.UseViewOpen)
                    return columnHeaderLeftLineBorderOpen;
                else
                    return columnHeaderLeftLineBorderClose;
            }
        }

        private string err = string.Empty;
        public string Err
        {
            get
            {
                return err;
            }
            set
            {
                err = value;
            }
        }

        public void LoadReport(QuickReportCore.Objects.QuickReportObject qr)
        {
            quickReport = qr;
            Init();
        }

        private void Init()
        {
            InitCustomSetting();
            InitSettingFromXml();
            InitInterfaces();
            #region 初始化BaseColumn与BaseCondition。
            InitBaseColumn();
            InitBaseCondition();
            #endregion
            #region 初始化CanShow的列。网格报表与交叉报表在列方面有很大不同，所以需要分开处理。
            if (reportType != ReportType.Grid)
                InitCrossReportColumnCanShow();
            else
                InitGridReportColumnCanShow();
            #endregion
            #region 初始化CanShow的条件。这里对于网格报表和交叉报表不需要分开处理。
            InitReportConditionCanShow();
            #endregion
            #region 对比CanShow的列与条件与客户自定义的列与条件。
            CompareCustomAndCanShowsColumn();
            CompareCustomAndCanShowsCondition();
            #endregion
            #region 对列与条件排序。
            SortCustomColumn();
            SortCustomCondition();
            #endregion
            InitConditions();
            InitTree();
            isLoaded = true;
        }

        /// <summary>
        /// 初始化主Xml的各种设置。
        /// </summary>
        private void InitSettingFromXml()
        {
            if (quickReport.Content.Trim() == string.Empty)
                return;
            xmlDocument.LoadXml(Managers.EncryptionManager.Decrypt(quickReport.Content));
            #region reportSetting
            System.Xml.XmlNode nodeSetting = xmlDocument.SelectSingleNode("//" + Forms.frmQuickReportEditor.XmlAttrDicViewSetting.ViewSetting.ToString());
            if (nodeSetting != null)
            {
                reportSetting.UseTree = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSetting.bUseTree.ToString(), "0")));
                reportSetting.UseDetail = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSetting.bUseDetail.ToString(), "0")));
                reportSetting.UseLoadAndQuery = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSetting.bLoadAndQuery.ToString(), "0")));
                reportSetting.UseAutoColumnWidth = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSetting.bAutoColumnWidth.ToString(), "0")));
                reportSetting.UseViewOpen = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSetting.bViewOpen.ToString(), "0")));
                reportSetting.UseEvenColor = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSetting.bUseEvenColor.ToString(), "0")));
                reportSetting.CrossReport = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSetting.bCrossView.ToString(), "0")));
                reportSetting.GridReport = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSetting.bGridView.ToString(), "0")));
                reportSetting.EvenColor = System.Drawing.ColorTranslator.FromHtml(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSetting.tEvenColor.ToString(), string.Empty));
                nodeSetting = xmlDocument.SelectSingleNode("//" + Forms.frmQuickReportEditor.XmlAttrDic.ReportBaseInfo.ToString());
                reportSetting.SQL = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDic.tReportSql.ToString(), string.Empty);
            }           
            #endregion

            #region headerSettingTop
            headerSettingTop = new List<QuickReportCore.Objects.Header>(); ;
            XmlNodeList xmlNodeList = xmlDocument.SelectSingleNode("//" + Forms.frmQuickReportEditor.XmlAttrDicViewSettingReport.HeaderTopSetting.ToString()).SelectSingleNode(QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.HeaderObjectList.ToString()).SelectNodes(QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.HeaderObject.ToString());
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                QuickReportCore.Objects.Header header = new QuickReportCore.Objects.Header();
                header.RowIndex = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tRowIndex.ToString(), "0"));
                header.Text = Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tText.ToString(), string.Empty);
                header.Font = fc.ConvertFromInvariantString(Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tFont.ToString(), string.Empty)) as Font;
                header.HAligment = (FarPoint.Win.Spread.CellHorizontalAlignment)Enum.Parse(typeof(FarPoint.Win.Spread.CellHorizontalAlignment), Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tHAligment.ToString(), FarPoint.Win.Spread.CellHorizontalAlignment.General.ToString()));
                header.VAligment = (FarPoint.Win.Spread.CellVerticalAlignment)Enum.Parse(typeof(FarPoint.Win.Spread.CellVerticalAlignment), Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tVAligment.ToString(), FarPoint.Win.Spread.CellVerticalAlignment.General.ToString()));
                header.Height = Convert.ToInt64(Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tHeight.ToString(), "25"));
                header.Color = System.Drawing.ColorTranslator.FromHtml(Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tColor.ToString(), string.Empty));
                headerSettingTop.Add(header);
            }
            #endregion

            #region headerSettingBottom
            headerSettingBottom = new List<QuickReportCore.Objects.Header>();
            xmlNodeList = xmlDocument.SelectSingleNode("//" + Forms.frmQuickReportEditor.XmlAttrDicViewSettingReport.HeaderBottomSetting.ToString()).SelectSingleNode(QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.HeaderObjectList.ToString()).SelectNodes(QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.HeaderObject.ToString());
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                QuickReportCore.Objects.Header header = new QuickReportCore.Objects.Header();
                header.RowIndex = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tRowIndex.ToString(), "0"));
                header.Text = Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tText.ToString(), string.Empty);
                header.Font = fc.ConvertFromInvariantString(Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tFont.ToString(), string.Empty)) as Font;
                header.HAligment = (FarPoint.Win.Spread.CellHorizontalAlignment)Enum.Parse(typeof(FarPoint.Win.Spread.CellHorizontalAlignment), Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tHAligment.ToString(), FarPoint.Win.Spread.CellHorizontalAlignment.General.ToString()));
                header.VAligment = (FarPoint.Win.Spread.CellVerticalAlignment)Enum.Parse(typeof(FarPoint.Win.Spread.CellVerticalAlignment), Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tVAligment.ToString(), FarPoint.Win.Spread.CellVerticalAlignment.General.ToString()));
                header.Height = Convert.ToInt64(Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tHeight.ToString(), "25"));
                header.Color = System.Drawing.ColorTranslator.FromHtml(Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tColor.ToString(), string.Empty));
                headerSettingBottom.Add(header);
            }
            #endregion

            #region detailHeaderSettingTop
            detailHeaderSettingTop = new List<QuickReportCore.Objects.Header>(); ;
            xmlNodeList = xmlDocument.SelectSingleNode("//" + Forms.frmQuickReportEditor.XmlAttrDicViewSettingReport.DetailHeaderTopSetting.ToString()).SelectSingleNode(QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.HeaderObjectList.ToString()).SelectNodes(QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.HeaderObject.ToString());
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                QuickReportCore.Objects.Header header = new QuickReportCore.Objects.Header();
                header.RowIndex = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tRowIndex.ToString(), "0"));
                header.Text = Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tText.ToString(), string.Empty);
                header.Font = fc.ConvertFromInvariantString(Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tFont.ToString(), string.Empty)) as Font;
                header.HAligment = (FarPoint.Win.Spread.CellHorizontalAlignment)Enum.Parse(typeof(FarPoint.Win.Spread.CellHorizontalAlignment), Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tHAligment.ToString(), FarPoint.Win.Spread.CellHorizontalAlignment.General.ToString()));
                header.VAligment = (FarPoint.Win.Spread.CellVerticalAlignment)Enum.Parse(typeof(FarPoint.Win.Spread.CellVerticalAlignment), Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tVAligment.ToString(), FarPoint.Win.Spread.CellVerticalAlignment.General.ToString()));
                header.Height = Convert.ToInt64(Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tHeight.ToString(), "25"));
                header.Color = System.Drawing.ColorTranslator.FromHtml(Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tColor.ToString(), string.Empty));
                detailHeaderSettingTop.Add(header);
            }
            #endregion

            #region detailHeaderSettingBottom
            detailHeaderSettingBottom = new List<QuickReportCore.Objects.Header>();
            xmlNodeList = xmlDocument.SelectSingleNode("//" + Forms.frmQuickReportEditor.XmlAttrDicViewSettingReport.DetailHeaderBottomSetting.ToString()).SelectSingleNode(QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.HeaderObjectList.ToString()).SelectNodes(QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.HeaderObject.ToString());
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                QuickReportCore.Objects.Header header = new QuickReportCore.Objects.Header();
                header.RowIndex = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tRowIndex.ToString(), "0"));
                header.Text = Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tText.ToString(), string.Empty);
                header.Font = fc.ConvertFromInvariantString(Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tFont.ToString(), string.Empty)) as Font;
                header.HAligment = (FarPoint.Win.Spread.CellHorizontalAlignment)Enum.Parse(typeof(FarPoint.Win.Spread.CellHorizontalAlignment), Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tHAligment.ToString(), FarPoint.Win.Spread.CellHorizontalAlignment.General.ToString()));
                header.VAligment = (FarPoint.Win.Spread.CellVerticalAlignment)Enum.Parse(typeof(FarPoint.Win.Spread.CellVerticalAlignment), Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tVAligment.ToString(), FarPoint.Win.Spread.CellVerticalAlignment.General.ToString()));
                header.Height = Convert.ToInt64(Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tHeight.ToString(), "25"));
                header.Color = System.Drawing.ColorTranslator.FromHtml(Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.tColor.ToString(), string.Empty));
                detailHeaderSettingBottom.Add(header);
            }
            #endregion

            #region treeSetting
            nodeSetting = xmlDocument.SelectSingleNode("//" + Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.TreeSetting.ToString());
            if (nodeSetting != null)
            {
                treeSetting.SQL = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.tTreeSql.ToString(), string.Empty);
                treeSetting.Code = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.tTreeCode.ToString(), string.Empty);
                treeSetting.Name = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.tTreeName.ToString(), string.Empty);
                treeSetting.GroupCode = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.tTreeGroupCode.ToString(), string.Empty);
                treeSetting.GroupName = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.tTreeGroupName.ToString(), string.Empty);
                treeSetting.TreeRootCode = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.tTreeRootCode.ToString(), string.Empty);
                treeSetting.TreeRootName = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.tTreeRootName.ToString(), string.Empty);
                treeSetting.TreeExpanded = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.bDefaultCollpased.ToString(), "0")));
                treeSetting.TreeMultiSelect = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.bTreeMultiSelect.ToString(), "0")));
                treeSetting.GroupFont = fc.ConvertFromInvariantString(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.tTreeGroupFont.ToString(), string.Empty)) as Font;
                treeSetting.RootFont = fc.ConvertFromInvariantString(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.tTreeRootFont.ToString(), string.Empty)) as Font;
                treeSetting.NameFont = fc.ConvertFromInvariantString(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.tTreeNameFont.ToString(), string.Empty)) as Font;
                treeSetting.GroupColor = System.Drawing.ColorTranslator.FromHtml(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.tTreeGroupColor.ToString(), string.Empty));
                treeSetting.RootColor = System.Drawing.ColorTranslator.FromHtml(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.tTreeRootColor.ToString(), string.Empty));
                treeSetting.NameColor = System.Drawing.ColorTranslator.FromHtml(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.tTreeNameColor.ToString(), string.Empty));
                treeSetting.GroupIcon = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.tTreeGroupIcon.ToString(), "0"));
                treeSetting.RootIcon = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.tTreeRootIcon.ToString(), "0"));
                treeSetting.NameIcon = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.tTreeNameIcon.ToString(), "0"));
                treeSetting.ActionType = (Forms.frmQuickReportEditor.QueryActionType)Enum.Parse(typeof(Forms.frmQuickReportEditor.QueryActionType), Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingTree.tTreeSelectAction.ToString(), Forms.frmQuickReportEditor.QueryActionType.单击激活查询.ToString()));
            }
            #endregion

            #region detailSetting
            nodeSetting = xmlDocument.SelectSingleNode("//" + Forms.frmQuickReportEditor.XmlAttrDicViewSettingDetail.DetailSetting.ToString());
            if (nodeSetting != null)
            {
                detailSetting.SQL = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingDetail.tDetailSql.ToString(), string.Empty);
                detailSetting.ActionType = (Forms.frmQuickReportEditor.QueryActionType)Enum.Parse(typeof(Forms.frmQuickReportEditor.QueryActionType), Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmQuickReportEditor.XmlAttrDicViewSettingDetail.tDetailAction.ToString(), Forms.frmQuickReportEditor.QueryActionType.单击激活查询.ToString()));
            }
            #endregion

            #region crossSetting
            if (reportSetting.CrossReport)
            {
                nodeSetting = xmlDocument.SelectSingleNode("//" + Forms.frmToolBoxCrossSetting.XmlAttrDic.ViewSettingCrossSetting.ToString());
                if (nodeSetting != null)
                {
                    crossSetting.Row = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.tRow.ToString(), string.Empty);
                    crossSetting.Column = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.tColumn.ToString(), string.Empty);
                    crossSetting.Value = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.tValue.ToString(), string.Empty);
                    crossSetting.GroupSumRow = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.tGroupSumRow.ToString(), string.Empty);
                    crossSetting.GroupSumColumn = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.tGroupSumColumn.ToString(), string.Empty);
                    crossSetting.UseCustomColumn = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.bCustomColumn.ToString(), "0")));
                    crossSetting.UseCustomRow = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.bCustomRow.ToString(), "0")));
                    crossSetting.ColumnSQL = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.tCustomColumnSQL.ToString(), string.Empty);
                    crossSetting.RowSQL = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.tCustomRowSQL.ToString(), string.Empty);
                    crossSetting.CustomColumnName = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.tCustomColumnName.ToString(), string.Empty);
                    crossSetting.GroupSumCustomColumn = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.tGroupSumCustomColumn.ToString(), string.Empty);
                    crossSetting.CustomRowName = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.tCustomRowName.ToString(), string.Empty);
                    crossSetting.GroupSumCustomRow = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.tGroupSumCustomRow.ToString(), string.Empty);
                    crossSetting.GroupSumColumnName = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.tGroupSumColumnName.ToString(), string.Empty);
                    crossSetting.GroupSumRowName = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.tGroupSumRowName.ToString(), string.Empty);
                    crossSetting.CustomColumnGroupSumName = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.tCustomColumnGroupSumName.ToString(), string.Empty);
                    crossSetting.RowSum = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.bRowSum.ToString(), "0")));
                    crossSetting.ColumnSum = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.bColumnSum.ToString(), "0")));
                    crossSetting.UseGroupSumRow = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.bUseGroupSumRow.ToString(), "0")));
                    crossSetting.UseHeader = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.bUseHeader.ToString(), "0")));
                    crossSetting.Union = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxCrossSetting.XmlAttrDic.bUnion.ToString(), "0")));
                }
             }           
           #endregion

            #region gridSetting
            if (reportSetting.GridReport)
            {
                nodeSetting = xmlDocument.SelectSingleNode("//" + Forms.frmToolBoxGridSetting.XmlAttrDic.ViewSettingGridSetting.ToString());
                if (nodeSetting != null)
                {
                    gridSetting.GroupSumRow = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxGridSetting.XmlAttrDic.tGroupRow.ToString(), string.Empty);
                    gridSetting.RowGroupSumName = Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxGridSetting.XmlAttrDic.tRowGroupSumName.ToString(), string.Empty);
                    gridSetting.UseGroupSumRow = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxGridSetting.XmlAttrDic.bUseGroupSumRow.ToString(), "0")));
                    gridSetting.UseHeader = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxGridSetting.XmlAttrDic.bUseHeader.ToString(), "0")));
                    gridSetting.Union = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(nodeSetting, Forms.frmToolBoxGridSetting.XmlAttrDic.bUnion.ToString(), "0")));
                }
            }
            #endregion

            #region interfacesSetting
            nodeSetting = xmlDocument.SelectSingleNode("//" + QuickReportCore.Controls.InterfaceList.ucINeedDatasList.XmlAttrDic.INeedDatasList.ToString());
            List<Objects.Interface> interfaceList = new List<QuickReportCore.Objects.Interface>();
            if (nodeSetting != null)
            {
                xmlNodeList = nodeSetting.SelectNodes(QuickReportCore.Controls.InterfaceList.ucINeedDatasList.XmlAttrDic.INeedDatasObject.ToString());
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    Objects.Interface customInterface = new QuickReportCore.Objects.Interface();
                    customInterface.InterfaceName = Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.InterfaceList.ucINeedDatasList.XmlAttrDic.tInterfaceName.ToString(), string.Empty);
                    customInterface.DllName = Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.InterfaceList.ucINeedDatasList.XmlAttrDic.tDllName.ToString(), string.Empty);
                    customInterface.ClassName = Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.InterfaceList.ucINeedDatasList.XmlAttrDic.tClassName.ToString(), string.Empty);
                    customInterface.Values = Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.InterfaceList.ucINeedDatasList.XmlAttrDic.tValues.ToString(), string.Empty);
                    customInterface.SortID = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.InterfaceList.ucINeedDatasList.XmlAttrDic.tSortID.ToString(), "0"));
                    interfaceList.Add(customInterface);
                }
            }
            nodeSetting = xmlDocument.SelectSingleNode("//" + QuickReportCore.Controls.InterfaceList.ucISystemValueList.XmlAttrDic.ISystemValueList.ToString());
            if (nodeSetting != null)
            {
                xmlNodeList = nodeSetting.SelectNodes(QuickReportCore.Controls.InterfaceList.ucISystemValueList.XmlAttrDic.ISystemValueObject.ToString());
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    Objects.Interface customInterface = new QuickReportCore.Objects.Interface();
                    customInterface.InterfaceName = Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.InterfaceList.ucISystemValueList.XmlAttrDic.tInterfaceName.ToString(), string.Empty);
                    customInterface.DllName = Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.InterfaceList.ucISystemValueList.XmlAttrDic.tDllName.ToString(), string.Empty);
                    customInterface.ClassName = Managers.Functions.GetNodeAttrValue(xmlNodeList[i], QuickReportCore.Controls.InterfaceList.ucISystemValueList.XmlAttrDic.tClassName.ToString(), string.Empty);
                    interfaceList.Add(customInterface);
                }
                interfacesSetting.InterfaceList = interfaceList;
                interfacesSetting.INeedDatasActionType = (QuickReportCore.Controls.ucReportInterfaceOtherSetting.INeedDatasActionType)Enum.Parse(typeof(QuickReportCore.Controls.ucReportInterfaceOtherSetting.INeedDatasActionType), Managers.Functions.GetNodeAttrValue(nodeSetting, QuickReportCore.Controls.ucReportInterfaceOtherSetting.XmlAttrDic.tINeedDatasActionType.ToString(), QuickReportCore.Controls.ucReportInterfaceOtherSetting.INeedDatasActionType.双击激活接口.ToString()));
            }
            #endregion

            if (reportSetting.GridReport)
                reportType = ReportType.Grid;
            else if (reportSetting.CrossReport && !crossSetting.UseCustomColumn && !crossSetting.UseCustomRow)
                reportType = ReportType.GeneralCross;
            else
                reportType = ReportType.CustomCross;
        }

        /// <summary>
        /// 初始化接口。
        /// </summary>
        private void InitInterfaces()
        {
            if (interfacesSetting.InterfaceList.Count == 0)
                return;
            iSystemValueList = new List<QuickReportCore.PublicInterfaces.ISystemValue>();
            iNeedDatasList = new SortedList();
            foreach (Objects.Interface i in interfacesSetting.InterfaceList)
            {
                if (i.InterfaceName == typeof(PublicInterfaces.INeedDatas).Name)
                {
                    PublicInterfaces.INeedDatas iNeedDatas = i.Instance as PublicInterfaces.INeedDatas;
                    if (iNeedDatas != null)
                    {
                        iNeedDatasList.Add(i, iNeedDatas);
                        iNeedDatas.Done += new QuickReportCore.PublicInterfaces.DoneHandle(iNeedDatas_Done);
                    }
                }
                else if (i.InterfaceName == typeof(PublicInterfaces.ISystemValue).Name)
                {
                    PublicInterfaces.ISystemValue iSystemValue = i.Instance as PublicInterfaces.ISystemValue;
                    if (iSystemValue != null)
                        iSystemValueList.Add(iSystemValue);
                }
            }
            if (iSystemValueList.Count > 0)//向全局系统变量注册。
            {
                foreach (PublicInterfaces.ISystemValue iSystemValue in iSystemValueList)
                {
                    Forms.frmToolBoxSystemValue.AddSystemValueToStaticSystemValueList(iSystemValue);
                }
            }
        }

        void iNeedDatas_Done(QuickReportCore.PublicInterfaces.DoneAction doneAction)
        {
            switch (doneAction)
            {
                case QuickReportCore.PublicInterfaces.DoneAction.None:
                    {
                        return;
                    }
                case QuickReportCore.PublicInterfaces.DoneAction.Query:
                    {
                        Query();
                        break;
                    }
                case QuickReportCore.PublicInterfaces.DoneAction.DeleteSelectedRow:
                    {
                        if (fpMain_Sheet1.ActiveCell == null)
                            return;
                        fpMain_Sheet1.RemoveRows(fpMain_Sheet1.ActiveRowIndex, 1);
                        break;
                    }
                case QuickReportCore.PublicInterfaces.DoneAction.ClearReport:
                    {
                        ClearReportFarpoint();
                        InitFp();
                        break;
                    }
            }
        }

        /// <summary>
        /// 初始化BaseColumn。
        /// </summary>
        private void InitBaseColumn()
        {
            htColumnsBase = new Hashtable();
            System.Xml.XmlNodeList nodeList = xmlDocument.SelectNodes("//" + ucColumnObject.XmlAttrDic.ColumnObject.ToString());
            foreach (System.Xml.XmlNode node in nodeList)
            {
                Objects.Column column = new QuickReportCore.Objects.Column();
                column.ID = Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.tID.ToString(), string.Empty);
                column.Name = Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.tName.ToString(), string.Empty);
                column.Filter = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.bFilter.ToString(), "0")));
                column.Use = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.bUse.ToString(), "0")));
                column.Sort = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.bSort.ToString(), "0")));
                column.TotalColumn = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.bTotalColumn.ToString(), "0")));
                column.TotalRow = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.bTotalRow.ToString(), "0")));
                column.SortId = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.tSortID.ToString(), "0"));
                column.IsNumber = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.bIsNumber.ToString(), "0")));
                column.DecimalPlace = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.tDecimalPlace.ToString(), "0"));
                column.Font = fc.ConvertFromInvariantString(Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.tFont.ToString(), string.Empty)) as Font;
                column.Color = System.Drawing.ColorTranslator.FromHtml(Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.tColor.ToString(), string.Empty));
                column.HAligment = (FarPoint.Win.Spread.CellHorizontalAlignment)Enum.Parse(typeof(FarPoint.Win.Spread.CellHorizontalAlignment), Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.tHAligment.ToString(), FarPoint.Win.Spread.CellHorizontalAlignment.General.ToString()));
                column.VAligment = (FarPoint.Win.Spread.CellVerticalAlignment)Enum.Parse(typeof(FarPoint.Win.Spread.CellVerticalAlignment), Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.tVAligment.ToString(), FarPoint.Win.Spread.CellVerticalAlignment.General.ToString()));
                column.Union = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.bUnion.ToString(), "0")));
                column.ValueTransType = (QuickReportCore.Class.NumberCellTypePlus.ValueTranslateType)Enum.Parse(typeof(QuickReportCore.Class.NumberCellTypePlus.ValueTranslateType), Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.tValueTranslateType.ToString(), QuickReportCore.Class.NumberCellTypePlus.ValueTranslateType.不转换.ToString()));
                htColumnsBase.Add(column.ID, column);
            }
        }

        /// <summary>
        /// 初始化BaseCondition。
        /// </summary>
        private void InitBaseCondition()
        {
            htConditionsBase = new Hashtable();
            System.Xml.XmlNodeList nl = xmlDocument.SelectNodes("//" + ucConditionObject.XmlAttrDic.ConditionObject.ToString());
            foreach (System.Xml.XmlNode node in nl)
            {
                Objects.Condition condition = new QuickReportCore.Objects.Condition();
                condition.ID = Managers.Functions.GetNodeAttrValue(node, ucConditionObject.XmlAttrDic.tID.ToString(), string.Empty);
                condition.Name = Managers.Functions.GetNodeAttrValue(node, ucConditionObject.XmlAttrDic.tName.ToString(), string.Empty);
                condition.ConditionType.ID = Managers.Functions.GetNodeAttrValue(node, ucConditionObject.XmlAttrDic.tConditionTypeID.ToString(), string.Empty);
                condition.ConditionType.Name = Managers.Functions.GetNodeAttrValue(node, ucConditionObject.XmlAttrDic.tConditionTypeName.ToString(), string.Empty);
                condition.ConditionType.Content = node.SelectSingleNode(Forms.frmToolBoxConditionTypeEditor.XmlAttrDic.ConditionTypeContent.ToString()) as System.Xml.XmlElement;
                condition.DefaultShow = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucConditionObject.XmlAttrDic.bDefaultShow.ToString(), "0")));
                condition.Use = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucConditionObject.XmlAttrDic.bUse.ToString(), "0")));
                condition.NotNull = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucConditionObject.XmlAttrDic.bNotNull.ToString(), "0")));
                condition.SortId = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucConditionObject.XmlAttrDic.tSortID.ToString(), "0"));
                condition.ConditionSetting = node.SelectSingleNode(ucConditionObject.XmlAttrDic.ConditionSetting.ToString()) as XmlElement;
                htConditionsBase.Add(condition.ID, condition);
            }
        }

        /// <summary>
        /// 初始化CanShow的条件。
        /// </summary>
        private void InitReportConditionCanShow()
        {
            htConditionsCanShows = new Hashtable();
            foreach (DictionaryEntry de in htConditionsBase)
            {
                Objects.Condition condition = de.Value as Objects.Condition;
                if (condition.Use && condition.ConditionType.ID.Trim() != string.Empty)
                    htConditionsCanShows.Add(condition.ID, condition.Clone());
            }
        }

        /// <summary>
        /// 初始化网格报表可以显示的列。
        /// </summary>
        private void InitGridReportColumnCanShow()
        {
            htColumnsCanShows = new Hashtable();
            foreach (DictionaryEntry de in htColumnsBase)
            {
                Objects.Column column = de.Value as Objects.Column;
                if (column.Use)
                    htColumnsCanShows.Add(column.ID, column.Clone());
            }
        }

        /// <summary>
        /// 初始化交叉报表（两种）可以显示的列。
        /// </summary>
        private void InitCrossReportColumnCanShow()
        {
            if (reportType == ReportType.GeneralCross)
            {
                InitGeneralCrossReportColumnCanShow();
            }
            else if (reportType == ReportType.CustomCross)
            {
                InitCustomCrossReportColumnCanShow();
            }
        }

        /// <summary>
        /// 初始化普通交叉报表可以显示的列。
        /// </summary>
        private void InitGeneralCrossReportColumnCanShow()
        {
            //普通交叉报表无法让用户自定义列（每次查询出的结果都不相同，自定义列无意义），所以直接将这三项清空。
            htColumnsCanShows = new Hashtable();
            htColumnsCustomShows = new Hashtable();
            htColumnsCustomUnShows = new Hashtable();
        }

        /// <summary>
        /// 初始化自定义的交叉报表可以显示的列。
        /// </summary>
        private void InitCustomCrossReportColumnCanShow()
        {
            if (crossSetting.UseCustomColumn)
            {
                //清空CanShow，因为自定义列是从SQL中获取的。
                htColumnsCanShows = new Hashtable();
                #region 需要被翻译的种类。
                Managers.Functions.SQLCodeType[] types = new QuickReportCore.Managers.Functions.SQLCodeType[1];
                types[0] = QuickReportCore.Managers.Functions.SQLCodeType.System;
                #endregion
                string sql = TranslateValue(crossSetting.ColumnSQL, types);
                if (crossSetting.GroupSumCustomColumn != string.Empty)
                {
                    sql = "Select Distinct " + crossSetting.CustomColumnName + " , " + crossSetting.GroupSumCustomColumn + " From ( \n " + sql + " \n )";
                    quickReportManager.ExecQuery(sql);
                    int count = 0;
                    try
                    {
                        while (quickReportManager.Reader.Read())
                        {
                            Objects.Column c = new QuickReportCore.Objects.Column();
                            c.ID = c.Name = quickReportManager.Reader[0].ToString();
                            c.GroupName = quickReportManager.Reader[1].ToString();
                            c.SortId = count;
                            if (htColumnsCanShows.Contains(c.ID))
                                continue;
                            htColumnsCanShows.Add(c.ID, c);
                            count++;
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception("加载交叉报表列失败。" + e.Message);
                    }
                    finally
                    {
                        quickReportManager.Reader.Close();
                    }
                }
                else
                {
                    sql = "Select Distinct " + crossSetting.CustomColumnName + " From ( \n " + sql + " \n )";
                    quickReportManager.ExecQuery(sql);
                    int count = 0;
                    try
                    {
                        while (quickReportManager.Reader.Read())
                        {
                            Objects.Column c = new QuickReportCore.Objects.Column();
                            c.ID = c.Name = quickReportManager.Reader[0].ToString();
                            c.SortId = count;
                            htColumnsCanShows.Add(c.ID, c);
                            count++;
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception("加载交叉报表列失败。" + e.Message);
                    }
                    finally
                    {
                        quickReportManager.Reader.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 设置此次报表主SQL。需要在CustomColumnShows排序后执行。
        /// </summary>
        private void SetQueryColumns()
        {
            if (reportType == ReportType.Grid)
            {
                Hashtable htQueryColumns = htColumnsCustomShows.Clone() as Hashtable;
                slQueryColumns = new SortedList();
                int count = 0;
                foreach (DictionaryEntry de in htColumnsBase)
                {
                    if (!htQueryColumns.Contains(de.Key))
                    {
                        Objects.Column c = (de.Value as Objects.Column).Clone();
                        c.SortId = htColumnsCustomShows.Count + count;
                        htQueryColumns.Add(de.Key, c);
                        count++;
                    }
                }
                foreach (DictionaryEntry de in htQueryColumns)
                {
                    slQueryColumns.Add(de.Value, de.Key);
                }
                string sqlBase = reportSetting.SQL;
                string columns = string.Empty;
                count = 0;
                foreach (DictionaryEntry de in slQueryColumns)
                {
                    Objects.Column column = de.Key as Objects.Column;
                    if (count == slQueryColumns.Count - 1)
                        columns += column.ID + " ";
                    else
                        columns += column.ID + " , ";
                    count++;
                    #region 设置htColumnsBase的SortID
                    Objects.Column columnBase = htColumnsBase[de.Value] as Objects.Column;
                    columnBase.SortId = column.SortId;
                    #endregion
                }
                sqlBase = "Select " + columns + " From ( \n " + sqlBase + " \n ) ";
                dataSourceSql = sqlBase;
            }
            else if (reportType == ReportType.GeneralCross)
            {

            }
        }

        /// <summary>
        /// 对比客户自定义的列与最新解析出来的列。
        /// </summary>
        private void CompareCustomAndCanShowsColumn()
        {
            #region 增加CanShows里有但Custom中没有的
            if (doNotHaveASetting)//如果当前没有设置，则直接将CanShows赋值给Custom。
            {
                htColumnsCustomShows = htColumnsCanShows;
            }
            else
            {
                foreach (DictionaryEntry de in htColumnsCanShows)
                {
                    if (htColumnsCustomShows.Contains(de.Key) || htColumnsCustomUnShows.Contains(de.Key))
                    {
                        if (htColumnsCustomShows.Contains(de.Key))
                        {
                            Objects.Column c = de.Value as Objects.Column;
                            Objects.Column cCustom = htColumnsCustomShows[de.Key] as Objects.Column;
                            c.Width = cCustom.Width;
                            c.SortId = cCustom.SortId;
                            htColumnsCustomShows[de.Key] = c;
                        }
                        if (htColumnsCustomUnShows.Contains(de.Key))
                        {
                            Objects.Column c = de.Value as Objects.Column;
                            Objects.Column cCustom = htColumnsCustomUnShows[de.Key] as Objects.Column;
                            c.Width = cCustom.Width;
                            c.SortId = cCustom.SortId;
                            htColumnsCustomUnShows[de.Key] = c;
                        }
                        continue;
                    }
                    else
                    {
                        Objects.Column c = de.Value as Objects.Column;
                        c.SortId = htColumnsCustomShows.Count;
                        htColumnsCustomShows.Add(c.ID, c);
                    }
                }
            }
            #endregion

            #region 删除CanShows里没有的。
            ArrayList deleteList = new ArrayList();
            foreach (DictionaryEntry de in htColumnsCustomShows)
            {
                if (!htColumnsCanShows.Contains(de.Key))
                    deleteList.Add(de.Key);
            }
            for (int i = 0; i < deleteList.Count; i++)
                htColumnsCustomShows.Remove(deleteList[i].ToString());

            deleteList = new ArrayList();
            foreach (DictionaryEntry de in htColumnsCustomUnShows)
            {
                if (!htColumnsCanShows.Contains(de.Key))
                    deleteList.Add(de.Key);
            }
            for (int i = 0; i < deleteList.Count; i++)
                htColumnsCustomUnShows.Remove(deleteList[i].ToString());
            #endregion
        }

        /// <summary>
        /// 对自定义的列排序。
        /// </summary>
        private void SortCustomColumn()
        {
            SortedList sl = new SortedList();
            foreach (DictionaryEntry de in htColumnsCustomShows)
            {
                sl.Add(de.Value, de.Key);
            }
            htColumnsCustomShows = new Hashtable();
            int count = 0;
            foreach (DictionaryEntry de in sl)
            {
                Objects.Column c = de.Key as Objects.Column;
                c.SortId = count;
                htColumnsCustomShows.Add(c.ID, c);
                count++;
            }
            slColumnsCustomShows = sl;//将排序后的显示的列保存，在查询自定义列的交叉报表处使用。

            sl = new SortedList();
            foreach (DictionaryEntry de in htColumnsCustomUnShows)
            {
                sl.Add(de.Value, de.Key);
            }
            htColumnsCustomUnShows = new Hashtable();
            count = 0;
            foreach (DictionaryEntry de in sl)
            {
                Objects.Column c = de.Key as Objects.Column;
                c.SortId = count;
                htColumnsCustomUnShows.Add(c.ID, c);
                count++;
            }
        }

        /// <summary>
        /// 对比客户自定义的条件与最新解析出来的条件。
        /// </summary>
        private void CompareCustomAndCanShowsCondition()
        {
            #region 增加CanShows里有但Custom中没有的
            if (doNotHaveASetting)
            {
                htConditionsCustomShows = htConditionsCanShows;
            }
            else
            {
                foreach (DictionaryEntry de in htConditionsCanShows)
                {
                    if (htConditionsCustomShows.Contains(de.Key) || htConditionsCustomUnShows.Contains(de.Key))
                    {
                        if (htConditionsCustomShows.Contains(de.Key))
                        {
                            //把自定义的内容交给CanShow，然后再把CanShow交给自定义，这样其他需要开发人员选择的属性便传递给自定义的内容。
                            Objects.Condition c = de.Value as Objects.Condition;
                            Objects.Condition cCustom = htConditionsCustomShows[de.Key] as Objects.Condition;
                            c.AndOr = cCustom.AndOr;
                            c.OperatorType = cCustom.OperatorType;
                            c.Value = cCustom.Value;
                            c.SortId = cCustom.SortId;
                            htConditionsCustomShows[de.Key] = c;
                        }
                        if (htConditionsCustomUnShows.Contains(de.Key))
                        {
                            Objects.Condition c = de.Value as Objects.Condition;
                            Objects.Condition cCustom = htConditionsCustomUnShows[de.Key] as Objects.Condition;
                            c.AndOr = cCustom.AndOr;
                            c.OperatorType = cCustom.OperatorType;
                            c.Value = cCustom.Value;
                            c.SortId = cCustom.SortId;
                            htConditionsCustomUnShows[de.Key] = c;
                        }
                        continue;
                    }
                    else
                    {
                        Objects.Condition c = de.Value as Objects.Condition;
                        c.SortId = htConditionsCustomShows.Count;
                        htConditionsCustomShows.Add(c.ID, c);
                    }
                }
            }
            #endregion

            #region 删除CanShows里没有的。
            ArrayList deleteList = new ArrayList();
            foreach (DictionaryEntry de in htConditionsCustomShows)
            {
                if (!htConditionsCanShows.Contains(de.Key))
                    deleteList.Add(de.Key);
            }
            for (int i = 0; i < deleteList.Count; i++)
                htConditionsCustomShows.Remove(deleteList[i].ToString());

            deleteList = new ArrayList();
            foreach (DictionaryEntry de in htConditionsCustomUnShows)
            {
                if (!htConditionsCanShows.Contains(de.Key))
                    deleteList.Add(de.Key);
            }
            for (int i = 0; i < deleteList.Count; i++)
                htConditionsCustomUnShows.Remove(deleteList[i].ToString());
            #endregion
        }

        /// <summary>
        /// 对自定义的条件排序。
        /// </summary>
        private void SortCustomCondition()
        {
            SortedList sl = new SortedList();
            foreach (DictionaryEntry de in htConditionsCustomShows)
            {
                sl.Add(de.Value, de.Key);
            }
            htConditionsCustomShows = new Hashtable();
            int count = 0;
            foreach (DictionaryEntry de in sl)
            {
                Objects.Condition c = de.Key as Objects.Condition;
                c.SortId = count;
                htConditionsCustomShows.Add(c.ID, c);
                count++;
            }

            sl = new SortedList();
            foreach (DictionaryEntry de in htConditionsCustomUnShows)
            {
                sl.Add(de.Value, de.Key);
            }
            htConditionsCustomUnShows = new Hashtable();
            count = 0;
            foreach (DictionaryEntry de in sl)
            {
                Objects.Condition c = de.Key as Objects.Condition;
                c.SortId = count;
                htConditionsCustomUnShows.Add(c.ID, c);
                count++;
            }
        }

        /// <summary>
        /// 初始化后执行的界面设置。
        /// </summary>
        private void SetViewWhenLoaded()
        {
            saveProtector = true;
            splitContainerH.SplitterDistance = 180;
            if (!doNotHaveASetting)
            {
                splitContainerH.SplitterDistance = customViewSetting.SplitH;
                splitContainerV.SplitterDistance = customViewSetting.SplitV;
            }
            if (!reportSetting.UseTree)
            {
                splitContainerH.SplitterDistance = 0;
                splitContainerH.IsSplitterFixed = true;
            }
            if (!reportSetting.UseDetail)
            {
                splitContainerV.SplitterDistance = splitContainerH.Panel2.Height;
                splitContainerV.IsSplitterFixed = true;
            }
            //如果没有条件，隐藏条件所在的位置。
            if (htConditionsCustomShows.Count == 0)
            {
                pnlConditions.Visible = false;
            }
            saveProtector = false;
        }

        private bool doNotHaveASetting = false;
        /// <summary>
        /// 初始化个人设置。包括布局、列的显示与宽度、条件的显示、打印等设置。
        /// </summary>
        private void InitCustomSetting()
        {
            string customSettingContent = string.Empty;
            customSettingContent = quickReportManager.QuerySharedSettingByReportID(quickReport.ID);//先查找共享的设置。
            if (customSettingContent == null || customSettingContent.Trim() == string.Empty)//如果没找到，则使用自己的设置。
            {
                customSettingContent = quickReportManager.QuerySettingByOperCodeAndReportID(quickReportManager.Operator.ID, quickReport.ID);
            }
            if (customSettingContent == null || customSettingContent.Trim() == string.Empty)
            {
                doNotHaveASetting = true;
                return;
            }
            xmlDocumentCustomSetting = new XmlDocument();
            xmlDocumentCustomSetting.LoadXml(customSettingContent);
            XmlNode node = xmlDocumentCustomSetting.SelectSingleNode(XmlAttrDicCustomView.CustomViewSetting.ToString());
            customViewSetting.SplitH = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicCustomView.tSplitH.ToString(), "180"));
            customViewSetting.SplitV = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicCustomView.tSplitV.ToString(), "360"));
            htColumnsCustomShows = GetCustomColumnShowListFromXml(node.SelectSingleNode(XmlAttrDicCustomView.CustomColumnShowList.ToString()) as XmlElement);
            htColumnsCustomUnShows = GetCustomColumnUnShowListFromXml(node.SelectSingleNode(XmlAttrDicCustomView.CustomColumnUnShowList.ToString()) as XmlElement);
            htConditionsCustomShows = GetCustomConditionShowListFromXml(node.SelectSingleNode(XmlAttrDicCustomView.CustomConditionShowList.ToString()) as XmlElement);
            htConditionsCustomUnShows = GetCustomConditionUnShowListFromXml(node.SelectSingleNode(XmlAttrDicCustomView.CustomConditionUnShowList.ToString()) as XmlElement);
        }

        /// <summary>
        /// 初始化条件。
        /// </summary>
        private void InitConditions()
        {
            if (isLoaded)
            {
                if (htConditionsCustomShows.Count == 0)
                {
                    ucReportConditionList.ClearConditions();
                    pnlConditions.Visible = false;
                    return;
                }
            }
            pnlConditions.Visible = true;
            Objects.Condition[] cs = new QuickReportCore.Objects.Condition[htConditionsCustomShows.Count];
            foreach (DictionaryEntry de in htConditionsCustomShows)
                cs[((Objects.Condition)de.Value).SortId] = htConditionsCanShows[de.Key] as Objects.Condition;
            ArrayList al = ucReportConditionList.LoadConditionList(cs);
            iNeedTranslatedValueList = al[0] as List<QuickReportCore.Interfaces.INeedTranslatedValue>;
            iNeedQueryList = al[1] as List<QuickReportCore.Interfaces.INeedQuery>;
            ucReportConditionList.ShowConditions();
            foreach (Interfaces.INeedTranslatedValue i in iNeedTranslatedValueList)
            {
                i.NeedTranslatedValue += new QuickReportCore.Interfaces.NeedTranslatedValueHandle(i_NeedTranslatedValue);
            }
            foreach (Interfaces.INeedQuery i in iNeedQueryList)
            {
                i.NeedQuery += new QuickReportCore.Interfaces.NeedQueryHandle(i_NeedQuery);
            }
        }

        void i_NeedQuery(object sender)
        {
            Query();
        }

        void i_NeedTranslatedValue(ref string value, QuickReportCore.Managers.Functions.SQLCodeType[] types)
        {
            value = TranslateValue(value, types);
        }

        private void InitFp()
        {
            fpMain.SuspendLayout();
            fpDetail.SuspendLayout();
            fpMain.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
            fpDetail.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
            InitFpColumns();
            InitFpColumnHeaders();
            SetQueryColumns();
            SetColumnBorder();
            //if (reportSetting.UseLoadAndQuery && !haveBeenLoadAndQuery)
            //{
            //    Query();
            //}
            fpMain.ResumeLayout();
            fpDetail.ResumeLayout();
        }

        /// <summary>
        /// 设置ColumnBorder。
        /// </summary>
        private void SetColumnBorder()
        {
            if (reportType == ReportType.GeneralCross||reportType == ReportType.CustomCross)//如果报表样式是交叉报表，则循环所有的列。
            {
                for (int i = 0; i < fpMain_Sheet1.Columns.Count; i++)
                {
                    fpMain_Sheet1.Columns[i].Border = normalColumnCenterBorder;
                }
                if (fpMain_Sheet1.Columns.Count > 0)
                {
                    fpMain_Sheet1.Columns[0].Border = NormalColumnLeftLineBorder;
                    fpMain_Sheet1.Columns[fpMain_Sheet1.Columns.Count - 1].Border = NormalColumnRightBorder;
                }
                if (fpMain_Sheet1.ColumnHeader.Rows.Count > 0 && fpMain_Sheet1.ColumnHeader.Rows[fpMain_Sheet1.ColumnHeader.Rows.Count - 1].Tag == null)
                {
                    for (int i = 0; i < fpMain_Sheet1.ColumnHeader.Columns.Count; i++)
                    {
                        fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, i].Border = columnHeaderCenterLineBorder;
                    }
                    if (fpMain_Sheet1.ColumnHeader.Columns.Count > 0 && fpMain_Sheet1.ColumnHeader.Rows.Count > 0)
                    {
                        fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, 0].Border = ColumnHeaderLeftLineBorder;
                        fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Border = ColumnHeaderRightLineBorder;
                    }
                }
            }
            else if(reportType== ReportType.Grid)//如果是网格报表。
            {
                int lastVisbleColumnIndex = 0;
                for (int i = 0; i < fpMain_Sheet1.Columns.Count; i++)
                {
                    if (fpMain_Sheet1.Columns[i].Visible)
                    {
                        fpMain_Sheet1.Columns[i].Border = normalColumnCenterBorder;
                        lastVisbleColumnIndex = i;
                    }
                }
                if (fpMain_Sheet1.Columns.Count > 0)
                {
                    fpMain_Sheet1.Columns[0].Border = NormalColumnLeftLineBorder;
                    fpMain_Sheet1.Columns[lastVisbleColumnIndex].Border = NormalColumnRightBorder;
                }
                if (fpMain_Sheet1.ColumnHeader.Rows.Count > 0 && fpMain_Sheet1.ColumnHeader.Rows[fpMain_Sheet1.ColumnHeader.Rows.Count - 1].Tag == null)
                {
                    for (int i = 0; i < fpMain_Sheet1.ColumnHeader.Columns.Count; i++)
                    {
                        if (fpMain_Sheet1.ColumnHeader.Columns[i].Visible)
                        {
                            fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, i].Border = columnHeaderCenterLineBorder;
                            lastVisbleColumnIndex = i;
                        }
                    }
                    if (fpMain_Sheet1.ColumnHeader.Columns.Count > 0 && fpMain_Sheet1.ColumnHeader.Rows.Count > 0)
                    {
                        fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, 0].Border = ColumnHeaderLeftLineBorder;
                        fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, lastVisbleColumnIndex].Border = ColumnHeaderRightLineBorder;
                    }
                }
            }
        }

        /// <summary>
        /// 初始化Fp的列。
        /// </summary>
        private void InitFpColumns()
        {
            //如果是非自定义列的交叉报表，则清空当前报表界面并去执行明细报表的初始化。
            if (reportType== ReportType.GeneralCross)
            {
                ClearReportFarpoint();//注意，此处已经清空报表，Detail可以不必再次清空。
                goto Detail;
            }
            fpMain_Sheet1.DataSource = null;
            ClearReportFarpoint();
            #region 获取需要计算列合计与行合计的列。
            columnsNeedColumnSums = new ArrayList();
            columnsNeedRowSums = new ArrayList();
            //获得所有需要合计的列。
            int decimalPlace = 0;
            foreach (DictionaryEntry de in htColumnsCustomShows)
            {
                if ((de.Value as Objects.Column).TotalColumn)//需要列合计。
                    columnsNeedColumnSums.Add((de.Value as Objects.Column).SortId);
                if ((de.Value as Objects.Column).TotalRow)//需要行合计。
                {
                    columnsNeedRowSums.Add((de.Value as Objects.Column).SortId);
                    if ((de.Value as Objects.Column).DecimalPlace > decimalPlace)//将保留位数最长的作为行合计的保留位数。
                        decimalPlace = (de.Value as Objects.Column).DecimalPlace;
                }
                rowSumNumberCellType.DecimalPlaces = decimalPlace;// (de.Value as Objects.Column).DecimalPlace;//随便取一个数据类型。
            }
            #endregion
            if (htColumnsCustomShows.Count != 0)
                fpMain_Sheet1.ColumnHeader.Rows.Count = 1;//先新增一行用以显示列头。
            if (reportType == ReportType.CustomCross)//如果是自定义列的交叉报表，则添加交叉报表的行。
            {
                fpMain_Sheet1.ColumnHeader.Columns.Count = htColumnsCustomShows.Count + 1;//之所以+1，是为了显示交叉报表的行。
                if (fpMain_Sheet1.ColumnHeader.Rows.Count > 0)
                    fpMain_Sheet1.ColumnHeader.Cells[0, 0].Value = crossSetting.Row;
                foreach (DictionaryEntry de in htColumnsCustomShows)
                {
                    Objects.Column c = de.Value as Objects.Column;
                    fpMain_Sheet1.ColumnHeader.Cells[0, c.SortId+1].Value = c.ID;
                    fpMain_Sheet1.ColumnHeader.Columns[c.SortId+1].Width = c.Width;
                    fpMain_Sheet1.ColumnHeader.Columns[c.SortId+1].Tag = c;
                }
            }
            else
            {
                if (columnsNeedRowSums.Count == 0)//如果不使用行合计。
                    fpMain_Sheet1.ColumnHeader.Columns.Count = htColumnsCustomShows.Count;
                else//如果使用行合计。
                {
                    fpMain_Sheet1.ColumnHeader.Columns.Count = htColumnsCustomShows.Count + 1;//+1是因为有行合计。
                    fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.Columns.Count - 1].Value = "合计";
                }
                foreach (DictionaryEntry de in htColumnsCustomShows)
                {
                    Objects.Column c = de.Value as Objects.Column;
                    fpMain_Sheet1.ColumnHeader.Cells[0, c.SortId].Value = c.ID;
                    fpMain_Sheet1.ColumnHeader.Columns[c.SortId].Width = c.Width;
                    fpMain_Sheet1.ColumnHeader.Columns[c.SortId].Tag = c;
                }
            }

        Detail:

            if (!reportSetting.UseDetail)
                return;
            #region 需要被翻译的种类。
            Managers.Functions.SQLCodeType[] typesDetail = new QuickReportCore.Managers.Functions.SQLCodeType[4];
            typesDetail[0] = QuickReportCore.Managers.Functions.SQLCodeType.Tree;
            typesDetail[1] = QuickReportCore.Managers.Functions.SQLCodeType.System;
            typesDetail[2] = QuickReportCore.Managers.Functions.SQLCodeType.Condition;
            typesDetail[3] = QuickReportCore.Managers.Functions.SQLCodeType.Column;
            #endregion
            string sql = detailSetting.SQL;
            sql = TranslateValue(sql, typesDetail);
            sql = "Select * From ( \n " + sql + " \n ) Where 1<>1";
            DataSet ds = null;
            quickReportManager.ExecQuery(sql, ref ds);
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
                return;
            DataTable dt = ds.Tables[0];
            fpDetail_Sheet1.DataSource = null;
            fpDetail_Sheet1.ColumnHeader.Columns.Count = dt.Columns.Count;
            if (dt.Columns.Count != 0)
                fpDetail_Sheet1.ColumnHeader.Rows.Count = 1;
            for (int index = 0; index < dt.Columns.Count; index++)
            {
                fpDetail_Sheet1.ColumnHeader.Cells[0, index].Value = dt.Columns[index].ColumnName;
                fpDetail_Sheet1.ColumnHeader.Cells[0, index].Border = columnHeaderCenterLineBorder;
                fpDetail_Sheet1.ColumnHeader.Columns[index].Width = fpDetail_Sheet1.ColumnHeader.Columns[index].GetPreferredWidth();
            }
            if (fpDetail_Sheet1.ColumnHeader.Columns.Count > 0 && fpDetail_Sheet1.ColumnHeader.Rows.Count > 0)
            {
                fpDetail_Sheet1.ColumnHeader.Cells[0, 0].Border = ColumnHeaderLeftLineBorder;
                fpDetail_Sheet1.ColumnHeader.Cells[0, fpDetail_Sheet1.ColumnHeader.Columns.Count - 1].Border = ColumnHeaderRightLineBorder;
            }
        }

        /// <summary>
        /// 初始化Fp的列头。
        /// </summary>
        private void InitFpColumnHeaders()
        {
            if (headerSettingTop.Count == 0)
                goto Detail;
            fpMain_Sheet1.ColumnHeader.Rows.Add(0, headerSettingTop.Count);
            if (fpMain_Sheet1.ColumnHeader.Columns.Count == 0)
                fpMain_Sheet1.ColumnHeader.Columns.Count = 1;
            #region 需要被翻译的种类。
            Managers.Functions.SQLCodeType[] types = new QuickReportCore.Managers.Functions.SQLCodeType[5];
            types[0] = QuickReportCore.Managers.Functions.SQLCodeType.Tree;
            types[1] = QuickReportCore.Managers.Functions.SQLCodeType.System;
            types[2] = QuickReportCore.Managers.Functions.SQLCodeType.Condition;
            types[3] = QuickReportCore.Managers.Functions.SQLCodeType.Dynamic;
            types[4] = QuickReportCore.Managers.Functions.SQLCodeType.Column;
            #endregion
            foreach (Objects.Header h in headerSettingTop)
            {
                FarPoint.Win.Spread.Cell cell = fpMain_Sheet1.ColumnHeader.Cells[h.RowIndex, 0];
                cell.CellType = textCelltype;
                cell.ColumnSpan = fpMain_Sheet1.ColumnHeader.Columns.Count;
                string s = TranslateValue(h.Text, types);
                cell.Value = s;
                cell.Font = h.Font;
                cell.ForeColor = h.Color;
                cell.HorizontalAlignment = h.HAligment;
                cell.VerticalAlignment = h.VAligment;
                cell.Row.Border = bottomHeaderBorder;
                fpMain_Sheet1.ColumnHeader.Rows[h.RowIndex].Height = h.Height;
                fpMain_Sheet1.ColumnHeader.Rows[h.RowIndex].Tag = h;
            }
            if (fpMain_Sheet1.ColumnHeader.Columns.Count == 1)
                fpMain_Sheet1.ColumnHeader.Columns[0].Width = 1000;
            if (fpMain_Sheet1.ColumnHeader.Visible == false)
                fpMain_Sheet1.ColumnHeader.Visible = true;
        Detail:
            if (!reportSetting.UseDetail)
                return;
            if (detailHeaderSettingTop.Count == 0)
                return;
            fpDetail_Sheet1.ColumnHeader.Rows.Add(0, detailHeaderSettingTop.Count);
            if (fpDetail_Sheet1.ColumnHeader.Columns.Count == 0)
                fpDetail_Sheet1.ColumnHeader.Columns.Count = 1;
            #region 需要被翻译的种类。
            Managers.Functions.SQLCodeType[] typesDetail = new QuickReportCore.Managers.Functions.SQLCodeType[5];
            typesDetail[0] = QuickReportCore.Managers.Functions.SQLCodeType.Tree;
            typesDetail[1] = QuickReportCore.Managers.Functions.SQLCodeType.System;
            typesDetail[2] = QuickReportCore.Managers.Functions.SQLCodeType.Condition;
            typesDetail[3] = QuickReportCore.Managers.Functions.SQLCodeType.Column;
            typesDetail[4] = QuickReportCore.Managers.Functions.SQLCodeType.Dynamic;
            #endregion
            foreach (Objects.Header h in detailHeaderSettingTop)
            {
                FarPoint.Win.Spread.Cell cell = fpDetail_Sheet1.ColumnHeader.Cells[h.RowIndex, 0];
                cell.CellType = textCelltype;
                cell.ColumnSpan = fpDetail_Sheet1.ColumnHeader.Columns.Count;
                string s = TranslateValue(h.Text, typesDetail);
                cell.Text = s;
                cell.Font = h.Font;
                cell.ForeColor = h.Color;
                cell.HorizontalAlignment = h.HAligment;
                cell.VerticalAlignment = h.VAligment;
                cell.Row.Border = bottomHeaderBorder;
                fpDetail_Sheet1.ColumnHeader.Rows[h.RowIndex].Height = h.Height;
                fpDetail_Sheet1.ColumnHeader.Rows[h.RowIndex].Tag = h;
            }
            if (fpDetail_Sheet1.ColumnHeader.Columns.Count == 1)
                fpDetail_Sheet1.ColumnHeader.Columns[0].Width = 1000;
        }

        /// <summary>
        /// 设置列的属性到自定义的属性。
        /// </summary>
        private void SetColumnAttrToCustomAfterQuery()
        {
            saveProtector = true;
            //如果是网格报表。
            if (reportType == ReportType.Grid)
            {
                for (int i = 0; i < fpMain_Sheet1.ColumnHeader.Columns.Count; i++)
                {
                    if (fpMain_Sheet1.ColumnHeader.Columns[i].Tag is Objects.Column)
                    {
                        Objects.Column column = fpMain_Sheet1.ColumnHeader.Columns[i].Tag as Objects.Column;
                        fpMain_Sheet1.ColumnHeader.Columns[i].Width = column.Width;
                        fpMain_Sheet1.Columns[i].AllowAutoFilter = column.Filter;
                        fpMain_Sheet1.Columns[i].AllowAutoSort = column.Sort;
                        if(column.Union)
                            fpMain_Sheet1.Columns[i].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
                        fpMain_Sheet1.Columns[i].Font = column.Font;
                        fpMain_Sheet1.Columns[i].ForeColor = column.Color;
                        fpMain_Sheet1.Columns[i].HorizontalAlignment = column.HAligment;
                        fpMain_Sheet1.Columns[i].VerticalAlignment = column.VAligment;
                        if (column.IsNumber)
                        {
                            numberCellType.DecimalPlaces = column.DecimalPlace;
                            numberCellType.ValueTransType = column.ValueTransType;
                            fpMain_Sheet1.Columns[i].CellType = numberCellType.Clone() as FarPoint.Win.Spread.CellType.NumberCellType;
                        }
                        else
                            fpMain_Sheet1.Columns[i].CellType = textCelltype;
                    }
                }
            }
            //如果是自定义列的交叉报表。
            else if (reportType== ReportType.CustomCross)
            {
                for (int i = 0; i < fpMain_Sheet1.ColumnHeader.Columns.Count; i++)
                {
                    if (fpMain_Sheet1.ColumnHeader.Columns[i].Tag is Objects.Column)
                    {
                        Objects.Column column = fpMain_Sheet1.ColumnHeader.Columns[i].Tag as Objects.Column;
                        fpMain_Sheet1.ColumnHeader.Columns[i].Width = column.Width;
                    }
                }
            }
            saveProtector = false;
        }

        /// <summary>
        /// 设置非显示列不可见。
        /// </summary>
        private void SetUnCustomColumnInvisbleAfterQuery()
        {
            //如果是普通交叉报表，则返回。
            if (reportType== ReportType.GeneralCross)
                return;
            for (int i = htColumnsCustomShows.Count; i < fpMain_Sheet1.ColumnHeader.Columns.Count; i++)
                fpMain_Sheet1.ColumnHeader.Columns[i].Visible = false;
        }

        /// <summary>
        /// 查询后设置表头。
        /// </summary>
        private void SetColumnHeaderAfterQuery(MainOrDetail m)
        {
            if (m == MainOrDetail.Main)
            {
                #region 主报表需要被翻译的种类。
                Managers.Functions.SQLCodeType[] types = new QuickReportCore.Managers.Functions.SQLCodeType[5];
                types[0] = QuickReportCore.Managers.Functions.SQLCodeType.Tree;
                types[1] = QuickReportCore.Managers.Functions.SQLCodeType.System;
                types[2] = QuickReportCore.Managers.Functions.SQLCodeType.Condition;
                types[3] = QuickReportCore.Managers.Functions.SQLCodeType.Dynamic;
                types[4] = QuickReportCore.Managers.Functions.SQLCodeType.Column;
                #endregion
                for (int i = 0; i < fpMain_Sheet1.ColumnHeader.Rows.Count; i++)
                {
                    if ((Objects.Header)fpMain_Sheet1.ColumnHeader.Rows[i].Tag == null)
                        continue;
                    string s = (fpMain_Sheet1.ColumnHeader.Rows[i].Tag as Objects.Header).Text;
                    s = TranslateValue(s, types);
                    fpMain_Sheet1.ColumnHeader.Cells[i, 0].Value = s;
                }
            }
            else if (m == MainOrDetail.Detail)
            {
                #region 明细表需要被翻译的种类。
                Managers.Functions.SQLCodeType[] typesDetail = new QuickReportCore.Managers.Functions.SQLCodeType[5];
                typesDetail[0] = QuickReportCore.Managers.Functions.SQLCodeType.Tree;
                typesDetail[1] = QuickReportCore.Managers.Functions.SQLCodeType.System;
                typesDetail[2] = QuickReportCore.Managers.Functions.SQLCodeType.Condition;
                typesDetail[3] = QuickReportCore.Managers.Functions.SQLCodeType.Dynamic;
                typesDetail[4] = QuickReportCore.Managers.Functions.SQLCodeType.Column;
                #endregion
                for (int i = 0; i < fpDetail_Sheet1.ColumnHeader.Rows.Count; i++)
                {
                    if ((Objects.Header)fpDetail_Sheet1.ColumnHeader.Rows[i].Tag == null)
                        continue;
                    string s = (fpDetail_Sheet1.ColumnHeader.Rows[i].Tag as Objects.Header).Text;
                    s = TranslateValue(s, typesDetail);
                    fpDetail_Sheet1.ColumnHeader.Cells[i, 0].Value = s;
                }
            }
        }

        /// <summary>
        /// 将改变后的列宽保存到自定义列中。
        /// </summary>
        private void ColumnWidthChanged()
        {
            //如果是非自定义列的交叉报表。
            if (reportType== ReportType.GeneralCross)
                return;
            for (int i = 0; i < fpMain_Sheet1.ColumnHeader.Columns.Count; i++)
            {
                if (fpMain_Sheet1.ColumnHeader.Columns[i].Tag is Objects.Column)
                {
                    (fpMain_Sheet1.ColumnHeader.Columns[i].Tag as Objects.Column).Width = fpMain_Sheet1.ColumnHeader.Columns[i].Width;
                }
            }
        }

        /// <summary>
        /// 在查询完毕后执行。添加脚标。
        /// </summary>
        private void AddBottomHeaderAfterQuery(MainOrDetail m)
        {
            if (m == MainOrDetail.Main)
            {
                if (headerSettingBottom.Count == 0)
                    return;
                int rowCount = fpMain_Sheet1.Rows.Count;
                fpMain_Sheet1.AddUnboundRows(rowCount, headerSettingBottom.Count);
                if (fpMain_Sheet1.Columns.Count == 0)
                    fpMain_Sheet1.Columns.Count = 1;
                #region 需要被翻译的种类。
                Managers.Functions.SQLCodeType[] types = new QuickReportCore.Managers.Functions.SQLCodeType[5];
                types[0] = QuickReportCore.Managers.Functions.SQLCodeType.Tree;
                types[1] = QuickReportCore.Managers.Functions.SQLCodeType.System;
                types[2] = QuickReportCore.Managers.Functions.SQLCodeType.Condition;
                types[3] = QuickReportCore.Managers.Functions.SQLCodeType.Dynamic;
                types[4] = QuickReportCore.Managers.Functions.SQLCodeType.Column;
                #endregion
                foreach (Objects.Header h in headerSettingBottom)
                {
                    FarPoint.Win.Spread.Cell cell = fpMain_Sheet1.Cells[rowCount + h.RowIndex, 0];
                    cell.CellType = textCelltype;
                    cell.ColumnSpan = fpMain_Sheet1.Columns.Count;
                    string s = TranslateValue(h.Text, types);
                    cell.Value = s;
                    cell.Font = h.Font;
                    cell.ForeColor = h.Color;
                    cell.HorizontalAlignment = h.HAligment;
                    cell.VerticalAlignment = h.VAligment;
                    cell.Row.Border = bottomHeaderBorder;
                    fpMain_Sheet1.Rows[rowCount + h.RowIndex].Height = h.Height;
                    fpMain_Sheet1.Rows[rowCount + h.RowIndex].Tag = h;
                }
            }
            else if (m == MainOrDetail.Detail)
            {
                if (!reportSetting.UseDetail)
                    return;
                if (detailHeaderSettingBottom.Count == 0)
                    return;
                int rowCount = fpDetail_Sheet1.Rows.Count;
                fpDetail_Sheet1.AddUnboundRows(rowCount, detailHeaderSettingBottom.Count);
                if (fpDetail_Sheet1.Columns.Count == 0)
                    fpDetail_Sheet1.Columns.Count = 1;
                #region 需要被翻译的种类。
                Managers.Functions.SQLCodeType[] typesDetail = new QuickReportCore.Managers.Functions.SQLCodeType[5];
                typesDetail[0] = QuickReportCore.Managers.Functions.SQLCodeType.Tree;
                typesDetail[1] = QuickReportCore.Managers.Functions.SQLCodeType.System;
                typesDetail[2] = QuickReportCore.Managers.Functions.SQLCodeType.Condition;
                typesDetail[3] = QuickReportCore.Managers.Functions.SQLCodeType.Column;
                typesDetail[4] = QuickReportCore.Managers.Functions.SQLCodeType.Dynamic;
                #endregion
                foreach (Objects.Header h in detailHeaderSettingBottom)
                {
                    FarPoint.Win.Spread.Cell cell = fpDetail_Sheet1.Cells[rowCount + h.RowIndex, 0];
                    cell.CellType = textCelltype;
                    cell.ColumnSpan = fpDetail_Sheet1.Columns.Count;
                    string s = TranslateValue(h.Text, typesDetail);
                    cell.Text = s;
                    cell.Font = h.Font;
                    cell.ForeColor = h.Color;
                    cell.HorizontalAlignment = h.HAligment;
                    cell.VerticalAlignment = h.VAligment;
                    cell.Row.Border = bottomHeaderBorder;
                    fpDetail_Sheet1.Rows[rowCount + h.RowIndex].Height = h.Height;
                    fpDetail_Sheet1.Rows[rowCount + h.RowIndex].Tag = h;
                }
            }
        }

        private List<Objects.Header> GetMainReportTranslatedColumnHeader(int translateSourceRowIndex)
        {
            List<QuickReportCore.Objects.Header> listTranslated = new List<QuickReportCore.Objects.Header>();
            if (headerSettingTop.Count == 0)
                return listTranslated;
            #region 需要被翻译的种类。
            Managers.Functions.SQLCodeType[] types = new QuickReportCore.Managers.Functions.SQLCodeType[4];
            types[0] = QuickReportCore.Managers.Functions.SQLCodeType.Tree;
            types[1] = QuickReportCore.Managers.Functions.SQLCodeType.System;
            types[2] = QuickReportCore.Managers.Functions.SQLCodeType.Condition;
            types[3] = QuickReportCore.Managers.Functions.SQLCodeType.Dynamic;
            #endregion
            foreach (Objects.Header h in headerSettingTop)
            {
                Objects.Header headerTranslasted = h.Clone();
                string s = TranslateValue(h.Text, types);
                s = TranslateTextWithColumnValue(s, translateSourceRowIndex);
                headerTranslasted.Text = s;
                listTranslated.Add(headerTranslasted);
            }
            return listTranslated;
        }

        private List<Objects.Header> GetMainReportTranslatedBottomHeader(int translateSourceRowIndex)
        {
            List<QuickReportCore.Objects.Header> listTranslated = new List<QuickReportCore.Objects.Header>();
            if (headerSettingBottom.Count == 0)
                return listTranslated;
            #region 需要被翻译的种类。
            Managers.Functions.SQLCodeType[] types = new QuickReportCore.Managers.Functions.SQLCodeType[4];
            types[0] = QuickReportCore.Managers.Functions.SQLCodeType.Tree;
            types[1] = QuickReportCore.Managers.Functions.SQLCodeType.System;
            types[2] = QuickReportCore.Managers.Functions.SQLCodeType.Condition;
            types[3] = QuickReportCore.Managers.Functions.SQLCodeType.Dynamic;
            #endregion
            foreach (Objects.Header h in headerSettingBottom)
            {
                Objects.Header headerTranslasted = h.Clone();
                string s = TranslateValue(h.Text, types);
                s = TranslateTextWithColumnValue(s, translateSourceRowIndex);
                headerTranslasted.Text = s;
                listTranslated.Add(headerTranslasted);
            }
            return listTranslated;
        }

        private List<Objects.Header> GetMainReportTranslatedColumnHeader(int translateSourceRowIndex, int translateSourceColumnIndex)
        {
            List<QuickReportCore.Objects.Header> listTranslated = new List<QuickReportCore.Objects.Header>();
            if (headerSettingTop.Count == 0)
                return listTranslated;
            #region 需要被翻译的种类。
            Managers.Functions.SQLCodeType[] types = new QuickReportCore.Managers.Functions.SQLCodeType[4];
            types[0] = QuickReportCore.Managers.Functions.SQLCodeType.Tree;
            types[1] = QuickReportCore.Managers.Functions.SQLCodeType.System;
            types[2] = QuickReportCore.Managers.Functions.SQLCodeType.Condition;
            types[3] = QuickReportCore.Managers.Functions.SQLCodeType.Dynamic;
            #endregion
            foreach (Objects.Header h in headerSettingTop)
            {
                Objects.Header headerTranslasted = h.Clone();
                string s = TranslateValue(h.Text, types);
                s = TranslateTextWithColumnValue(s, translateSourceRowIndex,translateSourceColumnIndex);
                headerTranslasted.Text = s;
                listTranslated.Add(headerTranslasted);
            }
            return listTranslated;
        }

        private List<Objects.Header> GetMainReportTranslatedBottomHeader(int translateSourceRowIndex,int translateSourceColumnIndex)
        {
            List<QuickReportCore.Objects.Header> listTranslated = new List<QuickReportCore.Objects.Header>();
            if (headerSettingBottom.Count == 0)
                return listTranslated;
            #region 需要被翻译的种类。
            Managers.Functions.SQLCodeType[] types = new QuickReportCore.Managers.Functions.SQLCodeType[4];
            types[0] = QuickReportCore.Managers.Functions.SQLCodeType.Tree;
            types[1] = QuickReportCore.Managers.Functions.SQLCodeType.System;
            types[2] = QuickReportCore.Managers.Functions.SQLCodeType.Condition;
            types[3] = QuickReportCore.Managers.Functions.SQLCodeType.Dynamic;
            #endregion
            foreach (Objects.Header h in headerSettingBottom)
            {
                Objects.Header headerTranslasted = h.Clone();
                string s = TranslateValue(h.Text, types);
                s = TranslateTextWithColumnValue(s, translateSourceRowIndex,translateSourceColumnIndex);
                headerTranslasted.Text = s;
                listTranslated.Add(headerTranslasted);
            }
            return listTranslated;
        }

        private string TranslateTextWithDynamicValue(string text)
        {
            string s = text.Replace(Managers.Functions.GetSQLCode(Forms.frmToolBoxSystemValue.DynamicSystemValueType.行数.ToString(), QuickReportCore.Managers.Functions.SQLCodeType.Dynamic), reportDataRowNumber.ToString());
            s = s.Replace(Managers.Functions.GetSQLCode(Forms.frmToolBoxSystemValue.DynamicSystemValueType.列数.ToString(), QuickReportCore.Managers.Functions.SQLCodeType.Dynamic), reportDataColumnNumer.ToString());
            s = s.Replace(Managers.Functions.GetSQLCode(Forms.frmToolBoxSystemValue.DynamicSystemValueType.耗时.ToString(), QuickReportCore.Managers.Functions.SQLCodeType.Dynamic), queryTimeUsed.ToString());
            return s;
        }

        private string TranslateTextWithTreeValue(string text)
        {
            string code = string.Empty;
            string name = string.Empty;
            if (!tvReport.CheckBoxes)//非多选框时。
            {
                if (tvReport.SelectedNode != null && tvReport.SelectedNode.Tag is Objects.Column)
                {
                    Objects.Column c = tvReport.SelectedNode.Tag as Objects.Column;
                    code = c.ID;
                    name = c.Name;
                }
            }
            else//使用多选框时。
            {
                List<TreeNode> nodes = tvReport.SelectedNodes;
                if (nodes.Count > 0)
                {
                    foreach (TreeNode node in nodes)
                    {
                        if (node.Tag is Objects.Column)
                        {
                            Objects.Column c = node.Tag as Objects.Column;
                            code +=  c.ID + ",";
                            name +=  c.Name + ",";
                        }
                    }
                    if (code.Length > 0)
                        code = code.Substring(0, code.Length - 1);//去掉最后一个逗号。
                    if (name.Length > 0)
                        name = name.Substring(0, name.Length - 1);//去掉最后一个逗号。
                }
            }
            string s = text.Replace(Managers.Functions.GetSQLCode(Forms.frmToolBoxSystemValue.TreeValueType.节点编码.ToString(), QuickReportCore.Managers.Functions.SQLCodeType.Tree), code);
            s = s.Replace(Managers.Functions.GetSQLCode(Forms.frmToolBoxSystemValue.TreeValueType.节点名称.ToString(), QuickReportCore.Managers.Functions.SQLCodeType.Tree), name);
            return s;
        }

        /// <summary>
        /// 为SQL查询提供树变量的翻译。主要是主报表的SQL与明细报表的SQL。
        /// </summary>
        /// <param name="text">需要翻译的字符。</param>
        /// <returns>翻译后的字符。</returns>
        private string TranslateTextWithTreeValueForSql(string text)
        {
            string code = "''";
            string name = "''";
            if (!tvReport.CheckBoxes)//非多选框时。
            {
                if (tvReport.SelectedNode != null && tvReport.SelectedNode.Tag is Objects.Column)
                {
                    Objects.Column c = tvReport.SelectedNode.Tag as Objects.Column;
                    code = c.ID;
                    name = c.Name;
                }
            }
            else//使用多选框时。
            {
                List<TreeNode> nodes = tvReport.SelectedNodes;
                if (nodes.Count > 0)
                {
                    foreach (TreeNode node in nodes)
                    {
                        if (node.Tag is Objects.Column)
                        {
                            Objects.Column c = node.Tag as Objects.Column;
                            code += "'" + c.ID + "',";
                            name += "'" + c.Name + "',";
                        }
                    }
                    if (code.Length > 2)
                    {
                        code = code.Substring(0, code.Length - 1);//去掉最后一个逗号。
                        code = code.Substring(2, code.Length - 2);//去掉最前面的两个引号。
                    }
                    if (name.Length > 2)
                    {
                        name = name.Substring(0, name.Length - 1);//去掉最后一个逗号。
                        name = name.Substring(2,name.Length-2);//去掉最前面的两个引号。
                    }
                }
            }
            string s = text.Replace(Managers.Functions.GetSQLCode(Forms.frmToolBoxSystemValue.TreeValueType.节点编码.ToString(), QuickReportCore.Managers.Functions.SQLCodeType.Tree), code);
            s = s.Replace(Managers.Functions.GetSQLCode(Forms.frmToolBoxSystemValue.TreeValueType.节点名称.ToString(), QuickReportCore.Managers.Functions.SQLCodeType.Tree), name);
            return s;
        }

        private string TranslateTextWithConditionValue(string text)
        {
            string s = text;
            foreach (DictionaryEntry de in htConditionsCanShows)
            {
                //去掉客户看不到的条件。
                if (!htConditionsCustomShows.Contains(de.Key))
                {
                    s = s.Replace(Managers.Functions.GetSQLCode(de.Key.ToString(), QuickReportCore.Managers.Functions.SQLCodeType.Condition), string.Empty);
                }
            }
            s = ucReportConditionList.TranslateTextWithConditionValue(s);
            return s;
        }

        /// <summary>
        /// 主要为表首与表尾的内容服务。主要是返回第一行数据的内容。
        /// </summary>
        /// <param name="text">翻译前的字符。</param>
        /// <returns>翻译后的字符。</returns>
        public string TranslateTextWithColumnValue(string text)
        {
            string s = text;
            if (fpMain_Sheet1.ActiveRow == null || fpMain_Sheet1.Rows.Count == 0)//如果当前没有活动行，或者当前没有数据。
            {
                if (reportType == ReportType.Grid)//如果是网格报表
                {
                    foreach (DictionaryEntry de in htColumnsBase)
                    {
                        s = s.Replace(Managers.Functions.GetSQLCode(de.Key.ToString(), QuickReportCore.Managers.Functions.SQLCodeType.Column), string.Empty);
                    }
                }
                else if (reportType == ReportType.CustomCross || reportType == ReportType.GeneralCross)//如果是交叉报表
                {
                    s = s.Replace(Managers.Functions.GetSQLCode(crossSetting.Row, QuickReportCore.Managers.Functions.SQLCodeType.Column), string.Empty);
                    s = s.Replace(Managers.Functions.GetSQLCode(crossSetting.Column, QuickReportCore.Managers.Functions.SQLCodeType.Column), string.Empty);
                    s = s.Replace(Managers.Functions.GetSQLCode(crossSetting.Value, QuickReportCore.Managers.Functions.SQLCodeType.Column), string.Empty);
                }
            }
            else
            {
                if (reportType == ReportType.Grid)//如果是网格报表
                {
                   s = TranslateTextWithColumnValue(s, 0);
                }
                else if (reportType == ReportType.CustomCross || reportType == ReportType.GeneralCross)//如果是交叉报表
                {
                    if (fpMain_Sheet1.Columns.Count == 1)
                        s = TranslateTextWithColumnValue(s, 0, 0);
                    else if(fpMain_Sheet1.Columns.Count>1)
                        s = TranslateTextWithColumnValue(s, 0,1);
                }
            }
            return s;
        }

        /// <summary>
        /// 用列的值翻译字串。为网格报表的明细查询服务。
        /// </summary>
        /// <param name="text">需要被翻译的字符串。</param>
        /// <param name="rowIndex">行号。</param>
        /// <returns>翻译后。</returns>
        private string TranslateTextWithColumnValue(string text, int rowIndex)
        {
            if (fpMain_Sheet1.ActiveRow == null)
                return text;
            string s = text;
            foreach (DictionaryEntry de in htColumnsBase)
            {
                string value = GetCellStringValue(fpMain_Sheet1.Cells[rowIndex, (de.Value as Objects.Column).SortId],string.Empty);
                s = s.Replace(Managers.Functions.GetSQLCode(de.Key.ToString(), QuickReportCore.Managers.Functions.SQLCodeType.Column), value);
            }
            return s;
        }

        /// <summary>
        /// 用列的值翻译字串。为交叉报表的明细查询服务。
        /// </summary>
        /// <param name="text">翻译前的字串。</param>
        /// <param name="rowIndex">行号。</param>
        /// <param name="columnIndex">列号。</param>
        /// <returns>翻译后的字串。</returns>
        private string TranslateTextWithColumnValue(string text, int rowIndex,int columnIndex)
        {
            if (fpMain_Sheet1.ActiveRow == null)
                return text;
            string s = text;
            string row = GetCellStringValue(fpMain_Sheet1.Cells[rowIndex, 0],string.Empty);
            string column = GetCellStringValue(fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, columnIndex],string.Empty);
            string value = GetCellStringValue(fpMain_Sheet1.Cells[rowIndex, columnIndex],string.Empty);
            s = s.Replace(Managers.Functions.GetSQLCode(crossSetting.Row, QuickReportCore.Managers.Functions.SQLCodeType.Column), row);
            s = s.Replace(Managers.Functions.GetSQLCode(crossSetting.Column, QuickReportCore.Managers.Functions.SQLCodeType.Column), column);
            s = s.Replace(Managers.Functions.GetSQLCode(crossSetting.Value, QuickReportCore.Managers.Functions.SQLCodeType.Column), value);
            return s;
        }

        /// <summary>
        /// 初始化树。
        /// </summary>
        private void InitTree()
        {
            if (!reportSetting.UseTree)
                return;
            tvReport.Nodes.Clear();
            Objects.Column treeRootColumn = new QuickReportCore.Objects.Column();
            treeRootColumn.ID = treeSetting.TreeRootCode;
            treeRootColumn.Name = treeSetting.TreeRootName;
            TreeNode treeRootNode = new TreeNode();
            treeRootNode.NodeFont = treeSetting.RootFont;
            treeRootNode.Text = treeRootColumn.Name;
            treeRootNode.Tag = treeRootColumn;
            treeRootNode.ImageIndex = treeSetting.RootIcon;
            treeRootNode.SelectedImageIndex = treeSetting.RootIcon + 18;
            tvReport.Nodes.Add(treeRootNode);

            string sql = Managers.Functions.TranslateTextWithSystemValue(treeSetting.SQL);
            if (treeSetting.GroupName.Trim() != string.Empty)
                sql = "Select " + treeSetting.Code + " , " + treeSetting.Name + " , " + treeSetting.GroupCode + " , " + treeSetting.GroupName + " From ( \n " + sql + " \n )";
            else
                sql = "Select " + treeSetting.Code + " , " + treeSetting.Name + " From ( \n " + sql + " \n )";
            quickReportManager.ExecQuery(sql);
            try
            {
                if (treeSetting.GroupName.Trim() == string.Empty)
                {
                    while (quickReportManager.Reader.Read())
                    {
                        Objects.Column c = new QuickReportCore.Objects.Column();
                        c.ID = quickReportManager.Reader[0].ToString();
                        c.Name = quickReportManager.Reader[1].ToString();
                        TreeNode node = new TreeNode();
                        node.NodeFont = treeSetting.NameFont;
                        node.Text = c.Name;
                        node.Tag = c;
                        node.ImageIndex = treeSetting.NameIcon;
                        node.SelectedImageIndex = treeSetting.NameIcon + 18;
                        treeRootNode.Nodes.Add(node);
                    }
                }
                else
                {
                    string groupNameCompare = compareString;
                    while (quickReportManager.Reader.Read())
                    {
                        Objects.Column c = new QuickReportCore.Objects.Column();
                        c.ID = quickReportManager.Reader[0].ToString();
                        c.Name = quickReportManager.Reader[1].ToString();
                        TreeNode node = new TreeNode();
                        node.NodeFont = treeSetting.NameFont;
                        node.Text = c.Name;
                        node.Tag = c;
                        node.ImageIndex = treeSetting.NameIcon;
                        node.SelectedImageIndex = treeSetting.NameIcon + 18;
                        string groupID = quickReportManager.Reader[2].ToString();
                        string groupName = quickReportManager.Reader[3].ToString();
                        if (groupName != groupNameCompare)
                        {
                            TreeNode n = new TreeNode();
                            Objects.Column gc = new QuickReportCore.Objects.Column();
                            gc.ID = groupID;
                            gc.Name = groupName;
                            n.Text = gc.Name;
                            n.Tag = gc;
                            n.ImageIndex = treeSetting.GroupIcon;
                            n.SelectedImageIndex = treeSetting.GroupIcon + 18;
                            n.NodeFont = treeSetting.GroupFont;
                            treeRootNode.Nodes.Add(n);
                            groupNameCompare = groupName;
                        }
                        treeRootNode.LastNode.Nodes.Add(node);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("加载树失败。" + e.Message);
            }
            finally
            {
                quickReportManager.Reader.Close();
            }
            if (treeSetting.TreeExpanded)
                tvReport.ExpandAll();
            else
                tvReport.CollapseAll();
            if (treeSetting.TreeMultiSelect)
                tvReport.CheckBoxes = true;
        }

        /// <summary>
        /// 查询。
        /// </summary>
        /// <returns>失败为-1,；成功为1；</returns>
        public int Query()
        {
            if (CheckInput() < 0)
                return 0;
            int i = 0;
            if (reportType == ReportType.Grid)
            {
                i= QueryGirdReport();
            }
            else if (reportType == ReportType.GeneralCross||reportType== ReportType.CustomCross)
            {
                i= QueryCrossReport();
            }
            if (i < 0)
                MessageBox.Show(Err);
            return i;
        }

        /// <summary>
        /// 查询网格报表。
        /// </summary>
        /// <returns>失败为-1,；成功为1；</returns>
        private int QueryGirdReport()
        {
            #region 需要被翻译的种类。
            Managers.Functions.SQLCodeType[] types = new QuickReportCore.Managers.Functions.SQLCodeType[1];
            types[0] = QuickReportCore.Managers.Functions.SQLCodeType.System;
            #endregion
            fpMain.SuspendLayout();
            fpMain.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            string sql = dataSourceSql;
            string where = ucReportConditionList.FullConditionString.Trim();
            if (where != string.Empty)
                sql += " \n Where " + where;
            sql = TranslateValue(sql, types);
            sql = TranslateTextWithTreeValueForSql(sql);//树单独翻译。因为节点为空时，应返回两个单引号"''"，防止SQL运行时报错。
            DataSet ds = null;
            WatchStart();
            quickReportManager.ExecQuery(sql, ref ds);
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
            {
                Err = "网格报表查询失败。";
                return -1;
            }
            fpMain_Sheet1.Rows.Count = 0;
            dvReport = new DataView(ds.Tables[0]);
            fpMain_Sheet1.DataSource = dvReport;
            #region 动态变量赋值。
            reportDataRowNumber = fpMain_Sheet1.Rows.Count;
            reportDataColumnNumer = htColumnsCustomShows.Count;
            #endregion
            SetColumnAttrToCustomAfterQuery();
            SetUnCustomColumnInvisbleAfterQuery();
            WatchStop();
            DoGirdReportSum();//执行各种合计，包括行分组合计与行总合计与列总合计，还有分组单独样式。
            if (!gridSetting.UseHeader)//当不是分组独立样式时，才手动添加表尾，因为需要复制表首、表尾时，会在DoGirdReportSum中处理。
            {
                SetColumnHeaderAfterQuery(MainOrDetail.Main);//刷新设置第一个表首，主要是将改变的各种变量刷新。
                AddBottomHeaderAfterQuery(MainOrDetail.Main);
                #region 只有在不是分组独立样式时，才设置间隔色
                if(reportSetting.UseEvenColor)
                    fpMain_Sheet1.AlternatingRows[1].BackColor = reportSetting.EvenColor;
                #endregion
            }
            #region 设置列的Border
            SetColumnBorder();
            #endregion
            #region 设置为完美列宽
            if (reportSetting.UseAutoColumnWidth)
            {
                saveProtector = true;
                for (int i = 1; i < fpMain_Sheet1.Columns.Count; i++)//之所以从1开始，是因为0被ColumnHeader占用，如果采用标准列宽，会被拉的很长。
                    fpMain_Sheet1.Columns[i].Width = fpMain_Sheet1.Columns[i].GetPreferredWidth();
                saveProtector = false;
            }
            #endregion
            fpMain.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            fpMain.ResumeLayout();
            return 1;
        }

        /// <summary>
        /// 计算网格报表的合计与分组合计。
        /// </summary>
        /// <returns>成功返回1；失败返回-1；</returns>
        private int DoGirdReportSum()
        {
            #region 如果使用小计，使用合计，不使用分组独立样式
            if (gridSetting.UseGroupSumRow&& columnsNeedColumnSums.Count > 0 && !gridSetting.UseHeader)
            {
                #region 先计算列的小计
                groupSums = new SortedList();
                groupSumsRowIndexMap = new SortedList();
                groupSumsRowList = new List<FarPoint.Win.Spread.Row>();
                int groupColumnIndex = (htColumnsBase[gridSetting.GroupSumRow] as Objects.Column).SortId;
                #region 进行小计
                string compareGroupName = compareString;
                int groupSumIndex = 0;//groupSum在groupSums中的序号。
                Hashtable groupSum = null;
                for (int i = 0; i < fpMain_Sheet1.Rows.Count; i++)
                {
                    if (compareGroupName != GetCellStringValue(fpMain_Sheet1.Cells[i, groupColumnIndex], string.Empty))
                    {
                        //只要第N+1行与第N行不同，则新建一个groupSum，然后将新的groupSum加入到groupSums中。
                        groupSum = new Hashtable();
                        groupSums.Add(groupSumIndex, groupSum);
                        groupSumsRowIndexMap.Add(groupSumIndex, i);//先添加进来第一个。
                        compareGroupName = GetCellStringValue(fpMain_Sheet1.Cells[i, groupColumnIndex], string.Empty);
                        groupSumIndex++;
                    }
                    //只要groupSum不是新的，那么这个foreach就会把每i行的columnsNeedColumnSums中的列的值往groupSum上叠加。
                    foreach (int columnIndex in columnsNeedColumnSums)
                    {
                        string value = GetCellStringValue(fpMain_Sheet1.Cells[i, columnIndex], "0");
                        if (value.Trim() == string.Empty)
                            value = "0";
                        if (!groupSum.Contains(columnIndex))//如果groupSum中不存在该列号，则新增。
                        {
                            groupSum.Add(columnIndex, Convert.ToDecimal(value));
                        }
                        else//如果groupSum中存在该列号，则将值叠加。
                        {
                            decimal d = Convert.ToDecimal(groupSum[columnIndex]);
                            d += Convert.ToDecimal(value);
                            groupSum[columnIndex] = d;
                        }
                    }
                    groupSumsRowIndexMap[groupSumIndex - 1] = i;//在此记录每个小计应该放在FP的哪个RowIndex上。
                }
                #endregion
                #endregion

                #region 再计算列的总合计
                //groupSums.Count为0时，则表示未进行小计，所以直接从界面上抓取数据。
                #region 若没有进行分组合计时
                if (groupSums.Count == 0)
                {
                    groupSum = new Hashtable();
                    for (int i = 0; i < fpMain_Sheet1.Rows.Count; i++)
                    {
                        foreach (int columnIndex in columnsNeedColumnSums)
                        {
                            string value = GetCellStringValue(fpMain_Sheet1.Cells[i, columnIndex], "0");
                            if (value.Trim() == string.Empty)
                                value = "0";
                            if (!groupSum.Contains(columnIndex))
                                groupSum.Add(columnIndex, Convert.ToDecimal(value));
                            else
                            {
                                decimal d = Convert.ToDecimal(groupSum[columnIndex]);
                                d += Convert.ToDecimal(value);
                                groupSum[columnIndex] = d;
                            }
                        }
                    }
                    if (fpMain_Sheet1.Rows.Count != 0)
                    {
                        groupSums.Add(0, groupSum);
                        groupSumsRowIndexMap.Add(0, fpMain_Sheet1.Rows.Count - 1);
                    }
                }
                #endregion
                #region 若进行了小计
                else
                {
                    groupSum = new Hashtable();
                    foreach (DictionaryEntry de in groupSums)
                    {
                        foreach (int columnIndex in columnsNeedColumnSums)
                        {
                            if (!groupSum.Contains(columnIndex))
                                groupSum.Add(columnIndex, Convert.ToDecimal(((Hashtable)de.Value)[columnIndex]));
                            else
                            {
                                decimal d = Convert.ToDecimal(groupSum[columnIndex]);
                                d += Convert.ToDecimal(((Hashtable)de.Value)[columnIndex]);
                                groupSum[columnIndex] = d;
                            }
                        }
                    }
                    groupSums.Add(groupSums.Count, groupSum);
                    groupSumsRowIndexMap.Add(groupSums.Count - 1, fpMain_Sheet1.Rows.Count - 1);
                }
                #endregion
                #endregion

                #region 将小计、合计添加到界面上
                int count = 0;
                groupColumnIndex = 0;//将小计合计显示在第1列。
                foreach (DictionaryEntry de in groupSums)
                {
                    //当groupSums.Count的数量大于1时，则添加小计。
                    if (count != groupSums.Count - 1)
                    {
                        int rowIndex = Convert.ToInt32(groupSumsRowIndexMap[de.Key]) + count + 1;
                        fpMain_Sheet1.AddUnboundRows(rowIndex, 1);
                        groupSumsRowList.Add(fpMain_Sheet1.Rows[rowIndex]);
                        Hashtable columnSums = de.Value as Hashtable;
                        bool useSameColumn = false;
                        foreach (DictionaryEntry columnSum in columnSums)
                        {
                            int column=Convert.ToInt32(columnSum.Key);
                            if (column == groupColumnIndex)
                                useSameColumn = true;//如果与合计小计使用相同列，则不使用“合计”“小计”字样。
                            fpMain_Sheet1.Cells[rowIndex, column].Value = columnSum.Value.ToString();
                        }
                        if (!useSameColumn)
                        {
                            fpMain_Sheet1.Cells[rowIndex, groupColumnIndex].CellType = textCelltype;
                            fpMain_Sheet1.Cells[rowIndex, groupColumnIndex].Value = gridSetting.RowGroupSumName;
                        }
                        fpMain_Sheet1.Rows[rowIndex].Font = defaultGroupSumFont;
                    }
                    //当groupSums.Count等于1或者已经到添加最后一个总合计时，添加总合计。
                    else
                    {
                        fpMain_Sheet1.AddUnboundRows(fpMain_Sheet1.Rows.Count, 1);
                        int rowIndex = fpMain_Sheet1.Rows.Count - 1;
                        groupSumsRowList.Add(fpMain_Sheet1.Rows[rowIndex]);
                        Hashtable columnSums = de.Value as Hashtable;
                        bool useSameColumn = false;
                        foreach (DictionaryEntry columnSum in columnSums)
                        {
                            int column = Convert.ToInt32(columnSum.Key);
                            if (column == groupColumnIndex)
                                useSameColumn = true;//如果与合计小计使用相同列，则不使用“合计”“小计”字样。
                            fpMain_Sheet1.Cells[rowIndex, column].Value = columnSum.Value.ToString();
                        }
                        if (!useSameColumn)
                        {
                            fpMain_Sheet1.Cells[rowIndex, groupColumnIndex].CellType = textCelltype;
                            fpMain_Sheet1.Cells[rowIndex, groupColumnIndex].Value = "合计";
                        }
                        fpMain_Sheet1.Rows[rowIndex].Font = defaultGroupSumFont;
                    }
                    count++;
                }
                haveChangedGroupSumColor = false;
                #endregion

                #region 再计算行的总合计
                if (columnsNeedRowSums.Count > 0)
                {
                    fpMain_Sheet1.Columns.Count++;
                    FarPoint.Win.Spread.Cell cell = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, fpMain_Sheet1.Columns.Count - 1];
                    cell.Value = "合计";
                    cell.Border = ColumnHeaderRightLineBorder;
                    fpMain_Sheet1.Columns[fpMain_Sheet1.Columns.Count - 1].CellType = rowSumNumberCellType;
                    for (int i = 0; i < fpMain_Sheet1.Rows.Count; i++)
                    {
                        decimal t = 0m;
                        foreach (int columnIndex in columnsNeedRowSums)
                        {
                            string s = GetCellStringValue(fpMain_Sheet1.Cells[i, columnIndex], "0");
                            t += Convert.ToDecimal(s);
                        }
                        fpMain_Sheet1.Cells[i, fpMain_Sheet1.Columns.Count - 1].Value = t.ToString();
                    }
                    fpMain_Sheet1.ColumnHeader.Columns[fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Font = defaultGroupSumFont;
                    fpMain_Sheet1.ColumnHeader.Columns[fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Width = fpMain_Sheet1.ColumnHeader.Columns[fpMain_Sheet1.ColumnHeader.Columns.Count - 1].GetPreferredWidth();
                    fpMain_Sheet1.Columns[fpMain_Sheet1.Columns.Count - 1].Font = defaultGroupSumFont;
                    for (int i = 0; i < headerSettingTop.Count; i++)
                    {
                        fpMain_Sheet1.ColumnHeader.Cells[i, 0].ColumnSpan = fpMain_Sheet1.ColumnHeader.Columns.Count;
                    }
                }
                #endregion
            }
            #endregion
            #region 如果使用小计，使用合计，使用分组独立样式
            else if (gridSetting.UseGroupSumRow&&columnsNeedColumnSums.Count > 0 && gridSetting.UseHeader)
            {
                #region 先计算列的小计
                groupSums = new SortedList();
                groupSumsRowIndexMap = new SortedList();
                int groupColumnIndex = (htColumnsBase[gridSetting.GroupSumRow] as Objects.Column).SortId;
                #region 进行小计
                string compareGroupName = compareString;
                int groupSumIndex = 0;//groupSum在groupSums中的序号。
                Hashtable groupSum = null;
                SortedList<int, List<Objects.Header>> slTopHeader = new SortedList<int, List<Objects.Header>>();//经过翻译的表首。
                SortedList<int, List<Objects.Header>> slBottomHeader = new SortedList<int, List<Objects.Header>>();//经过翻译的表尾。
                for (int i = 0; i < fpMain_Sheet1.Rows.Count; i++)
                {
                    if (compareGroupName != GetCellStringValue(fpMain_Sheet1.Cells[i, groupColumnIndex], string.Empty))
                    {
                        //只要第N+1行与第N行不同，则新建一个groupSum，然后将新的groupSum加入到groupSums中。
                        groupSum = new Hashtable();
                        groupSums.Add(groupSumIndex, groupSum);
                        groupSumsRowIndexMap.Add(groupSumIndex, i);//先添加进来第一个。
                        compareGroupName = GetCellStringValue(fpMain_Sheet1.Cells[i, groupColumnIndex], string.Empty);
                        #region 获得表首与表尾。现在看来，第一组的表首也需要自己添加了，不然分组以后，拖动右侧滚动条，最顶端的表首永远不动。
                        slTopHeader.Add(groupSumIndex, GetMainReportTranslatedColumnHeader(i));
                        slBottomHeader.Add(groupSumIndex, GetMainReportTranslatedBottomHeader(i));
                        #endregion
                        groupSumIndex++;
                    }
                    //只要groupSum不是新的，那么这个foreach就会把每i行的columnsNeedColumnSums中的列的值往groupSum上叠加。
                    foreach (int columnIndex in columnsNeedColumnSums)
                    {
                        string value = GetCellStringValue(fpMain_Sheet1.Cells[i, columnIndex], "0");
                        if (value.Trim() == string.Empty)
                            value = "0";
                        if (!groupSum.Contains(columnIndex))//如果groupSum中不存在该列号，则新增。
                        {
                            groupSum.Add(columnIndex, Convert.ToDecimal(value));
                        }
                        else//如果groupSum中存在该列号，则将值叠加。
                        {
                            decimal d = Convert.ToDecimal(groupSum[columnIndex]);
                            d += Convert.ToDecimal(value);
                            groupSum[columnIndex] = d;
                        }
                    }
                    groupSumsRowIndexMap[groupSumIndex - 1] = i;//在此记录每个小计应该放在FP的哪个RowIndex上。
                }
                #endregion
                #endregion

                //小计完毕后，不需要再计算总合计了，因为使用分组独立样式后，总合计就是小计。

                #region 将小计、合计添加到界面上
                int count = 0;
                groupColumnIndex = 0;//将小计合计显示在第1列。
                Hashtable headerIndexMap = new Hashtable();//为表首、表尾的插入记录位置。表首表尾需要再每一个合计后面增加，按照一个表尾、一个表首的次序添加。
                foreach (DictionaryEntry de in groupSums)
                {
                    int rowIndex = Convert.ToInt32(groupSumsRowIndexMap[de.Key]) + count + 1;
                    fpMain_Sheet1.AddUnboundRows(rowIndex, 2);//此处增加两行，因为有“小计”与“合计”。
                    headerIndexMap.Add(de.Key, rowIndex + 1);//记录每组表首表尾的插入点。实际上是每组表尾的插入点。知道了这个点，也就知道了下组表首的插入点。
                    Hashtable columnSums = de.Value as Hashtable;
                    bool useSameColumn = false;
                    foreach (DictionaryEntry columnSum in columnSums)
                    {
                        int column = Convert.ToInt32(columnSum.Key);
                        if (column == groupColumnIndex)
                            useSameColumn = true;//如果与合计小计使用相同列，则不使用“合计”“小计”字样。
                        #region 小计
                        fpMain_Sheet1.Cells[rowIndex, Convert.ToInt32(columnSum.Key)].Value = columnSum.Value.ToString();
                        #endregion
                        #region 合计
                        fpMain_Sheet1.Cells[rowIndex + 1, Convert.ToInt32(columnSum.Key)].Value = columnSum.Value.ToString();
                        #endregion
                    }
                    if (!useSameColumn)
                    {
                        fpMain_Sheet1.Cells[rowIndex, groupColumnIndex].CellType = textCelltype;
                        fpMain_Sheet1.Cells[rowIndex, groupColumnIndex].Value = gridSetting.RowGroupSumName;
                        fpMain_Sheet1.Cells[rowIndex + 1, groupColumnIndex].CellType = textCelltype;
                        fpMain_Sheet1.Cells[rowIndex + 1, groupColumnIndex].Value = "合计";
                    }
                    fpMain_Sheet1.Rows[rowIndex].Font = defaultGroupSumFont;
                    fpMain_Sheet1.Rows[rowIndex + 1].Font = defaultGroupSumFont;
                    count += 2;//因为每次都新增两行。
                }
                haveChangedGroupSumColor = false;
                #endregion

                #region 再计算行的总合计
                if (columnsNeedRowSums.Count > 0)
                {
                    fpMain_Sheet1.Columns.Count++;
                    FarPoint.Win.Spread.Cell cell = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, fpMain_Sheet1.Columns.Count - 1];
                    cell.Value = "合计";
                    cell.Border = ColumnHeaderRightLineBorder;
                    fpMain_Sheet1.Columns[fpMain_Sheet1.Columns.Count - 1].CellType = rowSumNumberCellType;
                    for (int i = 0; i < fpMain_Sheet1.Rows.Count; i++)
                    {
                        decimal t = 0m;
                        foreach (int columnIndex in columnsNeedRowSums)
                        {
                            string s = GetCellStringValue(fpMain_Sheet1.Cells[i, columnIndex], "0");
                            t += Convert.ToDecimal(s);
                        }
                        fpMain_Sheet1.Cells[i, fpMain_Sheet1.Columns.Count - 1].Value = t.ToString();
                    }
                    fpMain_Sheet1.ColumnHeader.Columns[fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Font = defaultGroupSumFont;
                    fpMain_Sheet1.ColumnHeader.Columns[fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Width = fpMain_Sheet1.ColumnHeader.Columns[fpMain_Sheet1.ColumnHeader.Columns.Count - 1].GetPreferredWidth();
                    fpMain_Sheet1.Columns[fpMain_Sheet1.Columns.Count - 1].Font = defaultGroupSumFont;
                    for (int i = 0; i < headerSettingTop.Count; i++)
                    {
                        fpMain_Sheet1.ColumnHeader.Cells[i, 0].ColumnSpan = fpMain_Sheet1.ColumnHeader.Columns.Count;
                    }
                }
                #endregion

                #region 增加每组的表首、表尾
                count = 0;
                foreach (KeyValuePair<int, List<QuickReportCore.Objects.Header>> bottomHeaders in slBottomHeader)
                {
                    int rowIndex = Convert.ToInt32(headerIndexMap[bottomHeaders.Key]) + count + 1;//bottomHeaders.Key组表尾插入点。
                    #region 插入第N组表尾
                    fpMain_Sheet1.AddUnboundRows(rowIndex, bottomHeaders.Value.Count);
                    foreach (Objects.Header h in bottomHeaders.Value)
                    {
                        AddAHeader(rowIndex + h.RowIndex, h, HeaderType.Bottom);
                    }
                    count += bottomHeaders.Value.Count;
                    rowIndex = Convert.ToInt32(headerIndexMap[bottomHeaders.Key]) + count + 1;//bottomHeaders.Key+1组表首插入点。
                    #region 插入第N+1组表首
                    List<Objects.Header> columnHeaders;
                    if (slTopHeader.ContainsKey(bottomHeaders.Key + 1))//因为表首永远比表尾少一个（参见前面的注释），所以需要判断。
                        columnHeaders = slTopHeader[bottomHeaders.Key + 1];
                    else
                        continue;

                    fpMain_Sheet1.AddUnboundRows(rowIndex, columnHeaders.Count + 1);//表首之所以需要+1，是因为需要复制列头。
                    foreach (Objects.Header h in columnHeaders)
                    {
                        AddAHeader(rowIndex + h.RowIndex, h, HeaderType.Top);
                    }
                    //复制列头。
                    for (int i = 0; i < fpMain_Sheet1.ColumnHeader.Columns.Count; i++)
                    {
                        fpMain_Sheet1.Rows[rowIndex + columnHeaders.Count].Tag = new Objects.Header();
                        fpMain_Sheet1.Rows[rowIndex + columnHeaders.Count].CellType = textCelltype;
                        fpMain_Sheet1.Cells[rowIndex + columnHeaders.Count, i].Value = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, i].Value;
                        fpMain_Sheet1.Cells[rowIndex + columnHeaders.Count, i].Border = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, i].Border;
                        fpMain_Sheet1.Cells[rowIndex + columnHeaders.Count, i].Font = defaultColumnHeaderFont;
                        fpMain_Sheet1.Cells[rowIndex + columnHeaders.Count, i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        fpMain_Sheet1.Cells[rowIndex + columnHeaders.Count, i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    }
                    count += columnHeaders.Count + 1;//复制列头，所以这里也要+1。
                    #endregion
                    #endregion
                }
                //增加第一组的表首。并隐藏原有的表首。之所以这么做，是因为第一组的表首默认是用ColumnHeader展现的，这个ColumnHeader是永远都在
                //前端显示的，也就是说无论怎么滚动右侧的滚动条，它永远显示在那里。如果进行分组独立样式的话，就乱套了。所以在这里，需要掩藏ColumnHeader，
                //并且手动添加第一组的表首。
                #region 增加第一组的表首 
                if (slTopHeader.Count > 0)
                {
                    fpMain_Sheet1.ColumnHeader.Visible = false;
                    fpMain_Sheet1.AddUnboundRows(0, slTopHeader[0].Count + 1);//+1是因为有列头。
                    count = 0;
                    foreach (Objects.Header h in slTopHeader[0])
                    {
                        AddAHeader(count, h, HeaderType.Top);
                        count++;
                    }
                    //复制列头。
                    for (int i = 0; i < fpMain_Sheet1.ColumnHeader.Columns.Count; i++)
                    {
                        fpMain_Sheet1.Rows[count].Tag = new Objects.Header();
                        fpMain_Sheet1.Rows[count].CellType = textCelltype;
                        fpMain_Sheet1.Cells[count, i].Value = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, i].Value;
                        fpMain_Sheet1.Cells[count, i].Border = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, i].Border;
                        fpMain_Sheet1.Cells[count, i].Font = defaultColumnHeaderFont;
                        fpMain_Sheet1.Cells[count, i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        fpMain_Sheet1.Cells[count, i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    }
                }
                #endregion
                #endregion
            }
            #endregion
            #region 如果不使用小计，不使用合计，不使用分组独立样式 不使用合计，就肯定不使用小计了。所以只判断不使用合计即可。
            else if (columnsNeedColumnSums.Count == 0 && !gridSetting.UseHeader)
            { 
               //那就什么也不用做了。
            }
            #endregion
            #region 如果不使用小计，不使用合计，使用分组独立样式 不使用合计，就肯定不使用小计了。所以只判断不使用合计即可。
            else if (columnsNeedColumnSums.Count == 0 && gridSetting.UseHeader)
            {
                #region 先进行分组
                int groupColumnIndex = (htColumnsBase[gridSetting.GroupSumRow] as Objects.Column).SortId;
                #region 进行分组
                int groupSumIndex = 0;
                string compareGroupName = compareString;
                SortedList<int, List<Objects.Header>> slTopHeader = new SortedList<int, List<Objects.Header>>();//经过翻译的表首。
                SortedList<int, List<Objects.Header>> slBottomHeader = new SortedList<int, List<Objects.Header>>();//经过翻译的表尾。
                Hashtable headerIndexMap = new Hashtable();//为表首、表尾的插入记录位置。表首表尾需要再每一个合计后面增加，按照一个表尾、一个表首的次序添加。
                for (int i = 0; i < fpMain_Sheet1.Rows.Count; i++)
                {
                    if (compareGroupName != GetCellStringValue(fpMain_Sheet1.Cells[i, groupColumnIndex], string.Empty))
                    {
                        compareGroupName = GetCellStringValue(fpMain_Sheet1.Cells[i, groupColumnIndex], string.Empty);
                        #region 获得表首与表尾。现在看来，第一组的表首也需要自己添加了，不然分组以后，拖动右侧滚动条，最顶端的表首永远不动。
                        slTopHeader.Add(groupSumIndex, GetMainReportTranslatedColumnHeader(i));
                        slBottomHeader.Add(groupSumIndex, GetMainReportTranslatedBottomHeader(i));
                        #endregion
                        headerIndexMap.Add(groupSumIndex, i);
                        groupSumIndex++;
                    }
                    headerIndexMap[groupSumIndex - 1] = i;
                }
                #endregion
                #endregion

                #region 再计算行的总合计
                if (columnsNeedRowSums.Count > 0)
                {
                    fpMain_Sheet1.Columns.Count++;
                    FarPoint.Win.Spread.Cell cell = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, fpMain_Sheet1.Columns.Count - 1];
                    cell.Value = "合计";
                    cell.Border = ColumnHeaderRightLineBorder;
                    fpMain_Sheet1.Columns[fpMain_Sheet1.Columns.Count - 1].CellType = rowSumNumberCellType;
                    for (int i = 0; i < fpMain_Sheet1.Rows.Count; i++)
                    {
                        decimal t = 0m;
                        foreach (int columnIndex in columnsNeedRowSums)
                        {
                            string s = GetCellStringValue(fpMain_Sheet1.Cells[i, columnIndex], "0");
                            t += Convert.ToDecimal(s);
                        }
                        fpMain_Sheet1.Cells[i, fpMain_Sheet1.Columns.Count - 1].Value = t.ToString();
                    }
                    fpMain_Sheet1.ColumnHeader.Columns[fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Font = defaultGroupSumFont;
                    fpMain_Sheet1.ColumnHeader.Columns[fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Width = fpMain_Sheet1.ColumnHeader.Columns[fpMain_Sheet1.ColumnHeader.Columns.Count - 1].GetPreferredWidth();
                    fpMain_Sheet1.Columns[fpMain_Sheet1.Columns.Count - 1].Font = defaultGroupSumFont;
                    for (int i = 0; i < headerSettingTop.Count; i++)
                    {
                        fpMain_Sheet1.ColumnHeader.Cells[i, 0].ColumnSpan = fpMain_Sheet1.ColumnHeader.Columns.Count;
                    }
                }
                #endregion

                #region 增加每组的表首、表尾
                int count = 0;
                foreach (KeyValuePair<int, List<QuickReportCore.Objects.Header>> bottomHeaders in slBottomHeader)
                {
                    int rowIndex = Convert.ToInt32(headerIndexMap[bottomHeaders.Key]) + count + 1;//bottomHeaders.Key组表尾插入点。
                    #region 插入第N组表尾
                    fpMain_Sheet1.AddUnboundRows(rowIndex, bottomHeaders.Value.Count);
                    foreach (Objects.Header h in bottomHeaders.Value)
                    {
                        AddAHeader(rowIndex + h.RowIndex, h, HeaderType.Bottom);
                    }
                    count += bottomHeaders.Value.Count;
                    rowIndex = Convert.ToInt32(headerIndexMap[bottomHeaders.Key]) + count + 1;//bottomHeaders.Key+1组表首插入点。
                    #region 插入第N+1组表首
                    List<Objects.Header> columnHeaders;
                    if (slTopHeader.ContainsKey(bottomHeaders.Key + 1))//因为表首永远比表尾少一个（参见前面的注释），所以需要判断。
                        columnHeaders = slTopHeader[bottomHeaders.Key + 1];
                    else
                        continue;
                    fpMain_Sheet1.AddUnboundRows(rowIndex, columnHeaders.Count + 1);//表首之所以需要+1，是因为需要复制列头。
                    foreach (Objects.Header h in columnHeaders)
                    {
                        AddAHeader(rowIndex + h.RowIndex, h, HeaderType.Top);
                    }
                    //复制列头。
                    for (int i = 0; i < fpMain_Sheet1.ColumnHeader.Columns.Count; i++)
                    {
                        fpMain_Sheet1.Rows[rowIndex + columnHeaders.Count].Tag = new Objects.Header();
                        fpMain_Sheet1.Rows[rowIndex + columnHeaders.Count].CellType = textCelltype;
                        fpMain_Sheet1.Cells[rowIndex + columnHeaders.Count, i].Value = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, i].Value;
                        fpMain_Sheet1.Cells[rowIndex + columnHeaders.Count, i].Border = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, i].Border;
                        fpMain_Sheet1.Cells[rowIndex + columnHeaders.Count, i].Font = defaultColumnHeaderFont;
                        fpMain_Sheet1.Cells[rowIndex + columnHeaders.Count, i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        fpMain_Sheet1.Cells[rowIndex + columnHeaders.Count, i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    }
                    count += columnHeaders.Count + 1;//复制列头，所以这里也要+1。
                    #endregion
                    #endregion
                }
                //增加第一组的表首。并隐藏原有的表首。之所以这么做，是因为第一组的表首默认是用ColumnHeader展现的，这个ColumnHeader是永远都在
                //前端显示的，也就是说无论怎么滚动右侧的滚动条，它永远显示在那里。如果进行分组独立样式的话，就乱套了。所以在这里，需要掩藏ColumnHeader，
                //并且手动添加第一组的表首。
                #region 增加第一组的表首    
                if (slTopHeader.Count > 0)
                {
                    fpMain_Sheet1.ColumnHeader.Visible = false;
                    fpMain_Sheet1.AddUnboundRows(0, slTopHeader[0].Count + 1);//+1是因为有列头。
                    count = 0;
                    foreach (Objects.Header h in slTopHeader[0])
                    {
                        AddAHeader(count, h, HeaderType.Top);
                        count++;
                    }
                    //复制列头。
                    for (int i = 0; i < fpMain_Sheet1.ColumnHeader.Columns.Count; i++)
                    {
                        fpMain_Sheet1.Rows[count].Tag = new Objects.Header();
                        fpMain_Sheet1.Rows[count].CellType = textCelltype;
                        fpMain_Sheet1.Cells[count, i].Value = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, i].Value;
                        fpMain_Sheet1.Cells[count, i].Border = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, i].Border;
                        fpMain_Sheet1.Cells[count, i].Font = defaultColumnHeaderFont;
                        fpMain_Sheet1.Cells[count, i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        fpMain_Sheet1.Cells[count, i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    }
                }
                #endregion
                #endregion
            }
            #endregion
            #region 如果不使用小计，使用合计，不使用分组独立样式
            else if (!gridSetting.UseGroupSumRow && columnsNeedColumnSums.Count > 0 && !gridSetting.UseHeader)
            {
                groupSums = new SortedList();
                groupSumsRowIndexMap = new SortedList();
                groupSumsRowList = new List<FarPoint.Win.Spread.Row>();
                int groupColumnIndex = 0;

                #region 再计算列的总合计
                Hashtable groupSum = new Hashtable();
                for (int i = 0; i < fpMain_Sheet1.Rows.Count; i++)
                {
                    foreach (int columnIndex in columnsNeedColumnSums)
                    {
                        string value = GetCellStringValue(fpMain_Sheet1.Cells[i, columnIndex], "0");
                        if (value.Trim() == string.Empty)
                            value = "0";
                        if (!groupSum.Contains(columnIndex))
                            groupSum.Add(columnIndex, Convert.ToDecimal(value));
                        else
                        {
                            decimal d = Convert.ToDecimal(groupSum[columnIndex]);
                            d += Convert.ToDecimal(value);
                            groupSum[columnIndex] = d;
                        }
                    }
                }
                if (fpMain_Sheet1.Rows.Count != 0)
                {
                    groupSums.Add(0, groupSum);
                    groupSumsRowIndexMap.Add(0, fpMain_Sheet1.Rows.Count - 1);
                }
                #endregion

                #region 将合计添加到界面上
                foreach (DictionaryEntry de in groupSums)
                {
                    fpMain_Sheet1.AddUnboundRows(fpMain_Sheet1.Rows.Count, 1);
                    int rowIndex = fpMain_Sheet1.Rows.Count - 1;
                    groupSumsRowList.Add(fpMain_Sheet1.Rows[rowIndex]);
                    Hashtable columnSums = de.Value as Hashtable;
                    bool useSameColumn = false;
                    foreach (DictionaryEntry columnSum in columnSums)
                    {
                        int column = Convert.ToInt32(columnSum.Key);
                        if (column == groupColumnIndex)
                            useSameColumn = true;//如果与合计小计使用相同列，则不使用“合计”“小计”字样。
                        fpMain_Sheet1.Cells[rowIndex, Convert.ToInt32(columnSum.Key)].Value = columnSum.Value.ToString();
                    }
                    if (!useSameColumn)
                    {
                        fpMain_Sheet1.Cells[rowIndex, groupColumnIndex].CellType = textCelltype;
                        fpMain_Sheet1.Cells[rowIndex, groupColumnIndex].Value = "合计";
                    }
                    fpMain_Sheet1.Rows[rowIndex].Font = defaultGroupSumFont;
                }
                haveChangedGroupSumColor = false;
                #endregion

                #region 再计算行的总合计
                if (columnsNeedRowSums.Count > 0)
                {
                    fpMain_Sheet1.Columns.Count++;
                    FarPoint.Win.Spread.Cell cell = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, fpMain_Sheet1.Columns.Count - 1];
                    cell.Value = "合计";
                    cell.Border = ColumnHeaderRightLineBorder;
                    fpMain_Sheet1.Columns[fpMain_Sheet1.Columns.Count - 1].CellType = rowSumNumberCellType;
                    for (int i = 0; i < fpMain_Sheet1.Rows.Count; i++)
                    {
                        decimal t = 0m;
                        foreach (int columnIndex in columnsNeedRowSums)
                        {
                            string s = GetCellStringValue(fpMain_Sheet1.Cells[i, columnIndex], "0");
                            t += Convert.ToDecimal(s);
                        }
                        fpMain_Sheet1.Cells[i, fpMain_Sheet1.Columns.Count - 1].Value = t.ToString();
                    }
                    fpMain_Sheet1.ColumnHeader.Columns[fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Font = defaultGroupSumFont;
                    fpMain_Sheet1.ColumnHeader.Columns[fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Width = fpMain_Sheet1.ColumnHeader.Columns[fpMain_Sheet1.ColumnHeader.Columns.Count - 1].GetPreferredWidth();
                    fpMain_Sheet1.Columns[fpMain_Sheet1.Columns.Count - 1].Font = defaultGroupSumFont;
                    for (int i = 0; i < headerSettingTop.Count; i++)
                    {
                        fpMain_Sheet1.ColumnHeader.Cells[i, 0].ColumnSpan = fpMain_Sheet1.ColumnHeader.Columns.Count;
                    }
                }
                #endregion
            }
            #endregion
            #region 如果不使用小计，使用合计，使用分组独立样式
            else if (!gridSetting.UseGroupSumRow && columnsNeedColumnSums.Count > 0 && gridSetting.UseHeader)
            {
                #region 先计算列的小计
                groupSums = new SortedList();
                groupSumsRowIndexMap = new SortedList();
                int groupColumnIndex = (htColumnsBase[gridSetting.GroupSumRow] as Objects.Column).SortId;
                #region 进行小计
                string compareGroupName = compareString;
                int groupSumIndex = 0;//groupSum在groupSums中的序号。
                Hashtable groupSum = null;
                SortedList<int, List<Objects.Header>> slTopHeader = new SortedList<int, List<Objects.Header>>();//经过翻译的表首。
                SortedList<int, List<Objects.Header>> slBottomHeader = new SortedList<int, List<Objects.Header>>();//经过翻译的表尾。
                for (int i = 0; i < fpMain_Sheet1.Rows.Count; i++)
                {
                    if (compareGroupName != GetCellStringValue(fpMain_Sheet1.Cells[i, groupColumnIndex], string.Empty))
                    {
                        //只要第N+1行与第N行不同，则新建一个groupSum，然后将新的groupSum加入到groupSums中。
                        groupSum = new Hashtable();
                        groupSums.Add(groupSumIndex, groupSum);
                        groupSumsRowIndexMap.Add(groupSumIndex, i);//先添加进来第一个。
                        compareGroupName = GetCellStringValue(fpMain_Sheet1.Cells[i, groupColumnIndex], string.Empty);
                        #region 获得表首与表尾。现在看来，第一组的表首也需要自己添加了，不然分组以后，拖动右侧滚动条，最顶端的表首永远不动。
                        slTopHeader.Add(groupSumIndex, GetMainReportTranslatedColumnHeader(i));
                        slBottomHeader.Add(groupSumIndex, GetMainReportTranslatedBottomHeader(i));
                        #endregion
                        groupSumIndex++;
                    }
                    //只要groupSum不是新的，那么这个foreach就会把每i行的columnsNeedColumnSums中的列的值往groupSum上叠加。
                    foreach (int columnIndex in columnsNeedColumnSums)
                    {
                        string value = GetCellStringValue(fpMain_Sheet1.Cells[i, columnIndex], "0");
                        if (value.Trim() == string.Empty)
                            value = "0";
                        if (!groupSum.Contains(columnIndex))//如果groupSum中不存在该列号，则新增。
                        {
                            groupSum.Add(columnIndex, Convert.ToDecimal(value));
                        }
                        else//如果groupSum中存在该列号，则将值叠加。
                        {
                            decimal d = Convert.ToDecimal(groupSum[columnIndex]);
                            d += Convert.ToDecimal(value);
                            groupSum[columnIndex] = d;
                        }
                    }
                    groupSumsRowIndexMap[groupSumIndex - 1] = i;//在此记录每个小计应该放在FP的哪个RowIndex上。
                }
                #endregion
                #endregion

                //小计完毕后，不需要再计算总合计了，因为使用分组独立样式后，总合计就是小计。

                #region 将合计添加到界面上
                int count = 0;
                groupColumnIndex = 0;//将小计合计显示在第1列。
                Hashtable headerIndexMap = new Hashtable();//为表首、表尾的插入记录位置。表首表尾需要再每一个合计后面增加，按照一个表尾、一个表首的次序添加。
                foreach (DictionaryEntry de in groupSums)
                {
                    int rowIndex = Convert.ToInt32(groupSumsRowIndexMap[de.Key]) + count + 1;
                    fpMain_Sheet1.AddUnboundRows(rowIndex, 1);
                    headerIndexMap.Add(de.Key, rowIndex);//记录每组表首表尾的插入点。实际上是每组表尾的插入点。知道了这个点，也就知道了下组表首的插入点。
                    Hashtable columnSums = de.Value as Hashtable;
                    bool useSameColumn = false;
                    foreach (DictionaryEntry columnSum in columnSums)
                    {
                        int column = Convert.ToInt32(columnSum.Key);
                        if (column == groupColumnIndex)
                            useSameColumn = true;//如果与合计小计使用相同列，则不使用“合计”“小计”字样。
                        #region 合计  
                        fpMain_Sheet1.Cells[rowIndex, Convert.ToInt32(columnSum.Key)].Value = columnSum.Value.ToString();
                        #endregion
                    }
                    if (!useSameColumn)
                    {
                        fpMain_Sheet1.Cells[rowIndex, groupColumnIndex].CellType = textCelltype;
                        fpMain_Sheet1.Cells[rowIndex, groupColumnIndex].Value = "合计";
                    }
                    fpMain_Sheet1.Rows[rowIndex].Font = defaultGroupSumFont;
                    count++;
                }
                haveChangedGroupSumColor = false;
                #endregion

                #region 再计算行的总合计
                if (columnsNeedRowSums.Count > 0)
                {
                    fpMain_Sheet1.Columns.Count++;
                    FarPoint.Win.Spread.Cell cell = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, fpMain_Sheet1.Columns.Count - 1];
                    cell.Value = "合计";
                    cell.Border = ColumnHeaderRightLineBorder;
                    fpMain_Sheet1.Columns[fpMain_Sheet1.Columns.Count - 1].CellType = rowSumNumberCellType;
                    for (int i = 0; i < fpMain_Sheet1.Rows.Count; i++)
                    {
                        decimal t = 0m;
                        foreach (int columnIndex in columnsNeedRowSums)
                        {
                            string s = GetCellStringValue(fpMain_Sheet1.Cells[i, columnIndex], "0");
                            t += Convert.ToDecimal(s);
                        }
                        fpMain_Sheet1.Cells[i, fpMain_Sheet1.Columns.Count - 1].Value = t.ToString();
                    }
                    fpMain_Sheet1.ColumnHeader.Columns[fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Font = defaultGroupSumFont;
                    fpMain_Sheet1.ColumnHeader.Columns[fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Width = fpMain_Sheet1.ColumnHeader.Columns[fpMain_Sheet1.ColumnHeader.Columns.Count - 1].GetPreferredWidth();
                    fpMain_Sheet1.Columns[fpMain_Sheet1.Columns.Count - 1].Font = defaultGroupSumFont;
                    for (int i = 0; i < headerSettingTop.Count; i++)
                    {
                        fpMain_Sheet1.ColumnHeader.Cells[i, 0].ColumnSpan = fpMain_Sheet1.ColumnHeader.Columns.Count;
                    }
                }
                #endregion

                #region 增加每组的表首、表尾
                count = 0;
                foreach (KeyValuePair<int, List<QuickReportCore.Objects.Header>> bottomHeaders in slBottomHeader)
                {
                    int rowIndex = Convert.ToInt32(headerIndexMap[bottomHeaders.Key]) + count + 1;//bottomHeaders.Key组表尾插入点。
                    #region 插入第N组表尾
                    fpMain_Sheet1.AddUnboundRows(rowIndex, bottomHeaders.Value.Count);
                    foreach (Objects.Header h in bottomHeaders.Value)
                    {
                        AddAHeader(rowIndex + h.RowIndex, h, HeaderType.Bottom);
                    }
                    count += bottomHeaders.Value.Count;
                    rowIndex = Convert.ToInt32(headerIndexMap[bottomHeaders.Key]) + count + 1;//bottomHeaders.Key+1组表首插入点。
                    #region 插入第N+1组表首
                    List<Objects.Header> columnHeaders;
                    if (slTopHeader.ContainsKey(bottomHeaders.Key + 1))//因为表首永远比表尾少一个（参见前面的注释），所以需要判断。
                        columnHeaders = slTopHeader[bottomHeaders.Key + 1];
                    else
                        continue;

                    fpMain_Sheet1.AddUnboundRows(rowIndex, columnHeaders.Count + 1);//表首之所以需要+1，是因为需要复制列头。
                    foreach (Objects.Header h in columnHeaders)
                    {
                        AddAHeader(rowIndex + h.RowIndex, h, HeaderType.Top);
                    }
                    //复制列头。
                    for (int i = 0; i < fpMain_Sheet1.ColumnHeader.Columns.Count; i++)
                    {
                        fpMain_Sheet1.Rows[rowIndex + columnHeaders.Count].Tag = new Objects.Header();
                        fpMain_Sheet1.Rows[rowIndex + columnHeaders.Count].CellType = textCelltype;
                        fpMain_Sheet1.Cells[rowIndex + columnHeaders.Count, i].Value = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, i].Value;
                        fpMain_Sheet1.Cells[rowIndex + columnHeaders.Count, i].Border = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, i].Border;
                        fpMain_Sheet1.Cells[rowIndex + columnHeaders.Count, i].Font = defaultColumnHeaderFont;
                        fpMain_Sheet1.Cells[rowIndex + columnHeaders.Count, i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        fpMain_Sheet1.Cells[rowIndex + columnHeaders.Count, i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    }
                    count += columnHeaders.Count + 1;//复制列头，所以这里也要+1。
                    #endregion
                    #endregion
                }
                //增加第一组的表首。并隐藏原有的表首。之所以这么做，是因为第一组的表首默认是用ColumnHeader展现的，这个ColumnHeader是永远都在
                //前端显示的，也就是说无论怎么滚动右侧的滚动条，它永远显示在那里。如果进行分组独立样式的话，就乱套了。所以在这里，需要掩藏ColumnHeader，
                //并且手动添加第一组的表首。
                #region 增加第一组的表首
                if (slTopHeader.Count > 0)
                {
                    fpMain_Sheet1.ColumnHeader.Visible = false;
                    fpMain_Sheet1.AddUnboundRows(0, slTopHeader[0].Count + 1);//+1是因为有列头。
                    count = 0;
                    foreach (Objects.Header h in slTopHeader[0])
                    {
                        AddAHeader(count, h, HeaderType.Top);
                        count++;
                    }
                    //复制列头。
                    for (int i = 0; i < fpMain_Sheet1.ColumnHeader.Columns.Count; i++)
                    {
                        fpMain_Sheet1.Rows[count].Tag = new Objects.Header();
                        fpMain_Sheet1.Rows[count].CellType = textCelltype;
                        fpMain_Sheet1.Cells[count, i].Value = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, i].Value;
                        fpMain_Sheet1.Cells[count, i].Border = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, i].Border;
                        fpMain_Sheet1.Cells[count, i].Font = defaultColumnHeaderFont;
                        fpMain_Sheet1.Cells[count, i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        fpMain_Sheet1.Cells[count, i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    }
                }
                #endregion
                #endregion
            }
            #endregion
            return 1;
        }

        public enum HeaderType
        { 
            Top,
            Bottom
        }

        private void AddAHeader(int rowIndex, Objects.Header header,HeaderType type)
        {
            if (type == HeaderType.Top)
            {
                if (fpMain_Sheet1.Columns.Count == 0)
                    fpMain_Sheet1.Columns.Count = 1;
                FarPoint.Win.Spread.Cell cell = fpMain_Sheet1.Cells[rowIndex, 0];
                cell.CellType = textCelltype;
                cell.ColumnSpan = fpMain_Sheet1.Columns.Count;
                cell.Value = header.Text;
                cell.Font = header.Font;
                cell.ForeColor = header.Color;
                cell.HorizontalAlignment = header.HAligment;
                cell.VerticalAlignment = header.VAligment;
                cell.Row.Border = bottomHeaderBorder;
                fpMain_Sheet1.Rows[rowIndex].Height = header.Height;
                fpMain_Sheet1.Rows[rowIndex].Tag = header;
            }
            else if (type == HeaderType.Bottom)
            { 
                if (fpMain_Sheet1.Columns.Count == 0)
                    fpMain_Sheet1.Columns.Count = 1;
                FarPoint.Win.Spread.Cell cell = fpMain_Sheet1.Cells[rowIndex, 0];
                cell.CellType = textCelltype;
                cell.ColumnSpan = fpMain_Sheet1.Columns.Count;
                cell.Value = header.Text;
                cell.Font = header.Font;
                cell.ForeColor = header.Color;
                cell.HorizontalAlignment = header.HAligment;
                cell.VerticalAlignment = header.VAligment;
                cell.Row.Border = bottomHeaderBorder;
                fpMain_Sheet1.Rows[rowIndex].Height = header.Height;
                fpMain_Sheet1.Rows[rowIndex].Tag = header;
            }
        }

        /// <summary>
        /// 查询非自定义的交叉报表。
        /// </summary>
        /// <returns>失败为-1,；成功为1；</returns>
        private int QueryCrossReport()
        {
            #region 需要被翻译的种类。
            Managers.Functions.SQLCodeType[] types = new QuickReportCore.Managers.Functions.SQLCodeType[1];
            types[0] = QuickReportCore.Managers.Functions.SQLCodeType.System;
            #endregion
            fpMain.SuspendLayout();
            fpMain.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

            string sqlBase = "Select " + " {0} " + " From ( \n" + reportSetting.SQL + " \n )";
            string where = ucReportConditionList.FullConditionString.Trim();
            if (where != string.Empty)
                sqlBase += " \n Where " + where + " {1} ";
            sqlBase = TranslateValue(sqlBase, types);
            sqlBase = TranslateTextWithTreeValueForSql(sqlBase);//树单独翻译。因为节点为空时，应返回两个单引号"''"，防止SQL运行时报错。

            Hashtable htColumnIndexMap = new Hashtable();
            Hashtable htColumnGroupSumIndexMap = new Hashtable();
            Hashtable htRowIndexMap = new Hashtable();
            Hashtable htRowGroupSumIndexMap = new Hashtable();
            WatchStart();

            #region 初始化列与列小计
            #region GeneralCrossReport
            if (reportType == ReportType.GeneralCross)
            {
                #region 初始化列与列小计
                if (crossSetting.GroupSumColumn != string.Empty)
                {
                    string sql = sqlBase;
                    sql = string.Format(sql, " Distinct " + crossSetting.GroupSumColumn + " , " + crossSetting.Column, " Order By " + crossSetting.GroupSumColumn);
                    quickReportManager.ExecQuery(sql);
                    try
                    {
                        ClearReportFarpoint();
                        fpMain_Sheet1.ColumnHeader.Rows.Count = 1;
                        fpMain_Sheet1.ColumnHeader.Columns.Count++;
                        fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Value = crossSetting.Row;
                        string compareForColumnGroup = compareString;
                        Objects.Column column = new QuickReportCore.Objects.Column();
                        while (quickReportManager.Reader.Read())
                        {
                            string group = quickReportManager.Reader[0].ToString();
                            string columnName = quickReportManager.Reader[1].ToString();
                            if (htColumnIndexMap.Contains(columnName))
                                continue;
                            fpMain_Sheet1.ColumnHeader.Columns.Count++;
                            fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Value = columnName;
                            htColumnIndexMap.Add(columnName, fpMain_Sheet1.ColumnHeader.Columns.Count - 1);
                            if (compareForColumnGroup != group && compareForColumnGroup != compareString)
                            {
                                fpMain_Sheet1.ColumnHeader.Columns.Count--;//先清除刚刚添加进来的数据。
                                fpMain_Sheet1.ColumnHeader.Columns.Count++;
                                column.SortId = fpMain_Sheet1.ColumnHeader.Columns.Count - 1;
                                column = new QuickReportCore.Objects.Column();
                                fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Value = crossSetting.GroupSumColumnName;
                                fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Font = defaultGroupSumFont;
                                #region 重新添加一次
                                fpMain_Sheet1.ColumnHeader.Columns.Count++;
                                fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Value = columnName;
                                htColumnIndexMap[columnName] = fpMain_Sheet1.ColumnHeader.Columns.Count - 1;
                                #endregion
                            }
                            compareForColumnGroup = group;
                            htColumnGroupSumIndexMap.Add(columnName, column);
                        }
                        #region 最后一列
                        fpMain_Sheet1.ColumnHeader.Columns.Count++;
                        column.SortId = fpMain_Sheet1.ColumnHeader.Columns.Count - 1;
                        fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Value = crossSetting.GroupSumColumnName;
                        fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Font = defaultGroupSumFont;
                        #endregion
                        if (crossSetting.RowSum)
                        {
                            fpMain_Sheet1.ColumnHeader.Columns.Count++;
                            fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Value = "合计";
                            fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Font = defaultGroupSumFont;
                        }
                    }
                    catch (Exception e)
                    {
                        Err = "加载交叉报表列失败。" + e.Message;
                        return -1;
                    }
                    finally
                    {
                        quickReportManager.Reader.Close();
                    }
                }
                else
                {
                    string sql = sqlBase;
                    sql = string.Format(sql, " Distinct " + crossSetting.Column, " Order By " + crossSetting.Column);
                    quickReportManager.ExecQuery(sql);
                    try
                    {
                        ClearReportFarpoint();
                        fpMain_Sheet1.ColumnHeader.Rows.Count = 1;
                        fpMain_Sheet1.ColumnHeader.Columns.Count++;
                        fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Value = crossSetting.Row;
                        while (quickReportManager.Reader.Read())
                        {
                            string columnName = quickReportManager.Reader[0].ToString();
                            if (htColumnIndexMap.Contains(columnName))
                                continue;
                            fpMain_Sheet1.ColumnHeader.Columns.Count++;
                            fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Value = columnName;
                            htColumnIndexMap.Add(columnName, fpMain_Sheet1.ColumnHeader.Columns.Count - 1);
                        }
                        if (crossSetting.RowSum)
                        {
                            fpMain_Sheet1.ColumnHeader.Columns.Count++;
                            fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Value = "合计";
                            fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Font = defaultGroupSumFont;
                        }
                    }
                    catch (Exception e)
                    {
                        Err = "加载交叉报表列失败。" + e.Message;
                        return -1;
                    }
                    finally
                    {
                        quickReportManager.Reader.Close();
                    }
                }
                #endregion
            }
            #endregion
            #region CustomCrossReport
            else if (reportType == ReportType.CustomCross)
            {
                #region 初始化列与列小计
                if (crossSetting.GroupSumCustomColumn != string.Empty)
                {
                    ClearReportFarpoint();
                    fpMain_Sheet1.ColumnHeader.Rows.Count = 1;
                    fpMain_Sheet1.ColumnHeader.Columns.Count++;
                    fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Value = crossSetting.Row;
                    string compareForColumnGroup = compareString;
                    Objects.Column column = new QuickReportCore.Objects.Column();

                    foreach (DictionaryEntry de in slColumnsCustomShows)
                    {
                        string group = (de.Key as Objects.Column).GroupName;
                        string columnName = de.Value.ToString();
                        if (htColumnIndexMap.Contains(columnName))
                            continue;
                        fpMain_Sheet1.ColumnHeader.Columns.Count++;
                        fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Value = columnName;
                        fpMain_Sheet1.ColumnHeader.Columns[fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Tag = de.Key;//因为交叉报表在查询前都会清空FP，所以导致列的Tag被删除，这里重新添加。
                        htColumnIndexMap.Add(columnName, fpMain_Sheet1.ColumnHeader.Columns.Count - 1);
                        if (compareForColumnGroup != group && compareForColumnGroup != compareString)
                        {
                            fpMain_Sheet1.ColumnHeader.Columns.Count--;//先清除刚刚添加进来的数据。
                            fpMain_Sheet1.ColumnHeader.Columns.Count++;
                            column.SortId = fpMain_Sheet1.ColumnHeader.Columns.Count - 1;
                            column = new QuickReportCore.Objects.Column();
                            fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Value = crossSetting.GroupSumColumnName;
                            fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Font = defaultGroupSumFont;
                            #region 重新添加一次
                            fpMain_Sheet1.ColumnHeader.Columns.Count++;
                            fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Value = columnName;
                            fpMain_Sheet1.ColumnHeader.Columns[fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Tag = de.Key;//因为交叉报表在查询前都会清空FP，所以导致列的Tag被删除，这里重新添加。
                            htColumnIndexMap[columnName] = fpMain_Sheet1.ColumnHeader.Columns.Count - 1;
                            #endregion
                        }
                        compareForColumnGroup = group;
                        htColumnGroupSumIndexMap.Add(columnName, column);
                    }
                    #region 最后一列
                    fpMain_Sheet1.ColumnHeader.Columns.Count++;
                    column.SortId = fpMain_Sheet1.ColumnHeader.Columns.Count - 1;
                    fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Value = crossSetting.GroupSumColumnName;
                    fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Font = defaultGroupSumFont;
                    #endregion
                    if (crossSetting.RowSum)
                    {
                        fpMain_Sheet1.ColumnHeader.Columns.Count++;
                        fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Value = "合计";
                        fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Font = defaultGroupSumFont;
                    }
                }
                else
                {
                    ClearReportFarpoint();
                    fpMain_Sheet1.ColumnHeader.Rows.Count = 1;
                    fpMain_Sheet1.ColumnHeader.Columns.Count++;
                    fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Value = crossSetting.Row;
                    foreach (DictionaryEntry de in slColumnsCustomShows)
                    {
                        string columnName = de.Value.ToString();
                        if (htColumnIndexMap.Contains(columnName))
                            continue;
                        fpMain_Sheet1.ColumnHeader.Columns.Count++;
                        fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Value = columnName;
                        fpMain_Sheet1.ColumnHeader.Columns[fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Tag = de.Key;//因为交叉报表在查询前都会清空FP，所以导致列的Tag被删除，这里重新添加。
                        htColumnIndexMap.Add(columnName, fpMain_Sheet1.ColumnHeader.Columns.Count - 1);
                    }
                    if (crossSetting.RowSum)
                    {
                        fpMain_Sheet1.ColumnHeader.Columns.Count++;
                        fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Value = "合计";
                        fpMain_Sheet1.ColumnHeader.Cells[0, fpMain_Sheet1.ColumnHeader.Columns.Count - 1].Font = defaultGroupSumFont;
                    }
                }
                #endregion
            }
            #endregion
            #endregion

            #region 初始化行与行小计
            #region 如果不使用分组独立样式
            if (!crossSetting.UseHeader)
            {
                if (crossSetting.UseGroupSumRow)
                {
                    string sql = sqlBase;
                    sql = string.Format(sql, " Distinct " + crossSetting.GroupSumRow + " , " + crossSetting.Row, " Order By " + crossSetting.GroupSumRow);
                    quickReportManager.ExecQuery(sql);
                    try
                    {
                        string compareForRowGroup = compareString;
                        Objects.Row row = new QuickReportCore.Objects.Row();
                        while (quickReportManager.Reader.Read())
                        {
                            string group = quickReportManager.Reader[0].ToString();
                            string rowName = quickReportManager.Reader[1].ToString();
                            if (htRowIndexMap.Contains(rowName))
                                continue;
                            fpMain_Sheet1.Rows.Count++;
                            fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = rowName;
                            htRowIndexMap.Add(rowName, fpMain_Sheet1.Rows.Count - 1);
                            if (compareForRowGroup != group && compareForRowGroup != compareString)
                            {
                                fpMain_Sheet1.Rows.Count--;//先清除上面被添加进来的数据
                                fpMain_Sheet1.Rows.Count++;
                                row.SortId = fpMain_Sheet1.Rows.Count - 1;
                                row = new QuickReportCore.Objects.Row();
                                fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = crossSetting.GroupSumRowName;
                                fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Font = defaultGroupSumFont;
                                #region 再加一次
                                fpMain_Sheet1.Rows.Count++;
                                fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = rowName;
                                htRowIndexMap[rowName] = fpMain_Sheet1.Rows.Count - 1;
                                #endregion
                            }
                            compareForRowGroup = group;
                            htRowGroupSumIndexMap.Add(rowName, row);
                        }
                        #region 最后一行
                        fpMain_Sheet1.Rows.Count++;
                        row.SortId = fpMain_Sheet1.Rows.Count - 1;
                        fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = crossSetting.GroupSumRowName;
                        fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Font = defaultGroupSumFont;
                        #endregion
                        if (crossSetting.ColumnSum)
                        {
                            fpMain_Sheet1.Rows.Count++;
                            fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = "合计";
                            fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Font = defaultGroupSumFont;
                        }
                    }
                    catch (Exception e)
                    {
                        Err = "加载交叉报表行失败。" + e.Message;
                        return -1;
                    }
                    finally
                    {
                        quickReportManager.Reader.Close();
                    }
                }
                else
                {
                    string sql = sqlBase;
                    sql = string.Format(sql, " Distinct " + crossSetting.Row, " Order By " + crossSetting.Row);
                    quickReportManager.ExecQuery(sql);
                    try
                    {
                        while (quickReportManager.Reader.Read())
                        {
                            string rowName = quickReportManager.Reader[0].ToString();
                            if (htRowIndexMap.Contains(rowName))
                                continue;
                            fpMain_Sheet1.Rows.Count++;
                            fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = rowName;
                            htRowIndexMap.Add(rowName, fpMain_Sheet1.Rows.Count - 1);
                        }
                        if (crossSetting.ColumnSum)
                        {
                            fpMain_Sheet1.Rows.Count++;
                            fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = "合计";
                            fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Font = defaultGroupSumFont;
                        }
                    }
                    catch (Exception e)
                    {
                        Err = "加载交叉报表行失败。" + e.Message;
                        return -1;
                    }
                    finally
                    {
                        quickReportManager.Reader.Close();
                    }
                }
            }
            #endregion
            #region 如果使用分组独立样式
            else
            {
                #region 有行小计有列合计
                if (crossSetting.UseGroupSumRow && crossSetting.ColumnSum)
                {
                    string sql = sqlBase;
                    sql = string.Format(sql, " Distinct " + crossSetting.GroupSumRow + " , " + crossSetting.Row, " Order By " + crossSetting.GroupSumRow);
                    quickReportManager.ExecQuery(sql);
                    try
                    {
                        string compareForRowGroup = compareString;
                        Objects.Row row = new QuickReportCore.Objects.Row();
                        while (quickReportManager.Reader.Read())
                        {
                            string group = quickReportManager.Reader[0].ToString();
                            string rowName = quickReportManager.Reader[1].ToString();
                            if (htRowIndexMap.Contains(rowName))
                                continue;
                            fpMain_Sheet1.Rows.Count++;
                            fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = rowName;
                            htRowIndexMap.Add(rowName, fpMain_Sheet1.Rows.Count - 1);
                            if (compareForRowGroup != group && compareForRowGroup != compareString)
                            {
                                fpMain_Sheet1.Rows.Count--;//先清除上面被添加进来的数据
                                fpMain_Sheet1.Rows.Count++;
                                fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = crossSetting.GroupSumRowName;
                                fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Font = defaultGroupSumFont;
                                #region 合计
                                fpMain_Sheet1.Rows.Count++;
                                fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = "合计";
                                fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Font = defaultGroupSumFont;
                                #endregion
                                row.SortId = fpMain_Sheet1.Rows.Count - 1;//将“合计”的位置记录
                                row = new QuickReportCore.Objects.Row();
                                #region 再加一次
                                fpMain_Sheet1.Rows.Count++;
                                fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = rowName;
                                htRowIndexMap[rowName] = fpMain_Sheet1.Rows.Count - 1;
                                #endregion
                            }
                            compareForRowGroup = group;
                            htRowGroupSumIndexMap.Add(rowName, row);
                        }
                        #region 最后一行
                        fpMain_Sheet1.Rows.Count++;
                        fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = crossSetting.GroupSumRowName;
                        fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Font = defaultGroupSumFont;
                        #region 合计
                        fpMain_Sheet1.Rows.Count++;
                        row.SortId = fpMain_Sheet1.Rows.Count - 1;
                        fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = "合计";
                        fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Font = defaultGroupSumFont;
                        #endregion
                        #endregion
                    }
                    catch (Exception e)
                    {
                        Err = "加载交叉报表行失败。" + e.Message;
                        return -1;
                    }
                    finally
                    {
                        quickReportManager.Reader.Close();
                    }
                }
                #endregion
                #region 有行小计无列合计
                if (crossSetting.UseGroupSumRow && !crossSetting.ColumnSum)
                {
                    string sql = sqlBase;
                    sql = string.Format(sql, " Distinct " + crossSetting.GroupSumRow + " , " + crossSetting.Row, " Order By " + crossSetting.GroupSumRow);
                    quickReportManager.ExecQuery(sql);
                    try
                    {
                        string compareForRowGroup = compareString;
                        Objects.Row row = new QuickReportCore.Objects.Row();
                        while (quickReportManager.Reader.Read())
                        {
                            string group = quickReportManager.Reader[0].ToString();
                            string rowName = quickReportManager.Reader[1].ToString();
                            if (htRowIndexMap.Contains(rowName))
                                continue;
                            fpMain_Sheet1.Rows.Count++;
                            fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = rowName;
                            htRowIndexMap.Add(rowName, fpMain_Sheet1.Rows.Count - 1);
                            if (compareForRowGroup != group && compareForRowGroup != compareString)
                            {
                                fpMain_Sheet1.Rows.Count--;//先清除上面被添加进来的数据
                                fpMain_Sheet1.Rows.Count++;
                                row.SortId = fpMain_Sheet1.Rows.Count - 1;
                                row = new QuickReportCore.Objects.Row();
                                fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = crossSetting.GroupSumRowName;
                                fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Font = defaultGroupSumFont;
                                #region 再加一次
                                fpMain_Sheet1.Rows.Count++;
                                fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = rowName;
                                htRowIndexMap[rowName] = fpMain_Sheet1.Rows.Count - 1;
                                #endregion
                            }
                            compareForRowGroup = group;
                            htRowGroupSumIndexMap.Add(rowName, row);
                        }
                        #region 最后一行
                        fpMain_Sheet1.Rows.Count++;
                        row.SortId = fpMain_Sheet1.Rows.Count - 1;
                        fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = crossSetting.GroupSumRowName;
                        fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Font = defaultGroupSumFont;
                        #endregion
                    }
                    catch (Exception e)
                    {
                        Err = "加载交叉报表行失败。" + e.Message;
                        return -1;
                    }
                    finally
                    {
                        quickReportManager.Reader.Close();
                    }
                }
                #endregion
                #region 无行小计无列合计
                if (!crossSetting.UseGroupSumRow && !crossSetting.ColumnSum)
                {
                    string sql = sqlBase;
                    sql = string.Format(sql, " Distinct " + crossSetting.GroupSumRow + " , " + crossSetting.Row, " Order By " + crossSetting.GroupSumRow);
                    quickReportManager.ExecQuery(sql);
                    try
                    {
                        string compareForRowGroup = compareString;
                        Objects.Row row = new QuickReportCore.Objects.Row();
                        while (quickReportManager.Reader.Read())
                        {
                            string group = quickReportManager.Reader[0].ToString();
                            string rowName = quickReportManager.Reader[1].ToString();
                            if (htRowIndexMap.Contains(rowName))
                                continue;
                            fpMain_Sheet1.Rows.Count++;
                            fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = rowName;
                            htRowIndexMap.Add(rowName, fpMain_Sheet1.Rows.Count - 1);
                            if (compareForRowGroup != group && compareForRowGroup != compareString)
                            {
                                row.SortId = fpMain_Sheet1.Rows.Count - 2;//将上一组最后一个的位置记录。
                                row = new QuickReportCore.Objects.Row();
                            }
                            compareForRowGroup = group;
                            htRowGroupSumIndexMap.Add(rowName, row);
                        }
                        #region 最后一行
                        row.SortId = fpMain_Sheet1.Rows.Count - 1;//最后一组的最后一个位置。
                        #endregion
                    }
                    catch (Exception e)
                    {
                        Err = "加载交叉报表行失败。" + e.Message;
                        return -1;
                    }
                    finally
                    {
                        quickReportManager.Reader.Close();
                    }
                }
                #endregion
                #region 无行小计有列合计
                if (!crossSetting.UseGroupSumRow && crossSetting.ColumnSum)
                {
                    string sql = sqlBase;
                    sql = string.Format(sql, " Distinct " + crossSetting.GroupSumRow + " , " + crossSetting.Row, " Order By " + crossSetting.GroupSumRow);
                    quickReportManager.ExecQuery(sql);
                    try
                    {
                        string compareForRowGroup = compareString;
                        Objects.Row row = new QuickReportCore.Objects.Row();
                        while (quickReportManager.Reader.Read())
                        {
                            string group = quickReportManager.Reader[0].ToString();
                            string rowName = quickReportManager.Reader[1].ToString();
                            if (htRowIndexMap.Contains(rowName))
                                continue;
                            fpMain_Sheet1.Rows.Count++;
                            fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = rowName;
                            htRowIndexMap.Add(rowName, fpMain_Sheet1.Rows.Count - 1);
                            if (compareForRowGroup != group && compareForRowGroup != compareString)
                            {
                                fpMain_Sheet1.Rows.Count--;//先清除上面被添加进来的数据
                                fpMain_Sheet1.Rows.Count++;
                                row.SortId = fpMain_Sheet1.Rows.Count - 1;
                                row = new QuickReportCore.Objects.Row();
                                fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = "合计";
                                fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Font = defaultGroupSumFont;
                                #region 再加一次
                                fpMain_Sheet1.Rows.Count++;
                                fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = rowName;
                                htRowIndexMap[rowName] = fpMain_Sheet1.Rows.Count - 1;
                                #endregion
                            }
                            compareForRowGroup = group;
                            htRowGroupSumIndexMap.Add(rowName, row);
                        }
                        #region 最后一行
                        fpMain_Sheet1.Rows.Count++;
                        row.SortId = fpMain_Sheet1.Rows.Count - 1;
                        fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Value = "合计";
                        fpMain_Sheet1.Cells[fpMain_Sheet1.Rows.Count - 1, 0].Font = defaultGroupSumFont;
                        #endregion
                    }
                    catch (Exception e)
                    {
                        Err = "加载交叉报表行失败。" + e.Message;
                        return -1;
                    }
                    finally
                    {
                        quickReportManager.Reader.Close();
                    }
                }
                      #endregion
            }
            #endregion
            #endregion

            #region 查询数据
            string sqlQuery = sqlBase;
            bool valueIsNumber = (htColumnsBase[crossSetting.Value] as Objects.Column).IsNumber;
            if (valueIsNumber)//如果是数字型的，则手动NVL，防止在循环中不断判断是否为空而影响效率。
                sqlQuery = string.Format(sqlQuery, crossSetting.Row + " , " + crossSetting.Column + " , NVL(" + crossSetting.Value + ",0)", string.Empty);
            else
                sqlQuery = string.Format(sqlQuery, crossSetting.Row + " , " + crossSetting.Column + " , " + crossSetting.Value, string.Empty);
          
            CrossReportQueryType queryType;
            #region 判断查询方式
            if (htColumnGroupSumIndexMap.Count == 0)
            {
                if (htRowGroupSumIndexMap.Count == 0)
                {
                    if (!crossSetting.ColumnSum)
                    {
                        if (!crossSetting.RowSum)
                        {
                            queryType = CrossReportQueryType.无无无无;
                        }
                        else
                        {
                            queryType = CrossReportQueryType.无无无有;
                        }
                    }
                    else
                    {
                        if (!crossSetting.RowSum)
                        {
                            queryType = CrossReportQueryType.无无有无;
                        }
                        else
                        {
                            queryType = CrossReportQueryType.无无有有;
                        }
                    }
                }
                else
                {
                    if (!crossSetting.ColumnSum)
                    {
                        if (!crossSetting.RowSum)
                        {
                            queryType = CrossReportQueryType.无有无无;
                        }
                        else
                        {
                            queryType = CrossReportQueryType.无有无有;
                        }
                    }
                    else
                    {
                        if (!crossSetting.RowSum)
                        {
                            queryType = CrossReportQueryType.无有有无;
                        }
                        else
                        {
                            queryType = CrossReportQueryType.无有有有;
                        }
                    }
                }
            }
            else
            {
                if (htRowGroupSumIndexMap.Count == 0)
                {
                    if (!crossSetting.ColumnSum)
                    {
                        if (!crossSetting.RowSum)
                        {
                            queryType = CrossReportQueryType.有无无无;
                        }
                        else
                        {
                            queryType = CrossReportQueryType.有无无有;
                        }
                    }
                    else
                    {
                        if (!crossSetting.RowSum)
                        {
                            queryType = CrossReportQueryType.有无有无;
                        }
                        else
                        {
                            queryType = CrossReportQueryType.有无有有;
                        }
                    }
                }
                else
                {
                    if (!crossSetting.ColumnSum)
                    {
                        if (!crossSetting.RowSum)
                        {
                            queryType = CrossReportQueryType.有有无无;
                        }
                        else
                        {
                            queryType = CrossReportQueryType.有有无有;
                        }
                    }
                    else
                    {
                        if (!crossSetting.RowSum)
                        {
                            queryType = CrossReportQueryType.有有有无;
                        }
                        else
                        {
                            queryType = CrossReportQueryType.有有有有;
                        }
                    }
                }
            }
            #endregion

            #region 执行查询
            quickReportManager.ExecQuery(sqlQuery);
            try
            {
                #region 界面清零。这样在循环中便可以不用一直判断值是否为空了。
                if (valueIsNumber)//如果是数字型，则直接把CellType设置为数字型。
                {
                    FarPoint.Win.Spread.CellType.NumberCellType numberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                    numberCellType.DecimalPlaces = (htColumnsBase[crossSetting.Value] as Objects.Column).DecimalPlace;
                    for (int i = 1; i < fpMain_Sheet1.Columns.Count; i++)
                    {
                        for (int j = 0; j < fpMain_Sheet1.Rows.Count; j++)
                            fpMain_Sheet1.Cells[j, i].Value = 0m;
                        fpMain_Sheet1.Columns[i].CellType = numberCellType;
                    }
                }
                #endregion

                #region 如果不使用分组独立样式。
                if (!crossSetting.UseHeader)
                {
                    int rowIndex = 0;
                    int columnIndex = 0;
                    decimal numberValue = 0m;
                    int rowSumColumnIndex = fpMain_Sheet1.Columns.Count - 1;
                    int columnSumRowIndex = fpMain_Sheet1.Rows.Count - 1;
                    string stringValue = string.Empty;

                    if (reportType == ReportType.GeneralCross)
                    {
                        #region GeneralCrossReport
                        switch (queryType)
                        {
                            case CrossReportQueryType.无无无无:
                                {
                                    if (!valueIsNumber)
                                    {
                                        while (quickReportManager.Reader.Read())
                                        {
                                            rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                            columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                            stringValue = quickReportManager.Reader[2].ToString();
                                            fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = stringValue;
                                        }
                                    }
                                    else
                                    {
                                        while (quickReportManager.Reader.Read())
                                        {
                                            rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                            columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                            numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                            fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        }
                                    }
                                    break;
                                }
                            case CrossReportQueryType.无无无有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.无无有无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列合计
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.无无有有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列合计
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 总合计（行、列合计交叉处）
                                        fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.无有无无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.无有无有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计与行合计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.无有有无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.无有有有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计与行合计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.有无无无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.有无无有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.有无有无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列小计与列合计交叉处
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.有无有有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列小计与列合计交叉处
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 总合计（行、列合计交叉处）
                                        fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.有有无无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行、列小计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.有有无有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行、列小计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计与行合计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.有有有无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行、列小计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列小计与列合计交叉处
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.有有有有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行、列小计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列小计与列合计交叉处
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计与行合计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 总合计（行、列合计交叉处）
                                        fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                        }
                        #endregion
                    }
                    else if (reportType == ReportType.CustomCross)
                    {
                        #region CustomCrossReport
                        switch (queryType)
                        {
                            case CrossReportQueryType.无无无无:
                                {
                                    if (!valueIsNumber)
                                    {
                                        while (quickReportManager.Reader.Read())
                                        {
                                            rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                            //这里必须判断htColumnIndexMap中是否含有该列，因为是列是自定义的，数据库中可能并不存在该列的数据。若不含有则continue。下同，不一一注释了。
                                            if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                                continue;
                                            columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                            stringValue = quickReportManager.Reader[2].ToString();
                                            fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = stringValue;
                                        }
                                    }
                                    else
                                    {
                                        while (quickReportManager.Reader.Read())
                                        {
                                            rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                            if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                                continue;
                                            columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                            numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                            fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        }
                                    }
                                    break;
                                }
                            case CrossReportQueryType.无无无有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.无无有无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列合计
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.无无有有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列合计
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 总合计（行、列合计交叉处）
                                        fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.无有无无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.无有无有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计与行合计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.无有有无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.无有有有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计与行合计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.有无无无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.有无无有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.有无有无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列小计与列合计交叉处
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.有无有有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列小计与列合计交叉处
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 总合计（行、列合计交叉处）
                                        fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.有有无无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行、列小计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.有有无有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行、列小计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计与行合计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.有有有无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行、列小计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列小计与列合计交叉处
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            case CrossReportQueryType.有有有有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行、列小计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列小计与列合计交叉处
                                        fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计与行合计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 总合计（行、列合计交叉处）
                                        fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                        }
                        #endregion
                    }
                }
                #endregion 
                #region 如果使用分组独立样式。
                else 
                {
                    int rowIndex = 0;
                    int columnIndex = 0;
                    decimal numberValue = 0m;
                    int rowSumColumnIndex = fpMain_Sheet1.Columns.Count - 1;
                    int columnSumRowIndex = fpMain_Sheet1.Rows.Count - 1;
                    string stringValue = string.Empty;

                    if (reportType == ReportType.GeneralCross)
                    {
                        #region GeneralCrossReport
                        switch (queryType)
                        {
                            #region 无无无无
                            case CrossReportQueryType.无无无无:
                                {
                                    if (!valueIsNumber)
                                    {
                                        while (quickReportManager.Reader.Read())
                                        {
                                            rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                            columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                            stringValue = quickReportManager.Reader[2].ToString();
                                            fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = stringValue;
                                        }
                                    }
                                    else
                                    {
                                        while (quickReportManager.Reader.Read())
                                        {
                                            rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                            columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                            numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                            fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        }
                                    }
                                    break;
                                }
                            #endregion
                            #region 无无无有
                            case CrossReportQueryType.无无无有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 无无有无
                            case CrossReportQueryType.无无有无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列合计
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 实际使用的是行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion 
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 无无有有
                            case CrossReportQueryType.无无有有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列合计
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 实际使用的是行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion 
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 总合计（行、列合计交叉处）
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;                                       
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 无有无无
                            case CrossReportQueryType.无有无无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 无有无有
                            case CrossReportQueryType.无有无有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计与行合计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 无有有无
                            case CrossReportQueryType.无有有无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行小计
                                        //int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        //fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId-1;//因为采用列合计的时候，记录的是列合计的位置，行小计在前一行。
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 实际使用的是行小计
                                        rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 无有有有
                            case CrossReportQueryType.无有有有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行小计
                                        //int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        //fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId - 1;//因为在合计前一行。
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 实际使用的是行小计
                                        rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计与行合计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex-1, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex-1, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #region 列合计与行合计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 有无无无
                            case CrossReportQueryType.有无无无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 有无无有
                            case CrossReportQueryType.有无无有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion 
                            #region 有无有无
                            case CrossReportQueryType.有无有无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 实际使用的是行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                         #endregion
                                        #region 列小计与列合计交叉处
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 有无有有
                            case CrossReportQueryType.有无有有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 实际使用的是行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                         #endregion
                                        #region 列小计与列合计交叉处
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 总合计（行、列合计交叉处）
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 有有无无
                            case CrossReportQueryType.有有无无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行、列小计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 有有无有
                            case CrossReportQueryType.有有无有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行、列小计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计与行合计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 有有有无
                            case CrossReportQueryType.有有有无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId-1;//在列合计上面，所以要减一。
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行、列小计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 实际使用的是行小计
                                        rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #endregion
                                        #region 列小计与列合计交叉处
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 有有有有
                            case CrossReportQueryType.有有有有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId-1;//需要-1，因为在列合计上面。
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行、列小计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 实际使用的是行小计
                                        rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                          #endregion
                                        #region 列小计与列合计交叉处
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计与行合计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex -1 , rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex -1, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 总合计（行、列合计交叉处）
                                        //不需要了 已经在行小计与行合计交叉处里了。
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                        }
                        #endregion
                    }
                    else if (reportType == ReportType.CustomCross)
                    {
                        #region CustomCrossReport
                        switch (queryType)
                        {
                            #region 无无无无
                            case CrossReportQueryType.无无无无:
                                {
                                    if (!valueIsNumber)
                                    {
                                        while (quickReportManager.Reader.Read())
                                        {
                                            rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                            //这里必须判断htColumnIndexMap中是否含有该列，因为是列是自定义的，数据库中可能并不存在该列的数据。若不含有则continue。下同，不一一注释了。
                                            if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                                continue;
                                            columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                            stringValue = quickReportManager.Reader[2].ToString();
                                            fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = stringValue;
                                        }
                                    }
                                    else
                                    {
                                        while (quickReportManager.Reader.Read())
                                        {
                                            rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                            if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                                continue;
                                            columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                            numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                            fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        }
                                    }
                                    break;
                                }
                            #endregion
                            #region 无无无有
                            case CrossReportQueryType.无无无有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 无无有无
                            case CrossReportQueryType.无无有无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列合计
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 实际使用的是行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 无无有有
                            case CrossReportQueryType.无无有有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列合计
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 实际使用的是行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 总合计（行、列合计交叉处）
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 无有无无
                            case CrossReportQueryType.无有无无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 无有无有
                            case CrossReportQueryType.无有无有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计与行合计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 无有有无
                            case CrossReportQueryType.无有有无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行小计
                                        //int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        //fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId - 1;//因为采用列合计的时候，记录的是列合计的位置，行小计在前一行。
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 实际使用的是行小计
                                        rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 无有有有
                            case CrossReportQueryType.无有有有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 行小计
                                        //int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        //fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId - 1;//因为在合计前一行。
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 实际使用的是行小计
                                        rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计与行合计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex - 1, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex - 1, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #region 列合计与行合计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 有无无无
                            case CrossReportQueryType.有无无无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 有无无有
                            case CrossReportQueryType.有无无有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 有无有无
                            case CrossReportQueryType.有无有无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 实际使用的是行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #endregion
                                        #region 列小计与列合计交叉处
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 有无有有
                            case CrossReportQueryType.有无有有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 实际使用的是行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #endregion
                                        #region 列小计与列合计交叉处
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 总合计（行、列合计交叉处）
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 有有无无
                            case CrossReportQueryType.有有无无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行、列小计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 有有无有
                            case CrossReportQueryType.有有无有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行、列小计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计与行合计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 有有有无
                            case CrossReportQueryType.有有有无:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId - 1;//在列合计上面，所以要减一。
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行、列小计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 实际使用的是行小计
                                        rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #endregion
                                        #region 列小计与列合计交叉处
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                            #region 有有有有
                            case CrossReportQueryType.有有有有:
                                {
                                    while (quickReportManager.Reader.Read())
                                    {
                                        rowIndex = (int)htRowIndexMap[quickReportManager.Reader[0].ToString()];
                                        if (!htColumnIndexMap.Contains(quickReportManager.Reader[1].ToString()))
                                            continue;
                                        columnIndex = (int)htColumnIndexMap[quickReportManager.Reader[1].ToString()];
                                        numberValue = Convert.ToDecimal(quickReportManager.Reader[2].ToString());
                                        fpMain_Sheet1.Cells[rowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 列小计
                                        int columnGroupSumIndex = (htColumnGroupSumIndexMap[quickReportManager.Reader[1].ToString()] as Objects.Column).SortId;
                                        fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计
                                        int rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId - 1;//需要-1，因为在列合计上面。
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行、列小计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 列合计
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnIndex].Value.ToString()) + numberValue;
                                        #region 实际使用的是行小计
                                        rowGroupSumIndex = (htRowGroupSumIndexMap[quickReportManager.Reader[0].ToString()] as Objects.Row).SortId;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #endregion
                                        #region 列小计与列合计交叉处
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, columnGroupSumIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行合计
                                        fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 行小计与行合计交叉处
                                        fpMain_Sheet1.Cells[rowGroupSumIndex - 1, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex - 1, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[rowGroupSumIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                        #region 总合计（行、列合计交叉处）
                                        //不需要了 已经在行小计与行合计交叉处里了。
                                        //fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value = Convert.ToDecimal(fpMain_Sheet1.Cells[columnSumRowIndex, rowSumColumnIndex].Value.ToString()) + numberValue;
                                        #endregion
                                    }
                                    break;
                                }
                            #endregion
                        }
                        #endregion
                    }
                }
                #endregion
            }
            catch (Exception e)
            {
                Err = "查询交叉报表失败。" + e.Message;
                return -1;
            }
            finally
            {
                quickReportManager.Reader.Close();
            }
            #endregion

            #endregion

            #region 设置列的属性
            //第一列的属性，为交叉报表设置中“行”的属性。
            fpMain_Sheet1.Columns[0].HorizontalAlignment = (htColumnsBase[crossSetting.Row] as Objects.Column).HAligment;
            fpMain_Sheet1.Columns[0].VerticalAlignment = (htColumnsBase[crossSetting.Row] as Objects.Column).VAligment;
            fpMain_Sheet1.Columns[0].Font = (htColumnsBase[crossSetting.Row] as Objects.Column).Font;
            fpMain_Sheet1.Columns[0].ForeColor = (htColumnsBase[crossSetting.Row] as Objects.Column).Color;
            //其余列的属性，为交叉报表设置中“值”的属性。
            if (valueIsNumber)
            {
                for (int i = 1; i < fpMain_Sheet1.Columns.Count; i++)
                {
                    fpMain_Sheet1.Columns[i].HorizontalAlignment = (htColumnsBase[crossSetting.Value] as Objects.Column).HAligment;
                    fpMain_Sheet1.Columns[i].VerticalAlignment = (htColumnsBase[crossSetting.Value] as Objects.Column).VAligment;
                    fpMain_Sheet1.Columns[i].Font = (htColumnsBase[crossSetting.Value] as Objects.Column).Font;
                    fpMain_Sheet1.Columns[i].ForeColor = (htColumnsBase[crossSetting.Value] as Objects.Column).Color;
                    numberCellType.DecimalPlaces = (htColumnsBase[crossSetting.Value] as Objects.Column).DecimalPlace;
                    numberCellType.ValueTransType = (htColumnsBase[crossSetting.Value] as Objects.Column).ValueTransType;
                    fpMain_Sheet1.Columns[i].CellType = numberCellType.Clone() as FarPoint.Win.Spread.CellType.NumberCellType;
                }
            }
            else
            {
                for (int i = 1; i < fpMain_Sheet1.Columns.Count; i++)
                {
                    fpMain_Sheet1.Columns[i].HorizontalAlignment = (htColumnsBase[crossSetting.Value] as Objects.Column).HAligment;
                    fpMain_Sheet1.Columns[i].VerticalAlignment = (htColumnsBase[crossSetting.Value] as Objects.Column).VAligment;
                    fpMain_Sheet1.Columns[i].Font = (htColumnsBase[crossSetting.Value] as Objects.Column).Font;
                    fpMain_Sheet1.Columns[i].ForeColor = (htColumnsBase[crossSetting.Value] as Objects.Column).Color;
                }
            }
            #endregion

            #region 设置小计、合计字体 （在设置列的属性之后，是有道理的。）
            #region 当不使用分组独立样式
            if (!crossSetting.UseHeader)
            {
                if (crossSetting.ColumnSum)
                    fpMain_Sheet1.Rows[fpMain_Sheet1.Rows.Count - 1].Font = defaultGroupSumFont;
                if (crossSetting.RowSum)
                    fpMain_Sheet1.Columns[fpMain_Sheet1.Columns.Count - 1].Font = defaultGroupSumFont;
                if (htColumnGroupSumIndexMap.Count > 0)
                {
                    foreach (DictionaryEntry de in htColumnGroupSumIndexMap)
                        fpMain_Sheet1.Columns[(de.Value as Objects.Column).SortId].Font = defaultGroupSumFont;
                }
                if (htRowGroupSumIndexMap.Count > 0)
                {
                    foreach (DictionaryEntry de in htRowGroupSumIndexMap)
                        fpMain_Sheet1.Rows[(de.Value as Objects.Row).SortId].Font = defaultGroupSumFont;
                }
            }
            #endregion
            #region 使用分组独立样式
            else
            {
                #region 有行小计有列合计
                if (crossSetting.UseGroupSumRow && crossSetting.ColumnSum)
                {
                    if (htRowGroupSumIndexMap.Count > 0)
                    {
                        foreach (DictionaryEntry de in htRowGroupSumIndexMap)
                        {
                            fpMain_Sheet1.Rows[(de.Value as Objects.Row).SortId-1].Font = defaultGroupSumFont;//行小计
                            fpMain_Sheet1.Rows[(de.Value as Objects.Row).SortId].Font = defaultGroupSumFont;//列合计
                        }
                    }
                }
                #endregion
                #region 有行小计无列合计
                if (crossSetting.UseGroupSumRow && !crossSetting.ColumnSum)
                {
                    if (htRowGroupSumIndexMap.Count > 0)
                    {
                        foreach (DictionaryEntry de in htRowGroupSumIndexMap)
                        {
                            fpMain_Sheet1.Rows[(de.Value as Objects.Row).SortId].Font = defaultGroupSumFont;//行小计
                        }
                    }
                }
                #endregion
                #region 无行小计无列合计
                if (!crossSetting.UseGroupSumRow && !crossSetting.ColumnSum)
                {
                    //什么也不做。
                }
                #endregion
                #region 无行小计有列合计
                if (!crossSetting.UseGroupSumRow && crossSetting.ColumnSum)
                {
                    if (htRowGroupSumIndexMap.Count > 0)
                    {
                        foreach (DictionaryEntry de in htRowGroupSumIndexMap)
                        {
                            fpMain_Sheet1.Rows[(de.Value as Objects.Row).SortId].Font = defaultGroupSumFont;//列合计
                        }
                    }
                }
                #endregion
                if (crossSetting.RowSum)
                    fpMain_Sheet1.Columns[fpMain_Sheet1.Columns.Count - 1].Font = defaultGroupSumFont;
                if (htColumnGroupSumIndexMap.Count > 0)
                {
                    foreach (DictionaryEntry de in htColumnGroupSumIndexMap)
                        fpMain_Sheet1.Columns[(de.Value as Objects.Column).SortId].Font = defaultGroupSumFont;
                }
            }
            #endregion
            #endregion

            #region 调整列宽
            if (reportType == ReportType.GeneralCross)
            {
                #region GeneralCrossReport
                saveProtector = true;
                float totalWidth = 0;
                if (reportType == ReportType.GeneralCross)
                {
                    for (int i = 1; i < fpMain_Sheet1.Columns.Count; i++)//之所以从1开始，是不想让0受上方ColumnHeader的影响。
                    {
                        fpMain_Sheet1.Columns[i].Width = fpMain_Sheet1.Columns[i].GetPreferredWidth();
                        totalWidth += fpMain_Sheet1.Columns[i].Width;
                    }
                }
                if (totalWidth < 1000)
                {
                    float eatch = (1000 - totalWidth) / fpMain_Sheet1.Columns.Count;
                    for (int i = 0; i < fpMain_Sheet1.Columns.Count; i++)
                    {
                        fpMain_Sheet1.Columns[i].Width += eatch;
                    }
                }
                saveProtector = false;
            }
            #endregion
            else if (reportType == ReportType.CustomCross)
            {
                #region CustomCrossReport
                SetColumnAttrToCustomAfterQuery();
                fpMain_Sheet1.Columns[0].Width = 100;//受最上方的表首影响，会导致第一列超长。目前只能手工设置为100。
                #endregion
            }
            #endregion

            #region 设置动态变量值。
            if (reportType == ReportType.GeneralCross)
            {
                reportDataRowNumber = fpMain_Sheet1.Rows.Count;
                reportDataColumnNumer = fpMain_Sheet1.Columns.Count;
            }
            else
            {
                reportDataRowNumber = fpMain_Sheet1.Rows.Count;
                reportDataColumnNumer = fpMain_Sheet1.Columns.Count;
            }
            #endregion
            WatchStop();
            InitFpColumnHeaders();//之所以这里是InitFpColumnHeaders而不是SetColumnHeaderAfterQuery，是因为交叉报表与网格报表不同。交叉报表在查询初期会将Fp清空，网格报表不会。
            #region 设置列的Border
            SetColumnBorder();
            #endregion
            #region 设置为完美列宽
            if (reportSetting.UseAutoColumnWidth)
            {
                saveProtector = true;
                for (int i = 1; i < fpMain_Sheet1.Columns.Count; i++)
                    fpMain_Sheet1.Columns[i].Width = fpMain_Sheet1.Columns[i].GetPreferredWidth();
                saveProtector = false;
            }
            #endregion
            #region 添加分组独立样式
            if (crossSetting.UseHeader)
            {
                fpMain_Sheet1.ColumnHeader.Visible = false;//分组独立样式时，隐藏ColumnHeader。
                if (htRowGroupSumIndexMap.Count > 0)
                {
                    SortedList<int, List<Objects.Header>> slTopHeader = new SortedList<int, List<Objects.Header>>();//经过翻译的表首。
                    SortedList<int, List<Objects.Header>> slBottomHeader = new SortedList<int, List<Objects.Header>>();//经过翻译的表尾。
                    SortedList<int, object> sortor = new SortedList<int, object>();
                    foreach (DictionaryEntry de in htRowGroupSumIndexMap)
                    {
                        if (sortor.ContainsKey((de.Value as Objects.Row).SortId))
                            continue;
                        sortor.Add((de.Value as Objects.Row).SortId, null);
                    }
                    int lastRowIndex = -1;
                    foreach (KeyValuePair<int, object> de in sortor)
                    {
                        slTopHeader.Add(de.Key, GetMainReportTranslatedColumnHeader(lastRowIndex + 1, 1));//第N组表首
                        slBottomHeader.Add(de.Key, GetMainReportTranslatedBottomHeader(lastRowIndex + 1, 1));//第N组表尾
                        lastRowIndex = de.Key;
                    }
                    int lastTopRowIndex = 0;
                    int rowsAdded = 0;
                    foreach (KeyValuePair<int, List<Objects.Header>> de in slTopHeader)
                    {
                        #region 添加第N组表首
                        List<Objects.Header> topHeaderList = de.Value as List<Objects.Header>;
                        fpMain_Sheet1.AddUnboundRows(lastTopRowIndex, topHeaderList.Count + 1);//+1是为了给列头使用。
                        rowsAdded += topHeaderList.Count + 1;
                        foreach (Objects.Header header in topHeaderList)
                        {
                            AddAHeader(lastTopRowIndex + header.RowIndex, header, HeaderType.Top);
                        }
                        //复制列头。
                        for (int i = 0; i < fpMain_Sheet1.ColumnHeader.Columns.Count; i++)
                        {
                            fpMain_Sheet1.Rows[lastTopRowIndex + topHeaderList.Count].Tag = new Objects.Header();
                            fpMain_Sheet1.Rows[lastTopRowIndex + topHeaderList.Count].CellType = textCelltype;
                            fpMain_Sheet1.Cells[lastTopRowIndex + topHeaderList.Count, i].Value = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, i].Value;
                            fpMain_Sheet1.Cells[lastTopRowIndex + topHeaderList.Count, i].Border = fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, i].Border;
                            fpMain_Sheet1.Cells[lastTopRowIndex + topHeaderList.Count, i].Font = defaultColumnHeaderFont;
                            fpMain_Sheet1.Cells[lastTopRowIndex + topHeaderList.Count, i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                            fpMain_Sheet1.Cells[lastTopRowIndex + topHeaderList.Count, i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        }
                        #endregion
                        #region 添加第N组表尾
                        int rowIndex = de.Key + rowsAdded;
                        rowIndex += 1;//topHeaderList.Count + 1 是因为上面插入了一个列头+一组表首；再加1是因为第N组表尾是在第N组最后一行+1开始。
                        List<Objects.Header> bottomHeaderList = slBottomHeader[de.Key];
                        fpMain_Sheet1.AddUnboundRows(rowIndex, bottomHeaderList.Count);
                        rowsAdded += bottomHeaderList.Count;
                        foreach (Objects.Header header in bottomHeaderList)
                        {
                            AddAHeader(rowIndex + header.RowIndex, header, HeaderType.Bottom);
                        }
                        #endregion
                        lastTopRowIndex = rowIndex + bottomHeaderList.Count;
                    }
                }
            }
            #endregion
            if (!crossSetting.UseHeader)//当不是分组独立样式时，才手动添加表尾。
            {
                SetColumnHeaderAfterQuery(MainOrDetail.Main);//刷新设置第一个表首，主要是将改变的各种变量刷新。
                AddBottomHeaderAfterQuery(MainOrDetail.Main);
                #region 只有在不是分组独立样式时，才设置间隔色
                if (reportSetting.UseEvenColor)
                    fpMain_Sheet1.AlternatingRows[1].BackColor = reportSetting.EvenColor;
                #endregion
            }
            fpMain.ResumeLayout();
            fpMain.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            return 1;
        }

        /// <summary>
        /// 查询报表明细。
        /// </summary>
        /// <param name="rowIndex">所要查询的行序号。</param>
        /// <returns>失败为-1,；成功为1；</returns>
        private int QueryDetail(int rowIndex)
        {
            #region 需要被翻译的种类。
            Managers.Functions.SQLCodeType[] typesDetail = new QuickReportCore.Managers.Functions.SQLCodeType[3];
            typesDetail[0] = QuickReportCore.Managers.Functions.SQLCodeType.System;
            typesDetail[1] = QuickReportCore.Managers.Functions.SQLCodeType.Condition;
            typesDetail[2] = QuickReportCore.Managers.Functions.SQLCodeType.Dynamic;
            #endregion
            fpDetail.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            string sql = detailSetting.SQL;
            if (sql.Trim() == string.Empty)
                return -1;
            sql = TranslateValue(sql, typesDetail);
            sql = TranslateTextWithColumnValue(sql, rowIndex);
            sql = TranslateTextWithTreeValueForSql(sql);//树单独翻译。因为节点为空时，应返回两个单引号"''"，防止SQL运行时报错。
            DataSet ds = null;
            quickReportManager.ExecQuery(sql, ref ds);
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
            {
                Err = "报表明细查询失败。";
                return -1;
            }
            fpDetail_Sheet1.Rows.Count = 0;
            dvReportDetail = new DataView(ds.Tables[0]);
            fpDetail_Sheet1.DataSource = dvReportDetail;
            #region 调整列宽
            float totalWidth = 0;
            for (int i = 0; i < fpDetail_Sheet1.Columns.Count; i++)
            {
                fpDetail_Sheet1.Columns[i].Width = fpDetail_Sheet1.Columns[i].GetPreferredWidth();
                totalWidth += fpDetail_Sheet1.Columns[i].Width;
            }
            fpDetail_Sheet1.Columns[0].Width = 100;//受最上方的表首影响，会导致第一列超长。目前只能手工设置为100。
            if (totalWidth < 1000)
            {
                float eatch = (1000 - totalWidth) / fpDetail_Sheet1.Columns.Count;
                for (int i = 0; i < fpDetail_Sheet1.Columns.Count; i++)
                {
                    fpDetail_Sheet1.Columns[i].Width += eatch;
                }
            }
            #endregion
            SetColumnHeaderAfterQuery(MainOrDetail.Detail);
            AddBottomHeaderAfterQuery(MainOrDetail.Detail);
            fpDetail.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            return 1;
        }

        private int QueryDetail(int rowIndex,int columnIndex)
        {
            #region 需要被翻译的种类。
            Managers.Functions.SQLCodeType[] typesDetail = new QuickReportCore.Managers.Functions.SQLCodeType[3];
            typesDetail[0] = QuickReportCore.Managers.Functions.SQLCodeType.System;
            typesDetail[1] = QuickReportCore.Managers.Functions.SQLCodeType.Condition;
            typesDetail[2] = QuickReportCore.Managers.Functions.SQLCodeType.Dynamic;
            #endregion
            fpDetail.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            string sql = detailSetting.SQL;
            if (sql.Trim() == string.Empty)
                return -1;
            sql = TranslateValue(sql, typesDetail);
            sql = TranslateTextWithColumnValue(sql, rowIndex,columnIndex);
            sql = TranslateTextWithTreeValueForSql(sql);//树单独翻译。因为节点为空时，应返回两个单引号"''"，防止SQL运行时报错。
            DataSet ds = null;
            quickReportManager.ExecQuery(sql, ref ds);
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
            {
                Err = "报表明细查询失败。";
                return -1;
            }
            fpDetail_Sheet1.Rows.Count = 0;
            dvReportDetail = new DataView(ds.Tables[0]);
            fpDetail_Sheet1.DataSource = dvReportDetail;
            #region 调整列宽
            float totalWidth = 0;
            for (int i = 0; i < fpDetail_Sheet1.Columns.Count; i++)
            {
                fpDetail_Sheet1.Columns[i].Width = fpDetail_Sheet1.Columns[i].GetPreferredWidth();
                totalWidth += fpDetail_Sheet1.Columns[i].Width;
            }
            fpDetail_Sheet1.Columns[0].Width = 100;//受最上方的表首影响，会导致第一列超长。目前只能手工设置为100。
            if (totalWidth < 1000)
            {
                float eatch = (1000 - totalWidth) / fpDetail_Sheet1.Columns.Count;
                for (int i = 0; i < fpDetail_Sheet1.Columns.Count; i++)
                {
                    fpDetail_Sheet1.Columns[i].Width += eatch;
                }
            }
            #endregion
            SetColumnHeaderAfterQuery(MainOrDetail.Detail);
            AddBottomHeaderAfterQuery(MainOrDetail.Detail);
            fpDetail.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            return 1;
        }

        private void ProcessINeedDatas(int rowIndex)
        {
            if (iNeedDatasList == null || iNeedDatasList.Count == 0)
                return;
            #region 需要被翻译的种类。
            Managers.Functions.SQLCodeType[] types = new QuickReportCore.Managers.Functions.SQLCodeType[4];
            types[0] = QuickReportCore.Managers.Functions.SQLCodeType.Tree;
            types[1] = QuickReportCore.Managers.Functions.SQLCodeType.System;
            types[2] = QuickReportCore.Managers.Functions.SQLCodeType.Condition;
            types[3] = QuickReportCore.Managers.Functions.SQLCodeType.Dynamic;
            #endregion
            foreach (DictionaryEntry de in iNeedDatasList)
            {
                string[] values = TranslateTextWithColumnValue(TranslateValue((de.Key as Objects.Interface).Values, types),rowIndex).Replace("，", ",").Split(',');
                (de.Value as PublicInterfaces.INeedDatas).GetDatas(values);
            }
        }

        private void ProcessINeedDatas(int rowIndex,int columnIndex)
        {
            if (iNeedDatasList == null || iNeedDatasList.Count == 0)
                return;
            #region 需要被翻译的种类。列的变量单独处理翻译。
            Managers.Functions.SQLCodeType[] types = new QuickReportCore.Managers.Functions.SQLCodeType[4];
            types[0] = QuickReportCore.Managers.Functions.SQLCodeType.Tree;
            types[1] = QuickReportCore.Managers.Functions.SQLCodeType.System;
            types[2] = QuickReportCore.Managers.Functions.SQLCodeType.Condition;
            types[3] = QuickReportCore.Managers.Functions.SQLCodeType.Dynamic;
            #endregion
            foreach (DictionaryEntry de in iNeedDatasList)
            {
                string[] values = TranslateTextWithColumnValue(TranslateValue((de.Key as Objects.Interface).Values, types), rowIndex, columnIndex).Replace("，", ",").Split(',');
                (de.Value as PublicInterfaces.INeedDatas).GetDatas(values);
            }
        }

        private int CheckInput()
        {
            return ucReportConditionList.CheckInput();
        }

        public void ShowSetting()
        {
            Forms.frmReportCustomSetting frmCustomSetting = new QuickReportCore.Forms.frmReportCustomSetting();
            frmCustomSetting.LoadCustomSetting(htColumnsCustomShows, htColumnsCustomUnShows, htConditionsCustomShows, htConditionsCustomUnShows,quickReport.ID,reportType);
            frmCustomSetting.OnSave += new QuickReportCore.Forms.frmReportCustomSetting.OnSaveHandle(frmCustomSetting_OnSave);
            frmCustomSetting.OnRefresh += new QuickReportCore.Forms.frmReportCustomSetting.OnRefreshHandle(frmCustomSetting_OnRefresh);
            frmCustomSetting.ShowDialog();
        }

        void frmCustomSetting_OnRefresh(QuickReportCore.Forms.frmReportCustomSetting.RefreshType refreshType)
        {
            switch (refreshType)
            {
                case QuickReportCore.Forms.frmReportCustomSetting.RefreshType.Column:
                    {
                        RefreshColumns();
                        break;
                    }
                case QuickReportCore.Forms.frmReportCustomSetting.RefreshType.Condition:
                    {
                        RefreshConditions();
                        break;
                    }
            }
            SaveCustomSetting();
        }

        void frmCustomSetting_OnSave(Hashtable htColShows, Hashtable htColUnShows, Hashtable htConShows, Hashtable htConUnShows)
        {
            bool freshColumn = false;
            bool freshCondition = false;
            if (htColumnsCustomShows.Count != htColShows.Count)
            {
                freshColumn = true;
            }
            if (htConditionsCustomShows.Count != htConShows.Count)
            {
                freshCondition = true;
            }
            if (!freshColumn)
            {
                foreach (DictionaryEntry de in htColumnsCustomShows)
                {
                    if (!htColShows.Contains(de.Key) || (htColShows[de.Key] as Objects.Column).SortId != (de.Value as Objects.Column).SortId)
                    {
                        freshColumn = true;
                        break;
                    }
                }
            }
            if (!freshCondition)
            {
                foreach (DictionaryEntry de in htConditionsCustomShows)
                {
                    if (!htConShows.Contains(de.Key) || (htConShows[de.Key] as Objects.Condition).SortId != (de.Value as Objects.Condition).SortId)
                    {
                        freshCondition = true;
                        break;
                    }
                }
            }
            htColumnsCustomShows = htColShows;
            SortCustomColumn();//重新排序。目的实际上不是排序，因为设置界面传回来的就是经过排序的。主要是想更新slColumnsCustomShows。
            htColumnsCustomUnShows = htColUnShows;
            htConditionsCustomShows = htConShows;
            htConditionsCustomUnShows = htConUnShows;
            if (freshColumn)
                InitFp();
            if (freshCondition)
                InitConditions();
            if (freshColumn || freshCondition)
                SaveCustomSetting();
        }

        private bool saveProtector = false;
        private int SaveCustomSetting()
        {
            if (saveProtector)
                return -1;
            if (reportSetting.UseTree)
                customViewSetting.SplitH = splitContainerH.SplitterDistance;
            if (reportSetting.UseDetail)
                customViewSetting.SplitV = splitContainerV.SplitterDistance;

            xmlDocumentCustomSetting.RemoveAll();
            XmlDeclaration dec = xmlDocumentCustomSetting.CreateXmlDeclaration("1.0", "GB2312", null);
            xmlDocumentCustomSetting.AppendChild(dec);
            XmlElement root = xmlDocumentCustomSetting.CreateElement(XmlAttrDicCustomView.CustomViewSetting.ToString());
            xmlDocumentCustomSetting.AppendChild(root);
            root.SetAttribute(XmlAttrDicCustomView.tSplitH.ToString(), customViewSetting.SplitH.ToString());
            root.SetAttribute(XmlAttrDicCustomView.tSplitV.ToString(), customViewSetting.SplitV.ToString());
            root.AppendChild(ConvertCustomColumnShowListToXml());
            root.AppendChild(ConvertCustomColumnUnShowListToXml());
            root.AppendChild(ConvertGetCustomConditionShowListToXml());
            root.AppendChild(ConvertCustomConditionUnShowListToXml());
            string content = xmlDocumentCustomSetting.OuterXml;

            Neusoft.NFC.Management.PublicTrans.BeginTransaction();
            int i = quickReportManager.QuerySettingExist(quickReportManager.Operator.ID, quickReport.ID);
            if (i < 0)
            {
                goto Error;
            }
            if (i > 0)
            {
                int j = quickReportManager.UpdateSettingByOperCodeAndReportID(quickReportManager.Operator.ID, quickReport.ID, content);
                if (j < 0)
                {
                    goto Error;
                }
                Neusoft.NFC.Management.PublicTrans.Commit();
                return j;
            }
            else
            {
                int j = quickReportManager.InsertSetting(quickReportManager.Operator.ID, quickReport.ID, content);
                if (j < 0)
                {
                    goto Error;
                }
                Neusoft.NFC.Management.PublicTrans.Commit();
                return j;
            }
        Error:
            {
                Neusoft.NFC.Management.PublicTrans.RollBack();
                return -1;
            }
        }

        private XmlElement ConvertCustomColumnShowListToXml()
        {
            XmlElement node = xmlDocumentCustomSetting.CreateElement(XmlAttrDicCustomView.CustomColumnShowList.ToString());
            foreach (DictionaryEntry de in htColumnsCustomShows)
            {
                XmlElement n = xmlDocumentCustomSetting.CreateElement(XmlAttrDicCustomView.CustomColumnShow.ToString());
                n.SetAttribute(XmlAttrDicCustomView.tColumnName.ToString(), (de.Value as Objects.Column).ID);
                n.SetAttribute(XmlAttrDicCustomView.tColumnSortID.ToString(), (de.Value as Objects.Column).SortId.ToString());
                n.SetAttribute(XmlAttrDicCustomView.tColumnWidth.ToString(), (de.Value as Objects.Column).Width.ToString());
                node.AppendChild(n);
            }
            return node;
        }

        private XmlElement ConvertCustomColumnUnShowListToXml()
        {
            XmlElement node = xmlDocumentCustomSetting.CreateElement(XmlAttrDicCustomView.CustomColumnUnShowList.ToString());
            foreach (DictionaryEntry de in htColumnsCustomUnShows)
            {
                XmlElement n = xmlDocumentCustomSetting.CreateElement(XmlAttrDicCustomView.CustomColumnUnShow.ToString());
                n.SetAttribute(XmlAttrDicCustomView.tColumnName.ToString(), (de.Value as Objects.Column).ID);
                n.SetAttribute(XmlAttrDicCustomView.tColumnSortID.ToString(), (de.Value as Objects.Column).SortId.ToString());
                n.SetAttribute(XmlAttrDicCustomView.tColumnWidth.ToString(), (de.Value as Objects.Column).Width.ToString());
                node.AppendChild(n);
            }
            return node;
        }

        private XmlElement ConvertGetCustomConditionShowListToXml()
        {
            XmlElement node = xmlDocumentCustomSetting.CreateElement(XmlAttrDicCustomView.CustomConditionShowList.ToString());
            foreach (DictionaryEntry de in htConditionsCustomShows)
            {
                XmlElement n = xmlDocumentCustomSetting.CreateElement(XmlAttrDicCustomView.CustomConditionShow.ToString());
                n.SetAttribute(XmlAttrDicCustomView.tConditionName.ToString(), (de.Value as Objects.Condition).ID);
                n.SetAttribute(XmlAttrDicCustomView.tConditionSortID.ToString(), (de.Value as Objects.Condition).SortId.ToString());
                n.SetAttribute(XmlAttrDicCustomView.tConditionOperator.ToString(), (de.Value as Objects.Condition).OperatorType);
                n.SetAttribute(XmlAttrDicCustomView.tConditionAndOr.ToString(), (de.Value as Objects.Condition).AndOr);
                n.SetAttribute(XmlAttrDicCustomView.tConditionValue.ToString(), (de.Value as Objects.Condition).Value);
                node.AppendChild(n);
            }
            return node;
        }

        private XmlElement ConvertCustomConditionUnShowListToXml()
        {
            XmlElement node = xmlDocumentCustomSetting.CreateElement(XmlAttrDicCustomView.CustomConditionUnShowList.ToString());
            foreach (DictionaryEntry de in htConditionsCustomUnShows)
            {
                XmlElement n = xmlDocumentCustomSetting.CreateElement(XmlAttrDicCustomView.CustomConditionUnShow.ToString());
                n.SetAttribute(XmlAttrDicCustomView.tConditionName.ToString(), (de.Value as Objects.Condition).ID);
                n.SetAttribute(XmlAttrDicCustomView.tConditionSortID.ToString(), (de.Value as Objects.Condition).SortId.ToString());
                n.SetAttribute(XmlAttrDicCustomView.tConditionOperator.ToString(), (de.Value as Objects.Condition).OperatorType);
                n.SetAttribute(XmlAttrDicCustomView.tConditionAndOr.ToString(), (de.Value as Objects.Condition).AndOr);
                n.SetAttribute(XmlAttrDicCustomView.tConditionValue.ToString(), (de.Value as Objects.Condition).Value);
                node.AppendChild(n);
            }
            return node;
        }

        private Hashtable GetCustomColumnShowListFromXml(XmlElement xmlElement)
        {
            XmlNodeList nodes = xmlElement.SelectNodes(XmlAttrDicCustomView.CustomColumnShow.ToString());
            Hashtable list = new Hashtable();
            foreach (XmlNode node in nodes)
            {
                Objects.Column c = new QuickReportCore.Objects.Column();
                c.ID = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicCustomView.tColumnName.ToString(), string.Empty);
                c.SortId = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicCustomView.tColumnSortID.ToString(), "0"));
                c.Width = Convert.ToInt64(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicCustomView.tColumnWidth.ToString(), "90"));
                list.Add(c.ID, c);
            }
            return list;
        }

        private Hashtable GetCustomColumnUnShowListFromXml(XmlElement xmlElement)
        {
            XmlNodeList nodes = xmlElement.SelectNodes(XmlAttrDicCustomView.CustomColumnUnShow.ToString());
            Hashtable list = new Hashtable();
            foreach (XmlNode node in nodes)
            {
                Objects.Column c = new QuickReportCore.Objects.Column();
                c.ID = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicCustomView.tColumnName.ToString(), string.Empty);
                c.SortId = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicCustomView.tColumnSortID.ToString(), "0"));
                c.Width = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicCustomView.tColumnWidth.ToString(), "90"));
                list.Add(c.ID, c);
            }
            return list;
        }

        private Hashtable GetCustomConditionShowListFromXml(XmlElement xmlElement)
        {
            XmlNodeList nodes = xmlElement.SelectNodes(XmlAttrDicCustomView.CustomConditionShow.ToString());
            Hashtable list = new Hashtable();
            foreach (XmlNode node in nodes)
            {
                Objects.Condition c = new QuickReportCore.Objects.Condition();
                c.ID = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicCustomView.tConditionName.ToString(), string.Empty);
                c.SortId = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicCustomView.tConditionSortID.ToString(), "0"));
                c.OperatorType = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicCustomView.tConditionOperator.ToString(), "等于");
                c.AndOr = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicCustomView.tConditionAndOr.ToString(), "且");
                c.Value = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicCustomView.tConditionValue.ToString(), string.Empty);
                list.Add(c.ID, c);
            }
            return list;
        }

        private Hashtable GetCustomConditionUnShowListFromXml(XmlElement xmlElement)
        {
            XmlNodeList nodes = xmlElement.SelectNodes(XmlAttrDicCustomView.CustomConditionUnShow.ToString());
            Hashtable list = new Hashtable();
            foreach (XmlNode node in nodes)
            {
                Objects.Condition c = new QuickReportCore.Objects.Condition();
                c.ID = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicCustomView.tConditionName.ToString(), string.Empty);
                c.SortId = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicCustomView.tConditionSortID.ToString(), "0"));
                c.OperatorType = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicCustomView.tConditionOperator.ToString(), "等于");
                c.AndOr = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicCustomView.tConditionAndOr.ToString(), "且");
                c.Value = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicCustomView.tConditionValue.ToString(), string.Empty);
                list.Add(c.ID, c);
            }
            return list;
        }

        /// <summary>
        /// 重置列。
        /// </summary>
        private void RefreshColumns()
        {
            InitBaseColumn();
            if (reportType != ReportType.Grid)
                InitCrossReportColumnCanShow();
            else
                InitGridReportColumnCanShow();
            htColumnsCustomShows = htColumnsCanShows;//重置以后，自定义的就是默认显示的。
            htColumnsCustomUnShows = new Hashtable();//清空不显示的。
            SortCustomColumn();//排序。
            InitFp();
        }

        /// <summary>
        /// 重置条件。
        /// </summary>
        private void RefreshConditions()
        {
            InitBaseCondition();
            InitReportConditionCanShow();
            htConditionsCustomShows = htConditionsCanShows;//重置以后，自定义的就是默认显示的。
            htConditionsCustomUnShows = new Hashtable();//清空不显示的。
            SortCustomCondition();//排序。
            InitConditions();
        }

        public enum XmlAttrDicCustomView
        {
            CustomViewSetting,
            CustomColumnShowList,
            CustomColumnUnShowList,
            CustomConditionShowList,
            CustomConditionUnShowList,
            CustomColumnShow,
            CustomColumnUnShow,
            CustomConditionShow,
            CustomConditionUnShow,
            tSplitH,
            tSplitV,
            tColumnName,
            tColumnSortID,
            tColumnWidth,
            tConditionName,
            tConditionSortID,
            tConditionOperator,
            tConditionValue,
            tConditionAndOr
        }

        int splitSplitterMoveCount = 0;
        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (splitSplitterMoveCount < 10)
            {
                splitSplitterMoveCount++;
                return;
            }
            SaveCustomSetting();
        }

        int splitSizeChangedCount = 0;
        private void splitContainer_SizeChanged(object sender, EventArgs e)
        {
            if (splitSizeChangedCount == 10)
            {
                splitSizeChangedCount++;
                SetViewWhenLoaded();
                InitFp();
                if (reportSetting.UseLoadAndQuery)
                    Query();
            }
            splitSizeChangedCount++;
        }

        public int Print()
        {
            if (gridSetting.UseHeader)
                fpMain_Sheet1.PrintInfo.ShowColumnHeaders=false;  
            fpMain.PrintSheet(0);
            return 1;
        }

        /// <summary>
        /// 停止计时。
        /// </summary>
        private void WatchStop()
        {
            MyWatch.Stop();
            queryTimeUsed = MyWatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// 开始计时。
        /// </summary>
        private void WatchStart()
        {
            MyWatch.Reset();
            MyWatch.Start();
            queryTimeUsed = 0;
        }

        private void fpMain_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            ColumnWidthChanged();
            SaveCustomSetting();
        }

        private void tbTreeExp_Click(object sender, EventArgs e)
        {
            tvReport.ExpandAll();
        }

        private void tbTreeCol_Click(object sender, EventArgs e)
        {
            tvReport.CollapseAll();
        }

        private void fpMain_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader||fpMain_Sheet1.Rows[e.Row].Tag is Objects.Header)
            {
                e.Cancel = true;
                return;
            }
            if (interfacesSetting.INeedDatasActionType == ucReportInterfaceOtherSetting.INeedDatasActionType.单击激活接口)
            {
                if (reportType == ReportType.Grid)
                    ProcessINeedDatas(e.Row);
                else
                    ProcessINeedDatas(e.Row, e.Column);
            }
            if (detailSetting.ActionType == QuickReportCore.Forms.frmQuickReportEditor.QueryActionType.单击激活查询 && reportSetting.UseDetail)
            {
                if (reportType == ReportType.Grid)
                    QueryDetail(e.Row);
                else
                    QueryDetail(e.Row, e.Column);
            }
        }

        private void fpMain_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader || fpMain_Sheet1.Rows[e.Row].Tag is Objects.Header)
            {
                e.Cancel = true;
                return;
            }
            if (interfacesSetting.INeedDatasActionType == ucReportInterfaceOtherSetting.INeedDatasActionType.双击激活接口)
            {
                if (reportType == ReportType.Grid)
                    ProcessINeedDatas(e.Row);
                else
                    ProcessINeedDatas(e.Row, e.Column);
            }
            if (detailSetting.ActionType == QuickReportCore.Forms.frmQuickReportEditor.QueryActionType.双击激活查询 && reportSetting.UseDetail)
            {
                if (reportType == ReportType.Grid)
                    QueryDetail(e.Row);
                else
                    QueryDetail(e.Row, e.Column);
            }
        }

        private void tvReport_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeSetting.ActionType == QuickReportCore.Forms.frmQuickReportEditor.QueryActionType.双击激活查询)
            {
                Query();
            }
        }

        private void tvReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeSetting.ActionType == QuickReportCore.Forms.frmQuickReportEditor.QueryActionType.单击激活查询)
            {
                Query();
            }
        }

        #region 对列排序的算法。未使用。
        private void SortColumn(int columnIndex, int startRowIndex, int endRowIndex, SortType sortType)
        {
            if (startRowIndex >= endRowIndex)
                return;
            ArrayList al = new ArrayList();
            for (int i = startRowIndex; i <= endRowIndex; i++)
            {
                al.Add(new Objects.CompareableRow(fpMain_Sheet1.Cells[i, columnIndex].Value, fpMain_Sheet1.Rows[i]));
            }
            QuickReportCore.Objects.CompareableRowComparer.ValueType valueType;
            if (reportType == ReportType.Grid)
            {
                if ((htColumnsBase[fpMain_Sheet1.ColumnHeader.Cells[fpMain_Sheet1.ColumnHeader.Rows.Count - 1, columnIndex].Value.ToString()] as Objects.Column).IsNumber)
                {
                    valueType = QuickReportCore.Objects.CompareableRowComparer.ValueType.Decimal;
                }
                else
                {
                    valueType = QuickReportCore.Objects.CompareableRowComparer.ValueType.String;
                }
            }
            else
            {
                if ((htColumnsBase[crossSetting.Value] as Objects.Column).IsNumber)
                {
                    valueType = QuickReportCore.Objects.CompareableRowComparer.ValueType.Decimal;
                }
                else
                {
                    valueType = QuickReportCore.Objects.CompareableRowComparer.ValueType.String;
                }
            }
            al.Sort(new Objects.CompareableRowComparer(valueType) as IComparer);
            if (sortType == SortType.ASC)
            {
                int index = startRowIndex;
                for (int i = 0; i < al.Count; i++)
                {
                    FarPoint.Win.Spread.Row r = (al[i] as Objects.CompareableRow).Row;
                    fpMain_Sheet1.MoveRow(r.Index, index, true);
                    index++;
                }
            }
            else
            {
                int index = endRowIndex;
                for (int i = 0; i < al.Count; i++)
                {
                    FarPoint.Win.Spread.Row r = (al[i] as Objects.CompareableRow).Row;
                    fpMain_Sheet1.MoveRow(r.Index, index, true);
                    index--;
                }
            }
        }

        private void SortColumn(int columnIndex, SortType sortType)
        {
            int start = 0;
            int end = 0;
            if (groupSumsRowIndexMap.Count == 0)
            {
                end = fpMain_Sheet1.Rows.Count - headerSettingBottom.Count - 1;
                SortColumn(columnIndex, start, end, sortType);
                return;
            }
            int count = 0;
            for (int i = 0; i < groupSumsRowIndexMap.Count; i++)
            {
                if (groupSumsRowIndexMap[i + 1] != null)
                {
                    if (i == 0)
                    {
                        end = Convert.ToInt32(groupSumsRowIndexMap[i]);
                    }
                    else
                    {
                        start = Convert.ToInt32(groupSumsRowIndexMap[i]) + 1 + count;
                        end = Convert.ToInt32(groupSumsRowIndexMap[i + 1]) + count;
                    }
                    SortColumn(columnIndex, start, end, sortType);
                }
                count++;
            }
        }
        #endregion

        private void ClearReportFarpoint()
        {
            fpMain_Sheet1.ColumnHeader.Rows.Count = 0;
            fpMain_Sheet1.ColumnHeader.Columns.Count = 0;
            fpMain_Sheet1.Rows.Count = 0;
            fpMain_Sheet1.Columns.Count = 0;
            reportDataColumnNumer = reportDataRowNumber = 0;
            queryTimeUsed = 0;
        }

        private bool haveChangedGroupSumColor = false;
        private void fpMain_AutoSortingColumn(object sender, FarPoint.Win.Spread.AutoSortingColumnEventArgs e)
        {
            if (reportType == ReportType.Grid)
            {
                e.Cancel = true;
                if (fpMain_Sheet1.DataSource == null || dvReport == null)
                    return;
                Objects.Column c = htColumnsBase[gridSetting.GroupSumRow] as Objects.Column;
                int sumStringIndex = 0;
                if (c != null)
                    sumStringIndex = c.SortId;
                if (!haveChangedGroupSumColor)
                {
                    foreach (FarPoint.Win.Spread.Row row in groupSumsRowList)
                    {
                        fpMain_Sheet1.Rows[row.Index].Font = null;//只有设置为Null后，后面的SetColumnAttrToCustomAfterQuery才会起作用。
                    }
                    haveChangedGroupSumColor = true;
                }
                string sort = string.Empty;
                if (dvReport.Sort.Contains("ASC"))
                    dvReport.Sort = fpMain_Sheet1.Columns[e.Column].DataField + " DESC";
                else
                    dvReport.Sort = fpMain_Sheet1.Columns[e.Column].DataField + " ASC";
                SetColumnAttrToCustomAfterQuery();
                AddBottomHeaderAfterQuery(MainOrDetail.Main);
            }
            else if (reportType == ReportType.GeneralCross)
            {

            }
            else if (reportType == ReportType.CustomCross)
            {

            }
        }

        /// <summary>
        /// 翻译字符串。
        /// </summary>
        /// <param name="s">字符串。</param>
        /// <param name="types">翻译种类。</param>
        /// <returns>翻译后的字符串。</returns>
        private string TranslateValue(string s, Managers.Functions.SQLCodeType[] types)
        {
            if (!s.Contains("["))//如果s中不含有变量，则返回s。
                return s;
            string str = s;
            for (int i = 0; i < types.Length; i++)
            {
                switch (types[i])
                {
                    case QuickReportCore.Managers.Functions.SQLCodeType.System:
                        str = Managers.Functions.TranslateTextWithSystemValue(str);
                        break;
                    case QuickReportCore.Managers.Functions.SQLCodeType.Tree:
                        str = TranslateTextWithTreeValue(str);
                        break;
                    case QuickReportCore.Managers.Functions.SQLCodeType.Column:
                        str = TranslateTextWithColumnValue(str);
                        break;
                    case QuickReportCore.Managers.Functions.SQLCodeType.Condition:
                        str = TranslateTextWithConditionValue(str);
                        break;
                    case QuickReportCore.Managers.Functions.SQLCodeType.Dynamic:
                        str = TranslateTextWithDynamicValue(str);
                        break;
                }
            }
            return str;
        }

        /// <summary>
        /// 根据Cell的Value值，获得该Cell的文本值。
        /// </summary>
        /// <param name="cell">Cell。</param>
        /// <returns>文本值。</returns>
        private string GetCellStringValue(FarPoint.Win.Spread.Cell cell,string valueWhenNull)
        {
            if (cell.Value == null)
                return valueWhenNull;
            else
                return cell.Value.ToString();
        }

        /// <summary>
        /// 获得一组Cell的字符。
        /// </summary>
        /// <param name="rowIndexs">行们。</param>
        /// <param name="columnIndexs">列们。</param>
        /// <param name="spliter">分隔符。</param>
        /// <returns>字符。</returns>
        private string GetCellsStringValue(int[] rowIndexs,int[] columnIndexs,string spliter)
        {
            string s = string.Empty;
            for (int i = 0; i < rowIndexs.Length; i++)
            {
                for (int j = 0; j < columnIndexs.Length; j++)
                    s += GetCellStringValue(fpMain_Sheet1.Cells[i, j], string.Empty)+spliter;
            }
            return s.Substring(0, s.Length - 1);
        }

        /// <summary>
        /// 排序方式。
        /// </summary>
        public enum SortType
        {
            /// <summary>
            /// 升序。
            /// </summary>
            ASC,
            /// <summary>
            /// 降序。
            /// </summary>
            DESC
        }

        /// <summary>
        /// 报表类型。
        /// </summary>
        public enum ReportType
        {
            /// <summary>
            /// 网格报表。
            /// </summary>
            Grid,
            /// <summary>
            /// 普通交叉报表。
            /// </summary>
            GeneralCross,
            /// <summary>
            /// 自定义交叉报表。
            /// </summary>
            CustomCross
        }

        #region IAmReport 成员

        public decimal Version
        {
            get { return 1.10m; }
        }

        #endregion

        /// <summary>
        /// 对于交叉报表，因小计与合计的使用与否，导致有16种状态。为其中每一种状态写一个方法，将减少单个方法内部判断次数，从而提高报表生成效率。
        /// 从左到右依次为：
        /// 列小计-行小计-列合计-行合计
        /// </summary>
        public enum CrossReportQueryType
        {
            无无无无,
            无无无有,
            无无有无,
            无无有有,
            无有无无,
            无有无有,
            无有有无,
            无有有有,
            有无无无,
            有无无有,
            有无有无,
            有无有有,
            有有无无,
            有有无有,
            有有有无,
            有有有有
        }

        public enum MainOrDetail
        { 
            /// <summary>
            /// 主表。
            /// </summary>
            Main,
            /// <summary>
            /// 明细表。
            /// </summary>
            Detail
        }

        private void fpDetail_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader || fpDetail_Sheet1.Rows[e.Row].Tag is Objects.Header)
            {
                e.Cancel = true;
                return;
            }
        }

        private void fpDetail_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader || fpDetail_Sheet1.Rows[e.Row].Tag is Objects.Header)
            {
                e.Cancel = true;
                return;
            }
        }

        #region IAmReport 成员


        public int Export()
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.FileName = quickReport.Name;
            sd.Filter = "Excel (.xls)|*.xls";
            DialogResult dr = sd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    fpMain.SaveExcel(sd.FileName, FarPoint.Excel.ExcelSaveFlags.SaveBothCustomRowAndColumnHeaders);
                }
                catch(Exception e)
                {
                    MessageBox.Show("导出失败。"+e.Message,"提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            return 1;
        }

        #endregion
    }
}
