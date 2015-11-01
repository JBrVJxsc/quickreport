using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Interfaces.ReportUserControl
{
    /// <summary>
    /// 报表界面上的控件需要触发查询时需实现的接口。
    /// </summary>
    internal interface ISendQueryCommandUserControl
    {
        /// <summary>
        /// 当需要报表界面进行查询时，所触发的事件。
        /// </summary>
        event SendQueryCommandHandle Query;
    }

    /// <summary>
    /// 当控件需要报表界面进行查询时，所执行的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    internal delegate void SendQueryCommandHandle(object sender);
}
