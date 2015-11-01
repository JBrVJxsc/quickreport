using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting;

namespace QuickReportLib.Interfaces.ReportLayoutStyle
{
    /// <summary>
    /// 报表布局样式需实现此接口。
    /// </summary>
    public interface IReportLayoutStyle
    {
        /// <summary>
        /// 获得样式名称。
        /// </summary>
        /// <returns>样式名称。</returns>
        string GetLayoutStyleName();

        /// <summary>
        /// 获得样式简介。
        /// </summary>
        /// <returns>样式简介。</returns>
        string GetLayoutStyleSummary();

        /// <summary>
        /// 获得样式示例图片。
        /// </summary>
        /// <returns>样式示例图片。</returns>
        Image GetLayoutStylePreview();

        /// <summary>
        /// 获得布局样式的序号。
        /// </summary>
        /// <returns>序号。</returns>
        int GetStyleSortID();

        /// <summary>
        /// 获得所包含的报表元素。
        /// </summary>
        /// <returns>报表元素集合。</returns>
        List<ReportElement> GetReportElements();

        /// <summary>
        /// 获得界面布局所需的报表设置控件。
        /// </summary>
        /// <returns>设置控件。</returns>
        IReportSettingUserControl[] GetReportSettingControls();

        /// <summary>
        /// 获取界面布局支持的控件。
        /// </summary>
        /// <returns>支持控件。</returns>
        IReportLayoutStyleShowUserControl GetLayoutStyleShowUserControl();
    }
}
