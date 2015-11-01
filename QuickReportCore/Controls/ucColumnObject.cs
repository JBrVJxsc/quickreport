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
    internal partial class ucColumnObject : UserControl, Interfaces.IConvertToXml
    {
        public ucColumnObject()
        {
            InitializeComponent();
            SetUse(true);
        }

        private Size useSize = new Size(555, 55);
        private FontDialog fd = new FontDialog();
        private ColorDialog cd = new ColorDialog(); 
        private FontConverter fc = new FontConverter();

        private QuickReportCore.Objects.Column column = new QuickReportCore.Objects.Column();
        /// <summary>
        /// 列实体。
        /// </summary>
        public QuickReportCore.Objects.Column Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
                txtColumnName.Text = column.Name;
                cbUse.Checked = column.Use;
                cbTotalCountColumn.Checked = column.TotalColumn;
                cbTotalCountRow.Checked = column.TotalRow;
                cbSort.Checked = column.Sort;
                cbFilter.Checked = column.Filter;
                numericUpDown.Value = column.DecimalPlace;
                UnionToolStripMenuItem.Checked = column.Union;
                switch (column.HAligment)
                {
                    case FarPoint.Win.Spread.CellHorizontalAlignment.General:
                        {
                            UnCheckHAligment();
                            HAligmentGeneralToolStripMenuItem.Checked = true;
                            break;
                        }
                    case FarPoint.Win.Spread.CellHorizontalAlignment.Center:
                        {
                            UnCheckHAligment();
                            HAligmentCenterToolStripMenuItem.Checked = true;
                            break;
                        }
                    case FarPoint.Win.Spread.CellHorizontalAlignment.Right:
                        {
                            UnCheckHAligment();
                            HAligmentRightToolStripMenuItem.Checked = true;
                            break;
                        }
                    case FarPoint.Win.Spread.CellHorizontalAlignment.Left:
                        {
                            UnCheckHAligment();
                            HAligmentLeftToolStripMenuItem.Checked = true;
                            break;
                        }
                }
                switch (column.VAligment)
                {
                    case FarPoint.Win.Spread.CellVerticalAlignment.General:
                        {
                            UnCheckVAligment();
                            VAligmentGeneralToolStripMenuItem.Checked = true;
                            break;
                        }
                    case FarPoint.Win.Spread.CellVerticalAlignment.Center:
                        {
                            UnCheckVAligment();
                            VAligmentCenterToolStripMenuItem.Checked = true;
                            break;
                        }
                    case FarPoint.Win.Spread.CellVerticalAlignment.Bottom:
                        {
                            UnCheckVAligment();
                            VAligmentBottomToolStripMenuItem.Checked = true;
                            break;
                        }
                    case FarPoint.Win.Spread.CellVerticalAlignment.Top:
                        {
                            UnCheckVAligment();
                            VAligmentTopToolStripMenuItem.Checked = true;
                            break;
                        }
                }
                switch (column.ValueTransType)
                {
                    case QuickReportCore.Class.NumberCellTypePlus.ValueTranslateType.不转换:
                        {
                            UnCheckValueTrans();
                            ValueTransDefaultToolStripMenuItem.Checked = true;
                            break;
                        }
                    case QuickReportCore.Class.NumberCellTypePlus.ValueTranslateType.值为空时转换为零:
                        {
                            UnCheckValueTrans();
                            ValueTransBeZeroWhenNullToolStripMenuItem.Checked = true;
                            break;
                        }
                    case QuickReportCore.Class.NumberCellTypePlus.ValueTranslateType.值为零时转换为空:
                        {
                            UnCheckValueTrans();
                            ValueTransBeNullWhenZeroToolStripMenuItem.Checked = true;
                            break;
                        }
                }
                if (column.IsNumber)
                {
                    cbTotalCountColumn.Enabled = true;
                    cbTotalCountRow.Enabled = true;
                    numericUpDown.Enabled = true;
                    lbNumberPlace.ForeColor = Color.Black;
                    ValueTransTypeToolStripMenuItem.Visible = true;
                }
                else
                {
                    cbTotalCountColumn.Checked = false;
                    cbTotalCountColumn.Enabled = false;
                    cbTotalCountRow.Checked = false;
                    cbTotalCountRow.Enabled = false;
                    numericUpDown.Enabled = false;
                    lbNumberPlace.ForeColor = Color.Gray;
                    ValueTransTypeToolStripMenuItem.Visible = false;
                }
            }
        }

        private void UnCheckHAligment()
        {
            HAligmentCenterToolStripMenuItem.Checked = false;
            HAligmentGeneralToolStripMenuItem.Checked = false;
            HAligmentLeftToolStripMenuItem.Checked = false;
            HAligmentRightToolStripMenuItem.Checked = false;
        }

        private void UnCheckVAligment()
        {
            VAligmentCenterToolStripMenuItem.Checked = false;
            VAligmentGeneralToolStripMenuItem.Checked = false;
            VAligmentTopToolStripMenuItem.Checked = false;
            VAligmentBottomToolStripMenuItem.Checked = false;
        }

        private bool activate = false;
        /// <summary>
        /// 是否处于激活状态。
        /// </summary>
        public bool Activate
        {
            get
            {
                return activate;
            }
            set
            {
                activate = value;
                if (activate)
                {
                    pnlColumnObject.BackColor = ucConditionObject.ObjectActivateColor;
                    if(!numericUpDown.Focused)
                        txtColumnName.Focus();
                    if (ActivateOn != null)
                        ActivateOn(this);
                }
                else
                    pnlColumnObject.BackColor = SystemColors.Control;
            }
        }

        public delegate void ActivateHandle(ucColumnObject uc);
        public event ActivateHandle ActivateOn;

        #region 事件
        private void cbHide_CheckedChanged(object sender, EventArgs e)
        {
            column.Use = cbUse.Checked;
            SetUse(column.Use);
        }

        private void SetUse(bool b)
        {
            if (b)
                Size = useSize;
            else
                Size = new Size(cbUse.Location.X + cbUse.Width + 5, Height);
        }

        private void cbTotalCount_CheckedChanged(object sender, EventArgs e)
        {
            column.TotalColumn = cbTotalCountColumn.Checked;
        }

        private void cbSort_CheckedChanged(object sender, EventArgs e)
        {
            column.Sort = cbSort.Checked;
        }

        private void cbFilter_CheckedChanged(object sender, EventArgs e)
        {
            column.Filter = cbFilter.Checked;
        }

        private void txtColumnName_TextChanged(object sender, EventArgs e)
        {
            column.Name = txtColumnName.Text;
        }

        private void ucColumnObject_Load(object sender, EventArgs e)
        {
            foreach (Control c in pnlColumnObject.Controls)
                c.Click += new EventHandler(c_Click);
            pnlColumnObject.Click += new EventHandler(c_Click);
            grbColumnObject.Click += new EventHandler(c_Click);
        }

        void c_Click(object sender, EventArgs e)
        {
            if (!Activate)
                Activate = true;
        }
        #endregion

        #region IConvertToXml 成员

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.ColumnObject.ToString());
            node.SetAttribute(XmlAttrDic.tID.ToString(), Column.ID);
            node.SetAttribute(XmlAttrDic.tName.ToString(), Column.Name);
            node.SetAttribute(XmlAttrDic.bSort.ToString(), Convert.ToInt32(Column.Sort).ToString());
            node.SetAttribute(XmlAttrDic.bUse.ToString(), Convert.ToInt32(Column.Use).ToString());
            node.SetAttribute(XmlAttrDic.bFilter.ToString(), Convert.ToInt32(Column.Filter).ToString());
            node.SetAttribute(XmlAttrDic.bTotalColumn.ToString(), Convert.ToInt32(Column.TotalColumn).ToString());
            node.SetAttribute(XmlAttrDic.bTotalRow.ToString(), Convert.ToInt32(Column.TotalRow).ToString());
            node.SetAttribute(XmlAttrDic.tSortID.ToString(), Column.SortId.ToString());
            node.SetAttribute(XmlAttrDic.bIsNumber.ToString(), Convert.ToInt32(Column.IsNumber).ToString());
            node.SetAttribute(XmlAttrDic.tDecimalPlace.ToString(), Column.DecimalPlace.ToString());
            node.SetAttribute(XmlAttrDic.tFont.ToString(), fc.ConvertToInvariantString(Column.Font));
            node.SetAttribute(XmlAttrDic.tColor.ToString(), System.Drawing.ColorTranslator.ToHtml(Column.Color));
            node.SetAttribute(XmlAttrDic.tHAligment.ToString(), Column.HAligment.ToString());
            node.SetAttribute(XmlAttrDic.tVAligment.ToString(), Column.VAligment.ToString());
            node.SetAttribute(XmlAttrDic.bUnion.ToString(), Convert.ToInt32(Column.Union).ToString());
            node.SetAttribute(XmlAttrDic.tValueTranslateType.ToString(), Column.ValueTransType.ToString());
            return node;
        }

        public enum XmlAttrDic
        {
            ColumnObject,
            tID,
            tName,
            bSort,
            bUse,
            bFilter,
            bTotalColumn,
            bTotalRow,
            tSortID,
            bIsNumber,
            tDecimalPlace,
            tFont,
            tColor,
            tHAligment,
            tVAligment,
            bUnion,
            tValueTranslateType
        }

        #endregion

        #region IConvertToXml 成员


        public void ParseFromXml(XmlDocument xmlDocument)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IConvertToXml 成员


        public void ParseFromXml(XmlNodeList xmlNodeList)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            column.DecimalPlace =Convert.ToInt32(numericUpDown.Value);
        }

        private void cbTotalCountRow_CheckedChanged(object sender, EventArgs e)
        {
            column.TotalRow = cbTotalCountRow.Checked;
        }

        private void linkLableOther_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            contextMenuStrip.Show(linkLableOther, 0, 0);
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fd.Font = column.Font;
            fd.ShowDialog();
            column.Font = fd.Font;
        }

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cd.Color = column.Color;
            cd.ShowDialog();
            column.Color = cd.Color;
        }

        private void HAligmentLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            column.HAligment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            UnCheckHAligment();
            (sender as ToolStripMenuItem).Checked = true;
        }

        private void HAligmentCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            column.HAligment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            UnCheckHAligment();
            (sender as ToolStripMenuItem).Checked = true;
        }

        private void HAligmentRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            column.HAligment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            UnCheckHAligment();
            (sender as ToolStripMenuItem).Checked = true;
        }

        private void HAligmentGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            column.HAligment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            UnCheckHAligment();
            (sender as ToolStripMenuItem).Checked = true;
        }

        private void VAligmentTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            column.VAligment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            UnCheckVAligment();
            (sender as ToolStripMenuItem).Checked = true;
        }

        private void VAligmentCenterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            column.VAligment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            UnCheckVAligment();
            (sender as ToolStripMenuItem).Checked = true;
        }

        private void VAligmentBottomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            column.VAligment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            UnCheckVAligment();
            (sender as ToolStripMenuItem).Checked = true;
        }

        private void VAligmentGeneralToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            column.VAligment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            UnCheckVAligment();
            (sender as ToolStripMenuItem).Checked = true;
        }

        private void UnionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnionToolStripMenuItem.Checked = !UnionToolStripMenuItem.Checked;
            column.Union = UnionToolStripMenuItem.Checked;
        }

        private void UnCheckValueTrans()
        {
            ValueTransBeNullWhenZeroToolStripMenuItem.Checked = false;
            ValueTransBeZeroWhenNullToolStripMenuItem.Checked = false;
            ValueTransDefaultToolStripMenuItem.Checked = false;
        }

        private void ValueTransBeZeroWhenNullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnCheckValueTrans();
            column.ValueTransType = QuickReportCore.Class.NumberCellTypePlus.ValueTranslateType.值为空时转换为零;
            (sender as ToolStripMenuItem).Checked = true;
        }

        private void ValueTransBeNullWhenZeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnCheckValueTrans();
            column.ValueTransType = QuickReportCore.Class.NumberCellTypePlus.ValueTranslateType.值为零时转换为空;
            (sender as ToolStripMenuItem).Checked = true;
        }

        private void ValueTransDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnCheckValueTrans();
            column.ValueTransType = QuickReportCore.Class.NumberCellTypePlus.ValueTranslateType.不转换;
            (sender as ToolStripMenuItem).Checked = true;
        }
    }
}
