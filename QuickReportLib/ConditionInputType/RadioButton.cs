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
    /// 单选框。
    /// </summary>
    public class RadioButton : BaseInputType
    {
        private RadioButtonSetting radioButtonSetting = new RadioButtonSetting();
        private RadioButtonSettingUserControl radioButtonSettingUserControl;

        public override string GetConditionInputTypeName()
        {
            return "单选框";
        }

        public override string GetConditionInputTypeSummary()
        {
            return "单选框";
        }

        public override Control GetEditorControl()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override BaseInputTypeSetting ConditionInputTypeSettingObject
        {
            get
            {
                return radioButtonSetting;
            }
            set
            {
                radioButtonSetting = value as RadioButtonSetting;
            }
        }

        public override IConditionInputTypeSettingUserControl GetConditionInputTypeSettingUserControl(EventHandler changed)
        {
            if (radioButtonSettingUserControl == null)
            {
                radioButtonSettingUserControl = new RadioButtonSettingUserControl();
                radioButtonSettingUserControl.ChangedEvent = changed;
                radioButtonSettingUserControl.ConditionInputTypeSettingObject = radioButtonSetting;
            }
            return radioButtonSettingUserControl;
        }

        public override void Init()
        {
            radioButtonSetting.CheckControlElements.Clear();
            CheckControlElement checkControlElement1 = new CheckControlElement();
            checkControlElement1.SortID = 0;
            CheckControlElement checkControlElement2 = new CheckControlElement();
            checkControlElement1.SortID = 1;
            radioButtonSetting.CheckControlElements.Add(checkControlElement1);
            radioButtonSetting.CheckControlElements.Add(checkControlElement2);
        }
    }
}
