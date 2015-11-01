using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Objects;

namespace QuickReportLib.Interfaces.ReportSetting
{
    /// <summary>
    /// 条件设置界面需实现此接口。
    /// </summary>
    internal interface IConditionSettingUserControl : IReportSettingUserControl, IGlobalValueProvider
    {

    }
}
