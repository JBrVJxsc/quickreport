using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore.Forms
{
    internal partial class frmBase : Form
    {
        public frmBase()
        {
            InitializeComponent();
        }

        protected Point oldLocation;

        private bool hideCloseButton = false;
        /// <summary>
        /// 是否使窗口为强制激活窗口。
        /// </summary>
        [Category("设置"), Description("掩藏关闭按钮。")]
        public bool HideCloseButton
        {
            get
            {
                return hideCloseButton;
            }
            set
            {
                hideCloseButton = value;
            }
        }

        private bool forceActiveForm = false;
        /// <summary>
        /// 是否使窗口为强制激活窗口。
        /// </summary>
        [Category("设置"), Description("是否使窗口为强制激活窗口。")]
        public bool ForceActiveForm
        {
            get
            {
                return forceActiveForm;
            }
            set
            {
                forceActiveForm = value;
            }
        }

        private bool cannotClose = false;
        /// <summary>
        /// 是否是无法关闭的窗口。
        /// </summary>
        [Category("设置"), Description("是否是无法关闭的窗口。")]
        public bool CannotClose
        {
            get
            {
                return cannotClose;
            }
            set
            {
                cannotClose = value;
            }
        }

        private bool closeToHide = false;
        /// <summary>
        /// 是否是无法关闭的窗口。
        /// </summary>
        [Category("设置"), Description("点击关闭后隐藏。")]
        public bool CloseToHide
        {
            get
            {
                return closeToHide;
            }
            set
            {
                closeToHide = value;
            }
        }


        /// <summary>
        /// 判断点的坐标是否在窗体内。
        /// </summary>
        /// <param name="p">需要判断的点的坐标。</param>
        /// <returns>true为在窗体内，false为不在窗体内。</returns>
        protected bool IfPointInWindow(Point p)
        {
            if (p.X > Location.X + Width || p.X < Location.X || p.Y > Location.Y + Height || p.Y < Location.Y)
                return false;
            return true;
        }

        const int WM_NCACTIVATE = 0x086;
        const int WM_SYSCOMMAND = 0x0112;
        const int SC_CLOSE = 0xF060;
        protected override void WndProc(ref Message m)
        {
            if (CannotClose && m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
            {
                if (CloseToHide)
                    Hide();
                return;
            }
            else if (m.Msg == WM_NCACTIVATE)
            {
                if (m.WParam == IntPtr.Zero)
                {
                    if (ForceActiveForm)
                    {
                        m.WParam = new IntPtr(1);
                    }
                }
            }
            base.WndProc(ref m);
        }

        protected void AddHookEvent()
        {
            if (DesignMode)
                return;
            if (Managers.KeyboardAndMouseHooker.Hooker == null)
                Managers.KeyboardAndMouseHooker.Hooker = new QuickReportCore.Managers.KeyboardAndMouseHooker();
            if (!Managers.KeyboardAndMouseHooker.Hooker.Started)
                Managers.KeyboardAndMouseHooker.Hooker.Start();
            Managers.KeyboardAndMouseHooker.Hooker.HookOnKeyDownEvent += new KeyEventHandler(HookOnKeyDownEvent);
            Managers.KeyboardAndMouseHooker.Hooker.HookOnKeyPressEvent += new KeyPressEventHandler(HookOnKeyPressEvent);
            Managers.KeyboardAndMouseHooker.Hooker.HookOnKeyUpEvent += new KeyEventHandler(HookOnKeyUpEvent);
            Managers.KeyboardAndMouseHooker.Hooker.HookOnMouseActivityEvent += new MouseEventHandler(HookOnMouseActivityEvent);
        }

        protected void CancelHookEvent()
        {
            if (Managers.KeyboardAndMouseHooker.Hooker == null)
                return;
            Managers.KeyboardAndMouseHooker.Hooker.HookOnKeyDownEvent -= new KeyEventHandler(HookOnKeyDownEvent);
            Managers.KeyboardAndMouseHooker.Hooker.HookOnKeyPressEvent -= new KeyPressEventHandler(HookOnKeyPressEvent);
            Managers.KeyboardAndMouseHooker.Hooker.HookOnKeyUpEvent -= new KeyEventHandler(HookOnKeyUpEvent);
            Managers.KeyboardAndMouseHooker.Hooker.HookOnMouseActivityEvent -= new MouseEventHandler(HookOnMouseActivityEvent);
        }


        protected virtual void HookOnMouseActivityEvent(object sender, MouseEventArgs e)
        {

        }

        protected virtual void HookOnKeyUpEvent(object sender, KeyEventArgs e)
        {

        }

        protected virtual void HookOnKeyPressEvent(object sender, KeyPressEventArgs e)
        {

        }

        protected virtual void HookOnKeyDownEvent(object sender, KeyEventArgs e)
        {

        }

        private void frmBase_Load(object sender, EventArgs e)
        {
            AddHookEvent();
            oldLocation = Location;
            if (HideCloseButton)
            {
                Managers.Functions.RemoveCloseMenu(Handle);
            }
        }

        private void frmBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            CancelHookEvent();
        }

        private void frmBase_LocationChanged(object sender, EventArgs e)
        {
            int offsetX = Location.X - oldLocation.X;
            int offsetY = Location.Y - oldLocation.Y;
            if (OwnedForms != null && OwnedForms.Length != 0)
            {
                for (int i = 0; i < OwnedForms.Length; i++)
                {
                    frmBaseToolBox frm = OwnedForms[i] as frmBaseToolBox;
                    if (frm.Docked)
                        frm.Location = new Point(frm.Location.X + offsetX, frm.Location.Y + offsetY);
                }
            }
            oldLocation = Location;
        }
    }
}