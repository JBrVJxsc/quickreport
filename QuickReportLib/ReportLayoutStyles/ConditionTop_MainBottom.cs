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
    public class ConditionTop_MainBottom : BaseReportLayoutStyle
    {

        public override string GetLayoutStyleName()
        {
            return "布局一";
        }

        public override string GetLayoutStyleSummary()
        {
            return "条件在上方，主报表在条件的下方。";
        }

        public override Image GetLayoutStylePreview()
        {
            return global::QuickReportLib.Properties.Resources.LayoutStylePreview_ConditionTop_MainBottom;
        }

        public override int GetStyleSortID()
        {
            return 0;
        }

        public override IReportSettingUserControl[] GetReportSettingControls()
        {
             IReportSettingUserControl[] settingUserControls=new IReportSettingUserControl[3];
             settingUserControls[0] = new BaseInfoSetting();
             settingUserControls[1] = new ConditionSetting();
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
            reportElementList.Add(ReportElement.Condition);
            reportElementList.Add(ReportElement.MainReport);
            return reportElementList;
        }
    }
}
