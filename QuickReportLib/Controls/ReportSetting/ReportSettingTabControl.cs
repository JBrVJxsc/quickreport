using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Objects;
using QuickReportLib.Managers;
using QuickReportLib.Interfaces.ReportSetting;
using QuickReportLib.ReportLayoutStyles;
using QuickReportLib.ReportStyles;

namespace QuickReportLib.Controls.ReportSetting
{
    internal partial class ReportSettingTabControl : TabControl
    {
        public ReportSettingTabControl()
        {
            InitializeComponent();
        }

        private Report report;

        public void Init(Report report)
        {
            this.report = report;
            BaseReportStyle style = this.report.ReportStyle;
            BaseReportLayoutStyle layoutStyle = this.report.ReportLayoutStyle;
            IReportSettingUserControl[] settingUserControls = layoutStyle.GetReportSettingControls();
            TabPage tabPage ;
            foreach (IReportSettingUserControl settingUserControl in settingUserControls)
            {
                tabPage  = GetTabPage(settingUserControl);
                TabPages.Add(tabPage);
            }
            tabPage = GetTabPage(style.GetStyleSettingUserControl());
            TabPages.Add(tabPage);
        }

        private TabPage GetTabPage(IReportSettingUserControl iReportSettingUserControl)
        {
            ReportSettingTabPage tabPage = new ReportSettingTabPage(iReportSettingUserControl,report);
            return tabPage;
        }
    }
}
