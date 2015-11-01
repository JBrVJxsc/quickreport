using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.Setting
{
    internal class CustomViewSetting
    {
        private int splitH = 180;
        /// <summary>
        /// ������ק���������ľ��롣
        /// </summary>
        public int SplitH
        {
            get
            {
                return splitH;
            }
            set
            {
                splitH = value;
            }
        }
        private int splitV = 360;
        /// <summary>
        /// ������ק������Ϸ���ľ��롣
        /// </summary>
        public int SplitV
        {
            get
            {
                return splitV;
            }
            set
            {
                splitV = value;
            }
        }
    }
}
