using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;

namespace QuickReportCore.Controls
{
    internal partial class ucColumnList : UserControl, Interfaces.IConvertToXml,Interfaces.IHaveBeenChanged
    {
        public ucColumnList()
        {
            InitializeComponent();
        }

        private int topMargin = -8;
        private int leftMargin = 4;
        private int eatchMargin = 0;
        private FontConverter fc = new FontConverter();

        private Hashtable ucColumnObjectControls = new Hashtable();
        private ucColumnObject ucColumnObjectActivated;

        public static List<QuickReportCore.Objects.Column> GobalColumnList = new List<QuickReportCore.Objects.Column>();

        public int ShowColumns(List<QuickReportCore.Objects.Column> list)
        {
            pnlColumns.SuspendLayout();
            GobalColumnList = list;
            Hashtable newUcColumnControls = new Hashtable();
            int timer = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (!ucColumnObjectControls.Contains(list[i].ID))
                {
                    ucColumnObject uc = new ucColumnObject();
                    uc.ActivateOn += new ucColumnObject.ActivateHandle(uc_ActivateOn);
                    uc.Column = list[i];
                    uc.Column.SortId = timer;
                    timer++;
                    ucColumnObjectControls.Add(list[i].ID, uc);
                    newUcColumnControls.Add(list[i].ID, uc);
                }
                else
                {
                    if (!newUcColumnControls.Contains(list[i].ID))
                    {
                        Objects.Column tempColumn = (ucColumnObjectControls[list[i].ID] as ucColumnObject).Column.Clone();
                        tempColumn.Name = list[i].Name;
                        tempColumn.SortId = timer;
                        (ucColumnObjectControls[list[i].ID] as ucColumnObject).Column = tempColumn;
                        timer++;
                        newUcColumnControls.Add(list[i].ID, ucColumnObjectControls[list[i].ID]);
                    }
                }
            }
            ucColumnObjectControls = newUcColumnControls;
            pnlColumns.Controls.Clear();
            foreach (DictionaryEntry de in ucColumnObjectControls)
            {
                pnlColumns.Controls.Add(de.Value as Control);
                int i = (de.Value as ucColumnObject).Column.SortId;
                if (i == 0)
                    (de.Value as ucColumnObject).Location = new Point(leftMargin, topMargin);
                else
                    (de.Value as ucColumnObject).Location = new Point(leftMargin, topMargin + (ucColumnObjectControls[list[i].ID] as ucColumnObject).Height * i + eatchMargin * i);
            }
            pnlColumns.ResumeLayout();
            return 1;
        }

        void uc_ActivateOn(ucColumnObject uc)
        {
            if (ucColumnObjectActivated == null)
            {
                ucColumnObjectActivated = uc;
                return;
            }
            else
                if (ucColumnObjectActivated != uc)
                {
                    ucColumnObjectActivated.Activate = false;
                    ucColumnObjectActivated = uc;
                }
        }

        public void MoveObject(MoveOrder order)
        {
            if (ucColumnObjectActivated == null)
                return;
            Objects.Column tempColumn = ucColumnObjectActivated.Column.Clone();
            Point tempLocation = ucColumnObjectActivated.Location;
            ucColumnObject tempUc = null;
            if (order == MoveOrder.Up)
            {
                if (ucColumnObjectActivated.Column.SortId == 0)
                    return;
                tempUc = FindUcByColumnSortID(ucColumnObjectActivated.Column.SortId - 1);
                ucColumnObjectActivated.Location = tempUc.Location;
                tempUc.Location = tempLocation;
                ucColumnObjectActivated.Column.SortId -= 1;
                tempUc.Column.SortId += 1;
            }
            else if (order == MoveOrder.Down)
            {
                if (ucColumnObjectActivated.Column.SortId == ucColumnObjectControls.Count - 1)
                    return;
                tempUc = FindUcByColumnSortID(ucColumnObjectActivated.Column.SortId + 1);
                ucColumnObjectActivated.Location = tempUc.Location;
                tempUc.Location = tempLocation;
                ucColumnObjectActivated.Column.SortId += 1;
                tempUc.Column.SortId -= 1;
            }
            if (tempUc == null)
                return;
            pnlColumns.ScrollControlIntoView(ucColumnObjectActivated);
            if (HaveBeenChanged != null)
                HaveBeenChanged(this, null);
        }

        /// <summary>
        /// 根据序列ID获取控件。
        /// </summary>
        /// <param name="id">序列ID。</param>
        /// <returns>ucColumnObject控件。</returns>
        private ucColumnObject FindUcByColumnSortID(int id)
        {
            foreach (DictionaryEntry de in ucColumnObjectControls)
            {
                if ((de.Value as ucColumnObject).Column.SortId == id)
                    return de.Value as ucColumnObject;
            }
            return null;
        }

