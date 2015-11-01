using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;

namespace QuickReportCore.Forms
{
    internal partial class frmToolBoxCrossSetting : frmBaseToolBox, QuickReportCore.Interfaces.IConvertToXml, Interfaces.INeedRefreshDataSource, Interfaces.IHaveAToolStrip, Interfaces.ICheckInput, Interfaces.IHaveAComboBox,Interfaces.IHaveBeenChanged
    {
        public frmToolBoxCrossSetting()
        {
            InitializeComponent();
            tabControlCustom.TabPages.Remove(tbRow);//��ʱ���ṩ�Զ����й��ܡ�
        }

        private void RefreshColumnList()
        {
            string row = cmbRow.Text;
            string column = cmbColumn.Text;
            string value = cmbValue.Text;
            string groupRow = cmbGroupSumRow.Text;
            string groupColumn = cmbGroupSumColumn.Text;
            cmbSelectProtector = true;
            cmbRow.Items.Clear();
            cmbColumn.Items.Clear();
            cmbValue.Items.Clear();
            cmbGroupSumRow.Items.Clear();
            cmbGroupSumColumn.Items.Clear();
            for (int i = 0; i < QuickReportCore.Controls.ucColumnList.GobalColumnList.Count; i++)
            {
                cmbRow.Items.Add(QuickReportCore.Controls.ucColumnList.GobalColumnList[i]);
                cmbColumn.Items.Add(QuickReportCore.Controls.ucColumnList.GobalColumnList[i]);
                cmbValue.Items.Add(QuickReportCore.Controls.ucColumnList.GobalColumnList[i]);
                cmbGroupSumRow.Items.Add(QuickReportCore.Controls.ucColumnList.GobalColumnList[i]);
                cmbGroupSumColumn.Items.Add(QuickReportCore.Controls.ucColumnList.GobalColumnList[i]);
            }
            cmbRow.Items.Add(string.Empty);
            cmbColumn.Items.Add(string.Empty);
            cmbValue.Items.Add(string.Empty);
            cmbGroupSumRow.Items.Add(string.Empty);
            cmbGroupSumColumn.Items.Add(string.Empty);
            cmbSelectProtector = false;
            cmbRow.Text = row;
            cmbColumn.Text = column;
            cmbValue.Text = value;
            cmbGroupSumRow.Text = groupRow;
            cmbGroupSumColumn.Text = groupColumn;
        }

