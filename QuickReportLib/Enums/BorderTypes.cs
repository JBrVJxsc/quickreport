using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Enums
{
    /// <summary>
    /// ±ﬂøÚ÷÷¿‡°£
    /// </summary>
    [Flags]
    internal enum BorderTypes
    {
        Left = 1,
        Top = 2,
        Right = 4,
        Bottom = 8,
        Around = 16,
        All = 32,
        None = 64
    }
}
