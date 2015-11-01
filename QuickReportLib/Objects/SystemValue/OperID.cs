using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Managers;
using QuickReportLib.Enums;

namespace QuickReportLib.Objects.SystemValue
{
    /// <summary>
    /// 操作员编码。
    /// </summary>
    internal class OperID : BaseSystemValueObject
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
                return "操作员编码"; 
            }
        }

        public override string Value
        {
            get
            {
                return DataBaseManager.GlobalDataBaseManager.Operator.ID ;
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
