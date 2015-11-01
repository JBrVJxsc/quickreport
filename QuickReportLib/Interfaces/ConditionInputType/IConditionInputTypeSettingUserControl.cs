using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Objects.ConditionInputTypeSetting;
using QuickReportLib.Interfaces.ReportSetting;

namespace QuickReportLib.Interfaces.ConditionInputType
{
    /// <summary>
    /// IConditionInputType的设置界面，需实现此接口。
    /// </summary>
    public interface IConditionInputTypeSettingUserControl
    {
        /// <summary>
        /// 录入类型设置实体。
        /// </summary>
        BaseInputTypeSetting ConditionInputTypeSettingObject
        {
            get;
            set;
        }

        /// <summary>
        /// 检查录入。
        /// </summary>
        /// <returns>-1为失败；1为成功。</returns>
        int CheckInput();

        /// <summary>
        /// 希望将控件显示在最前端，所触发的事件。
        /// </summary>
        event AskForBringToFrontHandle AskForBringToFront;
    }
}
