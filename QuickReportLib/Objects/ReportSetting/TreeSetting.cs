using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// 树设置实体。
    /// </summary>
    public class TreeSetting
    {
        private string rootCode ="ALL";
        private string rootName = "全部";
        private string nodeCode = string.Empty;
        private string nodeName = string.Empty;
        private string groupNodeCode = string.Empty;
        private string groupNodeName = string.Empty;
        private bool useMultiSelect = false;
        private string sql = string.Empty;

        /// <summary>
        /// 根节点编码。
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
        /// 根节点名称。
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
        /// 节点编码。
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
        /// 节点名称。
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
        /// 分组节点编码。
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
        /// 分组节点名称。
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
        /// 节点是否可以多选。
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
        /// SQL。
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
