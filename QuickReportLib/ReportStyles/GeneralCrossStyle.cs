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
    /// 交叉报表样式。
    /// </summary>
    public class GeneralCrossStyle : BaseReportStyle
    {

        private GeneralCrossStyleSetting generalCrossStyleSetting = new GeneralCrossStyleSetting();

        public override string GetStyleName()
        {
            return "普通交叉报表";
        }

        public override string GetStyleSummary()
        {
            return "由两列数据交叉指向唯一数据的报表。";
        }

        public override int GetStyleSortID()
        {
            return 1;
        }

        public override Image GetStylePreview()
        {
            return global::QuickReportLib.Properties.Resources.GeneralCrossStylePreview;
        }

        public override BaseStyleSetting ReportStyleSettingObject
        {
            get
            {
                return generalCrossStyleSetting;
            }
            set
            {
                generalCrossStyleSetting = value as GeneralCrossStyleSetting;
            }
        }

        public override bool CanEditColumn()
        {
            return false;
        }

        public override IReportStyleSettingUserControl GetStyleSettingUserControl()
        {
            GeneralCrossStyleSettingUserControl generalCrossStyleSettingUserControl=new GeneralCrossStyleSettingUserControl();
            return generalCrossStyleSettingUserControl;
        }

        public override BaseWizard GetStyleSettingWizard(Report report)
        {
            return new GeneralCrossStyleWizard(report);
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
