using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects;

namespace QuickReportLib.Interfaces.ReportSetting
{
    /// <summary>
    /// 为报表提供设置界面的用户控件需实现此接口。
    /// </summary>
    public interface IReportSettingUserControl 
    {
        /// <summary>
        /// 报表实体。
        /// </summary>
        Report Report
        {
            get;
            set;
        }

        /// <summary>
        /// 名称。
        /// </summary>
        string SettingName
        {
            get;
        }

        /// <summary>
        /// 简介。
        /// </summary>
        string SettingSummary
        {
            get;
        }

        /// <summary>
        /// 保存。
        /// </summary>
        /// <returns>成功返回1；失败返回-1。</returns>
        int Save();

        /// <summary>
        /// 获取需要上传至工具栏的按钮。
        /// </summary>
        /// <returns>需要上传至工具栏的按钮。</returns>
        ToolStripItem[] GetToolStripItems();

        /// <summary>
        /// 希望将控件显示在最前端，所触发的事件。
        /// </summary>
        event AskForBringToFrontHandle AskForBringToFront;
    }
}
