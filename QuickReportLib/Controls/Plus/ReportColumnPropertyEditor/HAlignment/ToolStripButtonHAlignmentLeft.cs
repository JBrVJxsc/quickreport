using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using FarPoint.Win.Spread;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.ReportColumnPropertyEditor.HAlignment
{
    internal partial class ToolStripButtonHAlignmentLeft : ToolStripButtonHAlignmentBase, IReportColumnSettingToolStripItem
    {
        public ToolStripButtonHAlignmentLeft()
        {
            InitializeComponent();
        }

        protected override FarPoint.Win.Spread.CellHorizontalAlignment HorizontalAlignment
        {
            get
            {
                return CellHorizontalAlignment.Left;
            }
        }

        public override int SortID
        {
            get
            {
                return 80;
            }
        }
    }
}
