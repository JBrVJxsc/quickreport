using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting;

namespace QuickReportLib.Interfaces.ReportLayoutStyle
{
    /// <summary>
    /// ��������ʽ��ʵ�ִ˽ӿڡ�
    /// </summary>
    public interface IReportLayoutStyle
    {
        /// <summary>
        /// �����ʽ���ơ�
        /// </summary>
        /// <returns>��ʽ���ơ�</returns>
        string GetLayoutStyleName();

        /// <summary>
        /// �����ʽ��顣
        /// </summary>
        /// <returns>��ʽ��顣</returns>
        string GetLayoutStyleSummary();

        /// <summary>
        /// �����ʽʾ��ͼƬ��
        /// </summary>
        /// <returns>��ʽʾ��ͼƬ��</returns>
        Image GetLayoutStylePreview();

        /// <summary>
        /// ��ò�����ʽ����š�
        /// </summary>
        /// <returns>��š�</returns>
        int GetStyleSortID();

        /// <summary>
        /// ����������ı���Ԫ�ء�
        /// </summary>
        /// <returns>����Ԫ�ؼ��ϡ�</returns>
        List<ReportElement> GetReportElements();

        /// <summary>
        /// ��ý��沼������ı������ÿؼ���
        /// </summary>
        /// <returns>���ÿؼ���</returns>
        IReportSettingUserControl[] GetReportSettingControls();

        /// <summary>
        /// ��ȡ���沼��֧�ֵĿؼ���
        /// </summary>
        /// <returns>֧�ֿؼ���</returns>
        IReportLayoutStyleShowUserControl GetLayoutStyleShowUserControl();
    }
}
