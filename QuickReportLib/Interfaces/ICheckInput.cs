using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Interfaces
{
    /// <summary>
    /// 需要检查录入的控件需实现此接口。
    /// </summary>
    internal interface ICheckInput
    {
        /// <summary>
        /// 检查录入。
        /// </summary>
        /// <returns>1成功；-1失败。</returns>
        int CheckInput();
    }
}
