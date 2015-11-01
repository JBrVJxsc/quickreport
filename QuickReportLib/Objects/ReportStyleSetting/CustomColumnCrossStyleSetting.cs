using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.ReportStyles;

namespace QuickReportLib.Objects.ReportStyleSetting
{
    /// <summary>
    /// 自定义列交叉报表样式的设置实体。
    /// </summary>
    public class CustomColumnCrossStyleSetting : BaseStyleSetting
    {
        private string row = string.Empty;
        private string column = string.Empty;
        private string value = string.Empty;
        private string rowText = string.Empty;
        private string customColumnSQL = string.Empty;

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

        /// <summary>
        /// 值。
        /// </summary>
        public string Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        /// <summary>
        /// 行名称。
        /// </summary>
        public string RowText
        {
            get
            {
                return rowText;
            }
            set
            {
                rowText = value;
            }
        }

        /// <summary>
        /// 自定义列的SQL。
        /// </summary>
        public string CustomColumnSQL
        {
            get
            {
                return customColumnSQL;
            }
            set
            {
                customColumnSQL = value;
            }
        }
    }
}
