using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects;

namespace QuickReportLib.Controls.Wizard
{
    internal partial class BaseWizardUserControl : BaseUserControl , IComparable
    {
        public BaseWizardUserControl()
        {
            InitializeComponent();
        }

        protected Report report;

        public virtual Report Report
        {
            get
            {
                return report;
            }
            set
            {
                report = value;
            }
        }

        public virtual int SortID
        {
            get
            {
                return 0;
            }
        }

        #region IComparable ³ÉÔ±

        public int CompareTo(object obj)
        {
            BaseWizardUserControl baseWizardUserControl = obj as BaseWizardUserControl;
            if (SortID > baseWizardUserControl.SortID)
                return 1;
            if (SortID < baseWizardUserControl.SortID)
                return -1;
            return 0;
        }

        #endregion
    }
}
