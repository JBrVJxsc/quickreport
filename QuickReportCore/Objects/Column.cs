using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace QuickReportCore.Objects
{
    /// <summary>
    /// 列。
    /// </summary>
    internal class Column : BaseObject, IComparable
    {
        private bool isNumber = false;
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

        private bool use = true;
        /// <summary>
        /// 是否使用。
        /// </summary>
        public bool Use
        {
            get
            {
                return use;
            }
            set
            {
                use = value;
            }
        }
        private bool totalColumn = false;
        /// <summary>
        /// 是否计算列合计。
        /// </summary>
        public bool TotalColumn
        {
            get
            {
                return totalColumn;
            }
            set
            {
                totalColumn = value;
            }
        }

        private bool totalRow = false;
        /// <summary>
        /// 是否计算行合计。
        /// </summary>
        public bool TotalRow
        {
            get
            {
                return totalRow;
            }
            set
            {
                totalRow = value;
            }
        }

        private bool sort = false;
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
        private bool filter = false;
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
        private int sortId = 0;
        /// <summary>
        /// 排列序号。
        /// </summary>
        public int SortId
        {
            get
            {
                return sortId;
            }
            set
            {
                sortId = value;
            }
        }

        private float width = 90;
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

        private int decimalPlace = 2;
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

        private string groupName = string.Empty;
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

        private int groupIndex = 0;
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

        public override string ToString()
        {
            return Name;
        }

        private System.Drawing.Font font = new System.Drawing.Font("宋体", 9, System.Drawing.FontStyle.Regular);
        /// <summary>
        /// 字体。
        /// </summary>
        public System.Drawing.Font Font
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
            }
        }
        private System.Drawing.Color color=System.Drawing.Color.Black;
        public System.Drawing.Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        private FarPoint.Win.Spread.CellHorizontalAlignment hAligment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
        /// <summary>
        /// 横向对齐方式。
        /// </summary>
        public FarPoint.Win.Spread.CellHorizontalAlignment HAligment
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

        private FarPoint.Win.Spread.CellVerticalAlignment vAligment = FarPoint.Win.Spread.CellVerticalAlignment.General;
        /// <summary>
        /// 纵向对齐方式。
        /// </summary>
        public FarPoint.Win.Spread.CellVerticalAlignment VAligment
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

        private bool union = false;
        /// <summary>
        /// 是否合并同类项。
        /// </summary>
        public bool Union
        {
            get
            {
                return union;
            }
            set
            {
                union = value;
            }
        }

        private QuickReportCore.Class.NumberCellTypePlus.ValueTranslateType valueTranslateType = QuickReportCore.Class.NumberCellTypePlus.ValueTranslateType.不转换;
        /// <summary>
        /// 值得转换方式。
        /// </summary>
        public QuickReportCore.Class.NumberCellTypePlus.ValueTranslateType ValueTransType
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

        public Column Clone()
        {
            Column c = new Column();
            c.IsNumber = IsNumber;
            c.ID = ID;
            c.Name = Name;
            c.Use = Use;
            c.Sort = Sort;
            c.TotalColumn = TotalColumn;
            c.TotalRow = TotalRow;
            c.Filter = Filter;
            c.SortId = SortId;
            c.DecimalPlace = DecimalPlace;
            c.Width = Width;
            c.GroupName = GroupName;
            c.GroupIndex = GroupIndex;
            c.Font = Font;
            c.Color = Color;
            c.HAligment = HAligment;
            c.VAligment = VAligment;
            c.Union = Union;
            c.ValueTransType = ValueTransType;
            return c;
        }

        #region IComparable 成员

        public int CompareTo(object obj)
        {
            Column c = obj as Column;
            if (SortId > c.SortId)
                return 1;
            if (SortId < c.SortId)
                return -1;
            return 0;
        }

        #endregion
    }
}
