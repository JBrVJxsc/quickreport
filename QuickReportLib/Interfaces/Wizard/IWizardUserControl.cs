using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using QuickReportLib.Objects;

namespace QuickReportLib.Interfaces.Wizard
{
    /// <summary>
    /// �򵼿ؼ���ʵ�ִ˽ӿڡ�
    /// </summary>
    internal interface IWizardUserControl
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
        /// ���ֵĴ���
        /// </summary>
        int SortID
        {
            get;
        }

        /// <summary>
        /// �򵼱��⡣
        /// </summary>
        string Title
        {
            get;
        }

        /// <summary>
        /// �򵼼�顣
        /// </summary>
        string Summary
        {
            get;
        }

        /// <summary>
        /// ��ͼƬ��
        /// </summary>
        Image Image
        {
            get;
        }

        /// <summary>
        /// У��¼�롣
        /// </summary>
        /// <returns>false��ΪУ��δͨ����trueΪУ��ͨ����</returns>
        bool CanNext();
    }
}
