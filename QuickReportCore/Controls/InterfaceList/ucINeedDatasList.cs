using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore.Controls.InterfaceList
{
    internal partial class ucINeedDatasList : UserControl, Interfaces.IInterfaceList,Interfaces.IHaveBeenChanged
    {
        public ucINeedDatasList()
        {
            InitializeComponent();
        }

        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
        private FarPoint.Win.Spread.CellType.HyperLinkCellType hyperLinkCellType = new FarPoint.Win.Spread.CellType.HyperLinkCellType();

        #region IInterfaceList 成员

        public Type ParentInterface
        {
            get { return typeof(PublicInterfaces.INeedDatas); }
        }

        #endregion

        #region IConvertToXml 成员

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.INeedDatasList.ToString());
            for (int i = 0; i < fpInterfaces_Sheet1.Rows.Count; i++)
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
            System.Xml.XmlNode node = xmlDocument.SelectSingleNode("//" + XmlAttrDic.INeedDatasList.ToString());
            System.Xml.XmlNodeList nodeList = node.SelectNodes(XmlAttrDic.INeedDatasObject.ToString());
            fpInterfaces_Sheet1.Rows.Count = nodeList.Count;
            for (int i = 0; i < nodeList.Count; i++)
            {
                int rowIndex =Convert.ToInt32( Managers.Functions.GetNodeAttrValue(nodeList[i], XmlAttrDic.tSortID.ToString(), "0"));
                SetHyperLinkCellTypeCellText(fpInterfaces_Sheet1.Cells[rowIndex, 0], Managers.Functions.GetNodeAttrValue(nodeList[i], XmlAttrDic.tDllName.ToString(), string.Empty));
                fpInterfaces_Sheet1.Cells[rowIndex, 1].Value = Managers.Functions.GetNodeAttrValue(nodeList[i], XmlAttrDic.tClassName.ToString(), string.Empty);
                fpInterfaces_Sheet1.Cells[rowIndex, 2].Value = Managers.Functions.GetNodeAttrValue(nodeList[i], XmlAttrDic.tValues.ToString(), string.Empty);
            }
        }

        public void ParseFromXml(System.Xml.XmlNodeList xmlNodeList)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        private System.Xml.XmlElement RowToXml(int rowIndex)
        {
            string interfaceName = ParentInterface.Name;
            string dllName = (fpInterfaces_Sheet1.Cells[rowIndex, 0].CellType as FarPoint.Win.Spread.CellType.HyperLinkCellType).Text;
            string className = fpInterfaces_Sheet1.Cells[rowIndex, 1].Text;
            string values = fpInterfaces_Sheet1.Cells[rowIndex, 2].Text;
            if (dllName == string.Empty || className == string.Empty)
                return null;
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.INeedDatasObject.ToString());
            node.SetAttribute(XmlAttrDic.tInterfaceName.ToString(), interfaceName);
            node.SetAttribute(XmlAttrDic.tDllName.ToString(), dllName);
            node.SetAttribute(XmlAttrDic.tClassName.ToString(), className);
            node.SetAttribute(XmlAttrDic.tValues.ToString(), values);
            node.SetAttribute(XmlAttrDic.tSortID.ToString(), rowIndex.ToString());
            return node;
        }

        private void SetHyperLinkCellTypeCellText(FarPoint.Win.Spread.Cell cell, string text)
        {
            hyperLinkCellType = new FarPoint.Win.Spread.CellType.HyperLinkCellType();
            hyperLinkCellType.Link = " ";
            hyperLinkCellType.Text = text;
            cell.CellType = hyperLinkCellType.Clone() as FarPoint.Win.Spread.CellType.HyperLinkCellType;
        }

        private void tbAdd_Click(object sender, EventArgs e)
        {
            fpInterfaces_Sheet1.Rows.Count++;
            SetHyperLinkCellTypeCellText(fpInterfaces_Sheet1.Cells[fpInterfaces_Sheet1.Rows.Count - 1, 0], "单击选择文件");
        }

        private void tbDelete_Click(object sender, EventArgs e)
        {
            if (fpInterfaces_Sheet1.ActiveCell == null)
                return;
            if (fpInterfaces_Sheet1.RowCount > 0)
            {
                fpInterfaces_Sheet1.Rows.Remove(fpInterfaces_Sheet1.ActiveCell.Row.Index, 1);
            }
        }

        private void fpInterfaces_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            DialogResult dr = openFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string dllName = openFileDialog.SafeFileName;
                List<Type> typeList = null;
                typeList = Managers.Functions.GetTypes(dllName, ParentInterface);
                if (typeList == null || typeList.Count == 0)
                    return;
                SetHyperLinkCellTypeCellText(fpInterfaces_Sheet1.Cells[e.Row, e.Column], dllName);
                string[] types = new string[typeList.Count];
                for (int i = 0; i < typeList.Count; i++)
                {
                    types[i] = typeList[i].FullName;
                }
                comboBoxCellType.Items = types;
                fpInterfaces_Sheet1.Cells[e.Row, 1].CellType = comboBoxCellType.Clone() as FarPoint.Win.Spread.CellType.ComboBoxCellType;
                fpInterfaces_Sheet1.Cells[e.Row, 1].Locked = false;
            }
        }

        private void fpInterfaces_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
            {
                e.Cancel = true;
                return;
            }
        }

        private void fpInterfaces_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
            {
                e.Cancel = true;
                return;
            }
        }

        public enum XmlAttrDic
        { 
            INeedDatasList,
            INeedDatasObject,
            tInterfaceName,
            tDllName,
            tClassName,
            tValues,
            tSortID
        }

        private void InitChangedEvent()
        {
            fpInterfaces.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(fpInterfaces_EditChange);
            foreach (ToolStripItem t in toolStrip.Items)
            {
                t.Click += new EventHandler(t_Click);
            }
        }

        void fpInterfaces_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (HaveBeenChanged != null)
                HaveBeenChanged(sender, null);
        }

        void t_Click(object sender, EventArgs e)
        {
            if (HaveBeenChanged != null)
                HaveBeenChanged(sender, e);
        }

        #region IHaveBeenChanged 成员

        public event QuickReportCore.Interfaces.HaveBeenChangedHandle HaveBeenChanged;

        #endregion

        private void ucINeedDatasList_Load(object sender, EventArgs e)
        {
            InitChangedEvent();
        }
    }
}
