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
        /// �Ƿ��ǽ��汨��
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
        /// �Ƿ������񱨱�
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
        /// �Ƿ�ʹ������
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
        /// �Ƿ�ʹ����ϸ��
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
        /// �Ƿ��½���ѯ��
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
        /// �Ƿ�ʹ���Զ��п�
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
        /// �Ƿ��ǿ���ʽ����
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
        /// ���ɫ��
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
        /// �Ƿ�ʹ�ü��ɫ��
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
        /// SQL��䡣
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
