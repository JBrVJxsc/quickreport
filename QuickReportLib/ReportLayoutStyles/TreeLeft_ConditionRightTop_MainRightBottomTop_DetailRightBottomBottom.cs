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
    public class TreeLeft_ConditionRightTop_MainRightBottomTop_DetailRightBottomBottom : BaseReportLayoutStyle
    {

        public override string GetLayoutStyleName()
        {
            return "布局五";
        }

        public override string GetLayoutStyleSummary()
        {
            return "树在左侧，条件在右侧的上方，主报表在条件的下方，明细报表在主报表的下方。";
        }

        public override Image GetLayoutStylePreview()
        {
            return global::QuickReportLib.Properties.Resources.LayoutStylePreview_TreeLeft_ConditionRightTop_MainRightBottomTop_DetaiRightBottomBottom;
        }

        public override int GetStyleSortID()
        {
            return 4;
        }

        public override IReportSettingUserControl[] GetReportSettingControls()
        {
            IReportSettingUserControl[] settingUserControls = new IReportSettingUserControl[5];
            settingUserControls[0] = new BaseInfoSetting();
            settingUserControls[1] = new ConditionSetting();
            settingUserControls[2] = new TreeSetting();
            settingUserControls[3] = new DetailReportSetting();
            settingUserControls[4] = new InterfaceSetting();
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
            reportElementList.Add(ReportElement.Condition);
            reportElementList.Add(ReportElement.MainReport);
            reportElementList.Add(ReportElement.DetailReport);
            return reportElementList;
        }
    }
}
