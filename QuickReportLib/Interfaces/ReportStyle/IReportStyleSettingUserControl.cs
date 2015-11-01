using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Objects.ReportStyleSetting;
using QuickReportLib.Interfaces.ReportSetting;

namespace QuickReportLib.Interfaces.ReportStyle
{
    /// <summary>
    /// 报表样式设置界面需实现此接口。
    /// </summary>
    public interface IReportStyleSettingUserControl : IReportSettingUserControl
    {
        /// <summary>
        /// 报表样式设置实体。
        /// </summary>
        BaseStyleSetting StyleSettingObject
        {
            get;
            set;
        }
    }
}
