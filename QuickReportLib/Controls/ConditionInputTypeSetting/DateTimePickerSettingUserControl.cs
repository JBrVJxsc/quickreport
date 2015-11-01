using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Interfaces.ConditionInputType;
using QuickReportLib.Interfaces.ReportSetting;
using QuickReportLib.Objects.SystemValue;
using QuickReportLib.Objects.ConditionInputTypeSetting;

namespace QuickReportLib.Controls.ConditionInputTypeSetting
{
    internal partial class DateTimePickerSettingUserControl : BaseSettingUserControl, IConditionInputTypeSettingUserControl 
    {
        public DateTimePickerSettingUserControl()
        {
            InitializeComponent();

            htDateLayout.Add(numDay, numDay.Location);
            htDateLayout.Add(lbDay, lbDay.Location);

            htDateTimeLayout.Add(numDay, numDay.Location);
            htDateTimeLayout.Add(numHour, numHour.Location);
            htDateTimeLayout.Add(numMin, numMin.Location);
            htDateTimeLayout.Add(numSec, numSec.Location);
            htDateTimeLayout.Add(lbDay, lbDay.Location);
            htDateTimeLayout.Add(lbHour, lbHour.Location);
            htDateTimeLayout.Add(lbMin, lbMin.Location);
            htDateTimeLayout.Add(lbSec, lbSec.Location);

            htTimeLayout.Add(numHour, numDay.Location);
            htTimeLayout.Add(numMin, numHour.Location);
            htTimeLayout.Add(numSec, numMin.Location);
            htTimeLayout.Add(lbHour, lbDay.Location);
            htTimeLayout.Add(lbMin, lbHour.Location);
            htTimeLayout.Add(lbSec, lbMin.Location);
        }

        private Hashtable htDateLayout = new Hashtable();
        private Hashtable htDateTimeLayout = new Hashtable();
        private Hashtable htTimeLayout = new Hashtable();

        public override BaseInputTypeSetting ConditionInputTypeSettingObject
        {
            get
            {
                return base.ConditionInputTypeSettingObject;
            }
            set
            {
                base.ConditionInputTypeSettingObject = value;
                DateTimeSetting dateTimeSetting = conditionInputTypeSettingObject as DateTimeSetting;
                cmbDateTimeSystemValueTypes.SelectedSystemValueType = dateTimeSetting.SystemValueType;
                cmbAddOrSub.Text = dateTimeSetting.AddOrSub;
                numDay.Value = dateTimeSetting.Day;
                numHour.Value = dateTimeSetting.Hour;
                numMin.Value = dateTimeSetting.Min;
                numSec.Value = dateTimeSetting.Sec;
                cbUseFixedValue.Checked = dateTimeSetting.UseFixedValue;
                dtFixedValue.Value = dateTimeSetting.FixedValue;
                dtFixedValue.CustomFormat = dateTimeSetting.CustomFormat;
                cmbActionAfterEnterKeyDown.ActionAfterEnterKeyDown = dateTimeSetting.ActionAfterEnterKeyDown;
            }
        }

        private void SetLayout(Hashtable htLayout)
        {
            foreach (DictionaryEntry de in htLayout)
            {
                (de.Key as Control).Location = (Point)de.Value;
                (de.Key as Control).Visible = true;
                (de.Key as Control).BringToFront();
            }
            foreach (DictionaryEntry de in htDateTimeLayout)
            {
                if (!htLayout.Contains(de.Key))
                {
                    (de.Key as Control).Visible = false;
                }
            }
            if (htLayout == htDateLayout)
            {
                dtFixedValue.CustomFormat = "yyyy-MM-dd";
            }
            else if (htLayout == htDateTimeLayout)
            {
                dtFixedValue.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            }
            else
            {
                dtFixedValue.CustomFormat = "HH:mm:ss";
            }
        }

        private void cmbDateValueTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDateTimeSystemValueTypes.SelectedItem is PCDate)
            {
                SetLayout(htDateLayout);
            }
            else if (cmbDateTimeSystemValueTypes.SelectedItem is PCDateTime)
            {
                SetLayout(htDateTimeLayout);
            }
            else if (cmbDateTimeSystemValueTypes.SelectedItem is PCTime)
            {
                SetLayout(htTimeLayout);
            }
            else if (cmbDateTimeSystemValueTypes.SelectedItem is ServerDate)
            {
                SetLayout(htDateLayout);
            }
            else if (cmbDateTimeSystemValueTypes.SelectedItem is ServerDateTime)
            {
                SetLayout(htDateTimeLayout);
            }
            else if (cmbDateTimeSystemValueTypes.SelectedItem is ServerTime)
            {
                SetLayout(htTimeLayout);
            }
        }

        #region IConditionInputTypeSettingUserControl ≥…‘±


        public int CheckInput()
        {
            DateTimeSetting dateTimeSetting = conditionInputTypeSettingObject as DateTimeSetting;
            dateTimeSetting.SystemValueType = cmbDateTimeSystemValueTypes.SelectedSystemValueType;
            dateTimeSetting.AddOrSub = cmbAddOrSub.Text;
            dateTimeSetting.Day = (int)numDay.Value;
            dateTimeSetting.Hour = (int)numHour.Value;
            dateTimeSetting.Min = (int)numMin.Value;
            dateTimeSetting.Sec = (int)numSec.Value;
            dateTimeSetting.UseFixedValue = cbUseFixedValue.Checked;
            dateTimeSetting.FixedValue = dtFixedValue.Value;
            dateTimeSetting.CustomFormat = dtFixedValue.CustomFormat;
            dateTimeSetting.ActionAfterEnterKeyDown = cmbActionAfterEnterKeyDown.ActionAfterEnterKeyDown;
            return 1;
        }

        public event AskForBringToFrontHandle AskForBringToFront;

        #endregion
    }
}
