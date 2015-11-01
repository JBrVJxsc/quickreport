using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Interfaces
{
    /// <summary>
    /// 需在状态栏内容的帮助中显示内容，需实现此接口。
    /// </summary>
    public interface IShowStatusStripHelp
    {
        /// <summary>
        /// 需在状态栏中显示内容时，触发的事件。
        /// </summary>
        event ShowStatusStripHelpHandle ShowStatusStripHelp;
    }

    /// <summary>
    /// 需在状态栏中显示内容时，触发的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="helpContent">在状态栏中显示的内容。</param>
    public delegate void ShowStatusStripHelpHandle(object sender , string helpContent);
}
