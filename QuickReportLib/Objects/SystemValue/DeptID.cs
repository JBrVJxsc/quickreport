using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Object.Base;
using QuickReportLib.Enums;
using QuickReportLib.Managers;

namespace QuickReportLib.Objects.SystemValue
{
    /// <summary>
    /// µÇÂ½¿ÆÊÒ±àÂë¡£
    /// </summary>
    internal class DeptID : BaseSystemValueObject
    { 
        public override string ValueID
        {
            get
            {
                return GetType().Name;
            }
        }

        public override string ValueName
        {
            get
            { 
                return "µÇÂ¼¿ÆÊÒ±àÂë"; 
            }
        }

        public override string Value
        {
            get
            {
                return ((Employee)DataBaseManager.GlobalDataBaseManager.Operator).Dept.ID;
            }
        }

        public override SystemValueType ValueType
        {
            get
            {
                return SystemValueType.Department;
            }
        }
    }
}
