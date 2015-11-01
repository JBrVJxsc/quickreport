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
        /// ��TabPage���Ƴ�ʱ�������ķ�����
        /// </summary>
        public event ReportTablePageClosedHandle ReportTablePageClosed;
        /// <summary>
        /// ��ִ��TabContorl��RemoveTabPage����ʱ��TabControl�Ὣ��һҳ�ı���ҳ����ǰ�ˣ����Ի������˸��
        /// ���ϴ˴��룬���ж�����Ƿ���ͨ���������رձ���ҳ��
        /// </summary>
        private bool removeReportTabPageByCode = false;

        /// <summary>
        /// ���һ������
        /// </summary>
        /// <param name="report">����ʵ�塣</param>
        public void AddReport(Report report)
        {
            #region �����ͨ��˫������������ӣ���ô�жϵ�ǰ����ҳ���Ƿ��Ѵ��ڸñ������ǣ��򽫸ñ���ҳ����ǰ�ˣ������ء�
            foreach (ReportTabPage tabPage in TabPages)
            {
                //�����½��ı���ID���ǿգ�������Ҫ����ID�Ƿ�Ϊ�յ��жϡ�
                //���Ϊ�գ���ô�����½����������Ǵ���౨����˫��������
                if (tabPage.Report.ID==report.ID&&report.ID!=string.Empty)
                {
                    SelectedTab = tabPage;
                    return;
                }
            }
            #endregion
            //�½�����ҳ��֮����û�аѱ���ʵ��ŵ����캯���У�����ΪTabPageû��Load�¼����޷��ѳ�ʼ��TabPage�пؼ��ĺ����Զ�ִ�У�����ֻ��������ֶ�ִ�С�
            //���д�����캯���У���ô�����TabPage�пؼ����¼��޷�ע�ᵽTabPage�ϡ�
            ReportTabPage reportTabPage = new ReportTabPage();
            TabPages.Add(reportTabPage);
            //���ñ���ҳ��ͼƬ��
            reportTabPage.ImageIndex = 0;
            //�󶨱���ҳ�ĸ����¼���
            reportTabPage.GlobalValueChanged += GlobalValueChanged;
            reportTabPage.AskForGlobalValueToolStripItem+= AskForGlobalValueToolStripItem;
            reportTabPage.ProvideToolStripMenu += ProvideToolStripMenu;
            reportTabPage.ShowStatusStripHelp += ShowStatusStripHelp;
            //�ֶ�ִ�г�ʼ����
            reportTabPage.SetReport(report);
            //�������ı���ҳ����ǰ�ˡ�
            SelectedTab = reportTabPage;
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            //���˫������ҳ����رձ���ҳ��
            CloseTabPage();
            base.OnMouseDoubleClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            //���������м���������ҳ����رձ���ҳ��
            if (e.Button == MouseButtons.Middle)
            {
                //��ѡ�и�ҳ��
                WindowManager.MouseClick();
                //Ȼ��رա�
                CloseTabPage();
            }
            base.OnMouseDown(e);
        }

        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            //�����ͨ���������رձ���ҳ����ȡ��TabControl���Զ�ѡ��
            if (removeReportTabPageByCode)
            {
                e.Cancel = true;
            }
            base.OnSelecting(e);
        }

        /// <summary>
        /// �رյ�ǰ��ʾ��ǰ�˵ı���ҳ��
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
                DialogResult dr = MessageBox.Show("�Ƿ񽫸��ı��浽 " + tabPage.Text.Substring(0, tabPage.Text.Length - 1) + "��", "����", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                if (dr == DialogResult.Yes)
                {
                    int i = tabPage.Save();
                    //���δ����ɹ����򷵻ء�
                    if (i < 0)
                    {
                        return;
                    }
                    //������ɹ�������ˢ�±�������
                    needRefreshReportTree = true;
                }
            }
            //��ֹ��˸����removeReportTabPageByCode��Ϊtrue���μ�OnSelecting������
            removeReportTabPageByCode = true;
            TabPages.Remove(tabPage);
            removeReportTabPageByCode = false;
            //֪ͨ�����б����رա���Ҫ���ڵ������Ѿ�û�б���ʱ�����������������Դﵽ��չ�������Ŀ�ġ�
            if (ReportTablePageClosed != null)
            {
                ReportTablePageClosed(this, tabPage, needRefreshReportTree);
            }
            //������ر�ҳ���м䣬�����Ҳ��ҳ����ǰ�ˡ�
            if (TabPages.Count > tabPageIndex)
            {
                SelectedIndex = tabPageIndex;
            }
            //���򣬽����һҳ����ǰ�ˡ�
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
        /// ���浱ǰ��ʾ�ı���
        /// </summary>
        /// <returns>����0Ϊ����ɹ���</returns>
        public int Save()
        {
            //�����ǰû��ѡ�еı���ҳ���򷵻ء�
            if (SelectedTab == null)
            {
                return 0;
            }
            ReportTabPage tabPage=SelectedTab as ReportTabPage;
            //������ڱ༭״̬���򱣴档����û���޸Ĺ��ģ������档
            if (tabPage.IsEditing)
            {
                return tabPage.Save();
            }
            return 0;
        }

        /// <summary>
        /// �������еı���
        /// </summary>
        /// <returns>����0Ϊ����ɹ���</returns>
        public int SaveAll()
        {
            int i = 0;
            foreach (ReportTabPage tabPage in TabPages)
            {
                //������ڱ༭״̬���򱣴档����û���޸Ĺ��ģ������档
                if (tabPage.IsEditing)
                {
                    tabPage.Save();
                    i = 1;
                }
            }
            return i;
        }

        /// <summary>
        /// Ԥ����ǰ��ʾ�ı���
        /// </summary>
        public void Preview()
        {
            //�����ǰû��ѡ�еı���ҳ���򷵻ء�
            if (SelectedTab == null)
            {
                return;
            }
            ReportTabPage tabPage = SelectedTab as ReportTabPage;
            //Ԥ��ǰ���ȱ��档��Ϊ����ʱ���Խ��и���У�飬��������Ա�֤Ԥ��ϵͳ��ʾ�Ĳ���һ��������ı���
            if (tabPage.IsEditing)
            {
                int i = tabPage.Save();
                //����ɹ�����Ԥ������
                if (i > 0)
                {
                    tabPage.Preview();
                }
            }
        }

        /// <summary>
        /// �������弴���ر�ʱ�ɸ�����ִ�еķ������Դ˷������ж��Ƿ���Խ�������رա�
        /// </summary>
        /// <param name="e">����ر�ʱ����������Ϣ��</param>
        public void Closing(FormClosingEventArgs e)
        {
            foreach (ReportTabPage tabPage in TabPages)
            {
                DialogResult dr;
                //������ڱ༭״̬������ʾ�Ƿ񱣴档
                if (tabPage.IsEditing)
                {
                    dr = MessageBox.Show("�Ƿ񽫸��ı��浽 " + tabPage.Text.Substring(0,tabPage.Text.Length-1) + "��", "����", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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

    /// <summary>
    /// ��TabControl���Ƴ�TabPageʱִ�еķ�����
    /// </summary>
    /// <param name="sender">�¼�Դ��</param>
    /// <param name="tabPage">���Ƴ���TabPage��</param>
    /// <param name="refreshReportTree">�Ƿ���Ҫˢ�±�������</param>
    internal delegate void ReportTablePageClosedHandle(object sender, ReportTabPage tabPage , bool refreshReportTree);
}
