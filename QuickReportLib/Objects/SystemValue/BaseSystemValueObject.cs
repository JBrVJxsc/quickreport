using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.PublicInterfaces;
using QuickReportLib.Enums;

namespace QuickReportLib.Objects.SystemValue
{
    /// <summary>
    /// ϵͳ�����ĳ����ࡣ
    /// </summary>
    internal abstract class BaseSystemValueObject : BaseObject , ISystemValue
    {
        public override string ID
        {
            get
            {
                return ValueID;
            }
        }

        public override string Name
        {
            get
            {
                return ValueName;
            }
            set
            {
              
            }
        }

        #region ISystemValue ��Ա

        public abstract string ValueID
        {
            get;
        }

        public abstract string ValueName
        {
            get;
        }

        public abstract string Value
        {
            get;
        }

        public abstract SystemValueType ValueType
        {
            get;
        }

        #endregion

        public override string ToString()
        {
            return ValueName;
        }
    }
}
