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
    public class TreeLeft_MainRightTop_DetailRightBottom : BaseReportLayoutStyle
    {

        public override string GetLayoutStyleName()
        {
            return "布局八";
        }

        public override string GetLayoutStyleSummary()
        {
            return "条件在左侧，主报表在右侧的上方，明细报表在主报表的下方。";
        }

        public override Image GetLayoutStylePreview()
        {
            return global::QuickReportLib.Properties.Resources.LayoutStylePreview_TreeLeft_MainRightTop_DetailRightBottom;
        }

        public override int GetStyleSortID()
        {
            return 7;
        }

        public override IReportSettingUserControl[] GetReportSettingControls()
        {
            IReportSettingUserControl[] settingUserControls = new IReportSettingUserControl[4];
            settingUserControls[0] = new BaseInfoSetting();
            settingUserControls[1] = new TreeSetting();
            settingUserControls[2] = new DetailReportSetting();
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
            reportElementList.Add(ReportElement.Tree);
            reportElementList.Add(ReportElement.MainReport);
            reportElementList.Add(ReportElement.DetailReport);
            return reportElementList;
        }
    }
}
