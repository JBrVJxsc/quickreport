using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// ISystemValueʵ����ʵ�塣
    /// </summary>
    public class ISystemValueImplementor : BaseObject
    {
        private string dllName = string.Empty;
        private string className = string.Empty;

        /// <summary>
        /// Dll���ơ�
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
        /// ʵ�ֽӿڵ�������ơ�
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
