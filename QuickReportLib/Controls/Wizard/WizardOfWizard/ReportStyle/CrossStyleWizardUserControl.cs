using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Managers;
using QuickReportLib.Objects;
using QuickReportLib.Objects.ReportStyleSetting;

namespace QuickReportLib.Controls.Wizard.WizardOfWizard.ReportStyle
{
    internal partial class CrossStyleWizardUserControl : BaseWizardUserControl 
    {
        public CrossStyleWizardUserControl()
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

        protected virtual void Init()
        {

        }

        private void GeneralCrossStyleWizardUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            Init();
        }

        private void cmbRow_Enter(object sender, EventArgs e)
        {
            imgPreview.Image = global::QuickReportLib.Properties.Resources.CrossStyleWizardRow;
        }

        private void cmbColumn_Enter(object sender, EventArgs e)
        {
            imgPreview.Image = global::QuickReportLib.Properties.Resources.CrossStyleWizardColumn;
        }

        private void cmbValue_Enter(object sender, EventArgs e)
        {
            imgPreview.Image = global::QuickReportLib.Properties.Resources.CrossStyleWizardValue;
        }

        private void txtRowText_Enter(object sender, EventArgs e)
        {
            imgPreview.Image = global::QuickReportLib.Properties.Resources.CrossStyleWizardRowText;
        }

        protected virtual void txtRowText_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected virtual void cmbRow_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        protected virtual void cmbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected virtual void cmbValue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region IWizardUserControl 成员


        public string Title
        {
            get
            {
                return "基础信息";
            }
        }

        public string Summary
        {
            get
            {
                return "设置样式基础信息";
            }
        }

        public Image Image
        {
            get
            {
                return null;
            }
        }

        public virtual bool CanNext()
        {
            if (cmbRow.SelectedItem == null)
            {
                WindowManager.ShowToolTip(cmbRow, "需选择行。", true);
                return false;
            }
            if (cmbColumn.SelectedItem == null)
            {
                WindowManager.ShowToolTip(cmbColumn, "需选择列。", true);
                return false;
            }
            if (cmbValue.SelectedItem == null)
            {
                WindowManager.ShowToolTip(cmbValue, "需选择值。", true);
                return false;
            }
            if (txtRowText.Text == string.Empty)
            {
                WindowManager.ShowToolTip(cmbValue, "需录入行名称。", true);
                return false;
            }
            return true;
        }

        #endregion

    }
}
