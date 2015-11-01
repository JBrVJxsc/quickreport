using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace QuickReportLib.Controls.Plus
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    internal partial class ToolStripNumericUpDown : ToolStripControlHost
    {
        public ToolStripNumericUpDown() : base(CreateControlInstance())
        {

        }

        public ToolStripNumericUpDown(string name) : this()
        {
            base.Name = name;
        }

        public NumericUpDown NumericUpDown
        {
            get
            {
                return Control as NumericUpDown;
            }
        }

        private static Control CreateControlInstance()
        {
            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.AutoSize = true;
            return numericUpDown;
        }
    }
}
