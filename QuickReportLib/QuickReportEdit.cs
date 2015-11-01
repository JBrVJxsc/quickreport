using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Forms;
using QuickReportLib.Managers;

namespace QuickReportLib
{
    public partial class QuickReportEdit : Form
    {
        public QuickReportEdit()
        {
            InitializeComponent();
            checkDataBaseSucceed = CheckDataBase();
        }

        private DataBaseManager dataBaseManager = new DataBaseManager();
        private bool checkDataBaseSucceed = true;

        /// <summary>
        /// ������ݿ����Ƿ���ڱ�������������򴴽���
        /// </summary>
        /// <returns>�����ɹ������贴�����򷵻�true������ʧ�ܷ���false��</returns>
        private bool CheckDataBase()
        {
            int i = 0;
            i = dataBaseManager.QueryTableExistQUICKREPORT_REPORTS();
            if (i <= 0)
            {
                i = dataBaseManager.CreateTableQUICKREPORT_REPORTS();
                if (i < 0)
                {
                    goto Err;
                }
            }

            i = dataBaseManager.QueryTableExistQUICKREPORT_SETTINGS();
            if (i <= 0)
            {
                i = dataBaseManager.CreateTableQUICKREPORT_SETTINGS();
                if (i < 0)
                {
                    goto Err;
                }
            }
            return true;
        Err:
            {
                MessageBox.Show("�����������ݿ���ʧ�ܡ�ԭ��+\n" + dataBaseManager.Err, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void QuickReportEdit_Shown(object sender, EventArgs e)
        {
            if (!checkDataBaseSucceed)
            {
                return;
            }
            XmlManager.InitXmlManager();
            QuickReportEditor quickReportEditor = new QuickReportEditor();
            quickReportEditor.ShowDialog();
            Close();
        }
    }
}