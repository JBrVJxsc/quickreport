using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// ����������ʵ�塣
    /// </summary>
    public class MainReportSetting
    {
        private InterfaceSetting interfaceSetting = new InterfaceSetting();
        private ViewSetting viewSetting = new ViewSetting();
        private HeaderSetting headerSetting = new HeaderSetting();
        private string sql = string.Empty;

        /// <summary>
        /// �ӿ����á�
        /// </summary>
        public InterfaceSetting InterfaceSetting
        {
            get
            {
                return interfaceSetting;
            }
            set
            {
                interfaceSetting = value;
            }
        }

        /// <summary>
        /// ������á�
        /// </summary>
        public ViewSetting ViewSetting
        {
            get
            {
                return viewSetting;
            }
            set
            {
                viewSetting = value;
            }
        }

        /// <summary>
        /// ��ͷ���á�
        /// </summary>
        public HeaderSetting HeaderSetting
        {
            get
            {
                return headerSetting;
            }
            set
            {
                headerSetting = value;
            }
        }

        /// <summary>
        /// �������SQL��䡣
        /// </summary>
        public string SQL
        {
            get
            {
                return sql;
            }
            set
            {
                sql = value;
            }
        }
    }
}
