using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Objects.SystemValue;
using QuickReportLib.Managers;
using QuickReportLib.Enums;

namespace QuickReportLib.Managers
{
    /// <summary>
    /// �ṩϵͳ������ط����ľ�̬�ࡣ
    /// </summary>
    internal static class SystemValueManager
    {
        private static List<BaseSystemValueObject> baseSystemValueObjectList=new List<BaseSystemValueObject>();

        static SystemValueManager()
        {
            baseSystemValueObjectList = GetBaseSystemValueObjects();
        }

        /// <summary>
        /// �����ַ����е�ϵͳ�����������������ַ������ء�
        /// </summary>
        /// <param name="str">��Ҫ������ַ�����</param>
        /// <returns>�������ַ�����</returns>
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
