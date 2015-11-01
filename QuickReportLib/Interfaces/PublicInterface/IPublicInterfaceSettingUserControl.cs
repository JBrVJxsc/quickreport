using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Objects.ReportSetting;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting;

namespace QuickReportLib.Interfaces.PublicInterface
{
    /// <summary>
    /// ����繫���Ľӿ����ý��棬��ʵ�ִ˽ӿڡ�
    /// </summary>
    internal interface IPublicInterfaceSettingUserControl : IGlobalValueProvider, IChangedUserControl
    {
        /// <summary>
        /// Ϊ���ֽӿڷ���
        /// </summary>
        Type InterfaceType
        {
            get;
        }

        /// <summary>
        /// �ӿ�����ʵ�塣
        /// </summary>
        InterfaceSetting InterfaceSetting
        {
            get;
            set;
        }

        /// <summary>
        /// ������
        /// </summary>
        void Add();

        /// <summary>
        /// ɾ����
        /// </summary>
        void Delete();

        /// <summary>
        /// �����ƶ���
        /// </summary>
        void Up();

        /// <summary>
        /// �����ƶ���
        /// </summary>
        void Down();

        /// <summary>
        /// ���¼�롣
        /// </summary>
        /// <returns>1Ϊ�ɹ���-1Ϊʧ�ܡ�</returns>
        int CheckInput();

        /// <summary>
        /// ��ȡ����Ҫ�Ĺ������������ࡣ
        /// </summary>
        /// <returns>�������ࡣ</returns>
        List<InterfaceSettingToolStripButtonType> GetNeededToolStripButtons();

        /// <summary>
        /// ֪ͨ�Ѿ�������ϡ�
        /// </summary>
        void Loaded();
    }
}
