using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using FarPoint.Win.Spread;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting.HAlignment
{
    internal partial class ToolStripButtonHAlignmentRight : ToolStripButtonHAlignmentBase, IHeaderSettingToolStripItem
    {
        public ToolStripButtonHAlignmentRight()
        {
            InitializeComponent();
        }

        protected override CellHorizontalAlignment HorizontalAlignment
        {
            get
            {
                return CellHorizontalAlignment.Right;
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
