using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Interfaces
{
    /// <summary>
    /// ��Ҫ���¼��Ŀؼ���ʵ�ִ˽ӿڡ�
    /// </summary>
    internal interface ICheckInput
    {
        /// <summary>
        /// ���¼�롣
        /// </summary>
        /// <returns>1�ɹ���-1ʧ�ܡ�</returns>
        int CheckInput();
    }
}
