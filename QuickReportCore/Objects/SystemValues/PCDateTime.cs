using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.SystemValues
{
    internal class PCDateTime : QuickReportCore.PublicInterfaces.ISystemValue
    {
        #region ISystemValue ��Ա

        public string ValueID
        {
            get { return GetType().Name ; }
        }

        public string ValueName
        {
            get { return "��������ʱ��"; }
        }

        public string Value
        {
            get { return  DateTime.Now.ToString() ; }
        }

        public SystemValueType SystemValueType
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
