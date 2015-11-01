using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Enums;

namespace QuickReportLib.Objects.GlobalValue
{
    /// <summary>
    /// 全局变量基础抽象类。
    /// </summary>
    internal abstract class BaseGlobalValue : BaseObject , IGlobalValue
    {
        protected List<BaseObject> value;

        #region IGlobalValue 成员

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
