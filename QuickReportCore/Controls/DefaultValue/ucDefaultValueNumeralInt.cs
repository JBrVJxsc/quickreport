using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QuickReport.Controls.DefaultValue
{
    public partial class ucDefaultValueNumeralInt : UserControl, Interfaces.IDefaultValueUserControl,Interfaces.IConvertToXml
    {
        public ucDefaultValueNumeralInt()
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

        #region IDefaultValueUserControl 成员

        public event QuickReport.Interfaces.ClickButtonHandle ClickButton;

        #endregion

        private void ucNumeralText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
                ClickButton(ConvertToXml());
        }

        #region IDefaultValueUserControl 成员


        public QuickReport.Objects.Condition.ConditionInputType ConditionInputType
        {
            get { return QuickReport.Objects.Condition.ConditionInputType.NumeralInt; }
        }

        #endregion

        #region IDefaultValueUserControl 成员


        public void InitValue(QuickReport.Objects.Condition condition)
        {
            if (condition.DefaultValue == null)
                return;
            ParseFromXml(condition.DefaultValue.SelectNodes(XmlAttrDic.DefaultValueNumeralInt.ToString()));
        }

        #endregion

        #region IConvertToXml 成员

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.DefaultValueNumeralInt.ToString());
            node.SetAttribute(XmlAttrDic.tValue.ToString(), ucNumeralText.Text);
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
            ucNumeralText.Text = node.Attributes[XmlAttrDic.tValue.ToString()].Value;
        }

        #endregion

        public enum XmlAttrDic
        {
            DefaultValueNumeralInt,
            tValue
        }

        #region IDefaultValueUserControl 成员


        public Control EditControl
        {
            get { return ucNumeralText; }
        }

        public string EditControlValue
        {
            get { return ucNumeralText.Text; }
        }

        #endregion
    }
}
