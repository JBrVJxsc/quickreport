using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Interfaces.ReportSetting
{
    /// <summary>
    /// 当控件有自己特殊的值改变方式时，需实现此接口。
    /// </summary>
    internal interface IChangedUserControl
    {
        /// <summary>
        /// 当报表设置界面中的值发生改变后，所触发的事件。
        /// </summary>
        event EventHandler Changed;
    }
}
