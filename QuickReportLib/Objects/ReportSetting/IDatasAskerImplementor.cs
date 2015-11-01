using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Managers;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// IDatasAsker实现者实体。
    /// </summary>
    public class IDatasAskerImplementor : BaseObject
    {
        private string dllName = string.Empty;
        private string className = string.Empty;
        private string value = string.Empty;

        /// <summary>
        /// 实现类所在Dll名称。
        /// </summary>
        public string DllName
        {
            get
            {
                return dllName;
            }
            set
            {
                dllName = value;
            }
        }

        /// <summary>
        /// 实现接口的类的名称。
        /// </summary>
        public string ClassName
        {
            get
            {
                return className;
            }
            set
            {
                className = value;
            }
        }

        /// <summary>
        /// 需要从报表中获取的值。
        /// </summary>
        public string Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        /// <summary>
        /// 获得该类型的实例。
        /// </summary>
        public object Instance
        {
            get
            {
                return ReflectionManager.CreateInstanceByClassName(dllName, className);
            }
        }
    }
}
