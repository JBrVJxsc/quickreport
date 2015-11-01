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
        /// �洢��ͷ������㡣
        /// </summary>
        private Point[] points = new Point[5];

        /// <summary>
        /// ��ͷ��������ɫ��
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
        /// ��ͷ���������������ɫ��
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
        /// ��ͷ��ָ��������ƫ������
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
        /// ��ͷ�ĸ߶ȡ�
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
                    throw new Exception("��ͷ�ĸ߶Ȳ�������Panel�ĸ߶ȡ�");
                }
                if (value < 0)
                {
                    throw new Exception("��ͷ�ĸ߶Ȳ�����С���㡣");
                }
                arrowHeight = value;
            }
        }


        /// <summary>
        /// ��ͷ�Ŀ�ȡ�
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
                    throw new Exception("��ͷ�Ŀ�Ȳ�������Panel�Ŀ�ȡ�");
                }
                if (value < 0)
                {
                    throw new Exception("��ͷ�Ŀ�Ȳ�����С���㡣");
                }
                arrowWidth = value;
            }
        }

        /// <summary>
        /// Panel�ĸ߶ȡ�
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
            //�����ȳ���������Ŀ�ȣ�����ʾ��
            if (Width > rectangle.Width)
            {
                return false;
            }
            //�����ͷ�����ڴ������������ʾ��
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
                //��������������
                if (point.X - Width / 2 < rectangle.Left)
                {
                    //�����ͷ����ȫ����ʾ��
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
                    //�����ͷ����ȫ����ʾ��
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
            //�Ƚ�����Panel����ɫ����Ϊ͸����
            pnlArrow.BackColor = TransparencyKey;
            //���ߡ�
            using (Pen pen = new Pen(arrowColor))
            {
                e.Graphics.DrawLines(pen, points);
            }
            //����ͷ�ڰ�����������ɫ����Ϊָ������ɫ��
            using (Brush brush = new SolidBrush(arrowAreaColor))
            {
                //���ϻ���ͷ�õĵ㣬һ��7���㡣
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
        /// ��ʾ��ͷ���塣
        /// </summary>
        /// <param name="rectangle">�������ɴ��������</param>
        /// <param name="point">��ͷ��ָ���λ�á�</param>
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
        /// ��ʾ��ͷ���塣
        /// </summary>
        /// <param name="rectangle">�������ɴ��������</param>
        /// <param name="point">��ͷ��ָ���λ�á�</param>
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