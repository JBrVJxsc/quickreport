using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using QuickReportLib.Objects;

namespace QuickReportLib.Managers
{
    /// <summary>
    /// Xml静态操作类。提供Xml相关操作方法。
    /// </summary>
    internal static class XmlManager
    {
        private static XmlSerializer xmlSerializer;

        /// <summary>
        /// 初始化XmlManager。
        /// </summary>
        public static void InitXmlManager()
        {
            if (xmlSerializer == null)
            {
                xmlSerializer = new XmlSerializer(typeof(Report));
            }
        }

        /// <summary>
        /// 将报表实体序列化为Xml字符串。
        /// </summary>
        /// <param name="report">报表实体。</param>
        /// <returns>Xml字符串。</returns>
        public static string SerializeReport(Report report)
        {
            InitXmlManager();
            using (StringWriter sw = new StringWriter())
            {
                xmlSerializer.Serialize(sw, report);
                return sw.ToString();
            }
        }

        /// <summary>
        /// 将Xml字符串反序列化为报表实体。
        /// </summary>
        /// <param name="reportXml">Xml字符串。</param>
        /// <returns>报表实体。</returns>
        public static Report DeserializeReport(string reportXml)
        {
            InitXmlManager();
            using (StringReader sr = new StringReader(reportXml))
            {
                Report report = xmlSerializer.Deserialize(sr) as Report;
                return report;
            }
        }
    }
}
