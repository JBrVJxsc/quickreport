using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;

namespace QuickReportLib.Interfaces.ReportUserControl
{
    /// <summary>
    /// ���ؼ���Ҫ������淭���ַ���ʱ����ʵ�ֵĽӿڡ�
    /// </summary>
    internal interface ISendTranslateValueCommandUserControl
    {
        /// <summary>
        /// ��ȡ������һ��ֵ����ʾ�ÿؼ��������󱨱���淭��Ĺ����С�
        /// </summary>
        bool Translating
        { 
            get;
            set;
        }

        /// <summary>
        /// ���ؼ���Ҫ������淭���ַ���ʱ�����������¼���
        /// </summary>
        event SendTranslateValueCommandHandle TranslateValue;
    }

    /// <summary>
    /// ���ؼ���Ҫ������淭���ַ���ʱ����ִ�еķ�����
    /// </summary>
    /// <param name="value">��Ҫ��������ַ�����</param>
    /// <param name="valueTranslated">�������ַ�����</param>
    /// <param name="types">��Ҫ�����SQLCode���͡�</param>
    internal delegate void SendTranslateValueCommandHandle(string value, out string valueTranslated, SQLCodeType[] types);
}
