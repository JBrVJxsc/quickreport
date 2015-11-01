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
    /// Xml��̬�����ࡣ�ṩXml��ز���������
    /// </summary>
    internal static class XmlManager
    {
        private static XmlSerializer xmlSerializer;

        /// <summary>
        /// ��ʼ��XmlManager��
        /// </summary>
        public static void InitXmlManager()
        {
            if (xmlSerializer == null)
            {
                xmlSerializer = new XmlSerializer(typeof(Report));
            }
        }

        /// <summary>
        /// ������ʵ�����л�ΪXml�ַ�����
        /// </summary>
        /// <param name="report">����ʵ�塣</param>
        /// <returns>Xml�ַ�����</returns>
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
        /// ��Xml�ַ��������л�Ϊ����ʵ�塣
        /// </summary>
        /// <param name="reportXml">Xml�ַ�����</param>
        /// <returns>����ʵ�塣</returns>
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
