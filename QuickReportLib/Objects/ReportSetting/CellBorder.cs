using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FarPoint.Win;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// CellµÄ±ß¿ò¡£
    /// </summary>
    public class CellBorder
    {
        private bool left = false;
        private bool top = false;
        private bool right = false;
        private bool bottom = false;

        /// <summary>
        /// ×ó±ß¿ò¡£
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
        /// ÉÏ±ß¿ò¡£
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
        /// ÓÒ±ß¿ò¡£
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
        /// ÏÂ±ß¿ò¡£
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
