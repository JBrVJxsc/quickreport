using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Interfaces;
using QuickReportLib.Enums;
using QuickReportLib.Managers;

namespace QuickReportLib.Controls
{
    internal partial class ReportTabControl : TabControl , IGlobalValueProvider , IGlobalValueToolStripItemAsker , IToolStripMenuProvider , IShowStatusStripHelp
    {
        public ReportTabControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当TabPage被移除时所触发的方法。
        /// </summary>
        public event ReportTablePageClosedHandle ReportTablePageClosed;
        /// <summary>
        /// 当执行TabContorl的RemoveTabPage方法时，TabControl会将第一页的报表页置于前端，所以会造成闪烁。
        /// 加上此代码，来判断如果是否是通过代码来关闭报表页。
        /// </summary>
        private bool removeReportTabPageByCode = false;

        /// <summary>
        /// 添加一个报表。
        /// </summary>
        /// <param name="report">报表实体。</param>
        public void AddReport(Report report)
        {
            #region 如果是通过双击报表树来添加，那么判断当前报表页中是否已存在该报表，若是，则将该报表页置于前端，并返回。
            foreach (ReportTabPage tabPage in TabPages)
            {
                //对于新建的报表，ID都是空，所以需要加上ID是否为空的判断。
                //如果为空，那么就是新建报表，而不是从左侧报表树双击而来。
                if (tabPage.Report.ID==report.ID&&report.ID!=string.Empty)
                {
                    SelectedTab = tabPage;
                    return;
                }
            }
            #endregion
            //新建报表页。之所以没有把报表实体放到构造函数中，是因为TabPage没有Load事件，无法把初始化TabPage中控件的函数自动执行，所以只能在最后手动执行。
            //如果写到构造函数中，那么会造成TabPage中控件的事件无法注册到TabPage上。
            ReportTabPage reportTabPage = new ReportTabPage();
            TabPages.Add(reportTabPage);
            //设置报表页的图片。
            reportTabPage.ImageIndex = 0;
            //绑定报表页的各种事件。
            reportTabPage.GlobalValueChanged += GlobalValueChanged;
            reportTabPage.AskForGlobalValueToolStripItem+= AskForGlobalValueToolStripItem;
            reportTabPage.ProvideToolStripMenu += ProvideToolStripMenu;
            reportTabPage.ShowStatusStripHelp += ShowStatusStripHelp;
            //手动执行初始化。
            reportTabPage.SetReport(report);
            //将新增的报表页置于前端。
            SelectedTab = reportTabPage;
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            //如果双击报表页，则关闭报表页。
            CloseTabPage();
            base.OnMouseDoubleClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            //如果用鼠标中键单击报表页，则关闭报表页。
            if (e.Button == MouseButtons.Middle)
            {
                //先选中该页。
                WindowManager.MouseClick();
                //然后关闭。
                CloseTabPage();
            }
            base.OnMouseDown(e);
        }

        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            //如果是通过代码来关闭报表页，则取消TabControl的自动选择。
            if (removeReportTabPageByCode)
            {
                e.Cancel = true;
            }
            base.OnSelecting(e);
        }

        /// <summary>
        /// 关闭当前显示在前端的报表页。
        /// </summary>
        private void CloseTabPage()
        {
            ReportTabPage tabPage = SelectedTab as ReportTabPage;
            CloseTabPage(tabPage);
        }

