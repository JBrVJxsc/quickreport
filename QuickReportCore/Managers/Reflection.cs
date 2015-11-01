using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Managers
{
    internal class Reflection
    {
        /// <summary>
        /// 获取一个类指定的属性值
        /// </summary>
        /// <param name="info">object对象</param>
        /// <param name="field">属性名称</param>
        /// <returns></returns>
        public static object GetPropertyValue(object info, string field)
        {
            if (info == null) return null;
            Type t = info.GetType();
            return null;
        } 
    }
}
