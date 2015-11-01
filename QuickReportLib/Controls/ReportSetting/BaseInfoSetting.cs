using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Managers;
using QuickReportLib.Interfaces;
using QuickReportLib.Interfaces.ReportSetting;
using QuickReportLib.Interfaces.GlobalValue;
using QuickReportLib.Objects;
using QuickReportLib.Objects.GlobalValue;
using QuickReportLib.Controls.Plus.IToolStripMenuProvider.BaseInfoSetting;

namespace QuickReportLib.Controls.ReportSetting
{
    internal partial class BaseInfoSetting : BaseReportSettingUserControl, IBaseInfoSettingUserControl , ILoadedListener ,IChangedUserControl
    {
        public BaseInfoSetting()
        {
            InitializeComponent();
        }

        private ColumnGlobalValue columnGlobalValue = new ColumnGlobalValue();
        private ToolStripItem[] toolStripItems;
        private bool isEditingSQL = false;
        private DataBaseManager dataBaseManager = new DataBaseManager();

        #region IReportSettingUserControl ��Ա

        public string SettingName
        {
            get
            {
                return "������Ϣ";
            }
        }

        public string SettingSummary
        {
            get
            {
                return "���ñ��������Ϣ";
            }
        }

        public int Save()
        {
            return 1;
        }

        public ToolStripItem[] GetToolStripItems()
        {
            if (toolStripItems == null)
            {
                toolStripItems = new ToolStripItem[2];
                ToolStripButtonLock toolStripButtonLock = new ToolStripButtonLock();
                ToolStripButtonUnLock toolStripButtonUnLock = new ToolStripButtonUnLock();
                toolStripButtonLock.Click += new EventHandler(toolStripButtonLock_Click);
                toolStripButtonUnLock.Click += new EventHandler(toolStripButtonUnLock_Click);
                toolStripButtonUnLock.Visible = false;
                toolStripItems[0] = toolStripButtonLock;
                toolStripItems[1] = toolStripButtonUnLock;
            }
            return toolStripItems;
        }

        #endregion

        public override Report Report
        {
            get
            {
                return base.Report;
            }
            set
            {
                base.Report = value;
                cmbReportTypes.Text = report.Type;
                txtReportName.Text = report.Name;
                txtSQL.Text = report.MainReportSetting.SQL;
                txtReportID.Text = report.ID;
            }
        }

        private void EditSQL()
        {
            if (!isEditingSQL)
            {
                isEditingSQL = true;
                txtSQL.ReadOnly = false;
                (toolStripItems[1] as ToolStripButtonUnLock).Visible = true;
                (toolStripItems[0] as ToolStripButtonLock).Visible = false;
            }
            else
            {
                string sql = txtSQL.Text;
                string err=string.Empty;
                List<Column> columnList = SQLManager.ParseSQLToColumns(sql, ref err);
                if (columnList == null)
                {
                    WindowManager.ShowToolTip(txtSQL, "�޷�������ԭ��\n" + err, txtSQL.Location);
                    return;
                }
                isEditingSQL = false;
                txtSQL.ReadOnly = true;
                (toolStripItems[0] as ToolStripButtonLock).Visible = true;
                (toolStripItems[1] as ToolStripButtonUnLock).Visible = false;
                report.MainReportSetting.SQL = txtSQL.Text;
                report.Columns = columnList;
                SendColumnToGlobalValue();
                if (Changed != null)
                {
                    Changed(this, null);
                }
            }
        }

        private void InitReportTypes()
        {
            ArrayList reportTypes = dataBaseManager.QueryAllReportTypes();
            for (int i = 0; i < reportTypes.Count; i++)
            {
                cmbReportTypes.Items.Add(reportTypes[i].ToString());
            }
        }

        /// <summary>
        /// ����ȫ�ֱ�����������ܡ�
        /// </summary>
        private void SendColumnToGlobalValue()
        {
            columnGlobalValue.Value = new List<BaseObject>();
            foreach (Column column in report.Columns)
            {
                columnGlobalValue.Value.Add(column);
            }
            if (GlobalValueChanged != null)
            {
                GlobalValueChanged(this, columnGlobalValue);
            }
        }

        private void cmbReportTypes_TextChanged(object sender, EventArgs e)
        {
            report.Type = cmbReportTypes.Text;
        }

        private void txtReportName_TextChanged(object sender, EventArgs e)
        {
            report.Name = txtReportName.Text;
        }

        void toolStripButtonUnLock_Click(object sender, EventArgs e)
        {
            EditSQL();
        }

        void toolStripButtonLock_Click(object sender, EventArgs e)
        {
            EditSQL();
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtReportID.Text); 
        }

        protected override void OnLoad(EventArgs e)
        {
            InitReportTypes();
            base.OnLoad(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            int width = Width - tabControlSQL.Location.X;
            tabControlSQL.Size = new Size(width, tabControlSQL.Height);
            base.OnSizeChanged(e);
        }

        #region IGlobalValueProvider ��Ա

        public event GlobalValueChangedHandle GlobalValueChanged;

        #endregion

        #region IBaseInfoSettingUserControl ��Ա

        public bool IsEditingSQL
        {
            get
            {
                return isEditingSQL;
            }
        }

        public event AskForBringToFrontHandle AskForBringToFront;

        #endregion

        #region ILoadedListener ��Ա

        public void Loaded()
        {
            SendColumnToGlobalValue();
        }

        #endregion

        #region IChangedUserControl ��Ա

        public event EventHandler Changed;

        #endregion
    }
}
