using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;

namespace QuickReportCore.Forms
{
    internal partial class frmBaseToolBox : frmBase
    {
        public static Point WrongPoint = new Point(-10000, -10000);

        public frmBaseToolBox()
        {
            InitializeComponent();
        }

        private bool toolStripProtectd = false;
        public static string MouseHaveBeenEatenByWho = string.Empty;

        private double defaultFormOpacity = 0.85;
        /// <summary>
        /// �����Ĭ��͸���ȡ�
        /// </summary>
        [Category("����"), Description("�����Ĭ��͸���ȡ�")]
        public double DefaultFormOpacity
        {
            get
            {
                return defaultFormOpacity;
            }
            set
            {
                defaultFormOpacity = value;
            }
        }

        private bool docked = true;
        /// <summary>
        /// ��ȡ�����ù������Ƿ���ͣ��״̬��
        /// </summary>
        public bool Docked
        {
            get
            {
                return docked;
            }
            set
            {
                docked = value;
            }
        }

        private int dockProbeMarginal = 15;
        /// <summary>
        /// �ؼ�ͣ����̽����롣
        /// </summary>
        public int DockProbeMarginal
        {
            get
            {
                return dockProbeMarginal;
            }
        }

        private int dockParentMarginal = 10;
        /// <summary>
        /// �������ڸ�������ͣ��ʱ�����븸����ı�Ե���롣
        /// </summary>
        public int DockParentMarginal
        {
            get
            {
                return dockParentMarginal;
            }
        }

