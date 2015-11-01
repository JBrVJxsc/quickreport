using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects.ConditionInputTypeSetting;

namespace QuickReportLib.Interfaces.ConditionInputType
{
    /// <summary>
    /// 条件的录入类型需实现此接口。
    /// </summary>
    public interface IConditionInputType
    {
        /// <summary>
        /// 获得录入类型的名称。
        /// </summary>
        /// <returns>录入类型的名称。</returns>
        string GetConditionInputTypeName();

        /// <summary>
        /// 获得录入类型简介。
        /// </summary>
        /// <returns>录入类型的简介。</returns>
        string GetConditionInputTypeSummary();

        /// <summary>
        /// 获得用于录入类型的控件。
        /// </summary>
        /// <returns>录入类型的控件。</returns>
        Control GetEditorControl();

        /// <summary>
        /// 录入类型的设置实体。
        /// </summary>
        BaseInputTypeSetting ConditionInputTypeSettingObject
        {
            get;
            set;
        }

        /// <summary>
        /// 获得录入类型的设置界面。
        /// </summary>
        /// <returns>录入类型的设置界面。</returns>
        IConditionInputTypeSettingUserControl GetConditionInputTypeSettingUserControl(EventHandler changed);

        /// <summary>
        /// 在第一次创建时，允许初始化自己的内容。
        /// </summary>
        void Init();
    }
}
