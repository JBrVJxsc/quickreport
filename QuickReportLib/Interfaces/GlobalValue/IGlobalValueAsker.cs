using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;

namespace QuickReportLib.Interfaces.GlobalValue
{
    /// <summary>
    /// ��Ҫ���µ�ȫ�ֱ���������ʵ�ִ˽ӿڡ�
    /// </summary>
    internal interface IGlobalValueAsker
    {
        /// <summary>
        /// �����ȫ�ֱ������͡�
        /// </summary>
        List<GlobalValueType> GlobalValueTypes
        {
            get;
        }

        /// <summary>
        /// ����ȫ�ֱ�����
        /// </summary>
        /// <param name="globalValue">ȫ�ֱ�����</param>
        void SetGlobalValue(IGlobalValue globalValue);
    }
}
