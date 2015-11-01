using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ConditionInputTypeSetting
{
    /// <summary>
    /// 点击类控件的设置元素。
    /// </summary>
    public class CheckControlElement : BaseObject
    {
        public CheckControlElement()
        {
            Name = "新元素";
        }

        private bool checkedOn = false;

        /// <summary>
        /// 是否选中。
        /// </summary>
        public bool CheckedOn
        {
            get
            {
                return checkedOn;
            }
            set
            {
                checkedOn = value;
            }
        }
    }
}
