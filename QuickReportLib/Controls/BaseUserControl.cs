using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using QuickReportLib.Interfaces.ReportSetting;
using QuickReportLib.Interfaces.GlobalValue;

namespace QuickReportLib.Controls
{
    /// <summary>
    /// 基础控件类。
    /// </summary>
    internal partial class BaseUserControl : UserControl
    {
        public BaseUserControl()
        {
            InitializeComponent();
        }

        private EventHandler changed;

        /// <summary>
        /// 递归调用，过滤控件，设置值改变事件。
        /// </summary>
        /// <param name="controls">控件列表。</param>
        /// <param name="changed">事件。</param>

        void BaseUserControl_ClipboardPasting(object sender, ClipboardPastingEventArgs e)
        {
            changed(sender, e);
        }

        void BaseUserControl_RowHeightChanged(object sender, RowHeightChangedEventArgs e)
        {
            changed(sender, e);
        }

        void BaseUserControl_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            changed(sender, e);
        }

        void BaseUserControl_EditChange(object sender, EditorNotifyEventArgs e)
        {
            changed(sender, e);
        }

        private void BandingChangedEvent(ControlCollection controls, EventHandler changed)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).TextChanged += changed;
                }
                else if (control is ComboBox)
                {
                    (control as ComboBox).SelectedIndexChanged += changed;
                    (control as ComboBox).TextChanged += changed;
                }
                else if (control is CheckBox)
                {
                    (control as CheckBox).CheckedChanged += changed;
                }
                else if (control is RadioButton)
                {
                    (control as RadioButton).CheckedChanged += changed;
                }
                else if (control is DateTimePicker)
                {
                    (control as DateTimePicker).ValueChanged += changed;
                }
                else if (control is NumericUpDown)
                {
                    (control as NumericUpDown).ValueChanged += changed;
                }
                else if (control is FpSpread)
                {
                    (control as FpSpread).EditChange += new EditorNotifyEventHandler(BaseUserControl_EditChange);
                    (control as FpSpread).FontChanged += changed;
                    (control as FpSpread).ColumnWidthChanged += new FarPoint.Win.Spread.ColumnWidthChangedEventHandler(BaseUserControl_ColumnWidthChanged);
                    (control as FpSpread).RowHeightChanged += new RowHeightChangedEventHandler(BaseUserControl_RowHeightChanged);
                    (control as FpSpread).ClipboardPasting += new ClipboardPastingEventHandler(BaseUserControl_ClipboardPasting);
                }

                if (control is IChangedUserControl)
                {
                    (control as IChangedUserControl).Changed += changed;
                }

                if (control.Controls.Count > 0)
                {
                    BandingChangedEvent(control.Controls, changed);
                }
            }
        }

        private void BandingIGlobalValueToolStripItemAskerEvent(ControlCollection controls, AskForGlobalValueToolStripItemHandle askForGlobalValueToolStripItem)
        {
            foreach (Control control in controls)
            {
                if (control is IGlobalValueToolStripItemAsker)
                {
                    (control as IGlobalValueToolStripItemAsker).AskForGlobalValueToolStripItem += askForGlobalValueToolStripItem;
                }

                if (control.Controls.Count > 0)
                {
                    BandingIGlobalValueToolStripItemAskerEvent(control.Controls, askForGlobalValueToolStripItem);
                }
            }
        }

        public void BandingChangedEvent(EventHandler changed)
        {
            this.changed = changed;
            BandingChangedEvent(Controls, changed);
        }

        public void BandingIGlobalValueToolStripItemAskerEvent(AskForGlobalValueToolStripItemHandle askForGlobalValueToolStripItem)
        {
            BandingIGlobalValueToolStripItemAskerEvent(Controls, askForGlobalValueToolStripItem);
        }
    }
}
