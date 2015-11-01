using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using QuickReportLib.Enums;
using QuickReportLib.Objects;
using QuickReportLib.Interfaces;
using QuickReportLib.Interfaces.ReportSetting;
using QuickReportLib.Managers;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;
using QuickReportLib.ReportStyles;
using QuickReportLib.Controls.Plus.IToolStripMenuProvider;
using QuickReportLib.Controls.Plus;

namespace QuickReportLib.Controls.ReportSetting
{
    internal partial class HeaderSetting : BaseUserControl, IToolStripMenuProvider, IShowStatusStripHelp, IChangedUserControl, ILoadedListener
    {
        public HeaderSetting()
        {
            InitializeComponent();
        }

        private Report report;
        private ToolStripItem[] toolStripItems;

        /// <summary>
        /// ��ʼ����������ť��
        /// </summary>
        private void InitToolStripItems()
        {
            //������б�ͷ��������İ�ť��
            List<object> objectList = ReflectionManager.CreateInstancesByInterfaceWithOutAbstract(typeof(IHeaderSettingToolStripItem));
            toolStripItems = new ToolStripItem[objectList.Count];
            #region �԰�ť��������
            SortedList sl = new SortedList();
            foreach (object obj in objectList)
            {
                IHeaderSettingToolStripItem iHeaderSettingToolStripItem = obj as IHeaderSettingToolStripItem;
                sl.Add(iHeaderSettingToolStripItem.SortID, iHeaderSettingToolStripItem);
            }
            int i = 0;
            foreach (DictionaryEntry de in sl)
            {
                IHeaderSettingToolStripItem iHeaderSettingToolStripItem = de.Value as IHeaderSettingToolStripItem;
                iHeaderSettingToolStripItem.FpSpread = fpMain;
                toolStripItems[i] = iHeaderSettingToolStripItem as ToolStripItem;
                i++;
            }
            #endregion
        }

        private void fpMain_HeaderSettingCommandStatusChanged(object sender, HeaderSettingCommandStatus commandStatus)
        {
            //��һ�ν���Fp�ı༭����ʱ����ʼ����ť��
            if (toolStripItems == null)
            {
                InitToolStripItems();
            }
            //��Fp��ǰ�ı༭�������ø���ť���ð�ť����Fp��������磬��ѡ�е��Ǳ�����ʱ������Border�İ�ť�����ң���������������á�
            for (int i = 0; i < toolStripItems.Length; i++)
            {
                IHeaderSettingToolStripItem iHeaderSettingToolStripItem = toolStripItems[i] as IHeaderSettingToolStripItem;
                iHeaderSettingToolStripItem.SetCommandStatus(commandStatus);
            }
            //���Ѿ�����Fp�༭����İ�ť���͵���ܡ�
            if (ProvideToolStripMenu != null)
            {
                ProvideToolStripMenu(this, toolStripItems);
            }
        }

        private void fpMain_HeaderSettingFpSpreadChanged(object sender, HeaderSettingFpSpreadChangedType changedType)
        {
            if (toolStripItems != null)
            {
                //��Fp���������ı�ʱ���ð�ťΪ�ҡ�
                if (changedType == HeaderSettingFpSpreadChangedType.TopRowCountChanged || changedType == HeaderSettingFpSpreadChangedType.BottomRowCountChanged || changedType == HeaderSettingFpSpreadChangedType.ColumnCountChanged)
                {
                    for (int i = 0; i < toolStripItems.Length; i++)
                    {
                        if (toolStripItems[i] is ToolStripButtonPlus)
                        {
                            (toolStripItems[i] as ToolStripButtonPlus).Checked = false;
                            (toolStripItems[i] as ToolStripButtonPlus).Enabled = false;
                        }
                        else if (toolStripItems[i] is ToolStripSplitButtonPlus)
                        {
                            (toolStripItems[i] as ToolStripSplitButtonPlus).Enabled = false;
                        }
                    }
                }
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            if (ShowStatusStripHelp != null)
            {
                ShowStatusStripHelp(this, "���ñ���ı�ͷ");
            }
            base.OnEnter(e);
        }

        /// <summary>
        /// ��ʼ����ͷ���ÿؼ���
        /// </summary>
        /// <param name="report">����ʵ�塣</param>
        public void Init(Report report)
        {
            this.report = report;
            //��ʼ��Fp��
            fpMain.Init(report);
        }

        /// <summary>
        /// ���档
        /// </summary>
        /// <returns>1�ɹ���-1ʧ�ܡ�</returns>
        public int Save()
        {
            fpMain.StopCellEditing();
            fpMain.Save();
            return 1;
        }

        #region IToolStripMenuProvider ��Ա

        public event ProvideToolStripMenuHandle ProvideToolStripMenu;

        #endregion

        #region IShowStatusStripHelp ��Ա

        public event ShowStatusStripHelpHandle ShowStatusStripHelp;

        #endregion

        #region IChangedUserControl ��Ա

        public event EventHandler Changed;

        #endregion

        #region ILoadedListener ��Ա

        public void Loaded()
        {
            fpMain.HorizontalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
            fpMain.VerticalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
        }

        #endregion
    }
}
