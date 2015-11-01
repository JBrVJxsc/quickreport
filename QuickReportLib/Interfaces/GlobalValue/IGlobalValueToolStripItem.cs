using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.GlobalValue;

namespace QuickReportLib.Interfaces.GlobalValue
{
    /// <summary>
    /// ����ȫ�ֱ�����ToolStripItem��ʵ�ִ˽ӿڡ�
    /// </summary>
    internal interface IGlobalValueToolStripItem
    {
        /// <summary>
        /// ѡ��ȫ�ֱ���ֵʱ���������¼���
        /// </summary>
        event SelectedGlobalValueHandle SelectedGlobalValue;

        /// <summary>
        /// ToolStripSplitButton��������ȫ�ֱ������͡�
        /// </summary>
        GlobalValueType GlobalValueType
        {
            get;
            set;
        }

        /// <summary>
        /// ���IGlobalValue��
        /// </summary>
        /// <param name="globalValue">ȫ�ֱ�����</param>
        void SetGlobalValue(IGlobalValue globalValue); 
    }

    /// <summary>
    /// ѡ��ȫ�ֱ���ֵʱ��ִ�еķ�����
    /// </summary>
    /// <param name="sender">�¼�Դ��</param>
    /// <param name="globalValue">ȫ�ֱ���ֵ��</param>
    internal delegate void SelectedGlobalValueHandle(object sender, string globalValue);
}
