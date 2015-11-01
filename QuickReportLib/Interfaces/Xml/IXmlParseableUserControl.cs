using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace QuickReportLib.Interfaces.Xml
{
    /// <summary>
    /// Xml�����ӿڡ�����ؼ���Ա��Xml�ĵ��н������ݡ�
    /// </summary>
    internal interface IXmlParseableUserControl : IXml
    {
        /// <summary>
        /// ��Xml�ĵ��н������ݡ�
        /// </summary>
        /// <param name="xmlDocument">Xml�ĵ���</param>
        void ParseFromXml(XmlDocument xmlDocument);
    }
}
