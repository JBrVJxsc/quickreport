using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using QuickReportLib.Enums;

namespace QuickReportLib.Controls.GlobalValue
{
    internal partial class TextBoxForNormalGlobalValueAsker : BaseTextBoxForGlobalValue
    {
        public TextBoxForNormalGlobalValueAsker()
        {
            InitializeComponent();
        }

        protected override List<GlobalValueType> GlobalValueTypes
        {
            get
            {
                if (globalValueTypeList == null)
                {
                    globalValueTypeList = new List<GlobalValueType>();
                    globalValueTypeList.Add(GlobalValueType.Date);
                    globalValueTypeList.Add(GlobalValueType.DateTime);
                    globalValueTypeList.Add(GlobalValueType.Person);
                    globalValueTypeList.Add(GlobalValueType.Department);
                }
                return base.GlobalValueTypes;
            }
        }
    }
}
