using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using QuickReportLib.Objects;

namespace QuickReportLib.Interfaces.Wizard
{
    /// <summary>
    /// 向导控件需实现此接口。
    /// </summary>
    internal interface IWizardUserControl
    {
        /// <summary>
        /// 报表实体。
        /// </summary>
        Report Report
        {
            get;
            set;
        }

        /// <summary>
        /// 出现的次序。
        /// </summary>
        int SortID
        {
            get;
        }

        /// <summary>
        /// 向导标题。
        /// </summary>
        string Title
        {
            get;
        }

        /// <summary>
        /// 向导简介。
        /// </summary>
        string Summary
        {
            get;
        }

        /// <summary>
        /// 向导图片。
        /// </summary>
        Image Image
        {
            get;
        }

        /// <summary>
        /// 校验录入。
        /// </summary>
        /// <returns>false，为校验未通过；true为校验通过。</returns>
        bool CanNext();
    }
}
