using System;

namespace QuickReportLib.Enums
{
    /// <summary>
    /// IDatas接口执行完毕后，报表界面执行的动作类型。
    /// </summary>
    public enum IDatasAskerDoneAction
    {
        /// <summary>
        /// 执行查询。
        /// </summary>
        Query,
        /// <summary>
        /// 删除弹出界面前所选中的行。
        /// </summary>
        DeleteSelectedRow,
        /// <summary>
        /// 清空报表界面。
        /// </summary>
        ClearReport,
        /// <summary>
        /// 什么都不做。
        /// </summary>
        None
    }
}
