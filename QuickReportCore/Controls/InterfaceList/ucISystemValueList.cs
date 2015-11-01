using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore.Controls.InterfaceList
{
    internal partial class ucISystemValueList : UserControl, Interfaces.IInterfaceList,Interfaces.IHaveBeenChanged
    {
        public ucISystemValueList()
        {
            InitializeComponent();
        }

        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
        private FarPoint.Win.Spread.CellType.HyperLinkCellType hyperLinkCellType = new FarPoint.Win.Spread.CellType.HyperLinkCellType();

        #region IInterfaceList 成员

        public Type ParentInterface
        {
            get { return typeof(PublicInterfaces.ISystemValue); }
        }

        #endregion

        #region IConvertToXml 成员

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.ISystemValueList.ToString());
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
            System.Xml.XmlNode node = xmlDocument.SelectSingleNode("//" + XmlAttrDic.ISystemValueList.ToString());
            System.Xml.XmlNodeList nodeList = node.SelectNodes(XmlAttrDic.ISystemValueObject.ToString());
            fpInterfaces_Sheet1.Rows.Count = nodeList.Count;
            for (int i = 0; i < nodeList.Count; i++)
            {
                SetHyperLinkCellTypeCellText(fpInterfaces_Sheet1.Cells[i, 0], Managers.Functions.GetNodeAttrValue(nodeList[i], XmlAttrDic.tDllName.ToString(), string.Empty));
                fpInterfaces_Sheet1.Cells[i, 1].Value = Managers.Functions.GetNodeAttrValue(nodeList[i], XmlAttrDic.tClassName.ToString(), string.Empty);
            }
            AddValueToToolBoxWhenLoad();
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
            if (dllName == string.Empty || className == string.Empty)
                return null;
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.ISystemValueObject.ToString());
            node.SetAttribute(XmlAttrDic.tInterfaceName.ToString(), interfaceName);
            node.SetAttribute(XmlAttrDic.tDllName.ToString(), dllName);
            node.SetAttribute(XmlAttrDic.tClassName.ToString(), className);
            return node;
        }

        private void SetHyperLinkCellTypeCellText(FarPoint.Win.Spread.Cell cell, string text)
        {
            hyperLinkCellType = new FarPoint.Win.Spread.CellType.HyperLinkCellType();
            hyperLinkCellType.Link = " ";
            hyperLinkCellType.Text = text;
            cell.CellType = hyperLinkCellType.Clone() as FarPoint.Win.Spread.CellType.HyperLinkCellType;
        }

        /// <summary>
        /// 刚刚初始化以后，将界面上的系统变量添加到工具箱。
        /// </summary>
        private void AddValueToToolBoxWhenLoad()
        {
            List<PublicInterfaces.ISystemValue> list = GetSystemValueFromFp();
            if (list.Count == 0)
                return;
            foreach (PublicInterfaces.ISystemValue i in list)
            {
                Forms.frmToolBoxSystemValue.AddSystemValueToStaticSystemValueList(i);
            }
            Forms.frmToolBoxSystemValue.SystemValueListHasBeenChanged = true;
        }

        private List<PublicInterfaces.ISystemValue> GetSystemValueFromFp()
        {
            List<PublicInterfaces.ISystemValue> list = new List<QuickReportCore.PublicInterfaces.ISystemValue>();
            for (int i = 0; i < fpInterfaces_Sheet1.Rows.Count; i++)
            {
                string dllName = (fpInterfaces_Sheet1.Cells[i, 0].CellType as FarPoint.Win.Spread.CellType.HyperLinkCellType).Text;
                string className = fpInterfaces_Sheet1.Cells[i, 1].Text;
                if (dllName == string.Empty || className == string.Empty)
                    continue;
                PublicInterfaces.ISystemValue iSystemValue = Managers.Functions.CreateInstance(dllName, className) as PublicInterfaces.ISystemValue;
                if (iSystemValue == null)
                    continue;
                fpInterfaces_Sheet1.Rows[i].Tag = iSystemValue;
                list.Add(iSystemValue);
            }
            return list;
        }

        private PublicInterfaces.ISystemValue GetSystemValueFromFp(int i)
        {
            string dllName = (fpInterfaces_Sheet1.Cells[i, 0].CellType as FarPoint.Win.Spread.CellType.HyperLinkCellType).Text;
            string className = fpInterfaces_Sheet1.Cells[i, 1].Text;
            if (dllName == string.Empty || className == string.Empty)
                return null;
            PublicInterfaces.ISystemValue iSystemValue = Managers.Functions.CreateInstance(dllName, className) as PublicInterfaces.ISystemValue;
            fpInterfaces_Sheet1.Rows[i].Tag = iSystemValue;
            return iSystemValue;
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
                PublicInterfaces.ISystemValue iSystemValue = fpInterfaces_Sheet1.Rows[fpInterfaces_Sheet1.ActiveRowIndex].Tag as PublicInterfaces.ISystemValue;
                string valueID = string.Empty;
                if (iSystemValue != null)
                    valueID = iSystemValue.ValueID;
                fpInterfaces_Sheet1.Rows.Remove(fpInterfaces_Sheet1.ActiveCell.Row.Index, 1);
                if (valueID == string.Empty)
                    return;
                bool needRefresh=true;
                for (int i = 0; i < fpInterfaces_Sheet1.Rows.Count; i++)
                {
                    PublicInterfaces.ISystemValue tempI = fpInterfaces_Sheet1.Rows[i].Tag as PublicInterfaces.ISystemValue;
                    if (tempI == null)
                        continue;
                    if (tempI.ValueID == iSystemValue.ValueID)
                    {
                        needRefresh = false;
                        break;
                    }
                }
                if (needRefresh)
                {
                    Forms.frmToolBoxSystemValue.DeleteSystemValueFromStaticSystemValueList(iSystemValue);
                    Forms.frmToolBoxSystemValue.SystemValueListHasBeenChanged = true;
                }
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
            ISystemValueList,
            ISystemValueObject,
            tInterfaceName,
            tDllName,
            tClassName
        }

        private void fpInterfaces_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 1)
            {
                PublicInterfaces.ISystemValue iSystemValue = GetSystemValueFromFp(e.Row);
                if (iSystemValue != null)
                {
                    Forms.frmToolBoxSystemValue.AddSystemValueToStaticSystemValueList(iSystemValue);
                    Forms.frmToolBoxSystemValue.SystemValueListHasBeenChanged = true;
                }
            }
            if (HaveBeenChanged != null)
                HaveBeenChanged(sender, null);
        }

        #region IHaveBeenChanged 成员

        public event QuickReportCore.Interfaces.HaveBeenChangedHandle HaveBeenChanged;

        #endregion

        private void InitChangedEvent()
        {
            fpInterfaces.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(fpInterfaces_EditChange);
            foreach (ToolStripItem t in toolStrip.Items)
            {
                t.Click += new EventHandler(t_Click);
            }
        }

        void t_Click(object sender, EventArgs e)
        {
            if (HaveBeenChanged != null)
                HaveBeenChanged(sender, e);
        }


        private void ucISystemValueList_Load(object sender, EventArgs e)
        {
            InitChangedEvent();
        }
    }
}
