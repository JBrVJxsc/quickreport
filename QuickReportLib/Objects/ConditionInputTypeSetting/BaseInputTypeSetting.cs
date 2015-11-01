using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using QuickReportLib.Interfaces.ConditionInputType;
using QuickReportLib.Enums;

namespace QuickReportLib.Objects.ConditionInputTypeSetting
{
    /// <summary>
    /// 条件录入方式设置实体的基础抽象类。
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(CheckBoxSetting))]
    [XmlInclude(typeof(ComboBoxSetting))]
    [XmlInclude(typeof(DateTimeSetting))]
    [XmlInclude(typeof(RadioButtonSetting))]
    [XmlInclude(typeof(TextBoxSetting))]
    public abstract class BaseInputTypeSetting : IConditionInputTypeSettingObject
    {
        private ActionAfterEnterKeyDown actionAfterEnterKeyDown = ActionAfterEnterKeyDown.Query;

        /// <summary>
        /// 回车键按下后所执行的动作。
        /// </summary>
        public ActionAfterEnterKeyDown ActionAfterEnterKeyDown
        {
            get
            {
                return actionAfterEnterKeyDown;
            }
            set
            {
                actionAfterEnterKeyDown = value;
            }
        }
    }
}
