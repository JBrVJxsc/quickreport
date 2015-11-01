using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;

namespace QuickReportCore.Controls
{
    internal partial class ucReportConditionList : UserControl
    {
        public ucReportConditionList()
        {
            InitializeComponent();
        }

        private Objects.Condition[] conditions;
        private ucReportCondition[] ucShouldShowList;
        private Hashtable conditionValueProvidor = new Hashtable();
        private int topM = 0;
        private int eatchMH = 5;
        private int leftM = 5;
        private int rightM = 5;
        private Hashtable htPanels = new Hashtable();

        public ArrayList LoadConditionList(Objects.Condition[] cs)
        {
            List<Interfaces.INeedTranslatedValue> iNeedTranslatedValueList=new List<QuickReportCore.Interfaces.INeedTranslatedValue>();
            List<Interfaces.INeedQuery> iNeedQueryList = new List<QuickReportCore.Interfaces.INeedQuery>();
            conditions = cs;
            ucShouldShowList = new ucReportCondition[conditions.Length];
            conditionValueProvidor = new Hashtable();
            for (int i = 0; i < conditions.Length; i++)
            {
                Objects.Condition c = conditions[i];
                ucReportCondition uc = new ucReportCondition();
                uc.EnterCondition += new ucReportCondition.EnterConditionHandle(uc_EnterCondition);
                uc.Condition = c;
                uc.TabIndex = i;
                if (uc.EditControl is QuickReportCore.Interfaces.INeedTranslatedValue)
                    iNeedTranslatedValueList.Add(uc.EditControl as QuickReportCore.Interfaces.INeedTranslatedValue);
                if (uc.EditControl is QuickReportCore.Interfaces.INeedQuery)
                    iNeedQueryList.Add(uc.EditControl as QuickReportCore.Interfaces.INeedQuery);
                ucShouldShowList[i] = uc;
                conditionValueProvidor.Add(Managers.Functions.GetSQLCode(c.ID, QuickReportCore.Managers.Functions.SQLCodeType.Condition), uc);
            }
            ArrayList al = new ArrayList();
            al.Add(iNeedTranslatedValueList);
            al.Add(iNeedQueryList);
            return al;
        }

        void uc_EnterCondition(int pageIndex)
        {
            vScrollBar.Value = pageIndex * 10;
        }

        /// <summary>
        /// 将含有条件系统变量的Text进行转换。
        /// </summary>
        /// <param name="text">需要转换的Text。</param>
        /// <returns>转换后的Text。</returns>
        public string TranslateTextWithConditionValue(string text)
        {
            string s = text;
            foreach (DictionaryEntry de in conditionValueProvidor)
            {
                s = s.Replace(de.Key.ToString(), ((ucReportCondition)de.Value).Value);
            }
            return s;
        }

        /// <summary>
        /// 清空界面上的条件。
        /// </summary>
        public void ClearConditions()
        {
            conditions = null;
            ucShouldShowList = null;
            pnlOfPnl.Controls.Clear();
        }

        public void ShowConditions()
        {
            if (ucShouldShowList == null)
                return;
            int widthUsed = 0;
            int pageIndex = 0;
            htPanels = new Hashtable();
            pnlOfPnl.Controls.Clear();
            Panel p = new Panel();
            pnlOfPnl.Controls.Add(p);
            p.Dock = DockStyle.Fill;
            htPanels.Add(pageIndex, p);
            int totalWidth = p.Width;

            for (int i = 0; i < ucShouldShowList.Length; i++)
            {
                ucReportCondition uc = ucShouldShowList[i];
                if (uc == null)
                    goto End;
                uc.ShowAndOrState = true;
                if (i == ucShouldShowList.Length - 1)
                    uc.ShowAndOrState = false;

                if (widthUsed == 0)
                {
                    ((Panel)htPanels[pageIndex]).Controls.Add(uc);
                    int x = leftM;
                    int y = topM;
                    if (uc.Location != new Point(x, y))
                        uc.Location = new Point(x, y);
                    widthUsed = x + uc.Width;
                    uc.PageIndex = pageIndex;
                    continue;
                }
                else
                {
                    if (uc.Width + widthUsed + eatchMH < totalWidth - rightM)
                    {
                        ((Panel)htPanels[pageIndex]).Controls.Add(uc);
                        int x = widthUsed + eatchMH;
                        int y = topM;
                        if (uc.Location != new Point(x, y))
                            uc.Location = new Point(x, y);
                        widthUsed = x + uc.Width;
                        uc.PageIndex = pageIndex;
                    }
                    else
                    {
                        pageIndex++;
                        Panel panel = new Panel();
                        pnlOfPnl.Controls.Add(panel);
                        panel.Dock = DockStyle.Fill;
                        htPanels.Add(pageIndex, panel);
                        ((Panel)htPanels[pageIndex]).Controls.Add(uc);
                        int x = leftM;
                        int y = topM;
                        if (uc.Location != new Point(x, y))
                            uc.Location = new Point(x, y);
                        widthUsed = x + uc.Width;
                        uc.PageIndex = pageIndex;
                    }
                }
            }
        End:
            for (int i = htPanels.Count - 1; i >= 0; i--)
            {
                ((Panel)htPanels[i]).BringToFront();
            }
            if (htPanels.Count <= 1)
            {
                vScrollBar.Visible = false;
            }
            else
            {
                vScrollBar.Maximum = htPanels.Count * 10;
                vScrollBar.Value = 0;
                vScrollBar.Visible = true;
            }
        }

        int showTimes = 0;
        private void ucReportConditionListNew_SizeChanged(object sender, EventArgs e)
        {
            if (showTimes == 5)
            {
                ShowConditions();
            }
            showTimes++;
        }

        public int CheckInput()
        {
            if (ucShouldShowList == null)
                return 1;
            for (int i = 0; i < ucShouldShowList.Length; i++)
            {
                if (ucShouldShowList[i] == null)
                    return 1;
                if (ucShouldShowList[i].CheckInput() < 0)
                {
                    string s = string.Empty;
                    if (ucShouldShowList[i].EditControl is TextBox)
                        s = "请输入";
                    else
                        s = "请选择";
                    vScrollBar.Value = ucShouldShowList[i].PageIndex * 10;
                    Managers.Functions.ShowToolTip(ucShouldShowList[i], s + ucShouldShowList[i].ToString() + "。", 3000);
                    ucShouldShowList[i].SetEditControlFocus();
                    return -1;
                }
            }
            return 1;
        }

        private void vScrollBar_ValueChanged(object sender, EventArgs e)
        {
            Panel p = htPanels[vScrollBar.Value / 10] as Panel;
            if(p!=null)
                p.BringToFront();
        }

        private void ucReportConditionList_Load(object sender, EventArgs e)
        {
            MouseWheel += new MouseEventHandler(ucReportConditionList_MouseWheel);
        }

        void ucReportConditionList_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (vScrollBar.Value - 10 >= vScrollBar.Minimum)
                    vScrollBar.Value -= 10;
            }
            else
            {
                if (vScrollBar.Value + 10 < vScrollBar.Maximum)
                    vScrollBar.Value += 10;
            }
        }

        public string FullConditionString
        {
            get
            {
                if (ucShouldShowList == null)
                    return string.Empty;
                string s = string.Empty;
                for (int i = 0; i < ucShouldShowList.Length; i++)
                    s += ucShouldShowList[i].FullConditionString;
                return s;
            }
        }
    }
}
