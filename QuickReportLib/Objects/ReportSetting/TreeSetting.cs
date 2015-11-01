using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// ������ʵ�塣
    /// </summary>
    public class TreeSetting
    {
        private string rootCode ="ALL";
        private string rootName = "ȫ��";
        private string nodeCode = string.Empty;
        private string nodeName = string.Empty;
        private string groupNodeCode = string.Empty;
        private string groupNodeName = string.Empty;
        private bool useMultiSelect = false;
        private string sql = string.Empty;

        /// <summary>
        /// ���ڵ���롣
        /// </summary>
        public string RootCode
        {
            get
            {
                return rootCode;
            }
            set
            {
                rootCode = value;
            }
        }

        /// <summary>
        /// ���ڵ����ơ�
        /// </summary>
        public string RootName
        {
            get
            {
                return rootName;
            }
            set
            {
                rootName = value;
            }
        }

        /// <summary>
        /// �ڵ���롣
        /// </summary>
        public string NodeCode
        {
            get
            {
                return nodeCode;
            }
            set
            {
                nodeCode = value;
            }
        }

        /// <summary>
        /// �ڵ����ơ�
        /// </summary>
        public string NodeName
        {
            get
            {
                return nodeName;
            }
            set
            {
                nodeName = value;
            }
        }

        /// <summary>
        /// ����ڵ���롣
        /// </summary>
        public string GroupNodeCode
        {
            get
            {
                return groupNodeCode;
            }
            set
            {
                groupNodeCode = value;
            }
        }

        /// <summary>
        /// ����ڵ����ơ�
        /// </summary>
        public string GroupNodeName
        {
            get
            {
                return groupNodeName;
            }
            set
            {
                groupNodeName = value;
            }
        }

        /// <summary>
        /// �ڵ��Ƿ���Զ�ѡ��
        /// </summary>
        public bool UseMultiSelect
        {
            get 
            {
                return useMultiSelect;
            }
            set
            {
                useMultiSelect = value;
            }
        }

        /// <summary>
        /// SQL��
        /// </summary>
        public string SQL
        {
            get
            {
                return sql;
            }
            set
            {
                sql = value;
            }
        }
    }
}
