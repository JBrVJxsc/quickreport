using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Interfaces.GlobalValue
{
    /// <summary>
    /// ȫ�ֱ��������ߡ�
    /// </summary>
    internal interface IGlobalValueProvider
    {
        /// <summary>
        /// ȫ�ֱ����ı�ʱ���������¼���
        /// </summary>
        event GlobalValueChangedHandle GlobalValueChanged;
    }

    /// <summary>
    /// ȫ�ֱ������ʱ�����ķ�����
    /// </summary>
    /// <param name="sender">�¼�Դ��</param>
    /// <param name="globalValue">������ȫ�ֱ�����</param>
    internal delegate void GlobalValueChangedHandle(object sender,IGlobalValue globalValue);
}
