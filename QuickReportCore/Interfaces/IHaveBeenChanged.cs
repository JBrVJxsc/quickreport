using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Interfaces
{
    internal delegate void HaveBeenChangedHandle(object sender, EventArgs e);

    internal interface IHaveBeenChanged
    {
        event HaveBeenChangedHandle HaveBeenChanged;
    }
}
