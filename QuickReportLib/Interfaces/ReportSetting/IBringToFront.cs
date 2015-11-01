using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Interfaces.ReportSetting
{
    /// <summary>
    /// ϣ�����ؼ���ʾ����ǰ�ˣ�����Ҫʵ�ֵĽӿڡ�
    /// </summary>
    internal interface IBringToFront
    {
        /// <summary>
        /// ϣ�����ؼ���ʾ����ǰ�ˣ����������¼���
        /// </summary>
        event AskForBringToFrontHandle AskForBringToFront;
    }

    /// <summary>
    /// ϣ�����ؼ���ʾ����ǰ�ˣ���ִ�еķ�����
    /// </summary>
    /// <param name="sender">�¼�Դ��</param>
    /// <param name="e">�¼�������</param>
    public delegate void AskForBringToFrontHandle(object sender,EventArgs e);
}
