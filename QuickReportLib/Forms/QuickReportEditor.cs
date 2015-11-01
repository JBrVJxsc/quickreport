using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects;
using QuickReportLib.Class.Window;
using QuickReportLib.Interfaces;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Managers;
using QuickReportLib.ReportStyles;
using QuickReportLib.Forms.Wizard;
using QuickReportLib.Enums;
using QuickReportLib.Controls;

namespace QuickReportLib.Forms
{
    /// <summary>
    /// QuickReport����������塣
    /// </summary>
    internal partial class QuickReportEditor : BaseForm
    {
        public QuickReportEditor()
        {
            InitializeComponent();
        }

        private GlobalValueToolStripItemProvider globalValueToolStripItemProvider = new GlobalValueToolStripItemProvider();
        private ToolStripItem[] currentToolStripItemsOfUserControl;
        private HookManager hookManager;
        private DataBaseManager dataBaseManager = new DataBaseManager();

        /// <summary>
        /// ��ʼ����
        /// </summary>
        private void Init()
        {
            InitGlobalValueToolStripItems();
            InitInterfacesImplementedControls();
            InitReportSearcherComboBox();
            //InitHookEvent();
        }

        /// <summary>
        /// ��ʼ�����ӡ�
        /// </summary>
        private void InitHookEvent()
        {
            hookManager = new HookManager(true, true);
            hookManager.HookOnKeyDownEvent += HookOnKeyDownEvent;
            hookManager.HookOnKeyUpEvent += HookOnKeyUpEvent;
            hookManager.HookOnKeyPressEvent += HookOnKeyPressEvent;
            hookManager.HookOnMouseActivityEvent += HookOnMouseActivityEvent;
        }

        /// <summary>
        /// ж�ع��ӡ�
        /// </summary>
        private void CancelHookEvent()
        {
            hookManager.HookOnKeyDownEvent -= HookOnKeyDownEvent;
            hookManager.HookOnKeyUpEvent -= HookOnKeyUpEvent;
            hookManager.HookOnKeyPressEvent -= HookOnKeyPressEvent;
            hookManager.HookOnMouseActivityEvent -= HookOnMouseActivityEvent;
        }

        #region ����������

        private void New()
        {
            #region �½��������б�������ɶ��ᾭ��������衣
            //һ��Report���������ڣ���������һ�й��캯����ʼ��
            Report report=new Report();
            //���µ�Guid��ֵ��report��ʹ֮��ΪreportΨһ�ı�ʾ��
            report.ID = GuidManager.GetNewGuid();
            //���½��ı���ʵ�崫�������򵼡�
            CreateReportWizard createReportWizard = new CreateReportWizard(report);
            //�󶨱����򵼵ı��������¼���
            createReportWizard.WizardDone += new WizardDoneHandle(createReportWizard_WizardDone);
            createReportWizard.ShowDialog();
            //ֻҪ�½��ɹ�һ�������򽫽������õ����ϡ�
            //��Ϊ���������õ����Ϻ󣬱���Խ����Ĺ�������ť�ϴ���������������������������Ч����
            if (createReportWizard.DialogResult != DialogResult.Cancel)
            {
                userControlOfReportTree.Focus();
            }
            #endregion
        }

        private void Delete()
        {
            userControlOfReportTree.Delete();
        }

        private void Save()
        {
            int i= reportTabControl.Save();
            //ֻ�б���ɹ�����ˢ�����б�
            if (i > 0)
            {
                userControlOfReportTree.RefreshReport();
            }
        }

        private void SaveAll()
        {
            int i = reportTabControl.SaveAll();
            //ֻ�б���ɹ�����ˢ�����б�
            if (i > 0)
            {
                userControlOfReportTree.RefreshReport();
            }
        }

        private void Import()
        { 
            
        }

        private void Export()
        {
            userControlOfReportTree.Export();
        }

        private void Preview()
        {
            reportTabControl.Preview();
        }

        private void Search()
        {
            tsMainSearch.ShowFilter();
        }

        private void Help()
        { 
            
        }

        private void About()
        {

        }

