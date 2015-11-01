using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace QuickReportLib.Interfaces.ReportLayoutStyle
{
    /// <summary>
    /// 提供界面布局支持的控件。
    /// </summary>
    public interface IReportLayoutStyleShowUserControl
    {
        /// <summary>
        /// 树的Panel。
        /// </summary>
        Panel PanelOfTree
        {
            get;
        }

        /// <summary>
        /// 条件的Panel。
        /// </summary>
        Panel PanelOfCondition
        {
            get;
        }

        /// <summary>
        /// 主报表的Panel。
        /// </summary>
        Panel PanelOfMainReport
        {
            get;
        }

        /// <summary>
        /// 明细报表的Panel。
        /// </summary>
        Panel PanelOfDetailReport
        {
            get;
        }
    }
}
