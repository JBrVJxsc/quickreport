using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects
{
    internal class Interface : BaseObject, IComparable
    {
        private string interfaceName = string.Empty;
        /// <summary>
        /// �ӿ����ơ�
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

        private string className = string.Empty;
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

        private string values = string.Empty;
        /// <summary>
        /// ֵ��
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
        /// ��š�
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
        /// ��ø����͵�ʵ����
        /// </summary>
        public object Instance
        {
            get
            {
                return Managers.Functions.CreateInstance(DllName, ClassName);
            }
        }

        #region IComparable ��Ա

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
