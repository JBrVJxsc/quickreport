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
    internal partial class ToolStripSplitButtonValueTranslateType : ToolStripSplitButtonPlus, IHeaderSettingToolStripItem
    {
        public ToolStripSplitButtonValueTranslateType()
        {
            InitializeComponent();
            InitDropDownItems();
            Visible = false;
        }

        private ToolStripMenuItem[] toolStripMenuItems;
        private FpSpreadForHeaderSetting fpSpreadForHeaderSetting;

        private void InitDropDownItems()
        {
            toolStripMenuItems = new ToolStripMenuItem[3];
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Tag = ValueTranslateType.BeNullWhenZero;
            toolStripMenuItem.Text = "值为零时转换为空";
            toolStripMenuItems[0] = toolStripMenuItem;
            toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Tag = ValueTranslateType.BeZeroWhenNull;
            toolStripMenuItem.Text = "值为空时转换为零";
            toolStripMenuItems[1] = toolStripMenuItem;
            toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Tag = ValueTranslateType.DoNothing;
            toolStripMenuItem.Text = "不转换";
            toolStripMenuItems[2] = toolStripMenuItem;
            for (int i = 0; i < toolStripMenuItems.Length; i++)
            {
                DropDownItems.Add(toolStripMenuItems[i]);
            }
        }

        protected override void OnDropDownItemClicked(ToolStripItemClickedEventArgs e)
        {
            if (fpSpreadForHeaderSetting.ReportColumnSelected != null)
            {
                if (fpSpreadForHeaderSetting.ReportColumnSelected.ValueTranslateType != (ValueTranslateType)e.ClickedItem.Tag)
                {
                    fpSpreadForHeaderSetting.ReportColumnSelected.ValueTranslateType = (ValueTranslateType)e.ClickedItem.Tag;
                    fpSpreadForHeaderSetting.ManualChange(HeaderSettingFpSpreadChangedType.ValueTranslateTypeChanged);
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
                if (fpSpreadForHeaderSetting.ReportColumnSelected != null && fpSpreadForHeaderSetting.ReportColumnSelected.IsNumber)
                {
                    Enabled = true;

                    for (int i = 0; i < toolStripMenuItems.Length; i++)
                    {
                        if (((ValueTranslateType)toolStripMenuItems[i].Tag) == fpSpreadForHeaderSetting.ReportColumnSelected.ValueTranslateType)
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
                return 390;
            }
        }

        #endregion
    }
}
