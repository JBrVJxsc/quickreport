using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Interfaces.PublicInterface;
using QuickReportLib.Enums;

namespace QuickReportLib.PublicInterfaces
{
    /// <summary>
    /// ��Ҫ�ӱ�������ϻ�ȡ���ݲ����д���ʱ����ʵ�ִ˽ӿڡ�
    /// </summary>
    public interface IDatasAsker : IPublicInterface
    {
        /// <summary>
        /// �ӱ�������ϻ�����ݡ�
        /// </summary>
        /// <param name="datas">�����ϵ����ݡ�</param>
        void GetDatas(string[] datas);
        /// <summary>
        /// ���д���󱨱����ִ�еĶ�����
        /// </summary>
        event DoneHandle Done;
    }

    /// <summary>
    /// ���д������Ҫ�������ִ�еĶ�����
    /// </summary>
    /// <param name="doneAction">���д���󱨱����ִ�еĶ���</param>
    public delegate void DoneHandle(IDatasAskerDoneAction doneAction);
}
