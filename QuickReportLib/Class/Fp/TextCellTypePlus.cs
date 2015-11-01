using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;

namespace QuickReportLib.Class.Fp
{
    internal class TextCellTypePlus : TextCellType
    {
        private TextBox textBox = new TextBox();

        public override Control GetEditorControl(FarPoint.Win.Spread.Appearance appearance, float zoomFactor)
        {
            textBox.BorderStyle = BorderStyle.None;
            return textBox;
        }

        public override void SetEditorValue(object value)
        {
            if (value != null)
            {
                textBox.Text = value.ToString();
            }
            else
            {
                textBox.Text = string.Empty;
            }
        }

        public override object GetEditorValue()
        {
            return textBox.Text;
        }
    }
}
