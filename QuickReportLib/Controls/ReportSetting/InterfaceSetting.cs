using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Interfaces.ReportSetting;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Interfaces;
using QuickReportLib.Interfaces.PublicInterface;
using QuickReportLib.Managers;
using QuickReportLib.Enums;
using QuickReportLib.Controls.Plus.IToolStripMenuProvider;
using QuickReportLib.Objects;

namespace QuickReportLib.Controls.ReportSetting
{
    internal partial class InterfaceSetting : BaseReportSettingUserControl, IInterfaceSettingUserControl , ILoadedListener
    {
        public InterfaceSetting()
        {
            InitializeComponent();
        }

        private ToolStripItem[] toolStripItems;
        private ToolStripButtonNewOne toolStripButtonNewOne;
        private ToolStripButtonDeleteOne toolStripButtonDeleteOne;
        private ToolStripButtonUp toolStripButtonUp;
        private ToolStripButtonDown toolStripButtonDown;

        public override Report Report
        {
            get
            {
                return base.Report;
            }
            set
            {
                base.Report = value;
                InitControls();
            }
        }

        private IPublicInterfaceSettingUserControl SelectedIPublicInterfaceSettingUserControl
        {
            get
            {
                IPublicInterfaceSettingUserControl iPublicInterfaceSettingUserControl = tabControl.SelectedTab.Tag as IPublicInterfaceSettingUserControl;
                return iPublicInterfaceSettingUserControl;
            }
        }

        private void InitControls()
        {
            List<Type> iPublicInterfaceList = ReflectionManager.GetTypesByInterface(typeof(IPublicInterface), TypeOfType.Interface);
            List<object> iPublicInterfaceSettingList=ReflectionManager.CreateInstancesByInterface(typeof(IPublicInterfaceSettingUserControl));
            foreach (Type type in iPublicInterfaceList)
            {
                foreach (IPublicInterfaceSettingUserControl iPublicInterfaceSettingUserControl in iPublicInterfaceSettingList)
                {
                    if (type == iPublicInterfaceSettingUserControl.InterfaceType)
                    {
                        iPublicInterfaceSettingUserControl.InterfaceSetting = report.MainReportSetting.InterfaceSetting;
                        TabPage tabPage = new TabPage();
                        tabPage.Text = type.Name;
                        tabPage.Controls.Add(iPublicInterfaceSettingUserControl as Control);
                        (iPublicInterfaceSettingUserControl as Control).Dock = DockStyle.Fill;
                        tabPage.Tag = iPublicInterfaceSettingUserControl;
                        tabControl.TabPages.Add(tabPage);
                    }
                }
            }
        }

        #region IReportSettingUserControl 成员

        public string SettingName
        {
            get
            {
                return "接口";
            }
        }

        public string SettingSummary
        {
            get
            {
                return "设置报表的接口";
            }
        }

        public int Save()
        {
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                IPublicInterfaceSettingUserControl iPublicInterfaceSettingUserControl = tabPage.Tag as IPublicInterfaceSettingUserControl;
                int i = iPublicInterfaceSettingUserControl.CheckInput();
                if (i < 0)
                {
                    return -1;
                }
            }
            return 1;
        }

        public ToolStripItem[] GetToolStripItems()
        {
            if (toolStripItems == null)
            {
                toolStripItems = new ToolStripItem[4];
                toolStripButtonNewOne = new ToolStripButtonNewOne();
                toolStripButtonDeleteOne = new ToolStripButtonDeleteOne();
                toolStripButtonUp = new ToolStripButtonUp();
                toolStripButtonDown = new ToolStripButtonDown();
                toolStripButtonNewOne.Click += new EventHandler(toolStripButtonNewOne_Click);
                toolStripButtonDeleteOne.Click += new EventHandler(toolStripButtonDeleteOne_Click);
                toolStripButtonUp.Click += new EventHandler(toolStripButtonUp_Click);
                toolStripButtonDown.Click += new EventHandler(toolStripButtonDown_Click);
                toolStripItems[0] = toolStripButtonNewOne;
                toolStripItems[1] = toolStripButtonDeleteOne;
                toolStripItems[2] = toolStripButtonUp;
                toolStripItems[3] = toolStripButtonDown;

                List<InterfaceSettingToolStripButtonType> interfaceSettingToolStripButtonTypeList = SelectedIPublicInterfaceSettingUserControl.GetNeededToolStripButtons();
                if (!interfaceSettingToolStripButtonTypeList.Contains(InterfaceSettingToolStripButtonType.Add))
                {
                    toolStripButtonNewOne.Visible = false;
                }
                if (!interfaceSettingToolStripButtonTypeList.Contains(InterfaceSettingToolStripButtonType.Delete))
                {
                    toolStripButtonDeleteOne.Visible = false;
                }
                if (!interfaceSettingToolStripButtonTypeList.Contains(InterfaceSettingToolStripButtonType.Up))
                {
                    toolStripButtonUp.Visible = false;
                }
                if (!interfaceSettingToolStripButtonTypeList.Contains(InterfaceSettingToolStripButtonType.Down))
                {
                    toolStripButtonDown.Visible = false;
                }
            }
            return toolStripItems;
        }

        void toolStripButtonDown_Click(object sender, EventArgs e)
        {
            SelectedIPublicInterfaceSettingUserControl.Down();
        }

        void toolStripButtonUp_Click(object sender, EventArgs e)
        {
            SelectedIPublicInterfaceSettingUserControl.Up();
        }

        void toolStripButtonDeleteOne_Click(object sender, EventArgs e)
        {
            SelectedIPublicInterfaceSettingUserControl.Delete();
        }

        void toolStripButtonNewOne_Click(object sender, EventArgs e)
        {
            SelectedIPublicInterfaceSettingUserControl.Add();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<InterfaceSettingToolStripButtonType> interfaceSettingToolStripButtonTypeList= SelectedIPublicInterfaceSettingUserControl.GetNeededToolStripButtons();
            toolStripButtonNewOne.Visible = true;
            toolStripButtonDeleteOne.Visible = true; 
            toolStripButtonUp.Visible = true; 
            toolStripButtonDown.Visible = true;
            if (!interfaceSettingToolStripButtonTypeList.Contains(InterfaceSettingToolStripButtonType.Add))
            {
                toolStripButtonNewOne.Visible = false;
            }
            if (!interfaceSettingToolStripButtonTypeList.Contains(InterfaceSettingToolStripButtonType.Delete))
            {
                toolStripButtonDeleteOne.Visible = false;
            }
            if (!interfaceSettingToolStripButtonTypeList.Contains(InterfaceSettingToolStripButtonType.Up))
            {
                toolStripButtonUp.Visible = false;
            }
            if (!interfaceSettingToolStripButtonTypeList.Contains(InterfaceSettingToolStripButtonType.Down))
            {
                toolStripButtonDown.Visible = false;
            }
        }

        public event AskForBringToFrontHandle AskForBringToFront;

        #endregion

        #region ILoadedListener 成员

        public void Loaded()
        {
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                IPublicInterfaceSettingUserControl iPublicInterfaceSettingUserControl = tabPage.Tag as IPublicInterfaceSettingUserControl;
                iPublicInterfaceSettingUserControl.Loaded();
            }
        }

        #endregion
    }
}
