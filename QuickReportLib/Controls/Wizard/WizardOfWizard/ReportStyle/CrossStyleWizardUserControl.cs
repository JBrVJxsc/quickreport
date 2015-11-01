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

        #region IWizardUserControl ��Ա


        public string Title
        {
            get
            {
                return "������Ϣ";
            }
        }

        public string Summary
        {
            get
            {
                return "������ʽ������Ϣ";
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
                WindowManager.ShowToolTip(cmbRow, "��ѡ���С�", true);
                return false;
            }
            if (cmbColumn.SelectedItem == null)
            {
                WindowManager.ShowToolTip(cmbColumn, "��ѡ���С�", true);
                return false;
            }
            if (cmbValue.SelectedItem == null)
            {
                WindowManager.ShowToolTip(cmbValue, "��ѡ��ֵ��", true);
                return false;
            }
            if (txtRowText.Text == string.Empty)
            {
                WindowManager.ShowToolTip(cmbValue, "��¼�������ơ�", true);
                return false;
            }
            return true;
        }

        #endregion

    }
}
