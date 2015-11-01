using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace QuickReportCore.Controls
{
    internal partial class RichTextBoxPlus : RichTextBox
    {
        public RichTextBoxPlus()
        {
            InitializeComponent();
        }

        //static RichTextBoxPlus()
        //{
        //    InitWordCompare();
        //}

        //static Hashtable WordCompare = new Hashtable();

        //static void InitWordCompare()
        //{
        //    QuickReportCore.Controls.RichTextBoxPlus.WordCompare.Add("select",Color.Blue);
        //}

        private Color Compare(string keyWord)
        {
            return Color.Black ;
        }

        private void Parse()
        {
            if (Text != string.Empty)
            {
                int selectStart = SelectionStart;
            }
        }
    }
}
