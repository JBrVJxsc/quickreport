using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;

namespace QuickReportCore.Forms
{
    internal partial class frmToolBoxSystemValue : frmBaseToolBox, Interfaces.IHaveAToolStrip, Interfaces.INeedRefreshDataSource, Interfaces.IHaveAComboBox
    {
        public frmToolBoxSystemValue()
        {
            InitializeComponent();
            Init();
        }

        public static System.Reflection.Assembly assembly;
        public static bool SystemValueListHasBeenChanged = false;
        public static Hashtable htSystemValueList = new Hashtable();

        private void Init()
        {
            ShowSystemValues();
            RefreshTreeCondtion();
            RefreshDynamicCondition();
        }

        private void ShowSystemValues()
        {
            CleaeItems();
            SortedList sl = new SortedList();
            foreach (DictionaryEntry de in htSystemValueList)
            {
                sl.Add(de.Key, de.Value);
            }
            foreach (DictionaryEntry de in sl)
            {
                AddSystemValue(de.Value as PublicInterfaces.ISystemValue);
            }
        }

        private void CleaeItems()
        {
            Date.DropDownItems.Clear();
            DateTime.DropDownItems.Clear();
            Oper.DropDownItems.Clear();
            Dept.DropDownItems.Clear();
        }

        private void AddSystemValue(PublicInterfaces.ISystemValue systemValue)
        {
            if (systemValue.SystemValueType == QuickReportCore.Objects.SystemValues.SystemValueType.Date)
                Date.DropDownItems.Add(NewToolStripMenuItem(systemValue));
            if (systemValue.SystemValueType == QuickReportCore.Objects.SystemValues.SystemValueType.DateTime)
                DateTime.DropDownItems.Add(NewToolStripMenuItem(systemValue));
            if (systemValue.SystemValueType == QuickReportCore.Objects.SystemValues.SystemValueType.Oper)
                Oper.DropDownItems.Add(NewToolStripMenuItem(systemValue));
            if (systemValue.SystemValueType == QuickReportCore.Objects.SystemValues.SystemValueType.Dept)
                Dept.DropDownItems.Add(NewToolStripMenuItem(systemValue));
        }

        private void RefreshReportColumn()
        {
            tbReportColumn.DropDownItems.Clear();
            SortedList sl = new SortedList();
            for (int i = 0; i < QuickReportCore.Controls.ucColumnList.GobalColumnList.Count; i++)
            {
                sl.Add(QuickReportCore.Controls.ucColumnList.GobalColumnList[i].Clone(), null);
            }
            foreach (DictionaryEntry de in sl)
            {
                tbReportColumn.DropDownItems.Add(NewToolStripMenuItemOfColumn(de.Key as Objects.Column));
            }
        }

        private void RefreshReportCondition()
        {
            tbReportCondition.DropDownItems.Clear();
            SortedList sl = new SortedList();
            for (int i = 0; i < QuickReportCore.Controls.ucConditionList.GobalConditionList.Count; i++)
            {
                sl.Add(QuickReportCore.Controls.ucConditionList.GobalConditionList[i].Clone(), null);
            }
            foreach (DictionaryEntry de in sl)
            {
                tbReportCondition.DropDownItems.Add(NewToolStripMenuItemOfCondition(de.Key as Objects.Condition));
            }
            
        }

        private void RefreshTreeCondtion()
        {
            tbTreeCondition.DropDownItems.Clear();
            Objects.Column c = new QuickReportCore.Objects.Column();
            c.ID = c.Name = TreeValueType.节点编码.ToString();
            tbTreeCondition.DropDownItems.Add(NewToolStripMenuItemOfTree(c.Clone()));
            c.ID = c.Name = TreeValueType.节点名称.ToString();
            tbTreeCondition.DropDownItems.Add(NewToolStripMenuItemOfTree(c.Clone()));
        }

