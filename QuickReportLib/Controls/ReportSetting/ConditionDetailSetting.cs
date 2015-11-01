using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Managers;
using QuickReportLib.Objects;
using QuickReportLib.Interfaces.ConditionInputType;
using QuickReportLib.ConditionInputType;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Interfaces.ReportSetting;

namespace QuickReportLib.Controls.ReportSetting
{
    internal partial class ConditionDetailSetting : BaseUserControl, IGlobalValueToolStripItemAsker, IChangedUserControl
    {
        public ConditionDetailSetting()
        {
            InitializeComponent();
        }

        private Condition condition;
        public event AskForBringToFrontHandle AskForBringToFront;

        /// <summary>
        /// ������
        /// </summary>
        public Condition Condition
        {
            get
            {
                return condition;
            }
            set
            {
                condition = value;
                if (condition != null)
                {
                    ShowInputTypeSettingUserControl();
                }
                else
                {
                    Controls.Clear();
                }
            }
        }

        private void ShowInputTypeSettingUserControl()
        {
            IConditionInputType iConditionInputType = condition.ConditionInputType;
            if (iConditionInputType != null)
            {
                SuspendLayout();
                Controls.Clear();
                Control control = iConditionInputType.GetConditionInputTypeSettingUserControl(Changed) as Control;
                control.Dock = DockStyle.Fill;
                #region ����ؼ����ÿؼ���Ҫ��������ȫ�ֱ�����������¼���
                IGlobalValueToolStripItemAsker iGlobalValueToolStripItemAsker = control as IGlobalValueToolStripItemAsker;
                if (iGlobalValueToolStripItemAsker != null)
                {
                    iGlobalValueToolStripItemAsker.AskForGlobalValueToolStripItem -= AskForGlobalValueToolStripItem;
                    iGlobalValueToolStripItemAsker.AskForGlobalValueToolStripItem += AskForGlobalValueToolStripItem;
                }
                #endregion
                (control as IConditionInputTypeSettingUserControl).AskForBringToFront -= AskForBringToFront;
                (control as IConditionInputTypeSettingUserControl).AskForBringToFront += AskForBringToFront;
                Controls.Add(control);
                ResumeLayout();
            }
        }

        #region IGlobalValueToolStripItemAsker ��Ա

        public event AskForGlobalValueToolStripItemHandle AskForGlobalValueToolStripItem;

        public void SetGlobalValue(string globalValue)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IChangedUserControl ��Ա

        public event EventHandler Changed;

        #endregion
    }
}
