using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Interfaces.Wizard.WizardOfWizard.ReportStyle;
using QuickReportLib.Managers;
using QuickReportLib.Objects;
using QuickReportLib.Objects.ReportStyleSetting;

namespace QuickReportLib.Controls.Wizard.WizardOfWizard.ReportStyle.CustomColumnCrossStyle
{
    internal partial class CustomColumnCrossStyleWizardUserControl : CrossStyleWizardUserControl , ICustomColumnCrossStyleWizardUserControl
    {
        public CustomColumnCrossStyleWizardUserControl()
        {
            InitializeComponent();
        }

        public override int SortID
        {
            get
            {
                return 0;
            }
        }

        protected override void Init()
        {
            SortedList sortedList = ListManager.ListToSortedList(report.Columns);
            foreach (DictionaryEntry de in sortedList)
            {
                cmbRow.Items.Add(de.Key);
                cmbValue.Items.Add(de.Key);
            }
        }

        private void txtCustomColumnSQL_Enter(object sender, EventArgs e)
        {
            imgPreview.Image = global::QuickReportLib.Properties.Resources.CrossStyleWizardColumn;
        }

        private void btParseSQL_Click(object sender, EventArgs e)
        {
            string err = string.Empty;
            List<Column> columnList = SQLManager.ParseSQLToColumns(txtCustomColumnSQL.Text, ref err);
            if (columnList == null)
            {
                WindowManager.ShowToolTip(txtCustomColumnSQL, "SQL”Ôæ‰”–ŒÛ°£‘≠“Ú£∫\n" + err, 3000);
                cmbColumn.Items.Clear();
                return;
            }
            string tempColumn = cmbColumn.Text;
            cmbColumn.Items.Clear();
            SortedList sortedList = ListManager.ListToSortedList(columnList);
            foreach (DictionaryEntry de in sortedList)
            {
                cmbColumn.Items.Add(de.Key);
            }
            cmbColumn.Text = tempColumn;
            if (cmbColumn.Text == string.Empty)
            {
                if (cmbColumn.Items.Count == 1)
                {
                    cmbColumn.SelectedIndex = 0;
                }
            }
            (report.ReportStyle.ReportStyleSettingObject as CustomColumnCrossStyleSetting).CustomColumnSQL = txtCustomColumnSQL.Text;
        }

        protected override void txtRowText_TextChanged(object sender, EventArgs e)
        {
            (report.ReportStyle.ReportStyleSettingObject as CustomColumnCrossStyleSetting).RowText = txtRowText.Text;
        }

        protected override void cmbRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtRowText.Text == string.Empty)
            {
                txtRowText.Text = cmbRow.Text;
            }
            (report.ReportStyle.ReportStyleSettingObject as CustomColumnCrossStyleSetting).Row = (cmbRow.SelectedItem as BaseObject).ID;
        }

        protected override void cmbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            (report.ReportStyle.ReportStyleSettingObject as CustomColumnCrossStyleSetting).Column = (cmbColumn.SelectedItem as BaseObject).ID;
        }

        protected override void cmbValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            (report.ReportStyle.ReportStyleSettingObject as CustomColumnCrossStyleSetting).Value = (cmbValue.SelectedItem as BaseObject).ID;
        }

        public override bool CanNext()
        {
            bool b =  base.CanNext();
            if (!b)
            {
                return false;
            }

            return true;
        }
    }
}
