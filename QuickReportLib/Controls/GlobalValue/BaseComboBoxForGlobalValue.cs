using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using QuickReportLib.Controls.Plus;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Enums;

namespace QuickReportLib.Controls.GlobalValue
{
    internal partial class BaseComboBoxForGlobalValue : ComboBoxPlus, IGlobalValueToolStripItemAsker
    {
        public BaseComboBoxForGlobalValue()
        {
            InitializeComponent();
        }

        protected List<GlobalValueType> globalValueTypeList;
        private static List<GlobalValueType> allGlobalValueTypes;

        static BaseComboBoxForGlobalValue()
        {
            allGlobalValueTypes = new List<GlobalValueType>();
        }

        protected virtual List<GlobalValueType> GlobalValueTypes
        {
            get
            {
                return globalValueTypeList;
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            if (AskForGlobalValueToolStripItem != null)
            {
                AskForGlobalValueToolStripItem(this, GlobalValueTypes);
            }
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            if (AskForGlobalValueToolStripItem != null)
            {
                AskForGlobalValueToolStripItem(this, allGlobalValueTypes);
            }
            base.OnLeave(e);
        }

        #region IGlobalValueToolStripItemAsker ≥…‘±

        public event AskForGlobalValueToolStripItemHandle AskForGlobalValueToolStripItem;

        public void SetGlobalValue(string globalValue)
        {
            if (DropDownStyle != System.Windows.Forms.ComboBoxStyle.DropDownList)
            {
                int start = SelectionStart;
                int length = SelectionLength;
                Text = Text.Remove(start, length);
                Text = Text.Insert(start, globalValue);
                Select(start + globalValue.Length, 0);
            }
        }

        #endregion
    }
}
