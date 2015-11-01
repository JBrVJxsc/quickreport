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
        /// 检查数据库中是否存在必须项，若不存在则创建。
        /// </summary>
        /// <returns>创建成功或无需创建，则返回true；创建失败返回false。</returns>
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
                MessageBox.Show("创建所需数据库项失败。原因：+\n" + dataBaseManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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