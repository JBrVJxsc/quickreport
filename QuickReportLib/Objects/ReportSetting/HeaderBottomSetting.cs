using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// ������·���ͷ����ʵ�塣
    /// </summary>
    public class HeaderBottomSetting
    {
        private int rowCount = 5;
        private List<CellInfo> cellInfoList = new List<CellInfo>();
        private List<BevelLine> bevelLineList = new List<BevelLine>();
        private List<RowHeight> rowHeightList = new List<RowHeight>();

        /// <summary>
        /// ������
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
        /// CellInfo�б�
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
        /// б���б�
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
        /// �иߡ�
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
