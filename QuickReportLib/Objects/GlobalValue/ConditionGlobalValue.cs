using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.Objects;

namespace QuickReportLib.Objects.GlobalValue
{
    /// <summary>
    /// 条件全局变量。
    /// </summary>
    internal class ConditionGlobalValue : BaseGlobalValue
    {
        public override GlobalValueType GlobalValueType
        {
            get 
            {
                return GlobalValueType.Condition;
            }
        }

        public override SQLCodeType SQLCodeType
        {
            get
            {
                return SQLCodeType.Condition;
            }
        }

        public override Type TypeOfValue
        {
            get 
            {
               return typeof(Condition);
            }
        }
    }
}
