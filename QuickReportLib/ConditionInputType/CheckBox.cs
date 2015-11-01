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
    /// 多选框。
    /// </summary>
    public class CheckBox : BaseInputType
    {

        private CheckBoxSetting checkBoxSetting = new CheckBoxSetting();
        private CheckBoxSettingUserControl checkBoxSettingUserControl;

        public override string GetConditionInputTypeName()
        {
            return "多选框";
        }

        public override string GetConditionInputTypeSummary()
        {
            return "多选框";
        }

        public override Control GetEditorControl()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override BaseInputTypeSetting ConditionInputTypeSettingObject
        {
            get
            {
                return checkBoxSetting;
            }
            set
            {
                checkBoxSetting = value as CheckBoxSetting;
            }
        }

        public override IConditionInputTypeSettingUserControl GetConditionInputTypeSettingUserControl(EventHandler changed)
        {
            if (checkBoxSettingUserControl == null)
            {
                checkBoxSettingUserControl = new CheckBoxSettingUserControl();
                checkBoxSettingUserControl.ChangedEvent = changed;
                checkBoxSettingUserControl.ConditionInputTypeSettingObject = checkBoxSetting;
            }
            return checkBoxSettingUserControl;
        }

        public override void Init()
        {
            checkBoxSetting.CheckControlElements.Clear();
            CheckControlElement checkControlElement1 = new CheckControlElement();
            checkControlElement1.SortID = 0;
            CheckControlElement checkControlElement2 = new CheckControlElement();
            checkControlElement1.SortID = 1;
            checkBoxSetting.CheckControlElements.Add(checkControlElement1);
            checkBoxSetting.CheckControlElements.Add(checkControlElement2);
        }
    }
}
