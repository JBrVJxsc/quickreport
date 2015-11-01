using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore.PublicInterfaces
{
    /// <summary>
    /// 需要从报表界面上获取数据并自行处理时，需实现此接口。
    /// </summary>
    public interface INeedDatas : QuickReportCore.Interfaces.IAmPublicInterface
    {
        void GetDatas(string[] datas);
        event DoneHandle Done;
    }

    /// <summary>
    /// 自行处理后，需要报表界面执行的动作。
    /// </summary>
    /// <param name="doneAction">自行处理后报表界面执行的动作</param>
    public delegate void DoneHandle(DoneAction doneAction);

    /// <summary>
    /// 自行处理后报表界面执行的动作。
    /// </summary>
    public enum DoneAction
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
