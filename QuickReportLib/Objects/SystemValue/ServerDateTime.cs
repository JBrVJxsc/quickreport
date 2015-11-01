using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Managers;
using QuickReportLib.Enums;

namespace QuickReportLib.Objects.SystemValue
{
    /// <summary>
    /// ����������ʱ�䡣
    /// </summary>
    internal class ServerDateTime : BaseSystemValueObject
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
                return "������������ʱ��";
            }
        }

        public override string Value
        {
            get 
            {
                return DataBaseManager.GlobalDataBaseManager.GetSysDateTime() ; 
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
