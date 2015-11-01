using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Interfaces.GlobalValue;

namespace QuickReportLib.Interfaces.ReportSetting
{
    /// <summary>
    /// Report的基础信息设置需实现此接口。
    /// </summary>
    internal interface IBaseInfoSettingUserControl : IReportSettingUserControl , IGlobalValueProvider
    {
        /// <summary>
        /// 当前是否处于编辑SQL状态。
        /// </summary>
        bool IsEditingSQL
        {
            get;
        }
    }
}
