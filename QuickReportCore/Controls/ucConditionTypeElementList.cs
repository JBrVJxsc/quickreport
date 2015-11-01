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
    internal partial class ucConditionTypeElementList : UserControl, Interfaces.IConvertToXml
    {
        public ucConditionTypeElementList()
        {
            InitializeComponent();
        }

        public ucConditionTypeElementList(List<QuickReportCore.Objects.ConditionTypeElement> list)
        {
            InitializeComponent();
            ShowConditionTypeElements(list);
        }

        private int topMargin = -8;
        private int leftMargin = 4;
        private int eatchMargin = 0;

        private Hashtable ucConditionTypeElementObjectControls = new Hashtable();
        private ucConditionTypeElementObject ucConditionTypeElementObjectActivated;
        private Managers.QuickReportManager quickReportManager = new QuickReportCore.Managers.QuickReportManager();

        public int ShowConditionTypeElements(List<QuickReportCore.Objects.ConditionTypeElement> list)
        {
            ucConditionTypeElementObjectControls = new Hashtable();
            foreach (QuickReportCore.Objects.ConditionTypeElement element in list)
            {
                ucConditionTypeElementObject uc = new ucConditionTypeElementObject();
                uc.ActivateOn += new ucConditionTypeElementObject.ActivateHandle(uc_ActivateOn);
                uc.ConditionTypeElement = element;
                ucConditionTypeElementObjectControls.Add(element.ID, uc);
            }
            pnlConditionTypeElements.Controls.Clear();
            foreach (DictionaryEntry de in ucConditionTypeElementObjectControls)
            {
                pnlConditionTypeElements.Controls.Add(de.Value as Control);
                int i = ((ucConditionTypeElementObject)de.Value).ConditionTypeElement.SortId;
                if (i == 0)
                    ((ucConditionTypeElementObject)de.Value).Location = new Point(leftMargin, topMargin);
                else
                    ((ucConditionTypeElementObject)de.Value).Location = new Point(leftMargin, topMargin + ((ucConditionObject)ucConditionTypeElementObjectControls[list[i].ID]).Height * i + eatchMargin * i);
            }
            return 1;
        }

        void uc_ActivateOn(ucConditionTypeElementObject uc)
        {
            if (ucConditionTypeElementObjectActivated == null)
            {
                ucConditionTypeElementObjectActivated = uc;
                return;
            }
            else
                ucConditionTypeElementObjectActivated.Activate = false;
            ucConditionTypeElementObjectActivated = uc;
        }

        public void MoveObject(MoveOrder order)
        {
            if (ucConditionTypeElementObjectActivated == null)
                return;
            Objects.ConditionTypeElement tempConditionTypeElement = ucConditionTypeElementObjectActivated.ConditionTypeElement.Clone();
            ucConditionTypeElementObject tempUc = null;
            if (order == MoveOrder.Up)
            {
                if (ucConditionTypeElementObjectActivated.ConditionTypeElement.SortId == 0)
                    return;
                tempUc = FindUcByConditionSortID(ucConditionTypeElementObjectActivated.ConditionTypeElement.SortId - 1);
                ucConditionTypeElementObjectActivated.ConditionTypeElement = tempUc.ConditionTypeElement.Clone();
                tempUc.ConditionTypeElement = tempConditionTypeElement;
                ucConditionTypeElementObjectActivated.ConditionTypeElement.SortId += 1;
                tempUc.ConditionTypeElement.SortId -= 1;
            }
            else if (order == MoveOrder.Down)
            {
                if (ucConditionTypeElementObjectActivated.ConditionTypeElement.SortId == ucConditionTypeElementObjectControls.Count - 1)
                    return;
                tempUc = FindUcByConditionSortID(ucConditionTypeElementObjectActivated.ConditionTypeElement.SortId + 1);
                ucConditionTypeElementObjectActivated.ConditionTypeElement = tempUc.ConditionTypeElement.Clone();
                tempUc.ConditionTypeElement = tempConditionTypeElement;
                ucConditionTypeElementObjectActivated.ConditionTypeElement.SortId -= 1;
                tempUc.ConditionTypeElement.SortId += 1;
            }
            if (tempUc == null)
                return;
            ucConditionTypeElementObjectControls.Remove(ucConditionTypeElementObjectActivated.ConditionTypeElement.ID);
            ucConditionTypeElementObjectControls.Add(ucConditionTypeElementObjectActivated.ConditionTypeElement.ID, ucConditionTypeElementObjectActivated);
            ucConditionTypeElementObjectControls.Remove(tempUc.ConditionTypeElement.ID);
            ucConditionTypeElementObjectControls.Add(tempUc.ConditionTypeElement.ID, tempUc);
            tempUc.Activate = true;
            pnlConditionTypeElements.ScrollControlIntoView(tempUc);
        }

        /// <summary>
        /// 根据序列ID获取控件。
        /// </summary>
        /// <param name="id">序列ID。</param>
        /// <returns>ucColumnObject控件。</returns>
        private ucConditionTypeElementObject FindUcByConditionSortID(int id)
        {
            foreach (DictionaryEntry de in ucConditionTypeElementObjectControls)
            {
                if (((ucConditionTypeElementObject)de.Value).ConditionTypeElement.SortId == id)
                    return de.Value as ucConditionTypeElementObject;
            }
            return null;
        }

        #region IConvertToXml 成员

        public System.Xml.XmlElement ConvertToXml()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

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
    }
}