        private void CloseTabPage(ReportTabPage tabPage)
        {
            int tabPageIndex = 0;
            bool needRefreshReportTree = false;
            for (int i = 0; i < TabPages.Count;i++ )
            {
                if (TabPages[i] == tabPage)
                {
                    tabPageIndex = i;
                    break;
                }
            }
            if (tabPage.IsEditing)
            {
                DialogResult dr = MessageBox.Show("是否将更改保存到 " + tabPage.Text.Substring(0, tabPage.Text.Length - 1) + "？", "保存", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                if (dr == DialogResult.Yes)
                {
                    int i = tabPage.Save();
                    //如果未保存成功，则返回。
                    if (i < 0)
                    {
                        return;
                    }
                    //若保存成功，则需刷新报表树。
                    needRefreshReportTree = true;
                }
            }
            //防止闪烁，将removeReportTabPageByCode置为true。参见OnSelecting方法。
            removeReportTabPageByCode = true;
            TabPages.Remove(tabPage);
            removeReportTabPageByCode = false;
            //通知窗体有报表被关闭。主要用于当界面已经没有报表时，将焦点置于树，以达到清空工具栏的目的。
            if (ReportTablePageClosed != null)
            {
                ReportTablePageClosed(this, tabPage, needRefreshReportTree);
            }
            //如果被关闭页在中间，则将它右侧的页置于前端。
            if (TabPages.Count > tabPageIndex)
            {
                SelectedIndex = tabPageIndex;
            }
            //否则，将最后一页置于前端。
            else
            {
                SelectedIndex = TabPages.Count - 1;
            }
        }

        public void CloseTabPage(string reportID)
        {
            for (int i = 0; i < TabPages.Count; i++)
            {
                if ((TabPages[i] as ReportTabPage).Report.ID == reportID)
                {
                    CloseTabPage(TabPages[i] as ReportTabPage);
                    break;
                }
            }
        }

        /// <summary>
        /// 保存当前显示的报表。
        /// </summary>
        /// <returns>大于0为保存成功。</returns>
        public int Save()
        {
            //如果当前没有选中的报表页，则返回。
            if (SelectedTab == null)
            {
                return 0;
            }
            ReportTabPage tabPage=SelectedTab as ReportTabPage;
            //如果处于编辑状态，则保存。对于没有修改过的，不保存。
            if (tabPage.IsEditing)
            {
                return tabPage.Save();
            }
            return 0;
        }

        /// <summary>
        /// 保存所有的报表。
        /// </summary>
        /// <returns>大于0为保存成功。</returns>
        public int SaveAll()
        {
            int i = 0;
            foreach (ReportTabPage tabPage in TabPages)
            {
                //如果处于编辑状态，则保存。对于没有修改过的，不保存。
                if (tabPage.IsEditing)
                {
                    tabPage.Save();
                    i = 1;
                }
            }
            return i;
        }

        /// <summary>
        /// 预览当前显示的报表。
        /// </summary>
        public void Preview()
        {
            //如果当前没有选中的报表页，则返回。
            if (SelectedTab == null)
            {
                return;
            }
            ReportTabPage tabPage = SelectedTab as ReportTabPage;
            //预览前，先保存。因为保存时可以进行各种校验，这样便可以保证预览系统显示的不是一个有问题的报表。
            if (tabPage.IsEditing)
            {
                int i = tabPage.Save();
                //保存成功，则预览报表。
                if (i > 0)
                {
                    tabPage.Preview();
                }
            }
        }

        /// <summary>
        /// 当父窗体即将关闭时由父窗体执行的方法，以此方法来判断是否可以将父窗体关闭。
        /// </summary>
        /// <param name="e">窗体关闭时所包含的信息。</param>
        public void Closing(FormClosingEventArgs e)
        {
            foreach (ReportTabPage tabPage in TabPages)
            {
                DialogResult dr;
                //如果正在编辑状态，则提示是否保存。
                if (tabPage.IsEditing)
                {
                    dr = MessageBox.Show("是否将更改保存到 " + tabPage.Text.Substring(0,tabPage.Text.Length-1) + "？", "保存", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }
                    if (dr == DialogResult.Yes)
                    {
                        tabPage.Save();
                    }
                }
            }
        }

        #region IGlobalValueProvider 成员

        public event GlobalValueChangedHandle GlobalValueChanged;

        #endregion

        #region IGlobalValueToolStripItemAsker 成员

        public event AskForGlobalValueToolStripItemHandle AskForGlobalValueToolStripItem;

        public void SetGlobalValue(string globalValue)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IToolStripMenuProvider 成员

        public event ProvideToolStripMenuHandle ProvideToolStripMenu;

        #endregion

        #region IShowStatusStripHelp 成员

        public event ShowStatusStripHelpHandle ShowStatusStripHelp;

        #endregion
    }

    /// <summary>
    /// 从TabControl中移除TabPage时执行的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="tabPage">被移除的TabPage。</param>
    /// <param name="refreshReportTree">是否需要刷新报表树。</param>
    internal delegate void ReportTablePageClosedHandle(object sender, ReportTabPage tabPage , bool refreshReportTree);
}
