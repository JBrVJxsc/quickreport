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
using QuickReportLib.Enums;
using QuickReportLib.Objects.ConditionInputTypeSetting;
using QuickReportLib.Managers;
using QuickReportLib.Objects;

namespace QuickReportLib.Controls.ConditionInputTypeSetting
{
    internal partial class BaseCheckControlSettingUserControl : BaseSettingUserControl, IConditionInputTypeSettingUserControl
    {
        public BaseCheckControlSettingUserControl()
        {
            InitializeComponent();
        }

        private CheckControlType checkControlType = CheckControlType.CheckBox;
        private Control activeControl = null;

        public override BaseInputTypeSetting ConditionInputTypeSettingObject
        {
            get
            {
                return base.ConditionInputTypeSettingObject;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                base.ConditionInputTypeSettingObject = value;
                BaseCheckControlInputTypeSetting baseCheckControlInputTypeSetting = conditionInputTypeSettingObject as BaseCheckControlInputTypeSetting;
                List<BaseObject> baseObjectList = ListManager.CheckControlElementListToBaseObjectList(baseCheckControlInputTypeSetting.CheckControlElements);
                SortedList sl = ListManager.ListToSortedList(baseObjectList);
                foreach (DictionaryEntry de in sl)
                {
                    Add(de.Key as CheckControlElement);
                }
                if (flowLayoutPanel.Controls.Count > 0)
                {
                    ActiveControl = flowLayoutPanel.Controls[0];
                }
            }
        }

        /// <summary>
        /// GroupBox的标题。
        /// </summary>
        public string GroupBoxTitle
        {
            get
            {
                return grbControls.Text;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                grbControls.Text = value;
            }
        }

        /// <summary>
        /// 控件类型。
        /// </summary>
        public CheckControlType CheckControlType
        {
            get
            {
                return checkControlType;
            }
            set
            {
                checkControlType = value;
            }
        }

        /// <summary>
        /// 当前激活的控件。
        /// </summary>
        public Control ActiveControl
        {
            get
            {
                return activeControl;
            }
            set
            {
                if (activeControl != null)
                {
                    activeControl.BackColor = SystemColors.Control;
                }
                activeControl = value;
                if (activeControl != null)
                {
                    activeControl.BackColor = Color.LightGray;
                    CheckControlElement element = activeControl.Tag as CheckControlElement;
                    txtID.Text = element.ID;
                    txtName.Text = element.Name;
                }
                if (activeControl == null)
                {
                    txtID.Text = string.Empty;
                    txtName.Text = string.Empty;
                }
            }
        }

        private void Add(CheckControlElement element)
        {
            Control control=null;
            if (checkControlType == CheckControlType.CheckBox)
            {
                control = new CheckBox();
                (control as CheckBox).Checked = element.CheckedOn;
                (control as CheckBox).CheckedChanged += new EventHandler(BaseCheckControlSettingUserControl_CheckedChanged);
            }
            else if (checkControlType == CheckControlType.RadioButton)
            {
                control = new RadioButton();
                (control as RadioButton).Checked = element.CheckedOn;
                (control as RadioButton).CheckedChanged+=new EventHandler(BaseCheckControlSettingUserControl_CheckedChanged);
            }
            control.Text = element.Name;
            control.Tag = element;
            control.Enter += new EventHandler(control_Enter);
            ActiveControl = control;
            flowLayoutPanel.Controls.Add(control);
        }

        void BaseCheckControlSettingUserControl_CheckedChanged(object sender, EventArgs e)
        {
            if (ChangedEvent != null)
            {
                ChangedEvent(sender, e);
            }
        }

        void control_Enter(object sender, EventArgs e)
        {
            ActiveControl = sender as Control;
        }

        private void Delete(CheckControlElement element)
        {
            BaseCheckControlInputTypeSetting baseCheckControlInputTypeSetting = conditionInputTypeSettingObject as BaseCheckControlInputTypeSetting;
            baseCheckControlInputTypeSetting.CheckControlElements.Remove(element);
            Control controlNeedDeleted = null;
            for (int i = 0; i < flowLayoutPanel.Controls.Count; i++)
            {
                Control control = flowLayoutPanel.Controls[i];
                if (control.Tag == element)
                {
                    controlNeedDeleted = control;
                    if (i < flowLayoutPanel.Controls.Count - 1)
                    {
                        ActiveControl = flowLayoutPanel.Controls[i + 1];
                    }
                    else if (i == flowLayoutPanel.Controls.Count - 1)
                    {
                        if (flowLayoutPanel.Controls.Count > 1)
                        {
                            ActiveControl = flowLayoutPanel.Controls[i - 1];
                        }
                        else if (flowLayoutPanel.Controls.Count == 1)
                        {
                            ActiveControl = null;
                        }
                    }
                    break;
                }
            }
            if (controlNeedDeleted != null)
            {
                flowLayoutPanel.Controls.Remove(controlNeedDeleted);
            }
        }

        private void Add()
        {
            CheckControlElement checkControlElement = new CheckControlElement();
            int sortID = 0;
            BaseCheckControlInputTypeSetting baseCheckControlInputTypeSetting = conditionInputTypeSettingObject as BaseCheckControlInputTypeSetting;
            foreach (CheckControlElement element in baseCheckControlInputTypeSetting.CheckControlElements)
            {
                if (element.SortID >= sortID)
                {
                    sortID = element.SortID;
                }
            }
            sortID++;
            checkControlElement.SortID = sortID;
            baseCheckControlInputTypeSetting.CheckControlElements.Add(checkControlElement);
            Add(checkControlElement);
            if (ChangedEvent != null)
            {
                ChangedEvent(this, null);
            }
        }

        private void Delete()
        {
            if (activeControl != null)
            {
                Delete(activeControl.Tag as CheckControlElement);
                if (ChangedEvent != null)
                {
                    ChangedEvent(this, null);
                }
            }
        }

        private void tbAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void tbDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (activeControl != null)
            {
                (activeControl.Tag as CheckControlElement).ID = txtID.Text;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (activeControl != null)
            {
                (activeControl.Tag as CheckControlElement).Name = txtName.Text;
                activeControl.Text = txtName.Text;
            }
        }

        #region IConditionInputTypeSettingUserControl 成员


        public virtual int CheckInput()
        {
            if (checkControlType == CheckControlType.CheckBox)
            {
                foreach (Control control in flowLayoutPanel.Controls)
                {
                    CheckBox checkBox = control as CheckBox;
                    (checkBox.Tag as CheckControlElement).CheckedOn = checkBox.Checked;
                }
            }
            else if (checkControlType == CheckControlType.RadioButton)
            {
                foreach (Control control in flowLayoutPanel.Controls)
                {
                    RadioButton radioButton = control as RadioButton;
                    (radioButton.Tag as CheckControlElement).CheckedOn = radioButton.Checked;
                }
            }
            return 1;
        }

        public event AskForBringToFrontHandle AskForBringToFront;

        #endregion
    }
}
