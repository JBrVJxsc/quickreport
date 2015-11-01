using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.PublicInterfaces;
using QuickReportLib.Objects.SystemValue;

namespace QuickReportLib.Objects.GlobalValue
{
    /// <summary>
    /// 日期全局变量。
    /// </summary>
    internal class DateGlobalValue : BaseGlobalValue
    {
        public override GlobalValueType GlobalValueType
        {
            get
            {
                return GlobalValueType.Date;
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
                    PCDate pcDate = new PCDate();
                    pcDate.SortID = 0;
                    PCDateTime pcDateTime = new PCDateTime();
                    pcDateTime.SortID = 1;
                    ServerDate serverDate = new ServerDate();
                    serverDate.SortID = 2;
                    ServerDateTime serverDateTime = new ServerDateTime();
                    serverDateTime.SortID = 3;
                    value.Add(pcDate);
                    value.Add(pcDateTime);
                    value.Add(serverDate);
                    value.Add(serverDateTime);
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
