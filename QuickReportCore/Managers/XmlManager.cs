using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace QuickReportCore.Managers
{
    internal class XmlManager
    {
        public static string Serialize<T>(T t)
        {
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xz = new XmlSerializer(t.GetType());
                xz.Serialize(sw, t);
                return sw.ToString();
            }
        }

        public static object Deserialize(Type type, string s)
        { 
             using (StringReader sr = new StringReader(s))
            {
                XmlSerializer xz = new XmlSerializer(type);
                return xz.Deserialize(sr);
            }
        }
    }
}
