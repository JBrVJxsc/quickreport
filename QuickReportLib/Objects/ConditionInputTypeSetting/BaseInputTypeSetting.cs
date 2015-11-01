using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using QuickReportLib.Interfaces.ConditionInputType;
using QuickReportLib.Enums;

namespace QuickReportLib.Objects.ConditionInputTypeSetting
{
    /// <summary>
    /// ����¼�뷽ʽ����ʵ��Ļ��������ࡣ
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
        /// �س������º���ִ�еĶ�����
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
