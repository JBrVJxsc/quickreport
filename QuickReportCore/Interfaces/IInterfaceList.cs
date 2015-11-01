using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    internal interface IInterfaceList : IConvertToXml
    {
        /// <summary>
        /// 隶属于的接口类型。
        /// </summary>
        Type ParentInterface
        {
            get;
        }
    }
}
