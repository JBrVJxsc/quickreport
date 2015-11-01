using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using QuickReportLib.Enums;

namespace QuickReportLib.Controls.Plus
{
    internal partial class ComboBoxActionAfterEnterKeyDown : ComboBoxPlus
    {
        public ComboBoxActionAfterEnterKeyDown()
        {
            InitializeComponent();
        }

        private bool loaded = false;
        private ActionAfterEnterKeyDown actionAfterEnterKeyDown = ActionAfterEnterKeyDown.Query;

        /// <summary>
        /// �س������º���ִ�еĶ�����
        /// </summary>
        public ActionAfterEnterKeyDown ActionAfterEnterKeyDown
        {
            get
            {
                return (ActionAfterEnterKeyDown)Enum.Parse(typeof(ActionAfterEnterKeyDown), SelectedIndex.ToString());
            }
            set
            {
                if (!loaded)
                {
                    loaded = true;
                    return;
                }
                actionAfterEnterKeyDown = value;
                SelectedIndex = Convert.ToInt32(value);
            }
        }

        protected override void OnCreateControl()
        {
            Items.Clear();
            Items.Add("��ѯ");
            Items.Add("ѡ����һ���ؼ�");
            SelectedIndex = Convert.ToInt32(actionAfterEnterKeyDown);
            base.OnCreateControl();
        }
    }
}
