using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Interfaces.ReportSetting
{
    /// <summary>
    /// ���ؼ����Լ������ֵ�ı䷽ʽʱ����ʵ�ִ˽ӿڡ�
    /// </summary>
    internal interface IChangedUserControl
    {
        /// <summary>
        /// ���������ý����е�ֵ�����ı�����������¼���
        /// </summary>
        event EventHandler Changed;
    }
}
