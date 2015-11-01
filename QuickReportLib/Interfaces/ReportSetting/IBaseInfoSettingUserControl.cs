using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Interfaces.GlobalValue;

namespace QuickReportLib.Interfaces.ReportSetting
{
    /// <summary>
    /// Report�Ļ�����Ϣ������ʵ�ִ˽ӿڡ�
    /// </summary>
    internal interface IBaseInfoSettingUserControl : IReportSettingUserControl , IGlobalValueProvider
    {
        /// <summary>
        /// ��ǰ�Ƿ��ڱ༭SQL״̬��
        /// </summary>
        bool IsEditingSQL
        {
            get;
        }
    }
}
