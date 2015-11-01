using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// 报表的上方表头设置实体。
    /// </summary>
    public class HeaderTopSetting
    {
        private int rowCount = 5;
        private List<CellInfo> cellInfoList = new List<CellInfo>();
        private List<BevelLine> bevelLineList = new List<BevelLine>();
        private List<RowHeight> rowHeightList = new List<RowHeight>();

        /// <summary>
        /// 行数。
        /// </summary>
        public int RowCount
        {
            get
            {
                return rowCount;
            }
            set
            {
                rowCount = value;
            }
        }

        /// <summary>
        /// CellInfo列表。
        /// </summary>
        public List<CellInfo> CellInfoList
        {
            get
            {
                return cellInfoList;
            }
            set
            {
                cellInfoList = value;
            }
        }

        /// <summary>
        /// 斜线列表。
        /// </summary>
        public List<BevelLine> BevelLineList
        {
            get
            {
                return bevelLineList;
            }
            set
            {
                bevelLineList = value;
            }
        }

        /// <summary>
        /// 行高。
        /// </summary>
        public List<RowHeight> RowHeightList
        {
            get
            {
                return rowHeightList;
            }
            set
            {
                rowHeightList = value;
            }
        }
    }
}
