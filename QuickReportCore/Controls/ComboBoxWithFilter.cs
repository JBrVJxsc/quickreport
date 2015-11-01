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

        private string sqlBase = @"Select {0} ,FUN_GET_QUERYCODE(Base.Name,1) as ƴ����,FUN_GET_QUERYCODE(Base.Name,0) as �����
From
(
{1}
)
Base";
        private string sqlColumnName = " Base.Name as ���� ";
        private string sqlColumnBoth = " Base.Code as ����, Base.Name as ���� ";
        private string sqlUnionallName = "Select '{0}' as Name From Dual \n union all \n ";
        private string sqlUnionallBoth = "Select '{0}' as Code, '{1}' as Name From Dual  \n union all \n ";

        private Forms.frmFilter filterForm;

        private ColumnShowState columnShowState = ColumnShowState.Both;
        /// <summary>
        /// ����ʾ��ʽ��
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

        private string filterName = "���˿�";
        /// <summary>
        /// ɸѡ����⡣
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
            if (Items[0] as Objects.BaseObject == null||ShowState == ColumnShowState.Name)//�жϣ������һ������BaseObject�ģ���Ĭ���Ժ��Ҳ���ǣ���������ֻ��ʾһ�С����ơ���
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
        /// ����ʾ��ʽ��
        /// </summary>
        public enum ColumnShowState
        { 
            /// <summary>
            /// ֻ��ʾ���ơ�
            /// </summary>
            Name,
            /// <summary>
            /// ȫ����ʾ��
            /// </summary>
            Both
        }
    }
}
