using System;

namespace QuickReportLib.Enums
{
    /// <summary>
    /// NumberCellType��ֵ�Զ�ת����ʽ��
    /// </summary>
    public enum ValueTranslateType
    {
        /// <summary>
        /// ֵΪ��ʱת��Ϊ�㡣
        /// </summary>
        BeZeroWhenNull,
        /// <summary>
        /// ֵΪ��ʱת��Ϊ�ա�
        /// </summary>
        BeNullWhenZero,
        /// <summary>
        /// ��ת����
        /// </summary>
        DoNothing
    }
}
