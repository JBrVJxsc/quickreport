using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects
{
    /// <summary>
    /// ����ʵ���ࡣ
    /// </summary>
    public class BaseObject : IComparable
    {
        private string id = string.Empty;
        private string name = string.Empty;
        private int sortID = 0;

        public BaseObject()
        { 
            
        }

        /// <summary>
        /// ʵ����BaseObject��
        /// </summary>
        /// <param name="id">���롣</param>
        /// <param name="name">���ơ�</param>
        public BaseObject(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        /// <summary>
        /// ʵ����BaseObject��
        /// </summary>
        /// <param name="id">���롣</param>
        /// <param name="name">���ơ�</param>
        /// <param name="sortID">������š�</param>
        public BaseObject(string id, string name,int sortID)
        {
            this.id = id;
            this.name = name;
            this.sortID = sortID;
        }

        /// <summary>
        /// ���롣
        /// </summary>
        public virtual string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        } 

        /// <summary>
        /// ���ơ�
        /// </summary>
        public virtual string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// ������š�
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
        /// ��¡��
        /// </summary>
        /// <returns>��¡���ʵ�塣</returns>
        public virtual BaseObject Clone()
        {
            BaseObject baseObject = new BaseObject();
            baseObject.id = ID;
            baseObject.name = Name;
            baseObject.sortID = SortID;
            return baseObject;
        }

        public override string ToString()
        {
            return Name;
        }

        #region IComparable ��Ա

        int IComparable.CompareTo(object obj)
        {
            BaseObject baseObject = obj as BaseObject;
            if (sortID > baseObject.sortID)
                return 1;
            if (sortID < baseObject.sortID)
                return -1;
            return 0;
        }

        #endregion
    }
}
