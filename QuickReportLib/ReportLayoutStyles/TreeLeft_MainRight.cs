using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using QuickReportLib.Interfaces.ReportLayoutStyle;
using QuickReportLib.Interfaces.ReportSetting;
using QuickReportLib.Enums;
using QuickReportLib.Controls.ReportSetting;

namespace QuickReportLib.ReportLayoutStyles
{
    public class TreeLeft_MainRight : BaseReportLayoutStyle
    {

        public override string GetLayoutStyleName()
        {
            return "布局七";
        }

        public override string GetLayoutStyleSummary()
        {
            return "条件在左侧，主报表在条件的右侧。";
        }

        public override Image GetLayoutStylePreview()
        {
            return global::QuickReportLib.Properties.Resources.LayoutStylePreview_TreeLeft_MainRight;
        }

        public override int GetStyleSortID()
        {
            return 6;
        }

        public override IReportSettingUserControl[] GetReportSettingControls()
        {
            IReportSettingUserControl[] settingUserControls = new IReportSettingUserControl[3];
            settingUserControls[0] = new BaseInfoSetting();
            settingUserControls[1] = new TreeSetting();
            settingUserControls[2] = new InterfaceSetting();
            return settingUserControls;
        }

        public override IReportLayoutStyleShowUserControl GetLayoutStyleShowUserControl()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override List<ReportElement> GetReportElements()
        {
            List<ReportElement> reportElementList = new List<ReportElement>();
            reportElementList.Add(ReportElement.Tree);
            reportElementList.Add(ReportElement.MainReport);
            return reportElementList;
        }
    }
}
