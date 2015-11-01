using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.Setting
{
    internal class CustomViewSetting
    {
        private int splitH = 180;
        /// <summary>
        /// 横向拖拽框距离左方向的距离。
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
        /// 纵向拖拽框距离上方向的距离。
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
