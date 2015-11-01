using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace QuickReportCore.Controls
{
    internal partial class ucReportInterfacesSetting : UserControl, Interfaces.IConvertToXml
    {
        public ucReportInterfacesSetting()
        {
            InitializeComponent();
        }

        private List<Type> iAmPublicInterfaceList;
        private List<Interfaces.IInterfaceList> iInterfaceList;

        public void InitPublicInterfaceTypes()
        {
            iAmPublicInterfaceList = new List<Type>();
            iInterfaceList = new List<QuickReportCore.Interfaces.IInterfaceList>();
            List<Type> iInterfaceListTypes = new List<Type>();
            List<Interfaces.IInterfaceList> tempIInterfaceList = new List<QuickReportCore.Interfaces.IInterfaceList>();
            iAmPublicInterfaceList = Managers.Functions.GetTypes("QuickReportCore.dll", typeof(Interfaces.IAmPublicInterface), QuickReportCore.Managers.Functions.TypeOfType.Interface);
            iInterfaceListTypes = Managers.Functions.GetTypes("QuickReportCore.dll", typeof(Interfaces.IInterfaceList), QuickReportCore.Managers.Functions.TypeOfType.Class);
            foreach (Type t in iInterfaceListTypes)
            {
                Interfaces.IInterfaceList i = Managers.Functions.CreateInstance("QuickReportCore.dll", t.FullName) as Interfaces.IInterfaceList;
                if(i!=null)
                    tempIInterfaceList.Add(i);
            }
            foreach (Type t in iAmPublicInterfaceList)
            {
                System.Windows.Forms.TabPage tabPage = new TabPage();
                tabPage.Text = t.Name;
                Interfaces.IInterfaceList iInterface=null;
                foreach (Interfaces.IInterfaceList i in tempIInterfaceList)
                {
                    if (i.ParentInterface == t)
                    {
                        iInterfaceList.Add(i);
                        iInterface = i;
                        break;
                    }
                }
                if (iInterface != null)
                {
                    tabPage.Controls.Add(iInterface as Control);
                    tabPage.Tag = iInterface;
                    (iInterface as Control).Dock = DockStyle.Fill;
                }
                tabControlInterfaces.TabPages.Add(tabPage);
            }
            System.Windows.Forms.TabPage tabPageOtherSetting = new TabPage();
            tabPageOtherSetting.Text = "其他";
            ucReportInterfaceOtherSetting uc = new ucReportInterfaceOtherSetting();
            tabPageOtherSetting.Controls.Add(uc);
            tabPageOtherSetting.Tag = uc;
            uc.Dock = DockStyle.Fill;
            tabControlInterfaces.TabPages.Add(tabPageOtherSetting);
        }

        #region IConvertToXml 成员

        public System.Xml.XmlElement ConvertToXml()
        {
            System.Xml.XmlElement node = Forms.frmQuickReportEditor.xmlDocument.CreateElement(XmlAttrDic.ReportInterfaceSetting.ToString());
            foreach (TabPage t in tabControlInterfaces.TabPages)
            {
                node.AppendChild((t.Tag as Interfaces.IConvertToXml).ConvertToXml());
            }
            return node;
        }

        public void ParseFromXml(System.Xml.XmlDocument xmlDocument)
        {
            foreach (TabPage t in tabControlInterfaces.TabPages)
            {
                (t.Tag as Interfaces.IConvertToXml).ParseFromXml(xmlDocument);
            }
        }

        public void ParseFromXml(System.Xml.XmlNodeList xmlNodeList)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        public enum XmlAttrDic
        { 
            ReportInterfaceSetting
        }
    }
}
