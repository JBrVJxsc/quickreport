using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects
{
    /// <summary>
    /// 基础实体类。
    /// </summary>
    internal class BaseObject
    {
        public BaseObject()
        { 
            
        }

        public BaseObject(string id, string name)
        {
            ID = id;
            Name = name;
        }

        private string id = string.Empty;
        /// <summary>
        /// 编码。
        /// </summary>
        public string ID
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
        private string name = string.Empty;
        /// <summary>
        /// 名称。
        /// </summary>
        public string Name
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

        public override string ToString()
        {
            return Name;
        }
    }
}
