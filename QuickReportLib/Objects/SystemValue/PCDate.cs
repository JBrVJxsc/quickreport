using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;

namespace QuickReportLib.Objects.SystemValue
{
    /// <summary>
    /// �������ڡ�
    /// </summary>
    internal class PCDate : BaseSystemValueObject
    {
        public override string ValueID
        {
            get
            {
                return GetType().Name ; 
            }
        }

        public override string ValueName
        {
            get
            {
                return "��������";
            }
        }

        public override string Value
        {
            get 
            {
                return DateTime.Now.Date.ToShortDateString();
            }
        }

        public override SystemValueType ValueType
        {
            get 
            {
                return SystemValueType.Date; 
            }
        }
    }
}
