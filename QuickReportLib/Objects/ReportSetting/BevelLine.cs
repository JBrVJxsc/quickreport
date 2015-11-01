using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.DrawingSpace;
using QuickReportLib.Enums;
using QuickReportLib.Class.Fp;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// б�ߡ�
    /// </summary>
    public class BevelLine
    {
        private int startCellRow = 0;
        private int startCellColumn = 0;
        private int endCellRow = 0;
        private int endCellColumn = 0;
        private int rowOffset=0;
        private BevelLineType bevelLineType = BevelLineType.Down;
        private LineShapePlus lineShape;
        private FpSpread fpSpread;

        /// <summary>
        /// ���Cell������š�
        /// </summary>
        public int StartCellRow
        {
            get
            {
                return startCellRow;
            }
            set
            {
                startCellRow = value;
            }
        }

        /// <summary>
        /// ���Cell������š�
        /// </summary>
        public int StartCellColumn
        {
            get
            {
                return startCellColumn;
            }
            set
            {
                startCellColumn = value;
            }
        }

        /// <summary>
        /// �յ�Cell������š�
        /// </summary>
        public int EndCellRow
        {
            get
            {
                return endCellRow;
            }
            set
            {
                endCellRow = value;
            }
        }

        /// <summary>
        /// �յ�Cell������š�
        /// </summary>
        public int EndCellColumn
        {
            get
            {
                return endCellColumn;
            }
            set
            {
                endCellColumn = value;
            }
        }

        /// <summary>
        /// б�����ࡣ
        /// </summary>
        public BevelLineType BevelLineType
        {
            get
            {
                return bevelLineType;
            }
            set
            {
                bevelLineType = value;
            }
        }

        /// <summary>
        /// �����ߡ�
        /// </summary>
        /// <param name="fpSpread">��Ҫ�����Ƶ�fpSpread��</param>
        /// <param name="rowOffset">��ƫ������</param>
        public void DrawLine(FpSpread fpSpread, int rowOffset)
        {
            lineShape = new LineShapePlus();
            this.fpSpread = fpSpread;
            this.rowOffset = rowOffset;
            SetBounds(fpSpread,lineShape);
            fpSpread.ActiveSheet.AddShape(lineShape);
        }

        /// <summary>
        /// ���»���б�ߡ�
        /// </summary>
        public void ReDraw()
        {
            Remove();
            DrawLine(fpSpread, rowOffset);
        }

        /// <summary>
        /// �Ƴ�б�ߡ�
        /// </summary>
        public void Remove()
        {
            fpSpread.ActiveSheet.RemoveShape(lineShape.Name);
        }

        private void SetBounds(FpSpread fpSpread,LineShape lineShape)
        {
            Rectangle startCellRectangle = GetCellRectangle(fpSpread,startCellRow + rowOffset, startCellColumn);
            Rectangle endCellRectangle = GetCellRectangle(fpSpread,endCellRow + rowOffset, endCellColumn);
            int x = startCellRectangle.X;
            int y = startCellRectangle.Y;
            int width = endCellRectangle.Right - startCellRectangle.Left;
            int height = endCellRectangle.Bottom - startCellRectangle.Top;
            lineShape.SetBounds(x, y, width, height);
            if (bevelLineType == BevelLineType.Up)
            {
                lineShape.SetBounds(x, y + height, width, height);
                float tan = (float)height / (float)width;
                double rotate = Math.Atan2(height, width) * 180 / Math.PI;
                lineShape.Rotate(lineShape.Location, -2 * (float)rotate);
            }
        }

        private Rectangle GetCellRectangle(FpSpread fpSpread , int row, int column)
        {
            SheetView sheet = fpSpread.ActiveSheet;
            float x = 0;
            float y = 0;
            for (int i = 0; i < column; i++)
            {
                x += sheet.Columns[i].Width;
            }
            for (int i = 0; i < row; i++)
            {
                y += sheet.Rows[i].Height;
            }
            Rectangle rectangle = new Rectangle((int)x, (int)y, (int)sheet.Columns[column].Width, (int)sheet.Rows[row].Height);
            return rectangle;
        }

        /// <summary>
        /// ��¡��
        /// </summary>
        /// <returns>��¡б���б��ʵ�塣</returns>
        public BevelLine Clone()
        {
            BevelLine bevelLine = new BevelLine();
            bevelLine.startCellRow = startCellRow;
            bevelLine.startCellColumn = startCellColumn;
            bevelLine.endCellRow = endCellRow;
            bevelLine.endCellColumn = endCellColumn;
            bevelLine.rowOffset = rowOffset;
            bevelLine.bevelLineType = bevelLineType;
            bevelLine.lineShape = lineShape;
            bevelLine.fpSpread = fpSpread;
            return bevelLine;
        }
    }
}
