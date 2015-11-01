using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;

namespace QuickReportLib.Interfaces.ReportUserControl
{
    /// <summary>
    /// 当控件需要报表界面翻译字符串时，需实现的接口。
    /// </summary>
    internal interface ISendTranslateValueCommandUserControl
    {
        /// <summary>
        /// 获取或设置一个值，表示该控件正在请求报表界面翻译的过程中。
        /// </summary>
        bool Translating
        { 
            get;
            set;
        }

        /// <summary>
        /// 当控件需要报表界面翻译字符串时，所触发的事件。
        /// </summary>
        event SendTranslateValueCommandHandle TranslateValue;
    }

    /// <summary>
    /// 当控件需要报表界面翻译字符串时，所执行的方法。
    /// </summary>
    /// <param name="value">需要被翻译的字符串。</param>
    /// <param name="valueTranslated">翻译后的字符串。</param>
    /// <param name="types">需要翻译的SQLCode类型。</param>
    internal delegate void SendTranslateValueCommandHandle(string value, out string valueTranslated, SQLCodeType[] types);
}
