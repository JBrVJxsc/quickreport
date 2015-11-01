using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using FarPoint.Win.Spread;

namespace QuickReportLib.Controls.Plus
{
    /// <summary>
    /// 自定义的FpSpread，增加一些原来未有的功能。
    /// </summary>
    internal partial class FpSpreadPlus : FpSpread
    {
        public FpSpreadPlus()
        {
            InitializeComponent();
        }

        private bool isEditing = false;
        private Point basePoint = new Point(0, 0);
        private bool allowColumnHeaderClick = true;
        private bool allowRowHeaderClick = true;
        private bool allowCornerHeaderClick = true;

        /// <summary>
        /// Cell是否处于编辑状态。
        /// </summary>
        public bool IsEditing
        {
            get
            {
                return isEditing;
            }
            set
            {
                isEditing = value;
            }
        }

        /// <summary>
        /// 是否允许ColumnHeader被点击。
        /// </summary>
        public bool AllowColumnHeaderClick
        {
            get
            {
                return allowColumnHeaderClick;
            }
            set
            {
                allowColumnHeaderClick = value;
            }
        }

        /// <summary>
        /// 是否允许RowHeader被点击。
        /// </summary>
        public bool AllowRowHeaderClick
        {
            get
            {
                return allowRowHeaderClick;
            }
            set
            {
                allowRowHeaderClick = value;
            }
        }

        /// <summary>
        /// 是否允许CornerHeader被点击。
        /// </summary>
        public bool AllowCornerHeaderClick
        {
            get
            {
                return allowCornerHeaderClick;
            }
            set
            {
                allowCornerHeaderClick = value;
            }
        }

        protected override void OnCellClick(CellClickEventArgs e)
        {
            if (e.ColumnHeader&&!e.RowHeader&&!allowColumnHeaderClick)
            {
                e.Cancel = true;
            }
            else if (!e.ColumnHeader&&e.RowHeader && !allowRowHeaderClick)
            {
                e.Cancel = true;
            }
            else if (e.ColumnHeader && e.RowHeader && !allowCornerHeaderClick)
            {
                e.Cancel = true;
            }
            base.OnCellClick(e);
        }

        protected override void OnCellDoubleClick(CellClickEventArgs e)
        {
            if (e.ColumnHeader && !e.RowHeader && !allowColumnHeaderClick)
            {
                e.Cancel = true;
            }
            else if (!e.ColumnHeader && e.RowHeader && !allowRowHeaderClick)
            {
                e.Cancel = true;
            }
            else if (e.ColumnHeader && e.RowHeader && !allowCornerHeaderClick)
            {
                e.Cancel = true;
            }
            base.OnCellDoubleClick(e);
        }

        protected override void OnEditModeOn(EventArgs e)
        {
            isEditing = true;
            base.OnEditModeOn(e);
        }

        protected override void OnEditModeOff(EventArgs e)
        {
            isEditing = false;
            base.OnEditModeOff(e);
        }

        /// <summary>
        /// 获取在屏幕上显示的区域。
        /// </summary>
        /// <returns>在屏幕上显示的区域。</returns>
        public Rectangle GetScreenRectangle()
        {
            Point point = PointToScreen(basePoint);
            Rectangle rectangle = new Rectangle(point, Size);
            return rectangle;
        }

        /// <summary>
        /// 获取Cell在屏幕上显示的区域。
        /// </summary>
        /// <param name="rowIndex">行序号。</param>
        /// <param name="columnIndex">列序号。</param>
        /// <returns>Cell在屏幕上显示的区域</returns>
        public Rectangle GetCellScreenRectangle(int rowIndex,int columnIndex)
        {
            Rectangle rectangle = GetCellRectangle(0, 0, rowIndex, columnIndex);
            Point point = new Point(rectangle.Location.X, rectangle.Location.Y);
            point = PointToScreen(point);
            rectangle = new Rectangle(point, rectangle.Size);
            return rectangle;
        }
    }
}
