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
    public class ConditionTop_TreeBottomLeft_MainBottomRight : BaseReportLayoutStyle
    {

        public override string GetLayoutStyleName()
        {
            return "布局二";
        }

        public override string GetLayoutStyleSummary()
        {
            return "条件在上方，树在条件下方的左侧，主报表在树的右侧。";
        }

        public override Image GetLayoutStylePreview()
        {
            return global::QuickReportLib.Properties.Resources.LayoutStylePreview_ConditionTop_TreeBottomLeft_MainBottomRight;
        }

        public override int GetStyleSortID()
        {
            return 1;
        }

        public override IReportSettingUserControl[] GetReportSettingControls()
        {
            IReportSettingUserControl[] settingUserControls = new IReportSettingUserControl[4];
            settingUserControls[0] = new BaseInfoSetting();
            settingUserControls[1] = new ConditionSetting();
            settingUserControls[2] = new TreeSetting();
            settingUserControls[3] = new InterfaceSetting();
            return settingUserControls;
        }

        public override IReportLayoutStyleShowUserControl GetLayoutStyleShowUserControl()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override List<ReportElement> GetReportElements()
        {
            List<ReportElement> reportElementList = new List<ReportElement>();
            reportElementList.Add(ReportElement.Condition);
            reportElementList.Add(ReportElement.Tree);
            reportElementList.Add(ReportElement.MainReport);
            return reportElementList;
        }
    }
}
