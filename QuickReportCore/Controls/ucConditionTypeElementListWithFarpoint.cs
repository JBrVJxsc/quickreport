using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore.Controls
{
    internal partial class ucConditionTypeElementListWithFarpoint : UserControl, Interfaces.IConvertToXml,Interfaces.IHaveBeenChanged
    {
        public ucConditionTypeElementListWithFarpoint()
        {
            InitializeComponent();
        }

        private void tbAdd_Click(object sender, EventArgs e)
        {
            fpConditionTypeElement_Sheet1.RowCount++;
        }

        private void tbDelete_Click(object sender, EventArgs e)
        {
            if (fpConditionTypeElement_Sheet1.ActiveCell == null)
                return;
            if (fpConditionTypeElement_Sheet1.RowCount > 0)
            {
                fpConditionTypeElement_Sheet1.Rows.Remove(fpConditionTypeElement_Sheet1.ActiveCell.Row.Index, 1);
            }
        }

        private System.Xml.XmlElement RowToXml(int rowIndex)
        {
            string code = fpConditionTypeElement_Sheet1.Cells[rowIndex, 0].Text;
            string name = fpConditionTypeElement_Sheet1.Cells[rowIndex, 1].Text;
            if (code.Trim() == string.Empty || name.Trim() == string.Empty)
                return null;
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.ConditionTypeElement.ToString());
            node.SetAttribute(XmlAttrDic.tCode.ToString(), code);
            node.SetAttribute(XmlAttrDic.tName.ToString(), name);
            return node;
        }

        #region IConvertToXml 成员

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.ConditionTypeElementList.ToString());
            for (int i = 0; i < fpConditionTypeElement_Sheet1.Rows.Count; i++)
            {
                System.Xml.XmlElement n = RowToXml(i);
                if (n == null)
                    continue;
                node.AppendChild(n);
            }
            return node;
        }

        public void ParseFromXml(System.Xml.XmlDocument xmlDocument)
        {
      
        }

        public void ParseFromXml(System.Xml.XmlNodeList xmlNodeList)
        {
            System.Xml.XmlNodeList nodeList = xmlNodeList;
            fpConditionTypeElement_Sheet1.RowCount = nodeList.Count;
            for (int i = 0; i < nodeList.Count; i++)
            {
                fpConditionTypeElement_Sheet1.Cells[i, 0].Value = Managers.Functions.GetNodeAttrValue(nodeList[i], XmlAttrDic.tCode.ToString(), string.Empty);
                fpConditionTypeElement_Sheet1.Cells[i, 1].Value = Managers.Functions.GetNodeAttrValue(nodeList[i], XmlAttrDic.tName.ToString(), string.Empty);
            }
        }

        #endregion

        public enum XmlAttrDic
        {
            ConditionTypeElementList,
            ConditionTypeElement,
            tCode,
            tName
        }

        public void Clear()
        {
            fpConditionTypeElement_Sheet1.RowCount = 0;
        }

        #region IHaveBeenChanged 成员

        public event QuickReportCore.Interfaces.HaveBeenChangedHandle HaveBeenChanged;

        #endregion

        private void ucConditionTypeElementListWithFarpoint_Load(object sender, EventArgs e)
        {
            InitChangedEvent();
        }

        private void InitChangedEvent()
        {
            fpConditionTypeElement.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(fpConditionTypeElement_EditChange);
            foreach (ToolStripItem t in toolStrip.Items)
            {
                t.Click += new EventHandler(t_Click);
            }
        }

        void fpConditionTypeElement_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (HaveBeenChanged != null)
                HaveBeenChanged(sender, null);
        }

        void t_Click(object sender, EventArgs e)
        {
            if (HaveBeenChanged != null)
                HaveBeenChanged(sender, e);
        }
    }
}
