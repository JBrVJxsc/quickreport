using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore.Controls.ConditionValue
{
    internal partial class ucConditionValueNumeralDecimal : ucChangedKnownBase, Interfaces.IConditionValue, Interfaces.IConvertToXml, Interfaces.ICheckInput
    {
        public ucConditionValueNumeralDecimal()
        {
            InitializeComponent();
            InitOperators();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (CheckInput() < 0)
                return;
            if(ClickButton!=null)
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
            get { return QuickReportCore.Objects.Condition.InputValueType.NumeralDecimal; }
        }

        #endregion

        #region IConditionValueUserControl ��Ա


        public void InitValue(QuickReportCore.Objects.Condition condition)
        {
            if (condition.ConditionSetting == null)
                return;
            ParseFromXml(condition.ConditionSetting.SelectNodes(XmlAttrDic.ConditionValueNumeralDecimal.ToString()));
            InitOperators();
        }

        #endregion

        #region IConvertToXml ��Ա

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.ConditionValueNumeralDecimal.ToString());
            node.SetAttribute(XmlAttrDic.tValue.ToString(), ucNumeralText.Text);
            node.SetAttribute(XmlAttrDic.tDefaultOperator.ToString(), cmbOperators.Text);
            node.SetAttribute(XmlAttrDic.bHideOperator.ToString(), Convert.ToInt32(cbHideOperator.Checked).ToString());
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
            ucNumeralText.Text =Managers.Functions.GetNodeAttrValue( node,XmlAttrDic.tValue.ToString(),"0");
            cmbOperators.Text = Managers.Functions.GetNodeAttrValue( node,XmlAttrDic.tDefaultOperator.ToString(),"����");
            cbHideOperator.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue( node,XmlAttrDic.bHideOperator.ToString(),"0")));
        }

        public enum XmlAttrDic
        {
            ConditionValueNumeralDecimal,
            tValue,
            tDefaultOperator,
            bHideOperator
        }

        #endregion

        #region IConditionValueUserControl ��Ա


        public Control EditControl
        {
            get {
                ucNumeralText.Width = 90;
                return ucNumeralText; }
        }

        public string EditControlValue
        {
            get { return ucNumeralText.Text; }
        }

        #endregion

        #region IConditionValueUserControl ��Ա


        public QuickReportCore.Objects.Operator[] Operators
        {
            get
            {
                QuickReportCore.Objects.Operator o1 = new QuickReportCore.Objects.Operator("=", "����");
                QuickReportCore.Objects.Operator o2 = new QuickReportCore.Objects.Operator(">", "����");
                QuickReportCore.Objects.Operator o3 = new QuickReportCore.Objects.Operator(">=", "���ڵ���");
                QuickReportCore.Objects.Operator o4 = new QuickReportCore.Objects.Operator("<", "С��");
                QuickReportCore.Objects.Operator o5 = new QuickReportCore.Objects.Operator("<=", "С�ڵ���");
                QuickReportCore.Objects.Operator o6 = new QuickReportCore.Objects.Operator("<>", "������");
                QuickReportCore.Objects.Operator[] operators = new QuickReportCore.Objects.Operator[] { o1, o2, o3, o4, o5,o6 };
                return operators;
            }
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

        #region IConditionValueUserControl ��Ա


        public string DefaultOperator
        {
            get { return cmbOperators.Text; }
        }

        #endregion

        #region ICheckInput ��Ա


        public int CheckInput()
        {
            if (cbHideOperator.Checked && cmbOperators.Text == string.Empty)
            {
                Managers.Functions.ShowToolTip(cmbOperators, "������ز�����������Ҫָ��һ��Ĭ�ϲ�������", 3000);
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
            get { return "'"+EditControlValue+"'"; }//��Ȼ�����֣��������ּ���������SQL�в�ѯ���޴󰭡�
        }

        #endregion
    }
}
