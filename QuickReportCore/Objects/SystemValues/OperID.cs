using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.SystemValues
{
    internal class OperID : Neusoft.NFC.Management.Database, QuickReportCore.PublicInterfaces.ISystemValue
    {
        #region ISystemValue 成员

        public string ValueID
        {
            get { return GetType().Name; }
        }

        public string ValueName
        {
            get { return "操作员编码"; }
        }

        public string Value
        {
            get { return Operator.ID ; }
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
