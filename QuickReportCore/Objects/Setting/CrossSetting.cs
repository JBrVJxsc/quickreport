using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.Setting
{
    internal class CrossSetting
    {
        private string row = string.Empty;
        /// <summary>
        /// 行。
        /// </summary>
        public string Row
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
            }
        }

        private string column = string.Empty;
        /// <summary>
        /// 列。
        /// </summary>
        public string Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
            }
        }

        private string valueT = string.Empty;
        /// <summary>
        /// 值。
        /// </summary>
        public string Value
        {
            get
            {
                return valueT;
            }
            set
            {
                valueT = value;
            }
        }

        private string groupSumRow = string.Empty;
        /// <summary>
        /// 行小计。
        /// </summary>
        public string GroupSumRow
        {
            get
            {
                return groupSumRow;
            }
            set
            {
                groupSumRow = value;
            }
        }

        private string groupSumColumn = string.Empty;
        /// <summary>
        /// 列小计。
        /// </summary>
        public string GroupSumColumn
        {
            get
            {
                return groupSumColumn;
            }
            set
            {
                groupSumColumn = value;
            }
        } 

        private bool useCustomColumn = false;
        /// <summary>
        /// 是否使用自定义列。
        /// </summary>
        public bool UseCustomColumn
        {
            get
            {
                return useCustomColumn;
            }
            set
            {
                useCustomColumn = value;
            }
        }

        private bool useCustomRow = false;
        /// <summary>
        /// 是否使用自定义行。
        /// </summary>
        public bool UseCustomRow
        {
            get
            {
                return useCustomRow;
            }
            set
            {
                useCustomRow = value;
            }
        }

        private string sqlColumn = string.Empty;
        /// <summary>
        /// 自定义列SQL语句。
        /// </summary>
        public string ColumnSQL
        {
            get
            {
                return sqlColumn;
            }
            set
            {
                sqlColumn = value;
            }
        }


        private string sqlRow = string.Empty;
        /// <summary>
        /// 自定义行SQL语句。
        /// </summary>
        public string RowSQL
        {
            get
            {
                return sqlRow;
            }
            set
            {
                sqlRow = value;
            }
        }

        private string customColumnName = string.Empty;
        /// <summary>
        /// 自定义列。
        /// </summary>
        public string CustomColumnName
        {
            get
            {
                return customColumnName;
            }
            set
            {
                customColumnName = value;
            }
        }

        private string groupSumCustomColumn = string.Empty;
        /// <summary>
        /// 列小计的列。
        /// </summary>
        public string GroupSumCustomColumn
        {
            get
            {
                return groupSumCustomColumn;
            }
            set
            {
                groupSumCustomColumn = value;
            }
        }

        private string customRowName = string.Empty;
        /// <summary>
        /// 自定义行。
        /// </summary>
        public string CustomRowName
        {
            get
            {
                return customRowName;
            }
            set
            {
                customRowName = value;
            }
        }

        private string groupSumCustomRow = string.Empty;
        /// <summary>
        /// 行小计的列。
        /// </summary>
        public string GroupSumCustomRow
        {
            get
            {
                return groupSumCustomRow;
            }
            set
            {
                groupSumCustomRow = value;
            }
        }

        private string groupSumRowName = string.Empty;
        /// <summary>
        /// 行小计的名字。
        /// </summary>
        public string GroupSumRowName
        {
            get
            {
                return groupSumRowName;
            }
            set
            {
                groupSumRowName = value;
            }
        }

        private string groupSumColumnName = string.Empty;
        /// <summary>
        /// 列小计的名字。
        /// </summary>
        public string GroupSumColumnName
        {
            get
            {
                return groupSumColumnName;
            }
            set
            {
                groupSumColumnName = value;
            }
        }

        private string customColumnGroupSumName = string.Empty;
        /// <summary>
        /// 自定义列时，列小计的名字。
        /// </summary>
        public string CustomColumnGroupSumName
        {
            get
            {
                return customColumnGroupSumName;
            }
            set
            {
                customColumnGroupSumName = value;
            }
        }


        private bool useGroupSumRow = false;
        /// <summary>
        /// 是否使用行小计。
        /// </summary>
        public bool UseGroupSumRow
        {
            get
            {
                return useGroupSumRow;
            }
            set
            {
                useGroupSumRow = value;
            }
        }

        private bool useHeader = false;
        /// <summary>
        /// 是否使用独立分组样式。
        /// </summary>
        public bool UseHeader
        {
            get
            {
                return useHeader;
            }
            set
            {
                useHeader = value;
            }
        }

        private bool rowSum = false;
        /// <summary>
        /// 是否使用行合计。
        /// </summary>
        public bool RowSum
        {
            get
            {
                return rowSum;
            }
            set
            {
                rowSum = value;
            }
        }

        private bool columnSum = false;
        /// <summary>
        /// 是否使用列合计。
        /// </summary>
        public bool ColumnSum
        {
            get
            {
                return columnSum;
            }
            set
            {
                columnSum = value;
            }
        }

        private bool union = false;
        /// <summary>
        /// 是否合并同类项。
        /// </summary>
        public bool Union
        {
            get
            {
                return union;
            }
            set
            {
                union = value;
            }
        }
    }
}
