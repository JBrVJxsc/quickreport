using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using QuickReportLib.Objects.ConditionInputTypeSetting;
using QuickReportLib.Interfaces.ConditionInputType;

namespace QuickReportLib.ConditionInputType
{
    /// <summary>
    /// 条件录入类型的基础抽象类。
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(CheckBox))]
    [XmlInclude(typeof(ComboBox))]
    [XmlInclude(typeof(DateTimePicker))]
    [XmlInclude(typeof(RadioButton))]
    [XmlInclude(typeof(TextBox))]
    public abstract class BaseInputType : IConditionInputType
    {

        #region IConditionInputType 成员

        public abstract string GetConditionInputTypeName();

        public abstract string GetConditionInputTypeSummary();

        public abstract Control GetEditorControl();

        public abstract BaseInputTypeSetting ConditionInputTypeSettingObject
        {
            get;
            set;
        }

        public abstract IConditionInputTypeSettingUserControl GetConditionInputTypeSettingUserControl(EventHandler changed);

        public abstract void Init();

        #endregion

        public override string ToString()
        {
            return GetConditionInputTypeName();
        } 
    }
}
