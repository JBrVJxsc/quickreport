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
                    //如果是ToolStripSplitButton，那么宽为48。
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
        /// 初始化。
        /// </summary>
        public void Init()
        {
            InitToolStripItems();
        }

        /// <summary>
        /// 初始化钩子。
        /// </summary>
        private void InitHookEvent()
        {
            hookManager = new HookManager(true, false);
            hookManager.HookOnMouseActivityEvent += HookOnMouseActivityEvent;
        }

        /// <summary>
        /// 卸载钩子。
        /// </summary>
        private void CancelHookEvent()
        {
            hookManager.HookOnMouseActivityEvent -= HookOnMouseActivityEvent;
        }

        /// <summary>
        /// 显示报表列属性窗口。
        /// </summary>
        /// <param name="column">报表列实体。</param>
        /// <param name="rectangle">窗体所能显示的区域。</param>
        /// <param name="point">箭头所指向的位置。</param>
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

        #region 钩子事件

        void HookOnMouseActivityEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            { 
                //如果点击的是左键，且点击的是ToolStrip内部，则将该属性框置于顶层。
                Rectangle rectangle=new Rectangle(0,0,tsMain.Width,tsMain.Height);
                if (tsMain.RectangleToScreen(rectangle).Contains(e.Location))
                {
                    BringToFront();
                    return;
                }
            }
            //当父窗体处于非激活状态且ToolStripSplitButton处于关闭状态时，才将父窗体置于顶层。
            if (!Owner.Focused && !toolStripSplitButtonDropDownOpened)
            {
                Owner.BringToFront();
            }
        }

        #endregion

        /// <summary>
        /// FpSpread发生改变时触发的事件。
        /// </summary>
        internal event HeaderSettingFpSpreadChangedHandle HeaderSettingFpSpreadChanged;
    }
}