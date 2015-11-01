using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects.ConditionInputTypeSetting;
using QuickReportLib.Interfaces.ConditionInputType;
using QuickReportLib.Controls.ConditionInputTypeSetting;

namespace QuickReportLib.ConditionInputType
{
    /// <summary>
    /// ����ʱ�䡣
    /// </summary>
    public class DateTimePicker : BaseInputType
    {
        private DateTimeSetting dateTimeSetting = new DateTimeSetting();
        private DateTimePickerSettingUserControl dateTimePickerSettingUserControl;

        public override string GetConditionInputTypeName()
        {
            return "����ʱ��";
        }

        public override string GetConditionInputTypeSummary()
        {
            return "���ڿؼ�";
        }

        public override Control GetEditorControl()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override BaseInputTypeSetting ConditionInputTypeSettingObject
        {
            get
            {
                return dateTimeSetting;
            }
            set
            {
                dateTimeSetting = value as DateTimeSetting;
            }
        }

        public override IConditionInputTypeSettingUserControl GetConditionInputTypeSettingUserControl(EventHandler changed)
        {
            if (dateTimePickerSettingUserControl == null)
            {
                dateTimePickerSettingUserControl = new DateTimePickerSettingUserControl();
                dateTimePickerSettingUserControl.ChangedEvent = changed;
                dateTimePickerSettingUserControl.ConditionInputTypeSettingObject = dateTimeSetting;
            }
            return dateTimePickerSettingUserControl;
        }

        public override void Init()
        {
            
        }
    }
}