        #endregion

        /// <summary>
        /// ��ʼ�������ѯ�ؼ���
        /// </summary>
        private void InitReportSearcherComboBox()
        {
            List<Report> reportList = userControlOfReportTree.ReportList;
            foreach (Report report in reportList)
            {
                tsMainSearch.Items.Add(report);
            }
        }

        /// <summary>
        /// ��ʵ�ָ��ֽӿڵĿؼ����¼��󶨵����塣
        /// </summary>
        private void InitInterfacesImplementedControls()
        {
            foreach (Control control in scMain.Panel1.Controls)
            {
                BindingControlEvent(control);
            }

            foreach (Control control in scMain.Panel2.Controls)
            {
                BindingControlEvent(control);
            }
        }

        /// <summary>
        /// ���¼���
        /// </summary>
        /// <param name="control">��Ҫ���¼��Ŀؼ���</param>
        private void BindingControlEvent(Control control)
        {
            if (control is IGlobalValueProvider)
            {
                (control as IGlobalValueProvider).GlobalValueChanged += new GlobalValueChangedHandle(QuickReportEditor_GloalValueChanged);
            }

            if (control is IGlobalValueToolStripItemAsker)
            {
                (control as IGlobalValueToolStripItemAsker).AskForGlobalValueToolStripItem += new AskForGlobalValueToolStripItemHandle(QuickReportEditor_AskForGlobalValueToolStripItem);
            }

            if (control is IToolStripMenuProvider)
            {
                (control as IToolStripMenuProvider).ProvideToolStripMenu += new ProvideToolStripMenuHandle(QuickReportEditor_ProvideToolStripMenu);
            }

            if (control is IShowStatusStripHelp)
            {
                (control as IShowStatusStripHelp).ShowStatusStripHelp += new ShowStatusStripHelpHandle(QuickReportEditor_ShowStatusStripHelp);
            }
        }

        /// <summary>
        /// ��ʼ��ȫ�ֱ����������еİ�ť��
        /// </summary>
        private void InitGlobalValueToolStripItems()
        {
            List<IGlobalValueToolStripItem> iGlobalValueToolStripItemList = globalValueToolStripItemProvider.GlobalValueToolStripItems;
            tsMain.Items.Add(globalValueToolStripItemProvider.ToolStripSeparator);
            for (int i = 0; i < iGlobalValueToolStripItemList.Count; i++)
            {
                tsMain.Items.Add(iGlobalValueToolStripItemList[i] as ToolStripItem);
            }
        }

        /// <summary>
        /// ���²�ѯ����ؼ��е����ݡ�
        /// </summary>
        /// <param name="baseObjects">��Ҫ���½�ȥ�����ݡ�</param>
        private void UpdateReportSearcherComboBox(List<BaseObject> baseObjects)
        {
            tsMainSearch.Items.Clear();
            tsMainSearch.ClearFilter();
            foreach (BaseObject baseObject in baseObjects)
            {
                tsMainSearch.Items.Add(baseObject);
            }
        }

        #region �¼�

        #region �������¼�

