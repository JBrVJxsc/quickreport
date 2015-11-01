using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace QuickReportLib.Controls.Plus
{
    internal partial class ComboBoxValid : ComboBoxPlus
    {
        public ComboBoxValid()
        {
            InitializeComponent();
        }

        private bool valid = true;

        /// <summary>
        /// 是否有效。
        /// </summary>
        public bool Valid
        {
            get
            {
                return valid;
            }
            set
            {
                valid = value;
                if (Items.Count == 0)
                {
                    return;
                }
                if (valid)
                {
                    SelectedIndex = 0;
                }
                else
                {
                    SelectedIndex = 1;
                }
            }
        }

        private void Init()
        {
            Items.Clear();
            Items.Add("启用");
            Items.Add("禁用");
            SelectedIndex = 0;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (SelectedIndex == 0)
            {
                valid = true;
            }
            else
            {
                valid = false;
            }
            base.OnSelectedIndexChanged(e);
        }

        protected override void OnCreateControl()
        {
            Init();
            base.OnCreateControl();
        }
    }
}
