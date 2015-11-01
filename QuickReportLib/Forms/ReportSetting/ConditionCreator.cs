using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects;
using QuickReportLib.Managers;
using QuickReportLib.Interfaces.ConditionInputType;
using QuickReportLib.ConditionInputType;

namespace QuickReportLib.Forms.ReportSetting
{
    internal partial class ConditionCreator : BaseForm
    {
        public ConditionCreator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �ɹ�����һ������ʱ���������¼���
        /// </summary>
        public event ConditionCreatedHandle ConditionCreated;

        private void Save()
        {
            if (txtConditionName.Text.Trim() == string.Empty)
            {
                WindowManager.ShowToolTip(txtConditionName, "��¼���������ơ�");
                return;
            }
            if (cmbConditionInputTypes.SelectedItem == null)
            {
                WindowManager.ShowToolTip(cmbConditionInputTypes, "��ѡ��ؼ����͡�");
                return;
            }
            if (ConditionCreated != null)
            {
                Condition condition = new Condition();
                condition.ID = condition.Name = txtConditionName.Text;
                condition.ConditionInputType = cmbConditionInputTypes.SelectedItem as BaseInputType;
                condition.ConditionInputType.Init();
                bool success = true;
                ConditionCreated(this, condition, out success);
                if (success)
                {
                    Close();
                }
                else
                {
                    WindowManager.ShowToolTip(txtConditionName, "�Ѵ�����Ϊ\""+txtConditionName.Text+"\"��������");
                }
            }
        }

        /// <summary>
        /// ��ʼ����������¼�����͡�
        /// </summary>
        private void InitConditionInputTypes()
        {
            List<object> objectList = ReflectionManager.CreateInstancesByInterfaceWithOutAbstract(typeof(IConditionInputType));
            foreach (object obj in objectList)
            {
                cmbConditionInputTypes.Items.Add(obj);
            }
        }

        private void btDone_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnActivated(EventArgs e)
        {
            txtConditionName.Focus();
            base.OnActivated(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            InitConditionInputTypes();
            base.OnLoad(e);
        }
    }

    /// <summary>
    /// �ɹ�����һ������ʱ��ִ�еķ�����
    /// </summary>
    /// <param name="sender">�¼�Դ��</param>
    /// <param name="condition">������</param>
    internal delegate void ConditionCreatedHandle(object sender,Condition condition , out bool success);
}