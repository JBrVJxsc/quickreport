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
    internal partial class ucConditionObject : UserControl, Interfaces.IConvertToXml,Interfaces.IHaveBeenChanged
    {
        public ucConditionObject()
        {
            InitializeComponent();
            InitConditionTypes();
            SetUse(false);
        }

        public static Color ObjectActivateColor = Color.FromArgb(175, 215, 255);
        public static bool RefreshingConditionProtector = false;

        private bool cmbConditionTypeProtector = false;
        Forms.frmToolBoxConditionTypeEditor f;

        private Size useSize = new Size(555, 55);

        private QuickReportCore.Objects.Condition condition = new QuickReportCore.Objects.Condition();
        /// <summary>
        /// 条件实体。
        /// </summary>
        public QuickReportCore.Objects.Condition Condition
        {
            get
            {
                return condition;
            }
            set
            {
                condition = value;
                txtConditionName.Text = condition.Name;
                cmbConditionTypeProtector = true;
                if (condition.ConditionType.Name == string.Empty)
                    cmbConditionType.SelectedItem = null;
                else
                    cmbConditionType.Text = condition.ConditionType.Name;
                cmbConditionTypeProtector = false;
                cbDefaultShow.Checked = condition.DefaultShow;
                cbUse.Checked = condition.Use;
                cbNotNull.Checked = condition.NotNull;
            }
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
                    pnlConditionObject.BackColor = ObjectActivateColor;
                    if (!cmbConditionType.Focused)
                        txtConditionName.Focus();
                    if (ActivateOn != null)
                        ActivateOn(this);
                }
                else
                    pnlConditionObject.BackColor = SystemColors.Control;
            }
        }

        public delegate void ActivateHandle(ucConditionObject uc);
        public event ActivateHandle ActivateOn;

        public delegate void ConditionShowChangedHandle();
        public event ConditionShowChangedHandle ConditionShowChanged;

        public void InitFormConditionEditor(Forms.frmToolBoxConditionTypeEditor frm)
        {
            f = frm;
        }

        /// <summary>
        /// 强制刷新控件中的Condition。
        /// </summary>
        public void RefreshCondition()
        {
            Condition = condition;
        }

        /// <summary>
        /// 初始化条件类型下拉列表。
        /// </summary>
        public void InitConditionTypes()
        {
            string temp = cmbConditionType.Text;
            cmbConditionType.Items.Clear();
            foreach (Objects.ConditionType conditionType in Objects.ConditionType.SystemConditionTypes)
            {
                cmbConditionType.Items.Add(conditionType.Clone());
                if (conditionType.Name == temp)
                    cmbConditionType.Text = temp;
            }
        }

        #region 事件

        private void txtConditionName_TextChanged(object sender, EventArgs e)
        {
            condition.Name = txtConditionName.Text;
        }

        private void cbDefaultShow_CheckedChanged(object sender, EventArgs e)
        {
            condition.DefaultShow = cbDefaultShow.Checked;
        }

        private void cbHide_CheckedChanged(object sender, EventArgs e)
        {
            condition.Use = cbUse.Checked;
            SetUse(condition.Use);
            if (RefreshingConditionProtector)
                return;
            if (!condition.Use)
                ucConditionList.GobalConditionList.Remove(condition);
            else
                ucConditionList.GobalConditionList.Add(condition);
            if (ConditionShowChanged != null)
                ConditionShowChanged();
        }

        private void SetUse(bool b)
        {
            if (b)
                Size = useSize;
            else
                Size = new Size(cbUse.Location.X + cbUse.Width + 5, Height);
        }

        private void ucConditionObject_Load(object sender, EventArgs e)
        {
            foreach (Control c in pnlConditionObject.Controls)
                c.Click += new EventHandler(c_Click);
            pnlConditionObject.Click += new EventHandler(c_Click);
            grbConditionObject.Click += new EventHandler(c_Click);
        }

        void c_Click(object sender, EventArgs e)
        {
            if (!Activate)
                Activate = true;
        }

        private void lnkDefaultValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cmbConditionType.SelectedItem == null)
            {
                QuickReportCore.Managers.Functions.ShowToolTip(cmbConditionType, "请选择条件类型。", true);
                return;
            }
            Forms.frmConditionSetting frm = new QuickReportCore.Forms.frmConditionSetting();
            if (Condition.ConditionType.ID != string.Empty)
            {
                frm.Init(this, (QuickReportCore.Objects.Condition.InputValueType)Enum.Parse(typeof(QuickReportCore.Objects.Condition.InputValueType), Condition.ConditionType.ID));
            }
            frm.HaveBeenChanged += new QuickReportCore.Interfaces.HaveBeenChangedHandle(frm_HaveBeenChanged);
            frm.ShowDialog();
            frm.Dispose();
        }

        void frm_HaveBeenChanged(object sender, EventArgs e)
        {
            if (HaveBeenChanged != null)
                HaveBeenChanged(sender, e);
        }
        #endregion

        #region IConvertToXml 成员

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.ConditionObject.ToString());
            node.SetAttribute(XmlAttrDic.tID.ToString(), Condition.ID);
            node.SetAttribute(XmlAttrDic.tName.ToString(), Condition.Name);
            node.SetAttribute(XmlAttrDic.tConditionTypeID.ToString(), Condition.ConditionType.ID);
            node.SetAttribute(XmlAttrDic.tConditionTypeName.ToString(), Condition.ConditionType.Name);
            if (Condition.ConditionType.Content != null)
                node.AppendChild(Condition.ConditionType.Content);
            node.SetAttribute(XmlAttrDic.bUse.ToString(), Convert.ToInt32(Condition.Use).ToString());
            node.SetAttribute(XmlAttrDic.bDefaultShow.ToString(), Convert.ToInt32(Condition.DefaultShow).ToString());
            node.SetAttribute(XmlAttrDic.bNotNull.ToString(), Convert.ToInt32(Condition.NotNull).ToString());
            node.SetAttribute(XmlAttrDic.tSortID.ToString(), Condition.SortId.ToString());
            if (Condition.ConditionSetting != null)
                node.AppendChild(Condition.ConditionSetting);
            return node;
        }

        public enum XmlAttrDic
        {
            ConditionObject,
            tID,
            tName,
            tConditionTypeID,
            tConditionTypeName,
            tConditionTypeContent,
            bUse,
            bDefaultShow,
            tSortID,
            bNotNull,
            ConditionSetting
        }

        #endregion

        private void cmbConditionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConditionType.SelectedItem == null)
            {
                Condition.ConditionType = null;
                return;
            }
            System.Xml.XmlElement conditionTypeContent = Condition.ConditionType.Content as System.Xml.XmlElement;
            Condition.ConditionType = cmbConditionType.SelectedItem as Objects.ConditionType;
            Condition.ConditionType.Content = conditionTypeContent;
            string conditionTypeID = ((Objects.ConditionType)cmbConditionType.SelectedItem).ID;
            if (conditionTypeID.Contains(Objects.Condition.InputValueType.CustomComboBox.ToString()) && !cmbConditionTypeProtector)
            {
                if (f == null)
                    return;
                f.ConditionType = Condition.ConditionType;
                f.Show();
                f.SelectText();
            }
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

        private void cbNotNull_CheckedChanged(object sender, EventArgs e)
        {
            condition.NotNull = cbNotNull.Checked;
        }

        #region IHaveBeenChanged 成员

        public event QuickReportCore.Interfaces.HaveBeenChangedHandle HaveBeenChanged;

        #endregion
    }
}
