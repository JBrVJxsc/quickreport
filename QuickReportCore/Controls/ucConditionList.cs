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
    internal partial class ucConditionList : UserControl, Interfaces.IConvertToXml,Interfaces.IHaveBeenChanged
    {
        public ucConditionList()
        {
            InitializeComponent();
        }

        private int topMargin = -8;
        private int leftMargin = 4;
        private int eatchMargin = 0;

        private Hashtable ucConditionObjectControls = new Hashtable();
        private ucConditionObject ucConditionObjectActivated;
        private Managers.QuickReportManager quickReportManager = new QuickReportCore.Managers.QuickReportManager();

        private Forms.frmToolBoxConditionTypeEditor f;

        public static List<QuickReportCore.Objects.Condition> GobalConditionList = new List<QuickReportCore.Objects.Condition>();
        public event ucConditionObject.ConditionShowChangedHandle ConditionShowChanged;

        public int ShowConditions(List<QuickReportCore.Objects.Condition> list)
        {
            pnlConditions.SuspendLayout();
            GobalConditionList = new List<QuickReportCore.Objects.Condition>();
            Hashtable newUcConditionControls = new Hashtable();
            int timer = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (!ucConditionObjectControls.Contains(list[i].ID))
                {
                    ucConditionObject uc = new ucConditionObject();
                    uc.ActivateOn += new ucConditionObject.ActivateHandle(uc_ActivateOn);
                    uc.ConditionShowChanged += new ucConditionObject.ConditionShowChangedHandle(uc_ConditionShowChanged);
                    uc.Condition = list[i];
                    uc.Condition.SortId = timer;
                    uc.InitFormConditionEditor(f);
                    timer++;
                    ucConditionObjectControls.Add(list[i].ID, uc);
                    newUcConditionControls.Add(list[i].ID, uc);
                }
                else
                {
                    if (!newUcConditionControls.Contains(list[i].ID))
                    {
                        Objects.Condition tempCondition = (ucConditionObjectControls[list[i].ID] as ucConditionObject).Condition.Clone();
                        tempCondition.Name = list[i].Name;
                        tempCondition.SortId = timer;
                        (ucConditionObjectControls[list[i].ID] as ucConditionObject).Condition = tempCondition;
                        timer++;
                        newUcConditionControls.Add(list[i].ID, ucConditionObjectControls[list[i].ID]);
                    }
                }
                if ((ucConditionObjectControls[list[i].ID] as ucConditionObject).Condition.Use)
                    GobalConditionList.Add((ucConditionObjectControls[list[i].ID] as ucConditionObject).Condition);
            }
            ucConditionObjectControls = newUcConditionControls;
            pnlConditions.Controls.Clear();
            foreach (DictionaryEntry de in ucConditionObjectControls)
            {
                pnlConditions.Controls.Add(de.Value as Control);
                int i = (de.Value as ucConditionObject).Condition.SortId;
                if (i == 0)
                    (de.Value as ucConditionObject).Location = new Point(leftMargin, topMargin);
                else
                    (de.Value as ucConditionObject).Location = new Point(leftMargin, topMargin + (ucConditionObjectControls[list[i].ID] as ucConditionObject).Height * i + eatchMargin * i);
            }
            pnlConditions.ResumeLayout();
            return 1;
        }

        void uc_ConditionShowChanged()
        {
            if (ConditionShowChanged != null)
                ConditionShowChanged();
        }

        void uc_ActivateOn(ucConditionObject uc)
        {
            if (ucConditionObjectActivated == null)
            {
                ucConditionObjectActivated = uc;
                return;
            }
            else
                if (ucConditionObjectActivated != uc)
                {
                    ucConditionObjectActivated.Activate = false;
                    ucConditionObjectActivated = uc;
                }
        }

        public void MoveObject(MoveOrder order)
        {
            if (ucConditionObjectActivated == null)
                return;
            Objects.Condition tempCondition = ucConditionObjectActivated.Condition.Clone();
            Point tempLocation = ucConditionObjectActivated.Location;
            ucConditionObject tempUc = null;
            if (order == MoveOrder.Up)
            {
                if (ucConditionObjectActivated.Condition.SortId == 0)
                    return;
                tempUc = FindUcByConditionSortID(ucConditionObjectActivated.Condition.SortId - 1);
                ucConditionObjectActivated.Location = tempUc.Location;
                tempUc.Location = tempLocation;
                ucConditionObjectActivated.Condition.SortId -= 1;
                tempUc.Condition.SortId += 1;
            }
            else if (order == MoveOrder.Down)
            {
                if (ucConditionObjectActivated.Condition.SortId == ucConditionObjectControls.Count - 1)
                    return;
                tempUc = FindUcByConditionSortID(ucConditionObjectActivated.Condition.SortId + 1);
                ucConditionObjectActivated.Location = tempUc.Location;
                tempUc.Location = tempLocation;
                ucConditionObjectActivated.Condition.SortId += 1;
                tempUc.Condition.SortId -= 1;
            }
            if (tempUc == null)
                return;
            pnlConditions.ScrollControlIntoView(ucConditionObjectActivated);
            if (HaveBeenChanged != null)
                HaveBeenChanged(this, null);
        }

        public void InitFormConditionEditor(Forms.frmToolBoxConditionTypeEditor frm)
        {
            f = frm;
        }

        /// <summary>
        /// 根据序列ID获取控件。
        /// </summary>
        /// <param name="id">序列ID。</param>
        /// <returns>ucColumnObject控件。</returns>
        private ucConditionObject FindUcByConditionSortID(int id)
        {
            foreach (DictionaryEntry de in ucConditionObjectControls)
            {
                if ((de.Value as ucConditionObject).Condition.SortId == id)
                    return de.Value as ucConditionObject;
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
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.ConditionObjectList.ToString());
            foreach (DictionaryEntry de in ucConditionObjectControls)
            {
                node.AppendChild((de.Value as ucConditionObject).ConvertToXml());
            }
            return node;
        }

        public enum XmlAttrDic
        {
            ConditionObjectList
        }

        #endregion

        #region IConvertToXml 成员


        public void ParseFromXml(XmlDocument xmlDocument)
        {
            GobalConditionList = new List<QuickReportCore.Objects.Condition>();
            System.Xml.XmlNodeList nodeList = xmlDocument.SelectNodes("//" + ucConditionObject.XmlAttrDic.ConditionObject.ToString());
            Objects.Condition[] conditions = new QuickReportCore.Objects.Condition[nodeList.Count];
            foreach (System.Xml.XmlNode node in nodeList)
            {
                Objects.Condition condition = new QuickReportCore.Objects.Condition();
                condition.ID = Managers.Functions.GetNodeAttrValue(node,ucConditionObject.XmlAttrDic.tID.ToString(),string.Empty);
                condition.Name =  Managers.Functions.GetNodeAttrValue(node,ucConditionObject.XmlAttrDic.tName.ToString(),string.Empty);
                condition.ConditionType.ID = Managers.Functions.GetNodeAttrValue(node,ucConditionObject.XmlAttrDic.tConditionTypeID.ToString(),string.Empty);
                condition.ConditionType.Name =  Managers.Functions.GetNodeAttrValue(node,ucConditionObject.XmlAttrDic.tConditionTypeName.ToString(),string.Empty);
                condition.ConditionType.Content = node.SelectSingleNode(Forms.frmToolBoxConditionTypeEditor.XmlAttrDic.ConditionTypeContent.ToString()) as System.Xml.XmlElement;
                condition.DefaultShow = Convert.ToBoolean(Convert.ToInt32( Managers.Functions.GetNodeAttrValue(node,ucConditionObject.XmlAttrDic.bDefaultShow.ToString(),"0")));
                condition.Use = Convert.ToBoolean(Convert.ToInt32( Managers.Functions.GetNodeAttrValue(node,ucConditionObject.XmlAttrDic.bUse.ToString(),"0")));
                condition.NotNull = Convert.ToBoolean(Convert.ToInt32( Managers.Functions.GetNodeAttrValue(node,ucConditionObject.XmlAttrDic.bNotNull.ToString(),"0")));
                condition.SortId = Convert.ToInt32( Managers.Functions.GetNodeAttrValue(node,ucConditionObject.XmlAttrDic.tSortID.ToString(),"0"));
                condition.ConditionSetting = node.SelectSingleNode(ucConditionObject.XmlAttrDic.ConditionSetting.ToString()) as XmlElement;
                conditions[condition.SortId] = condition.Clone();
                if (conditions[condition.SortId].Use)
                    GobalConditionList.Add(conditions[condition.SortId]);
            }
            ucConditionObjectControls = new Hashtable();
            for (int i = 0; i < conditions.Length; i++)
            {
                if (!ucConditionObjectControls.Contains(conditions[i].ID))
                {
                    ucConditionObject uc = new ucConditionObject();
                    uc.ActivateOn += new ucConditionObject.ActivateHandle(uc_ActivateOn);
                    uc.ConditionShowChanged+=new ucConditionObject.ConditionShowChangedHandle(uc_ConditionShowChanged);
                    uc.InitFormConditionEditor(f);
                    uc.Condition = conditions[i];
                    ucConditionObjectControls.Add(conditions[i].ID, uc);
                }
            }
            pnlConditions.Controls.Clear();
            foreach (DictionaryEntry de in ucConditionObjectControls)
            {
                pnlConditions.Controls.Add(de.Value as Control);
                int i = (de.Value as ucConditionObject).Condition.SortId;
                if (i == 0)
                    (de.Value as ucConditionObject).Location = new Point(leftMargin, topMargin);
                else
                    (de.Value as ucConditionObject).Location = new Point(leftMargin, topMargin + (ucConditionObjectControls[conditions[i].ID] as ucConditionObject).Height * i + eatchMargin * i);
            }
        }

        #endregion

        #region IConvertToXml 成员


        public void ParseFromXml(XmlNodeList xmlNodeList)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IHaveBeenChanged 成员

        public event QuickReportCore.Interfaces.HaveBeenChangedHandle HaveBeenChanged;

        #endregion
    }
}
