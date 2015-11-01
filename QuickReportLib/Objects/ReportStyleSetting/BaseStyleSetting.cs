using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using QuickReportLib.Interfaces.ReportStyle;

namespace QuickReportLib.Objects.ReportStyleSetting
{
    /// <summary>
    /// ������ʽ����ʵ��Ļ��������ࡣ
    /// </summary>
    [XmlInclude(typeof(GridStyleSetting))]
    [XmlInclude(typeof(GeneralCrossStyleSetting))]
    [XmlInclude(typeof(CustomColumnCrossStyleSetting))]
    public abstract class BaseStyleSetting : IReportStyleSettingObject
    {

    }
}
