using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Interfaces.GlobalValue;

namespace QuickReportLib.Interfaces.ReportSetting
{
    /// <summary>
    /// 明细报表设置需实现此接口。
    /// </summary>
    internal interface IDetailReportSettingUserControl : IReportSettingUserControl , IGlobalValueAsker
    {

    }
}
