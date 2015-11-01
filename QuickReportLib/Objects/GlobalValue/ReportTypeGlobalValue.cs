using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;

namespace QuickReportLib.Objects.GlobalValue
{
    /// <summary>
    /// �������ȫ�ֱ�����
    /// </summary>
    internal class ReportTypeGlobalValue : BaseGlobalValue
    {

        public override GlobalValueType GlobalValueType
        {
            get
            {
                return GlobalValueType.ReportType;
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
                return typeof(string);
            }
        }
    }
}
