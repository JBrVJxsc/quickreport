using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace QuickReportCore.Controls
{
    internal partial class ucReportDetailConditionSource : UserControl, Interfaces.IConvertToXml
    {
        public ucReportDetailConditionSource()
        {
            InitializeComponent();
        }

        private FarPoint.Win.Spread.CellType.ComboBoxCellType cellTypeTreeConditions = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
        private FarPoint.Win.Spread.CellType.ComboBoxCellType cellTypeReportConditions = new FarPoint.Win.Spread.CellType.ComboBoxCellType();

        private void tbConditionSourceAdd_Click(object sender, EventArgs e)
        {
            fpConditionSource_Sheet1.RowCount++;
        }

        public void RefreshConditionList()
        {
            cellTypeTreeConditions.Items = NewestTreeConditionList();
            cellTypeReportConditions.Items = NewestReportConditionList();
            Refresh();
        }

        private void tbConditionSourceDelete_Click(object sender, EventArgs e)
        {
            if (fpConditionSource_Sheet1.ActiveCell == null)
                return;
            if (fpConditionSource_Sheet1.RowCount > 0)
            {
                fpConditionSource_Sheet1.Rows.Remove(fpConditionSource_Sheet1.ActiveCell.Row.Index, 1);
            }
        }

        private string[] NewestReportConditionList()
        {
            string[] strs=new string[ucColumnList.GobalColumnList.Count];
            for (int i = 0; i < ucColumnList.GobalColumnList.Count; i++)
            {
                strs[i] = ucColumnList.GobalColumnList[i].Name;
            }
            return strs;
        }

        private string[] NewestTreeConditionList()
        {
            string[] strs = new string[Forms.frmQuickReportEditor.GobalTreeColumnList.Count];
            for (int i = 0; i < Forms.frmQuickReportEditor.GobalTreeColumnList.Count; i++)
            {
                strs[i] = Forms.frmQuickReportEditor.GobalTreeColumnList[i].Name;
            }
            return strs;
        }

        private void fpConditionSource_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if(e.Column==1)
                return;
            if (fpConditionSource_Sheet1.ActiveCell.Text == "树")
                fpConditionSource_Sheet1.Cells[e.Row, 1].CellType = cellTypeTreeConditions;
            else if (fpConditionSource_Sheet1.ActiveCell.Text == "报表")
                fpConditionSource_Sheet1.Cells[e.Row, 1].CellType = cellTypeReportConditions;
            else
                fpConditionSource_Sheet1.Cells[e.Row, 1].CellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
        }

        private System.Xml.XmlElement RowToXml(int rowIndex)
        {
            string source = fpConditionSource_Sheet1.Cells[rowIndex, 0].Text;
            string name=fpConditionSource_Sheet1.Cells[rowIndex,1].Text;
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.ConditionSourceObject.ToString());
            node.SetAttribute(XmlAttrDic.tConditionSource.ToString(), source);
            node.SetAttribute(XmlAttrDic.tCondtionName.ToString(), name);
            return node;
        }

        #region IConvertToXml 成员

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.ConditionSourceObjectList.ToString());
            for (int i = 0; i < fpConditionSource_Sheet1.Rows.Count; i++)
            {
                node.AppendChild(RowToXml(i));
            }
            return node;
        }

        public enum XmlAttrDic
        {
            ConditionSourceObjectList,
            ConditionSourceObject,
            tConditionSource,
            tCondtionName
        }
        #endregion

        #region IConvertToXml 成员


        public void ParseFromXml(XmlDocument xmlDocument)
        {
            System.Xml.XmlNodeList nodeList = xmlDocument.SelectNodes("//" + XmlAttrDic.ConditionSourceObject.ToString());
            fpConditionSource_Sheet1.RowCount = nodeList.Count;
            for (int i = 0; i < nodeList.Count; i++)
            {
                fpConditionSource_Sheet1.Cells[i, 0].Value = Managers.Functions.GetNodeAttrValue(nodeList[i], XmlAttrDic.tConditionSource.ToString(), string.Empty);
                fpConditionSource_Sheet1.Cells[i, 1].Value = Managers.Functions.GetNodeAttrValue(nodeList[i], XmlAttrDic.tCondtionName.ToString(), string.Empty);
            }
        }

        #endregion

        #region IConvertToXml 成员


        public void ParseFromXml(XmlNodeList xmlNodeList)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
