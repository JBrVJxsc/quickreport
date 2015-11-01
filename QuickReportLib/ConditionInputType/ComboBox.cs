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
    /// 下拉框。
    /// </summary>
    public class ComboBox : BaseInputType
    {
        private ComboBoxSetting comboBoxSetting = new ComboBoxSetting();
        private ComboBoxSettingUserControl comboBoxSettingUserControl;

        public override string GetConditionInputTypeName()
        {
            return "下拉框";
        }

        public override string GetConditionInputTypeSummary()
        {
            return "自定义显示内容的下拉框";
        }

        public override Control GetEditorControl()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override BaseInputTypeSetting ConditionInputTypeSettingObject
        {
            get
            {
                return comboBoxSetting;
            }
            set
            {
                comboBoxSetting = value as ComboBoxSetting;
            }
        }

        public override IConditionInputTypeSettingUserControl GetConditionInputTypeSettingUserControl(EventHandler changed)
        {
            if (comboBoxSettingUserControl == null)
            {
                comboBoxSettingUserControl = new ComboBoxSettingUserControl();
                comboBoxSettingUserControl.ChangedEvent = changed;
                comboBoxSettingUserControl.ConditionInputTypeSettingObject = comboBoxSetting;
            }
            return comboBoxSettingUserControl;
        }

        public override void Init()
        {
           
        }
    }
}
