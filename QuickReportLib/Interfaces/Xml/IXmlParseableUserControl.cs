using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace QuickReportLib.Interfaces.Xml
{
    /// <summary>
    /// Xml解析接口。允许控件成员从Xml文档中解析数据。
    /// </summary>
    internal interface IXmlParseableUserControl : IXml
    {
        /// <summary>
        /// 从Xml文档中解析数据。
        /// </summary>
        /// <param name="xmlDocument">Xml文档。</param>
        void ParseFromXml(XmlDocument xmlDocument);
    }
}
