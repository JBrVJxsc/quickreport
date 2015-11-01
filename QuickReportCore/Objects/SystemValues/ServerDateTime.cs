using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.SystemValues
{
    internal class ServerDateTime : Neusoft.NFC.Management.Database, QuickReportCore.PublicInterfaces.ISystemValue
    {
        #region ISystemValue 成员

        public string ValueID
        {
            get { return GetType().Name; }
        }

        public string ValueName
        {
            get { return "服务器日期时间"; }
        }

        public string Value
        {
            get { return GetSysDateTime() ; }
        }

        public Objects.SystemValues.SystemValueType SystemValueType
        {
            get { return SystemValueType.DateTime; }
        }

        public override string ToString()
        {
            return ValueName;
        }

        #endregion
    }
}
