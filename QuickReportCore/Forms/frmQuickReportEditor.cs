using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.Reflection;


namespace QuickReportCore.Forms
{
    internal partial class frmQuickReportEditor : frmBase
    {
        public static XmlDocument xmlDocument = new XmlDocument();

        private QuickReportCore.Managers.QuickReportManager quickReportManager = new QuickReportCore.Managers.QuickReportManager();
        private QuickReportCore.Objects.QuickReportObject quickReport = new QuickReportCore.Objects.QuickReportObject();
        private bool sqlIsEditing = false;
        private bool rbViewCrossProtector = false;
        private bool rbViewGridProtector = false;
        private bool needBeSaved = false;
        private ColorDialog cd = new ColorDialog();
        private FontConverter fc = new FontConverter();
        private frmToolBoxCrossSetting toolBoxCrossSetting = new frmToolBoxCrossSetting();
        private frmToolBoxSystemValue toolBoxSystemValue = new frmToolBoxSystemValue();
        private frmToolBoxConditionTypeEditor toolBoxConditionTypeEditor = new frmToolBoxConditionTypeEditor();
        private frmToolBoxGridSetting toolBoxGridSetting = new frmToolBoxGridSetting();
        private List<Interfaces.INeedRefreshDataSource> needRefreshDataSourceControls = new List<Interfaces.INeedRefreshDataSource>();
        private FontDialog treeGroupFont = new FontDialog();
        private FontDialog treeRootFont = new FontDialog();
        private FontDialog treeNameFont = new FontDialog();
        private ColorDialog treeGroupColor = new ColorDialog();
        private ColorDialog treeRootColor = new ColorDialog();
        private ColorDialog treeNameColor = new ColorDialog();
        private Forms.frmTreeIconSelector treeGroupIcon;
        private Forms.frmTreeIconSelector treeRootIcon;
        private Forms.frmTreeIconSelector treeNameIcon;
        private int treeGroupIconIndex = 0;
        private int treeRootIconIndex = 0;
        private int treeNameIconIndex = 0;
        private Color defaultEvenColor = Color.FromArgb(204, 232, 207);

        public static List<QuickReportCore.Objects.Column> GobalTreeColumnList = new List<QuickReportCore.Objects.Column>();

        public frmQuickReportEditor()
        {
            InitializeComponent();
        }

