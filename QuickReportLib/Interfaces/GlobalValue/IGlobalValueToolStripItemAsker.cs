using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;

namespace QuickReportLib.Interfaces.GlobalValue
{
    /// <summary>
    /// �������ȫ�ֱ�����ToolStripItem������ʵ�ִ˽ӿڡ�
    /// </summary>
    internal interface IGlobalValueToolStripItemAsker
    {
        /// <summary>
        /// ����Ҫʹ�ð���ȫ�ֱ�����ToolStripItemʱ�������¼���
        /// </summary>
        event AskForGlobalValueToolStripItemHandle AskForGlobalValueToolStripItem;

        /// <summary>
        /// ��ȡȫ�ֱ�����
        /// </summary>
        /// <param name="globalValue">ȫ�ֱ���ֵ��</param>
        void SetGlobalValue(string globalValue);
    }

    /// <summary>
    /// ����Ҫʹ�ð���ȫ�ֱ�����ToolStripItemʱ�����ķ�����
    /// </summary>
    /// <param name="sender">�¼�Դ��</param>
    /// <param name="globalValueTypes">ȫ�ֱ������͡�</param>
    internal delegate void AskForGlobalValueToolStripItemHandle(IGlobalValueToolStripItemAsker iGlobalValueToolStripItemAsker, List<GlobalValueType> globalValueTypes);
}
