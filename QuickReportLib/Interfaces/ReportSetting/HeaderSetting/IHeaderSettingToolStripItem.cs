using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Controls;
using QuickReportLib.Enums;

namespace QuickReportLib.Interfaces.ReportSetting.HeaderSetting
{
    /// <summary>
    /// �����ͷ������Ĺ��߳�Ա��ʵ�ִ˽ӿڡ�
    /// </summary>
    internal interface IHeaderSettingToolStripItem
    {
        /// <summary>
        /// ��������״̬��
        /// </summary>
        /// <param name="commandStatus">����״̬��</param>
        void SetCommandStatus(HeaderSettingCommandStatus commandStatus);

        /// <summary>
        /// ��ȡ������FpSpread��
        /// </summary>
        FpSpreadForHeaderSetting FpSpread
        {
            get;
            set;
        }

        /// <summary>
        /// ��š�
        /// </summary>
        int SortID
        {
            get;
        }
    }
}
