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
    /// ����
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
        /// ���
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
        /// �汾�š�
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
        /// �Ƿ���Ч��
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
        /// ������ʽ��
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
        /// ��������ʽ��
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
        /// �С�
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
        /// ������
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
        /// �����á�
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
        /// ���������á�
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
        /// ��ϸ�������á�
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
