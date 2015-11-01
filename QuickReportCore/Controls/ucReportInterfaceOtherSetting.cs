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
            cmbActionType.Items.Add(INeedDatasActionType.单击激活接口);
            cmbActionType.Items.Add(INeedDatasActionType.双击激活接口);
            cmbActionType.Text = INeedDatasActionType.双击激活接口.ToString();
        }

        /// <summary>
        /// 何时激活INeedDatas接口。
        /// </summary>
        public enum INeedDatasActionType
        {
            /// <summary>
            /// 单击激活接口。
            /// </summary>
            单击激活接口,
            /// <summary>
            /// 双击激活接口。
            /// </summary>
            双击激活接口
        }

        #region IConvertToXml 成员

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
