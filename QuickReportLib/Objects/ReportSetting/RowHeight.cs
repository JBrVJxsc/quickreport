using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// 行高实体。
    /// </summary>
    public class RowHeight
    {
        private int row = 0;
        private float height = Constants.Constants.HEADER_SETTING_ROW_HEIGHT;

        /// <summary>
        /// 行序号。
        /// </summary>
        public int Row
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
        /// 行高。
        /// </summary>
        public float Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
    }
}
