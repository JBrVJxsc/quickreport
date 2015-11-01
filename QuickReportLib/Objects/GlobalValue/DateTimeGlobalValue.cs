using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.Objects.SystemValue;
using QuickReportLib.PublicInterfaces;

namespace QuickReportLib.Objects.GlobalValue
{
    /// <summary>
    /// 日期时间全局变量。
    /// </summary>
    internal class DateTimeGlobalValue : BaseGlobalValue
    {

        public override GlobalValueType GlobalValueType
        {
            get
            {
                return GlobalValueType.DateTime;
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
                    PCTime pcTime = new PCTime();
                    pcTime.SortID = 0;
                    ServerTime serverTime = new ServerTime();
                    serverTime.SortID = 1;
                    value.Add(pcTime);
                    value.Add(serverTime);
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