        public enum MoveOrder
        {
            /// <summary>
            /// 向上。
            /// </summary>
            Up,
            /// <summary>
            /// 向下。
            /// </summary>
            Down
        }

        #region IConvertToXml 成员

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.ColumnObjectList.ToString());
            foreach (DictionaryEntry de in ucColumnObjectControls)
            {
                node.AppendChild((de.Value as ucColumnObject).ConvertToXml());
            }
            return node;
        }

        public enum XmlAttrDic
        {
            ColumnObjectList
        }

        #endregion

        #region IConvertToXml 成员


        public void ParseFromXml(XmlDocument xmlDocument)
        {
            GobalColumnList = new List<QuickReportCore.Objects.Column>();
            System.Xml.XmlNodeList nodeList = xmlDocument.SelectNodes("//" +ucColumnObject.XmlAttrDic.ColumnObject.ToString());
            Objects.Column[] columns = new QuickReportCore.Objects.Column[nodeList.Count];
            foreach (System.Xml.XmlNode node in nodeList)
            {
                Objects.Column column = new QuickReportCore.Objects.Column();
                column.ID = Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.tID.ToString(),string.Empty);
                column.Name = Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.tName.ToString(),string.Empty);
                column.Filter = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node,ucColumnObject.XmlAttrDic.bFilter.ToString(),"0")));
                column.Use = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.bUse.ToString(), "0")));
                column.Sort = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.bSort.ToString(), "0")));
                column.TotalColumn = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.bTotalColumn.ToString(), "0")));
                column.TotalRow = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.bTotalRow.ToString(), "0")));
                column.SortId = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node,ucColumnObject.XmlAttrDic.tSortID.ToString(),"0"));
                column.IsNumber = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.bIsNumber.ToString(), "0")));
                column.DecimalPlace = Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node,ucColumnObject.XmlAttrDic.tDecimalPlace.ToString(),"0"));
                column.Font=fc.ConvertFromInvariantString(Managers.Functions.GetNodeAttrValue(node,ucColumnObject.XmlAttrDic.tFont.ToString(),string.Empty)) as Font;
                column.Color = System.Drawing.ColorTranslator.FromHtml(Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.tColor.ToString(), string.Empty));
                column.HAligment =(FarPoint.Win.Spread.CellHorizontalAlignment)Enum.Parse(typeof(FarPoint.Win.Spread.CellHorizontalAlignment), Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.tHAligment.ToString(), FarPoint.Win.Spread.CellHorizontalAlignment.General.ToString()));
                column.VAligment = (FarPoint.Win.Spread.CellVerticalAlignment)Enum.Parse(typeof(FarPoint.Win.Spread.CellVerticalAlignment), Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.tVAligment.ToString(), FarPoint.Win.Spread.CellVerticalAlignment.General.ToString()));
                column.Union = Convert.ToBoolean(Convert.ToInt32(Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.bUnion.ToString(), "0")));
                column.ValueTransType = (QuickReportCore.Class.NumberCellTypePlus.ValueTranslateType)Enum.Parse(typeof(QuickReportCore.Class.NumberCellTypePlus.ValueTranslateType), Managers.Functions.GetNodeAttrValue(node, ucColumnObject.XmlAttrDic.tValueTranslateType.ToString(), QuickReportCore.Class.NumberCellTypePlus.ValueTranslateType.不转换.ToString()));
                columns[column.SortId] = column.Clone();
                GobalColumnList.Add(column.Clone());
            }
            ucColumnObjectControls = new Hashtable();
            for (int i = 0; i < columns.Length; i++)
            {
                if (!ucColumnObjectControls.Contains(columns[i].ID))
                {
                    ucColumnObject uc = new ucColumnObject();
                    uc.ActivateOn += new ucColumnObject.ActivateHandle(uc_ActivateOn);
                    uc.Column = columns[i];
                    ucColumnObjectControls.Add(columns[i].ID, uc);
                }
            }
            pnlColumns.Controls.Clear();
            foreach (DictionaryEntry de in ucColumnObjectControls)
            {
                pnlColumns.Controls.Add(de.Value as Control);
                int i = (de.Value as ucColumnObject).Column.SortId;
                if (i == 0)
                    (de.Value as ucColumnObject).Location = new Point(leftMargin, topMargin);
                else
                    (de.Value as ucColumnObject).Location = new Point(leftMargin, topMargin + (ucColumnObjectControls[columns[i].ID] as ucColumnObject).Height * i + eatchMargin * i);
            }
        }

        #endregion

        #region IConvertToXml 成员


        public void ParseFromXml(System.Xml.XmlNodeList xmlNodeList)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IHaveBeenChanged 成员

        public event QuickReportCore.Interfaces.HaveBeenChangedHandle HaveBeenChanged;

        #endregion
    }
}
