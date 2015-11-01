using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.GlobalValue;

namespace QuickReportLib.Interfaces.GlobalValue
{
    /// <summary>
    /// 含有全局变量的ToolStripItem需实现此接口。
    /// </summary>
    internal interface IGlobalValueToolStripItem
    {
        /// <summary>
        /// 选中全局变量值时所触发的事件。
        /// </summary>
        event SelectedGlobalValueHandle SelectedGlobalValue;

        /// <summary>
        /// ToolStripSplitButton所包含的全局变量类型。
        /// </summary>
        GlobalValueType GlobalValueType
        {
            get;
            set;
        }

        /// <summary>
        /// 添加IGlobalValue。
        /// </summary>
        /// <param name="globalValue">全局变量。</param>
        void SetGlobalValue(IGlobalValue globalValue); 
    }

    /// <summary>
    /// 选中全局变量值时所执行的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="globalValue">全局变量值。</param>
    internal delegate void SelectedGlobalValueHandle(object sender, string globalValue);
}
