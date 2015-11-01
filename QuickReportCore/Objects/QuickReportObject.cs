using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects
{
    /// <summary>
    /// 快捷报表。
    /// </summary>
    internal class QuickReportObject : BaseObject
    {
        private string type = string.Empty;
        /// <summary>
        /// 类别。
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        private string content = string.Empty;
        /// <summary>
        /// 内容。
        /// </summary>
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }
        private string isvalid = "1";
        /// <summary>
        /// 是否有效。
        /// </summary>
        public string IsValid
        {
            get
            {
                return isvalid;
            }
            set
            {
                isvalid = value;
            }
        }

        private decimal version = 1.00m;
        /// <summary>
        /// 版本号。
        /// </summary>
        public decimal Version
        {
            get
            {
                return version;
            }
            set
            {
                version = value;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
