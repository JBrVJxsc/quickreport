using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using QuickReportLib.Forms;

namespace QuickReportLib.Controls.Forms
{
    internal partial class SelectorForm : BaseForm
    {
        public SelectorForm()
        {
            InitializeComponent();
            InputMap im = fpSelector.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Escape, Keys.None), SpreadActions.None);
        }

        private Size normalSize = new Size(455, 247);
        private TextCellType textCellType = new TextCellType();
        private bool hideOutColumn = true;
        private string outColumn = string.Empty;
        private Control parentControl;
        private DataSet dataset;
        private DataView dataview;
        private string title = string.Empty;

        /// <summary>
        /// SelectorForm��ѡ����Ŀ�����������¼���
        /// </summary>
        public event SelectItemHandle SelectItem;

        void control_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                ProcessKeyDown(Keys.Up);
            }
            else
            {
                ProcessKeyDown(Keys.Down);
            }
        }

        /// <summary>
        /// �Ƿ���������С�
        /// </summary>
        public bool HideOutColumn
        {
            get
            {
                return hideOutColumn;
            }
            set
            {
                hideOutColumn = value;
            }
        }

        /// <summary>
        /// �����С�
        /// </summary>
        public string OutColumn
        {
            get
            {
                return outColumn;
            }
            set
            {
                outColumn = value;
            }
        }

        /// <summary>
        /// �������ĸ��ؼ���
        /// </summary>
        public Control ParentControl
        {
            get
            {
                return parentControl;
            }
            set
            {
                parentControl = value;
            }
        }

        /// <summary>
        /// ��ʼ��SelectorForm��
        /// </summary>
        /// <param name="control">�������ĸ��ؼ���</param>
        /// <param name="ds">��Ҫ��ʾ��DataSet</param>
        /// <returns></returns>
        public int InitSelector(Control control, DataSet ds)
        {
            DataSet = ds;
            if (DataSet == null || DataSet.Tables == null || DataSet.Tables.Count == 0)
            {
                return -1;
            }
            if (DataSet.Tables[0].Rows.Count == 0)
            {
                return 0;
            }
            Size = normalSize;
            DataView = new DataView(DataSet.Tables[0]);
            ParentControl = control;
            SetLocationAndBounds(ParentControl, this);
            return 1;
        }

        /// <summary>
        /// DataSet��
        /// </summary>
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

        /// <summary>
        /// DataView��
        /// </summary>
        public DataView DataView
        {
            get
            {
                return dataview;
            }
            set
            {
                dataview = value;
                fpSelector_Sheet1.DataSource = null;
                fpSelector_Sheet1.DataSource = dataview;
                SetFpFormat();
            }
        }

        /// <summary>
        /// ������Ϣ��
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                Text = title;
            }
        }

        private void SetFpFormat()
        {
            fpSelector.SuspendLayout();
            //���������
            if (HideOutColumn)
            {
                for (int i = 0; i < fpSelector_Sheet1.Columns.Count; i++)
                {
                    if (DataSet.Tables[0].Columns[i].ColumnName == OutColumn)
                    {
                        fpSelector_Sheet1.Columns[i].Visible = false;
                        break;
                    }
                }
            }
            float totalWidth = 0;
            for (int i = 0; i < fpSelector_Sheet1.Columns.Count ; i++)
            {
                if (!fpSelector_Sheet1.Columns[i].Visible)
                {
                    continue;
                }
                fpSelector_Sheet1.Columns[i].Locked = true;
                fpSelector_Sheet1.Columns[i].VerticalAlignment = CellVerticalAlignment.Center;
                fpSelector_Sheet1.Columns[i].Width = fpSelector_Sheet1.Columns[i].GetPreferredWidth();
                fpSelector_Sheet1.Columns[i].CellType = textCellType;
                totalWidth += fpSelector_Sheet1.Columns[i].Width;
            }
            fpSelector_Sheet1.ColumnHeader.Rows[0].Height = fpSelector_Sheet1.ColumnHeader.Rows[0].GetPreferredHeight();
            if (fpSelector_Sheet1.Rows.Count > 0)
            {
                SetActiveCell(fpSelector, fpSelector_Sheet1, 0, 0);
            }
            if (totalWidth >= Width)//����ܿ�ȴ��ڵ���Form������Form����Ӧ��
            {
                Width = Convert.ToInt32(totalWidth) + 25;
            }
            else//����ܿ��С��Form���򽫶���Ŀ��ƽ���ָ�ÿһ�С�
            {
                int avgSub = 0;
                if (HideOutColumn && fpSelector_Sheet1.Columns.Count - 1 > 0)
                {
                    avgSub = (Width - 25 - Convert.ToInt32(totalWidth)) / (fpSelector_Sheet1.Columns.Count - 1);
                }
                else if (fpSelector_Sheet1.Columns.Count > 0)
                {
                    avgSub = (Width - 25 - Convert.ToInt32(totalWidth)) / fpSelector_Sheet1.Columns.Count;
                }
                for (int i = 0; i < fpSelector_Sheet1.Columns.Count; i++)
                {
                    fpSelector_Sheet1.Columns[i].Width += avgSub;
                }
            }
            fpSelector.ResumeLayout();
        }

        private void ProcessKeyDown(Keys keyCode)
        {
            if (keyCode == Keys.Escape)
            {
                Close();
            }
            if (keyCode == Keys.Up && fpSelector_Sheet1.ActiveRowIndex > 0)
            {
                if (fpSelector_Sheet1.ActiveRow == null || fpSelector_Sheet1.ActiveRow.Index == 0)
                {
                    return;
                }
                SetActiveCell(fpSelector, fpSelector_Sheet1, fpSelector_Sheet1.ActiveRowIndex - 1, 0);
            }
            else if (keyCode == Keys.Down && fpSelector_Sheet1.ActiveRowIndex < fpSelector_Sheet1.Rows.Count - 1)
            {
                if (fpSelector_Sheet1.ActiveRow == null || fpSelector_Sheet1.ActiveRow.Index == fpSelector_Sheet1.Rows.Count - 1)
                {
                    return;
                }
                SetActiveCell(fpSelector, fpSelector_Sheet1, fpSelector_Sheet1.ActiveRowIndex + 1, 0);
            }
            else if (keyCode == Keys.Enter)
            {
                SeletctItem();
            }
        }

        private void SeletctItem()
        {
            if (fpSelector_Sheet1.Rows.Count > 0)
            {
                if (fpSelector_Sheet1.ActiveRowIndex >= 0)
                {
                    if (SelectItem == null)
                    {
                        return;
                    }
                    SelectItem(GetSelectedValue());
                    Close();
                }
            }
        }

        private string GetSelectedValue()
        {
            DataTable dt = DataSet.Tables[0];
            return dt.Rows[fpSelector_Sheet1.ActiveRowIndex][OutColumn].ToString();
        }

        private void SetActiveCell(FarPoint.Win.Spread.FpSpread spread, FarPoint.Win.Spread.SheetView sheet, int row, int column)
        {
            if (sheet.RowCount == 0 || sheet.Cells[row, column] == null)
            {
                return;
            }
            if (sheet.ActiveRow != null)
            {
                sheet.ActiveRow.BackColor = Color.White;
            }
            sheet.Rows[row].BackColor = Constants.Constants.ACTIVE_COLOR;
            sheet.SetActiveCell(row, column);
            spread.ShowActiveCell(VerticalPosition.Nearest, HorizontalPosition.Nearest);
        }

        private void SetLocationAndBounds(Control x, Control y)
        {
            Point px = x.PointToScreen(new Point(0, 0));
            Point py = y.PointToScreen(new Point(0, 0));
            int xOffset = px.X - py.X;
            int yOffset = px.Y - py.Y;
            Location = new Point(Location.X + xOffset, Location.Y + yOffset);
        }

        protected override void OnActivated(EventArgs e)
        {
            SetLocationAndBounds(ParentControl, this);
            base.OnActivated(e);
        }

        protected override void OnDeactivate(EventArgs e)
        {
            Close();
            if (SelectItem != null)
            {
                SelectItem(null);
            }
            base.OnDeactivate(e);
        }

        private void txtSelector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                return;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
            }
            ProcessKeyDown(e.KeyCode);
        }

        private void fpSelector_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
            {
                e.Cancel = true;
                return;
            }
            SeletctItem();
        }

        private void fpSelector_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            ((FpSpread)sender).ActiveSheet.Rows[e.Row].BackColor = Constants.Constants.ACTIVE_COLOR;
        }

        private void fpSelector_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            ((FpSpread)sender).ActiveSheet.Rows[e.Row].BackColor = Color.White;
        }

        private void fpSelector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeletctItem();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void fpSelector_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
            {
                e.Cancel = true;
                return;
            }
        }
    }

    /// <summary>
    /// SelectorForm��ѡ����Ŀ����ִ�еķ�����
    /// </summary>
    /// <param name="item">ѡ�����Ŀ��</param>
    public delegate void SelectItemHandle(string item);
}