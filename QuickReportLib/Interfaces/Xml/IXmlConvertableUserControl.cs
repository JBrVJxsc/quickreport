using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace QuickReportLib.Interfaces.Xml
{
    /// <summary>
    /// Xmlת���ӿڡ�����ؼ���Աת��ΪXmlԪ�ء�
    /// </summary>
    internal interface IXmlConvertableUserControl : IXml
    {
        /// <summary>
        /// ת��ΪXmlԪ�ء�
        /// </summary>
        /// <param name="xmlDocument">Xml�ĵ���</param>
        /// <returns>XmlԪ�ء�</returns>
        XmlElement ConvertToXml(XmlDocument xmlDocument);
    }
}
