using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;

namespace QuickReportCore.Controls
{
    internal partial class ComboBoxWithFilter : System.Windows.Forms.ComboBox
    {
        public ComboBoxWithFilter()
        {
            InitializeComponent();
        }

        private Managers.QuickReportManager quickReportManager;
        private bool initSuccess = false;

        private string sqlBase = @"Select {0} ,FUN_GET_QUERYCODE(Base.Name,1) as 拼音码,FUN_GET_QUERYCODE(Base.Name,0) as 五笔码
From
(
{1}
)
Base";
        private string sqlColumnName = " Base.Name as 名称 ";
        private string sqlColumnBoth = " Base.Code as 编码, Base.Name as 名称 ";
        private string sqlUnionallName = "Select '{0}' as Name From Dual \n union all \n ";
        private string sqlUnionallBoth = "Select '{0}' as Code, '{1}' as Name From Dual  \n union all \n ";

        private Forms.frmFilter filterForm;

        private ColumnShowState columnShowState = ColumnShowState.Both;
        /// <summary>
        /// 列显示方式。
        /// </summary>
        public ColumnShowState ShowState
        {
            get
            {
                return columnShowState;
            }
            set
            {
                columnShowState = value;
            }
        }

        private string filterName = "过滤框";
        /// <summary>
        /// 筛选框标题。
        /// </summary>
        public string FilterName
        {
            get
            {
                return filterName;
            }
            set
            {
                filterName = value;
            }
        }

        private int InitFilterForm()
        {
            quickReportManager = new QuickReportCore.Managers.QuickReportManager();
            filterForm = new QuickReportCore.Forms.frmFilter();
            filterForm.Text=filterName;
            filterForm.SelectItem += new QuickReportCore.Forms.frmFilter.SelectItemHandle(filterForm_SelectItem);
            DataSet ds = GetDataSet();
            if (ds == null)
                return -1;
            return filterForm.InitFilter(ds);
        }

        void filterForm_SelectItem(string item)
        {
            Text = item;
        }

        private DataSet GetDataSet()
        {
            string sqlColumn = string.Empty;
            string sqlUnionall = string.Empty;
            string sqlAllUnionall=string.Empty;
            if (Items[0] as Objects.BaseObject == null||ShowState == ColumnShowState.Name)//判断，如果第一个不是BaseObject的，则默认以后的也不是，这样，就只显示一列“名称”。
            {
                sqlColumn = sqlColumnName;
                sqlUnionall = sqlUnionallName;
                for (int i = 0; i < Items.Count; i++)
                {
                    sqlAllUnionall += string.Format(sqlUnionall, Items[i].ToString());
                }
                sqlAllUnionall=sqlAllUnionall.Remove(sqlAllUnionall.LastIndexOf("union all"));
                string sql = string.Format(sqlBase,sqlColumn, sqlAllUnionall);
                DataSet ds=null;
                quickReportManager.ExecQuery(sql, ref ds);
                return ds;
            }
            else
            {
                sqlColumn = sqlColumnBoth;
                sqlUnionall = sqlUnionallBoth;
                for (int i = 0; i < Items.Count; i++)
                {
                    Objects.BaseObject obj = Items[i] as Objects.BaseObject;
                    if (obj == null)
                        sqlAllUnionall += string.Format(sqlUnionall, string.Empty, Items[i].ToString());
                    else
                        sqlAllUnionall += string.Format(sqlUnionall, obj.ID, obj.Name);
                }
                sqlAllUnionall = sqlAllUnionall.Remove(sqlAllUnionall.LastIndexOf("union all"));
                string sql = string.Format(sqlBase, sqlColumn, sqlAllUnionall);
                DataSet ds = null;
                quickReportManager.ExecQuery(sql, ref ds);
                return ds;
            }
        }

        private void ComboBoxWithFilter_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Width == 0)
                return;
            if (e.KeyCode != System.Windows.Forms.Keys.Space)
                return;
            e.SuppressKeyPress = true;
            if (Items.Count == 0)
                return;
            if (filterForm == null)
            {
                if (InitFilterForm() < 0)
                {
                    initSuccess = false;
                    return;
                }
                else
                    initSuccess = true;
            }
            if (initSuccess)
            {
                filterForm.ShowDialog();
                if (DropDownStyle != System.Windows.Forms.ComboBoxStyle.DropDownList && Text.StartsWith(" "))
                {
                    SuspendLayout();
                    Text = Text.Substring(1, Text.Length - 1);
                    Select(Text.Length, 0);
                    ResumeLayout();
                }
            }
        }

        /// <summary>
        /// 列显示方式。
        /// </summary>
        public enum ColumnShowState
        { 
            /// <summary>
            /// 只显示名称。
            /// </summary>
            Name,
            /// <summary>
            /// 全部显示。
            /// </summary>
            Both
        }
    }
}
