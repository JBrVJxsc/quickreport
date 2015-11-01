using System;
namespace QuickReportCore.Controls
{
    interface IucColumnObject
    {
        bool Activate { get; set; }
        event ucColumnObject.ActivateHandle ActivateOn;
        QuickReportCore.Objects.Column Column { get; set; }
        System.Xml.XmlElement ConvertToXml();
        void ParseFromXml(System.Xml.XmlNodeList xmlNodeList);
        void ParseFromXml(System.Xml.XmlDocument xmlDocument);
    }
}