        private void RefreshDynamicCondition()
        {
            tbReportDynamic.DropDownItems.Clear();
            Objects.Column c = new QuickReportCore.Objects.Column();
            c.ID = c.Name = DynamicSystemValueType.行数.ToString();
            tbReportDynamic.DropDownItems.Add(NewToolStripMenuItemOfDynamic(c.Clone())); 
            c.ID = c.Name = DynamicSystemValueType.列数.ToString();
            tbReportDynamic.DropDownItems.Add(NewToolStripMenuItemOfDynamic(c.Clone()));
            c.ID = c.Name = DynamicSystemValueType.耗时.ToString();
            tbReportDynamic.DropDownItems.Add(NewToolStripMenuItemOfDynamic(c.Clone()));
        }

        private ToolStripMenuItem NewToolStripMenuItem(PublicInterfaces.ISystemValue systemValue)
        {
            ToolStripMenuItem t = new ToolStripMenuItem();
            Objects.Column column = new QuickReportCore.Objects.Column();
            column.ID = Managers.Functions.GetSQLCode(systemValue.ValueID, QuickReportCore.Managers.Functions.SQLCodeType.System);
            column.Name = systemValue.ValueName;
            t.Name = column.ID;
            t.Text = column.Name;
            t.Tag = column;
            return t;
        }

        private ToolStripMenuItem NewToolStripMenuItemOfCondition(Objects.Condition condition)
        {
            ToolStripMenuItem t = new ToolStripMenuItem();
            condition.ID = Managers.Functions.GetSQLCode(condition.ID, QuickReportCore.Managers.Functions.SQLCodeType.Condition);
            t.Name = condition.ID;
            t.Text = condition.Name;
            t.Tag = condition;
            return t;
        }

        private ToolStripMenuItem NewToolStripMenuItemOfTree(Objects.Column column)
        {
            ToolStripMenuItem t = new ToolStripMenuItem();
            column.ID = Managers.Functions.GetSQLCode(column.ID, QuickReportCore.Managers.Functions.SQLCodeType.Tree);
            t.Name = column.ID;
            t.Text = column.Name;
            t.Tag = column;
            return t;
        }

        private ToolStripMenuItem NewToolStripMenuItemOfDynamic(Objects.Column column)
        {
            ToolStripMenuItem t = new ToolStripMenuItem();
            column.ID = Managers.Functions.GetSQLCode(column.ID, QuickReportCore.Managers.Functions.SQLCodeType.Dynamic);
            t.Name = column.ID;
            t.Text = column.Name;
            t.Tag = column;
            return t;
        }

        private ToolStripMenuItem NewToolStripMenuItemOfColumn(Objects.Column column)
        {
            ToolStripMenuItem t = new ToolStripMenuItem();
            column.ID = Managers.Functions.GetSQLCode(column.ID, QuickReportCore.Managers.Functions.SQLCodeType.Column);
            t.Name = column.ID;
            t.Text = column.Name;
            t.Tag = column;
            return t;
        }

        private void tb_Click(object sender, EventArgs e)
        {
            ((ToolStripSplitButton)sender).ShowDropDown();
        }

        private void tb_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            lbCurrentSelection.Text = ((Objects.Column)e.ClickedItem.Tag).Name;
            Clipboard.SetDataObject(((Objects.Column)e.ClickedItem.Tag).ID);
        }

