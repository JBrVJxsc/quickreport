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
    /// ���񱨱���ʽ�����ý��档
    /// </summary>
    internal partial class GridStyleSettingUserControl : BaseReportSettingUserControl, IReportStyleSettingUserControl
    {
        public GridStyleSettingUserControl()
        {
            InitializeComponent();
        }

        private GridStyleSetting gridStyleSetting;

        #region IReportStyleSettingUserControl ��Ա

        public BaseStyleSetting StyleSettingObject
        {
            get
            {
                return gridStyleSetting;
            }
            set
            {
                gridStyleSetting = value as GridStyleSetting;
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
                return "�������񱨱���ʽ";
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
