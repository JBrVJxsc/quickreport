using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Enums;

namespace QuickReportLib.Controls
{
    internal partial class ControlWidthSetter : BaseUserControl
    {
        public ControlWidthSetter()
        {
            InitializeComponent();
        }

        private ControlWidthSetterControlTypes controlType = ControlWidthSetterControlTypes.TextBox;

        public ControlWidthSetterControlTypes ControlType
        {
            get
            {
                return controlType;
            }
            set
            {
                controlType = value;
            }
        }
    }
}
