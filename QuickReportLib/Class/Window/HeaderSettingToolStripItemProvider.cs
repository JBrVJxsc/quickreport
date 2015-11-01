using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Enums;
using QuickReportLib.Controls;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;
using QuickReportLib.Managers;

namespace QuickReportLib.Class.Window
{
    /// <summary>
    /// ��ͷ������Ĺ������ṩ�ߡ�
    /// </summary>
    internal class HeaderSettingToolStripItemProvider
    {
        private ToolStripItem[] toolStripItems;
        private FpSpreadForHeaderSetting fpSpreadForHeaderSetting;
        private ToolStrip toolStrip;
        private Hashtable toolStripItemsSordIDCompare = new Hashtable();
        private bool haveBeenInited = false;

        /// <summary>
        /// ��������״̬��
        /// </summary>
        /// <param name="commandStatus">����״̬��</param>
        public void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        { 
            
        }

        /// <summary>
        /// ��ȡ������FpSpread��
        /// </summary>
        public FpSpreadForHeaderSetting FpSpread
        {
            get
            {
                return fpSpreadForHeaderSetting;
            }
            set
            {
                if (fpSpreadForHeaderSetting==value)
                {
                    return;
                }
                fpSpreadForHeaderSetting = value;
                fpSpreadForHeaderSetting.Enter += new EventHandler(fpSpreadForHeaderSetting_Enter);
                fpSpreadForHeaderSetting.Leave += new EventHandler(fpSpreadForHeaderSetting_Leave);
                fpSpreadForHeaderSetting.HeaderSettingCommandStatusChanged += new HeaderSettingCommandStatusChangedHandle(fpSpreadForHeaderSetting_HeaderSettingCommandStatusChanged);

            }
        }

        void fpSpreadForHeaderSetting_HeaderSettingCommandStatusChanged(object sender, HeaderSettingCommandStatus commandStatus)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void fpSpreadForHeaderSetting_Leave(object sender, EventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// ToolStripItem���顣
        /// </summary>
        public ToolStripItem[] ToolStripItems
        {
            get
            {
                return toolStripItems;
            }
            set
            {
                toolStripItems = value;
            }
        }

        private void InitToolStripItems()
        {
            List<object> objectList = ReflectionManager.CreateInstancesByInterfaceWithOutAbstract(typeof(IHeaderSettingToolStripItem));
            toolStripItems = new ToolStripItem[objectList.Count];
            foreach (object obj in objectList)
            {
                IHeaderSettingToolStripItem iHeaderSettingToolStripItem = obj as IHeaderSettingToolStripItem;
                //iHeaderSettingToolStripItem.FpSpread = fpMain;
                toolStripItems[iHeaderSettingToolStripItem.SortID] = iHeaderSettingToolStripItem as ToolStripItem;
            }
        }

        public void Init(ToolStrip toolStrip)
        {
            if (haveBeenInited)
            {
                return;
            }
            this.toolStrip = toolStrip;
            haveBeenInited = true;
            InitToolStripItems();
        }
    }
}
