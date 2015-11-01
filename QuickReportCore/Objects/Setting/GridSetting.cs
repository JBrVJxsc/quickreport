using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportCore.Objects.Setting
{
    internal class GridSetting
    {
        private string groupSumRow = string.Empty;
        /// <summary>
        /// ����С�Ƶ��С�
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

        private string rowGroupSumName = string.Empty;
        /// <summary>
        /// ����С�Ƶ����ơ�
        /// </summary>
        public string RowGroupSumName
        {
            get
            {
                return rowGroupSumName;
            }
            set
            {
                rowGroupSumName = value;
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
        /// �Ƿ�ʹ�÷��������ʽ��
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
