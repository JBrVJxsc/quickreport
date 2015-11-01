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
using QuickReportLib.Interfaces;

namespace QuickReportLib.Controls.ReportSetting
{
    internal partial class ColumnSetting : BaseReportSettingUserControl , IColumnSettingUserControl 
    {
        public ColumnSetting()
        {
            InitializeComponent();
        }

        #region IReportSettingUserControl ��Ա


        public string SettingName
        {
            get
            {
                return "������";
            }
        }

        public string SettingSummary
        {
            get
            {
                return "�����е�����";
            }
        }

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

        #region IToolStripMenuProvider ��Ա

        public event ProvideToolStripMenuHandle ProvideToolStripMenu;

        #endregion
    }
}
