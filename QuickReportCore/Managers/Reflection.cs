using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Managers
{
    internal class Reflection
    {
        /// <summary>
        /// ��ȡһ����ָ��������ֵ
        /// </summary>
        /// <param name="info">object����</param>
        /// <param name="field">��������</param>
        /// <returns></returns>
        public static object GetPropertyValue(object info, string field)
        {
            if (info == null) return null;
            Type t = info.GetType();
            return null;
        } 
    }
}
