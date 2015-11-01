using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Interfaces
{
    internal delegate void NeedQueryHandle(object sender);

    internal interface INeedQuery
    {
        event NeedQueryHandle NeedQuery;
    }
}
