using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using QuickReportLib.Interfaces.ReportSetting;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Interfaces;
using QuickReportLib.Objects.GlobalValue;
using QuickReportLib.Controls.Plus.IToolStripMenuProvider;
using QuickReportLib.Forms.ReportSetting;
using QuickReportLib.Objects;
using QuickReportLib.Interfaces.ConditionInputType;

namespace QuickReportLib.Controls.ReportSetting
{
    internal partial class ConditionSetting : BaseReportSettingUserControl, IConditionSettingUserControl, ILoadedListener , IChangedUserControl
    {
        public ConditionSetting()
        {
            InitializeComponent();
        }

        private ConditionGlobalValue conditionGlobalValue = new ConditionGlobalValue();
        private ToolStripItem[] toolStripItems;

        private void Add(Condition condition)
        {
            fpConditions_Sheet1.Rows.Count++;
            report.Conditions.Add(condition);
            condition.SortID = fpConditions_Sheet1.Rows.Count - 1;
            Cell cell = fpConditions_Sheet1.Cells[fpConditions_Sheet1.Rows.Count - 1, 0];
            cell.Value = condition.ID;
            cell.Tag = condition;
            SelectCondition(cell);
            SendConditionToGlobalValue();
            Change();
        }

        private void Delete()
        {
            #region ��ɾ��ѡ�е�������
            if (fpConditions_Sheet1.ActiveCell != null)
            {
                Condition condition = fpConditions_Sheet1.ActiveCell.Tag as Condition;
                DialogResult dr = MessageBox.Show("ȷ��Ҫɾ�� " + condition.ID + " ��", "ɾ������", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes)
                {
                    return;
                }
                report.Conditions.Remove(condition);
                fpConditions_Sheet1.Rows.Remove(fpConditions_Sheet1.ActiveCell.Row.Index, 1);
            }
            else
            {
                return;
            }
            #endregion

            #region ѡ���µ�������
            //�������ʣ��������
            if (fpConditions_Sheet1.ActiveCell != null)
            {
                SelectCondition(fpConditions_Sheet1.ActiveCell);
            }
            //���û��ʣ��������
            else
            {
                conditionDetailSetting.Condition = null;
            }
            #endregion

            #region ����Ϊ��������
            for (int i = 0; i < fpConditions_Sheet1.Rows.Count; i++)
            {
                Cell cell = fpConditions_Sheet1.Cells[i, 0];
                Condition condition = cell.Tag as Condition;
                condition.SortID = i;
            }
            #endregion
            SendConditionToGlobalValue();
            Change();
        }

        private void ImportCondition()
        { 
            
        }

        private void ExportCondition()
        { 
            
        }

        private void SelectCondition(Cell cell)
        {
            Condition condition = cell.Tag as Condition;
            if (conditionDetailSetting.Condition != condition)
            {
                conditionDetailSetting.Condition = condition;
            }
            fpConditions_Sheet1.SetActiveCell(cell.Row.Index, cell.Column.Index);
        }

        /// <summary>
        /// ������λ�ý�����
        /// </summary>
        /// <param name="rowIndexOne">�����һ��</param>
        /// <param name="rowIndexTwo">����Ŷ���</param>
        private void ChangeRow(int rowIndexOne, int rowIndexTwo)
        {
            Cell cellOne = fpConditions_Sheet1.Cells[rowIndexOne, 0];
            Cell cellTwo = fpConditions_Sheet1.Cells[rowIndexTwo, 0];
            Condition conditionOne = cellOne.Tag as Condition;
            Condition conditionTwo = cellTwo.Tag as Condition;
            cellOne.Value = conditionTwo.ID;
            cellTwo.Value = conditionOne.ID;
            cellOne.Tag = conditionTwo;
            cellTwo.Tag = conditionOne;
            conditionOne.SortID = rowIndexTwo;
            conditionTwo.SortID = rowIndexOne;
            Change();
        }

        /// <summary>
        /// ������ȫ�ֱ�����������ܡ�
        /// </summary>
        private void SendConditionToGlobalValue()
        {
            conditionGlobalValue.Value = new List<BaseObject>();
            foreach (Condition condition in report.Conditions)
            {
                conditionGlobalValue.Value.Add(condition);
            }
            if (GlobalValueChanged != null)
            {
                GlobalValueChanged(this, conditionGlobalValue);
            }
        }

