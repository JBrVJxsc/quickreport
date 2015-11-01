using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace QuickReportLib.Controls.Plus
{
    /// <summary>
    /// �Զ����ToolTip��
    /// </summary>
    public partial class ToolTipPlus : ToolTip
    {
        public ToolTipPlus()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            ToolTipIcon = ToolTipIcon.Info;
            ForeColor = Color.Black;
            ToolTipTitle = "��ʾ";
            ShowAlways = true;
        }
    }
}
