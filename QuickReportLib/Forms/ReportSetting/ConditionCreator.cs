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
        /// 成功创建一个条件时所触发的事件。
        /// </summary>
        public event ConditionCreatedHandle ConditionCreated;

        private void Save()
        {
            if (txtConditionName.Text.Trim() == string.Empty)
            {
                WindowManager.ShowToolTip(txtConditionName, "需录入条件名称。");
                return;
            }
            if (cmbConditionInputTypes.SelectedItem == null)
            {
                WindowManager.ShowToolTip(cmbConditionInputTypes, "需选择控件类型。");
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
                    WindowManager.ShowToolTip(txtConditionName, "已存在名为\""+txtConditionName.Text+"\"的条件。");
                }
            }
        }

        /// <summary>
        /// 初始化所有条件录入类型。
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
    /// 成功创建一个条件时所执行的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="condition">条件。</param>
    internal delegate void ConditionCreatedHandle(object sender,Condition condition , out bool success);
}