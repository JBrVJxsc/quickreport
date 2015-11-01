using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReportLib.Objects.ReportSetting
{
    /// <summary>
    /// ��ϸ��������ʵ�塣
    /// </summary>
    public class DetailReportSetting
    {
        private string id = string.Empty;
        private bool enableInterface = false;
        private List<DetailReportConditionCompare> conditionCompareList = new List<DetailReportConditionCompare>();

        /// <summary>
        /// ��ϸ������ָ��ı���ID��
        /// </summary>
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        /// <summary>
        /// �Ƿ�����ִ����ϸ����Ľӿڡ�
        /// </summary>
        public bool EnableInterface
        {
            get
            {
                return enableInterface;
            }
            set
            {
                enableInterface = value;
            }
        }

        /// <summary>
        /// ��ϸ�������������б�
        /// </summary>
        public List<DetailReportConditionCompare> ConditionCompareList
        {
            get
            {
                return conditionCompareList;
            }
            set
            {
                conditionCompareList = value;
            }
        }
    }
}
