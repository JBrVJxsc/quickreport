using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore.Controls
{
    internal partial class ucChangedKnownBase : UserControl,Interfaces.IHaveBeenChanged
    {
        public ucChangedKnownBase()
        {
            InitializeComponent();
        }

        private void ucBase_Load(object sender, EventArgs e)
        {
            BandingChangedEvent(Controls);
        }

        void uc_Changed(object sender, EventArgs e)
        {
            if (HaveBeenChanged != null)
                HaveBeenChanged(sender, e);
        }

        private void BandingChangedEvent(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c.Controls.Count > 0)
                {
                    BandingChangedEvent(c.Controls);
                    if (c is Interfaces.IHaveBeenChanged)
                        (c as Interfaces.IHaveBeenChanged).HaveBeenChanged += new QuickReportCore.Interfaces.HaveBeenChangedHandle(uc_Changed);
                }
                else if (c is TextBox)
                    (c as TextBox).TextChanged += new EventHandler(uc_Changed);
                else if (c is ComboBox)
                {
                    (c as ComboBox).SelectedIndexChanged += new EventHandler(uc_Changed);
                    (c as ComboBox).TextChanged += new EventHandler(uc_Changed);
                }
                else if (c is CheckBox)
                    (c as CheckBox).CheckedChanged += new EventHandler(uc_Changed);
                else if (c is RadioButton)
                    (c as RadioButton).CheckedChanged += new EventHandler(uc_Changed);
                else if(c is DateTimePicker)
                    (c as DateTimePicker).ValueChanged += new EventHandler(uc_Changed);
            }
        }

        #region IHaveBeenChanged ≥…‘±

        public event QuickReportCore.Interfaces.HaveBeenChangedHandle HaveBeenChanged;

        #endregion
    }
}
