using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace QuickReportCore.Interfaces
{
    internal interface IConvertToXml
    {
        XmlElement ConvertToXml();
        void ParseFromXml(XmlDocument xmlDocument);
        void ParseFromXml(XmlNodeList xmlNodeList);
    }
}
