using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.Managers;

namespace QuickReportLib.Objects.SystemValue
{
    /// <summary>
    /// 服务器时间。
    /// </summary>
    internal class ServerTime : BaseSystemValueObject
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
                return "服务器时间";
            }
        }

        public override string Value
        {
            get
            {
                return DataBaseManager.GlobalDataBaseManager.GetSysDateTime().Split(' ')[1]; 
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
