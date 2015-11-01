using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.SystemValues
{
    internal class ServerDate : Neusoft.NFC.Management.Database, QuickReportCore.PublicInterfaces.ISystemValue
    {
        #region ISystemValue 成员

        public string ValueID
        {
            get { return GetType().Name ; }
        }

        public string ValueName
        {
            get { return "服务器日期"; }
        }

        public string Value
        {
            get { return GetSysDate() ; }
        }

        public Objects.SystemValues.SystemValueType SystemValueType
        {
            get { return SystemValueType.Date; }
        }

        public override string ToString()
        {
            return ValueName;
        }

        #endregion
    }
}
