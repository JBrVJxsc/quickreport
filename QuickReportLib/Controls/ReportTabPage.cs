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
    /// ������ʾ�����������ý����TabPage�ؼ���
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
        /// ���ñ���ʵ�塣
        /// </summary>
        /// <param name="report">����ʵ�塣</param>
        public void SetReport(Report report)
        {
            this.report = report;
            Text = report.Name;
            InitReportSettingPlatForm();
        }

        /// <summary>
        /// ��ʼ��reportSettingPlatForm��
        /// </summary>
        private void InitReportSettingPlatForm()
        {
            //������Խ�����ʵ��ֱ�ӷŵ����캯���У�����ΪUserControl��Load�¼���
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
            #region ������ƽ̨�пؼ��ṩ�ĸ���ȫ�ֱ��������������Ա㱨��ҳ�ڼ���ʱ�����½�����������ȫ�ֱ����ϴ�����ܡ�
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
            //��ƽ̨�з����޸ĵ��¼����ҵ�ǰΪ�Ǳ༭״̬������״̬Ϊ���ڱ༭��
            if (!isEditing)
            {
                IsEditing = true;
            }
        }

        /// <summary>
        /// �����Ƿ��ڱ༭״̬��
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
        /// ��TabPage�����ı���ʵ�塣
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
        /// ���汨��
        /// </summary>
        /// <returns>1�ɹ���-1ʧ�ܡ�</returns>
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
        /// Ԥ������
        /// </summary>
        public void Preview()
        {

        }

        protected override void OnEnter(EventArgs e)
        {            
            //����ҳ������󣬽��ñ���ҳ�ڵ�ȫ�ֱ�����������ܡ�
            foreach (DictionaryEntry de in globalValueBackUp)
            {
                if (GlobalValueChanged != null)
                {
                    GlobalValueChanged(de.Key, de.Value as IGlobalValue);
                }
            }
            base.OnEnter(e);
        }

        #region IGlobalValueProvider ��Ա

        public event GlobalValueChangedHandle GlobalValueChanged;

        #endregion

        #region IGlobalValueToolStripItemAsker ��Ա

        public event AskForGlobalValueToolStripItemHandle AskForGlobalValueToolStripItem;

        public void SetGlobalValue(string globalValue)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IToolStripMenuProvider ��Ա

        public event ProvideToolStripMenuHandle ProvideToolStripMenu;

        #endregion

        #region IShowStatusStripHelp ��Ա

        public event ShowStatusStripHelpHandle ShowStatusStripHelp;

        #endregion
    }
}
