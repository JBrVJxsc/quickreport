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
        /// �����ڵĽӿ����͡�
        /// </summary>
        Type ParentInterface
        {
            get;
        }
    }
}
