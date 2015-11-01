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
        /// 初始化工具栏按钮。
        /// </summary>
        private void InitToolStripItems()
        {
            //获得所有表头设置所需的按钮。
            List<object> objectList = ReflectionManager.CreateInstancesByInterfaceWithOutAbstract(typeof(IHeaderSettingToolStripItem));
            toolStripItems = new ToolStripItem[objectList.Count];
            #region 对按钮进行排序。
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
            //第一次接收Fp的编辑命令时，初始化按钮。
            if (toolStripItems == null)
            {
                InitToolStripItems();
            }
            //将Fp当前的编辑命令设置给按钮，让按钮处理Fp的命令。例如，当选中的是报表列时，设置Border的按钮都会变灰，就是这里起的作用。
            for (int i = 0; i < toolStripItems.Length; i++)
            {
                IHeaderSettingToolStripItem iHeaderSettingToolStripItem = toolStripItems[i] as IHeaderSettingToolStripItem;
                iHeaderSettingToolStripItem.SetCommandStatus(commandStatus);
            }
            //将已经处理Fp编辑命令的按钮发送到框架。
            if (ProvideToolStripMenu != null)
            {
                ProvideToolStripMenu(this, toolStripItems);
            }
        }

        private void fpMain_HeaderSettingFpSpreadChanged(object sender, HeaderSettingFpSpreadChangedType changedType)
        {
            if (toolStripItems != null)
            {
                //当Fp的行列数改变时，置按钮为灰。
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
                ShowStatusStripHelp(this, "设置报表的表头");
            }
            base.OnEnter(e);
        }

        /// <summary>
        /// 初始化表头设置控件。
        /// </summary>
        /// <param name="report">报表实体。</param>
        public void Init(Report report)
        {
            this.report = report;
            //初始化Fp。
            fpMain.Init(report);
        }

        /// <summary>
        /// 保存。
        /// </summary>
        /// <returns>1成功，-1失败。</returns>
        public int Save()
        {
            fpMain.StopCellEditing();
            fpMain.Save();
            return 1;
        }

        #region IToolStripMenuProvider 成员

        public event ProvideToolStripMenuHandle ProvideToolStripMenu;

        #endregion

        #region IShowStatusStripHelp 成员

        public event ShowStatusStripHelpHandle ShowStatusStripHelp;

        #endregion

        #region IChangedUserControl 成员

        public event EventHandler Changed;

        #endregion

        #region ILoadedListener 成员

        public void Loaded()
        {
            fpMain.HorizontalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
            fpMain.VerticalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
        }

        #endregion
    }
}
