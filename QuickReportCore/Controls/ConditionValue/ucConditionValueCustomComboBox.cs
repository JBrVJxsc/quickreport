using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore.Controls.ConditionValue
{
    internal partial class ucConditionValueCustomComboBox : ucChangedKnownBase, Interfaces.IConditionValue, Interfaces.IConvertToXml, Interfaces.ICheckInput
    {
        QuickReportCore.Managers.QuickReportManager qr = new QuickReportCore.Managers.QuickReportManager();

        public ucConditionValueCustomComboBox()
        {
            InitializeComponent();
            InitOperators();
        }

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

        #endregion

        #region IConditionValueUserControl 成员


        public QuickReportCore.Objects.Condition.InputValueType InputValueType
        {
            get { return QuickReportCore.Objects.Condition.InputValueType.CustomComboBox; }
        }

        #endregion

        #region IConditionValueUserControl 成员


        public void InitValue(QuickReportCore.Objects.Condition condition)
        {
            comboBox.Items.Clear();
            System.Xml.XmlElement node = condition.ConditionType.Content;
            if (node == null)
                return;
            bool useSql = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node,Forms.frmToolBoxConditionTypeEditor.XmlAttrDic.bUseSql.ToString(),"0"))); 
            bool useCustomElement = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node,Forms.frmToolBoxConditionTypeEditor.XmlAttrDic.bUseCustomElement.ToString(),"0")));
            bool useAll = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, Forms.frmToolBoxConditionTypeEditor.XmlAttrDic.bUseAll.ToString(), "0")));
            string sql = Managers.Functions.GetNodeAttrValue(node,Forms.frmToolBoxConditionTypeEditor.XmlAttrDic.tSql.ToString(),string.Empty);
            if (useSql)
            {
                sql = Managers.Functions.TranslateTextWithSystemValue(sql);
                int i = qr.ExecQuery(sql);
                if (i < 0)
                    return;
                try
                {
                    while (qr.Reader.Read())
                    {
                        Objects.Condition c = new QuickReportCore.Objects.Condition();
                        c.ID = qr.Reader[0].ToString();
                        c.Name = qr.Reader[1].ToString();
                        comboBox.Items.Add(c);
                    }
                }
                catch
                {
                    return;
                }
                finally
                {
                    qr.Reader.Close();
                }
                if (condition.ConditionSetting == null)
                    return;
            }
            else if (useCustomElement)
            {
                System.Xml.XmlNodeList nodeList = node.SelectSingleNode(ucConditionTypeElementListWithFarpoint.XmlAttrDic.ConditionTypeElementList.ToString()).SelectNodes(ucConditionTypeElementListWithFarpoint.XmlAttrDic.ConditionTypeElement.ToString());
                if (nodeList != null && nodeList.Count > 0)
                {
                    for (int i = 0; i < nodeList.Count; i++)
                    {
                        Objects.Condition c = new QuickReportCore.Objects.Condition();
                        c.ID =Managers.Functions.GetNodeAttrValue( nodeList[i],ucConditionTypeElementListWithFarpoint.XmlAttrDic.tCode.ToString(),string.Empty);
                        c.Name =Managers.Functions.GetNodeAttrValue( nodeList[i],ucConditionTypeElementListWithFarpoint.XmlAttrDic.tName.ToString(),string.Empty);
                        comboBox.Items.Add(c);
                    }
                }
            }
            if(useAll)
                comboBox.Items.Add(new Objects.Condition("ALL","全部"));
            if (condition.ConditionSetting == null)
                return;
            ParseFromXml(condition.ConditionSetting.SelectNodes(XmlAttrDic.ConditionValueCustomComboBox.ToString()));
        }

        #endregion

        #region IConvertToXml 成员

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.ConditionValueCustomComboBox.ToString());
            node.SetAttribute(XmlAttrDic.tValue.ToString(), comboBox.Text);
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
            System.Xml.XmlNode node = xmlNodeList[0];
            if (node == null)
                return;
            comboBox.Text = Managers.Functions.GetNodeAttrValue(node,XmlAttrDic.tValue.ToString(),string.Empty);
            cmbOperators.Text = Managers.Functions.GetNodeAttrValue(node,XmlAttrDic.tDefaultOperator.ToString(),string.Empty);
            cbHideOperator.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node,XmlAttrDic.bHideOperator.ToString(),"0")));
        }

        #endregion

        public enum XmlAttrDic
        {
            ConditionValueCustomComboBox,
            tValue,
            tDefaultOperator,
            bHideOperator
        }

        #region IConditionValueUserControl 成员


        public Control EditControl
        {
            get
            {
                comboBox.Width = 90;
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                return comboBox; 
            }
        }

        public string EditControlValue
        {
            get { return comboBox.Text; }
        }

        #endregion

        #region IConditionValueUserControl 成员


        public QuickReportCore.Objects.Operator[] Operators
        {
            get
            {
                QuickReportCore.Objects.Operator o1 = new QuickReportCore.Objects.Operator("=", "等于");
                QuickReportCore.Objects.Operator o2 = new QuickReportCore.Objects.Operator("<>", "不等于");
                QuickReportCore.Objects.Operator[] operators = new QuickReportCore.Objects.Operator[] { o1,o2 };
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
            get { return "'" + ((Objects.Condition)comboBox.SelectedItem).ID + "'"; }
        }

        #endregion
    }
}
