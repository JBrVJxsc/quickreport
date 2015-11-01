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
    /// 提供与Window相关的常用方法的静态类。
    /// </summary>
    internal static class WindowManager
    {
        private static ToolTipPlus toolTip = new ToolTipPlus();

        /// <summary>
        /// 清空上一个显示的ToolTipPlus。
        /// </summary>
        private static void ClearToolTip()
        {
            toolTip.Dispose();
            toolTip = new ToolTipPlus();
        }

        /// <summary>
        /// 显示一个气泡提示。
        /// </summary>
        /// <param name="c">显示所位于的控件。</param>
        /// <param name="message">信息。</param>
        public static void ShowToolTip(Control c, string message)
        {
            ClearToolTip();
            toolTip.Show(message, c, 5000);
        }

        /// <summary>
        /// 显示一个气泡提示。
        /// </summary>
        /// <param name="c">显示所位于的控件</param>
        /// <param name="message">信息。</param>
        /// <param name="focus">显示后，是否将焦点置于控件上。</param>
        public static void ShowToolTip(Control c, string message, bool focus)
        {
            ClearToolTip();
            toolTip.Show(message, c, 5000);
            if (focus)
                c.Focus();
        }

        /// <summary>
        /// 显示一个气泡提示。
        /// </summary>
        /// <param name="c">显示所位于的控件。</param>
        /// <param name="message">信息。</param>
        /// <param name="during">显示所持续的时间。</param>
        public static void ShowToolTip(Control c, string message, int during)
        {
            ClearToolTip();
            toolTip.Show(message, c, during);
        }

        /// <summary>
        /// 显示一个气泡提示。
        /// </summary>
        /// <param name="c">显示所位于的控件。</param>
        /// <param name="message">信息。</param>
        /// <param name="location">气泡的位置。</param>
        public static void ShowToolTip(Control c, string message, Point location)
        {
            ClearToolTip();
            toolTip.Show(message, c, location, 5000);
        }

        /// <summary>
        /// 显示一个气泡提示。
        /// </summary>
        /// <param name="c">显示所位于的控件。</param>
        /// <param name="message">信息。</param>
        /// <param name="during">显示所持续的时间。</param>
        /// <param name="location">气泡的位置。</param>
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
        /// 让鼠标执行一次单击操作。
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
        /// 获取窗口上某像素点的颜色。
        /// </summary>
        /// <param name="handle">窗口的句柄。若为0，则取全屏幕。</param>
        /// <param name="point">像素点所在的位置。</param>
        /// <returns>颜色。</returns>
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
        /// 查找控件所在的顶级窗体。
        /// </summary>
        /// <param name="control">控件。</param>
        /// <returns>窗体。</returns>
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
