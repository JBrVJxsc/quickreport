using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using QuickReportLib.Enums;

namespace QuickReportLib.Controls.Plus.ReportColumnPropertyEditor.VAlignment
{
    internal partial class ToolStripButtonVAlignmentBase : ToolStripButtonPlus
    {
        public ToolStripButtonVAlignmentBase()
        {
            InitializeComponent();
        }

        public event HeaderSettingFpSpreadChangedHandle HeaderSettingFpSpreadChanged;
        protected QuickReportLib.Objects.Column column;

        protected virtual CellVerticalAlignment VerticalAlignment
        {
            get
            {
                return CellVerticalAlignment.General;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            if (Checked)
            {
                column.VAligment = CellVerticalAlignment.General;
                Checked = false;
            }
            else
            {
                column.VAligment = VerticalAlignment;
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
                    if (toolStripItem is ToolStripButtonVAlignmentBase)
                    {
                        if ((toolStripItem as ToolStripButtonVAlignmentBase).VerticalAlignment == column.VAligment)
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
                if (toolStripItem is ToolStripButtonVAlignmentBase && toolStripItem != this)
                {
                    (toolStripItem as ToolStripButton).Checked = false;
                }
            }
        }
    }
}
