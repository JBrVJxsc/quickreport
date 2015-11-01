using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using FarPoint.Win.Spread;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.ReportColumnPropertyEditor.VAlignment
{
    internal partial class ToolStripButtonVAlignmentTop : ToolStripButtonVAlignmentBase, IReportColumnSettingToolStripItem
    {
        public ToolStripButtonVAlignmentTop()
        {
            InitializeComponent();
        }

        protected override CellVerticalAlignment VerticalAlignment
        {
            get
            {
                return CellVerticalAlignment.Top;
            }
        }

        public override int SortID
        {
            get
            {
                return 120;
            }
        }
    }
}
