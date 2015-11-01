using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Interfaces
{
    /// <summary>
    /// ����״̬�����ݵİ�������ʾ���ݣ���ʵ�ִ˽ӿڡ�
    /// </summary>
    public interface IShowStatusStripHelp
    {
        /// <summary>
        /// ����״̬������ʾ����ʱ���������¼���
        /// </summary>
        event ShowStatusStripHelpHandle ShowStatusStripHelp;
    }

    /// <summary>
    /// ����״̬������ʾ����ʱ�������ķ�����
    /// </summary>
    /// <param name="sender">�¼�Դ��</param>
    /// <param name="helpContent">��״̬������ʾ�����ݡ�</param>
    public delegate void ShowStatusStripHelpHandle(object sender , string helpContent);
}
