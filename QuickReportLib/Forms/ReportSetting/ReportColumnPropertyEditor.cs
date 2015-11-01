using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Controls;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;
using QuickReportLib.Managers;
using QuickReportLib.Objects;

namespace QuickReportLib.Forms.ReportSetting
{
    public partial class ReportColumnPropertyEditor : FormWithArrow
    {
        public ReportColumnPropertyEditor()
        {
            InitializeComponent();
        }

        private IReportColumnSettingToolStripItem[] iReportColumnSettingToolStripItems;
        private HookManager hookManager;
        private bool toolStripSplitButtonDropDownOpened = false;

        private void InitToolStripItems()
        {
            List<object> objectList = ReflectionManager.CreateInstancesByInterfaceWithOutAbstract(typeof(IReportColumnSettingToolStripItem));
            iReportColumnSettingToolStripItems = new IReportColumnSettingToolStripItem[objectList.Count];
            SortedList sl = new SortedList();
            foreach (object obj in objectList)
            {
                IReportColumnSettingToolStripItem iReportColumnSettingToolStripItem = obj as IReportColumnSettingToolStripItem;
                sl.Add(iReportColumnSettingToolStripItem.SortID, iReportColumnSettingToolStripItem);
            }
            int i = 0;
            foreach (DictionaryEntry de in sl)
            {
                IReportColumnSettingToolStripItem iReportColumnSettingToolStripItem = de.Value as IReportColumnSettingToolStripItem;
                iReportColumnSettingToolStripItem.HeaderSettingFpSpreadChanged += HeaderSettingFpSpreadChanged;
                if (iReportColumnSettingToolStripItem is ToolStripSplitButton)
                {
                    ToolStripSplitButton toolStripSplitButton = iReportColumnSettingToolStripItem as ToolStripSplitButton;
                    toolStripSplitButton.DropDownOpened += new EventHandler(toolStripSplitButton_DropDownOpened);
                    toolStripSplitButton.DropDownClosed += new EventHandler(toolStripSplitButton_DropDownClosed);
                }
                iReportColumnSettingToolStripItems[i] = iReportColumnSettingToolStripItem;
                tsMain.Items.Add(iReportColumnSettingToolStripItems[i] as ToolStripItem);
                i++;
            }
            CalculateSize();
        }

        void toolStripSplitButton_DropDownClosed(object sender, EventArgs e)
        {
            toolStripSplitButtonDropDownOpened = false;
        }

        void toolStripSplitButton_DropDownOpened(object sender, EventArgs e)
        {
            toolStripSplitButtonDropDownOpened = true;
        }

        private void CalculateSize()
        {
            int width = 0;
            int i = 0;
            foreach (ToolStripItem item in tsMain.Items)
            {
                if ((item as IReportColumnSettingToolStripItem).IsVisible)
                {
                    i++;
                    //�����ToolStripSplitButton����ô��Ϊ48��
                    if (item is ToolStripSplitButton)
                    {
                        width += 48;
                    }
                    else
                    {
                        width += item.Width;
                    }
                }
            }
            Width = width+1;
            Height = PanelHeight + tsMain.Height + (Height - ClientSize.Height);
        }

        /// <summary>
        /// ��ʼ����
        /// </summary>
        public void Init()
        {
            InitToolStripItems();
        }

        /// <summary>
        /// ��ʼ�����ӡ�
        /// </summary>
        private void InitHookEvent()
        {
            hookManager = new HookManager(true, false);
            hookManager.HookOnMouseActivityEvent += HookOnMouseActivityEvent;
        }

        /// <summary>
        /// ж�ع��ӡ�
        /// </summary>
        private void CancelHookEvent()
        {
            hookManager.HookOnMouseActivityEvent -= HookOnMouseActivityEvent;
        }

        /// <summary>
        /// ��ʾ���������Դ��ڡ�
        /// </summary>
        /// <param name="column">������ʵ�塣</param>
        /// <param name="rectangle">����������ʾ������</param>
        /// <param name="point">��ͷ��ָ���λ�á�</param>
        public void ShowColumnProperty(Column column, Rectangle rectangle, Point point)
        {
            SuspendLayout();
            for (int i = 0; i < iReportColumnSettingToolStripItems.Length; i++)
            {
                iReportColumnSettingToolStripItems[i].Column = column;
            }
            CalculateSize();
            Show(rectangle, point);
            ResumeLayout();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (Visible)
            {
                if (hookManager == null)
                {
                    InitHookEvent();
                }
                else
                {
                    hookManager.Start(true, false);
                }
            }
            else
            {
                hookManager.Stop();
            }
            base.OnVisibleChanged(e);
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

        #region �����¼�

        void HookOnMouseActivityEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            { 
                //����������������ҵ������ToolStrip�ڲ����򽫸����Կ����ڶ��㡣
                Rectangle rectangle=new Rectangle(0,0,tsMain.Width,tsMain.Height);
                if (tsMain.RectangleToScreen(rectangle).Contains(e.Location))
                {
                    BringToFront();
                    return;
                }
            }
            //�������崦�ڷǼ���״̬��ToolStripSplitButton���ڹر�״̬ʱ���Ž����������ڶ��㡣
            if (!Owner.Focused && !toolStripSplitButtonDropDownOpened)
            {
                Owner.BringToFront();
            }
        }

        #endregion

        /// <summary>
        /// FpSpread�����ı�ʱ�������¼���
        /// </summary>
        internal event HeaderSettingFpSpreadChangedHandle HeaderSettingFpSpreadChanged;
    }
}