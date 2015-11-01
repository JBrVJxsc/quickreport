using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace QuickReportLib.Forms
{
    public partial class FormWithArrow : BaseForm
    {
        public FormWithArrow()
        {
            InitializeComponent();
        }

        private Color arrowColor = Color.LightGray;
        private Color arrowAreaColor = Color.White;
        private Point arrowOffset = new Point(0, 0);
        private int arrowHeight = 10;
        private int arrowWidth = 21;
        /// <summary>
        /// 存储箭头的五个点。
        /// </summary>
        private Point[] points = new Point[5];

        /// <summary>
        /// 箭头线条的颜色。
        /// </summary>
        public Color ArrowColor
        {
            get
            {
                return arrowColor;
            }
            set
            {
                arrowColor = value;
            }
        }

        /// <summary>
        /// 箭头内所包含区域的颜色。
        /// </summary>
        public Color ArrowAreaColor
        {
            get
            {
                return arrowAreaColor;
            }
            set
            {
                arrowAreaColor = value;
            }
        }

        /// <summary>
        /// 箭头所指向的坐标的偏移量。
        /// </summary>
        public Point ArrowOffset
        {
            get
            {
                return arrowOffset;
            }
            set
            {
                arrowOffset = value;
            }
        }

        /// <summary>
        /// 箭头的高度。
        /// </summary>
        public int ArrowHeight
        {
            get
            {
                return arrowHeight;
            }
            set
            {
                if (value > pnlArrow.Height)
                {
                    throw new Exception("箭头的高度不允许超过Panel的高度。");
                }
                if (value < 0)
                {
                    throw new Exception("箭头的高度不允许小于零。");
                }
                arrowHeight = value;
            }
        }


        /// <summary>
        /// 箭头的宽度。
        /// </summary>
        public int ArrowWidth
        {
            get
            {
                return arrowWidth;
            }
            set
            {
                if (value > pnlArrow.Width)
                {
                    throw new Exception("箭头的宽度不允许超过Panel的宽度。");
                }
                if (value < 0)
                {
                    throw new Exception("箭头的宽度不允许小于零。");
                }
                arrowWidth = value;
            }
        }

        /// <summary>
        /// Panel的高度。
        /// </summary>
        public int PanelHeight
        {
            get
            {
                return pnlArrow.Height;  
            }
            set
            {
                pnlArrow.Height = value;
            }
        }

        private bool SetLocation(Rectangle rectangle, Point point)
        {
            point.Offset(arrowOffset);
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            //如果宽度超过总区域的宽度，则不显示。
            if (Width > rectangle.Width)
            {
                return false;
            }
            //如果箭头可以在窗体的正中央显示。
            if (point.X - Width / 2 >= rectangle.Left && point.X + Width / 2 <= rectangle.Right)
            {
                point.Offset(-Width / 2, 0);
                Location = point;
                points[0] = new Point(0, arrowHeight);
                points[1] = new Point(Width / 2 - arrowWidth / 2, arrowHeight);
                points[2] = new Point(Width / 2, 0);
                points[3] = new Point(Width / 2 + arrowWidth / 2, arrowHeight);
                points[4] = new Point(Width, arrowHeight);
            }
            else
            {
                //如果窗体左溢出。
                if (point.X - Width / 2 < rectangle.Left)
                {
                    //如果箭头不能全部显示。
                    if (point.X - rectangle.Left <= arrowWidth / 2)
                    {
                        Location = point;
                        points[0] = new Point(0, arrowHeight);
                        points[1] = new Point(0, arrowHeight);
                        points[2] = new Point(0,0);
                        points[3] = new Point(arrowWidth / 2, arrowHeight);
                        points[4] = new Point(Width, arrowHeight);
                    }
                    else
                    {
                        Location = new Point(rectangle.Left, point.Y);
                        points[0] = new Point(0, arrowHeight);
                        points[1] = new Point(point.X - Location.X - arrowWidth/2, arrowHeight);
                        points[2] = new Point(point.X - Location.X,0);
                        points[3] = new Point(point.X - Location.X+arrowWidth / 2, arrowHeight);
                        points[4] = new Point(Width, arrowHeight);
                    }
                }
                else
                {
                    //如果箭头不能全部显示。
                    if (rectangle.Right-point.X <= arrowWidth / 2)
                    {
                        point.Offset(-Width, 0);
                        Location = point;
                        points[0] = new Point(0, arrowHeight);
                        points[1] = new Point(Width-arrowWidth/2,arrowHeight);
                        points[2] = new Point(Width, 0);
                        points[3] = new Point(Width, arrowHeight);
                        points[4] = new Point(Width, arrowHeight);
                    }
                    else
                    {
                        Location = new Point(rectangle.Right - Width,point.Y);
                        points[0] = new Point(0, arrowHeight);
                        points[1] = new Point(point.X-Location.X - arrowWidth / 2,arrowHeight);
                        points[2] = new Point(point.X-Location.X, 0);
                        points[3] = new Point(point.X-Location.X+arrowWidth/2, arrowHeight);
                        points[4] = new Point(Width, arrowHeight);
                    }
                }
            }
            pnlArrow.Invalidate();
            return true;
        }

        private void pnlArrow_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //先将整个Panel背景色设置为透明。
            pnlArrow.BackColor = TransparencyKey;
            //画线。
            using (Pen pen = new Pen(arrowColor))
            {
                e.Graphics.DrawLines(pen, points);
            }
            //将箭头内包含的区域颜色设置为指定的颜色。
            using (Brush brush = new SolidBrush(arrowAreaColor))
            {
                //算上画箭头用的点，一共7个点。
                Point[] newPoints = new Point[7];
                Point point = new Point(0, pnlArrow.Height);
                point.Offset(-1, 0);
                newPoints[0] = point;
                points[0].Offset(-1, 0);
                newPoints[1] = points[0];
                newPoints[2] = points[1];
                newPoints[3] = points[2];
                newPoints[4] = points[3];
                newPoints[5] = points[4];
                newPoints[6] = new Point(pnlArrow.Width, pnlArrow.Height);
                e.Graphics.FillPolygon(brush, newPoints);
            }
        }

        /// <summary>
        /// 显示箭头窗体。
        /// </summary>
        /// <param name="rectangle">可以容纳窗体的区域。</param>
        /// <param name="point">箭头所指向的位置。</param>
        public void Show(Rectangle rectangle, Point point)
        {
            bool canShow = SetLocation(rectangle,point);
            if (canShow)
            {
                Show();
                BringToFront();
            }
        }

        /// <summary>
        /// 显示箭头窗体。
        /// </summary>
        /// <param name="rectangle">可以容纳窗体的区域。</param>
        /// <param name="point">箭头所指向的位置。</param>
        public void ShowDialog(Rectangle rectangle, Point point)
        {
            bool canShow = SetLocation(rectangle,point);
            if (canShow)
            {
                ShowDialog();
            }
        }
    }
}