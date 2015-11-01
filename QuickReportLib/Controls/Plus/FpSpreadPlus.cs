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
    /// �Զ����FpSpread������һЩԭ��δ�еĹ��ܡ�
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
        /// Cell�Ƿ��ڱ༭״̬��
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
        /// �Ƿ�����ColumnHeader�������
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
        /// �Ƿ�����RowHeader�������
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
        /// �Ƿ�����CornerHeader�������
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
        /// ��ȡ����Ļ����ʾ������
        /// </summary>
        /// <returns>����Ļ����ʾ������</returns>
        public Rectangle GetScreenRectangle()
        {
            Point point = PointToScreen(basePoint);
            Rectangle rectangle = new Rectangle(point, Size);
            return rectangle;
        }

        /// <summary>
        /// ��ȡCell����Ļ����ʾ������
        /// </summary>
        /// <param name="rowIndex">����š�</param>
        /// <param name="columnIndex">����š�</param>
        /// <returns>Cell����Ļ����ʾ������</returns>
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
