using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Managers
{
    /// <summary>
    /// ��Guid������صľ�̬�ࡣ
    /// </summary>
    internal static class GuidManager
    {
        /// <summary>
        /// ���Guid��
        /// </summary>
        /// <returns>Guid��</returns>
        public static string GetNewGuid()
        {
            return Guid.NewGuid().ToString("B");
        }
    }
}
