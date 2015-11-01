using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Controls.GlobalValue;
using QuickReportLib.Enums;
using QuickReportLib.Objects.GlobalValue;

namespace QuickReportLib.Class.Window
{
    /// <summary>
    /// 含有全局变量的ToolStripItem提供者。
    /// </summary>
    internal class GlobalValueToolStripItemProvider
    {
        private List<IGlobalValueToolStripItem> globalValueToolStripItems;
        private ToolStripSeparator toolStripSeparator;
        private IGlobalValueToolStripItemAsker iGlobalValueToolStripItemAsker;

        public ToolStripSeparator ToolStripSeparator
        {
            get
            {
                return toolStripSeparator;
            }
        }

        /// <summary>
        /// 获取包含系统变量的ToolStripSplitButton。
        /// </summary>
        public List<IGlobalValueToolStripItem> GlobalValueToolStripItems
        {
            get
            {
                if (globalValueToolStripItems == null)
                {
                    Init();
                }
                return globalValueToolStripItems;
            }
        }

        /// <summary>
        /// 初始化。
        /// </summary>
        private void Init()
        {
            toolStripSeparator = new ToolStripSeparator();
            toolStripSeparator.Visible = false;
            globalValueToolStripItems = new List<IGlobalValueToolStripItem>();
            IGlobalValueToolStripItem iGlobalValueToolStripItem;
            DateGlobalValue dateGlobalValue = new DateGlobalValue();
            iGlobalValueToolStripItem = GetIGlobalValueToolStripItem(dateGlobalValue);
            globalValueToolStripItems.Add(iGlobalValueToolStripItem);
            DateTimeGlobalValue dateTimeGlobalValue = new DateTimeGlobalValue();
            iGlobalValueToolStripItem = GetIGlobalValueToolStripItem(dateTimeGlobalValue);
            globalValueToolStripItems.Add(iGlobalValueToolStripItem);
            PersonGlobalValue personGlobalValue = new PersonGlobalValue();
            iGlobalValueToolStripItem = GetIGlobalValueToolStripItem(personGlobalValue);
            globalValueToolStripItems.Add(iGlobalValueToolStripItem);
            DepartmentGlobalValue departmentGlobalValue = new DepartmentGlobalValue();
            iGlobalValueToolStripItem = GetIGlobalValueToolStripItem(departmentGlobalValue);
            globalValueToolStripItems.Add(iGlobalValueToolStripItem);
            ColumnGlobalValue columnGlobalValue = new ColumnGlobalValue();
            iGlobalValueToolStripItem = GetIGlobalValueToolStripItem(columnGlobalValue);
            globalValueToolStripItems.Add(iGlobalValueToolStripItem);
            ConditionGlobalValue conditionGlobalValue = new ConditionGlobalValue();
            iGlobalValueToolStripItem = GetIGlobalValueToolStripItem(conditionGlobalValue);
            globalValueToolStripItems.Add(iGlobalValueToolStripItem);
            TreeGlobalValue treeGlobalValue = new TreeGlobalValue();
            iGlobalValueToolStripItem = GetIGlobalValueToolStripItem(treeGlobalValue);
            globalValueToolStripItems.Add(iGlobalValueToolStripItem);
            DonamicGlobalValue donamicGlobalValue = new DonamicGlobalValue();
            iGlobalValueToolStripItem = GetIGlobalValueToolStripItem(donamicGlobalValue);
            globalValueToolStripItems.Add(iGlobalValueToolStripItem);
        }

