using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects;
using QuickReportLib.Interfaces;
using QuickReportLib.Interfaces.ReportSetting;
using QuickReportLib.Controls.Plus.IToolStripMenuProvider;

namespace QuickReportLib.Controls.ReportSetting
{
    internal partial class ReportSettingTabPage : TabPage, IShowStatusStripHelp, IToolStripMenuProvider ,IBringToFront
    {
        public ReportSettingTabPage(IReportSettingUserControl iReportSettingUserControl,Report report)
        {
            InitializeComponent();
            this.iReportSettingUserControl = iReportSettingUserControl;
            this.report = report;
            Init();
        }

        private Report report;
        private IReportSettingUserControl iReportSettingUserControl;
        private ToolStripItem[] toolStripItemsNull = new ToolStripItem[] { new ToolStripButtonNull() };

        private void Init()
        {
            Text = iReportSettingUserControl.SettingName;
            (iReportSettingUserControl as Control).Dock = DockStyle.Fill;
            iReportSettingUserControl.Report = report;
            Controls.Add(iReportSettingUserControl as Control);
            iReportSettingUserControl.AskForBringToFront += new AskForBringToFrontHandle(iReportSettingUserControl_AskForBringToFront);
        }

        void iReportSettingUserControl_AskForBringToFront(object sender, EventArgs e)
        {
            if (AskForBringToFront != null)
            {
                AskForBringToFront(this, null);
            }
            (Parent as TabControl).SelectedTab = this;
        }

        protected override void OnEnter(EventArgs e)
        {
            if (ShowStatusStripHelp != null)
            {
                ShowStatusStripHelp(this, iReportSettingUserControl.SettingSummary);
            }
            ToolStripItem[] toolStripItems = iReportSettingUserControl.GetToolStripItems();
            if (toolStripItems != null)
            {
                if (ProvideToolStripMenu != null)
                {
                    ProvideToolStripMenu(this, toolStripItems);
                }
            }
            else
            {
                if (ProvideToolStripMenu != null)
                {
                    ProvideToolStripMenu(this, toolStripItemsNull);
                }
            }
            base.OnEnter(e);
        }

        #region IShowStatusStripHelp 成员

        public event ShowStatusStripHelpHandle ShowStatusStripHelp;

        #endregion

        #region IToolStripMenuProvider 成员

        public event ProvideToolStripMenuHandle ProvideToolStripMenu;

        #endregion

        #region IBringToFront 成员

        public event AskForBringToFrontHandle AskForBringToFront;

        #endregion
    }
}
