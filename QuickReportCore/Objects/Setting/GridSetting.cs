using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.Setting
{
    internal class GridSetting
    {
        private string groupSumRow = string.Empty;
        /// <summary>
        /// 分组小计的行。
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

        private string rowGroupSumName = string.Empty;
        /// <summary>
        /// 分组小计的名称。
        /// </summary>
        public string RowGroupSumName
        {
            get
            {
                return rowGroupSumName;
            }
            set
            {
                rowGroupSumName = value;
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
        /// 是否使用分组独立样式。
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
