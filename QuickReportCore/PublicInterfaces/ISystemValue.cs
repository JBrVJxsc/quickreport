using System;
using System.Collections.Generic;
using System.Text;
using QuickReportCore.Interfaces;

namespace QuickReportCore.PublicInterfaces
{
    /// <summary>
    /// ��Ҫ�Զ���ϵͳ����ʱ����ʵ�ִ˽ӿڡ�
    /// </summary>
    public interface ISystemValue : QuickReportCore.Interfaces.IAmPublicInterface
    {
        /// <summary>
        /// ����ID��
        /// </summary>
        string ValueID
        {
            get;
        }

        /// <summary>
        /// �������ơ�
        /// </summary>
        string ValueName
        {
            get;
        }

        /// <summary>
        /// ������ֵ��
        /// </summary>
        string Value
        {
            get;
        }

        /// <summary>
        /// ���������͡�����ʾ�ڱ������������ĸ�ͼ�����йء�
        /// </summary>
        Objects.SystemValues.SystemValueType SystemValueType
        {
            get;
        }
    }
}
