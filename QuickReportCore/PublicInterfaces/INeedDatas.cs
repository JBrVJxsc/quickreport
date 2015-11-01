using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore.PublicInterfaces
{
    /// <summary>
    /// ��Ҫ�ӱ�������ϻ�ȡ���ݲ����д���ʱ����ʵ�ִ˽ӿڡ�
    /// </summary>
    public interface INeedDatas : QuickReportCore.Interfaces.IAmPublicInterface
    {
        void GetDatas(string[] datas);
        event DoneHandle Done;
    }

    /// <summary>
    /// ���д������Ҫ�������ִ�еĶ�����
    /// </summary>
    /// <param name="doneAction">���д���󱨱����ִ�еĶ���</param>
    public delegate void DoneHandle(DoneAction doneAction);

    /// <summary>
    /// ���д���󱨱����ִ�еĶ�����
    /// </summary>
    public enum DoneAction
    {
        /// <summary>
        /// ִ�в�ѯ��
        /// </summary>
        Query,
        /// <summary>
        /// ɾ����������ǰ��ѡ�е��С�
        /// </summary>
        DeleteSelectedRow,
        /// <summary>
        /// ��ձ�����档
        /// </summary>
        ClearReport,
        /// <summary>
        /// ʲô��������
        /// </summary>
        None
    }
}
