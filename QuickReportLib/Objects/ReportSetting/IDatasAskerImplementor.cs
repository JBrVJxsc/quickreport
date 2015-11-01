using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Managers;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// IDatasAskerʵ����ʵ�塣
    /// </summary>
    public class IDatasAskerImplementor : BaseObject
    {
        private string dllName = string.Empty;
        private string className = string.Empty;
        private string value = string.Empty;

        /// <summary>
        /// ʵ��������Dll���ơ�
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

        /// <summary>
        /// ��Ҫ�ӱ����л�ȡ��ֵ��
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
        /// ��ø����͵�ʵ����
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
