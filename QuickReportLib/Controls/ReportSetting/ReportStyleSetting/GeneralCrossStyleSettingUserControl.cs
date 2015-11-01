using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.ReportStyles;
using QuickReportLib.Objects.ReportStyleSetting;
using QuickReportLib.Interfaces.ReportStyle;
using QuickReportLib.Objects;
using QuickReportLib.Interfaces.ReportSetting;

namespace QuickReportLib.Controls.ReportSetting.ReportStyleSetting
{
    /// <summary>
    /// 一般交叉报表样式的设置界面。
    /// </summary>
    internal partial class GeneralCrossStyleSettingUserControl : BaseReportSettingUserControl, IReportStyleSettingUserControl
    {
        public GeneralCrossStyleSettingUserControl()
        {
            InitializeComponent();
        }

        private GeneralCrossStyleSetting generalCrossStyleSetting;

        #region IReportStyleSettingUserControl 成员

        public BaseStyleSetting StyleSettingObject
        {
            get
            {
                return generalCrossStyleSetting;
            }
            set
            {
                generalCrossStyleSetting = value as GeneralCrossStyleSetting;
            }
        }

        #endregion

        #region IReportSettingUserControl 成员

        public string SettingName
        {
            get
            {
                return "样式";
            }
        }

        public string SettingSummary
        {
            get
            {
                return "设置普通交叉报表样式";
            }
        }

        public int Save()
        {
            return 1;
        }

        public ToolStripItem[] GetToolStripItems()
        {
            return null;
        }

        public event AskForBringToFrontHandle AskForBringToFront;

        #endregion
    }
}