        public void Init()
        {
            try
            {
                InitInterfaceSetting();
                InitReportTypes();
                InitTreeAndDetailQueryActionType();
                InitViewSetting();
                InitToolBoxs();
                InitQuickReport();
                InitFontDialogBox();
            }
            catch(Exception e)
            {
                MessageBox.Show("�������ʧ�ܡ�\nԭ��"+e.Message,"��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void InitInterfaceSetting()
        {
            ucReportInterfacesSetting.InitPublicInterfaceTypes();
        }

        private void InitViewSetting()
        {
            toolBoxCrossSetting.Hide();
            pnlEvenColor.BackColor = defaultEvenColor;
        }

        private void InitFontDialogBox()
        {
            treeGroupFont.Font = new Font("΢���ź�", 9, System.Drawing.FontStyle.Regular);
            treeRootFont.Font = new Font("΢���ź�", 9, System.Drawing.FontStyle.Regular);
            treeNameFont.Font = new Font("΢���ź�", 9, System.Drawing.FontStyle.Regular);
        }

        private void InitToolBoxs()
        {
            AddOwnedForm(toolBoxSystemValue);
            toolBoxSystemValue.Location = new Point(Location.X + Width + toolBoxSystemValue.DockParentMarginal, Location.Y);
            AddOwnedForm(toolBoxCrossSetting);
            toolBoxCrossSetting.Location = new Point(Location.X + Width + toolBoxCrossSetting.DockParentMarginal, Location.Y + toolBoxSystemValue.Height + 15);
            AddOwnedForm(toolBoxGridSetting);
            toolBoxGridSetting.Location = new Point(Location.X + Width + toolBoxGridSetting.DockParentMarginal, Location.Y + toolBoxSystemValue.Height + 15);
            AddOwnedForm(toolBoxConditionTypeEditor);
            toolBoxConditionTypeEditor.Location = new Point(Location.X + Width + toolBoxConditionTypeEditor.DockParentMarginal, Location.Y + toolBoxSystemValue.Height  + 15);
            ucConditionList.InitFormConditionEditor(toolBoxConditionTypeEditor);
            needRefreshDataSourceControls.Add(toolBoxSystemValue as Interfaces.INeedRefreshDataSource);
            needRefreshDataSourceControls.Add(toolBoxCrossSetting as Interfaces.INeedRefreshDataSource);
            needRefreshDataSourceControls.Add(toolBoxGridSetting as Interfaces.INeedRefreshDataSource);
        }

        private void InitReportTypes()
        {
            cmbReportType.Items.Clear();
            ArrayList reportTypes = quickReportManager.QueryAllReportTypes();
            for (int i = 0; i < reportTypes.Count; i++)
            {
                cmbReportType.Items.Add(reportTypes[i].ToString());
            }
        }

        private void InitQuickReport()
        {
            txtReportName.Text = quickReport.Name;
            cmbReportType.Text = quickReport.Type;
            if (quickReport.Content.Trim() != string.Empty)
            {
                xmlDocument.LoadXml(Managers.EncryptionManager.Decrypt(quickReport.Content));
                ParseFromXml();
            }
        }

        private void InitTreeAndDetailQueryActionType()
        {
            cmbTreeActionType.Items.Clear();
            cmbTreeActionType.Items.Add(QueryActionType.�����ѯ��ť);
            cmbTreeActionType.Items.Add(QueryActionType.���������ѯ);
            cmbTreeActionType.Items.Add(QueryActionType.˫�������ѯ);
            cmbTreeActionType.Text = QueryActionType.�����ѯ��ť.ToString();
            cmbDetailActionType.Items.Clear();
            cmbDetailActionType.Items.Add(QueryActionType.���������ѯ);
            cmbDetailActionType.Items.Add(QueryActionType.˫�������ѯ);
            cmbDetailActionType.Text = QueryActionType.���������ѯ.ToString();
        }

        private void GetQuickReport()
        {
            quickReport.Name = txtReportName.Text;
            quickReport.Type = cmbReportType.Text;
            quickReport.Version = Managers.Functions.GetLastestVersion();
            quickReport.Content =Managers.EncryptionManager.Encrypt(GetContent());
        }

        /// <summary>
        /// �ӽ����ϻ�ȡ���ݣ���дΪXml�ĵ����ء�
        /// </summary>
        /// <returns></returns>
        private string GetContent()
        {
            return ConvertToXml();
        }

        private void EditSql()
        {
            if (!sqlIsEditing)
            {
                sqlIsEditing = true;
                txtReportSql.ReadOnly = false;
                txtReportSql.Focus();
                tbEditSql.Checked = true;
                tbEditSql.ToolTipText = "����SQL��";
            }
            else
            {
                string s = txtReportSql.Text.Replace(Managers.Functions.GetSQLCode(  Forms.frmToolBoxSystemValue.TreeValueType.�ڵ����.ToString() , QuickReportCore.Managers.Functions.SQLCodeType.Tree), "''");
                s = s.Replace(Managers.Functions.GetSQLCode(  Forms.frmToolBoxSystemValue.TreeValueType.�ڵ�����.ToString(), QuickReportCore.Managers.Functions.SQLCodeType.Tree), "''");
                ArrayList list = QuickReportCore.Managers.Functions.ParseSql(s);
                if (list == null || list[0] == null || list[1] == null)
                {
                    QuickReportCore.Managers.Functions.ShowToolTip(grbEditSql, "SQL����ʽ�����޷�����SQL��", grbEditSql.Location);
                    return;
                }
                else
                {
                    if (ShowColumns(list[0] as List<QuickReportCore.Objects.Column>) < 0)
                    {
                        QuickReportCore.Managers.Functions.ShowToolTip(grbEditSql, "������ʧ�ܡ�", grbEditSql.Location);
                        return;
                    }
                    ReportColumnChanged();
                    QuickReportCore.Controls.ucConditionObject.RefreshingConditionProtector = true;
                    if (ShowConditions(list[1] as List<QuickReportCore.Objects.Condition>) < 0)
                    {
                        QuickReportCore.Managers.Functions.ShowToolTip(grbEditSql, "��������ʧ�ܡ�", grbEditSql.Location);
                        return;
                    }
                    QuickReportCore.Controls.ucConditionObject.RefreshingConditionProtector = false;
                    ReportConditionChanged();
                }
                sqlIsEditing = false;
                txtReportSql.ReadOnly = true;
                tbEditSql.Checked = false;
                tbEditSql.ToolTipText = "���SQL������";
                ReBandingColumnAndConditionListControl();
            }
        }


        private int Save()
        {
            if (sqlIsEditing)
            {
                QuickReportCore.Managers.Functions.ShowToolTip(grbEditSql, "��������SQL��", grbEditSql.Location);
                return -1;
            }
            if (CheckInput() < 0)
                return -1;
            Neusoft.NFC.Management.PublicTrans.BeginTransaction();
            GetQuickReport();
            if (quickReport.ID != string.Empty)
            {
                if (quickReportManager.UpdateQuickReportByID(quickReport, quickReport.ID) < 0)
                {
                    QuickReportCore.Managers.Functions.ShowToolTip(toolStripMain, "����ʧ�ܡ�\n" + quickReportManager.Err, new Point(toolStripMain.Location.X, toolStripMain.Location.Y + tbSave.Height));
                    Neusoft.NFC.Management.PublicTrans.RollBack();
                    return -1;
                }
            }
            else
            {
                quickReport.ID = quickReportManager.QueryQuickReportSeqID();
                if (quickReportManager.InsertQuickReport(quickReport) < 0)
                {
                    QuickReportCore.Managers.Functions.ShowToolTip(toolStripMain, "����ʧ�ܡ�\n" + quickReportManager.Err, new Point(toolStripMain.Location.X, toolStripMain.Location.Y + tbSave.Height));
                    quickReport.ID = string.Empty;
                    Neusoft.NFC.Management.PublicTrans.RollBack();
                    return -1;
                }
            }
            Neusoft.NFC.Management.PublicTrans.Commit();
            NeedSave(false);
            return 1;
        }


        private int CheckInput()
        {
            if (cmbReportType.Text.Trim() == string.Empty)
            {
                tabControl.SelectedIndex = 0;
                Managers.Functions.ShowToolTip(cmbReportType, "�����뱨����ࡣ", true);
                return -1;
            }
            if (txtReportName.Text.Trim() == string.Empty)
            {
                tabControl.SelectedIndex = 0;
                Managers.Functions.ShowToolTip(txtReportName, "�����뱨�����ơ�", true);
                return -1;
            }
            if (txtReportSql.Text.Trim() == string.Empty)
            {
                tabControl.SelectedIndex = 0;
                Managers.Functions.ShowToolTip(grbEditSql, "�����뱨��SQL��", grbEditSql.Location);
                return -1;
            }
            int i = CheckTreeInput();
            if (i < 0)
                return i;
            i = CheckDetailInput();
            if (i < 0)
                return i;
            if (rbViewCross.Checked)
            {
                i = CheckCrossSettingInput();
                if (i < 0)
                {
                    tabControl.SelectedIndex = 3;
                    return i;
                }
            }
            if (rbViewGrid.Checked)
            {
               i= CheckGridSettingInput();
               if (i < 0)
               {
                   tabControl.SelectedIndex = 3;
                   return i;
               }
            }
            return 1;
        }

        private int CheckTreeInput()
        {
            if (tbUseTree.Checked)
            {
                if (cmbTreeCode.Text == string.Empty)
                {
                    tabControl.SelectedIndex = 4;
                    tabControlTreeSetting.SelectedIndex = 0;
                    Managers.Functions.ShowToolTip(cmbTreeCode, "��ѡ����롣", 3000);
                    return -1;
                }
                if (cmbTreeName.Text == string.Empty)
                {
                    tabControl.SelectedIndex = 4;
                    tabControlTreeSetting.SelectedIndex = 0;
                    Managers.Functions.ShowToolTip(cmbTreeName, "��ѡ�����ơ�", 3000);
                    return -1;
                }
                if (cmbTreeGroupCode.Text != string.Empty && cmbTreeGroupName.Text == string.Empty)
                {
                    tabControl.SelectedIndex = 4;
                    tabControlTreeSetting.SelectedIndex = 0;
                    Managers.Functions.ShowToolTip(cmbTreeGroupName, "��ѡ��������ơ�", 3000);
                    return -1;
                }
                if (cmbTreeGroupName.Text != string.Empty && cmbTreeGroupCode.Text == string.Empty)
                {
                    tabControl.SelectedIndex = 4;
                    tabControlTreeSetting.SelectedIndex = 0;
                    Managers.Functions.ShowToolTip(cmbTreeGroupCode, "��ѡ�������롣", 3000);
                    return -1;
                }
                if(txtTreeSql.Text.Trim()==string.Empty)
                {
                    tabControl.SelectedIndex = 4;
                    Managers.Functions.ShowToolTip(txtTreeSql, "������һ������ʹ�õ�SQL��", txtTreeSql.Location);
                    return -1;
                }
            }
            return 1;
        }

        private int CheckDetailInput()
        {
            if (tbUseDetail.Checked)
            {
                if (txtDetailSql.Text.Trim() == string.Empty)
                {
                    tabControl.SelectedIndex = 5;
                    tabControlDetailSetting.SelectedIndex = 0;
                    Managers.Functions.ShowToolTip(txtDetailSql, "������һ������ʹ�õ�SQL��", txtDetailSql.Location);
                    return -1;
                }
            }
            return 1;
        }

        private int CheckCrossSettingInput()
        {
            return toolBoxCrossSetting.CheckInput();
        }

        private int CheckGridSettingInput()
        {
            return 1;
        }

        private void ShowCrossSetting(bool b)
        {
            if (b)
            {
                toolBoxCrossSetting.Show();
                StartHooker();
            }
            else
            {
                toolBoxCrossSetting.Hide();
            }
        }

        private void ShowGridSetting(bool b)
        {
            if (b)
            {
                toolBoxGridSetting.Show();
                StartHooker();
            }
            else
            {
                toolBoxGridSetting.Hide();
            }
        }

        private int ShowColumns(List<QuickReportCore.Objects.Column> columnList)
        {
            return ucColumnList.ShowColumns(columnList);
        }

        private int ShowConditions(List<QuickReportCore.Objects.Condition> conditionList)
        {
            return ucConditionList.ShowConditions(conditionList);
        }

        /// <summary>
        /// ���ؿ�ݱ���
        /// </summary>
        /// <param name="qr">��ݱ���ʵ�塣</param>
        public void LoadQuickReport(QuickReportCore.Objects.QuickReportObject qr)
        {
            quickReport = qr;
            if (quickReport.ID != string.Empty)
                quickReport = quickReportManager.QueryReportByID(qr.ID);
            Init();
        }

        #region �¼�
        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (sqlIsEditing &&e.TabPageIndex !=0)
            {
                e.Cancel = true;
                QuickReportCore.Managers.Functions.ShowToolTip(grbEditSql, "��������SQL��", grbEditSql.Location);
                return;
            }
            if (e.TabPageIndex == 3)
            {
                Managers.Functions.MouseClick();
                if (rbViewCross.Checked)
                {
                    toolBoxCrossSetting.Show();
                    StartHooker();
                }
                if (rbViewGrid.Checked)
                {
                    toolBoxGridSetting.Show();
                    StartHooker();
                }
            }
            else
            {
                toolBoxCrossSetting.Hide();
                toolBoxGridSetting.Hide();
            }
            if (e.TabPageIndex != 2)
            {
                toolBoxConditionTypeEditor.Hide();
            }
        }

        private void tbColumnDown_Click(object sender, EventArgs e)
        {
            ucColumnList.MoveObject(QuickReportCore.Controls.ucColumnList.MoveOrder.Down);
        }

        private void tbColumnUp_Click(object sender, EventArgs e)
        {
            ucColumnList.MoveObject(QuickReportCore.Controls.ucColumnList.MoveOrder.Up);
        }

        private void tbConditionDown_Click(object sender, EventArgs e)
        {
            ucConditionList.MoveObject(QuickReportCore.Controls.ucConditionList.MoveOrder.Down);
        }

        private void tbConditionUp_Click(object sender, EventArgs e)
        {
            ucConditionList.MoveObject(QuickReportCore.Controls.ucConditionList.MoveOrder.Up);
        }

        private void txtReportName_TextChanged(object sender, EventArgs e)
        {
            quickReport.Name = txtReportName.Text;
            Text = quickReport.Name + " - �༭����";
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            quickReport.Type = cmbReportType.Text;
        }

        private void tbEditSql_Click(object sender, EventArgs e)
        {
            EditSql();
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            int i = Save();
            if (i == 1)
                QuickReportCore.Managers.Functions.ShowToolTip(toolStripMain, "����ɹ���\n" + "����ID��" + quickReport.ID + "��", new Point(toolStripMain.Location.X, toolStripMain.Location.Y + tbSave.Height));
        }

        private void frmQuickReportEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            QuickReportCore.Managers.KeyboardAndMouseHooker.Hooker.Stop();
            QuickReportCore.Managers.KeyboardAndMouseHooker.Hooker = null;
        }

        #endregion


        private string ConvertToXml()
        {
            xmlDocument.RemoveAll();
            XmlDeclaration dec = xmlDocument.CreateXmlDeclaration("1.0", "GB2312", null);
            xmlDocument.AppendChild(dec);
            XmlElement root = xmlDocument.CreateElement(XmlAttrDic.QuickReportSetting.ToString());
            xmlDocument.AppendChild(root);
            root.AppendChild(GetReportBaseInfoXml());
            root.AppendChild(ucColumnList.ConvertToXml());
            root.AppendChild(ucConditionList.ConvertToXml());
            root.AppendChild(GetViewXml());
            xmlDocument.Save("c:\\a.xml");
            return xmlDocument.OuterXml;
        }

        private XmlElement GetViewXml()
        {
            System.Xml.XmlElement node = xmlDocument.CreateElement(XmlAttrDicViewSetting.ViewSetting.ToString());
            node.SetAttribute(XmlAttrDicViewSetting.bGridView.ToString(), Convert.ToInt32(rbViewGrid.Checked).ToString());
            node.SetAttribute(XmlAttrDicViewSetting.bCrossView.ToString(), Convert.ToInt32(rbViewCross.Checked).ToString());
            node.SetAttribute(XmlAttrDicViewSetting.bUseTree.ToString(), Convert.ToInt32(tbUseTree.Checked).ToString());
            node.SetAttribute(XmlAttrDicViewSetting.bUseDetail.ToString(), Convert.ToInt32(tbUseDetail.Checked).ToString());
            node.SetAttribute(XmlAttrDicViewSetting.bLoadAndQuery.ToString(), Convert.ToInt32(cbLoadAndQuery.Checked).ToString());
            node.SetAttribute(XmlAttrDicViewSetting.bAutoColumnWidth.ToString(), Convert.ToInt32(cbAutoColumnWidth.Checked).ToString());
            node.SetAttribute(XmlAttrDicViewSetting.bViewOpen.ToString(), Convert.ToInt32(cbViewOpen.Checked).ToString());
            node.SetAttribute(XmlAttrDicViewSetting.tEvenColor.ToString(), System.Drawing.ColorTranslator.ToHtml(pnlEvenColor.BackColor));
            node.SetAttribute(XmlAttrDicViewSetting.bUseEvenColor.ToString(), Convert.ToInt32(cbUseEvenColor.Checked).ToString());
            node.AppendChild(GetViewReportXml());
            node.AppendChild(GetViewTreeXml());
            node.AppendChild(GetViewDetailXml());
            node.AppendChild(toolBoxCrossSetting.ConvertToXml());
            node.AppendChild(toolBoxGridSetting.ConvertToXml());
            return node;
        }

        private XmlElement GetViewReportXml()
        {
            System.Xml.XmlElement node = xmlDocument.CreateElement(XmlAttrDicViewSettingReport.ReportHeaderSetting.ToString());
            node.AppendChild(GetViewReportHeaderTopXml());
            node.AppendChild(GetViewReportHeaderBottomXml());
            node.AppendChild(GetViewReportDetailHeaderTopXml());
            node.AppendChild(GetViewReportDetailHeaderBottomXml());
            node.AppendChild(ucReportInterfacesSetting.ConvertToXml());
            return node;
        }

        private XmlElement GetViewTreeXml()
        {
            System.Xml.XmlElement node = xmlDocument.CreateElement(XmlAttrDicViewSettingTree.TreeSetting.ToString());
            node.SetAttribute(XmlAttrDicViewSettingTree.tTreeSql.ToString(), txtTreeSql.Text);
            node.SetAttribute(XmlAttrDicViewSettingTree.tTreeRootCode.ToString(), txtTreeRootCode.Text);
            node.SetAttribute(XmlAttrDicViewSettingTree.tTreeRootName.ToString(), txtTreeRootName.Text);
            node.SetAttribute(XmlAttrDicViewSettingTree.tTreeCode.ToString(), cmbTreeCode.Text);
            node.SetAttribute(XmlAttrDicViewSettingTree.tTreeName.ToString(), cmbTreeName.Text);
            node.SetAttribute(XmlAttrDicViewSettingTree.tTreeGroupCode.ToString(), cmbTreeGroupCode.Text);
            node.SetAttribute(XmlAttrDicViewSettingTree.tTreeGroupName.ToString(), cmbTreeGroupName.Text);
            node.SetAttribute(XmlAttrDicViewSettingTree.bDefaultCollpased.ToString(), Convert.ToInt32(cbTreeCollapsed.Checked).ToString());
            node.SetAttribute(XmlAttrDicViewSettingTree.tTreeSelectAction.ToString(), cmbTreeActionType.Text);
            node.SetAttribute(XmlAttrDicViewSettingTree.tTreeGroupFont.ToString(), fc.ConvertToInvariantString(treeGroupFont.Font));
            node.SetAttribute(XmlAttrDicViewSettingTree.tTreeRootFont.ToString(), fc.ConvertToInvariantString(treeRootFont.Font));
            node.SetAttribute(XmlAttrDicViewSettingTree.tTreeNameFont.ToString(), fc.ConvertToInvariantString(treeNameFont.Font));
            node.SetAttribute(XmlAttrDicViewSettingTree.tTreeGroupColor.ToString(), System.Drawing.ColorTranslator.ToHtml(treeGroupColor.Color));
            node.SetAttribute(XmlAttrDicViewSettingTree.tTreeRootColor.ToString(), System.Drawing.ColorTranslator.ToHtml(treeRootColor.Color));
            node.SetAttribute(XmlAttrDicViewSettingTree.tTreeNameColor.ToString(), System.Drawing.ColorTranslator.ToHtml(treeNameColor.Color));
            node.SetAttribute(XmlAttrDicViewSettingTree.tTreeGroupIcon.ToString(), treeGroupIconIndex.ToString());
            node.SetAttribute(XmlAttrDicViewSettingTree.tTreeRootIcon.ToString(), treeRootIconIndex.ToString());
            node.SetAttribute(XmlAttrDicViewSettingTree.tTreeNameIcon.ToString(), treeNameIconIndex.ToString());
            node.SetAttribute(XmlAttrDicViewSettingTree.bTreeMultiSelect.ToString(), Convert.ToInt32(cbTreeMultiSelect.Checked).ToString());
            return node;
        }

        private XmlElement GetViewDetailXml()
        {
            System.Xml.XmlElement node = xmlDocument.CreateElement(XmlAttrDicViewSettingDetail.DetailSetting.ToString());
            node.SetAttribute(XmlAttrDicViewSettingDetail.tDetailSql.ToString(), txtDetailSql.Text);
            node.SetAttribute(XmlAttrDicViewSettingDetail.tDetailAction.ToString(), cmbDetailActionType.Text);
            return node;
        }

        private XmlElement GetViewReportHeaderTopXml()
        {
            System.Xml.XmlElement node = xmlDocument.CreateElement(XmlAttrDicViewSettingReport.HeaderTopSetting.ToString());
            node.AppendChild(ucReportHeaderSettingTop.ConvertToXml());
            return node;
        }

        private XmlElement GetViewReportHeaderBottomXml()
        {
            System.Xml.XmlElement node = xmlDocument.CreateElement(XmlAttrDicViewSettingReport.HeaderBottomSetting.ToString());
            node.AppendChild(ucReportHeaderSettingBottom.ConvertToXml());
            return node;
        }

        private XmlElement GetViewReportDetailHeaderTopXml()
        {
            System.Xml.XmlElement node = xmlDocument.CreateElement(XmlAttrDicViewSettingReport.DetailHeaderTopSetting.ToString());
            node.AppendChild(ucReportDetailHeaderSettingTop.ConvertToXml());
            return node;
        }

        private XmlElement GetViewReportDetailHeaderBottomXml()
        {
            System.Xml.XmlElement node = xmlDocument.CreateElement(XmlAttrDicViewSettingReport.DetailHeaderBottomSetting.ToString());
            node.AppendChild(ucReportDetailHeaderSettingBottom.ConvertToXml());
            return node;
        }

        private XmlElement GetReportBaseInfoXml()
        {
            System.Xml.XmlElement node = xmlDocument.CreateElement(XmlAttrDic.ReportBaseInfo.ToString());
            node.SetAttribute(XmlAttrDic.tReportType.ToString(), cmbReportType.Text);
            node.SetAttribute(XmlAttrDic.tReportName.ToString(), txtReportName.Text);
            node.SetAttribute(XmlAttrDic.tReportSql.ToString(), txtReportSql.Text);
            node.SetAttribute(XmlAttrDic.tReportVersion.ToString(), Managers.Functions.GetLastestVersion().ToString());
            return node;
        }

        public enum XmlAttrDic
        {
            QuickReportSetting,
            ReportBaseInfo,
            tReportType,
            tReportName,
            tReportSql,
            tReportVersion
        }

        public enum XmlAttrDicViewSetting
        {
            ViewSetting,
            bGridView,
            bCrossView,
            bUseTree,
            bUseDetail,
            bLoadAndQuery,
            tRowGroupSumColumn,
            bAutoColumnWidth,
            bViewOpen,
            tEvenColor,
            bUseEvenColor
        }

        public enum XmlAttrDicViewSettingReport
        { 
            ReportHeaderSetting,
            HeaderTopSetting,
            HeaderBottomSetting,
            DetailHeaderTopSetting,
            DetailHeaderBottomSetting
        }

        public enum XmlAttrDicViewSettingTree
        {
            TreeSetting,
            tTreeSql,
            tTreeCode,
            tTreeName,
            tTreeGroupCode,
            tTreeGroupName,
            tTreeRootCode,
            tTreeRootName,
            bDefaultCollpased,
            tTreeSelectAction,
            tTreeGroupFont,
            tTreeRootFont,
            tTreeNameFont,
            tTreeGroupColor,
            tTreeRootColor,
            tTreeNameColor,
            tTreeGroupIcon,
            tTreeRootIcon,
            tTreeNameIcon,
            bTreeMultiSelect
        }

        public enum XmlAttrDicViewSettingDetail
        {
            DetailSetting,
            tDetailSql,
            tDetailAction
        }

        private void ParseFromXml()
        {
            XmlNode node = xmlDocument.SelectSingleNode("//" + XmlAttrDic.ReportBaseInfo.ToString());
            if (node != null)
            {
                cmbReportType.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tReportType.ToString(), string.Empty);
                txtReportName.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tReportName.ToString(), string.Empty);
                txtReportSql.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tReportSql.ToString(), string.Empty);
                ucColumnList.ParseFromXml(xmlDocument);
                QuickReportCore.Controls.ucConditionObject.RefreshingConditionProtector = true;
                ucConditionList.ParseFromXml(xmlDocument);
                QuickReportCore.Controls.ucConditionObject.RefreshingConditionProtector = false;
            }

