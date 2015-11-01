using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuickReportLib.Forms
{
    /// <summary>
    /// 基础窗体类。
    /// </summary>
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        private bool smokyWindow = false;
        private double smokyOpacity = 0.7;

        /// <summary>
        /// 是否使用烟雾效果。
        /// </summary>
        public bool SmokyWindow
        {
            get
            {
                return smokyWindow;
            }
            set
            {
                smokyWindow = value;
            }
        }

        /// <summary>
        /// 处于烟雾状态时的透明度。
        /// </summary>
        public double SmokyOpacity
        {
            get
            {
                return smokyOpacity;
            }
            set
            {
                smokyOpacity = value;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.Constants.WM_NCACTIVATE)
            {
                if (m.WParam == IntPtr.Zero)
                {
                    m.WParam = new IntPtr(1);
                }
            }
            base.WndProc(ref m);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (smokyWindow)
            {
                BringToFront();
                Opacity = 1;
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (smokyWindow)
            {
                Opacity = smokyOpacity;
            }
            base.OnMouseLeave(e);
        }
    }
}