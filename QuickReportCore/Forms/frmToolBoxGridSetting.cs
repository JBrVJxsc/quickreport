using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore.Forms
{
    internal partial class frmToolBoxGridSetting : frmBaseToolBox, QuickReportCore.Interfaces.IConvertToXml, Interfaces.INeedRefreshDataSource, Interfaces.IHaveAToolStrip, Interfaces.IHaveAComboBox
    {
        public frmToolBoxGridSetting()
        {
            InitializeComponent();
        }

        #region IConvertToXml 成员

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.ViewSettingGridSetting.ToString());
            node.SetAttribute(XmlAttrDic.tGroupRow.ToString(), cmbRowGroupSum.Text);
            node.SetAttribute(XmlAttrDic.tRowGroupSumName.ToString(), txtRowGroupSumName.Text);
            node.SetAttribute(XmlAttrDic.bUseGroupSumRow.ToString(), Convert.ToInt32(cbUseGroupSumRow.Checked).ToString());
            node.SetAttribute(XmlAttrDic.bUseHeader.ToString(), Convert.ToInt32(cbUseHeader.Checked).ToString());
            node.SetAttribute(XmlAttrDic.bUnion.ToString(), Convert.ToInt32(cbUnion.Checked).ToString());
            return node;
        }

        public void ParseFromXml(System.Xml.XmlDocument xmlDocument)
        {
            System.Xml.XmlNode node = xmlDocument.SelectSingleNode("//" + XmlAttrDic.ViewSettingGridSetting.ToString());
            if (node != null)
            {
                cmbRowGroupSum.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tGroupRow.ToString(), string.Empty);
                txtRowGroupSumName.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tRowGroupSumName.ToString(), string.Empty);
                cbUseGroupSumRow.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.bUseGroupSumRow.ToString(), "0")));
                cbUseHeader.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.bUseHeader.ToString(), "0")));
                cbUnion.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.bUnion.ToString(), "0")));
            }
        }

        #endregion

        #region INeedRefreshDataSource 成员

        public void RefreshDataSource(Forms.frmToolBoxSystemValue.GobalValueType type)
        {
            if (type != frmToolBoxSystemValue.GobalValueType.Column)
                return;
            string row = cmbRowGroupSum.Text;
            cmbRowGroupSum.Items.Clear();
            for (int i = 0; i < QuickReportCore.Controls.ucColumnList.GobalColumnList.Count; i++)
            {
                cmbRowGroupSum.Items.Add(QuickReportCore.Controls.ucColumnList.GobalColumnList[i]);
            }
            cmbRowGroupSum.Items.Add(string.Empty);
            cmbRowGroupSum.Text = row;
        }

        #endregion

        #region IConvertToXml 成员

        public void ParseFromXml(System.Xml.XmlNodeList xmlNodeList)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        public enum XmlAttrDic
        {
            ViewSettingGridSetting,
            tGroupRow,
            tRowGroupSumName,
            bSumLocationHeader,
            bSumLocationColumn,
            bSumLocationNone,
            bUseGroupSumRow,
            bUseHeader,
            bUnion
        }

        #region INeedRefreshDataSource 成员


        public List<frmToolBoxSystemValue.GobalValueType> GobalValueTypesNeeded()
        {
            List<frmToolBoxSystemValue.GobalValueType> list = new List<frmToolBoxSystemValue.GobalValueType>();
            list.Add(frmToolBoxSystemValue.GobalValueType.Column);
            return list;
        }

        #endregion

        #region IHaveAToolStrip 成员

        public void SetToolStripFocus()
        {
            Focus();
        }

        #endregion

        #region IHaveAComboBox 成员

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

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked && cmbRowGroupSum.Text == string.Empty)
            {
                (sender as CheckBox).Checked = false;
                Managers.Functions.ShowToolTip(cmbRowGroupSum, "请选择行分组的列。");
            }
        }

        private void cmbRowGroupSum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRowGroupSum.Text == string.Empty)
                cbUseGroupSumRow.Checked = cbUseHeader.Checked =cbUnion.Checked = false;
        }
    }
}