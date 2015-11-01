using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore.Forms
{
    internal partial class frmFilter : Form
    {
        public frmFilter()
        {
            InitializeComponent();
            txtFilter.MouseWheel += new MouseEventHandler(txtFilter_MouseWheel);
            FarPoint.Win.Spread.InputMap im = fpFilter.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        }

        void txtFilter_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta>0)
                ProcessKeyDown(Keys.Up);
            else
                ProcessKeyDown(Keys.Down);
        }

        public delegate void SelectItemHandle(string item);
        public event SelectItemHandle SelectItem;

        public int InitFilter(DataSet ds)
        {
            DataSet = ds;
            if (DataSet == null || DataSet.Tables==null||DataSet.Tables.Count==0)
                return -1;
            DataView =new DataView(DataSet.Tables[0]);
            GetFilterString();
            return 1;
        }

        private DataSet dataset;
        public DataSet DataSet
        {
            get
            {
                return dataset;
            }
            set
            {
                dataset = value;
            }
        }

        private DataView dataview;
        public DataView DataView
        {
            get
            {
                return dataview;
            }
            set
            {
                dataview = value;
                fpFilter_Sheet1.DataSource = dataview;
                SetFpFormat();
            }
        }

        private string filterString = string.Empty;
        public string FilterString
        {
            get
            {
                if (txtFilter.Text == string.Empty)
                    return string.Empty;
                return string.Format(filterString,txtFilter.Text);
            }
            set
            {
                filterString = value;
            }
        }

        private void GetFilterString()
        {
            string s = string.Empty;
            foreach (System.Data.DataColumn column in DataSet.Tables[0].Columns)
            {
                s += column.ColumnName + " LIKE '%{0}%' OR ";
            }
            s=s.Remove(s.LastIndexOf("OR"));
            FilterString = s;
        }

        private void SetFpFormat()
        {
            fpFilter.SuspendLayout();
            fpFilter_Sheet1.Columns[fpFilter_Sheet1.Columns.Count - 1].Visible = false;
            fpFilter_Sheet1.Columns[fpFilter_Sheet1.Columns.Count - 2].Visible = false;
            for (int i = 0; i < fpFilter_Sheet1.Columns.Count - 2; i++)
            {
                fpFilter_Sheet1.Columns[i].Locked = true;
                fpFilter_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }
            fpFilter_Sheet1.ColumnHeader.Rows[0].Height = fpFilter_Sheet1.ColumnHeader.Rows[0].GetPreferredHeight();
            if (fpFilter_Sheet1.Columns.Count == 3)
            {
                fpFilter_Sheet1.Columns[0].Width = fpFilter.Width - 25;
            }
            else
            {
                fpFilter_Sheet1.Columns[0].Width = 130;
                fpFilter_Sheet1.Columns[1].Width = fpFilter.Width - 25 - 130;
            }
            if (fpFilter_Sheet1.Rows.Count > 0)
                SetActiveCell(fpFilter,fpFilter_Sheet1, 0, 0);
            fpFilter.ResumeLayout();
        }

        private void ProcessKeyDown(Keys keyCode)
        {
            if (keyCode == Keys.Escape)
                Close();
            if (keyCode == Keys.Up && fpFilter_Sheet1.ActiveRowIndex > 0)
            {
                if(fpFilter_Sheet1.ActiveRow==null||fpFilter_Sheet1.ActiveRow.Index==0)
                    return;
                SetActiveCell(fpFilter,fpFilter_Sheet1, fpFilter_Sheet1.ActiveRowIndex - 1, 0);
            }
            else if (keyCode == Keys.Down && fpFilter_Sheet1.ActiveRowIndex < fpFilter_Sheet1.Rows.Count - 1)
            {
                if (fpFilter_Sheet1.ActiveRow == null || fpFilter_Sheet1.ActiveRow.Index == fpFilter_Sheet1.Rows.Count-1)
                    return;
                SetActiveCell(fpFilter,fpFilter_Sheet1, fpFilter_Sheet1.ActiveRowIndex + 1, 0);
            }
            else if (keyCode == Keys.Enter)
                SeletctItem();
        }

        private void SeletctItem()
        {
            if (fpFilter_Sheet1.Rows.Count > 0)
            {
                if (fpFilter_Sheet1.ActiveRowIndex >= 0)
                {
                    if (SelectItem == null)
                        return;
                    if (fpFilter_Sheet1.Columns.Count == 3)
                        SelectItem(fpFilter_Sheet1.Cells[fpFilter_Sheet1.ActiveRowIndex, 0].Text);
                    else
                        SelectItem(fpFilter_Sheet1.Cells[fpFilter_Sheet1.ActiveRowIndex, 1].Text);
                    Close();
                }
            }
        }

        private void SetActiveCell(FarPoint.Win.Spread.FpSpread spread, FarPoint.Win.Spread.SheetView sheet, int row,int column)
        {
            if (sheet.RowCount == 0 || sheet.Cells[row, column] == null)
                return;
            if (sheet.ActiveRow != null)
            {
                sheet.ActiveRow.BackColor = Color.White;
            }
            sheet.Rows[row].BackColor = QuickReportCore.Controls.ucConditionObject.ObjectActivateColor;
            sheet.SetActiveCell(row, column);
            spread.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Nearest, FarPoint.Win.Spread.HorizontalPosition.Nearest);
        }

        private void fpFilter_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
                return;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (DataView == null)
                return;
            try
            {
                DataView.RowFilter = FilterString;
            }
            catch
            { 
                
            }
            SetFpFormat();
        }

        private void frmFilter_Activated(object sender, EventArgs e)
        {
            txtFilter.Focus();
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                return;
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
            }
            ProcessKeyDown(e.KeyCode);
        }

        private void fp_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.Rows[e.Row].BackColor = QuickReportCore.Controls.ucConditionObject.ObjectActivateColor;
        }

        private void fp_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.Rows[e.Row].BackColor = Color.White;
        }

        private void fpFilter_CellDoubleClick_1(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
            {
                e.Cancel = true;
                return;
            }
            SeletctItem();
        }

        private void fpFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SeletctItem();
            else if (e.KeyCode == Keys.Escape)
                Close();
            else if (e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
                txtFilter.Focus();
                txtFilter.Select(txtFilter.Text.Length, 0);
                SendKeys.Send("{Backspace}");
            }
            else if (e.KeyCode == Keys.Tab)
            {
                txtFilter.Focus();
                txtFilter.Select(txtFilter.Text.Length, 0);
            }
        }

        private void txtFilter_MouseDown(object sender, MouseEventArgs e)
        {
            if (!txtFilter.Focused)
                return;
            if (e.Button == MouseButtons.Middle)
                ProcessKeyDown(Keys.Enter);
        }

        private void fpFilter_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}