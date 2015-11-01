using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.Objects;

namespace QuickReportLib.Interfaces.GlobalValue
{
    /// <summary>
    /// 全局变量需实现此接口。
    /// </summary>
    internal interface IGlobalValue
    {
        /// <summary>
        /// 全局变量类型。
        /// </summary>
        GlobalValueType GlobalValueType
        {
            get;
        }

        /// <summary>
        /// SQL编码类型。。
        /// </summary>
        SQLCodeType SQLCodeType
        {
            get;
        }

        /// <summary>
        /// 全局变量值的类型。
        /// </summary>
        Type TypeOfValue
        {
            get;
        }

        /// <summary>
        /// 全局变量值。
        /// </summary>
        List<BaseObject> Value
        {
            get;
            set;
        }
    }
}
