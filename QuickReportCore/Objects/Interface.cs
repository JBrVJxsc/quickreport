using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects
{
    internal class Interface : BaseObject, IComparable
    {
        private string interfaceName = string.Empty;
        /// <summary>
        /// 接口名称。
        /// </summary>
        public string InterfaceName
        {
            get
            {
                return interfaceName;
            }
            set
            {
                interfaceName = value;
            }
        }

        private string dllName = string.Empty;
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

        private string className = string.Empty;
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

        private string values = string.Empty;
        /// <summary>
        /// 值。
        /// </summary>
        public string Values
        {
            get
            {
                return values;
            }
            set
            {
                values = value;
            }
        }

        private int sortID = 0;
        /// <summary>
        /// 序号。
        /// </summary>
        public int SortID
        {
            get
            {
                return sortID;
            }
            set
            {
                sortID = value;
            }
        }

        /// <summary>
        /// 获得该类型的实例。
        /// </summary>
        public object Instance
        {
            get
            {
                return Managers.Functions.CreateInstance(DllName, ClassName);
            }
        }

        #region IComparable 成员

        public int CompareTo(object obj)
        {
            Interface c = obj as Interface;
            if (SortID > c.SortID)
                return 1;
            if (SortID < c.SortID)
                return -1;
            return 0;
        }

        #endregion
    }
}
