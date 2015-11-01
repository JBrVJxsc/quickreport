using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Interfaces.ReportUserControl
{
    /// <summary>
    /// ��������ϵĿؼ���Ҫ������ѯʱ��ʵ�ֵĽӿڡ�
    /// </summary>
    internal interface ISendQueryCommandUserControl
    {
        /// <summary>
        /// ����Ҫ���������в�ѯʱ�����������¼���
        /// </summary>
        event SendQueryCommandHandle Query;
    }

    /// <summary>
    /// ���ؼ���Ҫ���������в�ѯʱ����ִ�еķ�����
    /// </summary>
    /// <param name="sender">�¼�Դ��</param>
    internal delegate void SendQueryCommandHandle(object sender);
}
