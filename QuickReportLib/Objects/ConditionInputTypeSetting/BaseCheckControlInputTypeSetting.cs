using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ConditionInputTypeSetting
{
    /// <summary>
    /// ��ѡ�Ϳؼ��Ļ�������ʵ�塣
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
