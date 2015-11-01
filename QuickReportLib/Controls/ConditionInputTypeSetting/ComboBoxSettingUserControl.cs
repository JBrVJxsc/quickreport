using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Interfaces.ConditionInputType;
using QuickReportLib.Interfaces.ReportSetting;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Objects;
using QuickReportLib.Managers;
using QuickReportLib.Objects.ConditionInputTypeSetting;

namespace QuickReportLib.Controls.ConditionInputTypeSetting
{
    internal partial class ComboBoxSettingUserControl : BaseSettingUserControl, IConditionInputTypeSettingUserControl, IGlobalValueToolStripItemAsker
    {
        public ComboBoxSettingUserControl()
        {
            InitializeComponent();
        }

        public override QuickReportLib.Objects.ConditionInputTypeSetting.BaseInputTypeSetting ConditionInputTypeSettingObject
        {
            get
            {
                return base.ConditionInputTypeSettingObject;
            }
            set
            {
                base.ConditionInputTypeSettingObject = value;
                ComboBoxSetting comboBoxSetting = conditionInputTypeSettingObject as ComboBoxSetting;
                cmbDefaultValue.Text = comboBoxSetting.DefaultValue;
                cbCanEdit.Checked = comboBoxSetting.CanEdit;
                cmbActionAfterEnterKeyDown.ActionAfterEnterKeyDown = comboBoxSetting.ActionAfterEnterKeyDown;
                txtSQL.Text = comboBoxSetting.SQL;
            }
        }

        private int ParseSQL()
        {
            string sql = txtSQL.Text;
            string err = string.Empty;
            List<Column> columnList = SQLManager.ParseSQLToColumns(sql, ref err);
            if (columnList == null)
            {
                ToBeFront();
                WindowManager.ShowToolTip(txtSQL, "解析出错。原因：\n" + err, txtSQL.Location);
                return -1;
            }
            string strTemp = cmbDefaultValue.Text;
            List<BaseObject> baseObjectList = ListManager.ColumnListToBaseObjectList(columnList);
            cmbDefaultValue.SetItems(baseObjectList);
            cmbDefaultValue.Text = strTemp;
            return 1;
        }

        private void ToBeFront()
        {
            if (AskForBringToFront != null)
            {
                AskForBringToFront(this, null);
            }
        }

        private void tbParseSQL_Click(object sender, EventArgs e)
        {
            ParseSQL();
        }

        protected override void OnLoad(EventArgs e)
        {
            BandingIGlobalValueToolStripItemAskerEvent(AskForGlobalValueToolStripItem);
            base.OnLoad(e);
        }

        #region IConditionInputTypeSettingUserControl 成员


        public int CheckInput()
        {
            ComboBoxSetting comboBoxSetting = conditionInputTypeSettingObject as ComboBoxSetting;
            comboBoxSetting.DefaultValue = cmbDefaultValue.Text;
            comboBoxSetting.CanEdit = cbCanEdit.Checked;
            comboBoxSetting.ActionAfterEnterKeyDown = cmbActionAfterEnterKeyDown.ActionAfterEnterKeyDown;
            if (txtSQL.Text.Trim() == string.Empty)
            {
                ToBeFront();
                WindowManager.ShowToolTip(txtSQL, "需录入下拉框的SQL语句。", txtSQL.Location);
                return -1;
            }
            int i = ParseSQL();
            if (i < 0)
            {
                return -1;
            }
            comboBoxSetting.SQL = txtSQL.Text;
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
