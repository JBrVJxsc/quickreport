using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace QuickReportCore.Forms
{
    internal partial class frmToolBoxConditionTypeEditor : frmBaseToolBox, Interfaces.IHaveAToolStrip, Interfaces.IConvertToXml,Interfaces.IHaveBeenChanged
    {
        public frmToolBoxConditionTypeEditor()
        {
            InitializeComponent();
        }

        private bool useSql = false;
        private bool useCustomElement = false;

        private Objects.ConditionType conditionType = new QuickReportCore.Objects.ConditionType();
        public Objects.ConditionType ConditionType
        {
            get
            {
                return conditionType;
            }
            set
            {
                conditionType = value;
                if (conditionType.Content != null)
                    ParseFromXml(conditionType.Content);
                else
                    Clear();
            }
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            if (useSql)
            {
                ArrayList list = QuickReportCore.Managers.Functions.ParseSql(txtSql.Text);
                if (list == null || list[0] == null || list[1] == null)
                {
                    QuickReportCore.Managers.Functions.ShowToolTip(txtSql, "SQL语句格式有误，请修改。",txtSql.Location);
                    txtSql.SelectAll();
                    return;
                }
            }
            ConditionType.Content = ConvertToXml();
            Hide();
        }

        public void SelectText()
        {
            txtSql.Focus();
            txtSql.Select();
        }

        #region IHaveAToolStrip 成员

        public void SetToolStripFocus()
        {
            Focus();
        }

        #endregion

        private void txtSql_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
                txtSql.SelectAll();
        }

        public enum XmlAttrDic
        {
            ConditionTypeContent,
            bUseSql,
            bUseCustomElement,
            tSql,
            bUseAll
        }

        #region IConvertToXml 成员

        public System.Xml.XmlElement ConvertToXml()
        {
            if (tabControl.SelectedIndex == 0)
            {
                useCustomElement = true;
                useSql = false;
            }
            if (tabControl.SelectedIndex == 1)
            {
                useSql = true;
                useCustomElement = false;
            }
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.ConditionTypeContent.ToString());
            node.SetAttribute(XmlAttrDic.bUseSql.ToString(), Convert.ToInt32(useSql).ToString());
            node.SetAttribute(XmlAttrDic.bUseCustomElement.ToString(), Convert.ToInt32(useCustomElement).ToString());
            node.SetAttribute(XmlAttrDic.tSql.ToString(), txtSql.Text);
            node.AppendChild(ucConditionTypeElementListWithFarpoint.ConvertToXml());
            node.SetAttribute(XmlAttrDic.bUseAll.ToString(), Convert.ToInt32(tbUseAll.Checked).ToString());
            return node;
        }

        public void ParseFromXml(System.Xml.XmlDocument xmlDocument)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void ParseFromXml(System.Xml.XmlNodeList xmlNodeList)
        {

        }

        public void ParseFromXml(System.Xml.XmlElement xmlElement)
        {
            System.Xml.XmlElement node = xmlElement;
            bool useSql = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node,Forms.frmToolBoxConditionTypeEditor.XmlAttrDic.bUseSql.ToString(),"0")));
            bool useCustomElement = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node,Forms.frmToolBoxConditionTypeEditor.XmlAttrDic.bUseCustomElement.ToString(),"0")));
            tbUseAll.Checked = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, Forms.frmToolBoxConditionTypeEditor.XmlAttrDic.bUseAll.ToString(), "0")));
            if (useSql)
            {
                tabControl.SelectedIndex = 1;
            }
            else if (useCustomElement)
            {
                tabControl.SelectedIndex = 0;
            }
            string sql = Managers.Functions.GetNodeAttrValue(node, Forms.frmToolBoxConditionTypeEditor.XmlAttrDic.tSql.ToString(), string.Empty);
            txtSql.Text = sql;
            System.Xml.XmlNodeList nodeList = node.SelectSingleNode(QuickReportCore.Controls.ucConditionTypeElementListWithFarpoint.XmlAttrDic.ConditionTypeElementList.ToString()).SelectNodes(QuickReportCore.Controls.ucConditionTypeElementListWithFarpoint.XmlAttrDic.ConditionTypeElement.ToString());
            ucConditionTypeElementListWithFarpoint.ParseFromXml(nodeList);
        }

        #endregion

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                useCustomElement = true;
                useSql = false;
            }
            else
                if (tabControl.SelectedIndex == 1)
                {
                    useCustomElement = false;
                    useSql = true;
                    txtSql.Focus();
                }
        }

        private void Clear()
        {
            ucConditionTypeElementListWithFarpoint.Clear();
            txtSql.Text = string.Empty;
            tabControl.SelectedIndex = 0;
        }

        private void tbUseAll_Click(object sender, EventArgs e)
        {
            tbUseAll.Checked = !tbUseAll.Checked;
            if (HaveBeenChanged != null)
                HaveBeenChanged(sender, e);
        }

        #region IHaveBeenChanged 成员

        public event QuickReportCore.Interfaces.HaveBeenChangedHandle HaveBeenChanged;

        #endregion

        private void frmToolBoxConditionTypeEditor_Load(object sender, EventArgs e)
        {
            InitChangedEvent();
        }

        private void InitChangedEvent()
        {
            ucConditionTypeElementListWithFarpoint.HaveBeenChanged += new QuickReportCore.Interfaces.HaveBeenChangedHandle(ucConditionTypeElementListWithFarpoint_HaveBeenChanged);
        }

        void ucConditionTypeElementListWithFarpoint_HaveBeenChanged(object sender, EventArgs e)
        {
            if (HaveBeenChanged != null)
                HaveBeenChanged(sender, e);
        }

        private void txtSql_TextChanged(object sender, EventArgs e)
        {
            if (HaveBeenChanged != null)
                HaveBeenChanged(sender, e);
        }
    }
}