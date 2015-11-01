using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace QuickReportLib.Interfaces
{
    /// <summary>
    /// 需在主界面的工具栏中显示项目，需实现此接口。
    /// </summary>
    internal interface IToolStripMenuProvider
    {
        /// <summary>
        /// 需在主工具栏中显示的项目时，触发的事件。
        /// </summary>
        event ProvideToolStripMenuHandle ProvideToolStripMenu;
    }

    /// <summary>
    /// 需在主工具栏中显示的项目时，执行的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="toolStripItems">项目列表。</param>
    internal delegate void ProvideToolStripMenuHandle(object sender,ToolStripItem[] toolStripItems);
}
