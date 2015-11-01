using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace QuickReportCore.Controls.ConditionValue
{
    internal partial class ucConditionValueText : ucChangedKnownBase, Interfaces.IConditionValue, Interfaces.IConvertToXml, Interfaces.ICheckInput
    {
        public ucConditionValueText()
        {
            InitializeComponent();
            InitOperators();
            InitSelectorActionType();
        }

        private TextBoxWithSelector textBoxWithSelector = new TextBoxWithSelector();

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (CheckInput() < 0)
                return;
            if (ClickButton != null)
                ClickButton(ConvertToXml());
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (ClickButton != null)
                ClickButton(null);
        }

        #region IConditionValueUserControl ��Ա

        public event QuickReportCore.Interfaces.ClickButtonHandle ClickButton;

        #endregion

        #region IConditionValueUserControl ��Ա


        public QuickReportCore.Objects.Condition.InputValueType InputValueType
        {
            get { return QuickReportCore.Objects.Condition.InputValueType.Text; }
        }

        #endregion

        #region IConditionValueUserControl ��Ա


        public void InitValue(QuickReportCore.Objects.Condition condition)
        {
            if (condition.ConditionSetting == null)
                return;
            ParseFromXml(condition.ConditionSetting.SelectNodes(XmlAttrDic.ConditionValueText.ToString()));
        }

        #endregion

        #region IConvertToXml ��Ա

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.ConditionValueText.ToString());
            node.SetAttribute(XmlAttrDic.tValue.ToString(), txtDefaultValue.Text);
            node.SetAttribute(XmlAttrDic.tDefaultOperator.ToString(), cmbOperators.Text);
            node.SetAttribute(XmlAttrDic.bHideOperator.ToString(), Convert.ToInt32(cbHideOperator.Checked).ToString());
            node.SetAttribute(XmlAttrDic.bLeftPadZero.ToString(), Convert.ToInt32(cbLeftZero.Checked).ToString());
            node.SetAttribute(XmlAttrDic.tLeftPadZeroPlace.ToString(), numLeftZero.Value.ToString());
            node.SetAttribute(XmlAttrDic.bUseSelector.ToString(), Convert.ToInt32(tbUseSelector.Checked).ToString());
            node.SetAttribute(XmlAttrDic.tSelectorSql.ToString(), txtSelectorSql.Text);
            node.SetAttribute(XmlAttrDic.tSelectorOutColumn.ToString(), cmbOutColumn.Text);
            node.SetAttribute(XmlAttrDic.tSelectorAction.ToString(), cmbSelectorActionType.Text);
            node.SetAttribute(XmlAttrDic.tSelectorTitle.ToString(), txtSelectorTitle.Text);
            node.SetAttribute(XmlAttrDic.tSelectorNullMessage.ToString(), txtSelectorNullMessage.Text);
            node.SetAttribute(XmlAttrDic.bHideSelectorOutColumn.ToString(), Convert.ToInt32(cbHideSelectorOutColumn.Checked).ToString());
            node.SetAttribute(XmlAttrDic.bQueryAfterEnter.ToString(), Convert.ToInt32(cbQueryAfterEnter.Checked).ToString());
            return node;
        }

        public void ParseFromXml(System.Xml.XmlDocument xmlDocument)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void ParseFromXml(System.Xml.XmlNodeList xmlNodeList)
        {
            if (xmlNodeList == null || xmlNodeList.Count == 0)
                return;
            System.Xml.XmlNode node = xmlNodeList[0];
            if (node == null)
                return;
            if (FindForm()!=null && FindForm().GetType() == typeof(Forms.frmConditionSetting))
            {
                txtDefaultValue.Text = Managers.Functions.GetNodeAttrValue(node,XmlAttrDic.tValue.ToString(),string.Empty);
            }
            else
            {
                txtDefaultValue.Text = Managers.Functions.TranslateTextWithSystemValue(Managers.Functions.GetNodeAttrValue(node,XmlAttrDic.tValue.ToString(),string.Empty));
            }
            cmbOperators.Text = Managers.Functions.GetNodeAttrValue(node,XmlAttrDic.tDefaultOperator.ToString(),"����");
            cbHideOperator.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.bHideOperator.ToString(), "0")));
            cbLeftZero.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.bLeftPadZero.ToString(), "0")));
            numLeftZero.Value =Convert.ToDecimal( Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tLeftPadZeroPlace.ToString(), "12"));
            tbUseSelector.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.bUseSelector.ToString(), "0")));
            txtSelectorSql.Text= Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tSelectorSql.ToString(), string.Empty);
            if (txtSelectorSql.Text.Trim() != string.Empty)
                ParseSql();
            cmbOutColumn.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tSelectorOutColumn.ToString(), string.Empty);
            cmbSelectorActionType.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tSelectorAction.ToString(), string.Empty);
            txtSelectorTitle.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tSelectorTitle.ToString(), "��ѡ��һ����¼��");
            txtSelectorNullMessage.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tSelectorNullMessage.ToString(), "δ���ҵ���Ч��¼��");
            cbHideSelectorOutColumn.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.bHideSelectorOutColumn.ToString(), "1")));
            cbQueryAfterEnter.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.bQueryAfterEnter.ToString(), "1")));
        }

        #endregion

        public enum XmlAttrDic
        {
            ConditionValueText,
            tValue,
            tDefaultOperator,
            bHideOperator,
            bLeftPadZero,
            tLeftPadZeroPlace,
            bUseSelector,
            tSelectorSql,
            tSelectorOutColumn,
            tSelectorAction,
            tSelectorTitle,
            tSelectorNullMessage,
            bHideSelectorOutColumn,
            bQueryAfterEnter
        }

        #region IConditionValueUserControl ��Ա


        public Control EditControl
        {
            get
            {
                textBoxWithSelector.Text = txtDefaultValue.Text;
                textBoxWithSelector.UseSelector = tbUseSelector.Checked;
                textBoxWithSelector.UsePadLeftZero = cbLeftZero.Checked;
                textBoxWithSelector.LeftPadZeroPlace = Convert.ToInt32(numLeftZero.Value);
                textBoxWithSelector.Width = 110;
                textBoxWithSelector.SQL = txtSelectorSql.Text;
                textBoxWithSelector.OutColumn = cmbOutColumn.Text;
                textBoxWithSelector.ActionType = (SelectorActionType)Enum.Parse(typeof(SelectorActionType), cmbSelectorActionType.Text);
                textBoxWithSelector.Title = txtSelectorTitle.Text;
                textBoxWithSelector.NullMessage = txtSelectorNullMessage.Text;
                textBoxWithSelector.HideOutColumn = cbHideSelectorOutColumn.Checked;
                return textBoxWithSelector;
            }
        }

        public string EditControlValue
        {
            get 
            {
                if (tbUseSelector.Checked)
                {
                    if(textBoxWithSelector.Translating)//����Ƿ���״̬�� �򷵻��Լ���ʵ¼������ݣ����򷵻ز�ѯ�����
                        return textBoxWithSelector.Text; 
                    return textBoxWithSelector.OutValue;
                }
                return textBoxWithSelector.Text; 
            }
        }

        #endregion

        #region IConditionValueUserControl ��Ա


        public QuickReportCore.Objects.Operator[] Operators
        {
            get
            {
                QuickReportCore.Objects.Operator o1 = new QuickReportCore.Objects.Operator("=", "����");
                QuickReportCore.Objects.Operator o2 = new QuickReportCore.Objects.Operator("LIKE", "����");
                QuickReportCore.Objects.Operator o3 = new QuickReportCore.Objects.Operator("<>", "������");
                QuickReportCore.Objects.Operator[] operators = new QuickReportCore.Objects.Operator[] { o1, o2, o3 };
                return operators;
            }
        }

        #endregion

        #region IConditionValueUserControl ��Ա


        public string DefaultOperator
        {
            get { return cmbOperators.Text; }
        }

        #endregion

        private void InitOperators()
        {
            QuickReportCore.Objects.Operator[] os = Operators;
            cmbOperators.Items.Clear();
            for (int i = 0; i < os.Length; i++)
            {
                cmbOperators.Items.Add(os[i]);
            }
            cmbOperators.SelectedIndex = 0;
        }

        private void InitSelectorActionType()
        {
            cmbSelectorActionType.Items.Clear();
            cmbSelectorActionType.Items.Add(SelectorActionType.��ѯ.ToString());
            cmbSelectorActionType.Items.Add(SelectorActionType.��.ToString());
            cmbSelectorActionType.SelectedIndex = 0;
        }

        private void ParseSql()
        {
            string sql = txtSelectorSql.Text;
            #region ȥ��Tree������
            sql = sql.Replace(Managers.Functions.GetSQLCode(Forms.frmToolBoxSystemValue.TreeValueType.�ڵ����.ToString(), QuickReportCore.Managers.Functions.SQLCodeType.Tree), string.Empty);
            sql = sql.Replace(Managers.Functions.GetSQLCode(Forms.frmToolBoxSystemValue.TreeValueType.�ڵ�����.ToString(), QuickReportCore.Managers.Functions.SQLCodeType.Tree), string.Empty);
            #endregion
            #region ȥ��Column������
            for (int i = 0; i < ucColumnList.GobalColumnList.Count; i++)
            {
                sql = sql.Replace(Managers.Functions.GetSQLCode(ucColumnList.GobalColumnList[i].ID, QuickReportCore.Managers.Functions.SQLCodeType.Column), string.Empty);
            }
            #endregion
            #region ȥ��Condition������
            for (int i = 0; i < ucConditionList.GobalConditionList.Count; i++)
            {
                sql = sql.Replace(Managers.Functions.GetSQLCode(ucConditionList.GobalConditionList[i].ID, QuickReportCore.Managers.Functions.SQLCodeType.Condition), string.Empty);
            }
            #endregion
            ArrayList list = QuickReportCore.Managers.Functions.ParseSql(sql);
            if (list == null || list[0] == null || list[1] == null)
            {
                QuickReportCore.Managers.Functions.ShowToolTip(txtSelectorSql, "SQL����ʽ�������޸ġ�", txtSelectorSql.Location);
                txtSelectorSql.SelectAll();
                return;
            }
            else
            {
                List<QuickReportCore.Objects.Column> columnList = list[0] as List<QuickReportCore.Objects.Column>;
                string column = cmbOutColumn.Text;
                cmbOutColumn.Items.Clear();
                for (int i = 0; i < columnList.Count; i++)
                {
                    cmbOutColumn.Items.Add(columnList[i]);
                }
                cmbOutColumn.Text = column;
            }
        }

        #region ICheckInput ��Ա


        public int CheckInput()
        {
            if (cbHideOperator.Checked && cmbOperators.Text == string.Empty)
            {
                Managers.Functions.ShowToolTip(cmbOperators, "������ز�����������Ҫָ��һ��Ĭ�ϲ�������", 3000);
                return -1;
            }
            if (tbUseSelector.Checked && cmbOutColumn.Text == string.Empty)
            {
                tabControlSelector.SelectedIndex = 1;
                Managers.Functions.ShowToolTip(cmbOutColumn, "���ʹ��ѡ�������Ҫָ��һ������С�", 3000);
                return -1;
            }
            return 1;
        }

        #endregion

        #region IConditionValueUserControl ��Ա


        public bool HideOperator
        {
            get { return cbHideOperator.Checked; }
        }

        #endregion


        #region IConditionValueUserControl ��Ա


        public string EditControlSQLValue
        {
            get { return " '" + EditControlValue + "' "; }
        }

        #endregion

        private void cbLeftZero_CheckedChanged(object sender, EventArgs e)
        {
            numLeftZero.Enabled = cbLeftZero.Checked;
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
                ((TextBox)sender).SelectAll();
        }

        private void tbUseSelector_Click(object sender, EventArgs e)
        {
            tbUseSelector.Checked = !tbUseSelector.Checked;
        }

        private void txtSelectorSql_Leave(object sender, EventArgs e)
        {
            ParseSql();
        }

        public enum SelectorActionType
        { 
            /// <summary>
            /// ѡ������̲�ѯ��
            /// </summary>
            ��ѯ,
            /// <summary>
            /// �ޡ�
            /// </summary>
            ��
        }
    }
}
