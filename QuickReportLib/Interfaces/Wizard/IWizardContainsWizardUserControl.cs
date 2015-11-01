using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.Objects;

namespace QuickReportLib.Interfaces.Wizard
{
    /// <summary>
    /// 当向导包含向导时，需实现此接口。
    /// </summary>
    internal interface IWizardContainsWizardUserControl : IWizardUserControl
    {
        /// <summary>
        /// 向导的向导完成后出发的事件。
        /// </summary>
        event WizardOfWizardDoneHandle WizardOfWizardDone;

        /// <summary>
        /// 显示向导的向导。
        /// </summary>
        void ShowWizard();
    }

    /// <summary>
    /// 向导的向导完成后执行的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="report">报表实体。</param>
    /// <param name="doneAction">结束后的操作。</param>
    internal delegate void WizardOfWizardDoneHandle(object sender,Report report, WizardOfWizardDoneAction doneAction);
}
