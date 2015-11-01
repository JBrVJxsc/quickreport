using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Managers;
using QuickReportLib.Enums;

namespace QuickReportLib.Objects.SystemValue
{
    /// <summary>
    /// 服务器日期。
    /// </summary>
    internal class ServerDate : BaseSystemValueObject
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
                return "服务器日期";
            }
        }

        public override string Value
        {
            get
            {
                return DataBaseManager.GlobalDataBaseManager.GetSysDate() ; 
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
