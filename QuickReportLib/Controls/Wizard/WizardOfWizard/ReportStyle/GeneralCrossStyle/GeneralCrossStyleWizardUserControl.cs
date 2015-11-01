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

namespace QuickReportLib.Controls.Wizard.WizardOfWizard.ReportStyle.GeneralCrossStyle
{
    internal partial class GeneralCrossStyleWizardUserControl : CrossStyleWizardUserControl , IGeneralCrossStyleWizardUserControl
    {
        public GeneralCrossStyleWizardUserControl()
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
                cmbColumn.Items.Add(de.Key);
                cmbValue.Items.Add(de.Key);
            }
        }

        protected override void txtRowText_TextChanged(object sender, EventArgs e)
        {
            (report.ReportStyle.ReportStyleSettingObject as GeneralCrossStyleSetting).RowText = txtRowText.Text;
        }

        protected override void cmbRow_SelectedIndexChanged(object sender,EventArgs e)
        {
            if (txtRowText.Text == string.Empty)
            {
                txtRowText.Text = cmbRow.Text;
            }
            if (cmbRow.SelectedItem as BaseObject != null)
            {
                (report.ReportStyle.ReportStyleSettingObject as GeneralCrossStyleSetting).Row = (cmbRow.SelectedItem as BaseObject).ID;
            }
        }

        protected override void cmbColumn_SelectedIndexChanged(object sender,EventArgs e)
        {
            if (cmbColumn.SelectedItem as BaseObject != null)
            {
                (report.ReportStyle.ReportStyleSettingObject as GeneralCrossStyleSetting).Column = (cmbColumn.SelectedItem as BaseObject).ID;
            }
        }

        protected override void cmbValue_SelectedIndexChanged(object sender,EventArgs e)
        {
            if (cmbValue.SelectedItem as BaseObject != null)
            {
                (report.ReportStyle.ReportStyleSettingObject as GeneralCrossStyleSetting).Value = (cmbValue.SelectedItem as BaseObject).ID;
            }
        }
    }
}
