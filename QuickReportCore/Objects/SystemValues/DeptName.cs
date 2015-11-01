using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.SystemValues
{
    internal class DeptName : Neusoft.NFC.Management.Database, QuickReportCore.PublicInterfaces.ISystemValue
    {
        #region ISystemValue ��Ա

        public string ValueID
        {
            get { return GetType().Name ; }
        }

        public string ValueName
        {
            get { return "��¼��������"; }
        }

        public string Value
        {
            get { return  ((Neusoft.HISFC.Object.Base.Employee)Operator).Dept.Name ; }
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
