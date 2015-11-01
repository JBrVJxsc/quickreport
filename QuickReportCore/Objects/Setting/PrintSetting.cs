using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore.Objects.Setting
{
    /// <summary>
    /// 打印设置。
    /// </summary>
    internal class PrintSetting : FarPoint.Win.Spread.PrintInfo
    {
        public static PrintSetting GobalPrintSetting=new PrintSetting();

        public static void ShowSetting()
        {
            PropertyGrid pg = new PropertyGrid();
            pg.SelectedObject = GobalPrintSetting;
            Form frm = new Form();
            frm.Controls.Add(pg);
            pg.Dock = DockStyle.Fill;
            frm.WindowState = FormWindowState.Maximized;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private bool showColumnHeaderInEveryPage = true;
        /// <summary>
        /// 每页都绘制表首与列头。
        /// </summary>
        public bool ShowColumnHeaderInEveryPage
        {
            get
            {
                return showColumnHeaderInEveryPage;
            }
            set
            {
                showColumnHeaderInEveryPage = value;
            }
        }

        private bool showEvenColor = false;
        /// <summary>
        /// 显示间隔色。
        /// </summary>
        public bool ShowEvenColor
        {
            get
            {
                return showEvenColor;
            }
            set
            {
                showEvenColor = value;
            }
        }
    }
}
