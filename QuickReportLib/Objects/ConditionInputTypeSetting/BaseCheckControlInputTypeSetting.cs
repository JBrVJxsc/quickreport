using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ConditionInputTypeSetting
{
    /// <summary>
    /// 点选型控件的基础设置实体。
    /// </summary>
    public class BaseCheckControlInputTypeSetting : BaseInputTypeSetting
    {
        private List<CheckControlElement> checkControlElements = new List<CheckControlElement>();

        public List<CheckControlElement> CheckControlElements
        {
            get
            {
                return checkControlElements;
            }
            set
            {
                checkControlElements = value;
            }
        }
    }
}
