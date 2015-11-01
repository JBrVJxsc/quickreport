using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Interfaces
{
    internal interface INeedRefreshDataSource
    {
        void RefreshDataSource(Forms.frmToolBoxSystemValue.GobalValueType type);
        List<Forms.frmToolBoxSystemValue.GobalValueType> GobalValueTypesNeeded();
    }
}
