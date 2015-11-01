using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Interfaces.Wizard;
using QuickReportLib.Managers;
using QuickReportLib.Objects;

namespace QuickReportLib.Controls.Wizard
{
    /// <summary>
    /// ���������Ϣ�򵼡�
    /// </summary>
    internal partial class ReportBaseInfoWizard : BaseWizardUserControl, ICreateReportWizardUserControl
    {
        public ReportBaseInfoWizard()
        {
            InitializeComponent();
        }

        private DataBaseManager dataBaseManager = new DataBaseManager();

        public override int SortID
        {
            get
            {
                return 0;
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

        private bool ParseSQL()
        {
            string sql = txtSQL.Text;
            string err = string.Empty;
            List<Column> columnList = SQLManager.ParseSQLToColumns(sql, ref err);
            if (columnList == null)
            {
                WindowManager.ShowToolTip(txtSQL, "SQL�������ԭ��\n" + err, txtSQL.Location);
                return false;
            }
            else
            {
                report.MainReportSetting.SQL = txtSQL.Text;
                report.Columns = columnList;
                return true;
            }
        }

        #region IWizardUserControl ��Ա

        public string Title
        {
            get
            {
                return "������Ϣ";
            }
        }

        public string Summary
        {
            get
            {
                return "���ñ��������Ϣ";
            }
        }

        public Image Image
        {
            get
            {
                return null;
            }
        }

        public bool CanNext()
        {
            if (cmbReportTypes.Text == string.Empty)
            {
                WindowManager.ShowToolTip(cmbReportTypes, "��¼�뱨�����", true);
                return false;
            }
            if (txtReportName.Text == string.Empty)
            {
                WindowManager.ShowToolTip(txtReportName, "��¼�뱨�����ơ�", true);
                return false;
            }
            bool b = ParseSQL();
            if (!b)
            {
                return false;
            }
            report.Type = cmbReportTypes.Text;
            report.Name = txtReportName.Text;
            return true;
        }

        #endregion

        private void ReportBaseInfoWizard_Load(object sender, EventArgs e)
        {
            InitReportTypes();
        }
    }
}
