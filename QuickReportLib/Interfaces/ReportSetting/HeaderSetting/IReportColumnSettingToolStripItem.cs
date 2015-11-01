using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Objects;
using QuickReportLib.Controls;

namespace QuickReportLib.Interfaces.ReportSetting.HeaderSetting
{
    /// <summary>
    /// ���ڱ����е����õ�ToolStripItem��ʵ�ִ˽ӿڡ�
    /// </summary>
    internal interface IReportColumnSettingToolStripItem
    {
        /// <summary>
        /// FpSpread�����ı�ʱ�������¼���
        /// </summary>
        event HeaderSettingFpSpreadChangedHandle HeaderSettingFpSpreadChanged;

        /// <summary>
        /// ��ȡ������Column��
        /// </summary>
        Column Column
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

        /// <summary>
        /// �Ƿ�ɼ���
        /// </summary>
        bool IsVisible
        {
            get;
            set;
        }
    }
}
