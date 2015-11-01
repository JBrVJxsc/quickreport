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
    public class ConditionTop_TreeBottomLeft_MainBottomRightTop_DetailBottomRightBottom : BaseReportLayoutStyle
    {

        public override string GetLayoutStyleName()
        {
            return "������";
        }

        public override string GetLayoutStyleSummary()
        {
            return "�������Ϸ������������·�����࣬�������������Ҳ���Ϸ�����ϸ��������������·���";
        }

        public override Image GetLayoutStylePreview()
        {
            return global::QuickReportLib.Properties.Resources.LayoutPreview_ConditionTop_TreeBottomLeft_MainBottomRightTop_DetailBottomRightBottom;
        }

        public override int GetStyleSortID()
        {
            return 2;
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
            reportElementList.Add(ReportElement.Condition);
            reportElementList.Add(ReportElement.Tree);
            reportElementList.Add(ReportElement.MainReport);
            reportElementList.Add(ReportElement.DetailReport);
            return reportElementList;
        }
    }
}
