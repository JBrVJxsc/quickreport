using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// �п�ʵ�塣
    /// </summary>
    public class ColumnWidth
    {
        private int column = 0;
        private float width = Constants.Constants.HEADER_SETTING_COLUMN_WIDTH;

        /// <summary>
        /// ����š�
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
        /// �п�
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
