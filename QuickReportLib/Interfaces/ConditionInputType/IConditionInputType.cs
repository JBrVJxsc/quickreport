using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects.ConditionInputTypeSetting;

namespace QuickReportLib.Interfaces.ConditionInputType
{
    /// <summary>
    /// ������¼��������ʵ�ִ˽ӿڡ�
    /// </summary>
    public interface IConditionInputType
    {
        /// <summary>
        /// ���¼�����͵����ơ�
        /// </summary>
        /// <returns>¼�����͵����ơ�</returns>
        string GetConditionInputTypeName();

        /// <summary>
        /// ���¼�����ͼ�顣
        /// </summary>
        /// <returns>¼�����͵ļ�顣</returns>
        string GetConditionInputTypeSummary();

        /// <summary>
        /// �������¼�����͵Ŀؼ���
        /// </summary>
        /// <returns>¼�����͵Ŀؼ���</returns>
        Control GetEditorControl();

        /// <summary>
        /// ¼�����͵�����ʵ�塣
        /// </summary>
        BaseInputTypeSetting ConditionInputTypeSettingObject
        {
            get;
            set;
        }

        /// <summary>
        /// ���¼�����͵����ý��档
        /// </summary>
        /// <returns>¼�����͵����ý��档</returns>
        IConditionInputTypeSettingUserControl GetConditionInputTypeSettingUserControl(EventHandler changed);

        /// <summary>
        /// �ڵ�һ�δ���ʱ�������ʼ���Լ������ݡ�
        /// </summary>
        void Init();
    }
}
