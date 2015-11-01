using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using QuickReportLib.Enums;

namespace QuickReportLib.Controls.Plus.ReportColumnPropertyEditor.HAlignment
{
    internal partial class ToolStripButtonHAlignmentBase : ToolStripButtonPlus
    {
        public ToolStripButtonHAlignmentBase()
        {
            InitializeComponent();
        }

        public event HeaderSettingFpSpreadChangedHandle HeaderSettingFpSpreadChanged;
        protected QuickReportLib.Objects.Column column;

        protected virtual CellHorizontalAlignment HorizontalAlignment
        {
            get
            {
                return CellHorizontalAlignment.General;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            if (Checked)
            {
                column.HAligment = CellHorizontalAlignment.General;
                Checked = false;
            }
            else
            {
                column.HAligment = HorizontalAlignment;
                Checked = true;
                UnCheckOthers();
            }
            if (HeaderSettingFpSpreadChanged != null)
            {
                HeaderSettingFpSpreadChanged(this, HeaderSettingFpSpreadChangedType.ReportColumnAlignmentChanged);
            }
            base.OnClick(e);
        }

        public virtual QuickReportLib.Objects.Column Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
                foreach (ToolStripItem toolStripItem in Parent.Items)
                {
                    if (toolStripItem is ToolStripButtonHAlignmentBase)
                    {
                        if ((toolStripItem as ToolStripButtonHAlignmentBase).HorizontalAlignment == column.HAligment)
                        {
                            (toolStripItem as ToolStripButton).Checked = true;
                        }
                        else
                        {
                            (toolStripItem as ToolStripButton).Checked = false;
                        }
                    }
                }
            }
        }

        public virtual int SortID
        {
            get
            {
                return 0;
            }
        }

        public virtual bool IsVisible
        {
            get
            {
                return true;
            }
            set
            {
                 
            }
        }

        private void UnCheckOthers()
        {
            foreach (ToolStripItem toolStripItem in Parent.Items)
            {
                if (toolStripItem is ToolStripButtonHAlignmentBase && toolStripItem != this)
                {
                    (toolStripItem as ToolStripButton).Checked = false;
                }
            }
        }
    }
}
