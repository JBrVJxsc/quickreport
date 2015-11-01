using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;

namespace QuickReportLib.Objects.GlobalValue
{
    /// <summary>
    /// 报表全局变量。
    /// </summary>
    internal class ReportGlobalValue : BaseGlobalValue
    {

        public override GlobalValueType GlobalValueType
        {
            get
            {
                return GlobalValueType.Report;
            }
        }

        public override SQLCodeType SQLCodeType
        {
            get
            {
                return SQLCodeType.Null;
            }
        }

        public override Type TypeOfValue
        {
            get
            {
                return typeof(Report);
            }
        }
    }
}
