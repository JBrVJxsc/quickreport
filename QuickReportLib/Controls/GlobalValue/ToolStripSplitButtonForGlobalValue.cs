using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Enums;
using QuickReportLib.Objects;
using QuickReportLib.Managers;

namespace QuickReportLib.Controls.GlobalValue
{
    /// <summary>
    /// 实现了IGlobalValueToolStripItem的ToolStripSplitButton。为全局变量服务。
    /// </summary>
    internal partial class ToolStripSplitButtonForGlobalValue : ToolStripSplitButton, IGlobalValueToolStripItem
    {
        public ToolStripSplitButtonForGlobalValue()
        {
            InitializeComponent();
        }

        private GlobalValueType globalValueType;

        private ToolStripMenuItem GetToolStripMenuItem(BaseObject baseObject, SQLCodeType sqlCodeType)
        {
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            BaseObject b = baseObject.Clone();
            b.ID = SQLManager.GetSQLCode(b.ID, sqlCodeType);
            toolStripMenuItem.Text = b.Name;
            toolStripMenuItem.Tag = b;
            return toolStripMenuItem;
        }

        private void ToolStripSplitButtonForGlobalValue_Click(object sender, EventArgs e)
        {
            ShowDropDown();
        }

        private void ToolStripSplitButtonForGlobalValue_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (SelectedGlobalValue != null)
            {
                string value = (e.ClickedItem.Tag as BaseObject).ID;
                SelectedGlobalValue(this, value);
            }
        }

        #region IGlobalValueToolStripItem 成员

        public event SelectedGlobalValueHandle SelectedGlobalValue;

        public GlobalValueType GlobalValueType
        {
            get
            {
                return globalValueType;
            }
            set
            {
                globalValueType = value;
            }
        }

        public void SetGlobalValue(IGlobalValue globalValue)
        {
            DropDownItems.Clear();
            List<BaseObject> baseObjects = globalValue.Value;
            SortedList sl = new SortedList();
            foreach (BaseObject baseObject in baseObjects)
            {
                sl.Add(baseObject, null);
            }
            foreach (DictionaryEntry de in sl)
            {
                ToolStripMenuItem toolStripMenuItem = GetToolStripMenuItem(de.Key as BaseObject, globalValue.SQLCodeType);
                DropDownItems.Add(toolStripMenuItem);
            }
        }

        #endregion
    }
}
