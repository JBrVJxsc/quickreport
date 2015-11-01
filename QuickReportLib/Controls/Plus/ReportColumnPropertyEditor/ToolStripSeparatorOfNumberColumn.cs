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
    internal partial class ToolStripSeparatorOfNumberColumn : ToolStripSeparator , IReportColumnSettingToolStripItem
    {
        public ToolStripSeparatorOfNumberColumn()
        {
            InitializeComponent();
        }

        private Column column;
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
                column = value;
                if (column.IsNumber)
                {
                    Visible = true;
                    isVisible = true;
                }
                else
                {
                    Visible = false;
                    isVisible = false;
                }
            }
        }

        public int SortID
        {
            get 
            {
                return 150;
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
