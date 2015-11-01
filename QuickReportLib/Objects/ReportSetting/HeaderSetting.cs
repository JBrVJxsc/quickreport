using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// 报表的表头设置实体。
    /// </summary>
    public class HeaderSetting
    {
        private HeaderTopSetting topSetting = new HeaderTopSetting();
        private HeaderBottomSetting bottomSetting = new HeaderBottomSetting();
        private int columnCount = 10;
        private float reportColumnHeight = Constants.Constants.HEADER_SETTING_ROW_HEIGHT;
        private List<ColumnWidth> columnWidthList = new List<ColumnWidth>();

        /// <summary>
        /// 主报表的上方表头设置实体。
        /// </summary>
        public HeaderTopSetting TopSetting
        {
            get
            {
                return topSetting;
            }
            set
            {
                topSetting = value;
            }
        }

        /// <summary>
        /// 主报表的下方表头设置实体。
        /// </summary>
        public HeaderBottomSetting BottomSetting
        {
            get
            {
                return bottomSetting;
            }
            set
            {
                bottomSetting = value;
            }
        }

        /// <summary>
        /// 列数。
        /// </summary>
        public int ColumnCount
        {
            get
            {
                return columnCount;
            }
            set
            {
                columnCount = value;
            }
        }

        /// <summary>
        /// 报表列的行高。
        /// </summary>
        public float ReportColumnHeight
        {
            get
            {
                return reportColumnHeight;
            }
            set
            {
                reportColumnHeight = value;
            }
        }

        /// <summary>
        /// 列宽。
        /// </summary>
        public List<ColumnWidth> ColumnWidthList
        {
            get
            {
                return columnWidthList;
            }
            set
            {
                columnWidthList = value;
            }
        }
    }
}
