using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;

namespace QuickReportLib.Interfaces.GlobalValue
{
    /// <summary>
    /// 需求包含全局变量的ToolStripItem，则需实现此接口。
    /// </summary>
    internal interface IGlobalValueToolStripItemAsker
    {
        /// <summary>
        /// 当需要使用包含全局变量的ToolStripItem时触发的事件。
        /// </summary>
        event AskForGlobalValueToolStripItemHandle AskForGlobalValueToolStripItem;

        /// <summary>
        /// 获取全局变量。
        /// </summary>
        /// <param name="globalValue">全局变量值。</param>
        void SetGlobalValue(string globalValue);
    }

    /// <summary>
    /// 当需要使用包含全局变量的ToolStripItem时触发的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="globalValueTypes">全局变量类型。</param>
    internal delegate void AskForGlobalValueToolStripItemHandle(IGlobalValueToolStripItemAsker iGlobalValueToolStripItemAsker, List<GlobalValueType> globalValueTypes);
}
