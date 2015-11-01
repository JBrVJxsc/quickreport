using System;

namespace QuickReportLib.Enums
{
    /// <summary>
    /// 包含向导的向导在结束时所进行的操作。
    /// </summary>
    public enum WizardOfWizardDoneAction
    {
        /// <summary>
        /// 继续下一个向导。
        /// </summary>
        Continue,
        /// <summary>
        /// 停止。
        /// </summary>
        Stay,
        /// <summary>
        /// 结束向导。
        /// </summary>
        Done
    }
}
