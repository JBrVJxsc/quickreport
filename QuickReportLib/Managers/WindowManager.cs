using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using QuickReportLib.Controls.Plus;

namespace QuickReportLib.Managers
{
    /// <summary>
    /// �ṩ��Window��صĳ��÷����ľ�̬�ࡣ
    /// </summary>
    internal static class WindowManager
    {
        private static ToolTipPlus toolTip = new ToolTipPlus();

        /// <summary>
        /// �����һ����ʾ��ToolTipPlus��
        /// </summary>
        private static void ClearToolTip()
        {
            toolTip.Dispose();
            toolTip = new ToolTipPlus();
        }

        /// <summary>
        /// ��ʾһ��������ʾ��
        /// </summary>
        /// <param name="c">��ʾ��λ�ڵĿؼ���</param>
        /// <param name="message">��Ϣ��</param>
        public static void ShowToolTip(Control c, string message)
        {
            ClearToolTip();
            toolTip.Show(message, c, 5000);
        }

        /// <summary>
        /// ��ʾһ��������ʾ��
        /// </summary>
        /// <param name="c">��ʾ��λ�ڵĿؼ�</param>
        /// <param name="message">��Ϣ��</param>
        /// <param name="focus">��ʾ���Ƿ񽫽������ڿؼ��ϡ�</param>
        public static void ShowToolTip(Control c, string message, bool focus)
        {
            ClearToolTip();
            toolTip.Show(message, c, 5000);
            if (focus)
                c.Focus();
        }

        /// <summary>
        /// ��ʾһ��������ʾ��
        /// </summary>
        /// <param name="c">��ʾ��λ�ڵĿؼ���</param>
        /// <param name="message">��Ϣ��</param>
        /// <param name="during">��ʾ��������ʱ�䡣</param>
        public static void ShowToolTip(Control c, string message, int during)
        {
            ClearToolTip();
            toolTip.Show(message, c, during);
        }

        /// <summary>
        /// ��ʾһ��������ʾ��
        /// </summary>
        /// <param name="c">��ʾ��λ�ڵĿؼ���</param>
        /// <param name="message">��Ϣ��</param>
        /// <param name="location">���ݵ�λ�á�</param>
        public static void ShowToolTip(Control c, string message, Point location)
        {
            ClearToolTip();
            toolTip.Show(message, c, location, 5000);
        }

        /// <summary>
        /// ��ʾһ��������ʾ��
        /// </summary>
        /// <param name="c">��ʾ��λ�ڵĿؼ���</param>
        /// <param name="message">��Ϣ��</param>
        /// <param name="during">��ʾ��������ʱ�䡣</param>
        /// <param name="location">���ݵ�λ�á�</param>
        public static void ShowToolTip(Control c, string message, int during, Point location)
        {
            ClearToolTip();
            toolTip.Show(message, c, location, during);
        }

        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);
        [Flags]
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }

        internal static readonly int GWL_EXSTYLE = -20;
        internal static readonly int WS_DISABLED = 0X8000000;

        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        internal static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        internal static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        internal static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);

        /// <summary>
        /// �����ִ��һ�ε���������
        /// </summary>
        public static void MouseClick()
        {
            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
        }

        [DllImport("user32.dll ")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll ")]
        public static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll ")]
        public static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        /// <summary>
        /// ��ȡ������ĳ���ص����ɫ��
        /// </summary>
        /// <param name="handle">���ڵľ������Ϊ0����ȡȫ��Ļ��</param>
        /// <param name="point">���ص����ڵ�λ�á�</param>
        /// <returns>��ɫ��</returns>
        public static Color GetColorFromPixel(IntPtr handle , Point point)
        {
            IntPtr dC = GetDC(handle);
            int pixel = (int)GetPixel(dC, point.X, point.Y);
            Color color = Color.FromArgb(
                    (pixel & 0x000000FF) >> 0,
                    (pixel & 0x0000FF00) >> 8,
                    (pixel & 0x00FF0000) >> 16);
            ReleaseDC(IntPtr.Zero, dC);
            return color;
        }

        /// <summary>
        /// ���ҿؼ����ڵĶ������塣
        /// </summary>
        /// <param name="control">�ؼ���</param>
        /// <returns>���塣</returns>
        public static Form GetTopParentForm(Control control)
        {
            Control controlFind=control.Parent;
            if (controlFind == null)
            {
                return null;
            }
            else
            {
                if (controlFind.Parent != null)
                {
                    controlFind = GetTopParentForm(controlFind.Parent);
                }
            }
            return controlFind as Form;
        }
    }
}
