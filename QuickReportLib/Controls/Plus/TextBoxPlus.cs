using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace QuickReportLib.Controls.Plus
{
    /// <summary>
    /// 自定义的TextBox，增加一些原来未有的功能。
    /// </summary>
    internal partial class TextBoxPlus : TextBox
    {
        public TextBoxPlus()
        {
            InitializeComponent();
        }

        private string textWhenNull = string.Empty;
        private Color foreColorWhenNull = Color.Gray;
        private Font fontWhenNull = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Italic);

        public string TextWhenNull
        {
            get
            {
                return textWhenNull;
            }
            set
            {
                textWhenNull = value;
            }
        }

        public Color ForeColorWhenNull
        {
            get
            {
                return foreColorWhenNull;
            }
            set
            {
                foreColorWhenNull = value;
            }
        }

        public Font FontWhenNull
        {
            get
            {
                return fontWhenNull;
            }
            set
            {
                fontWhenNull = value;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                SelectAll();
            }
            base.OnKeyDown(e);
        }
    }
}
