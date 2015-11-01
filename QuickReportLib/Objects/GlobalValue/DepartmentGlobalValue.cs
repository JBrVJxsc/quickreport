using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.PublicInterfaces;
using QuickReportLib.Objects.SystemValue;

namespace QuickReportLib.Objects.GlobalValue
{
    /// <summary>
    /// 科室全局变量。
    /// </summary>
    internal class DepartmentGlobalValue : BaseGlobalValue
    {

        public override GlobalValueType GlobalValueType
        {
            get
            {
                return GlobalValueType.Department;
            }
        }

        public override SQLCodeType SQLCodeType
        {
            get
            {
                return SQLCodeType.System;
            }
        }

        public override Type TypeOfValue
        {
            get
            {
                return typeof(ISystemValue);
            }
        }

        public override List<BaseObject> Value
        {
            get
            {
                if (value == null)
                {
                    value = new List<BaseObject>();
                    DeptID deptID = new DeptID();
                    deptID.SortID = 0;
                    DeptName deptName = new DeptName();
                    deptName.SortID = 1;
                    HospitalName hospitalName = new HospitalName();
                    hospitalName.SortID = 2;
                    value.Add(deptID);
                    value.Add(deptName);
                    value.Add(hospitalName);
                }
                return value;
            }
            set
            {
                base.Value = value;
            }
        }
    }
}
