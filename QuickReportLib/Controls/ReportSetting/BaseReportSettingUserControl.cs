using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects;

namespace QuickReportLib.Controls.ReportSetting
{
    internal partial class BaseReportSettingUserControl : BaseUserControl
    {
        public BaseReportSettingUserControl()
        {
            InitializeComponent();
        }

        protected Report report;

        /// <summary>
        /// 报表实体。
        /// </summary>
        public virtual Report Report
        {
            get
            {
                return report;
            }
            set
            {
                report = value;
            }
        }
    }
}