            ReportColumnChanged();
            ReportConditionChanged();

            node = xmlDocument.SelectSingleNode("//" + XmlAttrDicViewSetting.ViewSetting.ToString());
            if (node != null)
            {
                rbViewCrossProtector = true;
                rbViewGridProtector = true;
                rbViewCross.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSetting.bCrossView.ToString(), "0")));
                rbViewGrid.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSetting.bGridView.ToString(), "0")));
                rbViewCrossProtector = false;
                rbViewGridProtector = false;
                cbLoadAndQuery.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSetting.bLoadAndQuery.ToString(), "0")));
                cbAutoColumnWidth.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSetting.bAutoColumnWidth.ToString(), "0")));
                cbUseEvenColor.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSetting.bUseEvenColor.ToString(), "0")));
                cbViewOpen.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSetting.bViewOpen.ToString(), "0")));
                tbUseDetail.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSetting.bUseDetail.ToString(), "0")));
                tbUseTree.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSetting.bUseTree.ToString(), "0")));
                string color = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSetting.tEvenColor.ToString(), string.Empty);
                if (color != string.Empty)
                    pnlEvenColor.BackColor = System.Drawing.ColorTranslator.FromHtml(color);
            }

            node = xmlDocument.SelectSingleNode("//" + XmlAttrDicViewSettingTree.TreeSetting.ToString());
            if (node != null)
            {
                cbTreeCollapsed.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.bDefaultCollpased.ToString(), "0")));
                txtTreeSql.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.tTreeSql.ToString(), string.Empty);
                ArrayList listTreeColumn = QuickReportCore.Managers.Functions.ParseSql(txtTreeSql.Text);
                if (listTreeColumn != null && listTreeColumn[0] != null && listTreeColumn[1] != null)
                {
                    GobalTreeColumnList = listTreeColumn[0] as List<QuickReportCore.Objects.Column>;
                    TreeColumnChanged();
                }
                cmbTreeCode.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.tTreeCode.ToString(), string.Empty);
                cmbTreeName.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.tTreeName.ToString(), string.Empty);
                cmbTreeGroupCode.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.tTreeGroupCode.ToString(), string.Empty);
                cmbTreeGroupName.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.tTreeGroupName.ToString(), string.Empty);
                txtTreeRootCode.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.tTreeRootCode.ToString(), string.Empty);
                txtTreeRootName.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.tTreeRootName.ToString(), string.Empty);
                cmbTreeActionType.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.tTreeSelectAction.ToString(), string.Empty);
                treeGroupFont.Font = fc.ConvertFromInvariantString(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.tTreeGroupFont.ToString(), string.Empty)) as Font;
                treeRootFont.Font = fc.ConvertFromInvariantString(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.tTreeRootFont.ToString(), string.Empty)) as Font;
                treeNameFont.Font = fc.ConvertFromInvariantString(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.tTreeNameFont.ToString(), string.Empty)) as Font;
                treeGroupColor.Color = System.Drawing.ColorTranslator.FromHtml(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.tTreeGroupColor.ToString(), string.Empty));
                treeRootColor.Color = System.Drawing.ColorTranslator.FromHtml(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.tTreeRootColor.ToString(), string.Empty));
                treeNameColor.Color = System.Drawing.ColorTranslator.FromHtml(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.tTreeNameColor.ToString(), string.Empty));
                treeGroupIconIndex = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.tTreeGroupIcon.ToString(), "0"));
                treeRootIconIndex = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.tTreeRootIcon.ToString(), "0"));
                treeNameIconIndex = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.tTreeNameIcon.ToString(), "0"));
                cbTreeMultiSelect.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingTree.bTreeMultiSelect.ToString(), "0")));
            }

            ucReportHeaderSettingTop.ParseFromXml(xmlDocument.SelectSingleNode("//" + XmlAttrDicViewSettingReport.HeaderTopSetting.ToString()).SelectSingleNode(QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.HeaderObjectList.ToString()).SelectNodes(QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.HeaderObject.ToString()));
            ucReportHeaderSettingBottom.ParseFromXml(xmlDocument.SelectSingleNode("//" + XmlAttrDicViewSettingReport.HeaderBottomSetting.ToString()).SelectSingleNode(QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.HeaderObjectList.ToString()).SelectNodes(QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.HeaderObject.ToString()));
            ucReportDetailHeaderSettingTop.ParseFromXml(xmlDocument.SelectSingleNode("//" + XmlAttrDicViewSettingReport.DetailHeaderTopSetting.ToString()).SelectSingleNode(QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.HeaderObjectList.ToString()).SelectNodes(QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.HeaderObject.ToString()));
            ucReportDetailHeaderSettingBottom.ParseFromXml(xmlDocument.SelectSingleNode("//" + XmlAttrDicViewSettingReport.DetailHeaderBottomSetting.ToString()).SelectSingleNode(QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.HeaderObjectList.ToString()).SelectNodes(QuickReportCore.Controls.ucReportHeaderSetting.XmlAttrDic.HeaderObject.ToString()));
            ucReportInterfacesSetting.ParseFromXml(xmlDocument);

            toolBoxCrossSetting.ParseFromXml(xmlDocument);
            toolBoxGridSetting.ParseFromXml(xmlDocument);

            node = xmlDocument.SelectSingleNode("//" + XmlAttrDicViewSettingDetail.DetailSetting.ToString());
            if (node != null)
            {
                txtDetailSql.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingDetail.tDetailSql.ToString(), string.Empty);
                cmbDetailActionType.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDicViewSettingDetail.tDetailAction.ToString(), string.Empty);
            }
        }

        private void rbViewCross_CheckedChanged(object sender, EventArgs e)
        {
            if (rbViewCrossProtector)
                return;
            ShowCrossSetting(rbViewCross.Checked);
        }

        private void txtTreeSql_Leave(object sender, EventArgs e)
        {
            if (!tbUseTree.Checked)
                return;
            ArrayList list = QuickReportCore.Managers.Functions.ParseSql(txtTreeSql.Text);
            if (list == null || list[0] == null || list[1] == null)
            {
                QuickReportCore.Managers.Functions.ShowToolTip(txtTreeSql, "SQL����ʽ�������޸ġ�", txtTreeSql.Location);
                txtTreeSql.SelectAll();
                return;
            }
            else
            {
                GobalTreeColumnList = list[0] as List<QuickReportCore.Objects.Column>;
                TreeColumnChanged();
            }
        }

        private void RefreshTreeViewSetting()
        {
            string treeCode = cmbTreeCode.Text;
            string treeName = cmbTreeName.Text;
            string treeGroupCode = cmbTreeGroupCode.Text;
            string treeGroupName = cmbTreeGroupName.Text;
            cmbTreeCode.Items.Clear();
            cmbTreeName.Items.Clear();
            cmbTreeGroupCode.Items.Clear();
            cmbTreeGroupName.Items.Clear();
            for (int i = 0; i < GobalTreeColumnList.Count; i++)
            {
                cmbTreeCode.Items.Add(GobalTreeColumnList[i]);
                cmbTreeName.Items.Add(GobalTreeColumnList[i]);
                cmbTreeGroupCode.Items.Add(GobalTreeColumnList[i]);
                cmbTreeGroupName.Items.Add(GobalTreeColumnList[i]);
            }
            cmbTreeCode.Items.Add(string.Empty);
            cmbTreeName.Items.Add(string.Empty);
            cmbTreeGroupCode.Items.Add(string.Empty);
            cmbTreeGroupName.Items.Add(string.Empty);
            cmbTreeCode.Text = treeCode;
            cmbTreeName.Text = treeName;
            cmbTreeGroupCode.Text = treeGroupCode;
            cmbTreeGroupName.Text = treeGroupName;
        }

        private void TreeColumnChanged()
        {
            RefreshDataSource(frmToolBoxSystemValue.GobalValueType.Tree);
            RefreshTreeViewSetting();
        }

        private void ReportColumnChanged()
        {
            RefreshDataSource(frmToolBoxSystemValue.GobalValueType.Column);
        }

        private void ReportConditionChanged()
        {
            RefreshDataSource(frmToolBoxSystemValue.GobalValueType.Condition);
        }

        private void RefreshDataSource(frmToolBoxSystemValue.GobalValueType gobalValueType)
        {
            foreach (Interfaces.INeedRefreshDataSource i in needRefreshDataSourceControls)
            {
                if (i.GobalValueTypesNeeded().Contains(gobalValueType))
                    i.RefreshDataSource(gobalValueType);
            }
        }

        /// <summary>
        /// ���Ա���
        /// </summary>
        private void TestReport()
        {
            StopHooker();
            QuickReportCore.QuickReportShow.ShowReports(new string[] { quickReport.ID });
            StartHooker();
        }

        /// <summary>
        /// ��ʱ�����ѯ��
        /// </summary>
        public enum QueryActionType
        {
            /// <summary>
            /// �����ѯ��ť��ִ�в�ѯ��
            /// </summary>
            �����ѯ��ť,
            /// <summary>
            /// ���������ѯ��
            /// </summary>
            ���������ѯ,
            /// <summary>
            /// ˫�������ѯ��
            /// </summary>
            ˫�������ѯ
        }

        private void frmQuickReportEditor_Load(object sender, EventArgs e)
        {
            toolBoxSystemValue.Show();
            BandingChangedEvent(Controls);
            BandingToolBoxFormChangedEvent();
            BandingOtherControlsChangedEvent();
        }

        private void frmQuickReportEditor_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control.GetType().GetInterface(typeof(Interfaces.INeedRefreshDataSource).FullName) != null)
            {
                needRefreshDataSourceControls.Add(e.Control as Interfaces.INeedRefreshDataSource);
            }
        }

        private void rbViewGrid_CheckedChanged(object sender, EventArgs e)
        {
            if (rbViewGridProtector)
                return;
            ShowGridSetting(rbViewGrid.Checked);
        }

        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void frmQuickReportEditor_Activated(object sender, EventArgs e)
        {
            ReStartHooker();
        }

        private void ucConditionList_ConditionShowChanged()
        {
            ReportConditionChanged();
        }

        private void ReStartHooker()
        {
            Managers.KeyboardAndMouseHooker.Hooker.Stop();
            Managers.KeyboardAndMouseHooker.Hooker.Start();
        }

        public static void StartHooker()
        {
            Managers.KeyboardAndMouseHooker.Hooker.Start();
        }

        public static void StopHooker()
        {
            Managers.KeyboardAndMouseHooker.Hooker.Stop();
        }

        private void pnlEvenColor_Click(object sender, EventArgs e)
        {
            cd.Color = pnlEvenColor.BackColor;
            DialogResult dr = cd.ShowDialog();
            if (dr == DialogResult.OK)
                pnlEvenColor.BackColor = cd.Color;
            uc_Changed(sender, e);
        }

        private void linkLableTreeGroupFont_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StopHooker();
            treeGroupFont.ShowDialog();
            StartHooker();
        }

        private void linkLableTreeRootFont_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StopHooker();
            treeRootFont.ShowDialog();
            StartHooker();
        }

        private void linkLableTreeNameFont_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StopHooker();
            treeNameFont.ShowDialog();
            StartHooker();
        }

        private void frmQuickReportEditor_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            
        }

        private void BandingChangedEvent(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c.Controls.Count > 0)
                {
                    BandingChangedEvent(c.Controls);
                    if (c is Interfaces.IHaveBeenChanged)
                        (c as Interfaces.IHaveBeenChanged).HaveBeenChanged += new QuickReportCore.Interfaces.HaveBeenChangedHandle(uc_Changed);
                }
                if (c is TextBox)
                    (c as TextBox).TextChanged += new EventHandler(uc_Changed);
                else if (c is ComboBox)
                {
                    (c as ComboBox).SelectedIndexChanged += new EventHandler(uc_Changed);
                    (c as ComboBox).TextChanged += new EventHandler(uc_Changed);
                }
                else if (c is CheckBox)
                    (c as CheckBox).CheckedChanged += new EventHandler(uc_Changed);
                else if (c is RadioButton)
                    (c as RadioButton).CheckedChanged += new EventHandler(uc_Changed);
                else if(c is LinkLabel)
                    (c as LinkLabel).Click += new EventHandler(uc_Changed);
                else if (c is DateTimePicker)
                    (c as DateTimePicker).ValueChanged += new EventHandler(uc_Changed);
            }
        }

        void frmQuickReportEditor_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            EditChanged();
        }

        /// <summary>
        /// ���½���SQL�󣬻ᵼ�����������Ľ���ı䣬����ԭ�еĿؼ��ᱻ��գ�������Ҫ���°�һ�¡�
        /// </summary>
        private void ReBandingColumnAndConditionListControl()
        {
            BandingChangedEvent(ucColumnList.Controls);
            BandingChangedEvent(ucConditionList.Controls);
        }

        /// <summary>
        /// �󶨹������ֵ�ı��¼���
        /// </summary>
        private void BandingToolBoxFormChangedEvent()
        {
            BandingChangedEvent(toolBoxConditionTypeEditor.Controls);
            BandingChangedEvent(toolBoxCrossSetting.Controls);
            BandingChangedEvent(toolBoxGridSetting.Controls);
            toolBoxConditionTypeEditor.HaveBeenChanged += new QuickReportCore.Interfaces.HaveBeenChangedHandle(uc_Changed);
            toolBoxCrossSetting.HaveBeenChanged += new QuickReportCore.Interfaces.HaveBeenChangedHandle(uc_Changed);
        }

        private void BandingOtherControlsChangedEvent()
        {
            tbUseTree.Click += new EventHandler(uc_Changed);
            tbUseDetail.Click += new EventHandler(uc_Changed);
        }

        void uc_Changed(object sender, EventArgs e)
        {
            EditChanged();
        }

        private void EditChanged()
        {
            NeedSave(true);
        }

        public void NeedSave(bool b)
        {
            if (b)
            {
                Text = "*" + quickReport.Name;
                tbTest.Enabled = false;
            }
            else
            {
                Text = quickReport.Name;
                tbTest.Enabled = true;
            }
            needBeSaved = b;
        }

        protected override void HookOnMouseActivityEvent(object sender, MouseEventArgs e)
        {
            if (frmBaseToolBox.MouseHaveBeenEatenByWho != string.Empty)
                return;
            IntPtr activatyHandle = Managers.Functions.GetActivityWindow();
            if (activatyHandle != toolBoxSystemValue.Handle && activatyHandle != toolBoxGridSetting.Handle && activatyHandle != toolBoxCrossSetting.Handle && activatyHandle!=toolBoxConditionTypeEditor.Handle)
                return;
            if (IfPointInWindow(e.Location))
            {
                Focus();
            }
            else
                return;
            base.HookOnMouseActivityEvent(sender, e);
        }

        private void tbUseTree_Click(object sender, EventArgs e)
        {
            tbUseTree.Checked = !tbUseTree.Checked;
        }

        private void tbUseDetail_Click(object sender, EventArgs e)
        {
            tbUseDetail.Checked = !tbUseDetail.Checked;
        }

        private void tbTest_Click(object sender, EventArgs e)
        {
            TestReport();
        }

        private void frmQuickReportEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (needBeSaved)
            {
                DialogResult dr = MessageBox.Show("�Ƿ񽫸��ı��浽 " + quickReport.Name + "��", "����", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                if (dr == DialogResult.Yes)
                {
                    int i= Save();
                    if(i<0)
                        e.Cancel = true;
                }
            }
        }

        private void linkLableTreeRootColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StopHooker();
            treeRootColor.ShowDialog();
            StartHooker();
        }

        private void linkLableTreeNameColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StopHooker();
            treeNameColor.ShowDialog();
            StartHooker();
        }

        private void linkLableTreeGroupColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StopHooker();
            treeGroupColor.ShowDialog();
            StartHooker();
        }

        private void linkLableTreeRootIcon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            treeRootIcon = new frmTreeIconSelector();
            treeRootIcon.SelectImage += new frmTreeIconSelector.SelectImageHandle(treeRootIcon_SelectImage);
            treeRootIcon.Location = linkLableTreeRootIcon.PointToScreen(new Point(0, 0));
            treeRootIcon.SelectedImage = treeRootIconIndex;
            treeRootIcon.Show();
        }

        void treeRootIcon_SelectImage(int index)
        {
            treeRootIconIndex = index;
        }

        private void linkLableTreeNameIcon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            treeNameIcon = new frmTreeIconSelector();
            treeNameIcon.SelectImage += new frmTreeIconSelector.SelectImageHandle(treeNameIcon_SelectImage);
            treeNameIcon.Location = linkLableTreeRootIcon.PointToScreen(new Point(0, 0));
            treeNameIcon.SelectedImage = treeNameIconIndex;
            treeNameIcon.Show();
        }

        void treeNameIcon_SelectImage(int index)
        {
            treeNameIconIndex = index;
        }

        private void linkLableTreeGroupIcon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            treeGroupIcon = new frmTreeIconSelector();
            treeGroupIcon.SelectImage += new frmTreeIconSelector.SelectImageHandle(treeGroupIcon_SelectImage);
            treeGroupIcon.Location = linkLableTreeRootIcon.PointToScreen(new Point(0, 0));
            treeGroupIcon.SelectedImage = treeGroupIconIndex;
            treeGroupIcon.Show();
        }

        void treeGroupIcon_SelectImage(int index)
        {
            treeGroupIconIndex = index;
        }
    }
}