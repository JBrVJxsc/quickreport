using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace QuickReport.Interfaces
{
    public delegate void ClickButtonHandle(XmlElement defaultValue);
    public interface IDefaultValueUserControl
    {
        event ClickButtonHandle ClickButton;
        void InitValue(QuickReport.Objects.Condition condition);
        QuickReport.Objects.Condition.ConditionInputType ConditionInputType
        { get; }
        Control EditControl
        { get; }
        string EditControlValue
        { get; }
    }
}
