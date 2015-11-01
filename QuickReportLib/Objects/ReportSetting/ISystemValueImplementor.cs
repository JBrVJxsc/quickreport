using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// ISystemValue实现者实体。
    /// </summary>
    public class ISystemValueImplementor : BaseObject
    {
        private string dllName = string.Empty;
        private string className = string.Empty;

        /// <summary>
        /// Dll名称。
        /// </summary>
        public string DllName
        {
            get
            {
                return dllName;
            }
            set
            {
                dllName=value;
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
    }
}
