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
    internal partial class ucConditionTypeElementObject : UserControl, Interfaces.IConvertToXml
    {
        public ucConditionTypeElementObject()
        {
            InitializeComponent();
        }

        private QuickReportCore.Objects.ConditionTypeElement conditionTypeElement = new QuickReportCore.Objects.ConditionTypeElement();
        /// <summary>
        /// ��������Ԫ��ʵ�塣
        /// </summary>
        public QuickReportCore.Objects.ConditionTypeElement ConditionTypeElement
        {
            get
            {
                return conditionTypeElement;
            }
            set
            {
                conditionTypeElement = value;
                txtName.Text = conditionTypeElement.Name;
                txtID.Text = conditionTypeElement.ID;
                cbHide.Checked = conditionTypeElement.Hide;
            }
        }


        private bool activate = false;
        /// <summary>
        /// �Ƿ��ڼ���״̬��
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
                    pnlConditionTypeElement.BackColor = ucConditionObject.ObjectActivateColor;
                    txtName.Focus();
                    ActivateOn(this);
                }
                else
                    pnlConditionTypeElement.BackColor = SystemColors.Control;
            }
        }

        public delegate void ActivateHandle(ucConditionTypeElementObject uc);
        public event ActivateHandle ActivateOn;

        #region IConvertToXml ��Ա

        public System.Xml.XmlElement ConvertToXml()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region �¼�

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            conditionTypeElement.Name = txtName.Text;
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            conditionTypeElement.ID = txtID.Text;
        }

        private void cbHide_CheckedChanged(object sender, EventArgs e)
        {
            conditionTypeElement.Hide = cbHide.Checked;
        }

        #endregion

        #region IConvertToXml ��Ա


        public void ParseFromXml(XmlDocument xmlDocument)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IConvertToXml ��Ա


        public void ParseFromXml(XmlNodeList xmlNodeList)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
