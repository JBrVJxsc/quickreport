using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Interfaces.ReportSetting
{
    /// <summary>
    /// 希望将控件显示在最前端，所需要实现的接口。
    /// </summary>
    internal interface IBringToFront
    {
        /// <summary>
        /// 希望将控件显示在最前端，所触发的事件。
        /// </summary>
        event AskForBringToFrontHandle AskForBringToFront;
    }

    /// <summary>
    /// 希望将控件显示在最前端，所执行的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="e">事件参数。</param>
    public delegate void AskForBringToFrontHandle(object sender,EventArgs e);
}
