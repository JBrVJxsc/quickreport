using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore.Controls
{
    internal partial class ucReportCondition : UserControl
    {
        public ucReportCondition()
        {
            InitializeComponent();
            Init();
        }

        public delegate void EnterConditionHandle(int pageIndex);
        public event EnterConditionHandle EnterCondition;

        private Control editControl;
        public Control EditControl
        {
            get
            {
                return editControl;
            }
        }

        private Interfaces.IConditionValue IConditionValueUserControl;

        private Size andOrShowSize;
        private Size andOrUnShowSize;
        private int controlYoffset = -2;

        public void SetEditControlFocus()
        {
            if (editControl != null)
                editControl.Focus();
        }

        private bool showAndOrState = false;
        /// <summary>
        /// 是否显示或/且。
        /// </summary>
        public bool ShowAndOrState
        {
            get
            {
                return showAndOrState;
            }
            set
            {
                showAndOrState = value;
                ShowAndOr(showAndOrState);
            }
        }

        private int pageIndex = 0;
        public int PageIndex
        {
            get
            {
                return pageIndex;
            }
            set
            {
                pageIndex = value;
            }
        }

        private Objects.Condition condition = new QuickReportCore.Objects.Condition();
        public Objects.Condition Condition
        {
            get
            {
                return condition;
            }
            set
            {
                if (value == null)
                    return;
                condition = value;
                LoadCondition(condition);
            }
        }

        private void LoadCondition(Objects.Condition condition)
        {
            if (condition.ConditionType.ID.Trim() == string.Empty)
                return;
            lbConditionName.Text = condition.Name;
            QuickReportCore.Objects.Condition.InputValueType inputType = (QuickReportCore.Objects.Condition.InputValueType)Enum.Parse(typeof(QuickReportCore.Objects.Condition.InputValueType), Condition.ConditionType.ID);
            IConditionValueUserControl = System.Activator.CreateInstance(QuickReportCore.Forms.frmConditionSetting.htIConditionValueUserControlList[inputType] as Type) as Interfaces.IConditionValue;
            IConditionValueUserControl.InitValue(condition);
            editControl = IConditionValueUserControl.EditControl;
            pnlReportCondition.Controls.Add(editControl);
            int x = lbConditionName.Location.X + lbConditionName.Width;
            int y = lbConditionName.Location.Y + controlYoffset;
            int width = cmbOperator.Width;
            int height = cmbOperator.Height;
            if (IConditionValueUserControl.HideOperator)
            {
                width = 0;
                cmbOperator.Visible = false;
            }
            cmbOperator.SetBounds(x, y, width, height);
            x = cmbOperator.Location.X + cmbOperator.Width + 5;
            y = lbConditionName.Location.Y + controlYoffset+1;
            width = editControl.Width;
            height = editControl.Height;
            if (editControl is ComboBox)
                editControl.SetBounds(x, y-1, width, height);
            else
                editControl.SetBounds(x, y, width, height);
            andOrUnShowSize = new Size(editControl.Location.X + editControl.Width + 10, Height);
            x = editControl.Location.X + editControl.Width + 12;
            y = lbConditionName.Location.Y + controlYoffset;
            width = cmbAndOr.Width;
            height = cmbAndOr.Height;
            cmbAndOr.SetBounds(x, y, width, height);
            Size = new Size(cmbAndOr.Location.X + cmbAndOr.Width + 10, Height);
            andOrShowSize = Size;
            InitOperators(IConditionValueUserControl.Operators);
            cmbOperator.Text = IConditionValueUserControl.DefaultOperator;
            if (cmbOperator.Visible)
            {
                cmbOperator.TabIndex = 0;
                editControl.TabIndex = 1;
                cmbAndOr.TabIndex = 2;
            }
            else
            {
                editControl.TabIndex = 0;
                cmbAndOr.TabIndex = 1;
            }
        }

        public string Value
        {
            get
            {
                if (IConditionValueUserControl == null)
                    return null;
                return IConditionValueUserControl.EditControlValue;
            }
        }

        public string SQLValue
        {
            get
            {
                if (IConditionValueUserControl == null)
                    return null;
                return IConditionValueUserControl.EditControlSQLValue;
            }
        }

        private void Init()
        {
            Objects.Operator and = new QuickReportCore.Objects.Operator("AND", "且");
            Objects.Operator or = new QuickReportCore.Objects.Operator("OR", "或");
            cmbAndOr.Items.Add(and);
            cmbAndOr.Items.Add(or);
            cmbAndOr.SelectedIndex = 0;
        }

        private void InitOperators(Objects.Operator[] operators)
        {
            for (int i = 0; i < operators.Length; i++)
            {
                cmbOperator.Items.Add(operators[i]);
            }
            cmbOperator.SelectedIndex = 0;
        }

        private void ShowAndOr(bool b)
        {
            if (b)
            {
                cmbAndOr.Visible = true;
                if (Size != andOrShowSize)
                    Size = andOrShowSize;
            }
            else
            {
                cmbAndOr.Visible = false;
                if (Size != andOrUnShowSize)
                    Size = andOrUnShowSize;
            }
        }

        public override string ToString()
        {
            return Condition.Name;
        }

        public int CheckInput()
        {
            if (condition.NotNull && IConditionValueUserControl.EditControlValue.Trim() == string.Empty)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        public Type EditorControlType()
        {
            return editControl.GetType();
        }

        public string FullConditionString
        {
            get
            {
                string s = string.Empty;
                s += " "+Condition.ID+" ";
                Objects.Operator o = cmbOperator.SelectedItem as Objects.Operator;
                if (o.ID == "LIKE")
                    s += " LIKE " + " '%" + Value + "%' ";
                else
                {
                    if (SQLValue == "'ALL'")//如果选择的是全部，则返回1=1（即：条件作废）。
                    {
                        s = "(1=1)";
                        if (ShowAndOrState)
                            s += " " + (cmbAndOr.SelectedItem as Objects.Operator).ID + " ";
                        return s;
                    }
                    s += " " + o.ID + " " + SQLValue + " ";
                }
                if (ShowAndOrState)
                    s += " " + (cmbAndOr.SelectedItem as Objects.Operator).ID + " ";
                return s;
            }
        }

        private void ucReportCondition_Enter(object sender, EventArgs e)
        {
            if (EnterCondition != null)
                EnterCondition(PageIndex);
        }
    }
}
