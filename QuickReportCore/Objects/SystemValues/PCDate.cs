using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.SystemValues
{
    internal class PCDate : QuickReportCore.PublicInterfaces.ISystemValue
    {

        #region ISystemValue ��Ա

        public string ValueID
        {
            get { return GetType().Name ; }
        }

        public string ValueName
        {
            get { return "��������"; }
        }

        public string Value
        {
            get { return DateTime.Now.Date.ToShortDateString(); }
        }

        public SystemValueType SystemValueType
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
