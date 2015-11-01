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
    /// �ı���
    /// </summary>
    public class TextBox : BaseInputType
    {

        private TextBoxSetting textSetting = new TextBoxSetting();
        private TextBoxSettingUserControl textBoxSettingUserControl;

        public override string GetConditionInputTypeName()
        {
            return "�ı���";
        }

        public override string GetConditionInputTypeSummary()
        {
            return "���������ַ�";
        }

        public override Control GetEditorControl()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override BaseInputTypeSetting ConditionInputTypeSettingObject
        {
            get
            {
                return textSetting;
            }
            set
            {
                textSetting = value as TextBoxSetting;
            }
        }

        public override IConditionInputTypeSettingUserControl GetConditionInputTypeSettingUserControl(EventHandler changed)
        {
            if (textBoxSettingUserControl == null)
            {
                textBoxSettingUserControl = new TextBoxSettingUserControl();
                textBoxSettingUserControl.ChangedEvent = changed;
                textBoxSettingUserControl.ConditionInputTypeSettingObject = textSetting;
            }
            return textBoxSettingUserControl;
        }

        public override void Init()
        {
            
        }
    }
}
