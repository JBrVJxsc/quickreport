using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;

namespace QuickReportLib.Objects.SystemValue
{
    /// <summary>
    /// ����ʱ�䡣
    /// </summary>
    internal class PCTime : BaseSystemValueObject
    {
        public override string ValueID
        {
            get
            {
                return GetType().Name;
            }
        }

        public override string ValueName
        {
            get
            {
                return "����ʱ��";
            }
        }

        public override string Value
        {
            get
            {
                return DateTime.Now.ToLongTimeString().ToString();
            }
        }

        public override SystemValueType ValueType
        {
            get
            {
                return SystemValueType.DateTime;
            }
        }
    }
}
