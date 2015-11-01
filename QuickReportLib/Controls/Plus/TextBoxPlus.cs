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
    /// �Զ����TextBox������һЩԭ��δ�еĹ��ܡ�
    /// </summary>
    internal partial class TextBoxPlus : TextBox
    {
        public TextBoxPlus()
        {
            InitializeComponent();
        }

        private string textWhenNull = string.Empty;
        private Color foreColorWhenNull = Color.Gray;
        private Font fontWhenNull = new System.Drawing.Font("΢���ź�", 9F, System.Drawing.FontStyle.Italic);

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
