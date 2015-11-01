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
    internal partial class ucReportHeaderSetting : UserControl, Interfaces.IConvertToXml,Interfaces.IHaveBeenChanged
    {
        public ucReportHeaderSetting()
        {
            InitializeComponent();
            Init();
        }

        private FontDialog fd = new FontDialog();
        private ColorDialog cd = new ColorDialog();
        private FontConverter fc = new FontConverter();

        private void Init()
        {
            tbHLeft.Tag = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            tbHCenter.Tag = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            tbHRight.Tag = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            tbHGeneral.Tag = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            tbVTop.Tag = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            tbVCenter.Tag = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            tbVBottom.Tag = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            tbVGeneral.Tag = FarPoint.Win.Spread.CellVerticalAlignment.General;
        }

        private void UnCheckHAligment()
        {
            tbHLeft.Checked = false;
            tbHCenter.Checked = false;
            tbHRight.Checked = false;
            tbHGeneral.Checked = false;
        }

        private void UnCheckVAligment()
        {
            tbVTop.Checked = false;
            tbVCenter.Checked = false;
            tbVBottom.Checked = false;
            tbVGeneral.Checked = false;
        }

        private void SetHVToolstripButtom(FarPoint.Win.Spread.Cell cell)
        {
            switch (cell.HorizontalAlignment)
            {
                case FarPoint.Win.Spread.CellHorizontalAlignment.General:
                    {
                        UnCheckHAligment();
                        tbHGeneral.Checked = true;
                        break;
                    }
                case FarPoint.Win.Spread.CellHorizontalAlignment.Center:
                    {
                        UnCheckHAligment();
                        tbHCenter.Checked = true;
                        break;
                    }
                case FarPoint.Win.Spread.CellHorizontalAlignment.Right:
                    {
                        UnCheckHAligment();
                        tbHRight.Checked = true;
                        break;
                    }
                case FarPoint.Win.Spread.CellHorizontalAlignment.Left:
                    {
                        UnCheckHAligment();
                        tbHLeft.Checked = true;
                        break;
                    }
            }
            switch (cell.VerticalAlignment)
            {
                case FarPoint.Win.Spread.CellVerticalAlignment.General:
                    {
                        UnCheckVAligment();
                        tbVGeneral.Checked = true;
                        break;
                    }
                case FarPoint.Win.Spread.CellVerticalAlignment.Center:
                    {
                        UnCheckVAligment();
                        tbVCenter.Checked = true;
                        break;
                    }
                case FarPoint.Win.Spread.CellVerticalAlignment.Bottom:
                    {
                        UnCheckVAligment();
                        tbVBottom.Checked = true;
                        break;
                    }
                case FarPoint.Win.Spread.CellVerticalAlignment.Top:
                    {
                        UnCheckVAligment();
                        tbVTop.Checked = true;
                        break;
                    }
            }
        }

        private void tbAdd_Click(object sender, EventArgs e)
        {
            fpMain_Sheet1.RowCount++;
            fpMain_Sheet1.Cells[fpMain_Sheet1.RowCount - 1, 0].Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            fpMain_Sheet1.Cells[fpMain_Sheet1.RowCount - 1, 0].ForeColor = Color.Black;//颜色为默认黑色，这样在保存为XML时，不会因为用户不设置颜色而使XML中保存的颜色值为（0,0,0,0），也就是空。
        }

        private void tbDelete_Click(object sender, EventArgs e)
        {
            if (fpMain_Sheet1.ActiveCell == null)
                return;
            if (fpMain_Sheet1.RowCount > 0)
            {
                fpMain_Sheet1.Rows.Remove(fpMain_Sheet1.ActiveCell.Row.Index, 1);
            }
        }

        private void tbFont_Click(object sender, EventArgs e)
        {
            if (fpMain_Sheet1.ActiveCell == null)
                return;
            fd.Font = fpMain_Sheet1.ActiveCell.Font;
            Forms.frmQuickReportEditor.StopHooker();
            DialogResult dr = fd.ShowDialog();
            Forms.frmQuickReportEditor.StartHooker();
            if (dr != DialogResult.OK)
                return;
            fpMain_Sheet1.ActiveCell.Font = fd.Font;
        }

        private void tbHAligment_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (fpMain_Sheet1.ActiveCell == null)
                return;
            fpMain_Sheet1.ActiveCell.HorizontalAlignment = (FarPoint.Win.Spread.CellHorizontalAlignment)e.ClickedItem.Tag;
            UnCheckHAligment();
            (e.ClickedItem as ToolStripMenuItem).Checked = true;
        }

        private void tbVAligment_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (fpMain_Sheet1.ActiveCell == null)
                return;
            fpMain_Sheet1.ActiveCell.VerticalAlignment = (FarPoint.Win.Spread.CellVerticalAlignment)e.ClickedItem.Tag;
            UnCheckVAligment();
            (e.ClickedItem as ToolStripMenuItem).Checked = true;
        }

        private void fpMain_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
            {
                e.Cancel = true;
                return;
            }
            fd.Font = fpMain_Sheet1.ActiveCell.Font;
            SetHVToolstripButtom(fpMain_Sheet1.Cells[e.Row,e.Column]);
        }

        #region IConvertToXml 成员

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.HeaderObjectList.ToString());
            for (int i = 0; i < fpMain_Sheet1.Rows.Count; i++)
            {
                node.AppendChild(RowToXml(i));
            }
            return node;
        }

        public enum XmlAttrDic
        {
            HeaderObjectList,
            HeaderObject,
            tText,
            tFont,
            tColor,
            tHAligment,
            tVAligment,
            tHeight,
            tRowIndex
        }

        #endregion

        private System.Xml.XmlElement RowToXml(int rowIndex)
        {
            FarPoint.Win.Spread.Cell cell = fpMain_Sheet1.Cells[rowIndex, 0];
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.HeaderObject.ToString());
            node.SetAttribute(XmlAttrDic.tText.ToString(), cell.Text);
            node.SetAttribute(XmlAttrDic.tFont.ToString(), fc.ConvertToInvariantString(cell.Font));
            node.SetAttribute(XmlAttrDic.tColor.ToString(), System.Drawing.ColorTranslator.ToHtml(cell.ForeColor));
            node.SetAttribute(XmlAttrDic.tHAligment.ToString(), cell.HorizontalAlignment.ToString());
            node.SetAttribute(XmlAttrDic.tVAligment.ToString(), cell.VerticalAlignment.ToString());
            node.SetAttribute(XmlAttrDic.tHeight.ToString(), fpMain_Sheet1.Rows[rowIndex].Height.ToString());
            node.SetAttribute(XmlAttrDic.tRowIndex.ToString(), rowIndex.ToString());
            return node;
        }

        #region IConvertToXml 成员


        public void ParseFromXml(XmlDocument xmlDocument)
        {

        }

        #endregion

        #region IConvertToXml 成员

        public void ParseFromXml(XmlNodeList xmlNodeList)
        {
            fpMain_Sheet1.RowCount = xmlNodeList.Count;
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                int rowIndex = Convert.ToInt32(Managers.Functions.GetNodeAttrValue( xmlNodeList[i],XmlAttrDic.tRowIndex.ToString(),"0"));
                FarPoint.Win.Spread.Cell cell = fpMain_Sheet1.Cells[rowIndex, 0];
                cell.Text =Managers.Functions.GetNodeAttrValue( xmlNodeList[i],XmlAttrDic.tText.ToString(), string.Empty);
                cell.Font = fc.ConvertFromInvariantString(Managers.Functions.GetNodeAttrValue(xmlNodeList[i],XmlAttrDic.tFont.ToString(), string.Empty)) as Font;
                cell.ForeColor = System.Drawing.ColorTranslator.FromHtml(Managers.Functions.GetNodeAttrValue(xmlNodeList[i], XmlAttrDic.tColor.ToString(), string.Empty));
                cell.HorizontalAlignment = (FarPoint.Win.Spread.CellHorizontalAlignment)Enum.Parse(typeof(FarPoint.Win.Spread.CellHorizontalAlignment), Managers.Functions.GetNodeAttrValue(xmlNodeList[i], XmlAttrDic.tHAligment.ToString(), FarPoint.Win.Spread.CellHorizontalAlignment.General.ToString()));
                cell.VerticalAlignment = (FarPoint.Win.Spread.CellVerticalAlignment)Enum.Parse(typeof(FarPoint.Win.Spread.CellVerticalAlignment), Managers.Functions.GetNodeAttrValue(xmlNodeList[i], XmlAttrDic.tVAligment.ToString(), FarPoint.Win.Spread.CellVerticalAlignment.General.ToString()));
                fpMain_Sheet1.Rows[rowIndex].Height = Convert.ToInt64(Managers.Functions.GetNodeAttrValue(xmlNodeList[i],XmlAttrDic.tHeight.ToString(),"0"));
            }
        }

        #endregion

        private void tbAll_Click(object sender, EventArgs e)
        {
            for(int i=0;i<fpMain_Sheet1.Rows.Count;i++)
                fpMain_Sheet1.Rows[i].Height = fpMain_Sheet1.Rows[i].GetPreferredHeight();
        }

        private void tbSelect_Click(object sender, EventArgs e)
        {
            if (fpMain_Sheet1.ActiveCell == null)
                return;
            fpMain_Sheet1.Rows[fpMain_Sheet1.ActiveRowIndex].Height = fpMain_Sheet1.Rows[fpMain_Sheet1.ActiveRowIndex].GetPreferredHeight();
        }

        private void tbColor_Click(object sender, EventArgs e)
        {
            if (fpMain_Sheet1.ActiveCell == null)
                return;
            cd.Color = fpMain_Sheet1.ActiveCell.ForeColor;
            DialogResult dr = cd.ShowDialog();
            if (dr != DialogResult.OK)
                return;
            fpMain_Sheet1.ActiveCell.ForeColor = cd.Color;
        }

        private void fpMain_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
            {
                e.Cancel = true;
                return;
            }
        }

        private void ucReportHeaderSetting_Load(object sender, EventArgs e)
        {
            InitChangedEvent();
        }

        private void InitChangedEvent()
        {
            fpMain.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(fpMain_EditChange);
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

        void fpMain_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (HaveBeenChanged != null)
                HaveBeenChanged(sender, null);
        }

        #region IHaveBeenChanged 成员

        public event QuickReportCore.Interfaces.HaveBeenChangedHandle HaveBeenChanged;

        #endregion
    }
}
