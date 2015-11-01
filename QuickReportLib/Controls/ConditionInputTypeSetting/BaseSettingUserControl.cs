using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects.ConditionInputTypeSetting;

namespace QuickReportLib.Controls.ConditionInputTypeSetting
{
    internal partial class BaseSettingUserControl : BaseUserControl
    {
        public BaseSettingUserControl()
        {
            InitializeComponent();
        }

        private EventHandler changedEvent;

        public EventHandler ChangedEvent
        {
            get
            {
                return changedEvent;
            }
            set
            {
                changedEvent = value;
            }
        }

        protected BaseInputTypeSetting conditionInputTypeSettingObject;

        public virtual BaseInputTypeSetting ConditionInputTypeSettingObject
        {
            get
            {
                return conditionInputTypeSettingObject;
            }
            set
            {
                conditionInputTypeSettingObject = value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            BandingChangedEvent(changedEvent);
            base.OnLoad(e);
        }
    }
}
