using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects;

namespace QuickReportLib.Interfaces.ReportSetting
{
    /// <summary>
    /// Ϊ�����ṩ���ý�����û��ؼ���ʵ�ִ˽ӿڡ�
    /// </summary>
    public interface IReportSettingUserControl 
    {
        /// <summary>
        /// ����ʵ�塣
        /// </summary>
        Report Report
        {
            get;
            set;
        }

        /// <summary>
        /// ���ơ�
        /// </summary>
        string SettingName
        {
            get;
        }

        /// <summary>
        /// ��顣
        /// </summary>
        string SettingSummary
        {
            get;
        }

        /// <summary>
        /// ���档
        /// </summary>
        /// <returns>�ɹ�����1��ʧ�ܷ���-1��</returns>
        int Save();

        /// <summary>
        /// ��ȡ��Ҫ�ϴ����������İ�ť��
        /// </summary>
        /// <returns>��Ҫ�ϴ����������İ�ť��</returns>
        ToolStripItem[] GetToolStripItems();

        /// <summary>
        /// ϣ�����ؼ���ʾ����ǰ�ˣ����������¼���
        /// </summary>
        event AskForBringToFrontHandle AskForBringToFront;
    }
}
