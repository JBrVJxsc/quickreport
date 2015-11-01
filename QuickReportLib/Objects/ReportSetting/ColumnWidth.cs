using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// 列宽实体。
    /// </summary>
    public class ColumnWidth
    {
        private int column = 0;
        private float width = Constants.Constants.HEADER_SETTING_COLUMN_WIDTH;

        /// <summary>
        /// 列序号。
        /// </summary>
        public int Column
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
        /// 列宽。
        /// </summary>
        public float Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
    }
}
