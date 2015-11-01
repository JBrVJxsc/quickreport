using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.PublicInterfaces;
using QuickReportLib.Objects.SystemValue;

namespace QuickReportLib.Objects.GlobalValue
{
    /// <summary>
    /// 人员全局变量。
    /// </summary>
    internal class PersonGlobalValue : BaseGlobalValue
    {

        public override GlobalValueType GlobalValueType
        {
            get
            {
                return GlobalValueType.Person;
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
                    OperID operID = new OperID();
                    operID.SortID = 0;
                    OperName operName = new OperName();
                    operName.SortID = 1;
                    value.Add(operID);
                    value.Add(operName);
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
