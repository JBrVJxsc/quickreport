using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace QuickReportCore.Objects.Setting
{
    internal class ReportSetting
    {
        private bool crossReport = false;
        /// <summary>
        /// 是否是交叉报表。
        /// </summary>
        public bool CrossReport
        {
            get
            {
                return crossReport;
            }
            set
            {
                crossReport = value;
            }
        }

        private bool gridReport = false;
        /// <summary>
        /// 是否是网格报表。
        /// </summary>
        public bool GridReport
        {
            get
            {
                return gridReport;
            }
            set
            {
                gridReport = value;
            }
        }

        private bool useTree = false;
        /// <summary>
        /// 是否使用树。
        /// </summary>
        public bool UseTree
        {
            get
            {
                return useTree;
            }
            set
            {
                useTree = value;
            }
        }

        private bool useDetail = false;
        /// <summary>
        /// 是否使用明细。
        /// </summary>
        public bool UseDetail
        {
            get
            {
                return useDetail;
            }
            set
            {
                useDetail = value;
            }
        }

        private bool useLoadAndQuery = false;
        /// <summary>
        /// 是否登陆便查询。
        /// </summary>
        public bool UseLoadAndQuery
        {
            get
            {
                return useLoadAndQuery;
            }
            set
            {
                useLoadAndQuery = value;
            }
        }

        private bool useAutoColumnWidth = false;
        /// <summary>
        /// 是否使用自动列宽。
        /// </summary>
        public bool UseAutoColumnWidth
        {
            get
            {
                return useAutoColumnWidth;
            }
            set
            {
                useAutoColumnWidth = value;
            }
        }

        private bool useViewOpen = false;
        /// <summary>
        /// 是否是开放式报表。
        /// </summary>
        public bool UseViewOpen
        {
            get
            {
                return useViewOpen;
            }
            set
            {
                useViewOpen = value;
            }
        }

        private Color evenColor;
        /// <summary>
        /// 间隔色。
        /// </summary>
        public Color EvenColor
        {
            get
            {
                return evenColor;
            }
            set
            {
                evenColor = value;
            }
        }

        private bool useEvenColor = false;
        /// <summary>
        /// 是否使用间隔色。
        /// </summary>
        public bool UseEvenColor
        {
            get
            {
                return useEvenColor;
            }
            set
            {
                useEvenColor = value;
            }
        }

        private string sql = string.Empty;
        /// <summary>
        /// SQL语句。
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
