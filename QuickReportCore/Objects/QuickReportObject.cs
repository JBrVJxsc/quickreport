using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects
{
    /// <summary>
    /// ��ݱ���
    /// </summary>
    internal class QuickReportObject : BaseObject
    {
        private string type = string.Empty;
        /// <summary>
        /// ���
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
        /// ���ݡ�
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
        /// �Ƿ���Ч��
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
        /// �汾�š�
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
