using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.SystemValues
{
    internal class DeptName : Neusoft.NFC.Management.Database, QuickReportCore.PublicInterfaces.ISystemValue
    {
        #region ISystemValue 成员

        public string ValueID
        {
            get { return GetType().Name ; }
        }

        public string ValueName
        {
            get { return "登录科室名称"; }
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
