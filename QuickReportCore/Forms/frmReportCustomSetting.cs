using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace QuickReportCore.Forms
{
    internal partial class frmReportCustomSetting : Form
    {
        public frmReportCustomSetting()
        {
            InitializeComponent();
            tabControl.TabPages.Remove(tabPagePrint);
        }

        public delegate void OnSaveHandle(Hashtable htColShows, Hashtable htColUnShows, Hashtable htConShows, Hashtable htConUnShows);
        public event OnSaveHandle OnSave;
        public delegate void OnRefreshHandle(RefreshType refreshType);
        public event OnRefreshHandle OnRefresh;
        private Hashtable htColumnsShows ;
        private Hashtable htConditionsShows ;
        private Hashtable htColumnsUnShows ;
        private Hashtable htConditionsUnShows ;
        private Managers.QuickReportManager quickReportManager = new QuickReportCore.Managers.QuickReportManager();
        private string reportID = string.Empty;
        public string ReportID
        {
            get
            {
                return reportID;
            }
            set
            {
                reportID = value;
            }
        }

        public void LoadCustomSetting(Hashtable htColShows, Hashtable htColUnShows, Hashtable htConShows, Hashtable htConUnShows,string reportID,Controls.Report.ucReportV100.ReportType reportType)
        {
            htColumnsShows = htColShows;
            htColumnsUnShows = htColUnShows;
            htConditionsShows = htConShows;
            htConditionsUnShows = htConUnShows;
            #region 停止绘制。
            fpColumnShows.SuspendLayout();
            fpColumnUnShows.SuspendLayout();
            fpConditionShows.SuspendLayout();
            fpConditionUnShows.SuspendLayout();
            #endregion
            LoadCustomSetting();
            SetFpFormat();
            #region 重启绘制。
            fpColumnShows.ResumeLayout();
            fpColumnUnShows.ResumeLayout();
            fpConditionShows.ResumeLayout();
            fpConditionUnShows.ResumeLayout();
            #endregion
            ReportID = reportID;
            tbShareSetting.Checked = CheckShareSetting();
            #region 如果是普通交叉报表，则移除列设置。
            if (reportType == QuickReportCore.Controls.Report.ucReportV100.ReportType.GeneralCross)
                tabControl.TabPages.Remove(tabPageColumnSetting);
            #endregion
        }

        private void LoadCustomSetting()
        {
            fpColumnShows_Sheet1.RowCount = htColumnsShows.Count;
            foreach (DictionaryEntry de in htColumnsShows)
            {
                fpColumnShows_Sheet1.Cells[((Objects.Column)de.Value).SortId, 0].Value = ((Objects.Column)de.Value).ID;
                fpColumnShows_Sheet1.Rows[((Objects.Column)de.Value).SortId].Height = fpColumnShows_Sheet1.Rows[((Objects.Column)de.Value).SortId].GetPreferredHeight();
            }
            fpColumnUnShows_Sheet1.RowCount = htColumnsUnShows.Count;
            foreach (DictionaryEntry de in htColumnsUnShows)
            {
                fpColumnUnShows_Sheet1.Cells[((Objects.Column)de.Value).SortId, 0].Value = ((Objects.Column)de.Value).ID;
                fpColumnUnShows_Sheet1.Rows[((Objects.Column)de.Value).SortId].Height = fpColumnUnShows_Sheet1.Rows[((Objects.Column)de.Value).SortId].GetPreferredHeight();
            }
            fpConditionShows_Sheet1.RowCount = htConditionsShows.Count;
            foreach (DictionaryEntry de in htConditionsShows)
            {
                fpConditionShows_Sheet1.Cells[((Objects.Condition)de.Value).SortId, 0].Value = ((Objects.Condition)de.Value).ID;
                fpConditionShows_Sheet1.Rows[((Objects.Condition)de.Value).SortId].Height = fpConditionShows_Sheet1.Rows[((Objects.Condition)de.Value).SortId].GetPreferredHeight();
            }
            fpConditionUnShows_Sheet1.RowCount = htConditionsUnShows.Count;
            foreach (DictionaryEntry de in htConditionsUnShows)
            {
                fpConditionUnShows_Sheet1.Cells[((Objects.Condition)de.Value).SortId, 0].Value = ((Objects.Condition)de.Value).ID;
                fpConditionUnShows_Sheet1.Rows[((Objects.Condition)de.Value).SortId].Height = fpConditionUnShows_Sheet1.Rows[((Objects.Condition)de.Value).SortId].GetPreferredHeight();
            }
            SetActiveCell(fpColumnShows,fpColumnShows_Sheet1, 0, 0);
            SetActiveCell(fpColumnUnShows,fpColumnUnShows_Sheet1, 0, 0);
            SetActiveCell(fpConditionShows,fpConditionShows_Sheet1, 0, 0);
            SetActiveCell(fpConditionUnShows,fpConditionUnShows_Sheet1, 0, 0);
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void SetFpFormat()
        {
            fpColumnShows_Sheet1.Columns[0].Width = fpColumnShows.Width - 75;
            fpColumnUnShows_Sheet1.Columns[0].Width = fpColumnUnShows.Width - 75;
            fpConditionShows_Sheet1.Columns[0].Width = fpConditionShows.Width - 75;
            fpConditionUnShows_Sheet1.Columns[0].Width = fpConditionUnShows.Width - 75;
            FarPoint.Win.Spread.InputMap im = fpColumnShows.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im = fpColumnUnShows.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im = fpConditionShows.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im = fpConditionUnShows.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        }

        private void Save()
        {
            Hashtable htColumnsShowsNew = new Hashtable();
            for (int i = 0; i < fpColumnShows_Sheet1.RowCount; i++)
            {
                string id = fpColumnShows_Sheet1.Cells[i, 0].Text;
                Objects.Column c = htColumnsShows[id] as Objects.Column;
                if (c == null)
                    c = htColumnsUnShows[id] as Objects.Column;
                Objects.Column newC = c.Clone();
                newC.SortId = i;
                htColumnsShowsNew.Add(newC.ID, newC);
            }
            Hashtable htColumnsUnShowsNew = new Hashtable();
            for (int i = 0; i < fpColumnUnShows_Sheet1.RowCount; i++)
            {
                string id = fpColumnUnShows_Sheet1.Cells[i, 0].Text;
                Objects.Column c = htColumnsShows[id] as Objects.Column;
                if (c == null)
                    c = htColumnsUnShows[id] as Objects.Column;
                Objects.Column newC = c.Clone();
                newC.SortId = i;
                htColumnsUnShowsNew.Add(newC.ID, newC);
            }
            Hashtable htConditionsShowsNew = new Hashtable();
            for (int i = 0; i < fpConditionShows_Sheet1.RowCount; i++)
            {
                string id = fpConditionShows_Sheet1.Cells[i, 0].Text;
                Objects.Condition c = htConditionsShows[id] as Objects.Condition;
                if (c == null)
                    c = htConditionsUnShows[id] as Objects.Condition;
                Objects.Condition newC = c.Clone();
                newC.SortId = i;
                htConditionsShowsNew.Add(newC.ID, newC);
            }
            Hashtable htConditionsUnShowsNew = new Hashtable();
            for (int i = 0; i < fpConditionUnShows_Sheet1.RowCount; i++)
            {
                string id = fpConditionUnShows_Sheet1.Cells[i, 0].Text;
                Objects.Condition c = htConditionsShows[id] as Objects.Condition;
                if (c == null)
                    c = htConditionsUnShows[id] as Objects.Condition;
                Objects.Condition newC = c.Clone();
                newC.SortId = i;
                htConditionsUnShowsNew.Add(newC.ID, newC);
            }
            if (OnSave != null)
                OnSave(htColumnsShowsNew, htColumnsUnShowsNew, htConditionsShowsNew, htConditionsUnShowsNew);
            Close();
        }

        private void SetActiveCell(FarPoint.Win.Spread.FpSpread spread,FarPoint.Win.Spread.SheetView sheet, int row, int column)
        {
            if (sheet.RowCount==0 || sheet.Cells[row, column] == null)
                return;
            if (sheet.ActiveCell != null)
            {
                sheet.ActiveCell.BackColor = Color.White;
            }
            sheet.Cells[row, column].BackColor = QuickReportCore.Controls.ucConditionObject.ObjectActivateColor;
            sheet.SetActiveCell(row, column);
            spread.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Nearest, FarPoint.Win.Spread.HorizontalPosition.Nearest);
        }

        private void tbColumnUp_Click(object sender, EventArgs e)
        {
            if (fpColumnShows_Sheet1.ActiveCell == null||fpColumnShows_Sheet1.ActiveCell.Row.Index==0)
                return;
            string activeNow = fpColumnShows_Sheet1.ActiveCell.Text;
            fpColumnShows_Sheet1.ActiveCell.Text = fpColumnShows_Sheet1.Cells[fpColumnShows_Sheet1.ActiveRowIndex - 1, 0].Text;
            fpColumnShows_Sheet1.Cells[fpColumnShows_Sheet1.ActiveRowIndex - 1, 0].Value = activeNow;
            SetActiveCell(fpColumnShows,fpColumnShows_Sheet1, fpColumnShows_Sheet1.ActiveRowIndex - 1, 0);
        }

        private void tbColumnDown_Click(object sender, EventArgs e)
        {
            if (fpColumnShows_Sheet1.ActiveCell == null || fpColumnShows_Sheet1.ActiveCell.Row.Index == fpColumnShows_Sheet1.Rows.Count-1)
                return;
            string activeNow = fpColumnShows_Sheet1.ActiveCell.Text;
            fpColumnShows_Sheet1.ActiveCell.Text = fpColumnShows_Sheet1.Cells[fpColumnShows_Sheet1.ActiveRowIndex + 1, 0].Text;
            fpColumnShows_Sheet1.Cells[fpColumnShows_Sheet1.ActiveRowIndex + 1, 0].Value = activeNow;
            SetActiveCell(fpColumnShows,fpColumnShows_Sheet1, fpColumnShows_Sheet1.ActiveRowIndex + 1, 0);
        }

        private void tbConditionUp_Click(object sender, EventArgs e)
        {
            if (fpConditionShows_Sheet1.ActiveCell == null || fpConditionShows_Sheet1.ActiveCell.Row.Index == 0)
                return;
            string activeNow = fpConditionShows_Sheet1.ActiveCell.Text;
            fpConditionShows_Sheet1.ActiveCell.Text = fpConditionShows_Sheet1.Cells[fpConditionShows_Sheet1.ActiveRowIndex - 1, 0].Text;
            fpConditionShows_Sheet1.Cells[fpConditionShows_Sheet1.ActiveRowIndex - 1, 0].Value = activeNow;
            SetActiveCell(fpConditionShows,fpConditionShows_Sheet1, fpConditionShows_Sheet1.ActiveRowIndex - 1, 0);
        }

        private void tbConditionDown_Click(object sender, EventArgs e)
        {
            if (fpConditionShows_Sheet1.ActiveCell == null || fpConditionShows_Sheet1.ActiveCell.Row.Index == fpConditionShows_Sheet1.Rows.Count - 1)
                return;
            string activeNow = fpConditionShows_Sheet1.ActiveCell.Text;
            fpConditionShows_Sheet1.ActiveCell.Text = fpConditionShows_Sheet1.Cells[fpConditionShows_Sheet1.ActiveRowIndex + 1, 0].Text;
            fpConditionShows_Sheet1.Cells[fpConditionShows_Sheet1.ActiveRowIndex + 1, 0].Value = activeNow;
            SetActiveCell(fpConditionShows,fpConditionShows_Sheet1, fpConditionShows_Sheet1.ActiveRowIndex + 1, 0);
        }

        private void AddRow(FarPoint.Win.Spread.FpSpread spread,FarPoint.Win.Spread.SheetView sheet, string text)
        {
            sheet.RowCount++;
            sheet.Cells[sheet.RowCount - 1, 0].Value = text;
            sheet.Rows[sheet.RowCount - 1].Height = sheet.Rows[sheet.RowCount - 1].GetPreferredHeight();
            SetActiveCell(spread,sheet, sheet.RowCount - 1, 0);
        }

        private void fpColumnShows_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
            {
                e.Cancel = true;
                return;
            }
            AddRow(fpColumnUnShows,fpColumnUnShows_Sheet1, fpColumnShows_Sheet1.ActiveCell.Text);
            fpColumnShows_Sheet1.Rows.Remove(fpColumnShows_Sheet1.ActiveRowIndex, 1);
            SetActiveCell(fpColumnShows,fpColumnShows_Sheet1, fpColumnShows_Sheet1.ActiveRowIndex, fpColumnShows_Sheet1.ActiveColumnIndex);
        }

        private void fpColumnUnShows_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
            {
                e.Cancel = true;
                return;
            }
            AddRow(fpColumnShows,fpColumnShows_Sheet1, fpColumnUnShows_Sheet1.ActiveCell.Text);
            fpColumnUnShows_Sheet1.Rows.Remove(fpColumnUnShows_Sheet1.ActiveRowIndex, 1);
            SetActiveCell(fpColumnUnShows,fpColumnUnShows_Sheet1, fpColumnUnShows_Sheet1.ActiveRowIndex, fpColumnUnShows_Sheet1.ActiveColumnIndex);
        }

        private void fpConditionShows_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
            {
                e.Cancel = true;
                return;
            }
            AddRow(fpConditionUnShows,fpConditionUnShows_Sheet1, fpConditionShows_Sheet1.ActiveCell.Text);
            fpConditionShows_Sheet1.Rows.Remove(fpConditionShows_Sheet1.ActiveRowIndex, 1);
            SetActiveCell(fpConditionShows,fpConditionShows_Sheet1, fpConditionShows_Sheet1.ActiveRowIndex, fpConditionShows_Sheet1.ActiveColumnIndex);
        }

        private void fpConditionUnShows_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
            {
                e.Cancel = true;
                return;
            }
            AddRow(fpConditionShows,fpConditionShows_Sheet1, fpConditionUnShows_Sheet1.ActiveCell.Text);
            fpConditionUnShows_Sheet1.Rows.Remove(fpConditionUnShows_Sheet1.ActiveRowIndex, 1);
            SetActiveCell(fpConditionUnShows,fpConditionUnShows_Sheet1, fpConditionUnShows_Sheet1.ActiveRowIndex, fpConditionUnShows_Sheet1.ActiveColumnIndex);
        }

        public enum RefreshType
        { 
            Column,
            Condition,
            Print
        }

        private void tbRefreshColumn_Click(object sender, EventArgs e)
        {
            if (OnRefresh == null)
                return;
            DialogResult dr = MessageBox.Show("确实要重置列吗？","提示",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr != DialogResult.OK)
                return;
            OnRefresh(RefreshType.Column);
            Close();
        }

        private void tbRefreshCondition_Click(object sender, EventArgs e)
        {
            if (OnRefresh == null)
                return;
            DialogResult dr = MessageBox.Show("确实要重置条件吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr != DialogResult.OK)
                return;
            OnRefresh(RefreshType.Condition);
            Close();
        }

        private void fp_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
            {
                e.Cancel = true;
                return;
            }
            FarPoint.Win.Spread.FpSpread fp=sender as  FarPoint.Win.Spread.FpSpread ;
            SetActiveCell(fp, fp.ActiveSheet, e.Row, 0);
        }

        private void tbShareSetting_Click(object sender, EventArgs e)
        {
            ShareSetting();
        }

        private void ShareSetting()
        {
            if (!tbShareSetting.Checked)//非Checked状态下点击共享，意为用户想共享自己的设置。
            {
                string name = quickReportManager.QuerySharedSettingExist(ReportID);
                if (name == null)
                {
                    Neusoft.NFC.Management.PublicTrans.BeginTransaction();
                    int i = quickReportManager.UpdateSharedSettingFlagByOperCodeAndReportID(quickReportManager.Operator.ID, ReportID, "1");
                    if (i < 0)
                    {
                        Neusoft.NFC.Management.PublicTrans.RollBack();
                        Managers.Functions.ShowToolTip(tabControl, "共享失败。" + quickReportManager.Err, toolStripMain.Location);
                    }
                    else
                    {
                        tbShareSetting.Checked = true;
                        Neusoft.NFC.Management.PublicTrans.Commit();
                        Managers.Functions.ShowToolTip(tabControl, "共享成功。", toolStripMain.Location);
                    }
                }
                else
                {
                    Managers.Functions.ShowToolTip(tabControl, name + "已经共享了设置。", toolStripMain.Location);
                }
            }
            else
            {
                Neusoft.NFC.Management.PublicTrans.BeginTransaction();
                int i = quickReportManager.UpdateSharedSettingFlagByOperCodeAndReportID(quickReportManager.Operator.ID, ReportID, "0");
                if (i < 0)
                {
                    Neusoft.NFC.Management.PublicTrans.RollBack();
                    Managers.Functions.ShowToolTip(tabControl, "取消共享失败。" + quickReportManager.Err, toolStripMain.Location);
                }
                else
                {
                    tbShareSetting.Checked = false;
                    Neusoft.NFC.Management.PublicTrans.Commit();
                    Managers.Functions.ShowToolTip(tabControl, "取消共享成功。", toolStripMain.Location);
                }
            }
        }

        /// <summary>
        /// 检查本人本报表是否共享设置。
        /// </summary>
        /// <returns>true为有；false为无。</returns>
        private bool CheckShareSetting()
        {
            string name = quickReportManager.QuerySharedSettingExist(quickReportManager.Operator.ID, ReportID);
            if (name != null)
                return true;
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Objects.Setting.PrintSetting.ShowSetting();
        }
    }
}