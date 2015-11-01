using System;
using System.Collections.Generic;
using System.Text;
using FarPoint.Win.Spread.CellType;
using QuickReportLib.Enums;

namespace QuickReportLib.Class.Fp
{
    /// <summary>
    /// ӵ���Զ�ת�����ܵ�Cell���μ�ValueTransType���ԡ�
    /// </summary>
    internal class NumberCellTypePlus : NumberCellType
    {
        private ValueTranslateType valueTranslateType = ValueTranslateType.DoNothing;
        /// <summary>
        /// ֵ��ת����ʽ��
        /// </summary>
        public ValueTranslateType ValueTranslateType
        {
            get
            {
                return valueTranslateType;
            }
            set
            {
                valueTranslateType = value;
            }
        }

        public override void PaintCell(System.Drawing.Graphics g, System.Drawing.Rectangle r, FarPoint.Win.Spread.Appearance appearance, object value, bool isSelected, bool isLocked, float zoomFactor)
        {
            switch (valueTranslateType)
            {
                case ValueTranslateType.DoNothing:
                    {
                        base.PaintCell(g, r, appearance, value, isSelected, isLocked, zoomFactor);
                        break;
                    }
                case ValueTranslateType.BeZeroWhenNull:
                    {
                        if (value == null)
                        {
                            value = 0;
                        }
                        base.PaintCell(g, r, appearance, value, isSelected, isLocked, zoomFactor);
                        break;
                    }
                case ValueTranslateType.BeNullWhenZero:
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
    }
}
