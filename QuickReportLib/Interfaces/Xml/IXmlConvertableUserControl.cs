using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace QuickReportLib.Interfaces.Xml
{
    /// <summary>
    /// Xml转换接口。允许控件成员转换为Xml元素。
    /// </summary>
    internal interface IXmlConvertableUserControl : IXml
    {
        /// <summary>
        /// 转换为Xml元素。
        /// </summary>
        /// <param name="xmlDocument">Xml文档。</param>
        /// <returns>Xml元素。</returns>
        XmlElement ConvertToXml(XmlDocument xmlDocument);
    }
}