        void createReportWizard_WizardDone(object sender, Report report)
        {
            //�����򵼳ɹ��½�һ����������ӵ�TabControl�С�
            reportTabControl.AddReport(report);
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            Init();
            base.OnLoad(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //�رմ���ʱ���Ƚ�FormClosingEventArgs����reportTabControl�������ж��Ƿ���Թرմ��ڡ�
            reportTabControl.Closing(e);
            base.OnFormClosing(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            #region �رմ���ʱ��ע�����ӡ�
            if (hookManager != null)
            {
                CancelHookEvent();
                hookManager.Stop();
                hookManager = null;
            }
            #endregion
            base.OnFormClosed(e);
        }

        private void userControlOfReportTree_ReportSelected(object sender, Report report)
        {
            //˫������������TabControl����ӱ���
            report = dataBaseManager.QueryReportByID(report.ID);
            if (report != null)
            {
                reportTabControl.AddReport(report);
            }
        }

        private void userControlOfReportTree_ReportDeleted(object sender, Report report)
        {
            //�������ɾ���ˣ���ر���Ӧ��TabPage��
            reportTabControl.CloseTabPage(report.ID);
        }

        private void reportTabControl_ReportTablePageClosed(object sender, ReportTabPage tabPage, bool refreshReportTree)
        {
            //��û�б��������ʾʱ���򽫽�����������
            if (reportTabControl.TabPages.Count == 0)
            {
                userControlOfReportTree.Focus();
            }
            if (refreshReportTree)
            {
                userControlOfReportTree.RefreshReport();
            }
        }

        private void reportTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //��TabControl�л�ҳʱ����������������
            if (!userControlOfReportTree.Focused)
            {
                userControlOfReportTree.Focus();
            }
        }

        #region �ӿ��¼�

        void QuickReportEditor_AskForGlobalValueToolStripItem(IGlobalValueToolStripItemAsker iGlobalValueToolStripItemAsker, List<GlobalValueType> globalValueTypes)
        {
            //��ȫ�ֱ�����ť����Ϊ����������Ҫ�����͡�
            globalValueToolStripItemProvider.SetGlobalValueVisible(iGlobalValueToolStripItemAsker,globalValueTypes);
        }

        void QuickReportEditor_GloalValueChanged(object sender, IGlobalValue globalValue)
        {
            //����ȫ�ֱ�����ť�е����ݡ�
            globalValueToolStripItemProvider.UpateGlobalValue(globalValue);
            //������µ��Ǳ�������࣬����²�ѯ����Ŀؼ���
            if (globalValue.GlobalValueType == GlobalValueType.Report)
            {
                UpdateReportSearcherComboBox(globalValue.Value);
            }
        }

        void QuickReportEditor_ProvideToolStripMenu(object sender, ToolStripItem[] toolStripItems)
        {
            //�����ͬһ�鹤������ť�����ظ����¡�
            if (currentToolStripItemsOfUserControl == toolStripItems)
            {
                return;
            }
            //ֹͣ���֡���ֹ�Թ���������ӡ�ɾ����ťʱ�����˸��
            SuspendLayout();
            //����ť�������������
            tsForUserControl.Items.Clear();
            for (int i = 0; i < toolStripItems.Length; i++)
            {
                tsForUserControl.Items.Add(toolStripItems[i]);
            }
            //���ݹ�������ť��
            currentToolStripItemsOfUserControl = toolStripItems;
            //�ָ����֡�
            ResumeLayout();
        }

        void QuickReportEditor_ShowStatusStripHelp(object sender, string helpContent)
        {
            ssMainHelp.Text = helpContent;
        }

        #endregion

        #region �����¼�

        void HookOnMouseActivityEvent(object sender, MouseEventArgs e)
        {

        }

        void HookOnKeyPressEvent(object sender, KeyPressEventArgs e)
        {

        }

        void HookOnKeyUpEvent(object sender, KeyEventArgs e)
        {

        }

        void HookOnKeyDownEvent(object sender, KeyEventArgs e)
        {

        }

        #endregion

        #region �������¼�

        private void msMainFileNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void msMainFileDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void msMainFileSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void msMainFileSaveAll_Click(object sender, EventArgs e)
        {
            SaveAll();
        }

        private void msMainFileImport_Click(object sender, EventArgs e)
        {
            Import();
        }

        private void msMainFileExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void msMainFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void msMainToolsSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void msMainToolsPreview_Click(object sender, EventArgs e)
        {
            Preview();
        }

        private void msMainHelpDocument_Click(object sender, EventArgs e)
        {
            Help();
        }

        private void msMainHelpAbout_Click(object sender, EventArgs e)
        {
            About();
        }

        private void tsMainNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void tsMainDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void tsMainSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void tsMainSaveAll_Click(object sender, EventArgs e)
        {
            SaveAll();
        }

        private void tsMainImport_Click(object sender, EventArgs e)
        {
            Import();
        }

        private void tsMainExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void tsMainPreview_Click(object sender, EventArgs e)
        {
            Preview();
        }

        #endregion

        #endregion
    }
}