using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Interfaces
{
    /// <summary>
    /// Report�ӿڡ����ڰ汾���¡�
    /// </summary>
    internal interface IAmReport
    {
        /// <summary>
        /// ������Ҫ����Report��Xml�ļ�ʱ����ֻ�����С��λ������С����ǰ������+1��ͬʱС��λ���㡣
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
