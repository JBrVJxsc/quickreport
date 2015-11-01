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
    /// QuickReport设计器主窗体。
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
        /// 初始化。
        /// </summary>
        private void Init()
        {
            InitGlobalValueToolStripItems();
            InitInterfacesImplementedControls();
            InitReportSearcherComboBox();
            //InitHookEvent();
        }

        /// <summary>
        /// 初始化钩子。
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
        /// 卸载钩子。
        /// </summary>
        private void CancelHookEvent()
        {
            hookManager.HookOnKeyDownEvent -= HookOnKeyDownEvent;
            hookManager.HookOnKeyUpEvent -= HookOnKeyUpEvent;
            hookManager.HookOnKeyPressEvent -= HookOnKeyPressEvent;
            hookManager.HookOnMouseActivityEvent -= HookOnMouseActivityEvent;
        }

        #region 工具栏方法

        private void New()
        {
            #region 新建报表。所有报表的生成都会经过这个步骤。
            //一个Report的生命周期，从下面这一行构造函数开始。
            Report report=new Report();
            //将新的Guid赋值给report，使之成为report唯一的标示。
            report.ID = GuidManager.GetNewGuid();
            //将新建的报表实体传给报表向导。
            CreateReportWizard createReportWizard = new CreateReportWizard(report);
            //绑定报表向导的报表生成事件。
            createReportWizard.WizardDone += new WizardDoneHandle(createReportWizard_WizardDone);
            createReportWizard.ShowDialog();
            //只要新建成功一个报表，则将焦点设置到树上。
            //因为将焦点设置到树上后，便可以将树的工具栏按钮上传至工具栏，起到重新整理工具栏的效果。
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
            //只有保存成功，才刷新树列表。
            if (i > 0)
            {
                userControlOfReportTree.RefreshReport();
            }
        }

        private void SaveAll()
        {
            int i = reportTabControl.SaveAll();
            //只有保存成功，才刷新树列表。
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
        /// 初始化报表查询控件。
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
        /// 将实现各种接口的控件的事件绑定到窗体。
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
        /// 绑定事件。
        /// </summary>
        /// <param name="control">需要绑定事件的控件。</param>
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
        /// 初始化全局变量工具栏中的按钮。
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
        /// 更新查询报表控件中的内容。
        /// </summary>
        /// <param name="baseObjects">需要更新进去的内容。</param>
        private void UpdateReportSearcherComboBox(List<BaseObject> baseObjects)
        {
            tsMainSearch.Items.Clear();
            tsMainSearch.ClearFilter();
            foreach (BaseObject baseObject in baseObjects)
            {
                tsMainSearch.Items.Add(baseObject);
            }
        }

        #region 事件

        #region 报表向导事件

        void createReportWizard_WizardDone(object sender, Report report)
        {
            //报表向导成功新建一个报表，则添加到TabControl中。
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
            //关闭窗口时，先将FormClosingEventArgs传给reportTabControl，让其判定是否可以关闭窗口。
            reportTabControl.Closing(e);
            base.OnFormClosing(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            #region 关闭窗口时，注销钩子。
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
            //双击报表树后，向TabControl中添加报表。
            report = dataBaseManager.QueryReportByID(report.ID);
            if (report != null)
            {
                reportTabControl.AddReport(report);
            }
        }

        private void userControlOfReportTree_ReportDeleted(object sender, Report report)
        {
            //如果报表被删除了，则关闭相应的TabPage。
            reportTabControl.CloseTabPage(report.ID);
        }

        private void reportTabControl_ReportTablePageClosed(object sender, ReportTabPage tabPage, bool refreshReportTree)
        {
            //当没有报表可以显示时，则将焦点置于树。
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
            //当TabControl切换页时，将焦点置于树。
            if (!userControlOfReportTree.Focused)
            {
                userControlOfReportTree.Focus();
            }
        }

        #region 接口事件

        void QuickReportEditor_AskForGlobalValueToolStripItem(IGlobalValueToolStripItemAsker iGlobalValueToolStripItemAsker, List<GlobalValueType> globalValueTypes)
        {
            //将全局变量按钮设置为需求者所需要的类型。
            globalValueToolStripItemProvider.SetGlobalValueVisible(iGlobalValueToolStripItemAsker,globalValueTypes);
        }

        void QuickReportEditor_GloalValueChanged(object sender, IGlobalValue globalValue)
        {
            //更新全局变量按钮中的内容。
            globalValueToolStripItemProvider.UpateGlobalValue(globalValue);
            //如果更新的是报表的种类，则更新查询报表的控件。
            if (globalValue.GlobalValueType == GlobalValueType.Report)
            {
                UpdateReportSearcherComboBox(globalValue.Value);
            }
        }

        void QuickReportEditor_ProvideToolStripMenu(object sender, ToolStripItem[] toolStripItems)
        {
            //如果是同一组工具栏按钮，则不重复更新。
            if (currentToolStripItemsOfUserControl == toolStripItems)
            {
                return;
            }
            //停止布局。防止对工具栏中添加、删除按钮时造成闪烁。
            SuspendLayout();
            //将按钮添加至工具栏。
            tsForUserControl.Items.Clear();
            for (int i = 0; i < toolStripItems.Length; i++)
            {
                tsForUserControl.Items.Add(toolStripItems[i]);
            }
            //备份工具栏按钮。
            currentToolStripItemsOfUserControl = toolStripItems;
            //恢复布局。
            ResumeLayout();
        }

        void QuickReportEditor_ShowStatusStripHelp(object sender, string helpContent)
        {
            ssMainHelp.Text = helpContent;
        }

        #endregion

        #region 钩子事件

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

        #region 工具栏事件

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