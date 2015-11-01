using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FarPoint.Win;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// Cell�ı߿�
    /// </summary>
    public class CellBorder
    {
        private bool left = false;
        private bool top = false;
        private bool right = false;
        private bool bottom = false;

        /// <summary>
        /// ��߿�
        /// </summary>
        public bool Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

        /// <summary>
        /// �ϱ߿�
        /// </summary>
        public bool Top
        {
            get
            {
                return top;
            }
            set
            {
                top = value;
            }
        }

        /// <summary>
        /// �ұ߿�
        /// </summary>
        public bool Right
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }

        /// <summary>
        /// �±߿�
        /// </summary>
        public bool Bottom
        {
            get
            {
                return bottom;
            }
            set
            {
                bottom = value;
            }
        }

        public LineBorder GetBorder()
        {
            return new LineBorder(Color.Black, 1, left, top, right, bottom);
        }

        public void SetCellBorder(LineBorder lineBorder)
        {
            if (lineBorder == null)
            {
                return;
            }
            left = lineBorder.Left;
            top = lineBorder.Top;
            right = lineBorder.Right;
            bottom = lineBorder.Bottom;
        }
    }
}
