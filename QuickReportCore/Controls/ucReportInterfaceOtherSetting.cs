using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore.Controls
{
    internal partial class ucReportInterfaceOtherSetting : UserControl, Interfaces.IConvertToXml
    {
        public ucReportInterfaceOtherSetting()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            cmbActionType.Items.Clear();
            cmbActionType.Items.Add(INeedDatasActionType.��������ӿ�);
            cmbActionType.Items.Add(INeedDatasActionType.˫������ӿ�);
            cmbActionType.Text = INeedDatasActionType.˫������ӿ�.ToString();
        }

        /// <summary>
        /// ��ʱ����INeedDatas�ӿڡ�
        /// </summary>
        public enum INeedDatasActionType
        {
            /// <summary>
            /// ��������ӿڡ�
            /// </summary>
            ��������ӿ�,
            /// <summary>
            /// ˫������ӿڡ�
            /// </summary>
            ˫������ӿ�
        }

        #region IConvertToXml ��Ա

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.IReportInterfaceOtherSetting.ToString());
            node.SetAttribute(XmlAttrDic.tINeedDatasActionType.ToString(), cmbActionType.Text);
            return node;
        }

        public void ParseFromXml(System.Xml.XmlDocument xmlDocument)
        {
            System.Xml.XmlNode node = xmlDocument.SelectSingleNode("//" + XmlAttrDic.IReportInterfaceOtherSetting.ToString());
            cmbActionType.Text = Managers.Functions.GetNodeAttrValue(node, XmlAttrDic.tINeedDatasActionType.ToString(), string.Empty);
        }

        public void ParseFromXml(System.Xml.XmlNodeList xmlNodeList)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        public enum XmlAttrDic
        {
            IReportInterfaceOtherSetting,
            tINeedDatasActionType
        }
    }
}
