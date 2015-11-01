using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FarPoint.Win.Spread;
using FarPoint.Win;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// Cell信息。
    /// </summary>
    public class CellInfo
    {
        private int row = 0;
        private int column = 0;
        private int rowSpan = 1;
        private int columnSpan = 1;
        private string text = string.Empty;
        private Font font = new Font("宋体", 9, FontStyle.Regular);
        private Color color = System.Drawing.Color.Black;
        private CellHorizontalAlignment hAligment = CellHorizontalAlignment.General;
        private CellVerticalAlignment vAligment = CellVerticalAlignment.General;
        private CellBorder cellBorder = new CellBorder();
        private static FontConverter fontConverter = new FontConverter();

        /// <summary>
        /// 行序号。
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
        /// 列序号。
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
        /// 行合并数。
        /// </summary>
        public int RowSpan
        {
            get
            {
                return rowSpan;
            }
            set
            {
                rowSpan = value;
            }
        }

        /// <summary>
        /// 列合并数。
        /// </summary>
        public int ColumnSpan
        {
            get
            {
                return columnSpan;
            }
            set
            {
                columnSpan = value;
            }
        }

        /// <summary>
        /// Cell上的字符。
        /// </summary>
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }

        /// <summary>
        /// 字体。
        /// </summary>
        public string Font
        {
            get
            {
                string fontString = fontConverter.ConvertToInvariantString(font);
                return fontString;
            }
            set
            {
                font = fontConverter.ConvertFromInvariantString(value) as Font;
            }
        }

        /// <summary>
        /// 颜色。
        /// </summary>
        public string Color
        {
            get
            {
                string colorString = ColorTranslator.ToHtml(color);
                return colorString;
            }
            set
            {
                color = ColorTranslator.FromHtml(value);
            }
        }

        /// <summary>
        /// 获取Cell的字体。
        /// </summary>
        /// <returns>字体。</returns>
        public Font GetFont()
        {
            return font;
        }

        /// <summary>
        /// 获取Cell的颜色。
        /// </summary>
        /// <returns>颜色。</returns>
        public Color GetColor()
        {
            return color;
        }

        /// <summary>
        /// 设置Cell的字体。
        /// </summary>
        /// <param name="font">字体。</param>
        public void SetFont(Font font)
        {
            if (font != null)
            {
                this.font = font;
            }
        }

        /// <summary>
        /// 设置Cell的颜色。
        /// </summary>
        /// <param name="color">颜色</param>
        public void SetColor(Color color)
        {
            if (color != null)
            {
                this.color = color;
            }
        }

        /// <summary>
        /// 横向对齐方式。
        /// </summary>
        public CellHorizontalAlignment HAligment
        {
            get
            {
                return hAligment;
            }
            set
            {
                hAligment = value;
            }
        }

        /// <summary>
        /// 纵向对齐方式。
        /// </summary>
        public CellVerticalAlignment VAligment
        {
            get
            {
                return vAligment;
            }
            set
            {
                vAligment = value;
            }
        }

        /// <summary>
        /// Cell的边框。
        /// </summary>
        public CellBorder CellBorder
        {
            get
            {
                return cellBorder;
            }
            set
            {
                cellBorder = value;
            }
        }

        /// <summary>
        /// 用Cell的信息填充CellInfo。
        /// </summary>
        /// <param name="cell">Cell的信息。</param>
        public void SetCellInfo(Cell cell)
        {
            row = cell.Row.Index;
            column = cell.Column.Index;
            rowSpan = cell.RowSpan;
            columnSpan = cell.ColumnSpan;
            SetColor(cell.ForeColor);
            SetFont(cell.Font);
            cellBorder.SetCellBorder(cell.Border as LineBorder);
            hAligment = cell.HorizontalAlignment;
            vAligment = cell.VerticalAlignment;
            if (cell.Value != null)
            {
                text = cell.Value.ToString();
            }
        }
    }
}
