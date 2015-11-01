using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// �и�ʵ�塣
    /// </summary>
    public class RowHeight
    {
        private int row = 0;
        private float height = Constants.Constants.HEADER_SETTING_ROW_HEIGHT;

        /// <summary>
        /// ����š�
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
        /// �иߡ�
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
