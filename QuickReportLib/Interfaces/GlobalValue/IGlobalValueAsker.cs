using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;

namespace QuickReportLib.Interfaces.GlobalValue
{
    /// <summary>
    /// 需要最新的全局变量，则需实现此接口。
    /// </summary>
    internal interface IGlobalValueAsker
    {
        /// <summary>
        /// 所需的全局变量类型。
        /// </summary>
        List<GlobalValueType> GlobalValueTypes
        {
            get;
        }

        /// <summary>
        /// 设置全局变量。
        /// </summary>
        /// <param name="globalValue">全局变量。</param>
        void SetGlobalValue(IGlobalValue globalValue);
    }
}
