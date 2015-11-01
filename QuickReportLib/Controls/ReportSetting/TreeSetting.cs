using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Interfaces.ReportSetting;
using QuickReportLib.Objects.GlobalValue;
using QuickReportLib.Interfaces;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Controls.Plus.IToolStripMenuProvider;

namespace QuickReportLib.Controls.ReportSetting
{
    internal partial class TreeSetting : BaseReportSettingUserControl , ITreeSettingUserControl
    {
        public TreeSetting()
        {
            InitializeComponent();
        }

        private TreeGlobalValue treeGlobalValue = new TreeGlobalValue();

        #region IReportSettingUserControl 成员


        public string SettingName
        {
            get
            {
                return "树";
            }
        }

        public string SettingSummary
        {
            get
            {
                return "设置报表的树";
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

        #region IGlobalValueProvider 成员

        public event GlobalValueChangedHandle GlobalValueChanged;

        #endregion
    }
}
