using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportLayoutStyle;
using QuickReportLib.Interfaces.ReportSetting;

namespace QuickReportLib.ReportLayoutStyles
{
    /// <summary>
    /// 报表布局样式的基础抽象类。
    /// </summary>
    [XmlInclude(typeof(ConditionTop_MainBottom))]
    [XmlInclude(typeof(ConditionTop_TreeBottomLeft_MainBottomRight))]
    [XmlInclude(typeof(ConditionTop_TreeBottomLeft_MainBottomRightTop_DetailBottomRightBottom))]
    [XmlInclude(typeof(Main))]
    [XmlInclude(typeof(MainTop_DetailBottom))]
    [XmlInclude(typeof(TreeLeft_ConditionRightTop_MainRightBottom))]
    [XmlInclude(typeof(TreeLeft_ConditionRightTop_MainRightBottomTop_DetailRightBottomBottom))]
    [XmlInclude(typeof(TreeLeft_MainRight))]
    [XmlInclude(typeof(TreeLeft_MainRightTop_DetailRightBottom))]
    public abstract class BaseReportLayoutStyle : IReportLayoutStyle
    {

        #region IReportLayoutStyle 成员

        public abstract string GetLayoutStyleName();

        public abstract string GetLayoutStyleSummary();

        public abstract Image GetLayoutStylePreview();

        public abstract int GetStyleSortID();

        public abstract IReportSettingUserControl[] GetReportSettingControls();

        public abstract IReportLayoutStyleShowUserControl GetLayoutStyleShowUserControl();

        public abstract List<ReportElement> GetReportElements();

        #endregion
    }
}
