using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;
using FarPoint.Win.Spread;
using QuickReportLib.Enums;

namespace QuickReportLib.Objects
{
    /// <summary>
    /// 列。
    /// </summary>
    public class Column : BaseObject 
    {
        private bool show = true;
        private bool columnTotalSum = false;
        private bool rowTotalSum = false;
        private bool sort = false;
        private bool filter = false;
        private float width = 90;
        private bool isNumber = false;
        private int decimalPlace = 2;
        private string groupName = string.Empty;
        private int groupIndex = 0;
        private Font font = new Font("宋体", 9, FontStyle.Regular);
        private Color color =System.Drawing.Color.Black;
        private CellHorizontalAlignment hAligment = CellHorizontalAlignment.Center;
        private CellVerticalAlignment vAligment = CellVerticalAlignment.Center;
        private Font headerFont = new Font("宋体", 9, FontStyle.Regular);
        private Color headerColor = System.Drawing.Color.Black;
        private CellHorizontalAlignment headerHAligment = CellHorizontalAlignment.Center;
        private CellVerticalAlignment headerVAligment = CellVerticalAlignment.Center;
        private bool merge = false;
        private ValueTranslateType valueTranslateType = ValueTranslateType.DoNothing;
        private static FontConverter fontConverter = new FontConverter();
        private Type dataType;

        /// <summary>
        /// 是否显示。
        /// </summary>
        public bool Show
        {
            get
            {
                return show;
            }
            set
            {
                show = value;
            }
        }

        /// <summary>
        /// 是否计算列合计。
        /// </summary>
        public bool ColumnTotalSum
        {
            get
            {
                return columnTotalSum;
            }
            set
            {
                columnTotalSum = value;
            }
        }

        /// <summary>
        /// 是否计算行合计。
        /// </summary>
        public bool RowTotalSum
        {
            get
            {
                return rowTotalSum;
            }
            set
            {
                rowTotalSum = value;
            }
        }

        /// <summary>
        /// 是否排序。
        /// </summary>
        public bool Sort
        {
            get
            {
                return sort;
            }
            set
            {
                sort = value;
            }
        }

        /// <summary>
        /// 是否过滤。
        /// </summary>
        public bool Filter
        {
            get
            {
                return filter;
            }
            set
            {
                filter = value;
            }
        }

        /// <summary>
        /// 列宽。
        /// </summary>
        public float Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        /// <summary>
        /// 是否是数字型的。
        /// </summary>
        public bool IsNumber
        {
            get
            {
                return isNumber;
            }
            set
            {
                isNumber = value;
            }
        }

        /// <summary>
        /// 保留小数点位数。
        /// </summary>
        public int DecimalPlace
        {
            get
            {
                return decimalPlace;
            }
            set
            {
                decimalPlace = value;
            }
        }

        /// <summary>
        /// 分组名称。
        /// </summary>
        public string GroupName
        {
            get
            {
                return groupName;
            }
            set
            {
                groupName = value;
            }
        }

        /// <summary>
        /// 分组序号。
        /// </summary>
        public int GroupIndex
        {
            get
            {
                return groupIndex;
            }
            set
            {
                groupIndex = value;
            }
        }

