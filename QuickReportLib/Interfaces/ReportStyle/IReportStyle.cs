using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FarPoint.Win.Spread;
using QuickReportLib.Enums;
using QuickReportLib.Objects;
using QuickReportLib.Objects.ReportStyleSetting;
using QuickReportLib.Forms.Wizard;
using QuickReportLib.Objects.CustomSetting;
using QuickReportLib.Objects.ReportSetting;
using QuickReportLib.Interfaces.ReportSetting;

namespace QuickReportLib.Interfaces.ReportStyle
{
    /// <summary>
    /// ������ʽ��ʵ�ִ˽ӿڡ�
    /// </summary>
    public interface IReportStyle
    {
        /// <summary>
        /// ��Ҫ�������淭���ַ���ʱ�����������¼���
        /// </summary>
        event AskForTranslationHandle AskForTranslation;

        /// <summary>
        /// �����ʽ���ơ�
        /// </summary>
        /// <returns>��ʽ���ơ�</returns>
        string GetStyleName();

        /// <summary>
        /// �����ʽ��顣
        /// </summary>
        /// <returns>��ʽ��顣</returns>
        string GetStyleSummary();

        /// <summary>
        /// �����ʽ��š�
        /// </summary>
        /// <returns>��š�</returns>
        int GetStyleSortID();

        /// <summary>
        /// �����ʽʾ��ͼƬ��
        /// </summary>
        /// <returns>��ʽʾ��ͼƬ��</returns>
        Image GetStylePreview();

        /// <summary>
        /// ��ʽ������ʵ�塣
        /// </summary>
        BaseStyleSetting ReportStyleSettingObject
        {
            get;
            set;
        }

        /// <summary>
        /// �Ƿ���Ա༭�С�
        /// </summary>
        /// <returns>true�����Ա༭��false�����ɱ༭��</returns>
        bool CanEditColumn();

        /// <summary>
        /// �����ʽ�����ý��档
        /// </summary>
        /// <returns>��ʽ���ý��档</returns>
        IReportStyleSettingUserControl GetStyleSettingUserControl();

        /// <summary>
        /// ��ʽ���򵼽��档
        /// </summary>
        /// <returns>�򵼽��档</returns>
        BaseWizard GetStyleSettingWizard(Report report);

        /// <summary>
        /// ���������ݡ�
        /// </summary>
        /// <param name="sheet">��Ҫ�����Sheet��</param>
        /// <param name="report">����ʵ�塣</param>
        /// <param name="printSetting">��ӡ���á�</param>
        /// <param name="err">������Ϣ��</param>
        /// <returns>1�ɹ���-1ʧ�ܡ�</returns>
        int Process(SheetView sheet, Report report, PrintSetting printSetting, ref string err);

        /// <summary>
        /// ��ѡ���з����ַ�����
        /// </summary>
        /// <param name="str">��Ҫ������ַ�����</param>
        /// <returns>�������ַ�����</returns>
        string TranslateStringWithColumnValue(string str);

        /// <summary>
        /// �Զ�̬���������ַ�����
        /// </summary>
        /// <param name="str">��Ҫ������ַ�����</param>
        /// <returns>�������ַ�����</returns>
        string TranslateStringWithDonamicValue(string str);

        /// <summary>
        /// ��ȡ������ѡ�е����ݡ�
        /// </summary>
        /// <returns>ѡ�е����ݡ�</returns>
        string[][] GetSelectedDatas();
    }

    /// <summary>
    /// ��Ҫ�������淭���ַ���ʱ����ִ�еķ�����
    /// </summary>
    /// <param name="sender">�¼�Դ��</param>
    /// <param name="translationType">�������ࡣ</param>
    /// <param name="str">�������ַ�����</param>
    public delegate void AskForTranslationHandle(object sender,ReportStyleAskForTranslationType translationType,ref string str);
}
