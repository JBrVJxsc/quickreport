using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Class
{
    /// <summary>
    /// 拥有自动转换功能的Cell。参见ValueTransType属性。
    /// </summary>
    internal class NumberCellTypePlus : FarPoint.Win.Spread.CellType.NumberCellType
    {
        private ValueTranslateType translateType = ValueTranslateType.不转换;
        /// <summary>
        /// Cell的转换方式。
        /// </summary>
        public ValueTranslateType ValueTransType
        {
            get
            {
                return translateType;
            }
            set
            {
                translateType = value;
            }
        }

        public override void PaintCell(System.Drawing.Graphics g, System.Drawing.Rectangle r, FarPoint.Win.Spread.Appearance appearance, object value, bool isSelected, bool isLocked, float zoomFactor)
        {
            switch (translateType)
            {
                case ValueTranslateType.不转换:
                    {
                        base.PaintCell(g, r, appearance, value, isSelected, isLocked, zoomFactor);
                        break;
                    }
                case ValueTranslateType.值为空时转换为零:
                    {
                        if (value == null)
                        {
                            value = 0;
                        }
                        base.PaintCell(g, r, appearance, value, isSelected, isLocked, zoomFactor);
                        break;
                    }
                case ValueTranslateType.值为零时转换为空:
                    {
                        if (Convert.ToDecimal(value) == 0)
                        {
                            value = null;
                        }
                        base.PaintCell(g, r, appearance, value, isSelected, isLocked, zoomFactor);
                        break;
                    }
            }
        }

        /// <summary>
        /// 值的转换类型。
        /// </summary>
        public enum ValueTranslateType
        {
            值为空时转换为零,
            值为零时转换为空,
            不转换
        }
    }
}
