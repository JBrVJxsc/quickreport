using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.ReportColumnPropertyEditor
{
    internal partial class ToolStripSeparatorOfSort : ToolStripSeparator , IReportColumnSettingToolStripItem
    {
        public ToolStripSeparatorOfSort()
        {
            InitializeComponent();
        }

        private bool isVisible = true;

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
                return -1;
            }
        }

        public bool IsVisible
        {
            get
            {
                return isVisible;
            }
            set
            {
                isVisible = value;
            }
        }

        #endregion
    }
}
