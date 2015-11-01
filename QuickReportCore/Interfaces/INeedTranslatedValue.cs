using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Interfaces
{
    internal delegate void NeedTranslatedValueHandle(ref string value, Managers.Functions.SQLCodeType[] types);

    internal interface INeedTranslatedValue
    {
        bool Translating
        { get; set;}
        event NeedTranslatedValueHandle NeedTranslatedValue;
    }
}
