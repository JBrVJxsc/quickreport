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
    internal partial class ToolStripSplitButtonValueTranslateType : ToolStripSplitButtonPlus, IReportColumnSettingToolStripItem
    {
        public ToolStripSplitButtonValueTranslateType()
        {
            InitializeComponent();
            InitDropDownItems();
        }

        private Column column;
        private ToolStripMenuItem[] toolStripMenuItems;
        private bool isVisible = true;

        private void InitDropDownItems()
        {
            toolStripMenuItems = new ToolStripMenuItem[3];
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Tag = ValueTranslateType.BeNullWhenZero;
            toolStripMenuItem.Text = "ֵΪ��ʱת��Ϊ��";
            toolStripMenuItems[0] = toolStripMenuItem;
            toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Tag = ValueTranslateType.BeZeroWhenNull;
            toolStripMenuItem.Text = "ֵΪ��ʱת��Ϊ��";
            toolStripMenuItems[1] = toolStripMenuItem;
            toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Tag = ValueTranslateType.DoNothing;
            toolStripMenuItem.Text = "��ת��";
            toolStripMenuItems[2] = toolStripMenuItem;
            for (int i = 0; i < toolStripMenuItems.Length; i++)
            {
                DropDownItems.Add(toolStripMenuItems[i]);
            }
        }

        protected override void OnDropDownItemClicked(ToolStripItemClickedEventArgs e)
        {
            if (Column != null)
            {
                if (Column.ValueTranslateType != (ValueTranslateType)e.ClickedItem.Tag)
                {
                    Column.ValueTranslateType = (ValueTranslateType)e.ClickedItem.Tag;
                    if (HeaderSettingFpSpreadChanged != null)
                    {
                        HeaderSettingFpSpreadChanged(this, HeaderSettingFpSpreadChangedType.ReportColumnValueTranslateTypeChanged);
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

        #region IReportColumnSettingToolStripItem ��Ա

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
                        if ((ValueTranslateType)toolStripMenuItems[i].Tag == column.ValueTranslateType)
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
                return 180;
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
