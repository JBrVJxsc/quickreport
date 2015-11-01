using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QuickReport.Controls.DefaultValue
{
    public partial class ucDefaultValueText : UserControl, Interfaces.IDefaultValueUserControl, Interfaces.IConvertToXml
    {
        public ucDefaultValueText()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (ClickButton != null)
                ClickButton(ConvertToXml());
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (ClickButton != null)
                ClickButton(null);
        }

        #region IDefaultValueUserControl ��Ա

        public event QuickReport.Interfaces.ClickButtonHandle ClickButton;

        #endregion

        private void txtDefaultValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ClickButton(ConvertToXml());
        }

        #region IDefaultValueUserControl ��Ա


        public QuickReport.Objects.Condition.ConditionInputType ConditionInputType
        {
            get { return QuickReport.Objects.Condition.ConditionInputType.Text; }
        }

        #endregion

        #region IDefaultValueUserControl ��Ա


        public void InitValue(QuickReport.Objects.Condition condition)
        {
            if (condition.DefaultValue == null)
                return;
            ParseFromXml(condition.DefaultValue.SelectNodes(XmlAttrDic.DefaultValueText.ToString()));
        }

        #endregion

        #region IConvertToXml ��Ա

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.DefaultValueText.ToString());
            node.SetAttribute(XmlAttrDic.tValue.ToString(), txtDefaultValue.Text);
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
            txtDefaultValue.Text = node.Attributes[XmlAttrDic.tValue.ToString()].Value;
        }

        #endregion

        public enum XmlAttrDic
        {
            DefaultValueText,
            tValue
        }

        #region IDefaultValueUserControl ��Ա


        public Control EditControl
        {
            get { return txtDefaultValue; }
        }

        public string EditControlValue
        {
            get { return txtDefaultValue.Text; }
        }

        #endregion
    }
}
