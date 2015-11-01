using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Enums;

namespace QuickReportLib.Objects.GlobalValue
{
    /// <summary>
    /// ȫ�ֱ������������ࡣ
    /// </summary>
    internal abstract class BaseGlobalValue : BaseObject , IGlobalValue
    {
        protected List<BaseObject> value;

        #region IGlobalValue ��Ա

        public abstract GlobalValueType GlobalValueType
        {
            get;
        }

        public abstract SQLCodeType SQLCodeType
        {
            get;
        }

        public virtual Type TypeOfValue
        {
            get
            { 
                return typeof(BaseObject);
            }
        }

        public virtual List<BaseObject> Value
        {
            get
            {
                if (value == null)
                {
                    value = new List<BaseObject>();
                }
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        #endregion
    }
}
