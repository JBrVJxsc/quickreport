using System;
using System.Collections.Generic;
using System.Text;
using QuickReportLib.Objects;
using QuickReportLib.Objects.ReportSetting;
using QuickReportLib.ReportStyles;
using QuickReportLib.ReportLayoutStyles;

namespace QuickReportLib.Objects
{
    /// <summary>
    /// 报表。
    /// </summary>
    public class Report : BaseObject
    {
        private string type = string.Empty;
        private decimal version = 1.00m;
        private string isvalid = "1";
        private BaseReportStyle reportStyle;
        private BaseReportLayoutStyle reportLayoutStyle;
        private List<Column> columns = new List<Column>();
        private List<Condition> conditions = new List<Condition>();
        private TreeSetting treeSetting = new TreeSetting();
        private MainReportSetting mainReportSetting = new MainReportSetting();
        private DetailReportSetting detailReportSetting = new DetailReportSetting();

        /// <summary>
        /// 类别。
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        /// <summary>
        /// 版本号。
        /// </summary>
        public decimal Version
        {
            get
            {
                return version;
            }
            set
            {
                version = value;
            }
        }

        /// <summary>
        /// 是否有效。
        /// </summary>
        public string IsValid
        {
            get
            {
                return isvalid;
            }
            set
            {
                isvalid = value;
            }
        }

        /// <summary>
        /// 报表样式。
        /// </summary>
        public BaseReportStyle ReportStyle
        {
            get
            {
                return reportStyle;
            }
            set
            {
                reportStyle = value;
            }
        }

        /// <summary>
        /// 报表布局样式。
        /// </summary>
        public BaseReportLayoutStyle ReportLayoutStyle
        {
            get
            {
                return reportLayoutStyle;
            }
            set
            {
                reportLayoutStyle = value;
            }
        }

        /// <summary>
        /// 列。
        /// </summary>
        public List<Column> Columns
        {
            get
            {
                return columns;
            }
            set
            {
                columns = value;
            }
        }

        /// <summary>
        /// 条件。
        /// </summary>
        public List<Condition> Conditions
        {
            get
            {
                return conditions;
            }
            set
            {
                conditions = value;
            }
        }

        /// <summary>
        /// 树设置。
        /// </summary>
        public TreeSetting TreeSetting
        {
            get
            {
                return treeSetting;
            }
            set
            {
                treeSetting = value;
            }
        }

        /// <summary>
        /// 主报表设置。
        /// </summary>
        public MainReportSetting MainReportSetting
        {
            get
            {
                return mainReportSetting;
            }
            set
            {
                mainReportSetting = value;
            }
        }

        /// <summary>
        /// 明细报表设置。
        /// </summary>
        public DetailReportSetting DetailReportSetting
        {
            get
            {
                return detailReportSetting;
            }
            set
            {
                detailReportSetting = value;
            }
        }
    }
}
