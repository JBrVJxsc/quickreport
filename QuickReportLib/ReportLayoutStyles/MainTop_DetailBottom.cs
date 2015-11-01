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
    public class MainTop_DetailBottom : BaseReportLayoutStyle
    {

        public override string GetLayoutStyleName()
        {
            return "布局九";
        }

        public override string GetLayoutStyleSummary()
        {
            return "主报表在上方，明细报表在下方。";
        }

        public override Image GetLayoutStylePreview()
        {
            return global::QuickReportLib.Properties.Resources.LayoutStylePreview_MainTop_DetailBottom;
        }

        public override int GetStyleSortID()
        {
            return 8;
        }

        public override IReportSettingUserControl[] GetReportSettingControls()
        {
            IReportSettingUserControl[] settingUserControls = new IReportSettingUserControl[3];
            settingUserControls[0] = new BaseInfoSetting();
            settingUserControls[1] = new DetailReportSetting();
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
            reportElementList.Add(ReportElement.MainReport);
            reportElementList.Add(ReportElement.DetailReport);
            return reportElementList;
        }
    }
}
