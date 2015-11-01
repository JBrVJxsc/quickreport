using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Interfaces
{
    /// <summary>
    /// 解决ToolBox中的ToolStrip第一次无法获得焦点的问题。
    /// </summary>
    internal interface IHaveAToolStrip
    {
        void SetToolStripFocus();
    }
}
