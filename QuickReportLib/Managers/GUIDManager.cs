using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Managers
{
    /// <summary>
    /// 与Guid操作相关的静态类。
    /// </summary>
    internal static class GuidManager
    {
        /// <summary>
        /// 获得Guid。
        /// </summary>
        /// <returns>Guid。</returns>
        public static string GetNewGuid()
        {
            return Guid.NewGuid().ToString("B");
        }
    }
}
