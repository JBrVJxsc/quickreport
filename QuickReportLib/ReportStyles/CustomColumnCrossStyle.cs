using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FarPoint.Win.Spread;
using QuickReportLib.Objects;
using QuickReportLib.Objects.CustomSetting;
using QuickReportLib.Objects.ReportStyleSetting;
using QuickReportLib.Interfaces.ReportStyle;
using QuickReportLib.Forms.Wizard;
using QuickReportLib.Forms.Wizard.ReportStyle;
using QuickReportLib.Controls.ReportSetting.ReportStyleSetting;

namespace QuickReportLib.ReportStyles
{
    /// <summary>
    /// 自定义列的交叉报表样式。
    /// </summary>
    public class CustomColumnCrossStyle : BaseReportStyle
    {
        private CustomColumnCrossStyleSetting customColumnCrossStyleSetting = new CustomColumnCrossStyleSetting();

        public override string GetStyleName()
        {
            return "自定义列交叉报表";
        }

        public override string GetStyleSummary()
        {
            return "列由指定SQL生成的交叉报表。";
        }

        public override int GetStyleSortID()
        {
            return 2;
        }

        public override Image GetStylePreview()
        {
            return global::QuickReportLib.Properties.Resources.CustomColumnCrossStylePreview;
        }

        public override BaseStyleSetting ReportStyleSettingObject
        {
            get
            {
                return customColumnCrossStyleSetting;
            }
            set
            {
                customColumnCrossStyleSetting = value as CustomColumnCrossStyleSetting;
            }
        }

        public override bool CanEditColumn()
        {
            return false;
        }

        public override IReportStyleSettingUserControl GetStyleSettingUserControl()
        {
            CustomColumnCrossStyleSettingUserControl customColumnCrossStyleSettingUserControl = new CustomColumnCrossStyleSettingUserControl();
            return customColumnCrossStyleSettingUserControl;
        }

        public override BaseWizard GetStyleSettingWizard(Report report)
        {
            return new CustomColumnCrossStyleWizard(report);
        }

        public override int Process(SheetView sheet, Report report, PrintSetting printSetting, ref string err)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string TranslateStringWithColumnValue(string str)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string TranslateStringWithDonamicValue(string str)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string[][] GetSelectedDatas()
        {
            return null;
        }
    }
}
