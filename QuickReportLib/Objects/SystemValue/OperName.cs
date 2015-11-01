using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Managers;
using QuickReportLib.Enums;

namespace QuickReportLib.Objects.SystemValue
{
    /// <summary>
    /// ����Ա���ơ�
    /// </summary>
    internal class OperName : BaseSystemValueObject
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
                return "����Ա����";
            }
        }

        public override string Value
        {
            get 
            {
                return DataBaseManager.GlobalDataBaseManager.Operator.Name ; 
            }
        }

        public override SystemValueType ValueType
        {
            get
            {
                return SystemValueType.Person; 
            }
        }
    }
}
