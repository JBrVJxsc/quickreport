using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace QuickReportLib.Controls.Plus
{
    internal partial class ToolStripSplitButtonPlus : ToolStripSplitButton
    {
        public ToolStripSplitButtonPlus()
        {
            InitializeComponent();
        }

        protected override void OnClick(EventArgs e)
        {
            ShowDropDown();
            base.OnClick(e);
        }
    }
}
