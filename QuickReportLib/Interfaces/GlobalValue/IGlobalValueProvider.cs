using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Interfaces.GlobalValue
{
    /// <summary>
    /// 全局变量含有者。
    /// </summary>
    internal interface IGlobalValueProvider
    {
        /// <summary>
        /// 全局变量改变时，触发的事件。
        /// </summary>
        event GlobalValueChangedHandle GlobalValueChanged;
    }

    /// <summary>
    /// 全局变量变更时触发的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="globalValue">变更后的全局变量。</param>
    internal delegate void GlobalValueChangedHandle(object sender,IGlobalValue globalValue);
}
