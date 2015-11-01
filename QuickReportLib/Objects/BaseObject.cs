using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects
{
    /// <summary>
    /// 基础实体类。
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
        /// 实例化BaseObject。
        /// </summary>
        /// <param name="id">编码。</param>
        /// <param name="name">名称。</param>
        public BaseObject(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        /// <summary>
        /// 实例化BaseObject。
        /// </summary>
        /// <param name="id">编码。</param>
        /// <param name="name">名称。</param>
        /// <param name="sortID">排列序号。</param>
        public BaseObject(string id, string name,int sortID)
        {
            this.id = id;
            this.name = name;
            this.sortID = sortID;
        }

        /// <summary>
        /// 编码。
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
        /// 名称。
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
        /// 排列序号。
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
        /// 克隆。
        /// </summary>
        /// <returns>克隆后的实体。</returns>
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

        #region IComparable 成员

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
