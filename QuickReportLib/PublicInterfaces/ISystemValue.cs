using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Interfaces.PublicInterface;
using QuickReportLib.Enums;

namespace QuickReportLib.PublicInterfaces
{
    /// <summary>
    /// ��Ҫ�Զ���ϵͳ����ʱ����ʵ�ִ˽ӿڡ�
    /// </summary>
    public interface ISystemValue : IPublicInterface
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
        /// ���������͡�ÿ�����Ͷ�Ӧ�����������ڡ�����ʱ�䡢��Ա�������е�һ��ͼ�ꡣ
        /// </summary>
        SystemValueType ValueType
        {
            get;
        }
    }
}
