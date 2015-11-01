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
    /// 斜线。
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
        /// 起点Cell的行序号。
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
        /// 起点Cell的列序号。
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
        /// 终点Cell的行序号。
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
        /// 终点Cell的列序号。
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
        /// 斜线种类。
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
        /// 绘制线。
        /// </summary>
        /// <param name="fpSpread">需要被绘制的fpSpread。</param>
        /// <param name="rowOffset">行偏移量。</param>
        public void DrawLine(FpSpread fpSpread, int rowOffset)
        {
            lineShape = new LineShapePlus();
            this.fpSpread = fpSpread;
            this.rowOffset = rowOffset;
            SetBounds(fpSpread,lineShape);
            fpSpread.ActiveSheet.AddShape(lineShape);
        }

        /// <summary>
        /// 重新绘制斜线。
        /// </summary>
        public void ReDraw()
        {
            Remove();
            DrawLine(fpSpread, rowOffset);
        }

        /// <summary>
        /// 移除斜线。
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
        /// 克隆。
        /// </summary>
        /// <returns>克隆斜线列表的实体。</returns>
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
