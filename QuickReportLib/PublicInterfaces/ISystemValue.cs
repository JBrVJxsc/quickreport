using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Interfaces.PublicInterface;
using QuickReportLib.Enums;

namespace QuickReportLib.PublicInterfaces
{
    /// <summary>
    /// 需要自定义系统变量时，需实现此接口。
    /// </summary>
    public interface ISystemValue : IPublicInterface
    {
        /// <summary>
        /// 变量ID。
        /// </summary>
        string ValueID
        {
            get;
        }

        /// <summary>
        /// 变量名称。
        /// </summary>
        string ValueName
        {
            get;
        }

        /// <summary>
        /// 变量的值。
        /// </summary>
        string Value
        {
            get;
        }

        /// <summary>
        /// 变量的类型。每种类型对应工具栏中日期、日期时间、人员、科室中的一个图标。
        /// </summary>
        SystemValueType ValueType
        {
            get;
        }
    }
}
