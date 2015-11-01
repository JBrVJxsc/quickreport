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
    internal partial class ucConditionValueDate : ucChangedKnownBase, Interfaces.IConditionValue, Interfaces.IConvertToXml, Interfaces.ICheckInput
    {
        public ucConditionValueDate()
        {
            InitializeComponent();
            Init();
            InitOperators();
        }

        private Hashtable htSystemDataValue = new Hashtable();
        private DateTimePicker dtPicker = new DateTimePicker();

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

        #region IConditionValueUserControl 成员

        public event QuickReportCore.Interfaces.ClickButtonHandle ClickButton;

        public void InitValue(QuickReportCore.Objects.Condition condition)
        {
            if (condition.ConditionSetting == null)
                return;
            ParseFromXml(condition.ConditionSetting.SelectNodes(XmlAttrDic.ConditionValueDate.ToString()));
        }

        #endregion

        #region IConditionValueUserControl 成员


        public QuickReportCore.Objects.Condition.InputValueType InputValueType
        {
            get { return QuickReportCore.Objects.Condition.InputValueType.Date; }
        }

        #endregion

        private void Init()
        {
            foreach (DictionaryEntry de in QuickReportCore.Forms.frmToolBoxSystemValue.htSystemValueList)
            {
                PublicInterfaces.ISystemValue i = de.Value as PublicInterfaces.ISystemValue;
                if (i.SystemValueType == QuickReportCore.Objects.SystemValues.SystemValueType.Date)
                {
                    cmbSystemDataValue.Items.Add(i);
                    string valueID = Managers.Functions.GetSQLCode(i.ValueID, QuickReportCore.Managers.Functions.SQLCodeType.System);
                    if (!htSystemDataValue.Contains(valueID))
                        htSystemDataValue.Add(valueID, i.ValueName);
                }
            }
            if (cmbSystemDataValue.Items.Count > 0)
                cmbSystemDataValue.SelectedIndex = 0;
            cmbAddOrSub.Text = "+";
        }

        #region IConvertToXml 成员

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.ConditionValueDate.ToString());
            node.SetAttribute(XmlAttrDic.tFixedDateValue.ToString(), dateTimePicker.Value.ToShortDateString());
            node.SetAttribute(XmlAttrDic.bUseSystemValue.ToString(), Convert.ToInt32(cbSystemValue.Checked).ToString());
            if (cmbSystemDataValue.SelectedItem == null)
                node.SetAttribute(XmlAttrDic.tSystemDateValueType.ToString(), string.Empty);
            else
                node.SetAttribute(XmlAttrDic.tSystemDateValueType.ToString(), ((PublicInterfaces.ISystemValue)cmbSystemDataValue.SelectedItem).ValueID);
            node.SetAttribute(XmlAttrDic.tOperator.ToString(), cmbAddOrSub.Text);
            node.SetAttribute(XmlAttrDic.tDay.ToString(), txtDay.Text);
            node.SetAttribute(XmlAttrDic.tDefaultOperator.ToString(), cmbOperators.Text);
            node.SetAttribute(XmlAttrDic.bHideOperator.ToString(), Convert.ToInt32(cbHideOperator.Checked).ToString());
            return node;
        }

        public void ParseFromXml(System.Xml.XmlDocument xmlDocument)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        public enum XmlAttrDic
        {
            ConditionValueDate,
            bUseSystemValue,
            tFixedDateValue,
            tSystemDateValueType,
            tOperator,
            tDay,
            tDefaultOperator,
            bHideOperator
        }

        private void cbSystemValue_CheckedChanged(object sender, EventArgs e)
        {
            UseSystemValue(cbSystemValue.Checked);
        }

        private void UseSystemValue(bool b)
        {
            cmbSystemDataValue.Enabled = b;
            cmbAddOrSub.Enabled = b;
            txtDay.Enabled = b;
            dateTimePicker.Enabled = !b;
        }

        #region IConvertToXml 成员


        public void ParseFromXml(System.Xml.XmlNodeList xmlNodeList)
        {
            if (xmlNodeList == null || xmlNodeList.Count == 0)
                return;
            System.Xml.XmlNode node = xmlNodeList[0];
            if (node == null)
                return;
            dateTimePicker.Value = Convert.ToDateTime(Managers.Functions.GetNodeAttrValue( node,XmlAttrDic.tFixedDateValue.ToString(),System.DateTime.Now.ToShortDateString()));
            cbSystemValue.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue( node,XmlAttrDic.bUseSystemValue.ToString(),"0")));
            cmbSystemDataValue.Text = htSystemDataValue[Managers.Functions.GetSQLCode(Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tSystemDateValueType.ToString(), (cmbSystemDataValue.Items[0] as PublicInterfaces.ISystemValue).ValueID), QuickReportCore.Managers.Functions.SQLCodeType.System)].ToString();
            cmbAddOrSub.Text = Managers.Functions.GetNodeAttrValue( node,XmlAttrDic.tOperator.ToString(),cmbAddOrSub.Items[0].ToString());
            txtDay.Text = Managers.Functions.GetNodeAttrValue( node,XmlAttrDic.tDay.ToString(),"0");
            cmbOperators.Text =Managers.Functions.GetNodeAttrValue(  node,XmlAttrDic.tDefaultOperator.ToString(),cmbOperators.Items[0].ToString());
            cbHideOperator.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue( node,XmlAttrDic.bHideOperator.ToString(),"0")));

            if (!cbSystemValue.Checked)
                dtPicker.Value = dateTimePicker.Value;
            else
            {
                DateTime dtDefaultValue = Convert.ToDateTime(QuickReportCore.Managers.Functions.ConvertToSystemValue(Managers.Functions.GetNodeAttrValue( node,XmlAttrDic.tSystemDateValueType.ToString(),System.DateTime.Now.ToShortDateString())));
                if (cmbAddOrSub.Text == "+")
                    dtDefaultValue = dtDefaultValue.AddDays(Convert.ToDouble(txtDay.Text));
                else if (cmbAddOrSub.Text == "-")
                    dtDefaultValue = dtDefaultValue.AddDays(-Convert.ToDouble(txtDay.Text));
                dtPicker.Value = dtDefaultValue;
            }
            dtPicker.Size = dateTimePicker.Size;
        }
        #endregion

        #region IConditionValueUserControl 成员


        public Control EditControl
        {
            get
            {
                dtPicker.Width = 110;
                return dtPicker;
            }
        }

        public string EditControlValue
        {
            get { return dtPicker.Value.ToShortDateString(); }
        }

        #endregion

        #region IConditionValueUserControl 成员


        public QuickReportCore.Objects.Operator[] Operators
        {
            get
            {
                QuickReportCore.Objects.Operator o1 = new QuickReportCore.Objects.Operator("=", "等于");
                QuickReportCore.Objects.Operator o2 = new QuickReportCore.Objects.Operator(">", "大于");
                QuickReportCore.Objects.Operator o3 = new QuickReportCore.Objects.Operator(">=", "大于等于");
                QuickReportCore.Objects.Operator o4 = new QuickReportCore.Objects.Operator("<", "小于");
                QuickReportCore.Objects.Operator o5 = new QuickReportCore.Objects.Operator("<=", "小于等于");
                QuickReportCore.Objects.Operator o6 = new QuickReportCore.Objects.Operator("<>", "不等于");
                QuickReportCore.Objects.Operator[] operators = new QuickReportCore.Objects.Operator[] { o1, o2, o3, o4, o5, o6 };
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

        #region IConditionValueUserControl 成员


        public string DefaultOperator
        {
            get { return cmbOperators.Text; }
        }

        #endregion

        #region ICheckInput 成员


        public int CheckInput()
        {
            if (cbHideOperator.Checked && cmbOperators.Text == string.Empty)
            {
                Managers.Functions.ShowToolTip(cmbOperators, "如果隐藏操作符，则需要指定一个默认操作符。", 3000);
                return -1;
            }
            return 1;
        }

        #endregion

        #region IConditionValueUserControl 成员


        public bool HideOperator
        {
            get { return cbHideOperator.Checked; }
        }

        #endregion

        #region IConditionValueUserControl 成员


        public string EditControlSQLValue
        {
            get { return "TO_DATE('" + EditControlValue + "','yyyy-mm-dd') "; }
        }

        #endregion
    }
}
