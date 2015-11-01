namespace QuickReportLib.Controls.ReportSetting
{
    partial class ReportSettingPlatForm
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.headerSetting = new QuickReportLib.Controls.ReportSetting.HeaderSetting();
            this.reportSettingTabControl = new QuickReportLib.Controls.ReportSetting.ReportSettingTabControl();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.headerSetting);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.reportSettingTabControl);
            this.scMain.Size = new System.Drawing.Size(768, 497);
            this.scMain.SplitterDistance = 221;
            this.scMain.TabIndex = 0;
            // 
            // headerSetting
            // 
            this.headerSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerSetting.Location = new System.Drawing.Point(0, 0);
            this.headerSetting.Name = "headerSetting";
            this.headerSetting.Size = new System.Drawing.Size(768, 221);
            this.headerSetting.TabIndex = 0;
            // 
            // reportSettingTabControl
            // 
            this.reportSettingTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportSettingTabControl.Location = new System.Drawing.Point(0, 0);
            this.reportSettingTabControl.Name = "reportSettingTabControl";
            this.reportSettingTabControl.SelectedIndex = 0;
            this.reportSettingTabControl.Size = new System.Drawing.Size(768, 272);
            this.reportSettingTabControl.TabIndex = 0;
            // 
            // ReportSettingPlatForm
            // 
            this.Controls.Add(this.scMain);
            this.Name = "ReportSettingPlatForm";
            this.Size = new System.Drawing.Size(768, 497);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private ReportSettingTabControl reportSettingTabControl;
        private HeaderSetting headerSetting;
    }
}