        private void Change()
        {
            if (Changed != null)
            {
                Changed(this, null);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            fpConditions.Width = (int)fpConditions_Sheet1.Columns[0].Width+4;
            base.OnSizeChanged(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            conditionDetailSetting.AskForBringToFront += new AskForBringToFrontHandle(conditionDetailSetting_AskForBringToFront);
            base.OnLoad(e);
        }

        void conditionDetailSetting_AskForBringToFront(object sender, EventArgs e)
        {
            if (AskForBringToFront != null)
            {
                AskForBringToFront(this, null);
            }
            IConditionInputTypeSettingUserControl iConditionInputTypeSettingUserControl = sender as IConditionInputTypeSettingUserControl;
            for (int i = 0; i < fpConditions_Sheet1.Rows.Count; i++)
            {
                Cell cell = fpConditions_Sheet1.Cells[i, 0];
                Condition condition = cell.Tag as Condition;
                if (condition != null)
                {
                    if (condition.ConditionInputType.ConditionInputTypeSettingObject == iConditionInputTypeSettingUserControl.ConditionInputTypeSettingObject)
                    {
                        SelectCondition(cell);
                    }
                }
            }
        }

        #region IReportSettingUserControl ��Ա

        public string SettingName
        {
            get
            {
                return "����";
            }
        }

        public string SettingSummary
        {
            get
            {
                return "���ñ��������";
            }
        }

        public int Save()
        {
            foreach (Condition condition in report.Conditions)
            {
                if (condition.ConditionInputType.GetConditionInputTypeSettingUserControl(null).CheckInput() < 0)
                {
                    return -1;
                }
            }
            return 1;
        }

        public ToolStripItem[] GetToolStripItems()
        {
            if (toolStripItems == null)
            {
                toolStripItems = new ToolStripItem[6];
                ToolStripButtonNewOne toolStripButtonNewOne = new ToolStripButtonNewOne();
                ToolStripButtonDeleteOne toolStripButtonDeleteOne = new ToolStripButtonDeleteOne();
                ToolStripButtonUp toolStripButtonUp = new ToolStripButtonUp();
                ToolStripButtonDown toolStripButtonDown = new ToolStripButtonDown();
                ToolStripButtonImport toolStripButtonImport = new ToolStripButtonImport();
                ToolStripButtonExport toolStripButtonExport = new ToolStripButtonExport();
                #region �Ȳ��������ĵ��뵼�����ܡ���Ϊû��ʱ���ˡ�������˿�����δ��룬���Բ��յ��뵼������Ĺ���ʵ�ֵ��뵼�������Ĺ��ܡ�
                toolStripButtonImport.Visible = false;
                toolStripButtonExport.Visible = false;
                #endregion
                toolStripButtonNewOne.Click += new EventHandler(toolStripButtonNewOne_Click);
                toolStripButtonDeleteOne.Click += new EventHandler(toolStripButtonDeleteOne_Click);
                toolStripButtonUp.Click += new EventHandler(toolStripButtonUp_Click);
                toolStripButtonDown.Click += new EventHandler(toolStripButtonDown_Click);
                toolStripButtonImport.Click += new EventHandler(toolStripButtonImport_Click);
                toolStripButtonExport.Click += new EventHandler(toolStripButtonExport_Click);
                toolStripItems[0] = toolStripButtonNewOne;
                toolStripItems[1] = toolStripButtonDeleteOne;
                toolStripItems[2] = toolStripButtonUp;
                toolStripItems[3] = toolStripButtonDown;
                toolStripItems[4] = toolStripButtonImport;
                toolStripItems[5] = toolStripButtonExport;
            }
            return toolStripItems;
        }

        public event AskForBringToFrontHandle AskForBringToFront;

        #endregion

        void toolStripButtonExport_Click(object sender, EventArgs e)
        {
            ExportCondition();
        }

        void toolStripButtonImport_Click(object sender, EventArgs e)
        {
            ImportCondition();
        }

        void toolStripButtonDown_Click(object sender, EventArgs e)
        {
            if (fpConditions_Sheet1.ActiveCell == null||fpConditions_Sheet1.ActiveCell.Row.Index==fpConditions_Sheet1.Rows.Count-1)
            {
                return;
            }
            ChangeRow(fpConditions_Sheet1.ActiveCell.Row.Index, fpConditions_Sheet1.ActiveCell.Row.Index + 1);
            fpConditions_Sheet1.SetActiveCell(fpConditions_Sheet1.ActiveCell.Row.Index + 1, 0);
            SelectCondition(fpConditions_Sheet1.ActiveCell);
        }

        void toolStripButtonUp_Click(object sender, EventArgs e)
        {
            if (fpConditions_Sheet1.ActiveCell == null||fpConditions_Sheet1.ActiveCell.Row.Index == 0)
            {
                return;
            }
            ChangeRow(fpConditions_Sheet1.ActiveCell.Row.Index, fpConditions_Sheet1.ActiveCell.Row.Index - 1);
            fpConditions_Sheet1.SetActiveCell(fpConditions_Sheet1.ActiveCell.Row.Index - 1, 0);
            SelectCondition(fpConditions_Sheet1.ActiveCell);
        }

        void toolStripButtonDeleteOne_Click(object sender, EventArgs e)
        {
            Delete();
        }

        void toolStripButtonNewOne_Click(object sender, EventArgs e)
        {
            ConditionCreator conditionCreator = new ConditionCreator();
            conditionCreator.ConditionCreated += new ConditionCreatedHandle(conditionCreator_ConditionCreated);
            conditionCreator.ShowDialog();
        }

        void conditionCreator_ConditionCreated(object sender, Condition condition, out bool success)
        {
            success = true;
            foreach (Condition c in report.Conditions)
            {
                if (condition.ID == c.ID)
                {
                    success = false;
                    return;
                }
            }
            Add(condition);
        }

        private void fpConditions_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cell cell = fpConditions_Sheet1.Cells[e.Row, e.Column];
                SelectCondition(cell);
            }
        }

        private void fpConditions_EnterCell(object sender, EnterCellEventArgs e)
        {
            Cell cell = fpConditions_Sheet1.Cells[e.Row, e.Column];
            SelectCondition(cell);
        }

        #region IGlobalValueProvider ��Ա

        public event GlobalValueChangedHandle GlobalValueChanged;

        #endregion

        #region ILoadedListener ��Ա

        public void Loaded()
        {
            //��Report�е�������������档
            fpConditions_Sheet1.Rows.Count = report.Conditions.Count;
            foreach (Condition condition in report.Conditions)
            {
                Cell cell = fpConditions_Sheet1.Cells[condition.SortID, 0];
                cell.Value = condition.ID;
                cell.Tag = condition;
            }
            //ѡ�е�һ��������
            if (fpConditions_Sheet1.Rows.Count > 0)
            {
                Cell cell = fpConditions_Sheet1.Cells[0, 0];
                SelectCondition(cell);
            }
            SendConditionToGlobalValue();
        }

        #endregion

        #region IChangedUserControl ��Ա

        public event EventHandler Changed;

        #endregion
    }
}
