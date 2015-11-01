using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Interfaces
{
    /// <summary>
    /// Report接口。用于版本更新。
    /// </summary>
    internal interface IAmReport
    {
        /// <summary>
        /// 当不需要更改Report的Xml文件时，则只需更改小数位；否则小数点前的数字+1，同时小数位清零。
        /// </summary>
        decimal Version
        {
            get;
        }

        void LoadReport(QuickReportCore.Objects.QuickReportObject qr);

        string Err
        {
            get;
            set;
        }

        void ShowSetting();

        int Print();

        int Query();

        int Export();
    }
}
