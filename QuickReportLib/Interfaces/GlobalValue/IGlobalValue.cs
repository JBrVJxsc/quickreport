using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.Objects;

namespace QuickReportLib.Interfaces.GlobalValue
{
    /// <summary>
    /// ȫ�ֱ�����ʵ�ִ˽ӿڡ�
    /// </summary>
    internal interface IGlobalValue
    {
        /// <summary>
        /// ȫ�ֱ������͡�
        /// </summary>
        GlobalValueType GlobalValueType
        {
            get;
        }

        /// <summary>
        /// SQL�������͡���
        /// </summary>
        SQLCodeType SQLCodeType
        {
            get;
        }

        /// <summary>
        /// ȫ�ֱ���ֵ�����͡�
        /// </summary>
        Type TypeOfValue
        {
            get;
        }

        /// <summary>
        /// ȫ�ֱ���ֵ��
        /// </summary>
        List<BaseObject> Value
        {
            get;
            set;
        }
    }
}
