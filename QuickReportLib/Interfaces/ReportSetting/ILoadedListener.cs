using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Interfaces.ReportSetting
{
    /// <summary>
    /// ��Ҫ������ʼ�������¼��ĳ�Ա��ʵ�ִ˽ӿڡ�
    /// </summary>
    internal interface ILoadedListener
    {
        /// <summary>
        /// ��ʼ������ִ�еķ�����
        /// </summary>
        void Loaded();
    }
}
