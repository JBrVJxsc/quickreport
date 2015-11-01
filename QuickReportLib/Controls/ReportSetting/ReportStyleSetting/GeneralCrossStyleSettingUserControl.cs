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
    /// һ�㽻�汨����ʽ�����ý��档
    /// </summary>
    internal partial class GeneralCrossStyleSettingUserControl : BaseReportSettingUserControl, IReportStyleSettingUserControl
    {
        public GeneralCrossStyleSettingUserControl()
        {
            InitializeComponent();
        }

        private GeneralCrossStyleSetting generalCrossStyleSetting;

        #region IReportStyleSettingUserControl ��Ա

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

        #region IReportSettingUserControl ��Ա

        public string SettingName
        {
            get
            {
                return "��ʽ";
            }
        }

        public string SettingSummary
        {
            get
            {
                return "������ͨ���汨����ʽ";
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
