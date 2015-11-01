using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace QuickReportLib.Interfaces.ReportLayoutStyle
{
    /// <summary>
    /// �ṩ���沼��֧�ֵĿؼ���
    /// </summary>
    public interface IReportLayoutStyleShowUserControl
    {
        /// <summary>
        /// ����Panel��
        /// </summary>
        Panel PanelOfTree
        {
            get;
        }

        /// <summary>
        /// ������Panel��
        /// </summary>
        Panel PanelOfCondition
        {
            get;
        }

        /// <summary>
        /// �������Panel��
        /// </summary>
        Panel PanelOfMainReport
        {
            get;
        }

        /// <summary>
        /// ��ϸ�����Panel��
        /// </summary>
        Panel PanelOfDetailReport
        {
            get;
        }
    }
}
