using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Interfaces.Xml
{
    /// <summary>
    /// Xml基础接口。
    /// </summary>
    internal interface IXml
    {
        /// <summary>
        /// 元素名称。
        /// </summary>
        string ElementName
        {
            get;
        }
    }
}
