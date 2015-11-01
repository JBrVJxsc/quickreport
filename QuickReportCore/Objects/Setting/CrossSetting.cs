using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.Setting
{
    internal class CrossSetting
    {
        private string row = string.Empty;
        /// <summary>
        /// �С�
        /// </summary>
        public string Row
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
            }
        }

        private string column = string.Empty;
        /// <summary>
        /// �С�
        /// </summary>
        public string Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
            }
        }

        private string valueT = string.Empty;
        /// <summary>
        /// ֵ��
        /// </summary>
        public string Value
        {
            get
            {
                return valueT;
            }
            set
            {
                valueT = value;
            }
        }

        private string groupSumRow = string.Empty;
        /// <summary>
        /// ��С�ơ�
        /// </summary>
        public string GroupSumRow
        {
            get
            {
                return groupSumRow;
            }
            set
            {
                groupSumRow = value;
            }
        }

        private string groupSumColumn = string.Empty;
        /// <summary>
        /// ��С�ơ�
        /// </summary>
        public string GroupSumColumn
        {
            get
            {
                return groupSumColumn;
            }
            set
            {
                groupSumColumn = value;
            }
        } 

        private bool useCustomColumn = false;
        /// <summary>
        /// �Ƿ�ʹ���Զ����С�
        /// </summary>
        public bool UseCustomColumn
        {
            get
            {
                return useCustomColumn;
            }
            set
            {
                useCustomColumn = value;
            }
        }

        private bool useCustomRow = false;
        /// <summary>
        /// �Ƿ�ʹ���Զ����С�
        /// </summary>
        public bool UseCustomRow
        {
            get
            {
                return useCustomRow;
            }
            set
            {
                useCustomRow = value;
            }
        }

        private string sqlColumn = string.Empty;
        /// <summary>
        /// �Զ�����SQL��䡣
        /// </summary>
        public string ColumnSQL
        {
            get
            {
                return sqlColumn;
            }
            set
            {
                sqlColumn = value;
            }
        }


        private string sqlRow = string.Empty;
        /// <summary>
        /// �Զ�����SQL��䡣
        /// </summary>
        public string RowSQL
        {
            get
            {
                return sqlRow;
            }
            set
            {
                sqlRow = value;
            }
        }

        private string customColumnName = string.Empty;
        /// <summary>
        /// �Զ����С�
        /// </summary>
        public string CustomColumnName
        {
            get
            {
                return customColumnName;
            }
            set
            {
                customColumnName = value;
            }
        }

        private string groupSumCustomColumn = string.Empty;
        /// <summary>
        /// ��С�Ƶ��С�
        /// </summary>
        public string GroupSumCustomColumn
        {
            get
            {
                return groupSumCustomColumn;
            }
            set
            {
                groupSumCustomColumn = value;
            }
        }

        private string customRowName = string.Empty;
        /// <summary>
        /// �Զ����С�
        /// </summary>
        public string CustomRowName
        {
            get
            {
                return customRowName;
            }
            set
            {
                customRowName = value;
            }
        }

        private string groupSumCustomRow = string.Empty;
        /// <summary>
        /// ��С�Ƶ��С�
        /// </summary>
        public string GroupSumCustomRow
        {
            get
            {
                return groupSumCustomRow;
            }
            set
            {
                groupSumCustomRow = value;
            }
        }

        private string groupSumRowName = string.Empty;
        /// <summary>
        /// ��С�Ƶ����֡�
        /// </summary>
        public string GroupSumRowName
        {
            get
            {
                return groupSumRowName;
            }
            set
            {
                groupSumRowName = value;
            }
        }

        private string groupSumColumnName = string.Empty;
        /// <summary>
        /// ��С�Ƶ����֡�
        /// </summary>
        public string GroupSumColumnName
        {
            get
            {
                return groupSumColumnName;
            }
            set
            {
                groupSumColumnName = value;
            }
        }

        private string customColumnGroupSumName = string.Empty;
        /// <summary>
        /// �Զ�����ʱ����С�Ƶ����֡�
        /// </summary>
        public string CustomColumnGroupSumName
        {
            get
            {
                return customColumnGroupSumName;
            }
            set
            {
                customColumnGroupSumName = value;
            }
        }


        private bool useGroupSumRow = false;
        /// <summary>
        /// �Ƿ�ʹ����С�ơ�
        /// </summary>
        public bool UseGroupSumRow
        {
            get
            {
                return useGroupSumRow;
            }
            set
            {
                useGroupSumRow = value;
            }
        }

        private bool useHeader = false;
        /// <summary>
        /// �Ƿ�ʹ�ö���������ʽ��
        /// </summary>
        public bool UseHeader
        {
            get
            {
                return useHeader;
            }
            set
            {
                useHeader = value;
            }
        }

        private bool rowSum = false;
        /// <summary>
        /// �Ƿ�ʹ���кϼơ�
        /// </summary>
        public bool RowSum
        {
            get
            {
                return rowSum;
            }
            set
            {
                rowSum = value;
            }
        }

        private bool columnSum = false;
        /// <summary>
        /// �Ƿ�ʹ���кϼơ�
        /// </summary>
        public bool ColumnSum
        {
            get
            {
                return columnSum;
            }
            set
            {
                columnSum = value;
            }
        }

        private bool union = false;
        /// <summary>
        /// �Ƿ�ϲ�ͬ���
        /// </summary>
        public bool Union
        {
            get
            {
                return union;
            }
            set
            {
                union = value;
            }
        }
    }
}
