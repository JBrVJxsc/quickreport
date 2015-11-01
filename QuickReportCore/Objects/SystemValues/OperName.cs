using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.SystemValues
{
    internal class OperName : Neusoft.NFC.Management.Database, QuickReportCore.PublicInterfaces.ISystemValue
    {
        #region ISystemValue 成员

        public string ValueID
        {
            get { return GetType().Name ; }
        }

        public string ValueName
        {
            get { return "操作员姓名"; }
        }

        public string Value
        {
            get { return Operator.Name ; }
        }

        public Objects.SystemValues.SystemValueType SystemValueType
        {
            get { return SystemValueType.Oper; }
        }

        public override string ToString()
        {
            return ValueName;
        }

        #endregion
    }
}
