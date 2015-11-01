using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// ����ı�ͷ����ʵ�塣
    /// </summary>
    public class HeaderSetting
    {
        private HeaderTopSetting topSetting = new HeaderTopSetting();
        private HeaderBottomSetting bottomSetting = new HeaderBottomSetting();
        private int columnCount = 10;
        private float reportColumnHeight = Constants.Constants.HEADER_SETTING_ROW_HEIGHT;
        private List<ColumnWidth> columnWidthList = new List<ColumnWidth>();

        /// <summary>
        /// ��������Ϸ���ͷ����ʵ�塣
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
        /// ��������·���ͷ����ʵ�塣
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
        /// ������
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
        /// �����е��иߡ�
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
        /// �п�
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
