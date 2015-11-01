using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuickReportLib.Interfaces.ReportSetting;
using QuickReportLib.Enums;
using QuickReportLib.Interfaces.GlobalValue;

namespace QuickReportLib.Controls.ReportSetting
{
    internal partial class DetailReportSetting : BaseReportSettingUserControl , IDetailReportSettingUserControl
    {
        public DetailReportSetting()
        {
            InitializeComponent();
        }

        #region IReportSettingUserControl ��Ա


        public string SettingName
        {
            get
            {
                return "��ϸ����";
            }
        }

        public string SettingSummary
        {
            get
            {
                return "���ñ������ϸ����";
            }
        }

        public int Save()
        {
            return 1;
        }

        public ToolStripItem[] GetToolStripItems()
        {
            return null;
        }

        public event AskForBringToFrontHandle AskForBringToFront;

        #endregion

        #region IGlobalValueAsker ��Ա

        public List<GlobalValueType> GlobalValueTypes
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public void SetGlobalValue(IGlobalValue globalValue)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
