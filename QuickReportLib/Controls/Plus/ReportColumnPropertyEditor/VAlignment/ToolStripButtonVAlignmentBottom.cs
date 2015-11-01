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
    internal partial class ToolStripButtonVAlignmentBottom : ToolStripButtonVAlignmentBase, IReportColumnSettingToolStripItem
    {
        public ToolStripButtonVAlignmentBottom()
        {
            InitializeComponent();
        }

        protected override CellVerticalAlignment VerticalAlignment
        {
            get
            {
                return CellVerticalAlignment.Bottom;
            }
        }

        public override int SortID
        {
            get
            {
                return 140;
            }
        }
    }
}
