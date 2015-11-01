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
        /// 回车键按下后所执行的动作。
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
            Items.Add("查询");
            Items.Add("选择下一个控件");
            SelectedIndex = Convert.ToInt32(actionAfterEnterKeyDown);
            base.OnCreateControl();
        }
    }
}