        /// <summary>
        /// 获得填充后的ToolStripSplitButton。
        /// </summary>
        /// <param name="iGlobalValue">全局变量。</param>
        /// <returns>填充后的ToolStripSplitButton。</returns>
        private IGlobalValueToolStripItem GetIGlobalValueToolStripItem(IGlobalValue iGlobalValue)
        {
            IGlobalValueToolStripItem toolStripItem=null;
            switch (iGlobalValue.GlobalValueType)
            {
                case GlobalValueType.Column:
                    {
                        toolStripItem = new ToolStripSplitButtonForGlobalValue();
                        (toolStripItem as ToolStripSplitButtonForGlobalValue).Image = global::QuickReportLib.Properties.Resources.Column;
                        break;
                    }
                case GlobalValueType.Condition:
                    {
                        toolStripItem = new ToolStripSplitButtonForGlobalValue();
                        (toolStripItem as ToolStripSplitButtonForGlobalValue).Image = global::QuickReportLib.Properties.Resources.Condition;
                        break;
                    }
                case GlobalValueType.Date:
                    {
                        toolStripItem = new ToolStripSplitButtonForGlobalValue();
                        (toolStripItem as ToolStripSplitButtonForGlobalValue).Image = global::QuickReportLib.Properties.Resources.Date;
                        break;
                    }
                case GlobalValueType.DateTime:
                    {
                        toolStripItem = new ToolStripSplitButtonForGlobalValue();
                        (toolStripItem as ToolStripSplitButtonForGlobalValue).Image = global::QuickReportLib.Properties.Resources.DateTime;
                        break;
                    }
                case GlobalValueType.Department:
                    {
                        toolStripItem = new ToolStripSplitButtonForGlobalValue();
                        (toolStripItem as ToolStripSplitButtonForGlobalValue).Image = global::QuickReportLib.Properties.Resources.Department;
                        break;
                    }
                case GlobalValueType.Donamic:
                    {
                        toolStripItem = new ToolStripSplitButtonForGlobalValue();
                        (toolStripItem as ToolStripSplitButtonForGlobalValue).Image = global::QuickReportLib.Properties.Resources.Donamic;
                        break;
                    }
                case GlobalValueType.Person:
                    {
                        toolStripItem = new ToolStripSplitButtonForGlobalValue();
                        (toolStripItem as ToolStripSplitButtonForGlobalValue).Image = global::QuickReportLib.Properties.Resources.Person;
                        break;
                    }
                case GlobalValueType.Tree:
                    {
                        toolStripItem = new ToolStripSplitButtonForGlobalValue();
                        (toolStripItem as ToolStripSplitButtonForGlobalValue).Image = global::QuickReportLib.Properties.Resources.Tree;
                        break;
                    }
            }
            if (toolStripItem == null)
                return null;
            toolStripItem.GlobalValueType = iGlobalValue.GlobalValueType;
            toolStripItem.SetGlobalValue(iGlobalValue);
            toolStripItem.SelectedGlobalValue += new SelectedGlobalValueHandle(toolStripItem_SelectedGlobalValue);
            (toolStripItem as ToolStripItem).Visible = false;
            return toolStripItem;
        }

        void toolStripItem_SelectedGlobalValue(object sender, string globalValue)
        {
            this.iGlobalValueToolStripItemAsker.SetGlobalValue(globalValue);
        }

        /// <summary>
        /// 更新全局变量的值。
        /// </summary>
        /// <param name="iGlobalValue">全局变量。</param>
        public void UpateGlobalValue(IGlobalValue iGlobalValue)
        {
            foreach (IGlobalValueToolStripItem iGlobalValueToolStripItem in globalValueToolStripItems)
            {
                if (iGlobalValueToolStripItem.GlobalValueType == iGlobalValue.GlobalValueType)
                {
                    iGlobalValueToolStripItem.SetGlobalValue(iGlobalValue);
                }
            }
        }

        /// <summary>
        /// 设置哪些全局变量可以被显示出来。
        /// </summary>
        /// <param name="iGlobalValueToolStripItemAsker">全局变量的请求者。</param>
        /// <param name="globalValueTypes">全局变量的类型。</param>
        public void SetGlobalValueVisible( IGlobalValueToolStripItemAsker iGlobalValueToolStripItemAsker,List<GlobalValueType> globalValueTypes )
        {
            this.iGlobalValueToolStripItemAsker = iGlobalValueToolStripItemAsker;
            toolStripSeparator.Visible = false;
            foreach (IGlobalValueToolStripItem iGlobalValueToolStripItem in globalValueToolStripItems)
            {
                bool visible =globalValueTypes.Contains(iGlobalValueToolStripItem.GlobalValueType);
                (iGlobalValueToolStripItem as ToolStripItem).Visible = visible;
                if (visible)
                {
                    toolStripSeparator.Visible = true;
                }
            }
        }
    }
}