        /// <summary>
        /// 数据字体。
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
                font =fontConverter.ConvertFromInvariantString(value) as Font;
            }
        }

        /// <summary>
        /// 数据颜色。
        /// </summary>
        public string Color
        {
            get
            {
                string colorString=ColorTranslator.ToHtml(color);
                return colorString;
            }
            set
            {
                color = ColorTranslator.FromHtml(value);
            }
        }

        /// <summary>
        /// 数据横向对齐方式。
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
        /// 数据纵向对齐方式。
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
        /// 列头字体。
        /// </summary>
        public string HeaderFont
        {
            get
            {
                string fontString = fontConverter.ConvertToInvariantString(headerFont);
                return fontString;
            }
            set
            {
                headerFont = fontConverter.ConvertFromInvariantString(value) as Font;
            }
        }

        /// <summary>
        /// 列头颜色。
        /// </summary>
        public string HeaderColor
        {
            get
            {
                string colorString = ColorTranslator.ToHtml(headerColor);
                return colorString;
            }
            set
            {
                headerColor = ColorTranslator.FromHtml(value);
            }
        }

        /// <summary>
        /// 列头横向对齐方式。
        /// </summary>
        public CellHorizontalAlignment HeaderHAligment
        {
            get
            {
                return headerHAligment;
            }
            set
            {
                headerHAligment = value;
            }
        }

        /// <summary>
        /// 列头纵向对齐方式。
        /// </summary>
        public CellVerticalAlignment HeaderVAligment
        {
            get
            {
                return headerVAligment;
            }
            set
            {
                headerVAligment = value;
            }
        }

        /// <summary>
        /// 是否合并同类项。
        /// </summary>
        public bool Merge
        {
            get
            {
                return merge;
            }
            set
            {
                merge = value;
            }
        }

        /// <summary>
        /// 值的转换方式。
        /// </summary>
        public ValueTranslateType ValueTranslateType
        {
            get
            {
                return valueTranslateType;
            }
            set
            {
                valueTranslateType = value ;
            }
        }

        /// <summary>
        /// 数据类型。
        /// </summary>
        public string DataType
        {
            get
            {
                return dataType.FullName;
            }
            set
            {
                dataType = Type.GetType(value);
            }
        }

        /// <summary>
        /// 获取数据的字体。
        /// </summary>
        /// <returns>字体。</returns>
        public Font GetFont()
        {
            return font;
        }

        /// <summary>
        /// 获取数据的颜色。
        /// </summary>
        /// <returns>颜色。</returns>
        public Color GetColor()
        {
            return color;
        }

        /// <summary>
        /// 获取列头的字体。
        /// </summary>
        /// <returns>字体。</returns>
        public Font GetHeaderFont()
        {
            return headerFont;
        }

        /// <summary>
        /// 获取列头的颜色。
        /// </summary>
        /// <returns>颜色。</returns>
        public Color GetHeaderColor()
        {
            return headerColor;
        }

        /// <summary>
        /// 获取列的数据类型。
        /// </summary>
        /// <returns>数据类型。</returns>
        public Type GetDataType()
        {
            return dataType;
        }

        /// <summary>
        /// 设置数据的字体。
        /// </summary>
        /// <param name="font">字体。</param>
        public void SetFont(Font font)
        {
            this.font = font;
        }

        /// <summary>
        /// 设置数据的颜色。
        /// </summary>
        /// <param name="color">颜色。</param>
        public void SetColor(Color color)
        {
            this.color = color;
        }

        /// <summary>
        /// 设置列头的字体。
        /// </summary>
        /// <param name="font">字体。</param>
        public void SetHeaderFont(Font font)
        {
            headerFont = font;
        }

        /// <summary>
        /// 设置列头的颜色。
        /// </summary>
        /// <param name="color">颜色。</param>
        public void SetHeaderColor(Color color)
        {
            headerColor = color;
        }

        /// <summary>
        /// 设置列的数据类型。
        /// </summary>
        /// <param name="type">数据类型。</param>
        public void SetDataType(Type dataType)
        {
            this.dataType = dataType;
        }

        public override BaseObject Clone()
        {
            Column column = new Column();
            column.ID = ID;
            column.Name = Name;
            column.SortID = SortID;
            column.show = show;
            column.columnTotalSum = columnTotalSum;
            column.rowTotalSum = rowTotalSum;
            column.sort = sort;
            column.filter = filter;
            column.width = width;
            column.isNumber = isNumber;
            column.decimalPlace = decimalPlace;
            column.groupName = groupName;
            column.groupIndex = groupIndex;
            column.font = font;
            column.color = color;
            column.hAligment = hAligment;
            column.vAligment = vAligment;
            column.headerFont = headerFont;
            column.headerColor = headerColor;
            column.headerHAligment = headerHAligment;
            column.headerVAligment = headerVAligment;
            column.merge = merge;
            column.valueTranslateType = valueTranslateType;
            column.dataType = dataType;
            return column;
        }
    }
}
