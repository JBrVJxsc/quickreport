using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Enums;
using QuickReportLib.Objects;
using QuickReportLib.Interfaces.ReportSetting.HeaderSetting;

namespace QuickReportLib.Controls.Plus.ReportColumnPropertyEditor
{
    internal partial class ToolStripSplitButtonDecimalPlace : ToolStripSplitButtonPlus, IReportColumnSettingToolStripItem
    {
        public ToolStripSplitButtonDecimalPlace()
        {
            InitializeComponent();
            InitDropDownItems();
        }

        private Column column;
        private ToolStripMenuItem[] toolStripMenuItems;
        private bool isVisible = true;

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
            if (Column != null)
            {
                if (Column.DecimalPlace != (int)e.ClickedItem.Tag)
                {
                    Column.DecimalPlace = (int)e.ClickedItem.Tag;
                    if (HeaderSettingFpSpreadChanged != null)
                    {
                        HeaderSettingFpSpreadChanged(this, HeaderSettingFpSpreadChangedType.ReportColumnDecimalPlaceChanged);
                    }
                    for (int i = 0; i < toolStripMenuItems.Length; i++)
                    {
                        toolStripMenuItems[i].Checked = false;
                    }
                    (e.ClickedItem as ToolStripMenuItem).Checked = true;
                }
            }
            base.OnDropDownItemClicked(e);
        }

        #region IReportColumnSettingToolStripItem 成员

        public event HeaderSettingFpSpreadChangedHandle HeaderSettingFpSpreadChanged;

        public Column Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
                if (column.IsNumber)
                {
                    Visible = true;
                    isVisible = true;
                    for (int i = 0; i < toolStripMenuItems.Length; i++)
                    {
                        if ((int)toolStripMenuItems[i].Tag == column.DecimalPlace)
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
                    Visible = false;
                    isVisible = false;
                }
            }
        }

        public int SortID
        {
            get
            {
                return 190;
            }
        }

        public bool IsVisible
        {
            get
            {
                return isVisible;
            }
            set
            {
                isVisible = value;
            }
        }

        #endregion
    }
}
