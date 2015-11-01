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
    public class Main : BaseReportLayoutStyle
    {

        public override string GetLayoutStyleName()
        {
            return "布局六";
        }

        public override string GetLayoutStyleSummary()
        {
            return "主报表在中间。";
        }

        public override Image GetLayoutStylePreview()
        {
            return global::QuickReportLib.Properties.Resources.LayoutStylePreview_Main;
        }

        public override int GetStyleSortID()
        {
            return 5;
        }

        public override IReportSettingUserControl[] GetReportSettingControls()
        {
            IReportSettingUserControl[] settingUserControls = new IReportSettingUserControl[2];
            settingUserControls[0] = new BaseInfoSetting();
            settingUserControls[1] = new InterfaceSetting();
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
            return reportElementList;
        }
    }
}
