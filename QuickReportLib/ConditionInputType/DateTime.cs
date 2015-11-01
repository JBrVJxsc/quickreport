using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects.ConditionInputTypeSetting;
using QuickReportLib.Interfaces.ConditionInputType;

namespace QuickReportLib.ConditionInputType
{
    /// <summary>
    /// 日期时间。
    /// </summary>
    public class DateTime : BaseInputType
    {
        private DateTimeSetting dateTimeSetting = new DateTimeSetting();

        public override string GetConditionInputTypeName()
        {
            return "日期时间";
        }

        public override string GetConditionInputTypeSummary()
        {
            return "日期控件";
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

        public override IConditionInputTypeSettingUserControl GetConditionInputTypeSettingUserControl()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