        const int WM_NCLBUTTONDBLCLK = 0x00A3;
        const int WM_MOVING = 0x216;
        const int WM_NCLBUTTONDOWN = 0x00A1;
        private Point oldMousePoint;
        private Point myOldLocation;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDOWN)
            {
                int xPos = m.LParam.ToInt32() & 0x0000FFFF;
                int yPos = (m.LParam.ToInt32()) >> 16;
                oldMousePoint = new Point(xPos, yPos);
                myOldLocation = Location;
            }
            if (m.Msg == WM_MOVING)
            {
                int offsetX = QuickReportCore.Managers.KeyboardAndMouseHooker.GlobalMouseEventArgs.X - oldMousePoint.X;
                int offsetY = QuickReportCore.Managers.KeyboardAndMouseHooker.GlobalMouseEventArgs.Y - oldMousePoint.Y;
                int left = Marshal.ReadInt32(m.LParam, 0);
                int top = Marshal.ReadInt32(m.LParam, 4);
                int right = Marshal.ReadInt32(m.LParam, 8);
                int bottom = Marshal.ReadInt32(m.LParam, 12);
                Marshal.WriteInt32(m.LParam, 0, myOldLocation.X + offsetX);
                Marshal.WriteInt32(m.LParam, 4, myOldLocation.Y + offsetY);
                Marshal.WriteInt32(m.LParam, 8, myOldLocation.X + Width + offsetX);
                Marshal.WriteInt32(m.LParam, 12, myOldLocation.Y + Height + offsetY);
                Point p = Docking(new Point(Marshal.ReadInt32(m.LParam, 0), Marshal.ReadInt32(m.LParam, 4)));
                if (p.X > WrongPoint.X)
                {
                    Marshal.WriteInt32(m.LParam, 0, p.X);
                    Marshal.WriteInt32(m.LParam, 4, p.Y);
                    Marshal.WriteInt32(m.LParam, 8, p.X + Width);
                    Marshal.WriteInt32(m.LParam, 12, p.Y + Height);
                }
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// �ֶ�Ϊ������Ѱ��һ���ʺϵ�ͣ���㡣
        /// </summary>
        /// <param name="p">��Ҫ����ĵ㡣</param>
        /// <returns>��������������ͣ���ĵ㡣</returns>
        public Point Docking(Point p)
        {
            int x = p.X;
            int y = p.Y;

            Point pointFounded = WrongPoint;
            if (Owner != null)
            {
                Rectangle rect = new Rectangle(Owner.Location, Owner.Size);
                pointFounded = CalDockPoint(new Point(x, y), rect);
                if (pointFounded.X > WrongPoint.X)
                {
                    Docked = true;
                    return pointFounded;
                }
            }
            Docked = false;
            return pointFounded;
        }

        ///<summary>
        ///���㹤��������������ͣ���ĵ㡣
        ///</summary>
        /// <param name="point">��Ҫ����ĵ㡣</param>
        ///<param name="dockRectangle">��Ҫ���������</param>
        ///<returns>����������ͣ���ĵ㡣��û�����������ĵ㣬�򷵻�X��Y��Ϊ-10000�ĵ㡣</returns>
        private Point CalDockPoint(Point point, Rectangle dockRectangle)
        {
            int x = point.X;
            int y = point.Y;
            bool haveDockPoint = false;
            int dockMarginal = DockParentMarginal;
            int dockAdd = dockMarginal + DockProbeMarginal;

            bool hMixed = JudgeMixed(x, x + Width, dockRectangle.X, dockRectangle.X + dockRectangle.Width);
            bool vMixed = JudgeMixed(y, y + Height, dockRectangle.Y, dockRectangle.Y + dockRectangle.Height);
            if (!hMixed && !vMixed)
                return WrongPoint;
            if (point.X + Width > dockRectangle.X - dockAdd && point.X + Width < dockRectangle.X + dockAdd && vMixed)
            {
                x = dockRectangle.X - dockMarginal - Width;
                haveDockPoint = true;
            }

            int toolBoxHeight = point.Y;
            int rectHeight = dockRectangle.Y + dockRectangle.Height;
            if (toolBoxHeight > rectHeight - dockAdd && toolBoxHeight < rectHeight + dockAdd && hMixed)
            {
                y = rectHeight + dockMarginal;
                haveDockPoint = true;
            }

            int toolBoxWidth = point.X;
            int rectWidth = dockRectangle.X + dockRectangle.Width;
            if (toolBoxWidth > rectWidth - dockAdd && toolBoxWidth < rectWidth + dockAdd && vMixed)
            {
                x = rectWidth + dockMarginal;
                haveDockPoint = true;
            }

            if (point.Y + Height > dockRectangle.Y - dockAdd && point.Y + Height < dockRectangle.Y + dockAdd && hMixed)
            {
                y = dockRectangle.Y - dockMarginal - Height;
                haveDockPoint = true;
            }
            if (haveDockPoint)
                return new Point(x, y);

            return WrongPoint;
        }

        protected override void HookOnMouseActivityEvent(object sender, MouseEventArgs e)
        {
            if (QuickReportCore.Managers.KeyboardAndMouseHooker.GlobalMouseEventArgs.Button != MouseButtons.None)
            {
                return;
            }
            if (GetType().GetInterface(typeof(Interfaces.IHaveAComboBox).FullName) != null)
            {
                if (((Interfaces.IHaveAComboBox)this).ComboBoxShowState)
                    return;
            }
            if (IfPointInWindow(e.Location))
            {
                if (!Visible)
                {
                    if (MouseHaveBeenEatenByWho == Name)
                        MouseHaveBeenEatenByWho = string.Empty;
                    return;
                }
                if (MouseHaveBeenEatenByWho != string.Empty && MouseHaveBeenEatenByWho != Name)
                    return;
                MouseHaveBeenEatenByWho = Name;
                Opacity = 1;
                if (toolStripProtectd)
                    return;
                toolStripProtectd = true;
                if (GetType().GetInterface(typeof(Interfaces.IHaveAToolStrip).FullName) != null)
                {
                    ((Interfaces.IHaveAToolStrip)this).SetToolStripFocus();
                }
            }
            else
            {
                toolStripProtectd = false;
                if (MouseHaveBeenEatenByWho == Name)
                {
                    MouseHaveBeenEatenByWho = string.Empty;
                    Opacity = DefaultFormOpacity;
                }
            }

            base.HookOnMouseActivityEvent(sender, e);
        }

        /// <summary>
        /// �ж����������Ƿ���ڽ�����
        /// </summary>
        /// <param name="a1">��һ�����н�С���֡�</param>
        /// <param name="a2">��һ�����нϴ����֡�</param>
        /// <param name="b1">�ڶ������н�С���֡�</param>
        /// <param name="b2">�ڶ������нϴ����֡�</param>
        ///<returns>�Ƿ���ڽ�����</returns>
        private bool JudgeMixed(int a1, int a2, int b1, int b2)
        {
            if (b1 >= a1 && b1 <= a2 || a1 >= b1 && a1 <= b2)
                return true;
            return false;
        }

        private void frmBaseToolBox_Load(object sender, EventArgs e)
        {
            Opacity = DefaultFormOpacity;
        }
    }
}