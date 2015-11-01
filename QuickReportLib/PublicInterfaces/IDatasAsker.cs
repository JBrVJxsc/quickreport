using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Interfaces.PublicInterface;
using QuickReportLib.Enums;

namespace QuickReportLib.PublicInterfaces
{
    /// <summary>
    /// 需要从报表界面上获取数据并自行处理时，需实现此接口。
    /// </summary>
    public interface IDatasAsker : IPublicInterface
    {
        /// <summary>
        /// 从报表界面上获得数据。
        /// </summary>
        /// <param name="datas">报表上的数据。</param>
        void GetDatas(string[] datas);
        /// <summary>
        /// 自行处理后报表界面执行的动作。
        /// </summary>
        event DoneHandle Done;
    }

    /// <summary>
    /// 自行处理后，需要报表界面执行的动作。
    /// </summary>
    /// <param name="doneAction">自行处理后报表界面执行的动作</param>
    public delegate void DoneHandle(IDatasAskerDoneAction doneAction);
}
