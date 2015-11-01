using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FarPoint.Win.Spread;
using QuickReportLib.Enums;
using QuickReportLib.Objects;
using QuickReportLib.Objects.ReportStyleSetting;
using QuickReportLib.Forms.Wizard;
using QuickReportLib.Objects.CustomSetting;
using QuickReportLib.Objects.ReportSetting;
using QuickReportLib.Interfaces.ReportSetting;

namespace QuickReportLib.Interfaces.ReportStyle
{
    /// <summary>
    /// 报表样式需实现此接口。
    /// </summary>
    public interface IReportStyle
    {
        /// <summary>
        /// 需要请求引擎翻译字符串时，所触发的事件。
        /// </summary>
        event AskForTranslationHandle AskForTranslation;

        /// <summary>
        /// 获得样式名称。
        /// </summary>
        /// <returns>样式名称。</returns>
        string GetStyleName();

        /// <summary>
        /// 获得样式简介。
        /// </summary>
        /// <returns>样式简介。</returns>
        string GetStyleSummary();

        /// <summary>
        /// 获得样式序号。
        /// </summary>
        /// <returns>序号。</returns>
        int GetStyleSortID();

        /// <summary>
        /// 获得样式示例图片。
        /// </summary>
        /// <returns>样式示例图片。</returns>
        Image GetStylePreview();

        /// <summary>
        /// 样式的设置实体。
        /// </summary>
        BaseStyleSetting ReportStyleSettingObject
        {
            get;
            set;
        }

        /// <summary>
        /// 是否可以编辑列。
        /// </summary>
        /// <returns>true，可以编辑；false，不可编辑。</returns>
        bool CanEditColumn();

        /// <summary>
        /// 获得样式的设置界面。
        /// </summary>
        /// <returns>样式设置界面。</returns>
        IReportStyleSettingUserControl GetStyleSettingUserControl();

        /// <summary>
        /// 样式的向导界面。
        /// </summary>
        /// <returns>向导界面。</returns>
        BaseWizard GetStyleSettingWizard(Report report);

        /// <summary>
        /// 处理报表内容。
        /// </summary>
        /// <param name="sheet">需要处理的Sheet。</param>
        /// <param name="report">报表实体。</param>
        /// <param name="printSetting">打印设置。</param>
        /// <param name="err">错误信息。</param>
        /// <returns>1成功；-1失败。</returns>
        int Process(SheetView sheet, Report report, PrintSetting printSetting, ref string err);

        /// <summary>
        /// 以选中列翻译字符串。
        /// </summary>
        /// <param name="str">需要翻译的字符串。</param>
        /// <returns>翻译后的字符串。</returns>
        string TranslateStringWithColumnValue(string str);

        /// <summary>
        /// 以动态变量翻译字符串。
        /// </summary>
        /// <param name="str">需要翻译的字符串。</param>
        /// <returns>翻译后的字符串。</returns>
        string TranslateStringWithDonamicValue(string str);

        /// <summary>
        /// 获取报表中选中的数据。
        /// </summary>
        /// <returns>选中的数据。</returns>
        string[][] GetSelectedDatas();
    }

    /// <summary>
    /// 需要请求引擎翻译字符串时，所执行的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="translationType">翻译种类。</param>
    /// <param name="str">翻译后的字符串。</param>
    public delegate void AskForTranslationHandle(object sender,ReportStyleAskForTranslationType translationType,ref string str);
}
