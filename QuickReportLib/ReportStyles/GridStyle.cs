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
    /// 网格报表样式。
    /// </summary>
    public class GridStyle : BaseReportStyle
    {
        private GridStyleSetting gridStyleSetting = new GridStyleSetting();

        public override string GetStyleName()
        {
            return "网格报表";
        }

        public override string GetStyleSummary()
        {
            return "列由SQL生成的报表。";
        }

        public override int GetStyleSortID()
        {
            return 0;
        }

        public override Image GetStylePreview()
        {
            return global::QuickReportLib.Properties.Resources.GridStylePreview;
        }

        public override BaseStyleSetting  ReportStyleSettingObject
        {
            get 
            {
                return gridStyleSetting;
            }
            set
            {
                gridStyleSetting = value as GridStyleSetting;
            }
        }

        public override bool CanEditColumn()
        {
            return true;
        }

        public override IReportStyleSettingUserControl GetStyleSettingUserControl()
        {
            GridStyleSettingUserControl gridStyleSettingUserControl = new GridStyleSettingUserControl();
            return gridStyleSettingUserControl;
        }

        public override BaseWizard GetStyleSettingWizard(Report report)
        {
            return null;
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
