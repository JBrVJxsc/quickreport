using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Enums
{
    /// <summary>
    /// ������¼�����͡�
    /// </summary>
    internal enum ConditionInputType
    {
        /// <summary>
        /// �ַ���
        /// </summary>
        Text,
        /// <summary>
        /// ���֣�Int����
        /// </summary>
        NumeralInt,
        /// <summary>
        /// ���֣�Decimal����
        /// </summary>
        NumeralDecimal,
        /// <summary>
        /// ���ڡ�
        /// </summary>
        Date,
        /// <summary>
        /// ����ʱ�䡣
        /// </summary>
        DateTime,
        /// <summary>
        /// ������
        /// </summary>
        ComboBox
    }
}
