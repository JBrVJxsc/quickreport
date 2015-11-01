using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using FarPoint.Win.Spread;
using QuickReportLib.Interfaces.ReportStyle;
using QuickReportLib.Objects;
using QuickReportLib.Objects.ReportStyleSetting;
using QuickReportLib.Objects.CustomSetting;
using QuickReportLib.Forms.Wizard;

namespace QuickReportLib.ReportStyles
{
    /// <summary>
    /// 报表样式的基础抽象类。
    /// </summary>
    [XmlInclude(typeof(GridStyle))]
    [XmlInclude(typeof(GeneralCrossStyle))]
    [XmlInclude(typeof(CustomColumnCrossStyle))]
    public abstract class BaseReportStyle : IReportStyle
    {
        #region IReportStyle 成员

        public event AskForTranslationHandle AskForTranslation;

        public abstract string GetStyleName();

        public abstract string GetStyleSummary();

        public abstract int GetStyleSortID();

        public abstract Image GetStylePreview();

        public abstract BaseStyleSetting ReportStyleSettingObject
        {
            get;
            set;
        }

        public abstract bool CanEditColumn();

        public abstract IReportStyleSettingUserControl GetStyleSettingUserControl();

        public abstract BaseWizard GetStyleSettingWizard(Report report);

        public abstract int Process(SheetView sheet, Report report, PrintSetting printSetting, ref string err);

        public abstract string TranslateStringWithColumnValue(string str);

        public abstract string TranslateStringWithDonamicValue(string str);

        public abstract string[][] GetSelectedDatas();

        #endregion
    }
}
