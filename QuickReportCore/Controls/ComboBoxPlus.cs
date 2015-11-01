using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore.Controls
{
    internal partial class ComboBoxPlus : ComboBox
    {
        private const int WM_LBUTTONDOWN = 0x201, WM_LBUTTONDBLCLK = 0x203;

        public ComboBoxPlus()
        {
            InitializeComponent();
            Init();
        }

        public delegate void SelectedItemChangedHandle(object sender, object item);
        public event SelectedItemChangedHandle SelectedItemChanged;

        public delegate void ClickPlusHandle(object sender);
        public event ClickPlusHandle ClickPlus;

        private bool writeProtect = false;
        private bool showState = false;

        public void ShowContextMenuStrip(bool b)
        {
            if (b)
            {
                contextMenuStrip.Show(this, 0, Height);
                showState = true;
            }
            else
            {
                contextMenuStrip.Close();
            }
        }

        private void Init()
        {
            contextMenuStrip.Closed += new ToolStripDropDownClosedEventHandler(contextMenuStrip_Closed);
        }

        void contextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            showState = false;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN || m.Msg == WM_LBUTTONDBLCLK)
            {
                if (showState)
                {
                    ShowContextMenuStrip(false);
                    if (ClickPlus != null)
                        ClickPlus(this);
                    return;
                }
                if (!showState)
                    ShowContextMenuStrip(true);
                if (ClickPlus != null)
                    ClickPlus(this);
                return;
            }
            base.WndProc(ref m);
        }

        private void ComboBoxPlus_MouseEnter(object sender, EventArgs e)
        {
            contextMenuStrip.AutoClose = false;
        }

        private void ComboBoxPlus_MouseLeave(object sender, EventArgs e)
        {
            contextMenuStrip.AutoClose = true;
            if (!contextMenuStrip.Focused)
            {
                contextMenuStrip.Focus();
            }
        }

        public void Clear()
        {
            contextMenuStrip.Items.Clear();
            Items.Clear();
        }

        public void Collapse()
        {
            contextMenuStrip.Close();
        }

        /// <summary>
        /// ������ȡItem��
        /// </summary>
        /// <param name="indexs">Item���ڵļ���š������һ���˵�����A��B��C��C�а���D��E��D�а���F��������ȡ��F�����������"2,0,0"��</param>
        /// <returns>Item��</returns>
        public object GetItemByIndexs(params int[] indexs)
        {
            return GetItem(indexs).Tag;
        }

        public object GetItemByText(string text)
        {
            return GetItem(text).Tag;
        }

        /// <summary>
        /// ������ȡItem��
        /// </summary>
        /// <param name="indexs">Item���ڵļ���š������һ���˵�����A��B��C��C�а���D��E��D�а���F��������ȡ��F�����������"2,0,0"��</param>
        /// <returns>Item��</returns>
        private ToolStripMenuItem GetItem(params int[] indexs)
        {
            ToolStripMenuItem firstItem = contextMenuStrip.Items[indexs[0]] as ToolStripMenuItem;
            for (int i = 1; i < indexs.Length; i++)
            {
                firstItem = GetItem(firstItem, indexs[i]);
            }
            return firstItem;
        }

        private ToolStripMenuItem GetItem(ToolStripMenuItem item, int index)
        {
            if (item.HasDropDownItems && item.DropDownItems.Count > index)
            {
                return item.DropDownItems[index] as ToolStripMenuItem;
            }
            return null;
        }

        /// <summary>
        /// ����ѡ��Item��
        /// </summary>
        /// <param name="indexs">Item���ڵļ���š������һ���˵�����A��B��C��C�а���D��E��D�а���F��������ȡ��F�����������"2,0,0"��</param>
        public void SelectItem(params int[] indexs)
        {
            ToolStripMenuItem item = GetItem(indexs);
            writeProtect = true;
            Text = item.Text;
            writeProtect = false;
            SelectedItem = item.Tag;
            if (SelectedItemChanged != null)
                SelectedItemChanged(this, item.Tag);
        }

        /// <summary>
        /// ��Textѡ��Item��
        /// </summary>
        /// <param name="text">Item��Text��</param>
        public void SelectItem(string text)
        {
            ToolStripMenuItem item = GetItem(text);
            writeProtect = true;
            Text = item.Text;
            writeProtect = false;
            SelectedItem = item.Tag;
            if (SelectedItemChanged != null)
                SelectedItemChanged(this, item.Tag);
        }

        /// <summary>
        /// ���һ���ָ��ߡ�
        /// </summary>
        public void AddSeparator()
        {
            contextMenuStrip.Items.Add(new System.Windows.Forms.ToolStripSeparator());
        }

        /// <summary>
        /// ���һ���ָ�����һ��Ԫ��֮�ڡ�
        /// </summary>
        /// <param name="indexs">Ԫ�����ڵļ���š������һ���˵�����A��B��C��C�а���D��E��D�а���F�������������F�����������"2,0,0"��</param>
        public void AddSeparator(params int[] indexs)
        {
            ToolStripMenuItem temp = GetItem(indexs);
            if (temp == null)
                return;
            temp.DropDownItems.Add(new System.Windows.Forms.ToolStripSeparator());
        }

        /// <summary>
        /// ���һ��Ԫ�ء�
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(object item)
        {
            contextMenuStrip.Items.Add(NewToolStripMenuItem(item));
            Items.Add(item);
        }

        /// <summary>
        /// ���һ����Ԫ����һ����Ԫ��֮�ڡ�
        /// </summary>
        /// <param name="item">��Ԫ�ء�</param>
        /// <param name="indexs">��Ԫ�����ڵļ���š������һ���˵�����A��B��C��C�а���D��E��D�а���F�������������F�����������"2,0,0"��</param>
        public void AddItem(object item, params int[] indexs)
        {
            ToolStripMenuItem temp = GetItem(indexs);
            if (temp == null)
                return;
            temp.DropDownItems.Add(NewToolStripMenuItem(item));
            Items.Add(item);
        }

        private ToolStripMenuItem GetItem(string text)
        {
            ToolStripMenuItem found = null;
            foreach (ToolStripItem item in contextMenuStrip.Items)
            {
                if (item.GetType() != typeof(ToolStripMenuItem))
                    continue;
                found = GetItem(item as ToolStripMenuItem, text);
                if (found != null)
                    return found;
            }
            return null;
        }

        private ToolStripMenuItem GetItem(ToolStripMenuItem item, string text)
        {
            if (item.Text == text && !item.HasDropDownItems)
                return item;
            if (item.HasDropDownItems)
            {
                foreach (ToolStripItem temp in item.DropDownItems)
                {
                    if (item.GetType() != typeof(ToolStripMenuItem))
                        continue;
                    if (temp.Text == text && !((ToolStripMenuItem)temp).HasDropDownItems)
                        return temp as ToolStripMenuItem;
                    if (((ToolStripMenuItem)temp).HasDropDownItems)
                        return GetItem(temp as ToolStripMenuItem, text);
                }
            }
            return null;
        }

        private ToolStripMenuItem NewToolStripMenuItem(object item)
        {
            ToolStripMenuItem temp = new ToolStripMenuItem();
            temp.Click += new EventHandler(temp_Click);
            temp.Tag = item;
            temp.Text = item.ToString();
            return temp;
        }

        void temp_Click(object sender, EventArgs e)
        {
            if (!((ToolStripMenuItem)sender).HasDropDownItems)
            {
                writeProtect = true;
                Text = ((ToolStripMenuItem)sender).Text;
                writeProtect = false;
                SelectedItem = ((ToolStripMenuItem)sender).Tag;
                if (SelectedItemChanged != null)
                    SelectedItemChanged(this, ((ToolStripMenuItem)sender).Tag);
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                if (writeProtect)
                    return;
                ToolStripMenuItem item = GetItem(value);
                if (item == null)
                    return;
                SelectedItem = item.Tag;
                if (SelectedItemChanged != null)
                    SelectedItemChanged(this, item.Tag);
            }
        }
    }
}
