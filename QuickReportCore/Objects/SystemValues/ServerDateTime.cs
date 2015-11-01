using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.SystemValues
{
    internal class ServerDateTime : Neusoft.NFC.Management.Database, QuickReportCore.PublicInterfaces.ISystemValue
    {
        #region ISystemValue ��Ա

        public string ValueID
        {
            get { return GetType().Name; }
        }

        public string ValueName
        {
            get { return "����������ʱ��"; }
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
