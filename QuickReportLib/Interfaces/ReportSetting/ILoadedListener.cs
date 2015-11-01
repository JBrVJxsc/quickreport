using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Interfaces.ReportSetting
{
    /// <summary>
    /// 需要监听初始化结束事件的成员需实现此接口。
    /// </summary>
    internal interface ILoadedListener
    {
        /// <summary>
        /// 初始化后所执行的方法。
        /// </summary>
        void Loaded();
    }
}