        #region IConvertToXml ��Ա

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.ViewSettingCrossSetting.ToString());
            node.SetAttribute(XmlAttrDic.tRow.ToString(), cmbRow.Text);
            node.SetAttribute(XmlAttrDic.tColumn.ToString(), cmbColumn.Text);
            node.SetAttribute(XmlAttrDic.tValue.ToString(), cmbValue.Text);
            node.SetAttribute(XmlAttrDic.tGroupSumRow.ToString(), cmbGroupSumRow.Text);
            node.SetAttribute(XmlAttrDic.tGroupSumColumn.ToString(), cmbGroupSumColumn.Text);
            node.SetAttribute(XmlAttrDic.bCustomColumn.ToString(), Convert.ToInt32(tbUseCustomColumn.Checked).ToString());
            node.SetAttribute(XmlAttrDic.bCustomRow.ToString(), Convert.ToInt32(tbUseCustomRow.Checked).ToString());
            node.SetAttribute(XmlAttrDic.tCustomColumnSQL.ToString(), txtColumnSql.Text );
            node.SetAttribute(XmlAttrDic.tCustomColumnName.ToString(), cmbCustomColumnName.Text );
            node.SetAttribute(XmlAttrDic.tGroupSumCustomColumn.ToString(), cmbCustomColumnGroupSum.Text);
            node.SetAttribute(XmlAttrDic.tCustomRowSQL.ToString(), txtRowSql.Text);
            node.SetAttribute(XmlAttrDic.tCustomRowName.ToString(), cmbCustomRowName.Text);
            node.SetAttribute(XmlAttrDic.tGroupSumCustomRow.ToString(), cmbCustomRowGroupSum.Text);
            node.SetAttribute(XmlAttrDic.tGroupSumRowName.ToString(), txtGroupSumRowName.Text);
            node.SetAttribute(XmlAttrDic.tGroupSumColumnName.ToString(), txtGroupSumColumnName.Text);
            node.SetAttribute(XmlAttrDic.tCustomColumnGroupSumName.ToString(), txtCustomColumnGroupSumName.Text);
            node.SetAttribute(XmlAttrDic.bRowSum.ToString(), Convert.ToInt32(cbRowSum.Checked).ToString());
            node.SetAttribute(XmlAttrDic.bColumnSum.ToString(), Convert.ToInt32(cbColumnSum.Checked).ToString());
            node.SetAttribute(XmlAttrDic.bUseGroupSumRow.ToString(), Convert.ToInt32(cbUseGroupSumRow.Checked).ToString());
            node.SetAttribute(XmlAttrDic.bUseHeader.ToString(), Convert.ToInt32(cbUseHeader.Checked).ToString());
            node.SetAttribute(XmlAttrDic.bUnion.ToString(), Convert.ToInt32(cbUnion.Checked).ToString());
            return node;
        }

        public enum XmlAttrDic
        { 
            ViewSettingCrossSetting,
            /// <summary>
            /// ���汨����С�
            /// </summary>
            tRow,
            /// <summary>
            /// ���汨����С�
            /// </summary>
            tColumn,
            /// <summary>
            /// ���汨���ֵ��
            /// </summary>
            tValue,
            /// <summary>
            /// ������С�Ƶ��С�
            /// </summary>
            tGroupSumRow,
            /// <summary>
            /// ������С�Ƶ��С�
            /// </summary>
            tGroupSumColumn,
            /// <summary>
            /// �Ƿ�ʹ���Զ����С�
            /// </summary>
            bCustomColumn,
            /// <summary>
            /// �Ƿ�ʹ���Զ����С�
            /// </summary>
            bCustomRow,
            /// <summary>
            /// �Զ�����SQL��
            /// </summary>
            tCustomColumnSQL,
            /// <summary>
            /// �Զ�����SQL��
            /// </summary>
            tCustomRowSQL,
            /// <summary>
            /// �Զ�����SQL�У�������Ϊ���汨����С�
            /// </summary>
            tCustomColumnName,
            /// <summary>
            /// �Զ�����SQL�У�������Ϊ���汨����С�
            /// </summary>
            tCustomRowName,
            /// <summary>
            /// �Զ�����ͳ��С��ʱ�������з��顣
            /// </summary>
            tGroupSumCustomColumn,
            /// <summary>
            /// �Զ�����ͳ��С��ʱ�������з��顣
            /// </summary>
            tGroupSumCustomRow,
            tGroupSumRowName,
            tGroupSumColumnName,
            tCustomColumnGroupSumName,
            bRowSum,
            bColumnSum,
            bUseGroupSumRow,
            bUseHeader,
            bUnion
        }

        #endregion

        private void ParseSql(string type)
        {
            if (type == "column")
            {
                ArrayList list = QuickReportCore.Managers.Functions.ParseSql(txtColumnSql.Text);
                if (list == null || list[0] == null || list[1] == null)
                {
                    QuickReportCore.Managers.Functions.ShowToolTip(txtColumnSql, "SQL����ʽ�������޸ġ�", txtColumnSql.Location);
                    txtColumnSql.SelectAll();
                    return;
                }
                else
                {
                    List<QuickReportCore.Objects.Column> columnList = list[0] as List<QuickReportCore.Objects.Column>;
                    string name = cmbCustomColumnName.Text;
                    string group = cmbCustomColumnGroupSum.Text;
                    cmbCustomColumnName.Items.Clear();
                    cmbCustomColumnGroupSum.Items.Clear();
                    for (int i = 0; i < columnList.Count; i++)
                    {
                        cmbCustomColumnName.Items.Add(columnList[i]);
                        cmbCustomColumnGroupSum.Items.Add(columnList[i]);
                    }
                    cmbCustomColumnName.Items.Add(string.Empty);
                    cmbCustomColumnGroupSum.Items.Add(string.Empty);
                    cmbCustomColumnName.Text = name;
                    cmbCustomColumnGroupSum.Text = group;
                }
            }
            else if (type == "row")
            {
                ArrayList list = QuickReportCore.Managers.Functions.ParseSql(txtRowSql.Text);
                if (list == null || list[0] == null || list[1] == null)
                {
                    QuickReportCore.Managers.Functions.ShowToolTip(txtRowSql, "SQL����ʽ�������޸ġ�", txtRowSql.Location);
                    txtRowSql.SelectAll();
                    return;
                }
                else
                {
                    List<QuickReportCore.Objects.Column> columnList = list[0] as List<QuickReportCore.Objects.Column>;
                    string name = cmbCustomRowName.Text;
                    string group = cmbCustomRowGroupSum.Text;
                    cmbCustomRowName.Items.Clear();
                    cmbCustomRowGroupSum.Items.Clear();
                    for (int i = 0; i < columnList.Count; i++)
                    {
                        cmbCustomRowName.Items.Add(columnList[i]);
                        cmbCustomRowGroupSum.Items.Add(columnList[i]);
                    }
                    cmbCustomRowName.Items.Add(string.Empty);
                    cmbCustomRowGroupSum.Items.Add(string.Empty);
                    cmbCustomRowName.Text = name;
                    cmbCustomRowGroupSum.Text = group;
                }
            }
        }

        #region IConvertToXml ��Ա


        public void ParseFromXml(XmlDocument xmlDocument)
        {
            System.Xml.XmlNode node = xmlDocument.SelectSingleNode("//" + XmlAttrDic.ViewSettingCrossSetting.ToString());
            if (node != null)
            {
                txtColumnSql.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tCustomColumnSQL.ToString(), string.Empty);
                txtRowSql.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tCustomRowSQL.ToString(), string.Empty);
                ParseSql("column");
                ParseSql("row");
                cmbRow.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tRow.ToString(), string.Empty);
                cmbColumn.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tColumn.ToString(), string.Empty);
                cmbValue.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tValue.ToString(), string.Empty);
                cmbGroupSumRow.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tGroupSumRow.ToString(), string.Empty);
                cmbGroupSumColumn.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tGroupSumColumn.ToString(), string.Empty);
                cmbCustomColumnName.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tCustomColumnName.ToString(), string.Empty);
                cmbCustomRowName.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tCustomRowName.ToString(), string.Empty);
                cmbCustomColumnGroupSum.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tGroupSumCustomColumn.ToString(), string.Empty);
                cmbCustomRowGroupSum.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tGroupSumCustomRow.ToString(), string.Empty);
                tbUseCustomColumn.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.bCustomColumn.ToString(), "0")));
                tbUseCustomRow.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.bCustomRow.ToString(), "0")));
                txtGroupSumRowName.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tGroupSumRowName.ToString(), string.Empty);
                txtGroupSumColumnName.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tGroupSumColumnName.ToString(), string.Empty);
                txtCustomColumnGroupSumName.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tCustomColumnGroupSumName.ToString(), string.Empty);
                cbRowSum.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.bRowSum.ToString(), "0")));
                cbColumnSum.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.bColumnSum.ToString(), "0")));
                cbUseGroupSumRow.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.bUseGroupSumRow.ToString(), "0")));
                cbUnion.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.bUnion.ToString(), "0")));
                cbUseHeader.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.bUseHeader.ToString(), "0")));
                cmbGroupSumColumn.Enabled = !tbUseCustomColumn.Checked;
                cmbGroupSumRow.Enabled = !tbUseCustomRow.Checked;
            }
        }

        #endregion

        #region INeedRefreshDataSource ��Ա

        public void RefreshDataSource(Forms.frmToolBoxSystemValue.GobalValueType type)
        {
            if (type != frmToolBoxSystemValue.GobalValueType.Column)
                return;
            RefreshColumnList();
        }

        #endregion

        #region IConvertToXml ��Ա


        public void ParseFromXml(System.Xml.XmlNodeList xmlNodeList)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
                ((TextBox)sender).SelectAll();
        }

        #region INeedRefreshDataSource ��Ա


        public List<frmToolBoxSystemValue.GobalValueType> GobalValueTypesNeeded()
        {
            List<frmToolBoxSystemValue.GobalValueType> list = new List<frmToolBoxSystemValue.GobalValueType>();
            list.Add(frmToolBoxSystemValue.GobalValueType.Column);
            return list;
        }

        #endregion

        #region IHaveAToolStrip ��Ա

        public void SetToolStripFocus()
        {
            Focus();
        }

        #endregion

        private bool cmbSelectProtector = false;
        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectProtector)
                return;
            if ((sender as ComboBox).Name == "cmbGroupSumRow")
            {
                if (cmbGroupSumRow.Text == string.Empty)
                    cbUseGroupSumRow.Checked = cbUseHeader.Checked =cbUnion.Checked = false;                
            }
            cmbSelectProtector = true;
            if (CheckCmbInput() < 0)
            {
                QuickReportCore.Managers.Functions.ShowToolTip(sender as Control,   ((ComboBox)sender).Text+"�ѱ�ʹ�á�", 3000);
                ((ComboBox)sender).Text = string.Empty;
            }
            if ((sender as ComboBox).Name == "cmbGroupSumRow" || (sender as ComboBox).Name == "cmbGroupSumColumn")
            {
                if (cmbValue.SelectedItem != null && (cmbValue.SelectedItem as Objects.Column)!=null)
                {
                    if (!(cmbValue.SelectedItem as Objects.Column).IsNumber&&(sender as ComboBox).Text!=string.Empty)
                    {
                        QuickReportCore.Managers.Functions.ShowToolTip(sender as Control, "�޷�Ϊ"+cmbValue.Text + "����С�ơ�", 3000);
                        ((ComboBox)sender).Text = string.Empty;
                    }
                }
            }
            if ((sender as ComboBox).Name == "cmbValue")
            {
                if (cmbValue.SelectedItem != null && (cmbValue.SelectedItem as Objects.Column) != null)
                {
                    if (!(cmbValue.SelectedItem as Objects.Column).IsNumber)
                    {
                        cmbGroupSumRow.Text = string.Empty;
                        cmbGroupSumColumn.Text = string.Empty;
                        cbRowSum.Checked = cbColumnSum.Checked = false;
                    }
                }
            }
            cmbSelectProtector = false;
        }

        #region ICheckInput ��Ա

        public int CheckInput()
        {
            int i = CheckCmbInput();
            if (i < 0)
            {
                return -1;
            }
            i = CheckCustomColumn();
            if (i < 0)
            {
                return -1;
            }
            i = CheckRowColumnValue();
            if (i < 0)
            {
                return -1;
            }
            return 1;
        }

        #endregion

        private int CheckCmbInput()
        {
            if (cmbRow.Text == cmbColumn.Text && cmbRow.Text != string.Empty && cmbColumn.Text!=string.Empty)
            {
                return -1;
            }
            if (cmbRow.Text == cmbValue.Text && cmbRow.Text != string.Empty && cmbValue.Text != string.Empty)
            {
                return -1;
            }
            if (cmbRow.Text == cmbGroupSumRow.Text && cmbRow.Text != string.Empty && cmbGroupSumRow.Text != string.Empty)
            {
                return -1;
            }
            if (cmbRow.Text == cmbGroupSumColumn.Text && cmbRow.Text != string.Empty && cmbGroupSumColumn.Text != string.Empty)
            {
                return -1;
            }

            if (cmbColumn.Text == cmbValue.Text && cmbColumn.Text != string.Empty && cmbValue.Text != string.Empty)
            {
                return -1;
            }
            if (cmbColumn.Text == cmbGroupSumRow.Text && cmbColumn.Text != string.Empty && cmbGroupSumRow.Text != string.Empty)
            {
                return -1;
            }
            if (cmbColumn.Text == cmbGroupSumColumn.Text && cmbColumn.Text != string.Empty && cmbGroupSumColumn.Text != string.Empty)
            {
                return -1;
            }

            if (cmbValue.Text == cmbGroupSumRow.Text && cmbValue.Text != string.Empty && cmbGroupSumRow.Text != string.Empty)
            {
                return -1;
            }
            if (cmbValue.Text == cmbGroupSumColumn.Text && cmbValue.Text != string.Empty && cmbGroupSumColumn.Text != string.Empty)
            {
                return -1;
            }

            if (cmbGroupSumRow.Text == cmbGroupSumColumn.Text && cmbGroupSumRow.Text != string.Empty && cmbGroupSumColumn.Text != string.Empty)
            {
                return -1;
            }
            return 1;
        }

        private int CheckCustomColumn()
        {
            if (tbUseCustomColumn.Checked)
            {
                if (txtColumnSql.Text == string.Empty)
                {
                    if (Visible == false)
                        Show();
                    Focus();
                    QuickReportCore.Managers.Functions.ShowToolTip(txtColumnSql, "������һ������ʹ�õ�SQL��", txtColumnSql.Location);
                    return -1;
                }
                if (cmbCustomColumnName.Text == string.Empty)
                {
                    if (Visible == false)
                        Show();
                    Focus();
                    QuickReportCore.Managers.Functions.ShowToolTip(cmbCustomColumnName, "��ѡ��������", 3000);
                    return -1;
                }
            }
            if (tbUseCustomRow.Checked)
            {
                if (txtRowSql.Text == string.Empty)
                {
                    if (Visible == false)
                        Show();
                    Focus();
                    QuickReportCore.Managers.Functions.ShowToolTip(txtRowSql, "������һ������ʹ�õ�SQL��", txtRowSql.Location);
                    return -1;
                }
                if (cmbCustomRowName.Text == string.Empty)
                {
                    if (Visible == false)
                        Show();
                    Focus();
                    QuickReportCore.Managers.Functions.ShowToolTip(cmbCustomRowName, "��ѡ��������", 3000);
                    return -1;
                }
            }
            return 1;
        }

        private int CheckRowColumnValue()
        {
            if (cmbRow.Text == string.Empty)
            {
                if (Visible == false)
                    Show();
                Focus();
                QuickReportCore.Managers.Functions.ShowToolTip(cmbRow, "��ѡ���С�", 3000);
                return -1;
            }
            if (cmbColumn.Text == string.Empty)
            {
                if (Visible == false)
                    Show();
                Focus();
                QuickReportCore.Managers.Functions.ShowToolTip(cmbColumn, "��ѡ���С�", 3000);
                return -1;
            }
            if (cmbValue.Text == string.Empty)
            {
                if (Visible == false)
                    Show();
                Focus();
                QuickReportCore.Managers.Functions.ShowToolTip(cmbValue, "��ѡ��ֵ��", 3000);
                return -1;
            }
            return 1;
        }

        #region IHaveAComboBox ��Ա

        private bool comboBoxShowState = false;
        public bool ComboBoxShowState
        {
            get { return comboBoxShowState; }
        }

        #endregion

        private void cmb_DropDown(object sender, EventArgs e)
        {
            comboBoxShowState = true;
        }

        private void cmb_DropDownClosed(object sender, EventArgs e)
        {
            comboBoxShowState = false;
        }

        private void tbUseCustomColumn_Click(object sender, EventArgs e)
        {
            tbUseCustomColumn.Checked = !tbUseCustomColumn.Checked;
            cmbGroupSumColumn.Enabled =!tbUseCustomColumn.Checked;
            cmbColumn.Enabled = !tbUseCustomColumn.Checked;
            txtGroupSumColumnName.Enabled = !tbUseCustomColumn.Checked;
            if (HaveBeenChanged != null)
                HaveBeenChanged(sender, e);
        }

        private void tbUseCustomRow_Click(object sender, EventArgs e)
        {
            tbUseCustomRow.Checked = !tbUseCustomRow.Checked;
            cmbGroupSumRow.Enabled = !tbUseCustomRow.Checked;
            txtGroupSumRowName.Enabled = !tbUseCustomRow.Checked;
        }

        private void txtColumnSql_Leave(object sender, EventArgs e)
        {
            if(tbUseCustomColumn.Checked)
                ParseSql("column");
        }

        private void txtRowSql_Leave(object sender, EventArgs e)
        {
            if(tbUseCustomRow.Checked)
                ParseSql("row");
        }

        private bool cbProtector = false;
        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProtector)
                return;
            cbProtector = true;
            if (cmbValue.SelectedItem != null && (cmbValue.SelectedItem as Objects.Column) != null)
            {
                if (!(cmbValue.SelectedItem as Objects.Column).IsNumber&&(sender as CheckBox).Checked)
                {
                    QuickReportCore.Managers.Functions.ShowToolTip(sender as Control, "�޷�Ϊ" + cmbValue.Text + "����ϼơ�", 3000);
                    (sender as CheckBox).Checked = false;
                }
            }
            cbProtector = false;
        }

        #region IHaveBeenChanged ��Ա

        public event QuickReportCore.Interfaces.HaveBeenChangedHandle HaveBeenChanged;

        #endregion

        private void cbGroupSumSomething_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked && cmbGroupSumRow.Text == string.Empty)
            {
                (sender as CheckBox).Checked = false;
                Managers.Functions.ShowToolTip(cmbGroupSumRow, "��ѡ���з�����С�");
            }
        }
    }
}