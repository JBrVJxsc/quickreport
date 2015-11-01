using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.SystemValues
{
    internal class DeptID : Neusoft.NFC.Management.Database, QuickReportCore.PublicInterfaces.ISystemValue
    {
        #region ISystemValue ³ÉÔ±

        public string ValueID
        {
            get {return GetType().Name; }
        }

        public string ValueName
        {
            get { return "µÇÂ¼¿ÆÊÒ±àÂë"; }
        }

        public string Value
        {
            get { return ((Neusoft.HISFC.Object.Base.Employee)Operator).Dept.ID; }
        }

        public Objects.SystemValues.SystemValueType SystemValueType
        {
            get { return SystemValueType.Dept; }
        }

        public override string ToString()
        {
            return ValueName;
        }

        #endregion
    }
}
