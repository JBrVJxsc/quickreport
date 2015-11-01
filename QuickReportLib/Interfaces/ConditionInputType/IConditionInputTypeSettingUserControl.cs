using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Objects.ConditionInputTypeSetting;
using QuickReportLib.Interfaces.ReportSetting;

namespace QuickReportLib.Interfaces.ConditionInputType
{
    /// <summary>
    /// IConditionInputType�����ý��棬��ʵ�ִ˽ӿڡ�
    /// </summary>
    public interface IConditionInputTypeSettingUserControl
    {
        /// <summary>
        /// ¼����������ʵ�塣
        /// </summary>
        BaseInputTypeSetting ConditionInputTypeSettingObject
        {
            get;
            set;
        }

        /// <summary>
        /// ���¼�롣
        /// </summary>
        /// <returns>-1Ϊʧ�ܣ�1Ϊ�ɹ���</returns>
        int CheckInput();

        /// <summary>
        /// ϣ�����ؼ���ʾ����ǰ�ˣ����������¼���
        /// </summary>
        event AskForBringToFrontHandle AskForBringToFront;
    }
}
