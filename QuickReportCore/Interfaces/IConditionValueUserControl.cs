using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace QuickReportCore.Interfaces
{
    internal delegate void ClickButtonHandle(XmlElement defaultValue);
    internal interface IConditionValue
    {
        event ClickButtonHandle ClickButton;
        void InitValue(QuickReportCore.Objects.Condition condition);
        QuickReportCore.Objects.Condition.InputValueType InputValueType
        { get; }
        Control EditControl
        { get; }
        string EditControlValue
        { get; }
        Objects.Operator[] Operators
        { get; }
        string DefaultOperator
        { get; }
        bool HideOperator
        { get; }
        string EditControlSQLValue
        { get; }
    }
}
