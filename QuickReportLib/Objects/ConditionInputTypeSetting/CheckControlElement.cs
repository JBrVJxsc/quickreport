using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ConditionInputTypeSetting
{
    /// <summary>
    /// �����ؼ�������Ԫ�ء�
    /// </summary>
    public class CheckControlElement : BaseObject
    {
        public CheckControlElement()
        {
            Name = "��Ԫ��";
        }

        private bool checkedOn = false;

        /// <summary>
        /// �Ƿ�ѡ�С�
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
