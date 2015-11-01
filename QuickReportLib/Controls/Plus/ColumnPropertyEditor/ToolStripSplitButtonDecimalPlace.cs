using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;


namespace QuickReportLib.Controls.Plus.IToolStripMenuProvider.HeaderSetting.ReportColumn
{
    internal partial class ToolStripSplitButtonDecimalPlace : ToolStripSplitButtonPlus, IHeaderSettingToolStripItem
    {
        public ToolStripSplitButtonDecimalPlace()
        {
            InitializeComponent();
            InitDropDownItems();
            Visible = false;
        }

        private ToolStripMenuItem[] toolStripMenuItems;
        private FpSpreadForHeaderSetting fpSpreadForHeaderSetting;

        private void InitDropDownItems()
        {
            toolStripMenuItems = new ToolStripMenuItem[5];
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Tag = 0;
            toolStripMenuItem.Text = "整数";
            toolStripMenuItems[0] = toolStripMenuItem;
            toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Tag = 1;
            toolStripMenuItem.Text = "保留一位";
            toolStripMenuItems[1] = toolStripMenuItem;
            toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Tag = 2;
            toolStripMenuItem.Text = "保留二位";
            toolStripMenuItems[2] = toolStripMenuItem;
            toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Tag = 3;
            toolStripMenuItem.Text = "保留三位";
            toolStripMenuItems[3] = toolStripMenuItem;
            toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Tag = 4;
            toolStripMenuItem.Text = "保留四位";
            toolStripMenuItems[4] = toolStripMenuItem;
            for (int i = 0; i < toolStripMenuItems.Length; i++)
            {
                DropDownItems.Add(toolStripMenuItems[i]);
            }
        }

        protected override void OnDropDownItemClicked(ToolStripItemClickedEventArgs e)
        {
            if (fpSpreadForHeaderSetting.ReportColumnSelected != null)
            {
                if (fpSpreadForHeaderSetting.ReportColumnSelected.DecimalPlace != (int)e.ClickedItem.Tag)
                {
                    fpSpreadForHeaderSetting.ReportColumnSelected.DecimalPlace = (int)e.ClickedItem.Tag;
                    fpSpreadForHeaderSetting.ManualChange(HeaderSettingFpSpreadChangedType.DecimalPlaceChanged);
                    fpSpreadForHeaderSetting.ManualHeaderSettingCommandStatusChanged();
                }
            }
            base.OnDropDownItemClicked(e);
        }

        #region IHeaderSettingToolStripItem 成员

        public void SetCommandStatus(HeaderSettingCommandStatus commandStatus)
        {
            if (commandStatus == HeaderSettingCommandStatus.SelectReportColumn)
            {
                Visible = true;
                if (fpSpreadForHeaderSetting.ReportColumnSelected != null&&fpSpreadForHeaderSetting.ReportColumnSelected.IsNumber)
                {
                    Enabled = true;

                    for (int i = 0; i < toolStripMenuItems.Length; i++)
                    {
                        if (((int)toolStripMenuItems[i].Tag) == fpSpreadForHeaderSetting.ReportColumnSelected.DecimalPlace)
                        {
                            toolStripMenuItems[i].Checked = true;
                        }
                        else
                        {
                            toolStripMenuItems[i].Checked = false;
                        }
                    }
                }
                else
                {
                    Enabled = false;
                }
            }
            else
            {
                Visible = false;
            }
        }

        public FpSpreadForHeaderSetting FpSpread
        {
            get
            {
                return fpSpreadForHeaderSetting;
            }
            set
            {
                fpSpreadForHeaderSetting = value;
            }
        }

        public int SortID
        {
            get
            {
                return 400;
            }
        }

        #endregion
    }
}
