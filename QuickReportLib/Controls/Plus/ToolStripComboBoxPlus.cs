using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Windows.Forms;
using QuickReportLib.Managers;
using QuickReportLib.Controls.Forms;
using QuickReportLib.Enums;
using QuickReportLib.Objects;

namespace QuickReportLib.Controls.Plus
{
    /// <summary>
    /// �Զ����ToolStripComboBox���ṩ���¿ո���ʾɸѡ��ȹ��ܡ�
    /// </summary>
    internal partial class ToolStripComboBoxPlus : ToolStripComboBox 
    {
        public ToolStripComboBoxPlus()
        {
            InitializeComponent();
        }

        private DataBaseManager dataBaseManager;
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
        private FilterForm filterForm;
        private ComboBoxPlusColumnShowState columnShowState = ComboBoxPlusColumnShowState.Both;
        private string filterName = "���˿�";

        /// <summary>
        /// ����ʾ��ʽ��
        /// </summary>
        public ComboBoxPlusColumnShowState ColumnShowState
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
            dataBaseManager = new DataBaseManager();
            filterForm = new FilterForm();
            filterForm.Text = filterName;
            filterForm.SelectItem += new FilterForm.SelectItemHandle(filterForm_SelectItem);
            DataSet ds = GetDataSet();
            if (ds == null)
            {
                return -1;
            }
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
            string sqlAllUnionall = string.Empty;
            if (Items[0] as BaseObject == null || ColumnShowState == ComboBoxPlusColumnShowState.Name)//�жϣ������һ������BaseObject�ģ���Ĭ���Ժ��Ҳ���ǣ���������ֻ��ʾһ�С����ơ���
            {
                sqlColumn = sqlColumnName;
                sqlUnionall = sqlUnionallName;
                for (int i = 0; i < Items.Count; i++)
                {
                    sqlAllUnionall += string.Format(sqlUnionall, Items[i].ToString());
                }
                sqlAllUnionall = sqlAllUnionall.Remove(sqlAllUnionall.LastIndexOf("union all"));
                string sql = string.Format(sqlBase, sqlColumn, sqlAllUnionall);
                DataSet ds = null;
                dataBaseManager.ExecQuery(sql, ref ds);
                return ds;
            }
            else
            {
                sqlColumn = sqlColumnBoth;
                sqlUnionall = sqlUnionallBoth;
                for (int i = 0; i < Items.Count; i++)
                {
                    BaseObject obj = Items[i] as BaseObject;
                    if (obj == null)
                    {
                        sqlAllUnionall += string.Format(sqlUnionall, string.Empty, Items[i].ToString());
                    }
                    else
                    {
                        sqlAllUnionall += string.Format(sqlUnionall, obj.ID, obj.Name);
                    }
                }
                sqlAllUnionall = sqlAllUnionall.Remove(sqlAllUnionall.LastIndexOf("union all"));
                string sql = string.Format(sqlBase, sqlColumn, sqlAllUnionall);
                DataSet ds = null;
                dataBaseManager.ExecQuery(sql, ref ds);
                return ds;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (Width == 0)
            {
                return;
            }
            if (e.KeyCode != System.Windows.Forms.Keys.Space)
            {
                if (e.KeyCode == Keys.Enter && DropDownStyle != ComboBoxStyle.DropDownList)
                {
                    for (int i = 0; i < Items.Count; i++)
                    {
                        BaseObject baseObject = Items[i] as BaseObject;
                        if (baseObject != null)
                        {
                            if (baseObject.ID == Text)
                            {
                                SelectedItem = baseObject;
                                Select(Text.Length, 0);
                                break;
                            }
                        }
                    }
                }
                return;
            }
            if (Items.Count == 0)
            {
                return;
            }
            e.SuppressKeyPress = true;
            ShowFilter();
            base.OnKeyDown(e);
        }

        /// <summary>
        /// ���ɸѡ����
        /// </summary>
        public void ClearFilter()
        {
            filterForm = null;
        }

        /// <summary>
        /// ��ʾɸѡ����
        /// </summary>
        public void ShowFilter()
        {
            if (Items.Count == 0)
            {
                return;
            }
            if (filterForm == null)
            {
                if (InitFilterForm() < 0)
                {
                    initSuccess = false;
                    return;
                }
                else
                {
                    initSuccess = true;
                }
            }
            if (initSuccess)
            {
                filterForm.ShowDialog();
            }
        }
    }
}
