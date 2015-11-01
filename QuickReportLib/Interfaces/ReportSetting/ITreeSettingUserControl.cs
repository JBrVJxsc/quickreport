using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Interfaces.GlobalValue;

namespace QuickReportLib.Interfaces.ReportSetting
{
    /// <summary>
    /// 树设置控件应实现此接口。
    /// </summary>
    internal interface ITreeSettingUserControl : IReportSettingUserControl  ,IGlobalValueProvider
    {

    }
}
