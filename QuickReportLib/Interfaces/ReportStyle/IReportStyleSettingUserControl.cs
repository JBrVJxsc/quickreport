using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Objects.ReportStyleSetting;
using QuickReportLib.Interfaces.ReportSetting;

namespace QuickReportLib.Interfaces.ReportStyle
{
    /// <summary>
    /// ������ʽ���ý�����ʵ�ִ˽ӿڡ�
    /// </summary>
    public interface IReportStyleSettingUserControl : IReportSettingUserControl
    {
        /// <summary>
        /// ������ʽ����ʵ�塣
        /// </summary>
        BaseStyleSetting StyleSettingObject
        {
            get;
            set;
        }
    }
}
