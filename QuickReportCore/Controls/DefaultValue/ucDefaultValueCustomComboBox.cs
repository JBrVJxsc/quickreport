using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QuickReport.Controls.DefaultValue
{
    public partial class ucDefaultValueCustomComboBox : UserControl,Interfaces.IDefaultValueUserControl,Interfaces.IConvertToXml
    {
        QuickReport.Managers.QuickReportManager qr = new QuickReport.Managers.QuickReportManager();

        public ucDefaultValueCustomComboBox()
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

        private void comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ClickButton != null)
                ClickButton(ConvertToXml());
            }
        }

        #region IDefaultValueUserControl 成员


        public QuickReport.Objects.Condition.ConditionInputType ConditionInputType
        {
            get { return QuickReport.Objects.Condition.ConditionInputType.CustomComboBox; }
        }

        #endregion

        #region IDefaultValueUserControl 成员


        public void InitValue(QuickReport.Objects.Condition condition)
        {
            comboBox.Items.Clear();
            int i = qr.ExecQuery(condition.ConditionType.Content);
            if (i < 0)
                return;
            try
            {
                while (qr.Reader.Read())
                {
                    Objects.Condition c = new QuickReport.Objects.Condition();
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
            if (condition.DefaultValue == null)
                return;
            ParseFromXml(condition.DefaultValue.SelectNodes(XmlAttrDic.DefaultValueCustomComboBox.ToString()));
        }

        #endregion

        #region IConvertToXml 成员

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.DefaultValueCustomComboBox.ToString());
            node.SetAttribute(XmlAttrDic.tValue.ToString(), comboBox.Text);
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
            comboBox.Text = node.Attributes[XmlAttrDic.tValue.ToString()].Value;
        }

        #endregion

        public enum XmlAttrDic
        {
            DefaultValueCustomComboBox,
            tValue
        }

        #region IDefaultValueUserControl 成员


        public Control EditControl
        {
            get { return comboBox; }
        }

        public string EditControlValue
        {
            get { return comboBox.Text; }
        }

        #endregion
    }
}
