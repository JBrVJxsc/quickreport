using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Object.Base;
using QuickReportLib.Enums;
using QuickReportLib.Managers;

namespace QuickReportLib.Objects.SystemValue
{
    /// <summary>
    /// ��½�������ơ�
    /// </summary>
    internal class DeptName : BaseSystemValueObject
    {
        public override string ValueID
        {
            get 
            { 
                return GetType().Name ; 
            }
        }

        public override string ValueName
        {
            get 
            { 
                return "��¼��������";
            }
        }

        public override string Value
        {
            get 
            {
                return ((Employee)DataBaseManager.GlobalDataBaseManager.Operator).Dept.Name;
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
