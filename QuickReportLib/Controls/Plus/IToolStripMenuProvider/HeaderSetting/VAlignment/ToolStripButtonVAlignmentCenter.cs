using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using FarPoint.Win.Spread;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting.VAlignment
{
    internal partial class ToolStripButtonVAlignmentCenter : ToolStripButtonVAlignmentBase, IHeaderSettingToolStripItem
    {
        public ToolStripButtonVAlignmentCenter()
        {
            InitializeComponent();
        }

        protected override CellVerticalAlignment VerticalAlignment
        {
            get
            {
                return CellVerticalAlignment.Center;
            }
        }

        public override int SortID
        {
            get
            {
                return 150;
            }
        }
    }
}
