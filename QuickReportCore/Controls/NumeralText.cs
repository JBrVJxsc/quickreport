using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Controls
{

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(TextBox))]
    internal class BaseTextBox : TextBox
    {
        private bool m_keepBackColorWhenReadOnly = true;
        private Color m_backColor;
        private Color m_backColorWhenReadOnly;

        public BaseTextBox()
        {
            m_backColor = base.BackColor;
            base.ReadOnly = true;
            m_backColorWhenReadOnly = base.BackColor;
            base.ReadOnly = false;
        }

        [DefaultValue(typeof(Color), "Black")]
        public new Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        [DefaultValue(typeof(Color), "Window")]
        public new Color BackColor
        {
            get { return m_backColor; }
            set
            {
                if (m_backColor != value)
                {
                    m_backColor = value;
                    OnBackColorChanged(EventArgs.Empty);
                }
            }
        }

        [DefaultValue(true)]
        public bool KeepBackColorWhenReadOnly
        {
            get { return m_keepBackColorWhenReadOnly; }
            set
            {
                if (m_keepBackColorWhenReadOnly != value)
                {
                    m_keepBackColorWhenReadOnly = value;
                    OnBackColorChanged(EventArgs.Empty);
                }
            }
        }

        public new bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                if (base.ReadOnly != value)
                {
                    base.ReadOnly = value;
                    OnBackColorChanged(EventArgs.Empty);
                }
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);

            if (ReadOnly)
            {
                if (m_keepBackColorWhenReadOnly)
                {
                    base.BackColor = m_backColor;
                }
                else
                {
                    base.BackColor = m_backColorWhenReadOnly;
                }
            }
            else
            {
                base.BackColor = m_backColor;
            }
            Invalidate();
        }
    }

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(TextBox))]
    internal class NumeralText : BaseTextBox
    {
        private const int m_MaxDecimalLength = 10;
        private const int m_MaxValueLength = 27;
        private const int WM_CHAR = 0x0102;
        private const int WM_CUT = 0x0300;
        private const int WM_COPY = 0x0301;
        private const int WM_PASTE = 0x0302;
        private const int WM_CLEAR = 0x0303;
        private int m_decimalLength = 0;
        private bool m_allowNegative = true;
        private string m_valueFormatStr = string.Empty;
        private char m_decimalSeparator = '.';
        private char m_negativeSign = '-';

        public NumeralText()
        {
            base.Multiline = false;
            base.TextAlign = HorizontalAlignment.Right;
            base.Text = "0";
            System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
            m_decimalSeparator = ci.NumberFormat.CurrencyDecimalSeparator[0];
            m_negativeSign = ci.NumberFormat.NegativeSign[0];
            SetValueFormatStr();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(typeof(HorizontalAlignment), "Right")]
        public new HorizontalAlignment TextAlign
        {
            get { return base.TextAlign; }
        }

        [DefaultValue("0")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                decimal val;
                if (decimal.TryParse(value, out val))
                {
                    base.Text = val.ToString(m_valueFormatStr);
                }
                else
                {
                    base.Text = 0.ToString(m_valueFormatStr);
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override int MaxLength
        {
            get
            {
                return base.MaxLength;
            }
        }

        [DefaultValue(0)]
        public int DecimalLength
        {
            get
            {
                return m_decimalLength;
            }
            set
            {
                if (m_decimalLength != value)
                {
                    if (value < 0 || value > m_MaxDecimalLength)
                    {
                        m_decimalLength = 0;
                    }
                    else
                    {
                        m_decimalLength = value;
                    }
                    SetValueFormatStr();
                    base.Text = Value.ToString(m_valueFormatStr);
                }
            }
        }

        public decimal Value
        {
            get
            {
                decimal val;
                if (decimal.TryParse(base.Text, out val))
                {
                    return val;
                }
                return 0;
            }
        }

        public int IntValue
        {
            get
            {
                decimal val = Value;
                return (int)val;
            }
        }

        [DefaultValue(true)]
        public bool AllowNegative
        {
            get { return m_allowNegative; }
            set
            {
                if (m_allowNegative != value)
                {
                    m_allowNegative = value;
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PASTE)
            {
                ClearSelection();
                SendKeys.Send(Clipboard.GetText());
                base.OnTextChanged(EventArgs.Empty);
            }
            else if (m.Msg == WM_COPY)
            {
                if (SelectedText != string.Empty)
                    Clipboard.SetText(SelectedText);
            }
            else if (m.Msg == WM_CUT)
            {
                if (SelectedText != string.Empty)
                    Clipboard.SetText(SelectedText);
                ClearSelection();
                base.OnTextChanged(EventArgs.Empty);
            }
            else if (m.Msg == WM_CLEAR)
            {
                ClearSelection();
                base.OnTextChanged(EventArgs.Empty);
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys)Shortcut.CtrlV)
            {
                ClearSelection();

                string text = Clipboard.GetText();

                for (int k = 0; k < text.Length; k++)
                {
                    SendCharKey(text[k]);
                }
                return true;
            }
            else if (keyData == (Keys)Shortcut.CtrlC)
            {
                if (SelectedText != string.Empty)
                    Clipboard.SetText(SelectedText);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (!ReadOnly)
            {
                if (e.KeyData == Keys.Delete || e.KeyData == Keys.Back)
                {
                    if (SelectionLength > 0)
                    {
                        ClearSelection();
                    }
                    else
                    {
                        DeleteText(e.KeyData);
                    }
                    e.SuppressKeyPress = true;
                }
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (ReadOnly)
            {
                return;
            }
            if (e.KeyChar == (char)13 || e.KeyChar == (char)3 || e.KeyChar == (char)22 || e.KeyChar == (char)24)
            {
                return;
            }
            if (m_decimalLength == 0 && e.KeyChar == m_decimalSeparator)
            {
                e.Handled = true;
                return;
            }
            if (!m_allowNegative && e.KeyChar == m_negativeSign && base.Text.IndexOf(m_negativeSign) < 0)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != m_negativeSign && e.KeyChar != m_decimalSeparator)
            {
                e.Handled = true;
                return;
            }
            if (base.Text.Length >= m_MaxValueLength && e.KeyChar != m_negativeSign)
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == m_decimalSeparator || e.KeyChar == m_negativeSign)
            {
                SelectionLength = 0;
            }
            else
            {
                ClearSelection();
            }
            bool isNegative = (base.Text[0] == m_negativeSign) ? true : false;
            if (isNegative && SelectionStart == 0)
            {
                SelectionStart = 1;
            }
            if (e.KeyChar == m_negativeSign)
            {
                int selStart = SelectionStart;

                if (!isNegative)
                {
                    base.Text = m_negativeSign + base.Text;
                    SelectionStart = selStart + 1;
                }
                else
                {
                    base.Text = base.Text.Substring(1, base.Text.Length - 1);
                    if (selStart >= 1)
                    {
                        SelectionStart = selStart - 1;
                    }
                    else
                    {
                        SelectionStart = 0;
                    }
                }
                e.Handled = true;
                return;
            }
            int dotPos = base.Text.IndexOf(m_decimalSeparator) + 1;
            if (e.KeyChar == m_decimalSeparator)
            {
                if (dotPos > 0)
                {
                    SelectionStart = dotPos;
                }
                e.Handled = true;
                return;
            }
            if (base.Text == "0")
            {
                SelectionStart = 0;
                SelectionLength = 1;
            }
            else if (base.Text == m_negativeSign + "0")
            {
                SelectionStart = 1;
                SelectionLength = 1;
            }
            else if (m_decimalLength > 0)
            {
                if (base.Text[0] == '0' && dotPos == 2 && SelectionStart <= 1)
                {
                    SelectionStart = 0;
                    SelectionLength = 1;
                }
                else if (base.Text.Substring(0, 2) == m_negativeSign + "0" && dotPos == 3 && SelectionStart <= 2)
                {
                    SelectionStart = 1;
                    SelectionLength = 1;
                }
                else if (SelectionStart == dotPos + m_decimalLength)
                {
                    e.Handled = true;
                }
                else if (SelectionStart >= dotPos)
                {
                    SelectionLength = 1;
                }
                else if (SelectionStart < dotPos - 1)
                {
                    SelectionLength = 0;
                }
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            if (string.IsNullOrEmpty(base.Text))
            {
                base.Text = 0.ToString(m_valueFormatStr);
            }
            else
            {
                base.Text = Value.ToString(m_valueFormatStr);
            }
            base.OnLeave(e);
        }

        private void SetValueFormatStr()
        {
            m_valueFormatStr = "F" + m_decimalLength.ToString();
        }

        private void SendCharKey(char c)
        {
            Message msg = new Message();
            msg.HWnd = Handle;
            msg.Msg = WM_CHAR;
            msg.WParam = (IntPtr)c;
            msg.LParam = IntPtr.Zero;
            base.WndProc(ref msg);
        }

        private void DeleteText(Keys key)
        {
            int selStart = SelectionStart;

            if (key == Keys.Delete)
            {
                selStart += 1;
                if (selStart > base.Text.Length)
                {
                    return;
                }

                if (IsSeparator(selStart - 1))
                {
                    selStart++;
                }
            }
            else
            {
                if (selStart == 0)
                {
                    return;
                }

                if (IsSeparator(selStart - 1))
                {
                    selStart--;
                }
            }
            if (selStart == 0 || selStart > base.Text.Length)
            {
                return;
            }
            int dotPos = base.Text.IndexOf(m_decimalSeparator);
            bool isNegative = (base.Text.IndexOf(m_negativeSign) >= 0) ? true : false;
            if (selStart > dotPos && dotPos >= 0)
            {
                base.Text = base.Text.Substring(0, selStart - 1) + base.Text.Substring(selStart, base.Text.Length - selStart) + "0";
                base.SelectionStart = selStart - 1;
            }
            else
            {
                if (selStart == 1 && isNegative)
                {
                    if (base.Text.Length == 1)
                    {
                        base.Text = "0";
                    }
                    else if (dotPos == 1)
                    {
                        base.Text = "0" + base.Text.Substring(1, base.Text.Length - 1);
                    }
                    else
                    {
                        base.Text = base.Text.Substring(1, base.Text.Length - 1);
                    }
                    base.SelectionStart = 0;
                }
                else if (selStart == 1 && (dotPos == 1 || base.Text.Length == 1))
                {
                    base.Text = "0" + base.Text.Substring(1, base.Text.Length - 1);
                    base.SelectionStart = 1;
                }
                else if (isNegative && selStart == 2 && base.Text.Length == 2)
                {
                    base.Text = m_negativeSign + "0";
                    base.SelectionStart = 1;
                }
                else if (isNegative && selStart == 2 && dotPos == 2)
                {
                    base.Text = m_negativeSign + "0" + base.Text.Substring(2, base.Text.Length - 2);
                    base.SelectionStart = 1;
                }
                else
                {
                    base.Text = base.Text.Substring(0, selStart - 1) + base.Text.Substring(selStart, base.Text.Length - selStart);
                    base.SelectionStart = selStart - 1;
                }
            }
        }

        private void ClearSelection()
        {
            if (SelectionLength == 0)
            {
                return;
            }
            if (SelectedText.Length == base.Text.Length)
            {
                base.Text = 0.ToString(m_valueFormatStr);
                return;
            }
            int selLength = SelectedText.Length;
            if (SelectedText.IndexOf(m_decimalSeparator) >= 0)
            {
                selLength--;
            }
            SelectionStart += SelectedText.Length;
            SelectionLength = 0;

            for (int k = 1; k <= selLength; k++)
            {
                DeleteText(Keys.Back);
            }
        }

        private bool IsSeparator(int index)
        {
            return IsSeparator(base.Text[index]);
        }

        private bool IsSeparator(char c)
        {
            if (c == m_decimalSeparator)
            {
                return true;
            }
            return false;
        }
    }
}

