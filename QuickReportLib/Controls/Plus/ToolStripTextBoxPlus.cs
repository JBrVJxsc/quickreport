using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace QuickReportLib.Controls.Plus
{
    /// <summary>
    /// 只能录入数字的ToolStripTextBox。
    /// </summary>
    internal partial class ToolStripTextBoxPlus : ToolStripTextBox
    {
        public ToolStripTextBoxPlus()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当输入框为空时，所代表的值。
        /// </summary>
        protected virtual int NullValue
        {
            get
            {
                return 0;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            byte[] array = Encoding.Default.GetBytes(e.KeyChar.ToString());
            if (!char.IsDigit(e.KeyChar) || array.LongLength == 2)
            {
                e.Handled = true;
            }
            else
            {
                if (Text == "0" && SelectionStart != 0)
                {
                    e.Handled = true;
                    Text = e.KeyChar.ToString();
                    Select(Text.Length, 0);
                }
            }
            if (e.KeyChar == '\b')
            {
                if (Text.Length == 1&&SelectionStart!=0)
                {
                    e.Handled = true;
                    Text = "0";
                    Select(Text.Length, 0);
                }
                else
                {
                    e.Handled = false;
                }
            }
            base.OnKeyPress(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Text == string.Empty)
                {
                    Text = NullValue.ToString();
                    Select(Text.Length, 0);
                }
                else
                {
                    Text = Convert.ToInt32(Text).ToString();
                    Select(Text.Length, 0);
                }
            }
            base.OnKeyDown(e);
        }
    }
}
