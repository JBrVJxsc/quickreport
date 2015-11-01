using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Enums;
using QuickReportLib.Objects;

namespace QuickReportLib.Interfaces.Wizard
{
    /// <summary>
    /// ���򵼰�����ʱ����ʵ�ִ˽ӿڡ�
    /// </summary>
    internal interface IWizardContainsWizardUserControl : IWizardUserControl
    {
        /// <summary>
        /// �򵼵�����ɺ�������¼���
        /// </summary>
        event WizardOfWizardDoneHandle WizardOfWizardDone;

        /// <summary>
        /// ��ʾ�򵼵��򵼡�
        /// </summary>
        void ShowWizard();
    }

    /// <summary>
    /// �򵼵�����ɺ�ִ�еķ�����
    /// </summary>
    /// <param name="sender">�¼�Դ��</param>
    /// <param name="report">����ʵ�塣</param>
    /// <param name="doneAction">������Ĳ�����</param>
    internal delegate void WizardOfWizardDoneHandle(object sender,Report report, WizardOfWizardDoneAction doneAction);
}
