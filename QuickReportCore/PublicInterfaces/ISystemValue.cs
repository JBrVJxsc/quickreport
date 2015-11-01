using System;
using System.Collections.Generic;
using System.Text;
using QuickReportCore.Interfaces;

namespace QuickReportCore.PublicInterfaces
{
    /// <summary>
    /// 需要自定义系统变量时，需实现此接口。
    /// </summary>
    public interface ISystemValue : QuickReportCore.Interfaces.IAmPublicInterface
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
        /// 变量的类型。与显示在变量工具箱上哪个图标下有关。
        /// </summary>
        Objects.SystemValues.SystemValueType SystemValueType
        {
            get;
        }
    }
}
