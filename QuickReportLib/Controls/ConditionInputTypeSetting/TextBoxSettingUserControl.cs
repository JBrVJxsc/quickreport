using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Interfaces.ConditionInputType;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Objects.ConditionInputTypeSetting;
using QuickReportLib.Managers;
using QuickReportLib.Objects;
using QuickReportLib.Interfaces.ReportSetting;

namespace QuickReportLib.Controls.ConditionInputTypeSetting
{
    internal partial class TextBoxSettingUserControl : BaseSettingUserControl, IConditionInputTypeSettingUserControl, IGlobalValueToolStripItemAsker
    {
        public TextBoxSettingUserControl()
        {
            InitializeComponent();
        }

        public override BaseInputTypeSetting ConditionInputTypeSettingObject
        {
            get
            {
                return base.ConditionInputTypeSettingObject;
            }
            set
            {
                base.ConditionInputTypeSettingObject = value;
                TextBoxSetting textBoxSetting = conditionInputTypeSettingObject as TextBoxSetting;
                txtDefaultValue.Text = textBoxSetting.DefaultValue;
                cbOnlyNumber.Checked = textBoxSetting.OnlyNumber;
                cbLeftZero.Checked = textBoxSetting.LeftZero;
                numLeftZero.Value = textBoxSetting.LeftZeroPlace;
                cmbActionAfterEnterKeyDown.ActionAfterEnterKeyDown = textBoxSetting.ActionAfterEnterKeyDown;
                tbUseSelector.Checked = textBoxSetting.UserSelector;

                txtSelectorSQL.Text = textBoxSetting.SelectorSQL;
                ParseSQL();

                cmbOutPutColumn.Text = textBoxSetting.OutPutColumn;
                cbHideSelectorOutPutColumn.Checked = textBoxSetting.HideOutPutColumn;
                txtSelectorTitle.Text = textBoxSetting.SelectorTitle;
                txtSelectorNullMessage.Text = textBoxSetting.SelectorNullMessage;
            }
        }

        private int ParseSQL()
        {
            string sql = txtSelectorSQL.Text;
            string err = string.Empty;
            List<Column> columnList = SQLManager.ParseSQLToColumns(sql, ref err);
            if (columnList == null)
            {
                ToBeFront();
                tabControlSelector.SelectedIndex = 0;
                WindowManager.ShowToolTip(txtSelectorSQL, "解析出错。原因：\n" + err, txtSelectorSQL.Location);
                return -1;
            }
            string strTemp = cmbOutPutColumn.Text;
            List<BaseObject> baseObjectList = ListManager.ColumnListToBaseObjectList(columnList);
            cmbOutPutColumn.SetItems(baseObjectList);
            cmbOutPutColumn.Text = strTemp;
            return 1;
        }

        private void ToBeFront()
        {
            if (AskForBringToFront != null)
            {
                AskForBringToFront(this, null);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            BandingIGlobalValueToolStripItemAskerEvent(AskForGlobalValueToolStripItem);
            base.OnLoad(e);
        }

        private void tbUseSelector_Click(object sender, EventArgs e)
        {
            tbUseSelector.Checked = !tbUseSelector.Checked;
            if (ChangedEvent != null)
            {
                ChangedEvent(this, null);
            }
        }

        private void tbParseSQL_Click(object sender, EventArgs e)
        {
            ParseSQL();
        }

        private void cbOnlyNumber_CheckedChanged(object sender, EventArgs e)
        {
            cbLeftZero.Enabled = cbOnlyNumber.Checked;
            if (!cbOnlyNumber.Checked)
            {
                cbLeftZero.Checked = cbOnlyNumber.Checked;
                numLeftZero.Enabled = cbOnlyNumber.Checked;
            }
        }

        private void cbLeftZero_CheckedChanged(object sender, EventArgs e)
        {
            numLeftZero.Enabled = cbLeftZero.Checked;
        }

        #region IConditionInputTypeSettingUserControl 成员


        public int CheckInput()
        {
            TextBoxSetting textBoxSetting = conditionInputTypeSettingObject as TextBoxSetting;
            textBoxSetting.DefaultValue = txtDefaultValue.Text;
            textBoxSetting.OnlyNumber = cbOnlyNumber.Checked;
            textBoxSetting.LeftZero = cbLeftZero.Checked;
            textBoxSetting.LeftZeroPlace = (int)numLeftZero.Value;
            textBoxSetting.ActionAfterEnterKeyDown = cmbActionAfterEnterKeyDown.ActionAfterEnterKeyDown;
            textBoxSetting.UserSelector = tbUseSelector.Checked;
            if (tbUseSelector.Checked)
            {
                if (txtSelectorSQL.Text.Trim() == string.Empty)
                {
                    ToBeFront();
                    tabControlSelector.SelectedIndex = 0;
                    WindowManager.ShowToolTip(txtSelectorSQL, "需录入选择框的SQL语句。", txtSelectorSQL.Location);
                    return -1;
                }
                int i = ParseSQL();
                if (i < 0)
                {
                    return -1;
                }
                textBoxSetting.SelectorSQL = txtSelectorSQL.Text;
                if (cmbOutPutColumn.Text == string.Empty)
                {
                    ToBeFront();
                    tabControlSelector.SelectedIndex = 1;
                    WindowManager.ShowToolTip(cmbOutPutColumn, "需选择选择框的输出列。", cmbOutPutColumn.Location);
                    return -1;
                }
                textBoxSetting.OutPutColumn = cmbOutPutColumn.Text;
                textBoxSetting.HideOutPutColumn = cbHideSelectorOutPutColumn.Checked;
                textBoxSetting.SelectorTitle = txtSelectorTitle.Text;
                textBoxSetting.SelectorNullMessage = txtSelectorNullMessage.Text;
            }
            return 1;
        }

        public event AskForBringToFrontHandle AskForBringToFront;

        #endregion

        #region IGlobalValueToolStripItemAsker 成员

        public event AskForGlobalValueToolStripItemHandle AskForGlobalValueToolStripItem;

        public void SetGlobalValue(string globalValue)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
