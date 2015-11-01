using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace QuickReportLib.Controls.Plus
{
    public partial class PanelWithLine : Panel
    {
        public PanelWithLine()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.LightGray))
            {
                Point p = e.ClipRectangle.Location;
                e.Graphics.DrawLine(pen, p, new Point(p.X + Width, p.Y));
                e.Graphics.DrawLine(pen, new Point(p.X, p.Y + Height), new Point(p.X + Width, p.Y + Height));
            }
            base.OnPaint(e);
        }
    }
}
