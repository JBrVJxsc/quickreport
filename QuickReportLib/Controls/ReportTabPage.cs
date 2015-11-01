using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Enums;
using QuickReportLib.Objects;
using QuickReportLib.Controls.ReportSetting;
using QuickReportLib.Interfaces;
using QuickReportLib.Interfaces.GlobalValue;

namespace QuickReportLib.Controls
{
    /// <summary>
    /// 用来显示报表总体设置界面的TabPage控件。
    /// </summary>
    internal partial class ReportTabPage : TabPage, IGlobalValueProvider, IGlobalValueToolStripItemAsker, IToolStripMenuProvider, IShowStatusStripHelp
    {
        public ReportTabPage()
        {
            InitializeComponent();
        }

        private Report report;
        private ReportSettingPlatForm reportSettingPlatForm;
        private bool isEditing = false;
        private Hashtable globalValueBackUp = new Hashtable();

        /// <summary>
        /// 设置报表实体。
        /// </summary>
        /// <param name="report">报表实体。</param>
        public void SetReport(Report report)
        {
            this.report = report;
            Text = report.Name;
            InitReportSettingPlatForm();
        }

        /// <summary>
        /// 初始化reportSettingPlatForm。
        /// </summary>
        private void InitReportSettingPlatForm()
        {
            //这里可以将报表实体直接放到构造函数中，是因为UserControl有Load事件。
            reportSettingPlatForm = new ReportSettingPlatForm(report);
            reportSettingPlatForm.Changed += new EventHandler(reportSettingPlatForm_Changed);
            reportSettingPlatForm.GlobalValueChanged += new GlobalValueChangedHandle(reportSettingPlatForm_GloalValueChanged);
            reportSettingPlatForm.AskForGlobalValueToolStripItem += AskForGlobalValueToolStripItem;
            reportSettingPlatForm.ProvideToolStripMenu += ProvideToolStripMenu;
            reportSettingPlatForm.ShowStatusStripHelp += ShowStatusStripHelp;
            reportSettingPlatForm.AskForBringToFront += new QuickReportLib.Interfaces.ReportSetting.AskForBringToFrontHandle(reportSettingPlatForm_AskForBringToFront);
            reportSettingPlatForm.Dock = DockStyle.Fill;
            Controls.Add(reportSettingPlatForm);
        }

        void reportSettingPlatForm_AskForBringToFront(object sender, EventArgs e)
        {
            (Parent as TabControl).SelectedTab = this;
        }

        void reportSettingPlatForm_GloalValueChanged(object sender, IGlobalValue globalValue)
        {
            if (GlobalValueChanged != null)
            {
                GlobalValueChanged(sender, globalValue);
            }
            #region 将设置平台中控件提供的各种全局变量备份起来，以便报表页在激活时，重新将它所包含的全局变量上传至框架。
            if (globalValueBackUp.Contains(sender))
            {
                globalValueBackUp[sender] = globalValue;
            }
            else
            {
                globalValueBackUp.Add(sender, globalValue);
            }
            #endregion
        }

        void reportSettingPlatForm_Changed(object sender, EventArgs e)
        {
            //若平台中发来修改的事件，且当前为非编辑状态，则置状态为正在编辑。
            if (!isEditing)
            {
                IsEditing = true;
            }
        }

        /// <summary>
        /// 报表是否处于编辑状态。
        /// </summary>
        public bool IsEditing
        {
            get
            {
                return isEditing;
            }
            set
            {
                isEditing = value;
                if (isEditing)
                {
                    Text += "*";
                }
                else
                {
                    Text = report.Name;
                }
            }
        }

        /// <summary>
        /// 该TabPage包含的报表实体。
        /// </summary>
        public Report Report
        {
            get
            {
                return report;
            }
            set
            {
                report = value;
            }
        }

        /// <summary>
        /// 保存报表。
        /// </summary>
        /// <returns>1成功；-1失败。</returns>
        public int Save()
        {
            int i = reportSettingPlatForm.Save();
            if (i == -1)
            {
                return -1;
            }
            IsEditing = false;
            return 1;
        }

        /// <summary>
        /// 预览报表。
        /// </summary>
        public void Preview()
        {

        }

        protected override void OnEnter(EventArgs e)
        {            
            //报表页被激活后，将该报表页内的全局变量发送至框架。
            foreach (DictionaryEntry de in globalValueBackUp)
            {
                if (GlobalValueChanged != null)
                {
                    GlobalValueChanged(de.Key, de.Value as IGlobalValue);
                }
            }
            base.OnEnter(e);
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
}
