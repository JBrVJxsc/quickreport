using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using QuickReportLib.Objects.SystemValue;
using QuickReportLib.Objects;
using QuickReportLib.Managers;
using QuickReportLib.Enums;

namespace QuickReportLib.Controls.Plus
{
    internal partial class ComboBoxDateTimeSystemValue : ComboBoxPlus
    {
        public ComboBoxDateTimeSystemValue()
        {
            InitializeComponent();
        }

        private bool loaded = false;
        private string selectedSystemValueType = string.Empty;

        /// <summary>
        /// 被选中的系统变量。
        /// </summary>
        public string SelectedSystemValueType
        {
            get
            {
                return selectedSystemValueType;
            }
            set
            {
                if (!loaded)
                {
                    loaded = true;
                    return;
                }
                selectedSystemValueType = value;
                SelectSystemValue(selectedSystemValueType);
            }
        }

        private void SelectSystemValue(string systemValueID)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                BaseObject baseObject = Items[i] as BaseObject;
                string sqlCode = SQLManager.GetSQLCode(baseObject.ID, SQLCodeType.System);
                if (sqlCode == systemValueID)
                {
                    SelectedIndex = i;
                    break;
                }
            }
        }

        protected override void OnCreateControl()
        {
            Items.Clear();
            Items.Add(new PCDate());
            Items.Add(new PCDateTime());
            Items.Add(new PCTime());
            Items.Add(new ServerDate());
            Items.Add(new ServerDateTime());
            Items.Add(new ServerTime());
            SelectSystemValue(selectedSystemValueType);
            base.OnCreateControl();
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            selectedSystemValueType = SQLManager.GetSQLCode(SelectedItem.GetType().Name, SQLCodeType.System);
            base.OnSelectedIndexChanged(e);
        }
    }
}
