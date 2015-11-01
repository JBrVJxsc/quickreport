using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Objects.SystemValue;
using QuickReportLib.Managers;
using QuickReportLib.Enums;

namespace QuickReportLib.Managers
{
    /// <summary>
    /// 提供系统变量相关方法的静态类。
    /// </summary>
    internal static class SystemValueManager
    {
        private static List<BaseSystemValueObject> baseSystemValueObjectList=new List<BaseSystemValueObject>();

        static SystemValueManager()
        {
            baseSystemValueObjectList = GetBaseSystemValueObjects();
        }

        /// <summary>
        /// 翻译字符串中的系统变量，并将翻译后的字符串返回。
        /// </summary>
        /// <param name="str">需要翻译的字符串。</param>
        /// <returns>翻译后的字符串。</returns>
        public static string Translate(string str)
        {
            if (!str.Contains("["))
            {
                return str;
            }
            foreach (BaseSystemValueObject baseSystemValueObject in baseSystemValueObjectList)
            {
                str = str.Replace(SQLManager.GetSQLCode(baseSystemValueObject.ValueID,SQLCodeType.System), baseSystemValueObject.Value);
            }
            return str;
        }

        private static List<BaseSystemValueObject> GetBaseSystemValueObjects()
        {
           List<object> objectList = ReflectionManager.CreateInstancesByBaseClass(typeof(BaseSystemValueObject));
           List<BaseSystemValueObject> baseSystemValueObjectList = new List<BaseSystemValueObject>();
           foreach (object obj in objectList)
           {
               baseSystemValueObjectList.Add(obj as BaseSystemValueObject);
           }
           return baseSystemValueObjectList;
        }
    }
}
