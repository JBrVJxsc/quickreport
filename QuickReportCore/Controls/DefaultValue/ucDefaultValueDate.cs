using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace QuickReport.Controls.DefaultValue
{
    public partial class ucDefaultValueDate : UserControl, Interfaces.IDefaultValueUserControl, Interfaces.IConvertToXml
    {
        public ucDefaultValueDate()
        {
            InitializeComponent();
            Init();
        }

        private Hashtable htSystemDataValue = new Hashtable();
        private DateTimePicker dtPicker = new DateTimePicker();

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

        public void InitValue(QuickReport.Objects.Condition condition)
        {
            if (condition.DefaultValue == null)
                return;
            ParseFromXml(condition.DefaultValue.SelectNodes(XmlAttrDic.DefaultValueDate.ToString()));
        }

        #endregion

        #region IDefaultValueUserControl 成员


        public QuickReport.Objects.Condition.ConditionInputType ConditionInputType
        {
            get { return QuickReport.Objects.Condition.ConditionInputType.Date; }
        }

        #endregion

        private void Init()
        {
            foreach (Interfaces.ISystemValue i in QuickReport.Forms.frmToolBoxSystemValue.SystemValueList)
            {
                if (i.ConditionInputType == ConditionInputType)
                {
                    cmbSystemDataValue.Items.Add(i);
                    if (!htSystemDataValue.Contains(i.ValueID))
                        htSystemDataValue.Add(i.ValueID, i.ValueName);
                }
            }
        }

        #region IConvertToXml 成员

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.DefaultValueDate.ToString());
            node.SetAttribute(XmlAttrDic.tFixedDateValue.ToString(), dateTimePicker.Value.ToShortDateString());
            node.SetAttribute(XmlAttrDic.bUseSystemValue.ToString(), Convert.ToInt32(cbSystemValue.Checked).ToString());
            node.SetAttribute(XmlAttrDic.tSystemDateValueType.ToString(), ((Interfaces.ISystemValue)cmbSystemDataValue.SelectedItem).ValueID);
            node.SetAttribute(XmlAttrDic.tOperator.ToString(), cmbAddOrSub.Text);
            node.SetAttribute(XmlAttrDic.tDay.ToString(), txtDay.Text);
            return node;
        }

        public void ParseFromXml(System.Xml.XmlDocument xmlDocument)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        public enum XmlAttrDic
        {
            DefaultValueDate,
            bUseSystemValue,
            tFixedDateValue,
            tSystemDateValueType,
            tOperator,
            tDay
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
            dateTimePicker.Value = Convert.ToDateTime(node.Attributes[XmlAttrDic.tFixedDateValue.ToString()].Value);
            cbSystemValue.Checked = Convert.ToBoolean(Convert.ToInt32(node.Attributes[XmlAttrDic.bUseSystemValue.ToString()].Value));
            cmbSystemDataValue.Text = htSystemDataValue[node.Attributes[XmlAttrDic.tSystemDateValueType.ToString()].Value].ToString();
            cmbAddOrSub.Text = node.Attributes[XmlAttrDic.tOperator.ToString()].Value;
            txtDay.Text = node.Attributes[XmlAttrDic.tDay.ToString()].Value;

            DateTime dtDefaultValue = Convert.ToDateTime(QuickReport.Managers.Functions.ConvertToSystemValue(node.Attributes[XmlAttrDic.tSystemDateValueType.ToString()].Value));
            if (cmbAddOrSub.Text == "+")
                dtDefaultValue = dtDefaultValue.AddDays(Convert.ToDouble(txtDay.Text));
            else if (cmbAddOrSub.Text == "-")
                dtDefaultValue = dtDefaultValue.AddDays(-Convert.ToDouble(txtDay.Text));
            dtPicker.Value = dtDefaultValue;
            dtPicker.Size = dateTimePicker.Size;
        }
        #endregion

        #region IDefaultValueUserControl 成员


        public Control EditControl
        {
            get { return dtPicker; }
        }

        public string EditControlValue
        {
            get { return dtPicker.Value.ToString(); }
        }

        #endregion
    }
}
