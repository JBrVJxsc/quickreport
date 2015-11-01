using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// 主报表设置实体。
    /// </summary>
    public class MainReportSetting
    {
        private InterfaceSetting interfaceSetting = new InterfaceSetting();
        private ViewSetting viewSetting = new ViewSetting();
        private HeaderSetting headerSetting = new HeaderSetting();
        private string sql = string.Empty;

        /// <summary>
        /// 接口设置。
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
        /// 外观设置。
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
        /// 表头设置。
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
        /// 主报表的SQL语句。
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