        private void tbReportCondition_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            lbCurrentSelection.Text = ((Objects.Condition)e.ClickedItem.Tag).Name;
            Clipboard.SetDataObject(((Objects.Condition)e.ClickedItem.Tag).ID);
        }

        private void tbTreeCondition_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            lbCurrentSelection.Text = ((Objects.Column)e.ClickedItem.Tag).Name;
            Clipboard.SetDataObject(((Objects.Column)e.ClickedItem.Tag).ID);
        }

        private void tbReportColumn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            lbCurrentSelection.Text = ((Objects.Column)e.ClickedItem.Tag).Name;
            Clipboard.SetDataObject(((Objects.Column)e.ClickedItem.Tag).ID);
        }

        #region IHaveAToolStrip 成员

        public void SetToolStripFocus()
        {
            Focus();
        }

        #endregion

        #region INeedRefreshDataSource 成员

        public void RefreshDataSource(Forms.frmToolBoxSystemValue.GobalValueType type)
        {
            if (type == GobalValueType.Column)
                RefreshReportColumn();
            if (type == GobalValueType.Condition)
                RefreshReportCondition();
        }

        #endregion

        public static void GetAllSystemValue()
        {
            htSystemValueList = new Hashtable();
            assembly = Assembly.LoadFrom("QuickReportCore.dll");
            Type[] types = assembly.GetTypes();
            List<Type> typeList = new List<Type>();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].GetInterface(typeof(PublicInterfaces.ISystemValue).FullName) == null)
                    continue;
                PublicInterfaces.ISystemValue iSystemValue = System.Activator.CreateInstance(types[i]) as PublicInterfaces.ISystemValue;
                AddSystemValueToStaticSystemValueList(iSystemValue);
            }
        }

        /// <summary>
        /// 想全局系统变量列表中添加系统变量。若ID重复，则不添加。
        /// </summary>
        /// <param name="iSystemValue">系统变量。</param>
        public static void AddSystemValueToStaticSystemValueList(PublicInterfaces.ISystemValue iSystemValue)
        {
            if (iSystemValue == null)
                return;
            if (!htSystemValueList.Contains(iSystemValue.ValueID))
            {
                htSystemValueList.Add(iSystemValue.ValueID, iSystemValue);
            }
        }

        public static void DeleteSystemValueFromStaticSystemValueList(PublicInterfaces.ISystemValue iSystemValue)
        {
            if (htSystemValueList.Contains(iSystemValue.ValueID))
            {
                htSystemValueList.Remove(iSystemValue.ValueID);
            }
        }

        public static void DeleteSystemValueFromStaticSystemValueList(string valueID)
        {
            if (htSystemValueList.Contains(valueID))
            {
                htSystemValueList.Remove(valueID);
            }
        }

        static frmToolBoxSystemValue()
        {
            GetAllSystemValue();
        }

        /// <summary>
        /// 全局变量种类。
        /// </summary>
        public enum GobalValueType
        {
            Column,
            Condition,
            Tree
        }

        #region INeedRefreshDataSource 成员


        public List<frmToolBoxSystemValue.GobalValueType> GobalValueTypesNeeded()
        {
            List<frmToolBoxSystemValue.GobalValueType> list = new List<frmToolBoxSystemValue.GobalValueType>();
            list.Add(frmToolBoxSystemValue.GobalValueType.Column);
            list.Add(frmToolBoxSystemValue.GobalValueType.Condition);
            return list;
        }

        #endregion

        public enum TreeValueType
        { 
            节点编码,
            节点名称
        }

        /// <summary>
        /// 动态系统变量。
        /// </summary>
        public enum DynamicSystemValueType
        {
            /// <summary>
            /// 行数。
            /// </summary>
            行数,
            /// <summary>
            /// 列数。
            /// </summary>
            列数,
            /// <summary>
            /// 查询耗时。
            /// </summary>
            耗时
        }

        #region IHaveAComboBox 成员

        private bool comboBoxShowState = false;
        public bool ComboBoxShowState
        {
            get { return comboBoxShowState; }
        }

        #endregion

        private void tb_DropDownOpened(object sender, EventArgs e)
        {
            comboBoxShowState = true;
        }

        private void tb_DropDownClosed(object sender, EventArgs e)
        {
            comboBoxShowState = false;
        }

        private void tbReportDynamic_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            lbCurrentSelection.Text = ((Objects.Column)e.ClickedItem.Tag).Name;
            Clipboard.SetDataObject(((Objects.Column)e.ClickedItem.Tag).ID);
        }

        private void frmToolBoxSystemValue_Activated(object sender, EventArgs e)
        {
            if (!SystemValueListHasBeenChanged)
                return;
            ShowSystemValues();
            SystemValueListHasBeenChanged = false;
        }
    }
}