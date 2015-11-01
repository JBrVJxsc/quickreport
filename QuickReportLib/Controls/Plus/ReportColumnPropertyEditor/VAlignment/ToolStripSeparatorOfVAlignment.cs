using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.ReportColumnPropertyEditor.VAlignment
{
    internal partial class ToolStripSeparatorOfVAlignment : ToolStripSeparator, IReportColumnSettingToolStripItem
    {
        public ToolStripSeparatorOfVAlignment()
        {
            InitializeComponent();
        }

        #region IReportColumnSettingToolStripItem ≥…‘±

        public event HeaderSettingFpSpreadChangedHandle HeaderSettingFpSpreadChanged;

        public QuickReportLib.Objects.Column Column
        {
            get
            {
                return null;
            }
            set
            {
                
            }
        }

        public int SortID
        {
            get
            {
                return 110;
            }
        }

        public bool IsVisible
        {
            get
            {
                return true;
            }
            set
            {
               
            }
        }

        #endregion
    }
}
