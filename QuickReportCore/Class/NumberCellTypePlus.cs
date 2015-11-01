using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Class
{
    /// <summary>
    /// ӵ���Զ�ת�����ܵ�Cell���μ�ValueTransType���ԡ�
    /// </summary>
    internal class NumberCellTypePlus : FarPoint.Win.Spread.CellType.NumberCellType
    {
        private ValueTranslateType translateType = ValueTranslateType.��ת��;
        /// <summary>
        /// Cell��ת����ʽ��
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
                case ValueTranslateType.��ת��:
                    {
                        base.PaintCell(g, r, appearance, value, isSelected, isLocked, zoomFactor);
                        break;
                    }
                case ValueTranslateType.ֵΪ��ʱת��Ϊ��:
                    {
                        if (value == null)
                        {
                            value = 0;
                        }
                        base.PaintCell(g, r, appearance, value, isSelected, isLocked, zoomFactor);
                        break;
                    }
                case ValueTranslateType.ֵΪ��ʱת��Ϊ��:
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
        /// ֵ��ת�����͡�
        /// </summary>
        public enum ValueTranslateType
        {
            ֵΪ��ʱת��Ϊ��,
            ֵΪ��ʱת��Ϊ��,
            ��ת��
        }
    }
}
