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
    /// ����¼�����͵Ļ��������ࡣ
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(CheckBox))]
    [XmlInclude(typeof(ComboBox))]
    [XmlInclude(typeof(DateTimePicker))]
    [XmlInclude(typeof(RadioButton))]
    [XmlInclude(typeof(TextBox))]
    public abstract class BaseInputType : IConditionInputType
    {

        #region IConditionInputType ��Ա

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
