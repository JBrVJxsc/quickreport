using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.Objects;

namespace QuickReportLib.Objects.GlobalValue
{
    /// <summary>
    /// 列全局变量。
    /// </summary>
    internal class ColumnGlobalValue : BaseGlobalValue
    {
        public override GlobalValueType GlobalValueType
        {
            get
            {
                return GlobalValueType.Column;
            }
        }

        public override SQLCodeType SQLCodeType
        {
            get
            {
                return SQLCodeType.Column;
            }
        }

        public override Type TypeOfValue
        {
            get
            {
                return typeof(Column);
            }
        }
    }
}
