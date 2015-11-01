using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace QuickReportLib.Interfaces
{
    /// <summary>
    /// ����������Ĺ���������ʾ��Ŀ����ʵ�ִ˽ӿڡ�
    /// </summary>
    internal interface IToolStripMenuProvider
    {
        /// <summary>
        /// ����������������ʾ����Ŀʱ���������¼���
        /// </summary>
        event ProvideToolStripMenuHandle ProvideToolStripMenu;
    }

    /// <summary>
    /// ����������������ʾ����Ŀʱ��ִ�еķ�����
    /// </summary>
    /// <param name="sender">�¼�Դ��</param>
    /// <param name="toolStripItems">��Ŀ�б�</param>
    internal delegate void ProvideToolStripMenuHandle(object sender,ToolStripItem[] toolStripItems);
}
